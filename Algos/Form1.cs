using FileTables;
using FileTables.Interfaces;
using System.Linq;
using Algos.Core.Models;
using Algos.Core;
using System.Text;
using FoggyBalrog.MermaidDotNet;
using FoggyBalrog.MermaidDotNet.MindMap;
using System.Collections.Concurrent;
using FoggyBalrog.MermaidDotNet.Flowchart.Model;
using FoggyBalrog.MermaidDotNet.Configuration.Model;
using FoggyBalrog.MermaidDotNet.Flowchart;
using static System.Net.Mime.MediaTypeNames;
using System;

namespace Algos
{
  public partial class Form1 : Form, ILogMsg {
    public Form1() {
      InitializeComponent();
      ConfigureSettings();
    }
    private Item? _inEditItem = null;
    private Item? _copiedItem = null;
    private bool _InReorder = false;
    private bool _InReset = false;
    private bool _InEdit = false;
    private bool _isModelActive = false;
    private string _ModelFileName = "";
    private ItemService _itemService;

    #region Configure Settings File and Dictionary
    private SettingsFile _settingsFile;
    private Settings _settings;
    private ItemTypeService _itemTypeService = new();
    private Types _types;
    private void ConfigureSettings() {
      _types = _itemTypeService.Types;
      if (!Directory.Exists(FormExt.DefaultPath)) {
        Directory.CreateDirectory(FormExt.DefaultPath);
      }
      _settingsFile = new SettingsFile(FormExt.DefaultSettingsFileName, this);
      _settings = _settingsFile.Settings;
    }
    private void SaveSettings() {
      _settingsFile.Settings = _settings;
      _settingsFile.Save();
    }
    #endregion

    #region Log Message Delegate ILogMsg
    delegate void SetLogMsgCallback(string msg);
    public void LogMsg(string msg) {
      if (this.edLogMsg.InvokeRequired) {
        SetLogMsgCallback d = new SetLogMsgCallback(LogMsg);
        this.BeginInvoke(d, new object[] { msg });
      } else {
        if (!edLogMsg.Visible) edLogMsg.Visible = true;
        this.edLogMsg.Text = msg + Environment.NewLine + edLogMsg.Text;
      }
    }

    #endregion

    #region Form Show Close Default Location settings. 
    private void Form1_Shown(object sender, EventArgs e) {
      SetLocationSettings();
      ModelActive = false;
      SetupModelFileNamePicker();
      this.Invoke((Action)(async () => {
        await wbOut.EnsureCoreWebView2Async().ConfigureAwait(false);
      }));
    }
    private void Form1_FormClosing(object sender, FormClosingEventArgs e) {
      SaveLocationSettings();
    }
    private void Form1_Resize(object sender, EventArgs e) {
      SaveLocationSettings();
    }
    private void SetLocationSettings() {
      if (_settings == null) return;
      if (_settings.ContainsKey("FormTop")) {
        this.Top = _settings["FormTop"].Value.AsInt32();
      }
      if (_settings.ContainsKey("FormLeft")) {
        this.Left = _settings["FormLeft"].Value.AsInt32();
      }
      if (_settings.ContainsKey("FormHeight")) {
        this.Height = _settings["FormHeight"].Value.AsInt32();
      }
      if (_settings.ContainsKey("FormWidth")) {
        this.Width = _settings["FormWidth"].Value.AsInt32();
      }
      if (_settings.ContainsKey("Split1")) {
        this.splitContainer1.SplitterDistance = _settings["Split1"].Value.AsInt32();
      }
      if (_settings.ContainsKey("Split2")) {
        this.splitContainer2.SplitterDistance = _settings["Split2"].Value.AsInt32();
      }
    }
    private void SaveLocationSettings() {
      if (_settings == null) return;
      if (!_settings.ContainsKey("FormTop")) {
        _settings["FormTop"] = new SettingProperty() { Key = "FormTop", Value = this.Top.AsString() };
      } else {
        _settings["FormTop"].Value = this.Top.AsString();
      }

      if (!_settings.ContainsKey("FormLeft")) {
        _settings["FormLeft"] = new SettingProperty() { Key = "FormLeft", Value = this.Left.AsString() };
      } else {
        _settings["FormLeft"].Value = this.Left.AsString();
      }

      if (!_settings.ContainsKey("FormHeight")) {
        _settings["FormHeight"] = new SettingProperty() { Key = "FormHeight", Value = this.Height.AsString() };
      } else {
        _settings["FormHeight"].Value = this.Height.AsString();
      }

      if (!_settings.ContainsKey("FormWidth")) {
        _settings["FormWidth"] = new SettingProperty() { Key = "FormWidth", Value = this.Width.AsString() };
      } else {
        _settings["FormWidth"].Value = this.Width.AsString();
      }

      if (!_settings.ContainsKey("Split1")) {
        _settings["Split1"] = new SettingProperty() { Key = "Split1", Value = this.splitContainer1.SplitterDistance.AsString() };
      } else {
        _settings["Split1"].Value = this.splitContainer1.SplitterDistance.AsString();
      }

      if (!_settings.ContainsKey("Split2")) {
        _settings["Split2"] = new SettingProperty() { Key = "Split2", Value = this.splitContainer2.SplitterDistance.AsString() };
      } else {
        _settings["Split2"].Value = this.splitContainer2.SplitterDistance.AsString();
      }
      SaveSettings();
    }
    private void SetupModelFileNamePicker() {
      _settings = _settingsFile.Settings;
      if (_settings.ContainsKey("MRUL")) {
        string MRUL = _settings["MRUL"].Value;
        if (MRUL.Length > 0) {
          comboBox1.Items.Clear();
          comboBox1.Items.AddRange(MRUL.Split(Environment.NewLine));
          comboBox1.SelectedIndex = 0;
        }
        _ModelFileName = _settings["ModelFileName"].Value;
      }
    }
    private void AddFileToMRUL(string fileName) {
      if (!_settings.ContainsKey("MRUL")) {
        _settings["MRUL"] = new SettingProperty() { Key = "MRUL", Value = fileName };
      } else {
        var mrul = _settings["MRUL"].Value.Parse(Environment.NewLine);
        string newMRUL = (mrul.Length > 0 ? mrul[0] : "")
          + (mrul.Length > 1 ? Environment.NewLine + mrul[1] : "")
          + (mrul.Length > 2 ? Environment.NewLine + mrul[2] : "");
        StringDict mruld = newMRUL.AsDict(Environment.NewLine);
        mruld.Add(fileName);
        _settings["MRUL"].Value = fileName + Environment.NewLine + mruld.AsString();
      }
    }
    #endregion

