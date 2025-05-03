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
      label1 = new Label();
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
      newClassDiagramMenuItem = new ToolStripMenuItem();
      addMindMapNodeMenuItem = new ToolStripMenuItem();
      addFlowchartNodeMenuItem = new ToolStripMenuItem();
      addFlowchartSubGraphToolStripMenuItem = new ToolStripMenuItem();
      addFlowchartLinkMenuItem = new ToolStripMenuItem();
      addNameSpaceToolStripMenuItem = new ToolStripMenuItem();
      addClassToolStripMenuItem = new ToolStripMenuItem();
      addClassPropertyToolStripMenuItem = new ToolStripMenuItem();
      addClassMethToolStripMenuItem = new ToolStripMenuItem();
      addMethodParamToolStripMenuItem = new ToolStripMenuItem();
      addClassRelationshipMenuItem = new ToolStripMenuItem();
      toolStripSeparator1 = new ToolStripSeparator();
      MoveItemUpMenuItem = new ToolStripMenuItem();
      toolStripSeparator2 = new ToolStripSeparator();
      LocalCopyMenuItem = new ToolStripMenuItem();
      LocalPasteMenuItem = new ToolStripMenuItem();
      toolStripSeparator3 = new ToolStripSeparator();
      removeSelectedItemToolStripMenuItem = new ToolStripMenuItem();
      imageList2 = new ImageList(components);
      lbLine2 = new Label();
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
      lbName = new Label();
      edName = new TextBox();
      edLine2 = new TextBox();
      cbShowMermaidScript = new CheckBox();
      btnRefresh = new Button();
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
      panel1.Controls.Add(label1);
      panel1.Controls.Add(comboBox1);
      panel1.Controls.Add(btnOpen);
      panel1.Controls.Add(btnBrowse);
      panel1.Controls.Add(lbFocusedItem);
      panel1.Dock = DockStyle.Top;
      panel1.Location = new Point(0, 0);
      panel1.Margin = new Padding(3, 2, 3, 2);
      panel1.Name = "panel1";
      panel1.Size = new Size(958, 51);
      panel1.TabIndex = 0;
      // 
      // label1
      // 
      label1.AutoSize = true;
      label1.Location = new Point(23, 8);
      label1.Name = "label1";
      label1.Size = new Size(69, 15);
      label1.TabIndex = 4;
      label1.Text = "File to open";
      // 
      // comboBox1
      // 
      comboBox1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      comboBox1.FormattingEnabled = true;
      comboBox1.Location = new Point(104, 4);
      comboBox1.Margin = new Padding(3, 2, 3, 2);
      comboBox1.Name = "comboBox1";
      comboBox1.Size = new Size(676, 23);
      comboBox1.TabIndex = 0;
      // 
      // btnOpen
      // 
      btnOpen.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      btnOpen.ImageAlign = ContentAlignment.MiddleLeft;
      btnOpen.ImageIndex = 0;
      btnOpen.ImageList = imageList1;
      btnOpen.Location = new Point(872, 4);
      btnOpen.Margin = new Padding(3, 2, 3, 2);
      btnOpen.Name = "btnOpen";
      btnOpen.Size = new Size(75, 22);
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
      btnBrowse.Location = new Point(785, 4);
      btnBrowse.Margin = new Padding(3, 2, 3, 2);
      btnBrowse.Name = "btnBrowse";
      btnBrowse.Size = new Size(82, 22);
      btnBrowse.TabIndex = 1;
      btnBrowse.Text = "Browse";
      btnBrowse.UseVisualStyleBackColor = true;
      btnBrowse.Click += btnBrowse_Click;
      // 
      // lbFocusedItem
      // 
      lbFocusedItem.AutoSize = true;
      lbFocusedItem.Location = new Point(108, 29);
      lbFocusedItem.Name = "lbFocusedItem";
      lbFocusedItem.Size = new Size(0, 15);
      lbFocusedItem.TabIndex = 3;
      // 
      // splitContainer1
      // 
      splitContainer1.BorderStyle = BorderStyle.Fixed3D;
      splitContainer1.Dock = DockStyle.Fill;
      splitContainer1.Location = new Point(0, 51);
      splitContainer1.Margin = new Padding(3, 2, 3, 2);
      splitContainer1.Name = "splitContainer1";
      // 
      // splitContainer1.Panel1
      // 
      splitContainer1.Panel1.Controls.Add(splitContainer2);
      // 
      // splitContainer1.Panel2
      // 
      splitContainer1.Panel2.Controls.Add(cbShowMermaidScript);
      splitContainer1.Panel2.Controls.Add(btnRefresh);
      splitContainer1.Panel2.Controls.Add(wbOut);
      splitContainer1.Panel2.Controls.Add(edLogMsg);
      splitContainer1.Size = new Size(958, 613);
      splitContainer1.SplitterDistance = 318;
      splitContainer1.TabIndex = 1;
      // 
      // splitContainer2
      // 
      splitContainer2.BorderStyle = BorderStyle.Fixed3D;
      splitContainer2.Dock = DockStyle.Fill;
      splitContainer2.Location = new Point(0, 0);
      splitContainer2.Margin = new Padding(3, 2, 3, 2);
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
      splitContainer2.Panel2.Controls.Add(lbName);
      splitContainer2.Panel2.Controls.Add(edName);
      splitContainer2.Panel2.Controls.Add(edLine2);
      splitContainer2.Size = new Size(318, 613);
      splitContainer2.SplitterDistance = 314;
      splitContainer2.SplitterWidth = 3;
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
      treeView1.Margin = new Padding(3, 2, 3, 2);
      treeView1.Name = "treeView1";
      treeView1.SelectedImageIndex = 0;
      treeView1.Size = new Size(314, 310);
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
      contextMenuStrip1.Items.AddRange(new ToolStripItem[] { newDiagramToolStripMenuItem, addMindMapNodeMenuItem, addFlowchartNodeMenuItem, addFlowchartSubGraphToolStripMenuItem, addFlowchartLinkMenuItem, addNameSpaceToolStripMenuItem, addClassToolStripMenuItem, addClassPropertyToolStripMenuItem, addClassMethToolStripMenuItem, addMethodParamToolStripMenuItem, addClassRelationshipMenuItem, toolStripSeparator1, MoveItemUpMenuItem, toolStripSeparator2, LocalCopyMenuItem, LocalPasteMenuItem, toolStripSeparator3, removeSelectedItemToolStripMenuItem });
      contextMenuStrip1.Name = "contextMenuStrip1";
      contextMenuStrip1.Size = new Size(207, 374);
      contextMenuStrip1.Opening += contextMenuStrip1_Opening;
      // 
      // newDiagramToolStripMenuItem
      // 
      newDiagramToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { newMindMapDialogToolStripMenuItem, newFlowchartDiagramMenuItem, newClassDiagramMenuItem });
      newDiagramToolStripMenuItem.Name = "newDiagramToolStripMenuItem";
      newDiagramToolStripMenuItem.Size = new Size(206, 22);
      newDiagramToolStripMenuItem.Text = "New Diagram";
      // 
      // newMindMapDialogToolStripMenuItem
      // 
      newMindMapDialogToolStripMenuItem.Name = "newMindMapDialogToolStripMenuItem";
      newMindMapDialogToolStripMenuItem.Size = new Size(201, 22);
      newMindMapDialogToolStripMenuItem.Text = "New Mind Map Dialog";
      newMindMapDialogToolStripMenuItem.Click += newMindMapDialogToolStripMenuItem_Click;
      // 
      // newFlowchartDiagramMenuItem
      // 
      newFlowchartDiagramMenuItem.Name = "newFlowchartDiagramMenuItem";
      newFlowchartDiagramMenuItem.Size = new Size(201, 22);
      newFlowchartDiagramMenuItem.Text = "New Flowchart Diagram";
      newFlowchartDiagramMenuItem.Click += newFlowchartDiagramMenuItem_Click;
      // 
      // newClassDiagramMenuItem
      // 
      newClassDiagramMenuItem.Name = "newClassDiagramMenuItem";
      newClassDiagramMenuItem.Size = new Size(201, 22);
      newClassDiagramMenuItem.Text = "New Class Diagram";
      newClassDiagramMenuItem.Click += newClassDiagramMenuItem_Click;
      // 
      // addMindMapNodeMenuItem
      // 
      addMindMapNodeMenuItem.Name = "addMindMapNodeMenuItem";
      addMindMapNodeMenuItem.Size = new Size(206, 22);
      addMindMapNodeMenuItem.Text = "Add Mindmap Node";
      addMindMapNodeMenuItem.Click += addMindmapNodeMenuItem_Click;
      // 
      // addFlowchartNodeMenuItem
      // 
      addFlowchartNodeMenuItem.Name = "addFlowchartNodeMenuItem";
      addFlowchartNodeMenuItem.Size = new Size(206, 22);
      addFlowchartNodeMenuItem.Text = "Add Flowchart Node";
      addFlowchartNodeMenuItem.Click += addFlowchartNodeMenuItem_Click;
      // 
      // addFlowchartSubGraphToolStripMenuItem
      // 
      addFlowchartSubGraphToolStripMenuItem.Name = "addFlowchartSubGraphToolStripMenuItem";
      addFlowchartSubGraphToolStripMenuItem.Size = new Size(206, 22);
      addFlowchartSubGraphToolStripMenuItem.Text = "Add Flowchart SubGraph";
      addFlowchartSubGraphToolStripMenuItem.Click += addFlowchartSubGraphToolStripMenuItem_Click;
      // 
      // addFlowchartLinkMenuItem
      // 
      addFlowchartLinkMenuItem.Name = "addFlowchartLinkMenuItem";
      addFlowchartLinkMenuItem.Size = new Size(206, 22);
      addFlowchartLinkMenuItem.Text = "Add Flowchart Link";
      addFlowchartLinkMenuItem.Click += addFlowchartLinkMenuItem_Click;
      // 
      // addNameSpaceToolStripMenuItem
      // 
      addNameSpaceToolStripMenuItem.Name = "addNameSpaceToolStripMenuItem";
      addNameSpaceToolStripMenuItem.Size = new Size(206, 22);
      addNameSpaceToolStripMenuItem.Text = "Add Name Space";
      addNameSpaceToolStripMenuItem.Click += addNameSpaceToolStripMenuItem_Click;
      // 
      // addClassToolStripMenuItem
      // 
      addClassToolStripMenuItem.Name = "addClassToolStripMenuItem";
      addClassToolStripMenuItem.Size = new Size(206, 22);
      addClassToolStripMenuItem.Text = "Add Class";
      addClassToolStripMenuItem.Click += addClassToolStripMenuItem_Click;
      // 
      // addClassPropertyToolStripMenuItem
      // 
      addClassPropertyToolStripMenuItem.Name = "addClassPropertyToolStripMenuItem";
      addClassPropertyToolStripMenuItem.Size = new Size(206, 22);
      addClassPropertyToolStripMenuItem.Text = "Add Class Property";
      addClassPropertyToolStripMenuItem.Click += addClassPropertyToolStripMenuItem_Click;
      // 
      // addClassMethToolStripMenuItem
      // 
      addClassMethToolStripMenuItem.Name = "addClassMethToolStripMenuItem";
      addClassMethToolStripMenuItem.Size = new Size(206, 22);
      addClassMethToolStripMenuItem.Text = "Add Class Method";
      addClassMethToolStripMenuItem.Click += addClassMethToolStripMenuItem_Click;
      // 
      // addMethodParamToolStripMenuItem
      // 
      addMethodParamToolStripMenuItem.Name = "addMethodParamToolStripMenuItem";
      addMethodParamToolStripMenuItem.Size = new Size(206, 22);
      addMethodParamToolStripMenuItem.Text = "Add Method Param";
      addMethodParamToolStripMenuItem.Click += addMethodParamToolStripMenuItem_Click;
      // 
      // addClassRelationshipMenuItem
      // 
      addClassRelationshipMenuItem.Name = "addClassRelationshipMenuItem";
      addClassRelationshipMenuItem.Size = new Size(206, 22);
      addClassRelationshipMenuItem.Text = "Add Class Relationship";
      addClassRelationshipMenuItem.Click += addClassRelationshipMenuItem_Click;
      // 
      // toolStripSeparator1
      // 
      toolStripSeparator1.Name = "toolStripSeparator1";
      toolStripSeparator1.Size = new Size(203, 6);
      // 
      // MoveItemUpMenuItem
      // 
      MoveItemUpMenuItem.Name = "MoveItemUpMenuItem";
      MoveItemUpMenuItem.Size = new Size(206, 22);
      MoveItemUpMenuItem.Text = "Move Item Up";
      MoveItemUpMenuItem.Click += MoveItemUpMenuItem_Click;
      // 
      // toolStripSeparator2
      // 
      toolStripSeparator2.Name = "toolStripSeparator2";
      toolStripSeparator2.Size = new Size(203, 6);
      // 
      // LocalCopyMenuItem
      // 
      LocalCopyMenuItem.Name = "LocalCopyMenuItem";
      LocalCopyMenuItem.Size = new Size(206, 22);
      LocalCopyMenuItem.Text = "Local Copy Item";
      LocalCopyMenuItem.Click += LocalCopyMenuItem_Click;
      // 
      // LocalPasteMenuItem
      // 
      LocalPasteMenuItem.Name = "LocalPasteMenuItem";
      LocalPasteMenuItem.Size = new Size(206, 22);
      LocalPasteMenuItem.Text = "Local Paste Copied ";
      LocalPasteMenuItem.Click += LocalPasteMenuItem_Click;
      // 
      // toolStripSeparator3
      // 
      toolStripSeparator3.Name = "toolStripSeparator3";
      toolStripSeparator3.Size = new Size(203, 6);
      // 
      // removeSelectedItemToolStripMenuItem
      // 
      removeSelectedItemToolStripMenuItem.Name = "removeSelectedItemToolStripMenuItem";
      removeSelectedItemToolStripMenuItem.Size = new Size(206, 22);
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
      lbLine2.Location = new Point(21, 52);
      lbLine2.Name = "lbLine2";
      lbLine2.Size = new Size(32, 15);
      lbLine2.TabIndex = 13;
      lbLine2.Text = "Title:";
      // 
      // lbEdit3
      // 
      lbEdit3.AutoSize = true;
      lbEdit3.Location = new Point(10, 128);
      lbEdit3.Name = "lbEdit3";
      lbEdit3.Size = new Size(38, 15);
      lbEdit3.TabIndex = 11;
      lbEdit3.Text = "label2";
      // 
      // cbEdit3
      // 
      cbEdit3.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      cbEdit3.FormattingEnabled = true;
      cbEdit3.Location = new Point(74, 125);
      cbEdit3.Margin = new Padding(3, 2, 3, 2);
      cbEdit3.Name = "cbEdit3";
      cbEdit3.Size = new Size(236, 23);
      cbEdit3.TabIndex = 10;
      cbEdit3.SelectedIndexChanged += cbEdit3_SelectedIndexChanged;
      // 
      // lbTech
      // 
      lbTech.AutoSize = true;
      lbTech.Location = new Point(9, 5);
      lbTech.Name = "lbTech";
      lbTech.Size = new Size(72, 15);
      lbTech.TabIndex = 9;
      lbTech.Text = "Editing Id 35";
      // 
      // lbEdit2
      // 
      lbEdit2.AutoSize = true;
      lbEdit2.Location = new Point(8, 101);
      lbEdit2.Name = "lbEdit2";
      lbEdit2.Size = new Size(43, 15);
      lbEdit2.TabIndex = 8;
      lbEdit2.Text = "lbEdit2";
      // 
      // cbEdit2
      // 
      cbEdit2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      cbEdit2.FormattingEnabled = true;
      cbEdit2.Location = new Point(73, 100);
      cbEdit2.Margin = new Padding(3, 2, 3, 2);
      cbEdit2.Name = "cbEdit2";
      cbEdit2.Size = new Size(236, 23);
      cbEdit2.TabIndex = 7;
      cbEdit2.SelectedIndexChanged += cbEdit2_SelectedIndexChanged;
      // 
      // cbExpandedShape
      // 
      cbExpandedShape.AutoSize = true;
      cbExpandedShape.Location = new Point(74, 52);
      cbExpandedShape.Margin = new Padding(3, 2, 3, 2);
      cbExpandedShape.Name = "cbExpandedShape";
      cbExpandedShape.Size = new Size(140, 19);
      cbExpandedShape.TabIndex = 6;
      cbExpandedShape.Text = "Use Expanded Shapes";
      cbExpandedShape.UseVisualStyleBackColor = true;
      cbExpandedShape.CheckedChanged += cbExpandedShape_CheckedChanged;
      // 
      // lbShape
      // 
      lbShape.AutoSize = true;
      lbShape.Location = new Point(9, 77);
      lbShape.Name = "lbShape";
      lbShape.Size = new Size(44, 15);
      lbShape.TabIndex = 5;
      lbShape.Text = "Link To";
      // 
      // cbShape
      // 
      cbShape.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      cbShape.FormattingEnabled = true;
      cbShape.Location = new Point(73, 74);
      cbShape.Margin = new Padding(3, 2, 3, 2);
      cbShape.Name = "cbShape";
      cbShape.Size = new Size(236, 23);
      cbShape.TabIndex = 4;
      cbShape.SelectedIndexChanged += cbShape_SelectedIndexChanged;
      // 
      // btnCancel
      // 
      btnCancel.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      btnCancel.ImageIndex = 3;
      btnCancel.ImageList = imageList1;
      btnCancel.Location = new Point(280, 4);
      btnCancel.Margin = new Padding(3, 2, 3, 2);
      btnCancel.Name = "btnCancel";
      btnCancel.Size = new Size(29, 21);
      btnCancel.TabIndex = 3;
      btnCancel.UseVisualStyleBackColor = true;
      btnCancel.Click += btnCancel_Click;
      // 
      // btnSave
      // 
      btnSave.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      btnSave.ImageIndex = 4;
      btnSave.ImageList = imageList1;
      btnSave.Location = new Point(253, 4);
      btnSave.Margin = new Padding(3, 2, 3, 2);
      btnSave.Name = "btnSave";
      btnSave.Size = new Size(26, 21);
      btnSave.TabIndex = 2;
      btnSave.TextAlign = ContentAlignment.TopCenter;
      btnSave.UseVisualStyleBackColor = true;
      btnSave.Click += btnSave_Click;
      // 
      // lbName
      // 
      lbName.AutoSize = true;
      lbName.Location = new Point(11, 30);
      lbName.Name = "lbName";
      lbName.Size = new Size(42, 15);
      lbName.TabIndex = 1;
      lbName.Text = "Name:";
      // 
      // edName
      // 
      edName.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      edName.Location = new Point(73, 27);
      edName.Margin = new Padding(3, 2, 3, 2);
      edName.Name = "edName";
      edName.Size = new Size(236, 23);
      edName.TabIndex = 0;
      edName.TextChanged += edName_TextChanged;
      // 
      // edLine2
      // 
      edLine2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      edLine2.Location = new Point(73, 50);
      edLine2.Margin = new Padding(3, 2, 3, 2);
      edLine2.Name = "edLine2";
      edLine2.Size = new Size(236, 23);
      edLine2.TabIndex = 12;
      edLine2.TextChanged += edLine2_TextChanged;
      // 
      // cbShowMermaidScript
      // 
      cbShowMermaidScript.Appearance = Appearance.Button;
      cbShowMermaidScript.AutoSize = true;
      cbShowMermaidScript.Location = new Point(30, 3);
      cbShowMermaidScript.Margin = new Padding(3, 2, 3, 2);
      cbShowMermaidScript.Name = "cbShowMermaidScript";
      cbShowMermaidScript.Size = new Size(65, 25);
      cbShowMermaidScript.TabIndex = 17;
      cbShowMermaidScript.Text = "Mermaid";
      cbShowMermaidScript.UseVisualStyleBackColor = true;
      cbShowMermaidScript.CheckedChanged += cbShowMermaidScript_CheckedChanged;
      // 
      // btnRefresh
      // 
      btnRefresh.ImageAlign = ContentAlignment.MiddleLeft;
      btnRefresh.ImageIndex = 0;
      btnRefresh.ImageList = imageList1;
      btnRefresh.Location = new Point(4, 3);
      btnRefresh.Margin = new Padding(3, 2, 3, 2);
      btnRefresh.Name = "btnRefresh";
      btnRefresh.Size = new Size(25, 22);
      btnRefresh.TabIndex = 16;
      btnRefresh.UseVisualStyleBackColor = true;
      btnRefresh.Click += btnRefresh_Click;
      // 
      // wbOut
      // 
      wbOut.AllowExternalDrop = true;
      wbOut.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      wbOut.CreationProperties = null;
      wbOut.DefaultBackgroundColor = Color.White;
      wbOut.Location = new Point(3, 32);
      wbOut.Margin = new Padding(3, 2, 3, 2);
      wbOut.Name = "wbOut";
      wbOut.Size = new Size(625, 419);
      wbOut.TabIndex = 1;
      wbOut.ZoomFactor = 1D;
      // 
      // edLogMsg
      // 
      edLogMsg.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      edLogMsg.Location = new Point(4, 474);
      edLogMsg.Margin = new Padding(3, 2, 3, 2);
      edLogMsg.Multiline = true;
      edLogMsg.Name = "edLogMsg";
      edLogMsg.ScrollBars = ScrollBars.Vertical;
      edLogMsg.Size = new Size(622, 126);
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
      AutoScaleDimensions = new SizeF(7F, 15F);
      AutoScaleMode = AutoScaleMode.Font;
      ClientSize = new Size(958, 664);
      Controls.Add(splitContainer1);
      Controls.Add(panel1);
      Icon = (Icon)resources.GetObject("$this.Icon");
      Margin = new Padding(3, 2, 3, 2);
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
    private Label lbName;
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
    private ToolStripMenuItem addFlowchartSubGraphToolStripMenuItem;
    private ToolStripMenuItem newClassDiagramMenuItem;
    private ToolStripMenuItem addNameSpaceToolStripMenuItem;
    private ToolStripMenuItem addClassToolStripMenuItem;
    private ToolStripMenuItem addClassPropertyToolStripMenuItem;
    private ToolStripMenuItem addClassMethToolStripMenuItem;
    private ToolStripMenuItem addMethodParamToolStripMenuItem;
    private ToolStripMenuItem addClassRelationshipMenuItem;
    private Button btnRefresh;
    private CheckBox cbShowMermaidScript;
    private Label label1;
  }
}
