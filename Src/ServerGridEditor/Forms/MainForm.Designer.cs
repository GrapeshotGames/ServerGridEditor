﻿namespace ServerGridEditor
{
	 partial class MainForm
	 {
		  /// <summary>
		  /// Required designer variable.
		  /// </summary>
		  private System.ComponentModel.IContainer components = null;

		  /// <summary>
		  /// Clean up any resources being used.
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
		  /// Required method for Designer support - do not modify
		  /// the contents of this method with the code editor.
		  /// </summary>
		  private void InitializeComponent()
		  {
				System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
				this.mapPanel = new System.Windows.Forms.Panel();
				this.createProjBtn = new System.Windows.Forms.Button();
				this.loadProjBtn = new System.Windows.Forms.Button();
				this.mapHScrollBar = new System.Windows.Forms.HScrollBar();
				this.mapVScrollBar = new System.Windows.Forms.VScrollBar();
				this.menuStrip1 = new System.Windows.Forms.MenuStrip();
				this.projectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
				this.createToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
				this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
				this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
				this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
				this.editToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
				this.editSpawnerTemplatesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
				this.editAllDiscoveryZonesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
				this.editSpawnPointsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
				this.editServerTemplatesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
				this.editLocksToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
				this.cullInvalidPathsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
				this.exportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
				this.exportAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
				this.mapImageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
				this.cellImagesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
				this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
				this.slippyMapToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
				this.testsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
				this.testAllServersWithDataClearToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
				this.testAllServersWithoutDataClearToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
				this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
				this.controlsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
				this.scaleLbl = new System.Windows.Forms.Label();
				this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
				this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
				this.showServerInfoCheckbox = new System.Windows.Forms.CheckBox();
				this.showDiscoZoneInfoCheckbox = new System.Windows.Forms.CheckBox();
				this.setRatioBtn = new System.Windows.Forms.Button();
				this.customRatioTxtBox = new System.Windows.Forms.TextBox();
				this.showLinesCheckbox = new System.Windows.Forms.CheckBox();
				this.alphaBgCheckbox = new System.Windows.Forms.CheckBox();
				this.tiledBackgroundCheckbox = new System.Windows.Forms.CheckBox();
				this.chooseTileBtn = new System.Windows.Forms.Button();
				this.label1 = new System.Windows.Forms.Label();
				this.tileScaleBox = new System.Windows.Forms.NumericUpDown();
				this.label2 = new System.Windows.Forms.Label();
				this.cellImageSizetxtbox = new System.Windows.Forms.TextBox();
				this.label3 = new System.Windows.Forms.Label();
				this.atlasImageSizeTxtBox = new System.Windows.Forms.TextBox();
				this.chooseDiscoZoneBtn = new System.Windows.Forms.Button();
				this.showShipPathsInfoChckBox = new System.Windows.Forms.CheckBox();
				this.disableImageExportingCheckBox = new System.Windows.Forms.CheckBox();
				this.imageQualityTxtbox = new System.Windows.Forms.TextBox();
				this.label4 = new System.Windows.Forms.Label();
				this.showIslandNamesChckBox = new System.Windows.Forms.CheckBox();
				this.atlasLocation = new System.Windows.Forms.Label();
				this.showIslandsChckBox = new System.Windows.Forms.CheckBox();
				this.showGridNameChckBox = new System.Windows.Forms.CheckBox();
				this.showPathingGridCheckbox = new System.Windows.Forms.CheckBox();
				this.GridRowsTxtBox = new System.Windows.Forms.TextBox();
				this.gridRowsLabel = new System.Windows.Forms.Label();
				this.GridColumnsTxtBox = new System.Windows.Forms.TextBox();
				this.gridColumnsLabel = new System.Windows.Forms.Label();
				this.showForegroundChckBox = new System.Windows.Forms.CheckBox();
				this.chooseForegroundBtn = new System.Windows.Forms.Button();
				this.foregroundScaleBox = new System.Windows.Forms.NumericUpDown();
				this.label5 = new System.Windows.Forms.Label();
				this.Display = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
				this.IslandSize = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
				this.LevelName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
				this.islandListBox = new System.Windows.Forms.ListView();
				this.addIslandBtn = new System.Windows.Forms.Button();
				this.removeIslandBtn = new System.Windows.Forms.Button();
				this.editIslandBtn = new System.Windows.Forms.Button();
				this.mainTabControl = new System.Windows.Forms.TabControl();
				this.tabPage1 = new System.Windows.Forms.TabPage();
				this.tabPage2 = new System.Windows.Forms.TabPage();
				this.menuStrip1.SuspendLayout();
				((System.ComponentModel.ISupportInitialize)(this.tileScaleBox)).BeginInit();
				((System.ComponentModel.ISupportInitialize)(this.foregroundScaleBox)).BeginInit();
				this.mainTabControl.SuspendLayout();
				this.tabPage1.SuspendLayout();
				this.tabPage2.SuspendLayout();
				this.SuspendLayout();
				// 
				// mapPanel
				// 
				this.mapPanel.AllowDrop = true;
				this.mapPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
				this.mapPanel.BackColor = System.Drawing.SystemColors.ActiveCaption;
				this.mapPanel.Location = new System.Drawing.Point(25, 29);
				this.mapPanel.Name = "mapPanel";
				this.mapPanel.Size = new System.Drawing.Size(736, 630);
				this.mapPanel.TabIndex = 3;
				this.mapPanel.DragDrop += new System.Windows.Forms.DragEventHandler(this.mapPanel_DragDrop);
				this.mapPanel.DragOver += new System.Windows.Forms.DragEventHandler(this.mapPanel_DragOver);
				this.mapPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.mapPanel_Paint);
				this.mapPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.mapPanel_MouseDown);
				this.mapPanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.mapPanel_MouseMove);
				this.mapPanel.MouseUp += new System.Windows.Forms.MouseEventHandler(this.mapPanel_MouseUp);
				// 
				// createProjBtn
				// 
				this.createProjBtn.Anchor = System.Windows.Forms.AnchorStyles.None;
				this.createProjBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
				this.createProjBtn.Location = new System.Drawing.Point(442, 245);
				this.createProjBtn.Name = "createProjBtn";
				this.createProjBtn.Size = new System.Drawing.Size(239, 84);
				this.createProjBtn.TabIndex = 19;
				this.createProjBtn.Text = "Create Project";
				this.createProjBtn.UseVisualStyleBackColor = true;
				this.createProjBtn.Click += new System.EventHandler(this.createProjBtn_Click);
				// 
				// loadProjBtn
				// 
				this.loadProjBtn.Anchor = System.Windows.Forms.AnchorStyles.None;
				this.loadProjBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
				this.loadProjBtn.Location = new System.Drawing.Point(442, 364);
				this.loadProjBtn.Name = "loadProjBtn";
				this.loadProjBtn.Size = new System.Drawing.Size(239, 84);
				this.loadProjBtn.TabIndex = 20;
				this.loadProjBtn.Text = "Load Project";
				this.loadProjBtn.UseVisualStyleBackColor = true;
				this.loadProjBtn.Click += new System.EventHandler(this.loadProjBtn_Click);
				// 
				// mapHScrollBar
				// 
				this.mapHScrollBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
				this.mapHScrollBar.Enabled = false;
				this.mapHScrollBar.Location = new System.Drawing.Point(28, 662);
				this.mapHScrollBar.Name = "mapHScrollBar";
				this.mapHScrollBar.Size = new System.Drawing.Size(733, 17);
				this.mapHScrollBar.TabIndex = 4;
				this.mapHScrollBar.Scroll += new System.Windows.Forms.ScrollEventHandler(this.mapHScrollBar_Scroll);
				// 
				// mapVScrollBar
				// 
				this.mapVScrollBar.AllowDrop = true;
				this.mapVScrollBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
				this.mapVScrollBar.Enabled = false;
				this.mapVScrollBar.Location = new System.Drawing.Point(761, 29);
				this.mapVScrollBar.Name = "mapVScrollBar";
				this.mapVScrollBar.Size = new System.Drawing.Size(18, 650);
				this.mapVScrollBar.TabIndex = 5;
				this.mapVScrollBar.Scroll += new System.Windows.Forms.ScrollEventHandler(this.mapVScrollBar_Scroll);
				// 
				// menuStrip1
				// 
				this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.projectToolStripMenuItem,
            this.editToolStripMenuItem1,
            this.exportToolStripMenuItem,
            this.testsToolStripMenuItem,
            this.helpToolStripMenuItem});
				this.menuStrip1.Location = new System.Drawing.Point(0, 0);
				this.menuStrip1.Name = "menuStrip1";
				this.menuStrip1.Size = new System.Drawing.Size(1088, 24);
				this.menuStrip1.TabIndex = 6;
				this.menuStrip1.Text = "menuStrip1";
				// 
				// projectToolStripMenuItem
				// 
				this.projectToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.createToolStripMenuItem,
            this.openToolStripMenuItem,
            this.editToolStripMenuItem,
            this.saveToolStripMenuItem});
				this.projectToolStripMenuItem.Name = "projectToolStripMenuItem";
				this.projectToolStripMenuItem.Size = new System.Drawing.Size(56, 20);
				this.projectToolStripMenuItem.Text = "Project";
				// 
				// createToolStripMenuItem
				// 
				this.createToolStripMenuItem.Name = "createToolStripMenuItem";
				this.createToolStripMenuItem.Size = new System.Drawing.Size(108, 22);
				this.createToolStripMenuItem.Text = "Create";
				this.createToolStripMenuItem.Click += new System.EventHandler(this.createToolStripMenuItem_Click);
				// 
				// openToolStripMenuItem
				// 
				this.openToolStripMenuItem.Name = "openToolStripMenuItem";
				this.openToolStripMenuItem.Size = new System.Drawing.Size(108, 22);
				this.openToolStripMenuItem.Text = "Open";
				this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
				// 
				// editToolStripMenuItem
				// 
				this.editToolStripMenuItem.Enabled = false;
				this.editToolStripMenuItem.Name = "editToolStripMenuItem";
				this.editToolStripMenuItem.Size = new System.Drawing.Size(108, 22);
				this.editToolStripMenuItem.Text = "Edit";
				this.editToolStripMenuItem.Click += new System.EventHandler(this.editToolStripMenuItem_Click);
				// 
				// saveToolStripMenuItem
				// 
				this.saveToolStripMenuItem.Enabled = false;
				this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
				this.saveToolStripMenuItem.Size = new System.Drawing.Size(108, 22);
				this.saveToolStripMenuItem.Text = "Save";
				this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
				// 
				// editToolStripMenuItem1
				// 
				this.editToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editSpawnerTemplatesToolStripMenuItem,
            this.editAllDiscoveryZonesToolStripMenuItem,
            this.editSpawnPointsToolStripMenuItem,
            this.editServerTemplatesToolStripMenuItem,
            this.editLocksToolStripMenuItem,
            this.cullInvalidPathsToolStripMenuItem});
				this.editToolStripMenuItem1.Name = "editToolStripMenuItem1";
				this.editToolStripMenuItem1.Size = new System.Drawing.Size(39, 20);
				this.editToolStripMenuItem1.Text = "Edit";
				// 
				// editSpawnerTemplatesToolStripMenuItem
				// 
				this.editSpawnerTemplatesToolStripMenuItem.Name = "editSpawnerTemplatesToolStripMenuItem";
				this.editSpawnerTemplatesToolStripMenuItem.Size = new System.Drawing.Size(198, 22);
				this.editSpawnerTemplatesToolStripMenuItem.Text = "Edit Spawner Templates";
				this.editSpawnerTemplatesToolStripMenuItem.Click += new System.EventHandler(this.editSpawnerTemplatesToolStripMenuItem_Click);
				// 
				// editAllDiscoveryZonesToolStripMenuItem
				// 
				this.editAllDiscoveryZonesToolStripMenuItem.Name = "editAllDiscoveryZonesToolStripMenuItem";
				this.editAllDiscoveryZonesToolStripMenuItem.Size = new System.Drawing.Size(198, 22);
				this.editAllDiscoveryZonesToolStripMenuItem.Text = "Edit Discovery Zones";
				this.editAllDiscoveryZonesToolStripMenuItem.Click += new System.EventHandler(this.editAllDiscoveryZonesToolStripMenuItem_Click);
				// 
				// editSpawnPointsToolStripMenuItem
				// 
				this.editSpawnPointsToolStripMenuItem.Name = "editSpawnPointsToolStripMenuItem";
				this.editSpawnPointsToolStripMenuItem.Size = new System.Drawing.Size(198, 22);
				this.editSpawnPointsToolStripMenuItem.Text = "Edit Spawn Regions";
				this.editSpawnPointsToolStripMenuItem.Click += new System.EventHandler(this.editSpawnPointsToolStripMenuItem_Click);
				// 
				// editServerTemplatesToolStripMenuItem
				// 
				this.editServerTemplatesToolStripMenuItem.Enabled = false;
				this.editServerTemplatesToolStripMenuItem.Name = "editServerTemplatesToolStripMenuItem";
				this.editServerTemplatesToolStripMenuItem.Size = new System.Drawing.Size(198, 22);
				this.editServerTemplatesToolStripMenuItem.Text = "Edit Server Templates";
				this.editServerTemplatesToolStripMenuItem.Click += new System.EventHandler(this.editServerTemplatesToolStripMenuItem_Click);
				// 
				// editLocksToolStripMenuItem
				// 
				this.editLocksToolStripMenuItem.Name = "editLocksToolStripMenuItem";
				this.editLocksToolStripMenuItem.Size = new System.Drawing.Size(198, 22);
				this.editLocksToolStripMenuItem.Text = "Edit Locks";
				this.editLocksToolStripMenuItem.Click += new System.EventHandler(this.editLocksToolStripMenuItem_Click);
				// 
				// cullInvalidPathsToolStripMenuItem
				// 
				this.cullInvalidPathsToolStripMenuItem.Name = "cullInvalidPathsToolStripMenuItem";
				this.cullInvalidPathsToolStripMenuItem.Size = new System.Drawing.Size(198, 22);
				this.cullInvalidPathsToolStripMenuItem.Text = "Cull Invalid Paths";
				this.cullInvalidPathsToolStripMenuItem.Click += new System.EventHandler(this.cullInvalidPathsToolStripMenuItem_Click);
				// 
				// exportToolStripMenuItem
				// 
				this.exportToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exportAllToolStripMenuItem,
            this.mapImageToolStripMenuItem,
            this.cellImagesToolStripMenuItem,
            this.toolStripSeparator1,
            this.slippyMapToolStripMenuItem});
				this.exportToolStripMenuItem.Name = "exportToolStripMenuItem";
				this.exportToolStripMenuItem.Size = new System.Drawing.Size(53, 20);
				this.exportToolStripMenuItem.Text = "Export";
				// 
				// exportAllToolStripMenuItem
				// 
				this.exportAllToolStripMenuItem.Enabled = false;
				this.exportAllToolStripMenuItem.Name = "exportAllToolStripMenuItem";
				this.exportAllToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
				this.exportAllToolStripMenuItem.Text = "All";
				this.exportAllToolStripMenuItem.Click += new System.EventHandler(this.localExportToolStripMenuItem_Click);
				// 
				// mapImageToolStripMenuItem
				// 
				this.mapImageToolStripMenuItem.Enabled = false;
				this.mapImageToolStripMenuItem.Name = "mapImageToolStripMenuItem";
				this.mapImageToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
				this.mapImageToolStripMenuItem.Text = "Only Map Image";
				this.mapImageToolStripMenuItem.Click += new System.EventHandler(this.mapImageToolStripMenuItem_Click);
				// 
				// cellImagesToolStripMenuItem
				// 
				this.cellImagesToolStripMenuItem.Enabled = false;
				this.cellImagesToolStripMenuItem.Name = "cellImagesToolStripMenuItem";
				this.cellImagesToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
				this.cellImagesToolStripMenuItem.Text = "Only Cell Images";
				this.cellImagesToolStripMenuItem.Click += new System.EventHandler(this.cellImagesToolStripMenuItem_Click);
				// 
				// toolStripSeparator1
				// 
				this.toolStripSeparator1.Name = "toolStripSeparator1";
				this.toolStripSeparator1.Size = new System.Drawing.Size(187, 6);
				// 
				// slippyMapToolStripMenuItem
				// 
				this.slippyMapToolStripMenuItem.Enabled = false;
				this.slippyMapToolStripMenuItem.Name = "slippyMapToolStripMenuItem";
				this.slippyMapToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
				this.slippyMapToolStripMenuItem.Text = "Slippy Map (Optional)";
				this.slippyMapToolStripMenuItem.Click += new System.EventHandler(this.slippyMapToolStripMenuItem_Click);
				// 
				// testsToolStripMenuItem
				// 
				this.testsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.testAllServersWithDataClearToolStripMenuItem,
            this.testAllServersWithoutDataClearToolStripMenuItem});
				this.testsToolStripMenuItem.Name = "testsToolStripMenuItem";
				this.testsToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
				this.testsToolStripMenuItem.Text = "Tests";
				// 
				// testAllServersWithDataClearToolStripMenuItem
				// 
				this.testAllServersWithDataClearToolStripMenuItem.Enabled = false;
				this.testAllServersWithDataClearToolStripMenuItem.Name = "testAllServersWithDataClearToolStripMenuItem";
				this.testAllServersWithDataClearToolStripMenuItem.Size = new System.Drawing.Size(260, 22);
				this.testAllServersWithDataClearToolStripMenuItem.Text = "Test All Servers (With Data Clear)";
				// 
				// testAllServersWithoutDataClearToolStripMenuItem
				// 
				this.testAllServersWithoutDataClearToolStripMenuItem.Enabled = false;
				this.testAllServersWithoutDataClearToolStripMenuItem.Name = "testAllServersWithoutDataClearToolStripMenuItem";
				this.testAllServersWithoutDataClearToolStripMenuItem.Size = new System.Drawing.Size(260, 22);
				this.testAllServersWithoutDataClearToolStripMenuItem.Text = "Test All Servers (Without Data clear)";
				this.testAllServersWithoutDataClearToolStripMenuItem.Click += new System.EventHandler(this.testAllServersWithoutDataClearToolStripMenuItem_Click);
				// 
				// helpToolStripMenuItem
				// 
				this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.controlsToolStripMenuItem});
				this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
				this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
				this.helpToolStripMenuItem.Text = "Help";
				// 
				// controlsToolStripMenuItem
				// 
				this.controlsToolStripMenuItem.Name = "controlsToolStripMenuItem";
				this.controlsToolStripMenuItem.Size = new System.Drawing.Size(119, 22);
				this.controlsToolStripMenuItem.Text = "Controls";
				this.controlsToolStripMenuItem.Click += new System.EventHandler(this.controlsToolStripMenuItem_Click);
				// 
				// scaleLbl
				// 
				this.scaleLbl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
				this.scaleLbl.AutoSize = true;
				this.scaleLbl.Location = new System.Drawing.Point(195, 687);
				this.scaleLbl.Name = "scaleLbl";
				this.scaleLbl.Size = new System.Drawing.Size(130, 13);
				this.scaleLbl.TabIndex = 7;
				this.scaleLbl.Text = "1 pixel = 1000 unreal units";
				// 
				// showServerInfoCheckbox
				// 
				this.showServerInfoCheckbox.AutoSize = true;
				this.showServerInfoCheckbox.Checked = true;
				this.showServerInfoCheckbox.CheckState = System.Windows.Forms.CheckState.Checked;
				this.showServerInfoCheckbox.Location = new System.Drawing.Point(3, 174);
				this.showServerInfoCheckbox.Name = "showServerInfoCheckbox";
				this.showServerInfoCheckbox.Size = new System.Drawing.Size(108, 17);
				this.showServerInfoCheckbox.TabIndex = 8;
				this.showServerInfoCheckbox.Text = "Show Server Info";
				this.showServerInfoCheckbox.UseVisualStyleBackColor = true;
				this.showServerInfoCheckbox.CheckedChanged += new System.EventHandler(this.showServerInfoCheckbox_CheckedChanged);
				// 
				// showDiscoZoneInfoCheckbox
				// 
				this.showDiscoZoneInfoCheckbox.AutoSize = true;
				this.showDiscoZoneInfoCheckbox.Checked = true;
				this.showDiscoZoneInfoCheckbox.CheckState = System.Windows.Forms.CheckState.Checked;
				this.showDiscoZoneInfoCheckbox.Location = new System.Drawing.Point(3, 128);
				this.showDiscoZoneInfoCheckbox.Name = "showDiscoZoneInfoCheckbox";
				this.showDiscoZoneInfoCheckbox.Size = new System.Drawing.Size(152, 17);
				this.showDiscoZoneInfoCheckbox.TabIndex = 8;
				this.showDiscoZoneInfoCheckbox.Text = "Show Discovery Zone Info";
				this.showDiscoZoneInfoCheckbox.UseVisualStyleBackColor = true;
				this.showDiscoZoneInfoCheckbox.CheckedChanged += new System.EventHandler(this.showServerInfoCheckbox_CheckedChanged);
				// 
				// setRatioBtn
				// 
				this.setRatioBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
				this.setRatioBtn.Location = new System.Drawing.Point(114, 682);
				this.setRatioBtn.Name = "setRatioBtn";
				this.setRatioBtn.Size = new System.Drawing.Size(75, 23);
				this.setRatioBtn.TabIndex = 9;
				this.setRatioBtn.Text = "Set Ratio";
				this.setRatioBtn.UseVisualStyleBackColor = true;
				this.setRatioBtn.Click += new System.EventHandler(this.setRatioBtn_Click);
				// 
				// customRatioTxtBox
				// 
				this.customRatioTxtBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
				this.customRatioTxtBox.Location = new System.Drawing.Point(28, 684);
				this.customRatioTxtBox.Name = "customRatioTxtBox";
				this.customRatioTxtBox.Size = new System.Drawing.Size(83, 20);
				this.customRatioTxtBox.TabIndex = 10;
				this.customRatioTxtBox.Text = "100";
				this.customRatioTxtBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.customRatioTxtBox_KeyPress);
				// 
				// showLinesCheckbox
				// 
				this.showLinesCheckbox.AutoSize = true;
				this.showLinesCheckbox.Checked = true;
				this.showLinesCheckbox.CheckState = System.Windows.Forms.CheckState.Checked;
				this.showLinesCheckbox.Location = new System.Drawing.Point(3, 197);
				this.showLinesCheckbox.Name = "showLinesCheckbox";
				this.showLinesCheckbox.Size = new System.Drawing.Size(77, 17);
				this.showLinesCheckbox.TabIndex = 11;
				this.showLinesCheckbox.Text = "Show lines";
				this.showLinesCheckbox.UseVisualStyleBackColor = true;
				this.showLinesCheckbox.CheckedChanged += new System.EventHandler(this.showLinesCheckbox_CheckedChanged);
				// 
				// alphaBgCheckbox
				// 
				this.alphaBgCheckbox.AutoSize = true;
				this.alphaBgCheckbox.Location = new System.Drawing.Point(3, 309);
				this.alphaBgCheckbox.Name = "alphaBgCheckbox";
				this.alphaBgCheckbox.Size = new System.Drawing.Size(147, 17);
				this.alphaBgCheckbox.TabIndex = 13;
				this.alphaBgCheckbox.Text = "Export Alpha Background";
				this.alphaBgCheckbox.UseVisualStyleBackColor = true;
				this.alphaBgCheckbox.CheckedChanged += new System.EventHandler(this.alphaBgCheckbox_CheckedChanged);
				// 
				// tiledBackgroundCheckbox
				// 
				this.tiledBackgroundCheckbox.AutoSize = true;
				this.tiledBackgroundCheckbox.Location = new System.Drawing.Point(3, 220);
				this.tiledBackgroundCheckbox.Name = "tiledBackgroundCheckbox";
				this.tiledBackgroundCheckbox.Size = new System.Drawing.Size(136, 17);
				this.tiledBackgroundCheckbox.TabIndex = 14;
				this.tiledBackgroundCheckbox.Text = "Water Tile Background";
				this.tiledBackgroundCheckbox.UseVisualStyleBackColor = true;
				this.tiledBackgroundCheckbox.CheckedChanged += new System.EventHandler(this.tiledBackgroundCheckbox_CheckedChanged);
				// 
				// chooseTileBtn
				// 
				this.chooseTileBtn.Location = new System.Drawing.Point(161, 214);
				this.chooseTileBtn.Name = "chooseTileBtn";
				this.chooseTileBtn.Size = new System.Drawing.Size(86, 23);
				this.chooseTileBtn.TabIndex = 15;
				this.chooseTileBtn.Text = "Pick water tile";
				this.chooseTileBtn.UseVisualStyleBackColor = true;
				this.chooseTileBtn.Click += new System.EventHandler(this.chooseTileBtn_Click);
				// 
				// label1
				// 
				this.label1.AutoSize = true;
				this.label1.Location = new System.Drawing.Point(0, 417);
				this.label1.Name = "label1";
				this.label1.Size = new System.Drawing.Size(54, 13);
				this.label1.TabIndex = 17;
				this.label1.Text = "Tile Scale";
				// 
				// tileScaleBox
				// 
				this.tileScaleBox.DecimalPlaces = 3;
				this.tileScaleBox.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
				this.tileScaleBox.Location = new System.Drawing.Point(85, 415);
				this.tileScaleBox.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
				this.tileScaleBox.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            196608});
				this.tileScaleBox.Name = "tileScaleBox";
				this.tileScaleBox.Size = new System.Drawing.Size(54, 20);
				this.tileScaleBox.TabIndex = 18;
				this.tileScaleBox.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
				this.tileScaleBox.ValueChanged += new System.EventHandler(this.tileScaleBox_ValueChanged);
				// 
				// label2
				// 
				this.label2.AutoSize = true;
				this.label2.Location = new System.Drawing.Point(0, 342);
				this.label2.Name = "label2";
				this.label2.Size = new System.Drawing.Size(79, 13);
				this.label2.TabIndex = 21;
				this.label2.Text = "Cell Image Size";
				// 
				// cellImageSizetxtbox
				// 
				this.cellImageSizetxtbox.Location = new System.Drawing.Point(85, 339);
				this.cellImageSizetxtbox.Name = "cellImageSizetxtbox";
				this.cellImageSizetxtbox.Size = new System.Drawing.Size(47, 20);
				this.cellImageSizetxtbox.TabIndex = 22;
				this.cellImageSizetxtbox.TabStop = false;
				this.cellImageSizetxtbox.Text = "2048";
				this.cellImageSizetxtbox.TextChanged += new System.EventHandler(this.cellImageSizeTxtBox_TextChanged);
				this.cellImageSizetxtbox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cellImageSizeTxtBox_KeyPress);
				// 
				// label3
				// 
				this.label3.AutoSize = true;
				this.label3.Location = new System.Drawing.Point(0, 368);
				this.label3.Name = "label3";
				this.label3.Size = new System.Drawing.Size(85, 13);
				this.label3.TabIndex = 23;
				this.label3.Text = "Atlas Image Size";
				// 
				// atlasImageSizeTxtBox
				// 
				this.atlasImageSizeTxtBox.Location = new System.Drawing.Point(85, 365);
				this.atlasImageSizeTxtBox.Name = "atlasImageSizeTxtBox";
				this.atlasImageSizeTxtBox.Size = new System.Drawing.Size(47, 20);
				this.atlasImageSizeTxtBox.TabIndex = 24;
				this.atlasImageSizeTxtBox.TabStop = false;
				this.atlasImageSizeTxtBox.Text = "2048";
				this.atlasImageSizeTxtBox.TextChanged += new System.EventHandler(this.atlasImageSizeTxtBox_TextChanged);
				this.atlasImageSizeTxtBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.atlasImageSizeTxtBox_KeyPress);
				// 
				// chooseDiscoZoneBtn
				// 
				this.chooseDiscoZoneBtn.Location = new System.Drawing.Point(161, 124);
				this.chooseDiscoZoneBtn.Name = "chooseDiscoZoneBtn";
				this.chooseDiscoZoneBtn.Size = new System.Drawing.Size(111, 23);
				this.chooseDiscoZoneBtn.TabIndex = 25;
				this.chooseDiscoZoneBtn.Text = "Pick discozone tile";
				this.chooseDiscoZoneBtn.UseVisualStyleBackColor = true;
				this.chooseDiscoZoneBtn.Click += new System.EventHandler(this.chooseDiscoZoneBtn_Click);
				// 
				// showShipPathsInfoChckBox
				// 
				this.showShipPathsInfoChckBox.AutoSize = true;
				this.showShipPathsInfoChckBox.Checked = true;
				this.showShipPathsInfoChckBox.CheckState = System.Windows.Forms.CheckState.Checked;
				this.showShipPathsInfoChckBox.Location = new System.Drawing.Point(3, 151);
				this.showShipPathsInfoChckBox.Name = "showShipPathsInfoChckBox";
				this.showShipPathsInfoChckBox.Size = new System.Drawing.Size(107, 17);
				this.showShipPathsInfoChckBox.TabIndex = 26;
				this.showShipPathsInfoChckBox.Text = "Show Ship Paths";
				this.showShipPathsInfoChckBox.UseVisualStyleBackColor = true;
				this.showShipPathsInfoChckBox.CheckedChanged += new System.EventHandler(this.showShipPathsInfoChckBox_CheckedChanged);
				// 
				// disableImageExportingCheckBox
				// 
				this.disableImageExportingCheckBox.AutoSize = true;
				this.disableImageExportingCheckBox.Checked = true;
				this.disableImageExportingCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
				this.disableImageExportingCheckBox.Location = new System.Drawing.Point(3, 286);
				this.disableImageExportingCheckBox.Name = "disableImageExportingCheckBox";
				this.disableImageExportingCheckBox.Size = new System.Drawing.Size(140, 17);
				this.disableImageExportingCheckBox.TabIndex = 27;
				this.disableImageExportingCheckBox.Text = "Disable Image Exporting";
				this.disableImageExportingCheckBox.UseVisualStyleBackColor = true;
				this.disableImageExportingCheckBox.CheckedChanged += new System.EventHandler(this.disableImageExportingCheckBox_CheckedChanged);
				// 
				// imageQualityTxtbox
				// 
				this.imageQualityTxtbox.Location = new System.Drawing.Point(85, 389);
				this.imageQualityTxtbox.Name = "imageQualityTxtbox";
				this.imageQualityTxtbox.Size = new System.Drawing.Size(47, 20);
				this.imageQualityTxtbox.TabIndex = 29;
				this.imageQualityTxtbox.TabStop = false;
				this.imageQualityTxtbox.Text = "75";
				this.imageQualityTxtbox.TextChanged += new System.EventHandler(this.imageQualityTxtbox_TextChanged);
				this.imageQualityTxtbox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.imageQualityTxtbox_KeyPress);
				// 
				// label4
				// 
				this.label4.AutoSize = true;
				this.label4.Location = new System.Drawing.Point(0, 392);
				this.label4.Name = "label4";
				this.label4.Size = new System.Drawing.Size(82, 13);
				this.label4.TabIndex = 28;
				this.label4.Text = "Image Quality %";
				// 
				// showIslandNamesChckBox
				// 
				this.showIslandNamesChckBox.AutoSize = true;
				this.showIslandNamesChckBox.Checked = true;
				this.showIslandNamesChckBox.CheckState = System.Windows.Forms.CheckState.Checked;
				this.showIslandNamesChckBox.Location = new System.Drawing.Point(3, 105);
				this.showIslandNamesChckBox.Name = "showIslandNamesChckBox";
				this.showIslandNamesChckBox.Size = new System.Drawing.Size(120, 17);
				this.showIslandNamesChckBox.TabIndex = 30;
				this.showIslandNamesChckBox.Text = "Show Island Names";
				this.showIslandNamesChckBox.UseVisualStyleBackColor = true;
				this.showIslandNamesChckBox.CheckedChanged += new System.EventHandler(this.showIslandNamesChckBox_CheckedChanged);
				// 
				// atlasLocation
				// 
				this.atlasLocation.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
				this.atlasLocation.AutoSize = true;
				this.atlasLocation.Location = new System.Drawing.Point(684, 11);
				this.atlasLocation.Name = "atlasLocation";
				this.atlasLocation.Size = new System.Drawing.Size(74, 13);
				this.atlasLocation.TabIndex = 36;
				this.atlasLocation.Text = "Atlas Location";
				// 
				// showIslandsChckBox
				// 
				this.showIslandsChckBox.AutoSize = true;
				this.showIslandsChckBox.Checked = true;
				this.showIslandsChckBox.CheckState = System.Windows.Forms.CheckState.Checked;
				this.showIslandsChckBox.Location = new System.Drawing.Point(3, 59);
				this.showIslandsChckBox.Name = "showIslandsChckBox";
				this.showIslandsChckBox.Size = new System.Drawing.Size(89, 17);
				this.showIslandsChckBox.TabIndex = 37;
				this.showIslandsChckBox.Text = "Show Islands";
				this.showIslandsChckBox.UseVisualStyleBackColor = true;
				this.showIslandsChckBox.CheckedChanged += new System.EventHandler(this.showIslandsChckBox_CheckedChanged);
				// 
				// showGridNameChckBox
				// 
				this.showGridNameChckBox.AutoSize = true;
				this.showGridNameChckBox.Checked = true;
				this.showGridNameChckBox.CheckState = System.Windows.Forms.CheckState.Checked;
				this.showGridNameChckBox.Location = new System.Drawing.Point(3, 82);
				this.showGridNameChckBox.Name = "showGridNameChckBox";
				this.showGridNameChckBox.Size = new System.Drawing.Size(111, 17);
				this.showGridNameChckBox.TabIndex = 37;
				this.showGridNameChckBox.Text = "Show Grid Names";
				this.showGridNameChckBox.UseVisualStyleBackColor = true;
				this.showGridNameChckBox.CheckedChanged += new System.EventHandler(this.showGridNameChckBox_CheckedChanged);
				// 
				// showPathingGridCheckbox
				// 
				this.showPathingGridCheckbox.AutoSize = true;
				this.showPathingGridCheckbox.Location = new System.Drawing.Point(3, 243);
				this.showPathingGridCheckbox.Name = "showPathingGridCheckbox";
				this.showPathingGridCheckbox.Size = new System.Drawing.Size(114, 17);
				this.showPathingGridCheckbox.TabIndex = 37;
				this.showPathingGridCheckbox.Text = "Show Pathing Grid";
				this.showPathingGridCheckbox.UseVisualStyleBackColor = true;
				this.showPathingGridCheckbox.CheckedChanged += new System.EventHandler(this.showPathingGridCheckbox_CheckedChanged);
				// 
				// GridRowsTxtBox
				// 
				this.GridRowsTxtBox.Location = new System.Drawing.Point(81, 260);
				this.GridRowsTxtBox.Name = "GridRowsTxtBox";
				this.GridRowsTxtBox.Size = new System.Drawing.Size(47, 20);
				this.GridRowsTxtBox.TabIndex = 24;
				this.GridRowsTxtBox.TabStop = false;
				this.GridRowsTxtBox.Text = "10";
				this.GridRowsTxtBox.TextChanged += new System.EventHandler(this.GridRowsTxtBox_TextChanged);
				// 
				// gridRowsLabel
				// 
				this.gridRowsLabel.AutoSize = true;
				this.gridRowsLabel.Location = new System.Drawing.Point(25, 263);
				this.gridRowsLabel.Name = "gridRowsLabel";
				this.gridRowsLabel.Size = new System.Drawing.Size(56, 13);
				this.gridRowsLabel.TabIndex = 23;
				this.gridRowsLabel.Text = "Grid Rows";
				// 
				// GridColumnsTxtBox
				// 
				this.GridColumnsTxtBox.Location = new System.Drawing.Point(208, 260);
				this.GridColumnsTxtBox.Name = "GridColumnsTxtBox";
				this.GridColumnsTxtBox.Size = new System.Drawing.Size(47, 20);
				this.GridColumnsTxtBox.TabIndex = 39;
				this.GridColumnsTxtBox.TabStop = false;
				this.GridColumnsTxtBox.Text = "10";
				this.GridColumnsTxtBox.TextChanged += new System.EventHandler(this.GridColumnsTxtBox_TextChanged);
				// 
				// gridColumnsLabel
				// 
				this.gridColumnsLabel.AutoSize = true;
				this.gridColumnsLabel.Location = new System.Drawing.Point(135, 263);
				this.gridColumnsLabel.Name = "gridColumnsLabel";
				this.gridColumnsLabel.Size = new System.Drawing.Size(69, 13);
				this.gridColumnsLabel.TabIndex = 38;
				this.gridColumnsLabel.Text = "Grid Columns";
				// 
				// showForegroundChckBox
				// 
				this.showForegroundChckBox.AutoSize = true;
				this.showForegroundChckBox.Location = new System.Drawing.Point(3, 6);
				this.showForegroundChckBox.Name = "showForegroundChckBox";
				this.showForegroundChckBox.Size = new System.Drawing.Size(107, 17);
				this.showForegroundChckBox.TabIndex = 32;
				this.showForegroundChckBox.Text = "Show foreground";
				this.showForegroundChckBox.UseVisualStyleBackColor = true;
				this.showForegroundChckBox.CheckedChanged += new System.EventHandler(this.showForegroundChckBox_CheckedChanged);
				// 
				// chooseForegroundBtn
				// 
				this.chooseForegroundBtn.Location = new System.Drawing.Point(161, 2);
				this.chooseForegroundBtn.Name = "chooseForegroundBtn";
				this.chooseForegroundBtn.Size = new System.Drawing.Size(95, 23);
				this.chooseForegroundBtn.TabIndex = 33;
				this.chooseForegroundBtn.Text = "Pick Foreground";
				this.chooseForegroundBtn.UseVisualStyleBackColor = true;
				this.chooseForegroundBtn.Click += new System.EventHandler(this.chooseForegroundBtn_Click);
				// 
				// foregroundScaleBox
				// 
				this.foregroundScaleBox.DecimalPlaces = 3;
				this.foregroundScaleBox.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
				this.foregroundScaleBox.Location = new System.Drawing.Point(161, 27);
				this.foregroundScaleBox.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
				this.foregroundScaleBox.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            196608});
				this.foregroundScaleBox.Name = "foregroundScaleBox";
				this.foregroundScaleBox.Size = new System.Drawing.Size(54, 20);
				this.foregroundScaleBox.TabIndex = 34;
				this.foregroundScaleBox.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
				this.foregroundScaleBox.ValueChanged += new System.EventHandler(this.foregroundScaleBox_ValueChanged);
				// 
				// label5
				// 
				this.label5.AutoSize = true;
				this.label5.Location = new System.Drawing.Point(55, 29);
				this.label5.Name = "label5";
				this.label5.Size = new System.Drawing.Size(91, 13);
				this.label5.TabIndex = 35;
				this.label5.Text = "Foreground Scale";
				// 
				// Display
				// 
				this.Display.Text = "Display";
				// 
				// IslandSize
				// 
				this.IslandSize.Text = "Size";
				// 
				// LevelName
				// 
				this.LevelName.Text = "LevelName";
				// 
				// islandListBox
				// 
				this.islandListBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
				this.islandListBox.AutoArrange = false;
				this.islandListBox.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Display,
            this.IslandSize,
            this.LevelName});
				this.islandListBox.FullRowSelect = true;
				this.islandListBox.HideSelection = false;
				this.islandListBox.Location = new System.Drawing.Point(3, 6);
				this.islandListBox.Name = "islandListBox";
				this.islandListBox.OwnerDraw = true;
				this.islandListBox.Size = new System.Drawing.Size(292, 600);
				this.islandListBox.TabIndex = 0;
				this.islandListBox.UseCompatibleStateImageBehavior = false;
				this.islandListBox.View = System.Windows.Forms.View.Details;
				this.islandListBox.DrawColumnHeader += new System.Windows.Forms.DrawListViewColumnHeaderEventHandler(this.islandListBox_DrawColumnHeader);
				this.islandListBox.DrawItem += new System.Windows.Forms.DrawListViewItemEventHandler(this.islandListBox_DrawItem);
				this.islandListBox.DrawSubItem += new System.Windows.Forms.DrawListViewSubItemEventHandler(this.islandListBox_DrawSubItem);
				this.islandListBox.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.islandListBox_ItemDrag);
				// 
				// addIslandBtn
				// 
				this.addIslandBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
				this.addIslandBtn.Location = new System.Drawing.Point(3, 613);
				this.addIslandBtn.Name = "addIslandBtn";
				this.addIslandBtn.Size = new System.Drawing.Size(89, 34);
				this.addIslandBtn.TabIndex = 1;
				this.addIslandBtn.Text = "Add Island";
				this.addIslandBtn.UseVisualStyleBackColor = true;
				this.addIslandBtn.Click += new System.EventHandler(this.addIslandBtn_Click);
				// 
				// removeIslandBtn
				// 
				this.removeIslandBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
				this.removeIslandBtn.Location = new System.Drawing.Point(203, 612);
				this.removeIslandBtn.Name = "removeIslandBtn";
				this.removeIslandBtn.Size = new System.Drawing.Size(92, 34);
				this.removeIslandBtn.TabIndex = 2;
				this.removeIslandBtn.Text = "Remove Selected";
				this.removeIslandBtn.UseVisualStyleBackColor = true;
				this.removeIslandBtn.Click += new System.EventHandler(this.removeIslandBtn_Click);
				// 
				// editIslandBtn
				// 
				this.editIslandBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
				this.editIslandBtn.Location = new System.Drawing.Point(98, 612);
				this.editIslandBtn.Name = "editIslandBtn";
				this.editIslandBtn.Size = new System.Drawing.Size(99, 34);
				this.editIslandBtn.TabIndex = 12;
				this.editIslandBtn.Text = "Edit Island";
				this.editIslandBtn.UseVisualStyleBackColor = true;
				this.editIslandBtn.Click += new System.EventHandler(this.editIslandBtn_Click);
				// 
				// mainTabControl
				// 
				this.mainTabControl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
				this.mainTabControl.Controls.Add(this.tabPage1);
				this.mainTabControl.Controls.Add(this.tabPage2);
				this.mainTabControl.Location = new System.Drawing.Point(782, 29);
				this.mainTabControl.Name = "mainTabControl";
				this.mainTabControl.SelectedIndex = 0;
				this.mainTabControl.Size = new System.Drawing.Size(306, 676);
				this.mainTabControl.TabIndex = 40;
				// 
				// tabPage1
				// 
				this.tabPage1.Controls.Add(this.islandListBox);
				this.tabPage1.Controls.Add(this.addIslandBtn);
				this.tabPage1.Controls.Add(this.removeIslandBtn);
				this.tabPage1.Controls.Add(this.editIslandBtn);
				this.tabPage1.Location = new System.Drawing.Point(4, 22);
				this.tabPage1.Name = "tabPage1";
				this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
				this.tabPage1.Size = new System.Drawing.Size(298, 650);
				this.tabPage1.TabIndex = 0;
				this.tabPage1.Text = "Islands";
				this.tabPage1.UseVisualStyleBackColor = true;
				// 
				// tabPage2
				// 
				this.tabPage2.Controls.Add(this.disableImageExportingCheckBox);
				this.tabPage2.Controls.Add(this.showForegroundChckBox);
				this.tabPage2.Controls.Add(this.showPathingGridCheckbox);
				this.tabPage2.Controls.Add(this.alphaBgCheckbox);
				this.tabPage2.Controls.Add(this.chooseTileBtn);
				this.tabPage2.Controls.Add(this.cellImageSizetxtbox);
				this.tabPage2.Controls.Add(this.atlasImageSizeTxtBox);
				this.tabPage2.Controls.Add(this.GridColumnsTxtBox);
				this.tabPage2.Controls.Add(this.label5);
				this.tabPage2.Controls.Add(this.foregroundScaleBox);
				this.tabPage2.Controls.Add(this.label1);
				this.tabPage2.Controls.Add(this.gridRowsLabel);
				this.tabPage2.Controls.Add(this.tiledBackgroundCheckbox);
				this.tabPage2.Controls.Add(this.showIslandNamesChckBox);
				this.tabPage2.Controls.Add(this.label4);
				this.tabPage2.Controls.Add(this.label3);
				this.tabPage2.Controls.Add(this.showGridNameChckBox);
				this.tabPage2.Controls.Add(this.showIslandsChckBox);
				this.tabPage2.Controls.Add(this.showDiscoZoneInfoCheckbox);
				this.tabPage2.Controls.Add(this.tileScaleBox);
				this.tabPage2.Controls.Add(this.GridRowsTxtBox);
				this.tabPage2.Controls.Add(this.showServerInfoCheckbox);
				this.tabPage2.Controls.Add(this.gridColumnsLabel);
				this.tabPage2.Controls.Add(this.label2);
				this.tabPage2.Controls.Add(this.showLinesCheckbox);
				this.tabPage2.Controls.Add(this.chooseDiscoZoneBtn);
				this.tabPage2.Controls.Add(this.chooseForegroundBtn);
				this.tabPage2.Controls.Add(this.showShipPathsInfoChckBox);
				this.tabPage2.Controls.Add(this.imageQualityTxtbox);
				this.tabPage2.Location = new System.Drawing.Point(4, 22);
				this.tabPage2.Name = "tabPage2";
				this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
				this.tabPage2.Size = new System.Drawing.Size(298, 650);
				this.tabPage2.TabIndex = 1;
				this.tabPage2.Text = "View Options";
				this.tabPage2.UseVisualStyleBackColor = true;
				// 
				// MainForm
				// 
				this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
				this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
				this.ClientSize = new System.Drawing.Size(1088, 708);
				this.Controls.Add(this.mainTabControl);
				this.Controls.Add(this.atlasLocation);
				this.Controls.Add(this.customRatioTxtBox);
				this.Controls.Add(this.setRatioBtn);
				this.Controls.Add(this.scaleLbl);
				this.Controls.Add(this.mapVScrollBar);
				this.Controls.Add(this.mapHScrollBar);
				this.Controls.Add(this.mapPanel);
				this.Controls.Add(this.menuStrip1);
				this.Controls.Add(this.createProjBtn);
				this.Controls.Add(this.loadProjBtn);
				this.Cursor = System.Windows.Forms.Cursors.Arrow;
				this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
				this.KeyPreview = true;
				this.MinimumSize = new System.Drawing.Size(1104, 684);
				this.Name = "MainForm";
				this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
				this.Text = "Island Editor";
				this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
				this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyDown);
				this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyUp);
				this.menuStrip1.ResumeLayout(false);
				this.menuStrip1.PerformLayout();
				((System.ComponentModel.ISupportInitialize)(this.tileScaleBox)).EndInit();
				((System.ComponentModel.ISupportInitialize)(this.foregroundScaleBox)).EndInit();
				this.mainTabControl.ResumeLayout(false);
				this.tabPage1.ResumeLayout(false);
				this.tabPage2.ResumeLayout(false);
				this.tabPage2.PerformLayout();
				this.ResumeLayout(false);
				this.PerformLayout();

		  }

		  #endregion
		  private System.Windows.Forms.Panel mapPanel;
		  private System.Windows.Forms.HScrollBar mapHScrollBar;
		  private System.Windows.Forms.VScrollBar mapVScrollBar;
		  private System.Windows.Forms.MenuStrip menuStrip1;
		  private System.Windows.Forms.ToolStripMenuItem projectToolStripMenuItem;
		  private System.Windows.Forms.ToolStripMenuItem createToolStripMenuItem;
		  private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
		  private System.Windows.Forms.Label scaleLbl;
		  private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
		  private System.Windows.Forms.SaveFileDialog saveFileDialog;
		  private System.Windows.Forms.OpenFileDialog openFileDialog;
		  private System.Windows.Forms.ToolStripMenuItem exportToolStripMenuItem;
		  private System.Windows.Forms.ToolStripMenuItem mapImageToolStripMenuItem;
		  private System.Windows.Forms.CheckBox showServerInfoCheckbox;
		  private System.Windows.Forms.CheckBox showDiscoZoneInfoCheckbox;
		  private System.Windows.Forms.Button setRatioBtn;
		  private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
		  private System.Windows.Forms.ToolStripMenuItem controlsToolStripMenuItem;
		  private System.Windows.Forms.TextBox customRatioTxtBox;
		  private System.Windows.Forms.CheckBox showLinesCheckbox;
		  private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
		  private System.Windows.Forms.CheckBox alphaBgCheckbox;
		  private System.Windows.Forms.CheckBox tiledBackgroundCheckbox;
		  private System.Windows.Forms.Button chooseTileBtn;
		  private System.Windows.Forms.Label label1;
		  private System.Windows.Forms.NumericUpDown tileScaleBox;
		  private System.Windows.Forms.Button loadProjBtn;
		  private System.Windows.Forms.Button createProjBtn;
		  //        private System.Windows.Forms.ToolStripMenuItem clearTravelDataToolStripMenuItem;
		  private System.Windows.Forms.ToolStripMenuItem testsToolStripMenuItem;
		  private System.Windows.Forms.ToolStripMenuItem testAllServersWithDataClearToolStripMenuItem;
		  private System.Windows.Forms.ToolStripMenuItem testAllServersWithoutDataClearToolStripMenuItem;
		  private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem1;
		  private System.Windows.Forms.ToolStripMenuItem editSpawnerTemplatesToolStripMenuItem;
		  //        private System.Windows.Forms.ToolStripMenuItem LOCALClearTravelDataOnlyRemoveDataToolStripMenuItem;
		  private System.Windows.Forms.ToolStripMenuItem cellImagesToolStripMenuItem;
		  private System.Windows.Forms.Label label2;
		  private System.Windows.Forms.TextBox cellImageSizetxtbox;
		  private System.Windows.Forms.ToolStripMenuItem slippyMapToolStripMenuItem;
		  private System.Windows.Forms.ToolStripMenuItem exportAllToolStripMenuItem;
		  private System.Windows.Forms.Label label3;
		  private System.Windows.Forms.TextBox atlasImageSizeTxtBox;
		  private System.Windows.Forms.Button chooseDiscoZoneBtn;
		  private System.Windows.Forms.ToolStripMenuItem editAllDiscoveryZonesToolStripMenuItem;
		  private System.Windows.Forms.ToolStripMenuItem editSpawnPointsToolStripMenuItem;
		  private System.Windows.Forms.CheckBox showShipPathsInfoChckBox;
		  private System.Windows.Forms.CheckBox disableImageExportingCheckBox;
		  private System.Windows.Forms.TextBox imageQualityTxtbox;
		  private System.Windows.Forms.Label label4;
		  private System.Windows.Forms.CheckBox showIslandNamesChckBox;
		  private System.Windows.Forms.Label atlasLocation;
		  private System.Windows.Forms.ToolStripMenuItem editServerTemplatesToolStripMenuItem;
		  private System.Windows.Forms.ToolStripMenuItem editLocksToolStripMenuItem;
		  private System.Windows.Forms.ToolStripMenuItem cullInvalidPathsToolStripMenuItem;
		  private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		  private System.Windows.Forms.CheckBox showIslandsChckBox;
		  private System.Windows.Forms.CheckBox showGridNameChckBox;
		  private System.Windows.Forms.CheckBox showPathingGridCheckbox;
		  private System.Windows.Forms.TextBox GridRowsTxtBox;
		  private System.Windows.Forms.Label gridRowsLabel;
		  private System.Windows.Forms.TextBox GridColumnsTxtBox;
		  private System.Windows.Forms.Label gridColumnsLabel;
		  private System.Windows.Forms.CheckBox showForegroundChckBox;
		  private System.Windows.Forms.Button chooseForegroundBtn;
		  private System.Windows.Forms.NumericUpDown foregroundScaleBox;
		  private System.Windows.Forms.Label label5;
		  private System.Windows.Forms.ColumnHeader Display;
		  private System.Windows.Forms.ColumnHeader IslandSize;
		  private System.Windows.Forms.ColumnHeader LevelName;
		  private System.Windows.Forms.ListView islandListBox;
		  private System.Windows.Forms.Button addIslandBtn;
		  private System.Windows.Forms.Button removeIslandBtn;
		  private System.Windows.Forms.Button editIslandBtn;
		  private System.Windows.Forms.TabControl mainTabControl;
		  private System.Windows.Forms.TabPage tabPage1;
		  private System.Windows.Forms.TabPage tabPage2;
	 }
}