    #region Open the model
    private void btnBrowse_Click(object sender, EventArgs e) {
      if (_ModelFileName.Length > 0) {
        odMain.InitialDirectory = Path.GetDirectoryName(_ModelFileName);
        odMain.FileName = _ModelFileName;
      } else {
        odMain.InitialDirectory = FormExt.DefaultPath;
      }
      DialogResult dialogResult = odMain.ShowDialog();
      if (dialogResult == DialogResult.OK) {
        _ModelFileName = odMain.FileName;
        ModelActive = true;
      }
    }

    private void btnOpen_Click(object sender, EventArgs e) {
      if (ModelActive) {
        ModelActive = false;
        PopulateDisplays();
      } else {
        if (comboBox1.SelectedIndex != null) {
          _ModelFileName = comboBox1.SelectedItem.ToString();
        } else {
          _ModelFileName = comboBox1.Text;
        }
        var modelFolder = Path.GetDirectoryName(_ModelFileName);
        if (!Directory.Exists(modelFolder)) {
          Directory.CreateDirectory(modelFolder);
        }
        ModelActive = true;
      }
    }

    #endregion

    #region ModelActive and InEdit  

    public bool ModelActive {
      get { return _isModelActive; }
      set {
        _isModelActive = value;
        if (_isModelActive) {
          try {
            _itemService = new ItemService(treeView1, this, _itemTypeService, _ModelFileName);
            _itemService.LoadTreeviewItems(treeView1);
            AddFileToMRUL(_ModelFileName);
            SaveSettings();
          } catch (Exception ex) {
            MessageBox.Show("Error loading model: " + ex.Message);
            _isModelActive = false;
            return;
          }
          this.Text = "Algos - " + _ModelFileName;
          btnOpen.Text = "Close";
          lbFocusedItem.Text = "";
          btnOpen.ImageIndex = 1;

        } else {
          this.Text = "Algos - Choose file and click open to continue.";
          if (!btnBrowse.Visible) btnBrowse.Visible = true;
          if (!comboBox1.Visible) comboBox1.Visible = true;
          btnOpen.Text = "Open";
          _ModelFileName = "";
          lbFocusedItem.Text = "File To Open";
          treeView1.Nodes.Clear();
          _inEditItem = null;
          ResetPropertyEditors();
          btnOpen.ImageIndex = 0;
          if (btnSave.Visible) btnSave.Visible = false;
          if (btnCancel.Visible) btnCancel.Visible = false;

        }
      }
    }

    public bool InEdit {
      get { return _InEdit; }
      set {
        _InEdit = value;
        if (_InEdit) {
          if (!btnSave.Visible) btnSave.Visible = true;
          if (!btnCancel.Visible) btnCancel.Visible = true;
          if (edName.BackColor != Color.LightYellow) edName.BackColor = Color.LightYellow;
          if (cbShape.BackColor != Color.LightYellow) cbShape.BackColor = Color.LightYellow;
          if (cbEdit2.BackColor != Color.LightYellow) cbEdit2.BackColor = Color.LightYellow;
          if (cbEdit3.BackColor != Color.LightYellow) cbEdit3.BackColor = Color.LightYellow;
          //  if (cbExpandedShape.BackColor != Color.LightYellow) cbExpandedShape.BackColor = Color.LightYellow;
          if (edLine2.BackColor != Color.LightYellow) edLine2.BackColor = Color.LightYellow;
        } else {
          if (btnSave.Visible) btnSave.Visible = false;
          if (btnCancel.Visible) btnCancel.Visible = false;
          if (edName.BackColor != Color.White) edName.BackColor = Color.White;
          if (cbShape.BackColor != Color.White) cbShape.BackColor = Color.White;
          if (cbEdit2.BackColor != Color.White) cbEdit2.BackColor = Color.White;
          if (cbEdit3.BackColor != Color.White) cbEdit3.BackColor = Color.White;
          // if (cbExpandedShape.BackColor != Color.White) cbExpandedShape.BackColor = Color.White;
          if (edLine2.BackColor != Color.White) edLine2.BackColor = Color.White;
        }
      }
    }

    #endregion

