﻿using ServerGridEditor.Forms;

namespace ServerGridEditor
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
            this.islandListBox = new System.Windows.Forms.ListView();
            this.Display = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.IslandSize = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.LevelName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.addIslandBtn = new System.Windows.Forms.Button();
            this.removeIslandBtn = new System.Windows.Forms.Button();
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
            this.editServerConfigurationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editFoliageAttachmentOverrideToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editNodeTemplateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editRegionCategoriesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editRegionTemplateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editRegionsTreasureMapOverrideToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editRegionsOverworldLocationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mapImageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cellImagesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.slippyMapToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tradewindsWorldMapToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportServerJsonToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importServerJsonToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
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
            this.editIslandBtn = new System.Windows.Forms.Button();
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
            this.showForegroundChckBox = new System.Windows.Forms.CheckBox();
            this.chooseForegroundBtn = new System.Windows.Forms.Button();
            this.foregroundScaleBox = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.atlasLocation = new System.Windows.Forms.Label();
            this.showPathingGridCheckbox = new System.Windows.Forms.CheckBox();
            this.GridRowsTxtBox = new System.Windows.Forms.TextBox();
            this.gridRowsLabel = new System.Windows.Forms.Label();
            this.GridColumnsTxtBox = new System.Windows.Forms.TextBox();
            this.gridColumnsLabel = new System.Windows.Forms.Label();
            this.RecalcPathingGridButton = new System.Windows.Forms.Button();
            this.showTradeWindsChckBox = new System.Windows.Forms.CheckBox();
            this.tradeWindOverlayChckBox = new System.Windows.Forms.CheckBox();
            this.chooseTradeWindOverlayBtn = new System.Windows.Forms.Button();
            this.visualizeTradewindsWidthCheckBox = new System.Windows.Forms.CheckBox();
            this.showPortalNodesChckBox = new System.Windows.Forms.CheckBox();
            this.RegionComboBox = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.RegionTemplateOverridebtn = new System.Windows.Forms.Button();
            this.ExportServerTxt = new HintTextBox("Server to export a1");
            this.ImportServerTxt = new HintTextBox("Import to server a1");
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tileScaleBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.foregroundScaleBox)).BeginInit();
            this.SuspendLayout();
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
            this.islandListBox.Location = new System.Drawing.Point(1041, 36);
            this.islandListBox.Margin = new System.Windows.Forms.Padding(4);
            this.islandListBox.Name = "islandListBox";
            this.islandListBox.OwnerDraw = true;
            this.islandListBox.Size = new System.Drawing.Size(388, 854);
            this.islandListBox.TabIndex = 0;
            this.islandListBox.UseCompatibleStateImageBehavior = false;
            this.islandListBox.View = System.Windows.Forms.View.Details;
            this.islandListBox.DrawColumnHeader += new System.Windows.Forms.DrawListViewColumnHeaderEventHandler(this.islandListBox_DrawColumnHeader);
            this.islandListBox.DrawItem += new System.Windows.Forms.DrawListViewItemEventHandler(this.islandListBox_DrawItem);
            this.islandListBox.DrawSubItem += new System.Windows.Forms.DrawListViewSubItemEventHandler(this.islandListBox_DrawSubItem);
            this.islandListBox.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.islandListBox_ItemDrag);
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
            // addIslandBtn
            // 
            this.addIslandBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.addIslandBtn.Location = new System.Drawing.Point(1041, 900);
            this.addIslandBtn.Margin = new System.Windows.Forms.Padding(4);
            this.addIslandBtn.Name = "addIslandBtn";
            this.addIslandBtn.Size = new System.Drawing.Size(119, 42);
            this.addIslandBtn.TabIndex = 1;
            this.addIslandBtn.Text = "Add Island";
            this.addIslandBtn.UseVisualStyleBackColor = true;
            this.addIslandBtn.Click += new System.EventHandler(this.addIslandBtn_Click);
            // 
            // removeIslandBtn
            // 
            this.removeIslandBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.removeIslandBtn.Location = new System.Drawing.Point(1308, 898);
            this.removeIslandBtn.Margin = new System.Windows.Forms.Padding(4);
            this.removeIslandBtn.Name = "removeIslandBtn";
            this.removeIslandBtn.Size = new System.Drawing.Size(123, 42);
            this.removeIslandBtn.TabIndex = 2;
            this.removeIslandBtn.Text = "Remove Selected";
            this.removeIslandBtn.UseVisualStyleBackColor = true;
            this.removeIslandBtn.Click += new System.EventHandler(this.removeIslandBtn_Click);
            // 
            // mapPanel
            // 
            this.mapPanel.AllowDrop = true;
            this.mapPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.mapPanel.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.mapPanel.Location = new System.Drawing.Point(33, 36);
            this.mapPanel.Margin = new System.Windows.Forms.Padding(4);
            this.mapPanel.Name = "mapPanel";
            this.mapPanel.Size = new System.Drawing.Size(977, 718);
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
            this.createProjBtn.Location = new System.Drawing.Point(589, 342);
            this.createProjBtn.Margin = new System.Windows.Forms.Padding(4);
            this.createProjBtn.Name = "createProjBtn";
            this.createProjBtn.Size = new System.Drawing.Size(319, 103);
            this.createProjBtn.TabIndex = 19;
            this.createProjBtn.Text = "Create Project";
            this.createProjBtn.UseVisualStyleBackColor = true;
            this.createProjBtn.Click += new System.EventHandler(this.createProjBtn_Click);
            // 
            // loadProjBtn
            // 
            this.loadProjBtn.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.loadProjBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loadProjBtn.Location = new System.Drawing.Point(589, 489);
            this.loadProjBtn.Margin = new System.Windows.Forms.Padding(4);
            this.loadProjBtn.Name = "loadProjBtn";
            this.loadProjBtn.Size = new System.Drawing.Size(319, 103);
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
            this.mapHScrollBar.Location = new System.Drawing.Point(33, 757);
            this.mapHScrollBar.Name = "mapHScrollBar";
            this.mapHScrollBar.Size = new System.Drawing.Size(977, 17);
            this.mapHScrollBar.TabIndex = 4;
            this.mapHScrollBar.Scroll += new System.Windows.Forms.ScrollEventHandler(this.mapHScrollBar_Scroll);
            // 
            // mapVScrollBar
            // 
            this.mapVScrollBar.AllowDrop = true;
            this.mapVScrollBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.mapVScrollBar.Enabled = false;
            this.mapVScrollBar.Location = new System.Drawing.Point(1015, 36);
            this.mapVScrollBar.Name = "mapVScrollBar";
            this.mapVScrollBar.Size = new System.Drawing.Size(17, 742);
            this.mapVScrollBar.TabIndex = 5;
            this.mapVScrollBar.Scroll += new System.Windows.Forms.ScrollEventHandler(this.mapVScrollBar_Scroll);
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.projectToolStripMenuItem,
            this.editToolStripMenuItem1,
            this.exportToolStripMenuItem,
            this.testsToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(5, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(1451, 28);
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
            this.projectToolStripMenuItem.Size = new System.Drawing.Size(69, 24);
            this.projectToolStripMenuItem.Text = "Project";
            // 
            // createToolStripMenuItem
            // 
            this.createToolStripMenuItem.Name = "createToolStripMenuItem";
            this.createToolStripMenuItem.Size = new System.Drawing.Size(135, 26);
            this.createToolStripMenuItem.Text = "Create";
            this.createToolStripMenuItem.Click += new System.EventHandler(this.createToolStripMenuItem_Click);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(135, 26);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.Enabled = false;
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(135, 26);
            this.editToolStripMenuItem.Text = "Edit";
            this.editToolStripMenuItem.Click += new System.EventHandler(this.editToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Enabled = false;
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(135, 26);
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
            this.cullInvalidPathsToolStripMenuItem,
            this.editServerConfigurationToolStripMenuItem,
            this.editFoliageAttachmentOverrideToolStripMenuItem,
            this.editNodeTemplateToolStripMenuItem,
            this.editRegionCategoriesToolStripMenuItem,
            this.editRegionTemplateToolStripMenuItem,
            this.editRegionsTreasureMapOverrideToolStripMenuItem,
            this.editRegionsOverworldLocationToolStripMenuItem});
            this.editToolStripMenuItem1.Name = "editToolStripMenuItem1";
            this.editToolStripMenuItem1.Size = new System.Drawing.Size(49, 24);
            this.editToolStripMenuItem1.Text = "Edit";
            // 
            // editSpawnerTemplatesToolStripMenuItem
            // 
            this.editSpawnerTemplatesToolStripMenuItem.Name = "editSpawnerTemplatesToolStripMenuItem";
            this.editSpawnerTemplatesToolStripMenuItem.Size = new System.Drawing.Size(325, 26);
            this.editSpawnerTemplatesToolStripMenuItem.Text = "Edit Spawner Templates";
            this.editSpawnerTemplatesToolStripMenuItem.Click += new System.EventHandler(this.editSpawnerTemplatesToolStripMenuItem_Click);
            // 
            // editAllDiscoveryZonesToolStripMenuItem
            // 
            this.editAllDiscoveryZonesToolStripMenuItem.Name = "editAllDiscoveryZonesToolStripMenuItem";
            this.editAllDiscoveryZonesToolStripMenuItem.Size = new System.Drawing.Size(325, 26);
            this.editAllDiscoveryZonesToolStripMenuItem.Text = "Edit Discovery Zones";
            this.editAllDiscoveryZonesToolStripMenuItem.Click += new System.EventHandler(this.editAllDiscoveryZonesToolStripMenuItem_Click);
            // 
            // editSpawnPointsToolStripMenuItem
            // 
            this.editSpawnPointsToolStripMenuItem.Name = "editSpawnPointsToolStripMenuItem";
            this.editSpawnPointsToolStripMenuItem.Size = new System.Drawing.Size(325, 26);
            this.editSpawnPointsToolStripMenuItem.Text = "Edit Spawn Regions";
            this.editSpawnPointsToolStripMenuItem.Click += new System.EventHandler(this.editSpawnPointsToolStripMenuItem_Click);
            // 
            // editServerTemplatesToolStripMenuItem
            // 
            this.editServerTemplatesToolStripMenuItem.Enabled = false;
            this.editServerTemplatesToolStripMenuItem.Name = "editServerTemplatesToolStripMenuItem";
            this.editServerTemplatesToolStripMenuItem.Size = new System.Drawing.Size(325, 26);
            this.editServerTemplatesToolStripMenuItem.Text = "Edit Server Templates";
            this.editServerTemplatesToolStripMenuItem.Click += new System.EventHandler(this.editServerTemplatesToolStripMenuItem_Click);
            // 
            // editLocksToolStripMenuItem
            // 
            this.editLocksToolStripMenuItem.Name = "editLocksToolStripMenuItem";
            this.editLocksToolStripMenuItem.Size = new System.Drawing.Size(325, 26);
            this.editLocksToolStripMenuItem.Text = "Edit Locks";
            this.editLocksToolStripMenuItem.Click += new System.EventHandler(this.editLocksToolStripMenuItem_Click);
            // 
            // cullInvalidPathsToolStripMenuItem
            // 
            this.cullInvalidPathsToolStripMenuItem.Name = "cullInvalidPathsToolStripMenuItem";
            this.cullInvalidPathsToolStripMenuItem.Size = new System.Drawing.Size(325, 26);
            this.cullInvalidPathsToolStripMenuItem.Text = "Cull Invalid Paths";
            this.cullInvalidPathsToolStripMenuItem.Click += new System.EventHandler(this.cullInvalidPathsToolStripMenuItem_Click);
            // 
            // editServerConfigurationToolStripMenuItem
            // 
            this.editServerConfigurationToolStripMenuItem.Name = "editServerConfigurationToolStripMenuItem";
            this.editServerConfigurationToolStripMenuItem.Size = new System.Drawing.Size(325, 26);
            this.editServerConfigurationToolStripMenuItem.Text = "Edit Server Configurations";
            this.editServerConfigurationToolStripMenuItem.Click += new System.EventHandler(this.editServerConfigurationToolStripMenuItem_Click);
            // 
            // editFoliageAttachmentOverrideToolStripMenuItem
            // 
            this.editFoliageAttachmentOverrideToolStripMenuItem.Name = "editFoliageAttachmentOverrideToolStripMenuItem";
            this.editFoliageAttachmentOverrideToolStripMenuItem.Size = new System.Drawing.Size(325, 26);
            this.editFoliageAttachmentOverrideToolStripMenuItem.Text = "Edit Foliage Attachment Override";
            this.editFoliageAttachmentOverrideToolStripMenuItem.Click += new System.EventHandler(this.editFoliageAttachmentOverrideToolStripMenuItem_Click);
            // 
            // editNodeTemplateToolStripMenuItem
            // 
            this.editNodeTemplateToolStripMenuItem.Name = "editNodeTemplateToolStripMenuItem";
            this.editNodeTemplateToolStripMenuItem.Size = new System.Drawing.Size(325, 26);
            this.editNodeTemplateToolStripMenuItem.Text = "Edit Node Template";
            this.editNodeTemplateToolStripMenuItem.Click += new System.EventHandler(this.editNodeTemplateToolStripMenuItem_Click);
            // 
            // editRegionCategoriesToolStripMenuItem
            // 
            this.editRegionCategoriesToolStripMenuItem.Name = "editRegionCategoriesToolStripMenuItem";
            this.editRegionCategoriesToolStripMenuItem.Size = new System.Drawing.Size(325, 26);
            this.editRegionCategoriesToolStripMenuItem.Text = "Edit Region Categories";
            this.editRegionCategoriesToolStripMenuItem.Click += new System.EventHandler(this.editRegionCategoriesToolStripMenuItem_Click);
            // 
            // editRegionTemplateToolStripMenuItem
            // 
            this.editRegionTemplateToolStripMenuItem.Name = "editRegionTemplateToolStripMenuItem";
            this.editRegionTemplateToolStripMenuItem.Size = new System.Drawing.Size(325, 26);
            this.editRegionTemplateToolStripMenuItem.Text = "Edit Regions Templates";
            this.editRegionTemplateToolStripMenuItem.Click += new System.EventHandler(this.editRegionTemplateToolStripMenuItem_Click);
            // 
            // editRegionsTreasureMapOverrideToolStripMenuItem
            // 
            this.editRegionsTreasureMapOverrideToolStripMenuItem.Name = "editRegionsTreasureMapOverrideToolStripMenuItem";
            this.editRegionsTreasureMapOverrideToolStripMenuItem.Size = new System.Drawing.Size(325, 26);
            this.editRegionsTreasureMapOverrideToolStripMenuItem.Text = "Edit Regions TreasureMap Override";
            this.editRegionsTreasureMapOverrideToolStripMenuItem.Click += new System.EventHandler(this.editRegionsTreasureMapOverrideToolStripMenuItem_Click);
            // 
            // editRegionsOverworldLocationToolStripMenuItem
            // 
            this.editRegionsOverworldLocationToolStripMenuItem.Name = "editRegionsOverworldLocationToolStripMenuItem";
            this.editRegionsOverworldLocationToolStripMenuItem.Size = new System.Drawing.Size(325, 26);
            this.editRegionsOverworldLocationToolStripMenuItem.Text = "Edit Regions Overworld Location";
            this.editRegionsOverworldLocationToolStripMenuItem.Click += new System.EventHandler(this.editRegionsOverworldLocationToolStripMenuItem_Click);
            // 
            // exportToolStripMenuItem
            // 
            this.exportToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exportAllToolStripMenuItem,
            this.mapImageToolStripMenuItem,
            this.cellImagesToolStripMenuItem,
            this.toolStripSeparator1,
            this.slippyMapToolStripMenuItem,
            this.tradewindsWorldMapToolStripMenuItem,
            this.ExportServerTxt,
            this.exportServerJsonToolStripMenuItem,
            this.ImportServerTxt,
            this.importServerJsonToolStripMenuItem});
            this.exportToolStripMenuItem.Name = "exportToolStripMenuItem";
            this.exportToolStripMenuItem.Size = new System.Drawing.Size(66, 24);
            this.exportToolStripMenuItem.Text = "Export";
            // 
            // exportAllToolStripMenuItem
            // 
            this.exportAllToolStripMenuItem.Enabled = false;
            this.exportAllToolStripMenuItem.Name = "exportAllToolStripMenuItem";
            this.exportAllToolStripMenuItem.Size = new System.Drawing.Size(245, 26);
            this.exportAllToolStripMenuItem.Text = "All";
            this.exportAllToolStripMenuItem.Click += new System.EventHandler(this.localExportToolStripMenuItem_Click);
            // 
            // mapImageToolStripMenuItem
            // 
            this.mapImageToolStripMenuItem.Enabled = false;
            this.mapImageToolStripMenuItem.Name = "mapImageToolStripMenuItem";
            this.mapImageToolStripMenuItem.Size = new System.Drawing.Size(245, 26);
            this.mapImageToolStripMenuItem.Text = "Only Map Image";
            this.mapImageToolStripMenuItem.Click += new System.EventHandler(this.mapImageToolStripMenuItem_Click);
            // 
            // cellImagesToolStripMenuItem
            // 
            this.cellImagesToolStripMenuItem.Enabled = false;
            this.cellImagesToolStripMenuItem.Name = "cellImagesToolStripMenuItem";
            this.cellImagesToolStripMenuItem.Size = new System.Drawing.Size(245, 26);
            this.cellImagesToolStripMenuItem.Text = "Only Cell Images";
            this.cellImagesToolStripMenuItem.Click += new System.EventHandler(this.cellImagesToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(242, 6);
            // 
            // slippyMapToolStripMenuItem
            // 
            this.slippyMapToolStripMenuItem.Enabled = false;
            this.slippyMapToolStripMenuItem.Name = "slippyMapToolStripMenuItem";
            this.slippyMapToolStripMenuItem.Size = new System.Drawing.Size(245, 26);
            this.slippyMapToolStripMenuItem.Text = "Slippy Map (Optional)";
            this.slippyMapToolStripMenuItem.Click += new System.EventHandler(this.slippyMapToolStripMenuItem_Click);
            // 
            // tradewindsWorldMapToolStripMenuItem
            // 
            this.tradewindsWorldMapToolStripMenuItem.Name = "tradewindsWorldMapToolStripMenuItem";
            this.tradewindsWorldMapToolStripMenuItem.Size = new System.Drawing.Size(245, 26);
            this.tradewindsWorldMapToolStripMenuItem.Text = "Tradewinds World Map";
            this.tradewindsWorldMapToolStripMenuItem.Click += new System.EventHandler(this.tradewindsWorldMapToolStripMenuItem_Click);
            // 
            // exportServerJsonToolStripMenuItem
            // 
            this.exportServerJsonToolStripMenuItem.Name = "exportServerJsonToolStripMenuItem";
            this.exportServerJsonToolStripMenuItem.Size = new System.Drawing.Size(245, 26);
            this.exportServerJsonToolStripMenuItem.Text = "Export Server Json";
            this.exportServerJsonToolStripMenuItem.Click += new System.EventHandler(this.exportServerJsonToolStripMenuItem_Click);
            // 
            // importServerJsonToolStripMenuItem
            // 
            this.importServerJsonToolStripMenuItem.Name = "importServerJsonToolStripMenuItem";
            this.importServerJsonToolStripMenuItem.Size = new System.Drawing.Size(245, 26);
            this.importServerJsonToolStripMenuItem.Text = "Import Server Json";
            this.importServerJsonToolStripMenuItem.Click += new System.EventHandler(this.importServerJsonToolStripMenuItem_Click);
            // 
            // testsToolStripMenuItem
            // 
            this.testsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.testAllServersWithDataClearToolStripMenuItem,
            this.testAllServersWithoutDataClearToolStripMenuItem});
            this.testsToolStripMenuItem.Name = "testsToolStripMenuItem";
            this.testsToolStripMenuItem.Size = new System.Drawing.Size(55, 24);
            this.testsToolStripMenuItem.Text = "Tests";
            // 
            // testAllServersWithDataClearToolStripMenuItem
            // 
            this.testAllServersWithDataClearToolStripMenuItem.Enabled = false;
            this.testAllServersWithDataClearToolStripMenuItem.Name = "testAllServersWithDataClearToolStripMenuItem";
            this.testAllServersWithDataClearToolStripMenuItem.Size = new System.Drawing.Size(330, 26);
            this.testAllServersWithDataClearToolStripMenuItem.Text = "Test All Servers (With Data Clear)";
            // 
            // testAllServersWithoutDataClearToolStripMenuItem
            // 
            this.testAllServersWithoutDataClearToolStripMenuItem.Enabled = false;
            this.testAllServersWithoutDataClearToolStripMenuItem.Name = "testAllServersWithoutDataClearToolStripMenuItem";
            this.testAllServersWithoutDataClearToolStripMenuItem.Size = new System.Drawing.Size(330, 26);
            this.testAllServersWithoutDataClearToolStripMenuItem.Text = "Test All Servers (Without Data clear)";
            this.testAllServersWithoutDataClearToolStripMenuItem.Click += new System.EventHandler(this.testAllServersWithoutDataClearToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.controlsToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(55, 24);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // controlsToolStripMenuItem
            // 
            this.controlsToolStripMenuItem.Name = "controlsToolStripMenuItem";
            this.controlsToolStripMenuItem.Size = new System.Drawing.Size(147, 26);
            this.controlsToolStripMenuItem.Text = "Controls";
            this.controlsToolStripMenuItem.Click += new System.EventHandler(this.controlsToolStripMenuItem_Click);
            // 
            // scaleLbl
            // 
            this.scaleLbl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.scaleLbl.AutoSize = true;
            this.scaleLbl.Location = new System.Drawing.Point(21, 902);
            this.scaleLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.scaleLbl.Name = "scaleLbl";
            this.scaleLbl.Size = new System.Drawing.Size(174, 17);
            this.scaleLbl.TabIndex = 7;
            this.scaleLbl.Text = "1 pixel = 1000 unreal units";
            // 
            // showServerInfoCheckbox
            // 
            this.showServerInfoCheckbox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.showServerInfoCheckbox.AutoSize = true;
            this.showServerInfoCheckbox.Checked = true;
            this.showServerInfoCheckbox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.showServerInfoCheckbox.Location = new System.Drawing.Point(28, 843);
            this.showServerInfoCheckbox.Margin = new System.Windows.Forms.Padding(4);
            this.showServerInfoCheckbox.Name = "showServerInfoCheckbox";
            this.showServerInfoCheckbox.Size = new System.Drawing.Size(137, 21);
            this.showServerInfoCheckbox.TabIndex = 8;
            this.showServerInfoCheckbox.Text = "Show Server Info";
            this.showServerInfoCheckbox.UseVisualStyleBackColor = true;
            this.showServerInfoCheckbox.CheckedChanged += new System.EventHandler(this.showServerInfoCheckbox_CheckedChanged);
            // 
            // showDiscoZoneInfoCheckbox
            // 
            this.showDiscoZoneInfoCheckbox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.showDiscoZoneInfoCheckbox.AutoSize = true;
            this.showDiscoZoneInfoCheckbox.Checked = true;
            this.showDiscoZoneInfoCheckbox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.showDiscoZoneInfoCheckbox.Location = new System.Drawing.Point(187, 818);
            this.showDiscoZoneInfoCheckbox.Margin = new System.Windows.Forms.Padding(4);
            this.showDiscoZoneInfoCheckbox.Name = "showDiscoZoneInfoCheckbox";
            this.showDiscoZoneInfoCheckbox.Size = new System.Drawing.Size(174, 21);
            this.showDiscoZoneInfoCheckbox.TabIndex = 8;
            this.showDiscoZoneInfoCheckbox.Text = "Show Discovery Zones";
            this.showDiscoZoneInfoCheckbox.UseVisualStyleBackColor = true;
            this.showDiscoZoneInfoCheckbox.CheckedChanged += new System.EventHandler(this.showServerInfoCheckbox_CheckedChanged);
            // 
            // setRatioBtn
            // 
            this.setRatioBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.setRatioBtn.Location = new System.Drawing.Point(144, 917);
            this.setRatioBtn.Margin = new System.Windows.Forms.Padding(4);
            this.setRatioBtn.Name = "setRatioBtn";
            this.setRatioBtn.Size = new System.Drawing.Size(100, 28);
            this.setRatioBtn.TabIndex = 9;
            this.setRatioBtn.Text = "Set Ratio";
            this.setRatioBtn.UseVisualStyleBackColor = true;
            this.setRatioBtn.Click += new System.EventHandler(this.setRatioBtn_Click);
            // 
            // customRatioTxtBox
            // 
            this.customRatioTxtBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.customRatioTxtBox.Location = new System.Drawing.Point(25, 919);
            this.customRatioTxtBox.Margin = new System.Windows.Forms.Padding(4);
            this.customRatioTxtBox.Name = "customRatioTxtBox";
            this.customRatioTxtBox.Size = new System.Drawing.Size(109, 22);
            this.customRatioTxtBox.TabIndex = 10;
            this.customRatioTxtBox.Text = "100";
            this.customRatioTxtBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.customRatioTxtBox_KeyPress);
            // 
            // showLinesCheckbox
            // 
            this.showLinesCheckbox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.showLinesCheckbox.AutoSize = true;
            this.showLinesCheckbox.Checked = true;
            this.showLinesCheckbox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.showLinesCheckbox.Location = new System.Drawing.Point(187, 843);
            this.showLinesCheckbox.Margin = new System.Windows.Forms.Padding(4);
            this.showLinesCheckbox.Name = "showLinesCheckbox";
            this.showLinesCheckbox.Size = new System.Drawing.Size(97, 21);
            this.showLinesCheckbox.TabIndex = 11;
            this.showLinesCheckbox.Text = "Show lines";
            this.showLinesCheckbox.UseVisualStyleBackColor = true;
            this.showLinesCheckbox.CheckedChanged += new System.EventHandler(this.showLinesCheckbox_CheckedChanged);
            // 
            // editIslandBtn
            // 
            this.editIslandBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.editIslandBtn.Location = new System.Drawing.Point(1168, 898);
            this.editIslandBtn.Margin = new System.Windows.Forms.Padding(4);
            this.editIslandBtn.Name = "editIslandBtn";
            this.editIslandBtn.Size = new System.Drawing.Size(132, 42);
            this.editIslandBtn.TabIndex = 12;
            this.editIslandBtn.Text = "Edit Island";
            this.editIslandBtn.UseVisualStyleBackColor = true;
            this.editIslandBtn.Click += new System.EventHandler(this.editIslandBtn_Click);
            // 
            // alphaBgCheckbox
            // 
            this.alphaBgCheckbox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.alphaBgCheckbox.AutoSize = true;
            this.alphaBgCheckbox.Location = new System.Drawing.Point(292, 847);
            this.alphaBgCheckbox.Margin = new System.Windows.Forms.Padding(4);
            this.alphaBgCheckbox.Name = "alphaBgCheckbox";
            this.alphaBgCheckbox.Size = new System.Drawing.Size(190, 21);
            this.alphaBgCheckbox.TabIndex = 13;
            this.alphaBgCheckbox.Text = "Export Alpha Background";
            this.alphaBgCheckbox.UseVisualStyleBackColor = true;
            this.alphaBgCheckbox.CheckedChanged += new System.EventHandler(this.alphaBgCheckbox_CheckedChanged);
            // 
            // tiledBackgroundCheckbox
            // 
            this.tiledBackgroundCheckbox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.tiledBackgroundCheckbox.AutoSize = true;
            this.tiledBackgroundCheckbox.Location = new System.Drawing.Point(496, 847);
            this.tiledBackgroundCheckbox.Margin = new System.Windows.Forms.Padding(4);
            this.tiledBackgroundCheckbox.Name = "tiledBackgroundCheckbox";
            this.tiledBackgroundCheckbox.Size = new System.Drawing.Size(175, 21);
            this.tiledBackgroundCheckbox.TabIndex = 14;
            this.tiledBackgroundCheckbox.Text = "Water Tile Background";
            this.tiledBackgroundCheckbox.UseVisualStyleBackColor = true;
            this.tiledBackgroundCheckbox.CheckedChanged += new System.EventHandler(this.tiledBackgroundCheckbox_CheckedChanged);
            // 
            // chooseTileBtn
            // 
            this.chooseTileBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chooseTileBtn.Location = new System.Drawing.Point(593, 924);
            this.chooseTileBtn.Margin = new System.Windows.Forms.Padding(4);
            this.chooseTileBtn.Name = "chooseTileBtn";
            this.chooseTileBtn.Size = new System.Drawing.Size(208, 28);
            this.chooseTileBtn.TabIndex = 15;
            this.chooseTileBtn.Text = "Pick region water tile";
            this.chooseTileBtn.UseVisualStyleBackColor = true;
            this.chooseTileBtn.Click += new System.EventHandler(this.chooseTileBtn_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(957, 852);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 17);
            this.label1.TabIndex = 17;
            this.label1.Text = "Tile Scale";
            // 
            // tileScaleBox
            // 
            this.tileScaleBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.tileScaleBox.DecimalPlaces = 3;
            this.tileScaleBox.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.tileScaleBox.Location = new System.Drawing.Point(957, 871);
            this.tileScaleBox.Margin = new System.Windows.Forms.Padding(4);
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
            this.tileScaleBox.Size = new System.Drawing.Size(72, 22);
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
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(288, 896);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(104, 17);
            this.label2.TabIndex = 21;
            this.label2.Text = "Cell Image Size";
            // 
            // cellImageSizetxtbox
            // 
            this.cellImageSizetxtbox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cellImageSizetxtbox.Location = new System.Drawing.Point(401, 891);
            this.cellImageSizetxtbox.Margin = new System.Windows.Forms.Padding(4);
            this.cellImageSizetxtbox.Name = "cellImageSizetxtbox";
            this.cellImageSizetxtbox.Size = new System.Drawing.Size(61, 22);
            this.cellImageSizetxtbox.TabIndex = 22;
            this.cellImageSizetxtbox.TabStop = false;
            this.cellImageSizetxtbox.Text = "2048";
            this.cellImageSizetxtbox.TextChanged += new System.EventHandler(this.cellImageSizeTxtBox_TextChanged);
            this.cellImageSizetxtbox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cellImageSizeTxtBox_KeyPress);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(284, 922);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(112, 17);
            this.label3.TabIndex = 23;
            this.label3.Text = "Atlas Image Size";
            // 
            // atlasImageSizeTxtBox
            // 
            this.atlasImageSizeTxtBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.atlasImageSizeTxtBox.Location = new System.Drawing.Point(401, 918);
            this.atlasImageSizeTxtBox.Margin = new System.Windows.Forms.Padding(4);
            this.atlasImageSizeTxtBox.Name = "atlasImageSizeTxtBox";
            this.atlasImageSizeTxtBox.Size = new System.Drawing.Size(61, 22);
            this.atlasImageSizeTxtBox.TabIndex = 24;
            this.atlasImageSizeTxtBox.TabStop = false;
            this.atlasImageSizeTxtBox.Text = "2048";
            this.atlasImageSizeTxtBox.TextChanged += new System.EventHandler(this.atlasImageSizeTxtBox_TextChanged);
            this.atlasImageSizeTxtBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.atlasImageSizeTxtBox_KeyPress);
            // 
            // chooseDiscoZoneBtn
            // 
            this.chooseDiscoZoneBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chooseDiscoZoneBtn.Location = new System.Drawing.Point(801, 843);
            this.chooseDiscoZoneBtn.Margin = new System.Windows.Forms.Padding(4);
            this.chooseDiscoZoneBtn.Name = "chooseDiscoZoneBtn";
            this.chooseDiscoZoneBtn.Size = new System.Drawing.Size(148, 28);
            this.chooseDiscoZoneBtn.TabIndex = 25;
            this.chooseDiscoZoneBtn.Text = "Pick discozone tile";
            this.chooseDiscoZoneBtn.UseVisualStyleBackColor = true;
            this.chooseDiscoZoneBtn.Click += new System.EventHandler(this.chooseDiscoZoneBtn_Click);
            // 
            // showShipPathsInfoChckBox
            // 
            this.showShipPathsInfoChckBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.showShipPathsInfoChckBox.AutoSize = true;
            this.showShipPathsInfoChckBox.Checked = true;
            this.showShipPathsInfoChckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.showShipPathsInfoChckBox.Location = new System.Drawing.Point(367, 818);
            this.showShipPathsInfoChckBox.Margin = new System.Windows.Forms.Padding(4);
            this.showShipPathsInfoChckBox.Name = "showShipPathsInfoChckBox";
            this.showShipPathsInfoChckBox.Size = new System.Drawing.Size(136, 21);
            this.showShipPathsInfoChckBox.TabIndex = 26;
            this.showShipPathsInfoChckBox.Text = "Show Ship Paths";
            this.showShipPathsInfoChckBox.UseVisualStyleBackColor = true;
            this.showShipPathsInfoChckBox.CheckedChanged += new System.EventHandler(this.showShipPathsInfoChckBox_CheckedChanged);
            // 
            // disableImageExportingCheckBox
            // 
            this.disableImageExportingCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.disableImageExportingCheckBox.AutoSize = true;
            this.disableImageExportingCheckBox.Checked = true;
            this.disableImageExportingCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.disableImageExportingCheckBox.Location = new System.Drawing.Point(660, 818);
            this.disableImageExportingCheckBox.Margin = new System.Windows.Forms.Padding(4);
            this.disableImageExportingCheckBox.Name = "disableImageExportingCheckBox";
            this.disableImageExportingCheckBox.Size = new System.Drawing.Size(182, 21);
            this.disableImageExportingCheckBox.TabIndex = 27;
            this.disableImageExportingCheckBox.Text = "Disable Image Exporting";
            this.disableImageExportingCheckBox.UseVisualStyleBackColor = true;
            this.disableImageExportingCheckBox.CheckedChanged += new System.EventHandler(this.disableImageExportingCheckBox_CheckedChanged);
            // 
            // imageQualityTxtbox
            // 
            this.imageQualityTxtbox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.imageQualityTxtbox.Location = new System.Drawing.Point(967, 816);
            this.imageQualityTxtbox.Margin = new System.Windows.Forms.Padding(4);
            this.imageQualityTxtbox.Name = "imageQualityTxtbox";
            this.imageQualityTxtbox.Size = new System.Drawing.Size(61, 22);
            this.imageQualityTxtbox.TabIndex = 29;
            this.imageQualityTxtbox.TabStop = false;
            this.imageQualityTxtbox.Text = "75";
            this.imageQualityTxtbox.TextChanged += new System.EventHandler(this.imageQualityTxtbox_TextChanged);
            this.imageQualityTxtbox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.imageQualityTxtbox_KeyPress);
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(847, 822);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(110, 17);
            this.label4.TabIndex = 28;
            this.label4.Text = "Image Quality %";
            // 
            // showIslandNamesChckBox
            // 
            this.showIslandNamesChckBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.showIslandNamesChckBox.AutoSize = true;
            this.showIslandNamesChckBox.Checked = true;
            this.showIslandNamesChckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.showIslandNamesChckBox.Location = new System.Drawing.Point(28, 818);
            this.showIslandNamesChckBox.Margin = new System.Windows.Forms.Padding(4);
            this.showIslandNamesChckBox.Name = "showIslandNamesChckBox";
            this.showIslandNamesChckBox.Size = new System.Drawing.Size(153, 21);
            this.showIslandNamesChckBox.TabIndex = 30;
            this.showIslandNamesChckBox.Text = "Show Island Names";
            this.showIslandNamesChckBox.UseVisualStyleBackColor = true;
            this.showIslandNamesChckBox.CheckedChanged += new System.EventHandler(this.showIslandNamesChckBox_CheckedChanged);
            // 
            // showForegroundChckBox
            // 
            this.showForegroundChckBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.showForegroundChckBox.AutoSize = true;
            this.showForegroundChckBox.Location = new System.Drawing.Point(28, 791);
            this.showForegroundChckBox.Margin = new System.Windows.Forms.Padding(4);
            this.showForegroundChckBox.Name = "showForegroundChckBox";
            this.showForegroundChckBox.Size = new System.Drawing.Size(138, 21);
            this.showForegroundChckBox.TabIndex = 32;
            this.showForegroundChckBox.Text = "Show foreground";
            this.showForegroundChckBox.UseVisualStyleBackColor = true;
            this.showForegroundChckBox.CheckedChanged += new System.EventHandler(this.showForegroundChckBox_CheckedChanged);
            // 
            // chooseForegroundBtn
            // 
            this.chooseForegroundBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chooseForegroundBtn.Location = new System.Drawing.Point(176, 788);
            this.chooseForegroundBtn.Margin = new System.Windows.Forms.Padding(4);
            this.chooseForegroundBtn.Name = "chooseForegroundBtn";
            this.chooseForegroundBtn.Size = new System.Drawing.Size(127, 28);
            this.chooseForegroundBtn.TabIndex = 33;
            this.chooseForegroundBtn.Text = "Pick Foreground";
            this.chooseForegroundBtn.UseVisualStyleBackColor = true;
            this.chooseForegroundBtn.Click += new System.EventHandler(this.chooseForegroundBtn_Click);
            // 
            // foregroundScaleBox
            // 
            this.foregroundScaleBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.foregroundScaleBox.DecimalPlaces = 3;
            this.foregroundScaleBox.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.foregroundScaleBox.Location = new System.Drawing.Point(440, 790);
            this.foregroundScaleBox.Margin = new System.Windows.Forms.Padding(4);
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
            this.foregroundScaleBox.Size = new System.Drawing.Size(72, 22);
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
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(315, 794);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(121, 17);
            this.label5.TabIndex = 35;
            this.label5.Text = "Foreground Scale";
            // 
            // atlasLocation
            // 
            this.atlasLocation.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.atlasLocation.AutoSize = true;
            this.atlasLocation.Location = new System.Drawing.Point(912, 14);
            this.atlasLocation.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.atlasLocation.Name = "atlasLocation";
            this.atlasLocation.Size = new System.Drawing.Size(97, 17);
            this.atlasLocation.TabIndex = 36;
            this.atlasLocation.Text = "Atlas Location";
            // 
            // showPathingGridCheckbox
            // 
            this.showPathingGridCheckbox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.showPathingGridCheckbox.AutoSize = true;
            this.showPathingGridCheckbox.Location = new System.Drawing.Point(525, 791);
            this.showPathingGridCheckbox.Margin = new System.Windows.Forms.Padding(4);
            this.showPathingGridCheckbox.Name = "showPathingGridCheckbox";
            this.showPathingGridCheckbox.Size = new System.Drawing.Size(147, 21);
            this.showPathingGridCheckbox.TabIndex = 37;
            this.showPathingGridCheckbox.Text = "Show Pathing Grid";
            this.showPathingGridCheckbox.UseVisualStyleBackColor = true;
            this.showPathingGridCheckbox.CheckedChanged += new System.EventHandler(this.showPathingGridCheckbox_CheckedChanged);
            // 
            // GridRowsTxtBox
            // 
            this.GridRowsTxtBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.GridRowsTxtBox.Location = new System.Drawing.Point(752, 789);
            this.GridRowsTxtBox.Margin = new System.Windows.Forms.Padding(4);
            this.GridRowsTxtBox.Name = "GridRowsTxtBox";
            this.GridRowsTxtBox.Size = new System.Drawing.Size(33, 22);
            this.GridRowsTxtBox.TabIndex = 38;
            this.GridRowsTxtBox.TabStop = false;
            this.GridRowsTxtBox.Text = "10";
            this.GridRowsTxtBox.TextChanged += new System.EventHandler(this.GridRowsTxtBox_TextChanged);
            // 
            // gridRowsLabel
            // 
            this.gridRowsLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.gridRowsLabel.AutoSize = true;
            this.gridRowsLabel.Location = new System.Drawing.Point(675, 793);
            this.gridRowsLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.gridRowsLabel.Name = "gridRowsLabel";
            this.gridRowsLabel.Size = new System.Drawing.Size(73, 17);
            this.gridRowsLabel.TabIndex = 23;
            this.gridRowsLabel.Text = "Grid Rows";
            // 
            // GridColumnsTxtBox
            // 
            this.GridColumnsTxtBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.GridColumnsTxtBox.Location = new System.Drawing.Point(881, 788);
            this.GridColumnsTxtBox.Margin = new System.Windows.Forms.Padding(4);
            this.GridColumnsTxtBox.Name = "GridColumnsTxtBox";
            this.GridColumnsTxtBox.Size = new System.Drawing.Size(31, 22);
            this.GridColumnsTxtBox.TabIndex = 39;
            this.GridColumnsTxtBox.TabStop = false;
            this.GridColumnsTxtBox.Text = "10";
            this.GridColumnsTxtBox.TextChanged += new System.EventHandler(this.GridColumnsTxtBox_TextChanged);
            // 
            // gridColumnsLabel
            // 
            this.gridColumnsLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.gridColumnsLabel.AutoSize = true;
            this.gridColumnsLabel.Location = new System.Drawing.Point(789, 791);
            this.gridColumnsLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.gridColumnsLabel.Name = "gridColumnsLabel";
            this.gridColumnsLabel.Size = new System.Drawing.Size(93, 17);
            this.gridColumnsLabel.TabIndex = 38;
            this.gridColumnsLabel.Text = "Grid Columns";
            // 
            // RecalcPathingGridButton
            // 
            this.RecalcPathingGridButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.RecalcPathingGridButton.Location = new System.Drawing.Point(948, 784);
            this.RecalcPathingGridButton.Margin = new System.Windows.Forms.Padding(4);
            this.RecalcPathingGridButton.Name = "RecalcPathingGridButton";
            this.RecalcPathingGridButton.Size = new System.Drawing.Size(85, 28);
            this.RecalcPathingGridButton.TabIndex = 40;
            this.RecalcPathingGridButton.Text = "Recalc";
            this.RecalcPathingGridButton.UseVisualStyleBackColor = true;
            this.RecalcPathingGridButton.Click += new System.EventHandler(this.RecalcPathingGridButton_Click);
            // 
            // showTradeWindsChckBox
            // 
            this.showTradeWindsChckBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.showTradeWindsChckBox.AutoSize = true;
            this.showTradeWindsChckBox.Checked = true;
            this.showTradeWindsChckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.showTradeWindsChckBox.Location = new System.Drawing.Point(369, 873);
            this.showTradeWindsChckBox.Margin = new System.Windows.Forms.Padding(4);
            this.showTradeWindsChckBox.Name = "showTradeWindsChckBox";
            this.showTradeWindsChckBox.Size = new System.Drawing.Size(145, 21);
            this.showTradeWindsChckBox.TabIndex = 41;
            this.showTradeWindsChckBox.Text = "Show TradeWinds";
            this.showTradeWindsChckBox.UseVisualStyleBackColor = true;
            this.showTradeWindsChckBox.CheckedChanged += new System.EventHandler(this.showTradeWindsChckBox_CheckedChanged);
            // 
            // tradeWindOverlayChckBox
            // 
            this.tradeWindOverlayChckBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.tradeWindOverlayChckBox.AutoSize = true;
            this.tradeWindOverlayChckBox.Location = new System.Drawing.Point(28, 875);
            this.tradeWindOverlayChckBox.Margin = new System.Windows.Forms.Padding(4);
            this.tradeWindOverlayChckBox.Name = "tradeWindOverlayChckBox";
            this.tradeWindOverlayChckBox.Size = new System.Drawing.Size(157, 21);
            this.tradeWindOverlayChckBox.TabIndex = 42;
            this.tradeWindOverlayChckBox.Text = "Trade Wind Overlay";
            this.tradeWindOverlayChckBox.UseVisualStyleBackColor = true;
            this.tradeWindOverlayChckBox.CheckedChanged += new System.EventHandler(this.tradeWindOverlayChckBox_CheckedChanged);
            // 
            // chooseTradeWindOverlayBtn
            // 
            this.chooseTradeWindOverlayBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chooseTradeWindOverlayBtn.Location = new System.Drawing.Point(595, 895);
            this.chooseTradeWindOverlayBtn.Margin = new System.Windows.Forms.Padding(4);
            this.chooseTradeWindOverlayBtn.Name = "chooseTradeWindOverlayBtn";
            this.chooseTradeWindOverlayBtn.Size = new System.Drawing.Size(207, 28);
            this.chooseTradeWindOverlayBtn.TabIndex = 43;
            this.chooseTradeWindOverlayBtn.Text = "Pick region tradewind overlay";
            this.chooseTradeWindOverlayBtn.UseVisualStyleBackColor = true;
            this.chooseTradeWindOverlayBtn.Click += new System.EventHandler(this.chooseTradeWindOverlayBtn_Click);
            // 
            // visualizeTradewindsWidthCheckBox
            // 
            this.visualizeTradewindsWidthCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.visualizeTradewindsWidthCheckBox.AutoSize = true;
            this.visualizeTradewindsWidthCheckBox.Location = new System.Drawing.Point(520, 873);
            this.visualizeTradewindsWidthCheckBox.Margin = new System.Windows.Forms.Padding(4);
            this.visualizeTradewindsWidthCheckBox.Name = "visualizeTradewindsWidthCheckBox";
            this.visualizeTradewindsWidthCheckBox.Size = new System.Drawing.Size(203, 21);
            this.visualizeTradewindsWidthCheckBox.TabIndex = 44;
            this.visualizeTradewindsWidthCheckBox.Text = "Visualize Tradewinds Width";
            this.visualizeTradewindsWidthCheckBox.UseVisualStyleBackColor = true;
            this.visualizeTradewindsWidthCheckBox.CheckedChanged += new System.EventHandler(this.visualizeTradewindsWidthCheckBox_CheckedChanged);
            // 
            // showPortalNodesChckBox
            // 
            this.showPortalNodesChckBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.showPortalNodesChckBox.AutoSize = true;
            this.showPortalNodesChckBox.Checked = true;
            this.showPortalNodesChckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.showPortalNodesChckBox.Location = new System.Drawing.Point(736, 873);
            this.showPortalNodesChckBox.Margin = new System.Windows.Forms.Padding(4);
            this.showPortalNodesChckBox.Name = "showPortalNodesChckBox";
            this.showPortalNodesChckBox.Size = new System.Drawing.Size(150, 21);
            this.showPortalNodesChckBox.TabIndex = 45;
            this.showPortalNodesChckBox.Text = "Show Portal Nodes";
            this.showPortalNodesChckBox.UseVisualStyleBackColor = true;
            this.showPortalNodesChckBox.CheckedChanged += new System.EventHandler(this.showPortalNodesChckBox_CheckedChanged);
            // 
            // RegionComboBox
            // 
            this.RegionComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.RegionComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.RegionComboBox.FormattingEnabled = true;
            this.RegionComboBox.Location = new System.Drawing.Point(476, 924);
            this.RegionComboBox.Margin = new System.Windows.Forms.Padding(4);
            this.RegionComboBox.Name = "RegionComboBox";
            this.RegionComboBox.Size = new System.Drawing.Size(113, 24);
            this.RegionComboBox.TabIndex = 97;
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(477, 901);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(64, 17);
            this.label6.TabIndex = 98;
            this.label6.Text = "Regions:";
            // 
            // RegionTemplateOverridebtn
            // 
            this.RegionTemplateOverridebtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.RegionTemplateOverridebtn.Location = new System.Drawing.Point(805, 924);
            this.RegionTemplateOverridebtn.Margin = new System.Windows.Forms.Padding(4);
            this.RegionTemplateOverridebtn.Name = "RegionTemplateOverridebtn";
            this.RegionTemplateOverridebtn.Size = new System.Drawing.Size(207, 28);
            this.RegionTemplateOverridebtn.TabIndex = 99;
            this.RegionTemplateOverridebtn.Text = "Region Template Override";
            this.RegionTemplateOverridebtn.UseVisualStyleBackColor = true;
            this.RegionTemplateOverridebtn.Click += new System.EventHandler(this.RegionTemplateOverridebtn_Click);
            // 
            // toolStripTextBox1
            // 
            this.ExportServerTxt.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.ExportServerTxt.Name = "toolStripTextBox1";
            this.ExportServerTxt.Size = new System.Drawing.Size(130, 27);
            // 
            // toolStripTextBox2
            // 
            this.ImportServerTxt.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.ImportServerTxt.Name = "toolStripTextBox2";
            this.ImportServerTxt.Size = new System.Drawing.Size(130, 27);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1451, 954);
            this.Controls.Add(this.RegionTemplateOverridebtn);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.RegionComboBox);
            this.Controls.Add(this.showPortalNodesChckBox);
            this.Controls.Add(this.visualizeTradewindsWidthCheckBox);
            this.Controls.Add(this.chooseTradeWindOverlayBtn);
            this.Controls.Add(this.tradeWindOverlayChckBox);
            this.Controls.Add(this.showTradeWindsChckBox);
            this.Controls.Add(this.showShipPathsInfoChckBox);
            this.Controls.Add(this.showDiscoZoneInfoCheckbox);
            this.Controls.Add(this.disableImageExportingCheckBox);
            this.Controls.Add(this.RecalcPathingGridButton);
            this.Controls.Add(this.GridColumnsTxtBox);
            this.Controls.Add(this.gridColumnsLabel);
            this.Controls.Add(this.GridRowsTxtBox);
            this.Controls.Add(this.gridRowsLabel);
            this.Controls.Add(this.showPathingGridCheckbox);
            this.Controls.Add(this.atlasLocation);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.foregroundScaleBox);
            this.Controls.Add(this.chooseForegroundBtn);
            this.Controls.Add(this.showForegroundChckBox);
            this.Controls.Add(this.showIslandNamesChckBox);
            this.Controls.Add(this.imageQualityTxtbox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.chooseDiscoZoneBtn);
            this.Controls.Add(this.atlasImageSizeTxtBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cellImageSizetxtbox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tileScaleBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.chooseTileBtn);
            this.Controls.Add(this.tiledBackgroundCheckbox);
            this.Controls.Add(this.alphaBgCheckbox);
            this.Controls.Add(this.editIslandBtn);
            this.Controls.Add(this.showLinesCheckbox);
            this.Controls.Add(this.customRatioTxtBox);
            this.Controls.Add(this.setRatioBtn);
            this.Controls.Add(this.showServerInfoCheckbox);
            this.Controls.Add(this.scaleLbl);
            this.Controls.Add(this.mapVScrollBar);
            this.Controls.Add(this.mapHScrollBar);
            this.Controls.Add(this.mapPanel);
            this.Controls.Add(this.removeIslandBtn);
            this.Controls.Add(this.addIslandBtn);
            this.Controls.Add(this.islandListBox);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.createProjBtn);
            this.Controls.Add(this.loadProjBtn);
            this.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MinimumSize = new System.Drawing.Size(1466, 829);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Island Editor";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyUp);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tileScaleBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.foregroundScaleBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ColumnHeader Display;
        private System.Windows.Forms.ColumnHeader IslandSize;
        private System.Windows.Forms.ColumnHeader LevelName;
        private System.Windows.Forms.Button addIslandBtn;
        private System.Windows.Forms.Button removeIslandBtn;
        private System.Windows.Forms.ListView islandListBox;
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
        private System.Windows.Forms.Button editIslandBtn;
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
        private System.Windows.Forms.CheckBox showForegroundChckBox;
        private System.Windows.Forms.Button chooseForegroundBtn;
        private System.Windows.Forms.NumericUpDown foregroundScaleBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label atlasLocation;
        private System.Windows.Forms.ToolStripMenuItem editServerTemplatesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editLocksToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cullInvalidPathsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.CheckBox showPathingGridCheckbox;
        private System.Windows.Forms.TextBox GridRowsTxtBox;
        private System.Windows.Forms.Label gridRowsLabel;
        private System.Windows.Forms.TextBox GridColumnsTxtBox;
        private System.Windows.Forms.Label gridColumnsLabel;
        private System.Windows.Forms.Button RecalcPathingGridButton;
        private System.Windows.Forms.CheckBox showTradeWindsChckBox;
        private System.Windows.Forms.CheckBox tradeWindOverlayChckBox;
        private System.Windows.Forms.Button chooseTradeWindOverlayBtn;
        private System.Windows.Forms.ToolStripMenuItem tradewindsWorldMapToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editServerConfigurationToolStripMenuItem;
        private System.Windows.Forms.CheckBox visualizeTradewindsWidthCheckBox;
        private System.Windows.Forms.ToolStripMenuItem editFoliageAttachmentOverrideToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editNodeTemplateToolStripMenuItem;
        private System.Windows.Forms.CheckBox showPortalNodesChckBox;
        private System.Windows.Forms.ToolStripMenuItem editRegionCategoriesToolStripMenuItem;
        private System.Windows.Forms.ComboBox RegionComboBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ToolStripMenuItem editRegionTemplateToolStripMenuItem;
        private System.Windows.Forms.Button RegionTemplateOverridebtn;
        private System.Windows.Forms.ToolStripMenuItem editRegionsTreasureMapOverrideToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editRegionsOverworldLocationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportServerJsonToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem importServerJsonToolStripMenuItem;
        private HintTextBox ExportServerTxt;
        private HintTextBox ImportServerTxt;
    }
}

