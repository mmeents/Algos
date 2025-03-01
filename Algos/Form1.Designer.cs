namespace Algos
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

    #region Windows Form Designer generated code

    /// <summary>
    ///  Required method for Designer support - do not modify
    ///  the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent() {
      components = new System.ComponentModel.Container();
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
      panel1 = new Panel();
      comboBox1 = new ComboBox();
      btnOpen = new Button();
      imageList1 = new ImageList(components);
      btnBrowse = new Button();
      lbFocusedItem = new Label();
      splitContainer1 = new SplitContainer();
      splitContainer2 = new SplitContainer();
      treeView1 = new TreeView();
      contextMenuStrip1 = new ContextMenuStrip(components);
      newDiagramToolStripMenuItem = new ToolStripMenuItem();
      newMindMapDialogToolStripMenuItem = new ToolStripMenuItem();
      newFlowchartDiagramMenuItem = new ToolStripMenuItem();
      addMindMapNodeMenuItem = new ToolStripMenuItem();
      addFlowchartNodeMenuItem = new ToolStripMenuItem();
      addFlowchartLinkMenuItem = new ToolStripMenuItem();
      toolStripSeparator1 = new ToolStripSeparator();
      MoveItemUpMenuItem = new ToolStripMenuItem();
      toolStripSeparator2 = new ToolStripSeparator();
      LocalCopyMenuItem = new ToolStripMenuItem();
      LocalPasteMenuItem = new ToolStripMenuItem();
      toolStripSeparator3 = new ToolStripSeparator();
      removeSelectedItemToolStripMenuItem = new ToolStripMenuItem();
      imageList2 = new ImageList(components);
      lbLine2 = new Label();
      edLine2 = new TextBox();
      lbEdit3 = new Label();
      cbEdit3 = new ComboBox();
      lbTech = new Label();
      lbEdit2 = new Label();
      cbEdit2 = new ComboBox();
      cbExpandedShape = new CheckBox();
      lbShape = new Label();
      cbShape = new ComboBox();
      btnCancel = new Button();
      btnSave = new Button();
      label1 = new Label();
      edName = new TextBox();
      wbOut = new Microsoft.Web.WebView2.WinForms.WebView2();
      edLogMsg = new TextBox();
      odMain = new OpenFileDialog();
      panel1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
      splitContainer1.Panel1.SuspendLayout();
      splitContainer1.Panel2.SuspendLayout();
      splitContainer1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)splitContainer2).BeginInit();
      splitContainer2.Panel1.SuspendLayout();
      splitContainer2.Panel2.SuspendLayout();
      splitContainer2.SuspendLayout();
      contextMenuStrip1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)wbOut).BeginInit();
      SuspendLayout();
      // 
      // panel1
      // 
      panel1.Controls.Add(comboBox1);
      panel1.Controls.Add(btnOpen);
      panel1.Controls.Add(btnBrowse);
      panel1.Controls.Add(lbFocusedItem);
      panel1.Dock = DockStyle.Top;
      panel1.Location = new Point(0, 0);
      panel1.Name = "panel1";
      panel1.Size = new Size(1095, 60);
      panel1.TabIndex = 0;
      // 
      // comboBox1
      // 
      comboBox1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      comboBox1.FormattingEnabled = true;
      comboBox1.Location = new Point(119, 6);
      comboBox1.Name = "comboBox1";
      comboBox1.Size = new Size(772, 28);
      comboBox1.TabIndex = 0;
      // 
      // btnOpen
      // 
      btnOpen.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      btnOpen.ImageAlign = ContentAlignment.MiddleLeft;
      btnOpen.ImageIndex = 0;
      btnOpen.ImageList = imageList1;
      btnOpen.Location = new Point(997, 6);
      btnOpen.Name = "btnOpen";
      btnOpen.Size = new Size(86, 29);
      btnOpen.TabIndex = 2;
      btnOpen.Text = "Open";
      btnOpen.UseVisualStyleBackColor = true;
      btnOpen.Click += btnOpen_Click;
      // 
      // imageList1
      // 
      imageList1.ColorDepth = ColorDepth.Depth32Bit;
      imageList1.ImageStream = (ImageListStreamer)resources.GetObject("imageList1.ImageStream");
      imageList1.TransparentColor = Color.Transparent;
      imageList1.Images.SetKeyName(0, "flame-green.ico");
      imageList1.Images.SetKeyName(1, "flame-_1_ red.ico");
      imageList1.Images.SetKeyName(2, "Fatcow-Farm-Fresh-Cog-add.32.png");
      imageList1.Images.SetKeyName(3, "delete-icon.png");
      imageList1.Images.SetKeyName(4, "file-save-as-icon.png");
      imageList1.Images.SetKeyName(5, "folder-search-icon.png");
      // 
      // btnBrowse
      // 
      btnBrowse.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      btnBrowse.ImageAlign = ContentAlignment.MiddleLeft;
      btnBrowse.ImageIndex = 5;
      btnBrowse.ImageList = imageList1;
      btnBrowse.Location = new Point(897, 6);
      btnBrowse.Name = "btnBrowse";
      btnBrowse.Size = new Size(94, 29);
      btnBrowse.TabIndex = 1;
      btnBrowse.Text = "Browse";
      btnBrowse.UseVisualStyleBackColor = true;
      btnBrowse.Click += btnBrowse_Click;
      // 
      // lbFocusedItem
      // 
      lbFocusedItem.AutoSize = true;
      lbFocusedItem.Location = new Point(12, 9);
      lbFocusedItem.Name = "lbFocusedItem";
      lbFocusedItem.Size = new Size(88, 20);
      lbFocusedItem.TabIndex = 3;
      lbFocusedItem.Text = "File to open";
      // 
      // splitContainer1
      // 
      splitContainer1.BorderStyle = BorderStyle.Fixed3D;
      splitContainer1.Dock = DockStyle.Fill;
      splitContainer1.Location = new Point(0, 60);
      splitContainer1.Name = "splitContainer1";
      // 
      // splitContainer1.Panel1
      // 
      splitContainer1.Panel1.Controls.Add(splitContainer2);
      // 
      // splitContainer1.Panel2
      // 
      splitContainer1.Panel2.Controls.Add(wbOut);
      splitContainer1.Panel2.Controls.Add(edLogMsg);
      splitContainer1.Size = new Size(1095, 826);
      splitContainer1.SplitterDistance = 364;
      splitContainer1.TabIndex = 1;
      // 
      // splitContainer2
      // 
      splitContainer2.BorderStyle = BorderStyle.Fixed3D;
      splitContainer2.Dock = DockStyle.Fill;
      splitContainer2.Location = new Point(0, 0);
      splitContainer2.Name = "splitContainer2";
      splitContainer2.Orientation = Orientation.Horizontal;
      // 
      // splitContainer2.Panel1
      // 
      splitContainer2.Panel1.Controls.Add(treeView1);
      // 
      // splitContainer2.Panel2
      // 
      splitContainer2.Panel2.Controls.Add(lbLine2);
      splitContainer2.Panel2.Controls.Add(lbEdit3);
      splitContainer2.Panel2.Controls.Add(cbEdit3);
      splitContainer2.Panel2.Controls.Add(lbTech);
      splitContainer2.Panel2.Controls.Add(lbEdit2);
      splitContainer2.Panel2.Controls.Add(cbEdit2);
      splitContainer2.Panel2.Controls.Add(cbExpandedShape);
      splitContainer2.Panel2.Controls.Add(lbShape);
      splitContainer2.Panel2.Controls.Add(cbShape);
      splitContainer2.Panel2.Controls.Add(btnCancel);
      splitContainer2.Panel2.Controls.Add(btnSave);
      splitContainer2.Panel2.Controls.Add(label1);
      splitContainer2.Panel2.Controls.Add(edName);
      splitContainer2.Panel2.Controls.Add(edLine2);
      splitContainer2.Size = new Size(364, 826);
      splitContainer2.SplitterDistance = 494;
      splitContainer2.TabIndex = 0;
      // 
      // treeView1
      // 
      treeView1.AllowDrop = true;
      treeView1.ContextMenuStrip = contextMenuStrip1;
      treeView1.Dock = DockStyle.Fill;
      treeView1.ImageIndex = 0;
      treeView1.ImageList = imageList2;
      treeView1.LabelEdit = true;
      treeView1.Location = new Point(0, 0);
      treeView1.Name = "treeView1";
      treeView1.SelectedImageIndex = 0;
      treeView1.Size = new Size(360, 490);
      treeView1.TabIndex = 0;
      treeView1.AfterLabelEdit += treeView1_AfterLabelEdit;
      treeView1.ItemDrag += treeView1_ItemDrag;
      treeView1.AfterSelect += treeView1_AfterSelect;
      treeView1.DragDrop += treeView1_DragDrop;
      treeView1.DragEnter += treeView1_DragEnter;
      treeView1.DragOver += treeView1_DragOver;
      // 
      // contextMenuStrip1
      // 
      contextMenuStrip1.ImageScalingSize = new Size(20, 20);
      contextMenuStrip1.Items.AddRange(new ToolStripItem[] { newDiagramToolStripMenuItem, addMindMapNodeMenuItem, addFlowchartNodeMenuItem, addFlowchartLinkMenuItem, toolStripSeparator1, MoveItemUpMenuItem, toolStripSeparator2, LocalCopyMenuItem, LocalPasteMenuItem, toolStripSeparator3, removeSelectedItemToolStripMenuItem });
      contextMenuStrip1.Name = "contextMenuStrip1";
      contextMenuStrip1.Size = new Size(228, 214);
      contextMenuStrip1.Opening += contextMenuStrip1_Opening;
      // 
      // newDiagramToolStripMenuItem
      // 
      newDiagramToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { newMindMapDialogToolStripMenuItem, newFlowchartDiagramMenuItem });
      newDiagramToolStripMenuItem.Name = "newDiagramToolStripMenuItem";
      newDiagramToolStripMenuItem.Size = new Size(227, 24);
      newDiagramToolStripMenuItem.Text = "New Diagram";
      // 
      // newMindMapDialogToolStripMenuItem
      // 
      newMindMapDialogToolStripMenuItem.Name = "newMindMapDialogToolStripMenuItem";
      newMindMapDialogToolStripMenuItem.Size = new Size(252, 26);
      newMindMapDialogToolStripMenuItem.Text = "New Mind Map Dialog";
      newMindMapDialogToolStripMenuItem.Click += newMindMapDialogToolStripMenuItem_Click;
      // 
      // newFlowchartDiagramMenuItem
      // 
      newFlowchartDiagramMenuItem.Name = "newFlowchartDiagramMenuItem";
      newFlowchartDiagramMenuItem.Size = new Size(252, 26);
      newFlowchartDiagramMenuItem.Text = "New Flowchart Diagram";
      newFlowchartDiagramMenuItem.Click += newFlowchartDiagramMenuItem_Click;
      // 
      // addMindMapNodeMenuItem
      // 
      addMindMapNodeMenuItem.Name = "addMindMapNodeMenuItem";
      addMindMapNodeMenuItem.Size = new Size(227, 24);
      addMindMapNodeMenuItem.Text = "Add Mindmap Node";
      addMindMapNodeMenuItem.Click += addMindmapNodeMenuItem_Click;
      // 
      // addFlowchartNodeMenuItem
      // 
      addFlowchartNodeMenuItem.Name = "addFlowchartNodeMenuItem";
      addFlowchartNodeMenuItem.Size = new Size(227, 24);
      addFlowchartNodeMenuItem.Text = "Add Flowchart Node";
      addFlowchartNodeMenuItem.Click += addFlowchartNodeMenuItem_Click;
      // 
      // addFlowchartLinkMenuItem
      // 
      addFlowchartLinkMenuItem.Name = "addFlowchartLinkMenuItem";
      addFlowchartLinkMenuItem.Size = new Size(227, 24);
      addFlowchartLinkMenuItem.Text = "Add Flowchart Link";
      addFlowchartLinkMenuItem.Click += addFlowchartLinkMenuItem_Click;
      // 
      // toolStripSeparator1
      // 
      toolStripSeparator1.Name = "toolStripSeparator1";
      toolStripSeparator1.Size = new Size(224, 6);
      // 
      // MoveItemUpMenuItem
      // 
      MoveItemUpMenuItem.Name = "MoveItemUpMenuItem";
      MoveItemUpMenuItem.Size = new Size(227, 24);
      MoveItemUpMenuItem.Text = "Move Item Up";
      MoveItemUpMenuItem.Click += MoveItemUpMenuItem_Click;
      // 
      // toolStripSeparator2
      // 
      toolStripSeparator2.Name = "toolStripSeparator2";
      toolStripSeparator2.Size = new Size(224, 6);
      // 
      // LocalCopyMenuItem
      // 
      LocalCopyMenuItem.Name = "LocalCopyMenuItem";
      LocalCopyMenuItem.Size = new Size(227, 24);
      LocalCopyMenuItem.Text = "Local Copy Item";
      LocalCopyMenuItem.Click += LocalCopyMenuItem_Click;
      // 
      // LocalPasteMenuItem
      // 
      LocalPasteMenuItem.Name = "LocalPasteMenuItem";
      LocalPasteMenuItem.Size = new Size(227, 24);
      LocalPasteMenuItem.Text = "Local Paste Copied ";
      LocalPasteMenuItem.Click += LocalPasteMenuItem_Click;
      // 
      // toolStripSeparator3
      // 
      toolStripSeparator3.Name = "toolStripSeparator3";
      toolStripSeparator3.Size = new Size(224, 6);
      // 
      // removeSelectedItemToolStripMenuItem
      // 
      removeSelectedItemToolStripMenuItem.Name = "removeSelectedItemToolStripMenuItem";
      removeSelectedItemToolStripMenuItem.Size = new Size(227, 24);
      removeSelectedItemToolStripMenuItem.Text = "Remove Selected Item";
      removeSelectedItemToolStripMenuItem.Click += removeSelectedItemToolStripMenuItem_Click;
      // 
      // imageList2
      // 
      imageList2.ColorDepth = ColorDepth.Depth32Bit;
      imageList2.ImageStream = (ImageListStreamer)resources.GetObject("imageList2.ImageStream");
      imageList2.TransparentColor = Color.Transparent;
      imageList2.Images.SetKeyName(0, "flame-_1_.ico");
      imageList2.Images.SetKeyName(1, "Fatcow-Farm-Fresh-Blueprint.32.png");
      imageList2.Images.SetKeyName(2, "Fatcow-Farm-Fresh-Borders-accent.32.png");
      imageList2.Images.SetKeyName(3, "separator-label-icon.png");
      // 
      // lbLine2
      // 
      lbLine2.AutoSize = true;
      lbLine2.Location = new Point(24, 70);
      lbLine2.Name = "lbLine2";
      lbLine2.Size = new Size(41, 20);
      lbLine2.TabIndex = 13;
      lbLine2.Text = "Title:";
      // 
      // edLine2
      // 
      edLine2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      edLine2.Location = new Point(83, 67);
      edLine2.Name = "edLine2";
      edLine2.Size = new Size(270, 27);
      edLine2.TabIndex = 12;
      edLine2.TextChanged += edLine2_TextChanged;
      // 
      // lbEdit3
      // 
      lbEdit3.AutoSize = true;
      lbEdit3.Location = new Point(12, 171);
      lbEdit3.Name = "lbEdit3";
      lbEdit3.Size = new Size(50, 20);
      lbEdit3.TabIndex = 11;
      lbEdit3.Text = "label2";
      // 
      // cbEdit3
      // 
      cbEdit3.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      cbEdit3.FormattingEnabled = true;
      cbEdit3.Location = new Point(84, 167);
      cbEdit3.Name = "cbEdit3";
      cbEdit3.Size = new Size(270, 28);
      cbEdit3.TabIndex = 10;
      cbEdit3.SelectedIndexChanged += cbEdit3_SelectedIndexChanged;
      // 
      // lbTech
      // 
      lbTech.AutoSize = true;
      lbTech.Location = new Point(10, 7);
      lbTech.Name = "lbTech";
      lbTech.Size = new Size(93, 20);
      lbTech.TabIndex = 9;
      lbTech.Text = "Editing Id 35";
      // 
      // lbEdit2
      // 
      lbEdit2.AutoSize = true;
      lbEdit2.Location = new Point(9, 135);
      lbEdit2.Name = "lbEdit2";
      lbEdit2.Size = new Size(56, 20);
      lbEdit2.TabIndex = 8;
      lbEdit2.Text = "lbEdit2";
      // 
      // cbEdit2
      // 
      cbEdit2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      cbEdit2.FormattingEnabled = true;
      cbEdit2.Location = new Point(83, 133);
      cbEdit2.Name = "cbEdit2";
      cbEdit2.Size = new Size(270, 28);
      cbEdit2.TabIndex = 7;
      cbEdit2.SelectedIndexChanged += cbEdit2_SelectedIndexChanged;
      // 
      // cbExpandedShape
      // 
      cbExpandedShape.AutoSize = true;
      cbExpandedShape.Location = new Point(84, 69);
      cbExpandedShape.Name = "cbExpandedShape";
      cbExpandedShape.Size = new Size(176, 24);
      cbExpandedShape.TabIndex = 6;
      cbExpandedShape.Text = "Use Expanded Shapes";
      cbExpandedShape.UseVisualStyleBackColor = true;
      cbExpandedShape.CheckedChanged += cbExpandedShape_CheckedChanged;
      // 
      // lbShape
      // 
      lbShape.AutoSize = true;
      lbShape.Location = new Point(10, 103);
      lbShape.Name = "lbShape";
      lbShape.Size = new Size(55, 20);
      lbShape.TabIndex = 5;
      lbShape.Text = "Link To";
      // 
      // cbShape
      // 
      cbShape.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      cbShape.FormattingEnabled = true;
      cbShape.Location = new Point(83, 99);
      cbShape.Name = "cbShape";
      cbShape.Size = new Size(270, 28);
      cbShape.TabIndex = 4;
      cbShape.SelectedIndexChanged += cbShape_SelectedIndexChanged;
      // 
      // btnCancel
      // 
      btnCancel.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      btnCancel.ImageAlign = ContentAlignment.MiddleLeft;
      btnCancel.ImageIndex = 3;
      btnCancel.ImageList = imageList1;
      btnCancel.Location = new Point(267, 5);
      btnCancel.Name = "btnCancel";
      btnCancel.Size = new Size(87, 28);
      btnCancel.TabIndex = 3;
      btnCancel.Text = "Cancel";
      btnCancel.UseVisualStyleBackColor = true;
      btnCancel.Click += btnCancel_Click;
      // 
      // btnSave
      // 
      btnSave.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      btnSave.ImageAlign = ContentAlignment.MiddleLeft;
      btnSave.ImageIndex = 4;
      btnSave.ImageList = imageList1;
      btnSave.Location = new Point(184, 5);
      btnSave.Name = "btnSave";
      btnSave.Size = new Size(84, 28);
      btnSave.TabIndex = 2;
      btnSave.Text = "Save";
      btnSave.TextAlign = ContentAlignment.TopCenter;
      btnSave.UseVisualStyleBackColor = true;
      btnSave.Click += btnSave_Click;
      // 
      // label1
      // 
      label1.AutoSize = true;
      label1.Location = new Point(13, 40);
      label1.Name = "label1";
      label1.Size = new Size(52, 20);
      label1.TabIndex = 1;
      label1.Text = "Name:";
      // 
      // edName
      // 
      edName.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      edName.Location = new Point(83, 36);
      edName.Name = "edName";
      edName.Size = new Size(270, 27);
      edName.TabIndex = 0;
      edName.TextChanged += edName_TextChanged;
      // 
      // wbOut
      // 
      wbOut.AllowExternalDrop = true;
      wbOut.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      wbOut.CreationProperties = null;
      wbOut.DefaultBackgroundColor = Color.White;
      wbOut.Location = new Point(24, 17);
      wbOut.Name = "wbOut";
      wbOut.Size = new Size(689, 641);
      wbOut.TabIndex = 1;
      wbOut.ZoomFactor = 1D;
      // 
      // edLogMsg
      // 
      edLogMsg.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      edLogMsg.Location = new Point(24, 690);
      edLogMsg.Multiline = true;
      edLogMsg.Name = "edLogMsg";
      edLogMsg.Size = new Size(689, 122);
      edLogMsg.TabIndex = 0;
      // 
      // odMain
      // 
      odMain.CheckFileExists = false;
      odMain.DefaultExt = "algos";
      odMain.Filter = "ALGOS File|*.algos";
      odMain.SelectReadOnly = false;
      odMain.Title = "Identify an ALGOS File, or name a new one.";
      // 
      // Form1
      // 
      AutoScaleDimensions = new SizeF(8F, 20F);
      AutoScaleMode = AutoScaleMode.Font;
      ClientSize = new Size(1095, 886);
      Controls.Add(splitContainer1);
      Controls.Add(panel1);
      Icon = (Icon)resources.GetObject("$this.Icon");
      Name = "Form1";
      Text = "ALGOS";
      FormClosing += Form1_FormClosing;
      Shown += Form1_Shown;
      Resize += Form1_Resize;
      panel1.ResumeLayout(false);
      panel1.PerformLayout();
      splitContainer1.Panel1.ResumeLayout(false);
      splitContainer1.Panel2.ResumeLayout(false);
      splitContainer1.Panel2.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
      splitContainer1.ResumeLayout(false);
      splitContainer2.Panel1.ResumeLayout(false);
      splitContainer2.Panel2.ResumeLayout(false);
      splitContainer2.Panel2.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)splitContainer2).EndInit();
      splitContainer2.ResumeLayout(false);
      contextMenuStrip1.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)wbOut).EndInit();
      ResumeLayout(false);
    }

    #endregion

    private Panel panel1;
    private SplitContainer splitContainer1;
    private SplitContainer splitContainer2;
    private TreeView treeView1;
    private Label lbFocusedItem;
    private Button btnOpen;
    private Button btnBrowse;
    private ImageList imageList1;
    private OpenFileDialog odMain;
    private TextBox edLogMsg;
    private ComboBox comboBox1;
    private ContextMenuStrip contextMenuStrip1;
    private ToolStripMenuItem newDiagramToolStripMenuItem;
    private ToolStripMenuItem newMindMapDialogToolStripMenuItem;
    private ImageList imageList2;
    private Label label1;
    private TextBox edName;
    private Button btnCancel;
    private Button btnSave;
    private Microsoft.Web.WebView2.WinForms.WebView2 wbOut;
    private Label lbShape;
    private ComboBox cbShape;
    private CheckBox cbExpandedShape;
    private ComboBox cbEdit2;
    private Label lbEdit2;
    private ToolStripMenuItem newFlowchartDiagramMenuItem;
    private ToolStripMenuItem addMindMapNodeMenuItem;
    private ToolStripMenuItem addFlowchartNodeMenuItem;
    private ToolStripMenuItem addFlowchartLinkMenuItem;
    private ToolStripMenuItem removeSelectedItemToolStripMenuItem;
    private ToolStripSeparator toolStripSeparator1;
    private ToolStripMenuItem MoveItemUpMenuItem;
    private ToolStripSeparator toolStripSeparator2;
    private ToolStripMenuItem LocalCopyMenuItem;
    private ToolStripMenuItem LocalPasteMenuItem;
    private ToolStripSeparator toolStripSeparator3;
    private Label lbTech;
    private ComboBox cbEdit3;
    private Label lbEdit3;
    private TextBox edLine2;
    private Label lbLine2;
  }
}