    #region Treeview Context Menus 
    private void contextMenuStrip1_Opening(object sender, System.ComponentModel.CancelEventArgs e) {
      if (_inEditItem == null) {
        addFlowchartNodeMenuItem.Visible = false;
        addFlowchartSubGraphToolStripMenuItem.Visible = false;
        addFlowchartLinkMenuItem.Visible = false;
        addMindMapNodeMenuItem.Visible = false;
        removeSelectedItemToolStripMenuItem.Visible = false;
        LocalCopyMenuItem.Visible = false;

      } else {
        var diagramNode = _itemService.GetDiagramNode(_inEditItem);
        if (diagramNode.ItemTypeId == _types.MindMapDiagram.Id) {
          addFlowchartNodeMenuItem.Visible = false;
          addFlowchartLinkMenuItem.Visible = false;
          addFlowchartSubGraphToolStripMenuItem.Visible = false;
          addMindMapNodeMenuItem.Visible = true;
        } else if (diagramNode.ItemTypeId == _types.FlowChartDiagram.Id) {
          if (_inEditItem.ItemTypeId == _types.FlowChartDiagram.Id) {
            addFlowchartNodeMenuItem.Visible = true;
            addFlowchartLinkMenuItem.Visible = false;
            addMindMapNodeMenuItem.Visible = false;
            addFlowchartSubGraphToolStripMenuItem.Visible = true;
          } else if (_inEditItem.ItemTypeId == _types.FlowChartNode.Id) {
            addFlowchartNodeMenuItem.Visible = true;
            addFlowchartLinkMenuItem.Visible = true;
            addMindMapNodeMenuItem.Visible = false;
            addFlowchartSubGraphToolStripMenuItem.Visible = true;
          } else if (_inEditItem.ItemTypeId == _types.FlowChartSubGraph.Id) {
            addFlowchartNodeMenuItem.Visible = true;
            addFlowchartLinkMenuItem.Visible = true;
            addMindMapNodeMenuItem.Visible = false;
            addFlowchartSubGraphToolStripMenuItem.Visible = true;
          } else {
            addFlowchartNodeMenuItem.Visible = false;
            addFlowchartLinkMenuItem.Visible = false;
            addMindMapNodeMenuItem.Visible = false;
            addFlowchartSubGraphToolStripMenuItem.Visible = false;
          }
        } else {
          addFlowchartNodeMenuItem.Visible = false;
          addFlowchartLinkMenuItem.Visible = false;
          addMindMapNodeMenuItem.Visible = false;
          addFlowchartSubGraphToolStripMenuItem.Visible = false;
        }
        removeSelectedItemToolStripMenuItem.Visible = true;
        LocalCopyMenuItem.Visible = true;
      }
      if (_copiedItem == null || _inEditItem == null) {
        LocalPasteMenuItem.Visible = false;
      } else {
        var copiedDiagram = _itemService.GetDiagramNode(_copiedItem);
        var targetDiagram = _itemService.GetDiagramNode(_inEditItem);
        LocalPasteMenuItem.Visible = (copiedDiagram?.ItemTypeId == targetDiagram?.ItemTypeId) &&
          _inEditItem.ItemTypeId != _types.FlowChartLink.Id;
      }
    }

    private void newMindMapDialogToolStripMenuItem_Click(object sender, EventArgs e) {
      var nextDiagramNumber = _itemService.GetDiagramCount() + 1;
      var newMindMap = _itemService.SaveNewChildItemsFromText(null, _types.MindMapDiagram, $"Mindmap{nextDiagramNumber}");
    }

    private void addMindmapNodeMenuItem_Click(object sender, EventArgs e) {
      if (_inEditItem != null &&
          (_inEditItem.ItemTypeId == _types.MindMapDiagram.Id || _inEditItem.ItemTypeId == _types.MindMapShapes.Id)) {
        var newMindMap = _itemService.SaveNewChildItemsFromText(_inEditItem, _types.MindMapShapes, "MindmapNode");
      }
    }

    private void newFlowchartDiagramMenuItem_Click(object sender, EventArgs e) {
      var nextDiagramNumber = _itemService.GetDiagramCount() + 1;
      var newFlowChart = _itemService.SaveNewChildItemsFromText(null, _types.FlowChartDiagram, $"Flowchart{nextDiagramNumber}");
    }
    private void addFlowchartNodeMenuItem_Click(object sender, EventArgs e) {
      if (_inEditItem != null &&
        (_inEditItem.ItemTypeId == _types.FlowChartDiagram.Id || _inEditItem.ItemTypeId == _types.FlowChartNode.Id || _inEditItem.ItemTypeId == _types.FlowChartSubGraph.Id)) {
        var newFlowChartNode = _itemService.SaveNewChildItemsFromText(_inEditItem, _types.FlowChartNode, "item");
      }
    }
    private void addFlowchartLinkMenuItem_Click(object sender, EventArgs e) {
      if (_inEditItem != null &&
        (_inEditItem.ItemTypeId == _types.FlowChartNode.Id || _inEditItem.ItemTypeId == _types.FlowChartLink.Id || _inEditItem.ItemTypeId == _types.FlowChartSubGraph.Id)) {
        var newFlowChartLink = _itemService.SaveNewChildItemsFromText(_inEditItem, _types.FlowChartLink, "is");
      }
    }
    private void addFlowchartSubGraphToolStripMenuItem_Click(object sender, EventArgs e) {
      if (_inEditItem != null &&
        (_inEditItem.ItemTypeId == _types.FlowChartNode.Id || _inEditItem.ItemTypeId == _types.FlowChartLink.Id || _inEditItem.ItemTypeId == _types.FlowChartSubGraph.Id)) {
        var newFlowChartLink = _itemService.SaveNewChildItemsFromText(_inEditItem, _types.FlowChartSubGraph, "sub");
      }
    }
    private void MoveItemUpMenuItem_Click(object sender, EventArgs e) {
      if (_inEditItem == null) return;
      if (!_inEditItem.CanSwitchUp()) return;
      var otherItem = _inEditItem.GetSwitchUpItem();
      _inEditItem.SwitchRankUp();
      if (_inEditItem.Dirty) { _itemService.UpdateItem(_inEditItem); }
      if (otherItem != null && otherItem.Dirty) _itemService.UpdateItem(otherItem);

      var opItem = _inEditItem;
      _InReorder = true;
      try {
        var parentItem = (Item)_inEditItem.Parent;
        var otherItemIndex = parentItem.Nodes.IndexOf(otherItem);
        if (otherItemIndex >= 0) {
          parentItem.Nodes.Remove(opItem);
          parentItem.Nodes.Insert(otherItemIndex, opItem);
        }
      } finally {
        _InReorder = false;
      }
      treeView1.SelectedNode = opItem;
      _itemService.UpdateItem(_inEditItem, false);
      _itemService.UpdateItem(otherItem, true);

    }

    private void LocalCopyMenuItem_Click(object sender, EventArgs e) {
      if (treeView1.SelectedNode is Item selectedItem) {
        _copiedItem = selectedItem;
        LogMsg($"Item '{selectedItem.Name}' copied.");
      }
    }

    private void LocalPasteMenuItem_Click(object sender, EventArgs e) {
      if (_copiedItem != null && treeView1.SelectedNode is Item selectedItem) {
        try {
          _itemService.CopyItemTo(selectedItem, _copiedItem);
          LogMsg($"Item '{_copiedItem.Name}' pasted under '{selectedItem.Name}'.");
        } catch (Exception ex) {
          LogMsg($"Error pasting item: {ex.Message}");
          MessageBox.Show($"Error pasting item: {ex.Message}");
        }
      }
    }

    private void removeSelectedItemToolStripMenuItem_Click(object sender, EventArgs e) {
      if (_inEditItem == null) return;
      Item item = _inEditItem;
      Item ParentItem = (Item)item.Parent;
      if (ParentItem != null) {
        treeView1.SelectedNode = ParentItem;
        ParentItem.Nodes.Remove(item);
      }
      _itemService.RemoveItem(_inEditItem);
      treeView1_AfterSelect(sender, new TreeViewEventArgs(ParentItem));
    }
    #endregion

    #region TreeView After Select Events Handlers 
    private void treeView1_AfterSelect(object sender, TreeViewEventArgs e) {
      if (!_InReorder) {
        if (e.Node == null) return;
        var oldDiagram = _itemService.GetDiagramNode(_inEditItem);
        var newDiagram = _itemService.GetDiagramNode((Item)e.Node);
        _inEditItem = (Item)e.Node;
        ResetPropertyEditors();
        if (oldDiagram?.Id != newDiagram?.Id) {
          PopulateDisplays();
        }
      }
    }
    private void treeView1_AfterLabelEdit(object sender, NodeLabelEditEventArgs e) {
      try {

        if (_inEditItem != (Item)e.Node) {
          _inEditItem = (Item)e.Node;
        }
        if (_inEditItem == null || e.Label == null) {
          e.CancelEdit = true;
          return;
        }
        if (_inEditItem.Name != e.Label) {
          _inEditItem.Name = e.Label;
          ResetPropertyEditors();
          InEdit = true;
        }
      } catch (Exception ex) {
        LogMsg(ex.Message);
      }

    }

    #region Drag and Drop Handlers

    private void treeView1_ItemDrag(object sender, ItemDragEventArgs e) {
      if (e.Button == MouseButtons.Left && e.Item != null) {
        DoDragDrop(e.Item, DragDropEffects.Move);
      }
    }

    private void treeView1_DragDrop(object sender, DragEventArgs e) {
      try {
        Point targetPt = treeView1.PointToClient(new Point(e.X, e.Y));
        Item targetItem = (Item)treeView1.GetNodeAt(targetPt);

        if (targetItem != null && e.Data != null) {
          Item dragNode = (Item)e.Data.GetData(typeof(Item));
          if (dragNode != null) {
            var fnn = _itemService.MoveItemSave(targetItem, dragNode);
          }
        }
      } catch (Exception edd) {
        LogMsg(edd.Message);
      } finally {
      }
    }

    private void treeView1_DragEnter(object sender, DragEventArgs e) {
      e.Effect = DragDropEffects.Move;
    }

    private void treeView1_DragOver(object sender, DragEventArgs e) {
      if (e.Data != null) {
        Item selectedItem = (Item)e.Data.GetData(typeof(Item));
        if (selectedItem != null) {
          Point targetPt = treeView1.PointToClient(new Point(e.X, e.Y));
          Item targetNode = (Item)treeView1.GetNodeAt(targetPt);
          if (targetNode != selectedItem) {
            if (targetNode != null) {

              var targetDiagramNode = _itemService.GetDiagramNode(targetNode);
              var selectedDiagramNode = _itemService.GetDiagramNode(selectedItem);
              if ((targetDiagramNode?.ItemTypeId ?? 0) == (selectedDiagramNode?.ItemTypeId ?? 1)) {

                if (!targetNode.IsExpanded) targetNode.Expand();
                if (targetNode.ItemTypeId == _types.MindMapDiagram.Id) {
                  e.Effect = DragDropEffects.Move;
                } else if (targetNode.ItemTypeId == _types.FlowChartDiagram.Id && selectedItem.ItemTypeId == _types.FlowChartNode.Id) {
                  e.Effect = DragDropEffects.Move;
                } else if (targetNode.ItemTypeId == _types.FlowChartNode.Id &&
                  (selectedItem.ItemTypeId == _types.FlowChartNode.Id || selectedItem.ItemTypeId == _types.FlowChartLink.Id)) {
                  e.Effect = DragDropEffects.Move;
                } else if (targetNode.ItemTypeId == _types.FlowChartLink.Id) {
                  e.Effect = DragDropEffects.None;
                } else {
                  e.Effect = DragDropEffects.None;
                }

              } else {
                e.Effect = DragDropEffects.None;
              }

            } else {
              e.Effect = DragDropEffects.None;
            }
          }
        }
      }

    }

    #endregion
    #endregion

    #region Editors and change handlers

    private void EnsureEditorVisibility() {
      if (_inEditItem != null) {
        var diagramNode = _itemService.GetDiagramNode(_inEditItem);
        if (!lbTech.Visible) lbTech.Visible = true;
        if (!label1.Visible) label1.Visible = true;
        if (!edName.Visible) edName.Visible = true;

        if (diagramNode.ItemTypeId == _types.MindMapDiagram.Id) {

          if (cbExpandedShape.Visible) cbExpandedShape.Visible = false;
          if (!cbShape.Visible) cbShape.Visible = true;
          if (!lbShape.Visible) lbShape.Visible = true;
          if (cbEdit2.Visible) cbEdit2.Visible = false;
          if (lbEdit2.Visible) lbEdit2.Visible = false;
          if (cbEdit3.Visible) cbEdit3.Visible = false;
          if (lbEdit3.Visible) lbEdit3.Visible = false;

        } else if (diagramNode.ItemTypeId == _types.FlowChartDiagram.Id) {

          if (!cbShape.Visible) cbShape.Visible = true;
          if (!lbShape.Visible) lbShape.Visible = true;
          if (_inEditItem.ItemTypeId == _types.FlowChartDiagram.Id) {
            if (cbExpandedShape.Visible) cbExpandedShape.Visible = false;
            if (cbEdit2.Visible) cbEdit2.Visible = false;
            if (lbEdit2.Visible) lbEdit2.Visible = false;
            if (cbEdit3.Visible) cbEdit3.Visible = false;
            if (lbEdit3.Visible) lbEdit3.Visible = false;
            if (!lbLine2.Visible) lbLine2.Visible = true;
            if (!edLine2.Visible) edLine2.Visible = true;
          } else if (_inEditItem.ItemTypeId == _types.FlowChartNode.Id) {
            if (!cbExpandedShape.Visible) cbExpandedShape.Visible = true;
            if (cbEdit2.Visible) cbEdit2.Visible = false;
            if (lbEdit2.Visible) lbEdit2.Visible = false;
            if (cbEdit3.Visible) cbEdit3.Visible = false;
            if (lbEdit3.Visible) lbEdit3.Visible = false;
            if (lbLine2.Visible) lbLine2.Visible = false;
            if (edLine2.Visible) edLine2.Visible = false;
          } else if (_inEditItem.ItemTypeId == _types.FlowChartSubGraph.Id) {
            if (cbExpandedShape.Visible) cbExpandedShape.Visible = false;
            if (cbEdit2.Visible) cbEdit2.Visible = false;
            if (lbEdit2.Visible) lbEdit2.Visible = false;
            if (cbEdit3.Visible) cbEdit3.Visible = false;
            if (lbEdit3.Visible) lbEdit3.Visible = false;
            if (lbLine2.Visible) lbLine2.Visible = false;
            if (edLine2.Visible) edLine2.Visible = false;
          } else if (_inEditItem.ItemTypeId == _types.FlowChartLink.Id) {
            if (!cbExpandedShape.Visible) cbExpandedShape.Visible = true;
            if (!cbEdit2.Visible) cbEdit2.Visible = true;
            if (!lbEdit2.Visible) lbEdit2.Visible = true;
            if (!cbEdit3.Visible) cbEdit3.Visible = true;
            if (!lbEdit3.Visible) lbEdit3.Visible = true;
            if (lbLine2.Visible) lbLine2.Visible = false;
            if (edLine2.Visible) edLine2.Visible = false;
          }
        }
      } else {
        if (label1.Visible) label1.Visible = false;
        if (cbShape.Visible) cbShape.Visible = false;
        if (cbExpandedShape.Visible) cbExpandedShape.Visible = false;
        if (cbEdit2.Visible) cbEdit2.Visible = false;
        if (lbShape.Visible) lbShape.Visible = false;
        if (lbEdit2.Visible) lbEdit2.Visible = false;
        if (lbTech.Visible) lbTech.Visible = false;
        if (edName.Visible) edName.Visible = false;
        if (cbEdit3.Visible) cbEdit3.Visible = false;
        if (lbEdit3.Visible) lbEdit3.Visible = false;
        if (lbLine2.Visible) lbLine2.Visible = false;
        if (edLine2.Visible) edLine2.Visible = false;
      }
    }
    private void ResetPropertyEditors() {
      EnsureEditorVisibility();
      if (_inEditItem != null) {
        _InReset = true;
        try {

          lbFocusedItem.Text = _inEditItem.Name;
          edName.Text = _inEditItem.Name;
          var editStr = _InEdit ? "Edit" : "View";
          lbTech.Text = $"{editStr} Id {_inEditItem.Id};";

          var diagramNode = _itemService.GetDiagramNode(_inEditItem);
          if (diagramNode.ItemTypeId == _types.MindMapDiagram.Id) {
            lbShape.Text = "Shape";
            ConfigureComboBoxTypes(cbShape, _inEditItem.ShapeId, _types.GetChildrenItemsNoDef(_types.MindMapShapes.Id));
          } else if (diagramNode.ItemTypeId == _types.FlowChartDiagram.Id) {

            if (_inEditItem.ItemTypeId == _types.FlowChartDiagram.Id || _inEditItem.ItemTypeId == _types.FlowChartSubGraph.Id) {
              lbShape.Text = "Align:";
              edLine2.Text = _inEditItem.Title;
              ConfigureComboBoxTypes(cbShape, _inEditItem.OrientationId, _types.GetChildrenItemsNoDef(_types.FlowChartOrientation.Id));
            } else if (_inEditItem.ItemTypeId == _types.FlowChartNode.Id) {

              cbExpandedShape.Text = "Use Expanded Shapes";
              if (!cbExpandedShape.Visible) cbExpandedShape.Visible = true;
              if (cbExpandedShape.Checked != _inEditItem.IsExpandedShape) {
                cbExpandedShape.Checked = _inEditItem.IsExpandedShape;
              }

              lbShape.Text = "Shape";
              if (cbExpandedShape.Checked) {
                ConfigureComboBoxTypes(cbShape, _inEditItem.ShapeId, _types.GetChildrenItemsNoDef(_types.FlowChartExtShape.Id));
              } else {
                ConfigureComboBoxTypes(cbShape, _inEditItem.ShapeId, _types.GetChildrenItemsNoDef(_types.FlowChartShapes.Id));
              }

            } else if (_inEditItem.ItemTypeId == _types.FlowChartLink.Id) {

              if (!cbExpandedShape.Visible) cbExpandedShape.Visible = true;
              cbExpandedShape.Text = "Link Multi Directional";
              if (cbExpandedShape.Checked != _inEditItem.IsLinkMultidirectional) {
                cbExpandedShape.Checked = _inEditItem.IsLinkMultidirectional;
              }

              lbShape.Text = "Link To";
              ConfigureComboBoxItems(cbShape, _inEditItem.OrientationId, _itemService.GetFlowchartNodes(diagramNode));

              lbEdit2.Text = "Line Style";
              ConfigureComboBoxTypes(cbEdit2, _inEditItem.LinkLineStyleId, _types.GetChildrenItemsNoDef(_types.FlowChartLinkLineStyle.Id));

              lbEdit3.Text = "Link Ends";
              ConfigureComboBoxTypes(cbEdit3, _inEditItem.LinkEndingId, _types.GetChildrenItemsNoDef(_types.FlowChartLinkEnding.Id));
            }


          }


        } catch (Exception ex) {
          LogMsg(ex.Message);
        } finally {
          _InReset = false;
        }
        InEdit = false;
      }
    }

    public void ConfigureComboBoxItems(ComboBox cb, int SelectedIndex, IEnumerable<Item> nodes) {
      cb.DataSource = nodes;
      cb.DisplayMember = "Name";
      cb.ValueMember = "Id";
      try {
        var item = nodes.FirstOrDefault(x => x.Id == SelectedIndex);
        if (item != null) {
          cb.SelectedValue = item.Id;
        } else {
          cb.SelectedIndex = nodes.First().Id;
        }
      } catch (Exception e1) {
        LogMsg(e1.Message);
      }
    }

    private void ConfigureComboBoxTypes(ComboBox cb, int SelectedIndex, IEnumerable<ItemType>? types) {
      if (types != null) {
        cb.DataSource = types;
        cb.DisplayMember = "Name";
        cb.ValueMember = "Id";
        try {
          var item = types.FirstOrDefault(x => x.Id == SelectedIndex);
          if (item != null) {
            cb.SelectedValue = item.Id;
          } else {
            cb.SelectedIndex = types.First().Id;
          }
        } catch (Exception e2) {
          LogMsg(e2.Message);
        }
      }
    }


    private void edName_TextChanged(object sender, EventArgs e) {
      if (!_InReset && _inEditItem != null && edName.Text.Length > 0) {
        if (_inEditItem.Name != edName.Text) {
          InEdit = true;
        }
      }
    }

    private void edLine2_TextChanged(object sender, EventArgs e) {
      if (!_InReset && _inEditItem != null && edLine2.Text.Length > 0) {
        if (_inEditItem.Title != edLine2.Text) {
          InEdit = true;
        }
      }
    }
    private void cbExpandedShape_CheckedChanged(object sender, EventArgs e) {
      if (!_InReset && _inEditItem != null) {
        if (_inEditItem.ItemTypeId == _types.FlowChartNode.Id && cbExpandedShape.Checked != _inEditItem.IsExpandedShape) {
          InEdit = true;
          if (cbExpandedShape.Checked) {
            ConfigureComboBoxTypes(cbShape, _inEditItem.ShapeId, _types.GetChildrenItemsNoDef(_types.FlowChartExtShape.Id));
          } else {
            ConfigureComboBoxTypes(cbShape, _inEditItem.ShapeId, _types.GetChildrenItemsNoDef(_types.FlowChartShapes.Id));
          }
        } else if (_inEditItem.ItemTypeId == _types.FlowChartLink.Id && cbExpandedShape.Checked != _inEditItem.IsLinkMultidirectional) {
          InEdit = true;
        }
      }
    }

    private void cbShape_SelectedIndexChanged(object sender, EventArgs e) {
      if (!_InReset && _inEditItem != null) {
        var diagramNode = _itemService.GetDiagramNode(_inEditItem);
        if (diagramNode.ItemTypeId == _types.MindMapDiagram.Id || diagramNode.ItemTypeId == _types.MindMapNodes.Id) {
          if (cbShape.SelectedValue != null && _inEditItem.ShapeId != cbShape.SelectedValue.AsInt32()) {
            InEdit = true;
          }
        } else if (diagramNode.ItemTypeId == _types.FlowChartDiagram.Id) {
          if (_inEditItem.ItemTypeId == _types.FlowChartDiagram.Id || _inEditItem.ItemTypeId == _types.FlowChartSubGraph.Id) {
            if (cbShape.SelectedValue != null && _inEditItem.OrientationId != cbShape.SelectedValue.AsInt32()) {
              InEdit = true;
            }
          } else if (_inEditItem.ItemTypeId == _types.FlowChartNode.Id) {
            if (cbShape.SelectedValue != null && _inEditItem.ShapeId != cbShape.SelectedValue.AsInt32()) {
              InEdit = true;
            }
          } else if (_inEditItem.ItemTypeId == _types.FlowChartLink.Id) {
            if (cbShape.SelectedValue != null && _inEditItem.OrientationId != cbShape.SelectedValue.AsInt32()) {
              InEdit = true;
            }
          }
        }
      }
    }

    private void cbEdit2_SelectedIndexChanged(object sender, EventArgs e) {
      if (!_InReset && _inEditItem != null) {
        var diagramNode = _itemService.GetDiagramNode(_inEditItem);
        if (diagramNode.ItemTypeId == _types.FlowChartDiagram.Id) {
          if (_inEditItem.ItemTypeId == _types.FlowChartLink.Id) {
            if (cbEdit2.SelectedValue != null && _inEditItem.LinkLineStyleId != cbEdit2.SelectedValue.AsInt32()) {
              InEdit = true;
            }
          }
        }
      }
    }

    private void cbEdit3_SelectedIndexChanged(object sender, EventArgs e) {
      if (!_InReset && _inEditItem != null) {
        var diagramNode = _itemService.GetDiagramNode(_inEditItem);
        if (diagramNode.ItemTypeId == _types.FlowChartDiagram.Id) {
          if (_inEditItem.ItemTypeId == _types.FlowChartLink.Id) {
            if (cbEdit3.SelectedValue != null && _inEditItem.LinkEndingId != cbEdit3.SelectedValue.AsInt32()) {
              InEdit = true;
            }
          }
        }
      }
    }

    private void btnCancel_Click(object sender, EventArgs e) {
      ResetPropertyEditors();
    }

    private void btnSave_Click(object sender, EventArgs e) {
      if (_inEditItem != null) {

        _inEditItem.Name = edName.Text;
        var diagramNode = _itemService.GetDiagramNode(_inEditItem);

        if (diagramNode.ItemTypeId == _types.MindMapDiagram.Id) {

          if (cbShape.SelectedValue != null && _inEditItem.ShapeId != cbShape.SelectedValue.AsInt32()) {
            _inEditItem.ShapeId = cbShape.SelectedValue.AsInt32();
          }

        } else if (diagramNode.ItemTypeId == _types.FlowChartDiagram.Id) {

          if (_inEditItem.ItemTypeId == _types.FlowChartDiagram.Id || _inEditItem.ItemTypeId == _types.FlowChartSubGraph.Id) {
            if (cbShape.SelectedValue != null && _inEditItem.OrientationId != cbShape.SelectedValue.AsInt32()) {
              _inEditItem.OrientationId = cbShape.SelectedValue.AsInt32();
              _inEditItem.Title = edLine2.Text;
            }
          } else if (_inEditItem.ItemTypeId == _types.FlowChartNode.Id) {
            _inEditItem.IsExpandedShape = cbExpandedShape.Checked;
            if (cbShape.SelectedValue != null && _inEditItem.ShapeId != cbShape.SelectedValue.AsInt32()) {
              _inEditItem.ShapeId = cbShape.SelectedValue.AsInt32();
            }
          } else if (_inEditItem.ItemTypeId == _types.FlowChartLink.Id) {
            if (cbShape.SelectedValue != null && _inEditItem.OrientationId != cbShape.SelectedValue.AsInt32()) {
              _inEditItem.OrientationId = cbShape.SelectedValue.AsInt32();
            }
            if (cbEdit2.SelectedValue != null && _inEditItem.LinkLineStyleId != cbEdit2.SelectedValue.AsInt32()) {
              _inEditItem.LinkLineStyleId = cbEdit2.SelectedValue.AsInt32();
            }
            if (cbEdit3.SelectedValue != null && _inEditItem.LinkEndingId != cbEdit3.SelectedValue.AsInt32()) {
              _inEditItem.LinkEndingId = cbEdit3.SelectedValue.AsInt32();
            }
            _inEditItem.IsLinkMultidirectional = cbExpandedShape.Checked;

          }

        }

        _itemService.UpdateItem(_inEditItem);
        ResetPropertyEditors();
        PopulateDisplays();
      }
    }

    #endregion       

    #region Mermaid Diagram code generation and display
    private void PopulateDisplays() {
      if (_inEditItem != null) {
        wbOut.CoreWebView2.NavigateToString(GetMermaidForm(_inEditItem));
      } else {
        wbOut.CoreWebView2.NavigateToString("Open a file and select something in the tree.");
      }

    }

    private ConcurrentDictionary<int, FoggyBalrog.MermaidDotNet.MindMap.Model.Node> _mindmapNodes = new();
    private ConcurrentDictionary<int, FoggyBalrog.MermaidDotNet.Flowchart.Model.Node> _flowchartNodes = new();
    private ConcurrentDictionary<int, FoggyBalrog.MermaidDotNet.Flowchart.Model.Subgraph> _flowchartSubgraphs = new();
    private MindMapBuilder AddNodeByItem(Item it, MindMapBuilder mindMapBuilder) {

      var aParent = _mindmapNodes.ContainsKey(it.OwnerId) ? _mindmapNodes[it.OwnerId] : null;
      var aShape = _types[it.ShapeId].MindmapNodeShape;
      var bIsMarkdown = it.IsMarkdown;
      var ShowIcon = it.IconUrl.Length > 0 ? it.IconUrl : null;
      var saClasses = it.CssClass.Split(' ', StringSplitOptions.RemoveEmptyEntries);

      var node = mindMapBuilder.AddNode(it.Name, out var newNode, aParent, aShape, bIsMarkdown, ShowIcon, saClasses);
      _mindmapNodes[it.Id] = newNode;

      foreach (var child in it.Nodes) {
        AddNodeByItem((Item)child, node);
      }
      return mindMapBuilder;
    }

    private string MakeMindmapDiagram(Item diagram) {
      _mindmapNodes.Clear();
      string sRootText = diagram.Name;
      string sRootTitle = diagram.Name;
      MermaidConfig? aMermaidConfig = null;
      bool bIsMarkown = diagram.IsMarkdown;
      var aNodeShape = FoggyBalrog.MermaidDotNet.MindMap.Model.NodeShape.Default;
      string? sRootIcon = diagram.IconUrl.Length > 0 ? diagram.IconUrl : null;
      string[]? saRootClasses = diagram.CssClass.Split(' ', StringSplitOptions.RemoveEmptyEntries);
      var mindMapBuilder = Mermaid.MindMap(sRootText, sRootTitle, aMermaidConfig, aNodeShape, bIsMarkown, sRootIcon, saRootClasses);
      foreach (var child in diagram.Nodes) {
        AddNodeByItem((Item)child, mindMapBuilder);
      }
      return mindMapBuilder.Build();
    }

    private FlowchartBuilder AddFlowChartNodeByItem(Item it, FlowchartBuilder flowChartBuilder) {
      try {
        var bIsMarkdown = it.IsMarkdown;
        var ShowIcon = it.IconUrl.Length > 0 ? it.IconUrl : null;
        var saClasses = it.CssClass.Split(' ', StringSplitOptions.RemoveEmptyEntries);

        if (it.ItemTypeId == _types.FlowChartNode.Id) {

          if (it.IsExpandedShape) {
            var aShape = _types[it.ShapeId].FlowChartExpandedNodeShape;
            _ = flowChartBuilder.AddNodeWithExpandedShape(it.Name, out FoggyBalrog.MermaidDotNet.Flowchart.Model.Node nNode, aShape);
            if (nNode != null) _flowchartNodes[it.Id] = nNode;
          } else {
            _ = flowChartBuilder.AddNode(it.Name, out FoggyBalrog.MermaidDotNet.Flowchart.Model.Node nNode, _types[it.ShapeId].FlowChartNodeShape);
            if (nNode != null) _flowchartNodes[it.Id] = nNode;
          }

        } else if (it.ItemTypeId == _types.FlowChartSubGraph.Id) {
          return flowChartBuilder;
        }

        foreach (var child in it.Nodes) {
          AddFlowChartNodeByItem((Item)child, flowChartBuilder);
        }
        return flowChartBuilder;

      } catch (Exception e) {
        LogMsg(e.Message);
        return flowChartBuilder;
      }
    }

    private FlowchartBuilder AddFlowChartLinkByItem(Item it, FlowchartBuilder flowChartBuilder) {
      try {

        if (it.ItemTypeId == _types.FlowChartLink.Id) {
          var aLineStyle = _types[it.LinkLineStyleId].FlowChartLinkLineStyle;
          var aLinkEnding = _types[it.LinkEndingId].FlowChartLinkEnding;
          var LinkToNode = _flowchartNodes.ContainsKey(it.OrientationId) ? _flowchartNodes[it.OrientationId] : null;
          var LinkFromNode = _flowchartNodes.ContainsKey(it.OwnerId) ? _flowchartNodes[it.OwnerId] : null;
          if (LinkToNode != null && LinkFromNode != null) {
            _ = flowChartBuilder.AddLink(LinkFromNode, LinkToNode, out Link nLink, it.Name, aLineStyle, aLinkEnding, it.IsLinkMultidirectional, 0);
          }
        } else if (it.ItemTypeId == _types.FlowChartSubGraph.Id) {
          return flowChartBuilder;
        }

        foreach (var child in it.Nodes) {
          AddFlowChartLinkByItem((Item)child, flowChartBuilder);
        }
        return flowChartBuilder;

      } catch (Exception e) {
        LogMsg(e.Message);
        return flowChartBuilder;
      }
    }

    private FlowchartBuilder AddFlowChartSubGraphByItem(Item it, FlowchartBuilder flowChartBuilder) {
      try {
        if (it.ItemTypeId == _types.FlowChartSubGraph.Id) {
          var aTitle = it.Name;
          var aOrientation = _types[it.OrientationId].FlowChartOrientation;
          var subGraph = flowChartBuilder.AddSubgraph(aTitle, out Subgraph subgraph, builder => {
            foreach (var child in it.Nodes) {
              AddFlowChartNodeByItem((Item)child, builder);
            }
            foreach (var child in it.Nodes) {
              AddFlowChartSubGraphByItem((Item)child, flowChartBuilder);
            }
            foreach (var child in it.Nodes) {
              AddFlowChartLinkByItem((Item)child, builder);
            }
          }, aOrientation);
          if (subgraph != null) _flowchartSubgraphs[it.Id] = subgraph;
        } else {
          foreach (var child in it.Nodes) {
            AddFlowChartSubGraphByItem((Item)child, flowChartBuilder);
          }
        }

        return flowChartBuilder;
      } catch (Exception e) {
        LogMsg(e.Message);
        return flowChartBuilder;
      }
    }


    private string MakeFlowchartDiagram(Item diagram) {
      _flowchartNodes.Clear();
      _flowchartSubgraphs.Clear();
      var aTitle = diagram.Name;
      var aOrientation = _types[diagram.OrientationId].FlowChartOrientation;
      var flowchartBuilder = Mermaid.Flowchart(aTitle, null, aOrientation);
      foreach (var child in diagram.Nodes) {
        AddFlowChartNodeByItem((Item)child, flowchartBuilder);
      }
      foreach (var child in diagram.Nodes) {
        AddFlowChartSubGraphByItem((Item)child, flowchartBuilder);
      }
      foreach (var child in diagram.Nodes) {
        AddFlowChartLinkByItem((Item)child, flowchartBuilder);
      }
      return flowchartBuilder.Build();
    }

    private string PrepareDiagramScript(Item it) {
      StringBuilder sb = new();

      var diagramNode = _itemService.GetDiagramNode(it);
      if (diagramNode == null) {
        throw new Exception("No diagram found?");
      }
      if (diagramNode.ItemTypeId == _types.MindMapDiagram.Id) {
        return MakeMindmapDiagram(diagramNode);
      } else if (diagramNode.ItemTypeId == _types.FlowChartDiagram.Id) {
        return MakeFlowchartDiagram(diagramNode);
      }
      throw new Exception("Diagram type not yet supported");
    }

    private string GetMermaidForm(Item it) {
      StringBuilder sb = new StringBuilder();
      var mermaidScript = "";

      var errorMsg = "";
      try {
        mermaidScript = PrepareDiagramScript(it);
      } catch (Exception e0) {
        errorMsg = e0.Message;
      }


      sb.AppendLine("<!DOCTYPE html>\r\n<html lang=\"en\">");
      sb.AppendLine("<head>\r\n  <meta charset=\"UTF-8\"/>");
      sb.AppendLine($"<title>Algos Display</title>");
      sb.AppendLine("<script type=\"module\">");
      sb.AppendLine("  import mermaid from 'https://cdn.jsdelivr.net/npm/mermaid@10/dist/mermaid.esm.min.mjs';");
      sb.AppendLine("  mermaid.initialize({ startOnLoad: true, securityLevel: 'loose', theme: 'base' });");
      sb.AppendLine("  document.addEventListener(\"DOMContentLoaded\", () => { mermaid.init(undefined, document.querySelectorAll(\".mermaid\")); });");
      sb.AppendLine("</script>");
      sb.AppendLine("<style>");
      sb.AppendLine("  body { font-family: 'Segoe UI', Arial, sans-serif; font-size: 12.2pt; }");
      sb.AppendLine("  .mermaid-container { display: flex; justify-content: center; }");
      sb.AppendLine("  .copy-container { display: flex; justify-content: center; margin-top: 20px; }");
      sb.AppendLine("  textarea { width: 80%; height: 100px; }");
      sb.AppendLine("  button { margin-left: 10px; padding: 5px 10px; }");
      sb.AppendLine("</style>");
      sb.AppendLine("<script>");
      sb.AppendLine("  function copyToClipboard() {");
      sb.AppendLine("    var copyText = document.getElementById('mermaidScript');");
      sb.AppendLine("    copyText.select();");
      sb.AppendLine("    copyText.setSelectionRange(0, 99999);");
      sb.AppendLine("    document.execCommand('copy');");
      sb.AppendLine("  }");
      sb.AppendLine("</script>");
      sb.AppendLine("</head>");
      sb.AppendLine("<body>");
      if (errorMsg.Length > 0) {
        sb.AppendLine($"<h1>Error Building Mermaid Script: {errorMsg}</h1>");
      } else {
        sb.AppendLine("  <div class=\"mermaid-container\">\r\n");
        sb.AppendLine($"    <pre class=\"mermaid\">{mermaidScript}");
        sb.AppendLine("    </pre></div>");
        sb.AppendLine("  <div class=\"copy-container\">");
        sb.AppendLine("    <textarea id=\"mermaidScript\" readonly>");
        sb.AppendLine(mermaidScript);
        sb.AppendLine("    </textarea>");
        sb.AppendLine("    <button onclick=\"copyToClipboard()\">Copy Script</button>");
        sb.AppendLine("  </div>");
      }
      sb.AppendLine("</body>\r\n</html>");
      return sb.ToString();
    }
    #endregion



    
  }
}
