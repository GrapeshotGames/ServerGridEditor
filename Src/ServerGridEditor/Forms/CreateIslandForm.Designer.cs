namespace ServerGridEditor
{
    partial class CreateIslandForm
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
            this.islandNameTxtBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.sizeXTxtBox = new System.Windows.Forms.TextBox();
            this.sizeYTxtBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.chooseImgBtn = new System.Windows.Forms.Button();
            this.createBtn = new System.Windows.Forms.Button();
            this.cancelBtn = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.sublevelsList = new System.Windows.Forms.ListBox();
            this.addSublevels = new System.Windows.Forms.Button();
            this.landscapeMaterialOverrideTxtBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.spawnerOverridesGrid = new System.Windows.Forms.DataGridView();
            this.SpawnerName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SpawnerTemplate = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.minTreasureQualityTxtBox = new System.Windows.Forms.TextBox();
            this.maxTreasureQualityTxtBox = new System.Windows.Forms.TextBox();
            this.useNpcVolumesForTreasuresChkBox = new System.Windows.Forms.CheckBox();
            this.useLevelBoundsForTreasuresChkBox = new System.Windows.Forms.CheckBox();
            this.prioritizeVolumesForTreasuresChkBox = new System.Windows.Forms.CheckBox();
            this.label10 = new System.Windows.Forms.Label();
            this.IslandTreasureBottleSupplyCrateOverridesTxtBox = new System.Windows.Forms.TextBox();
            this.extraSublevelsTxtBox = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.instancesListBox = new System.Windows.Forms.ListBox();
            this.label13 = new System.Windows.Forms.Label();
            this.modNameTxtBox = new System.Windows.Forms.TextBox();
            this.islandPointsTxtBox = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.singleSpawnPointYTxtBox = new System.Windows.Forms.TextBox();
            this.singleSpawnPointXTxtBox = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.singleSpawnPointZTxtBox = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.TreasureMapSpawnPointsTxtBox = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.WildPirateCampSpawnPointsTxtBox = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label22 = new System.Windows.Forms.Label();
            this.isControlPointChkBox = new System.Windows.Forms.CheckBox();
            this.isControlPointAllowCaptureChckBox = new System.Windows.Forms.CheckBox();
            this.harvestOverridesGrid = new System.Windows.Forms.DataGridView();
            this.label21 = new System.Windows.Forms.Label();
            this.ImportHarvestOverridesButton = new System.Windows.Forms.Button();
            this.ExportHarvestOverridesButton = new System.Windows.Forms.Button();
            this.FoliageOverrideKey = new System.Windows.Forms.DataGridViewComboBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spawnerOverridesGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.harvestOverridesGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // islandNameTxtBox
            // 
            this.islandNameTxtBox.Location = new System.Drawing.Point(105, 40);
            this.islandNameTxtBox.Name = "islandNameTxtBox";
            this.islandNameTxtBox.Size = new System.Drawing.Size(144, 20);
            this.islandNameTxtBox.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Island Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(63, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(27, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Size";
            // 
            // sizeXTxtBox
            // 
            this.sizeXTxtBox.Location = new System.Drawing.Point(105, 67);
            this.sizeXTxtBox.Name = "sizeXTxtBox";
            this.sizeXTxtBox.Size = new System.Drawing.Size(55, 20);
            this.sizeXTxtBox.TabIndex = 2;
            this.sizeXTxtBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.sizeXTxtBox_KeyPress);
            // 
            // sizeYTxtBox
            // 
            this.sizeYTxtBox.Location = new System.Drawing.Point(194, 67);
            this.sizeYTxtBox.Name = "sizeYTxtBox";
            this.sizeYTxtBox.Size = new System.Drawing.Size(55, 20);
            this.sizeYTxtBox.TabIndex = 4;
            this.sizeYTxtBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.sizeYTxtBox_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(120, 90);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(14, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "X";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(209, 90);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(14, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Y";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.pictureBox1.Location = new System.Drawing.Point(191, 136);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(60, 50);
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            // 
            // chooseImgBtn
            // 
            this.chooseImgBtn.Location = new System.Drawing.Point(57, 150);
            this.chooseImgBtn.Name = "chooseImgBtn";
            this.chooseImgBtn.Size = new System.Drawing.Size(104, 23);
            this.chooseImgBtn.TabIndex = 8;
            this.chooseImgBtn.Text = "Choose Image";
            this.chooseImgBtn.UseVisualStyleBackColor = true;
            this.chooseImgBtn.Click += new System.EventHandler(this.chooseImgBtn_Click);
            // 
            // createBtn
            // 
            this.createBtn.Location = new System.Drawing.Point(17, 770);
            this.createBtn.Name = "createBtn";
            this.createBtn.Size = new System.Drawing.Size(111, 39);
            this.createBtn.TabIndex = 9;
            this.createBtn.Text = "Create";
            this.createBtn.UseVisualStyleBackColor = true;
            this.createBtn.Click += new System.EventHandler(this.createBtn_Click);
            // 
            // cancelBtn
            // 
            this.cancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelBtn.Location = new System.Drawing.Point(134, 770);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(118, 39);
            this.cancelBtn.TabIndex = 10;
            this.cancelBtn.Text = "Cancel";
            this.cancelBtn.UseVisualStyleBackColor = true;
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(24, 83);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(66, 12);
            this.label5.TabIndex = 11;
            this.label5.Text = "In Unreal Units";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // sublevelsList
            // 
            this.sublevelsList.FormattingEnabled = true;
            this.sublevelsList.Location = new System.Drawing.Point(26, 193);
            this.sublevelsList.Name = "sublevelsList";
            this.sublevelsList.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.sublevelsList.Size = new System.Drawing.Size(226, 95);
            this.sublevelsList.TabIndex = 12;
            this.sublevelsList.KeyDown += new System.Windows.Forms.KeyEventHandler(this.sublevelsList_KeyDown);
            // 
            // addSublevels
            // 
            this.addSublevels.Location = new System.Drawing.Point(96, 295);
            this.addSublevels.Name = "addSublevels";
            this.addSublevels.Size = new System.Drawing.Size(90, 24);
            this.addSublevels.TabIndex = 13;
            this.addSublevels.Text = "Add Sublevels";
            this.addSublevels.UseVisualStyleBackColor = true;
            this.addSublevels.Click += new System.EventHandler(this.addSublevels_Click);
            // 
            // landscapeMaterialOverrideTxtBox
            // 
            this.landscapeMaterialOverrideTxtBox.Location = new System.Drawing.Point(197, 110);
            this.landscapeMaterialOverrideTxtBox.Name = "landscapeMaterialOverrideTxtBox";
            this.landscapeMaterialOverrideTxtBox.Size = new System.Drawing.Size(55, 20);
            this.landscapeMaterialOverrideTxtBox.TabIndex = 14;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(21, 114);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(172, 13);
            this.label6.TabIndex = 15;
            this.label6.Text = "Landscape Material Override Index";
            // 
            // label7
            // 
            this.label7.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(266, 14);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(143, 20);
            this.label7.TabIndex = 17;
            this.label7.Text = "Spawner Overrides";
            // 
            // spawnerOverridesGrid
            // 
            this.spawnerOverridesGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.spawnerOverridesGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.SpawnerName,
            this.SpawnerTemplate});
            this.spawnerOverridesGrid.Location = new System.Drawing.Point(270, 39);
            this.spawnerOverridesGrid.Name = "spawnerOverridesGrid";
            this.spawnerOverridesGrid.Size = new System.Drawing.Size(323, 147);
            this.spawnerOverridesGrid.TabIndex = 16;
            // 
            // SpawnerName
            // 
            this.SpawnerName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.SpawnerName.HeaderText = "Spawner Name";
            this.SpawnerName.Name = "SpawnerName";
            // 
            // SpawnerTemplate
            // 
            this.SpawnerTemplate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.SpawnerTemplate.HeaderText = "Spawner Template";
            this.SpawnerTemplate.Name = "SpawnerTemplate";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(26, 338);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(128, 13);
            this.label8.TabIndex = 18;
            this.label8.Text = "Minimum Treasure Quality";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(26, 361);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(125, 13);
            this.label9.TabIndex = 19;
            this.label9.Text = "MaximumTreasureQuality";
            // 
            // minTreasureQualityTxtBox
            // 
            this.minTreasureQualityTxtBox.Location = new System.Drawing.Point(168, 335);
            this.minTreasureQualityTxtBox.Name = "minTreasureQualityTxtBox";
            this.minTreasureQualityTxtBox.Size = new System.Drawing.Size(55, 20);
            this.minTreasureQualityTxtBox.TabIndex = 20;
            this.minTreasureQualityTxtBox.Text = "-1";
            // 
            // maxTreasureQualityTxtBox
            // 
            this.maxTreasureQualityTxtBox.Location = new System.Drawing.Point(168, 358);
            this.maxTreasureQualityTxtBox.Name = "maxTreasureQualityTxtBox";
            this.maxTreasureQualityTxtBox.Size = new System.Drawing.Size(55, 20);
            this.maxTreasureQualityTxtBox.TabIndex = 21;
            this.maxTreasureQualityTxtBox.Text = "-1";
            // 
            // useNpcVolumesForTreasuresChkBox
            // 
            this.useNpcVolumesForTreasuresChkBox.AutoSize = true;
            this.useNpcVolumesForTreasuresChkBox.Location = new System.Drawing.Point(24, 407);
            this.useNpcVolumesForTreasuresChkBox.Name = "useNpcVolumesForTreasuresChkBox";
            this.useNpcVolumesForTreasuresChkBox.Size = new System.Drawing.Size(174, 17);
            this.useNpcVolumesForTreasuresChkBox.TabIndex = 23;
            this.useNpcVolumesForTreasuresChkBox.Text = "Use NPC Volumes for treasures";
            this.useNpcVolumesForTreasuresChkBox.UseVisualStyleBackColor = true;
            // 
            // useLevelBoundsForTreasuresChkBox
            // 
            this.useLevelBoundsForTreasuresChkBox.AutoSize = true;
            this.useLevelBoundsForTreasuresChkBox.Checked = true;
            this.useLevelBoundsForTreasuresChkBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.useLevelBoundsForTreasuresChkBox.Location = new System.Drawing.Point(24, 469);
            this.useLevelBoundsForTreasuresChkBox.Name = "useLevelBoundsForTreasuresChkBox";
            this.useLevelBoundsForTreasuresChkBox.Size = new System.Drawing.Size(169, 17);
            this.useLevelBoundsForTreasuresChkBox.TabIndex = 24;
            this.useLevelBoundsForTreasuresChkBox.Text = "Use level bounds for treasures";
            this.useLevelBoundsForTreasuresChkBox.UseVisualStyleBackColor = true;
            // 
            // prioritizeVolumesForTreasuresChkBox
            // 
            this.prioritizeVolumesForTreasuresChkBox.AutoSize = true;
            this.prioritizeVolumesForTreasuresChkBox.Location = new System.Drawing.Point(24, 433);
            this.prioritizeVolumesForTreasuresChkBox.Name = "prioritizeVolumesForTreasuresChkBox";
            this.prioritizeVolumesForTreasuresChkBox.Size = new System.Drawing.Size(194, 30);
            this.prioritizeVolumesForTreasuresChkBox.TabIndex = 25;
            this.prioritizeVolumesForTreasuresChkBox.Text = "Prioritize volumes over level bounds\r\nfor treasures";
            this.prioritizeVolumesForTreasuresChkBox.UseVisualStyleBackColor = true;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(258, 402);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(206, 13);
            this.label10.TabIndex = 27;
            this.label10.Text = "IslandTreasureBottleSupplyCrateOverrides";
            // 
            // IslandTreasureBottleSupplyCrateOverridesTxtBox
            // 
            this.IslandTreasureBottleSupplyCrateOverridesTxtBox.Location = new System.Drawing.Point(261, 418);
            this.IslandTreasureBottleSupplyCrateOverridesTxtBox.Multiline = true;
            this.IslandTreasureBottleSupplyCrateOverridesTxtBox.Name = "IslandTreasureBottleSupplyCrateOverridesTxtBox";
            this.IslandTreasureBottleSupplyCrateOverridesTxtBox.Size = new System.Drawing.Size(332, 70);
            this.IslandTreasureBottleSupplyCrateOverridesTxtBox.TabIndex = 35;
            // 
            // extraSublevelsTxtBox
            // 
            this.extraSublevelsTxtBox.Location = new System.Drawing.Point(261, 516);
            this.extraSublevelsTxtBox.Multiline = true;
            this.extraSublevelsTxtBox.Name = "extraSublevelsTxtBox";
            this.extraSublevelsTxtBox.Size = new System.Drawing.Size(332, 75);
            this.extraSublevelsTxtBox.TabIndex = 36;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(258, 500);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(77, 13);
            this.label11.TabIndex = 37;
            this.label11.Text = "ExtraSublevels";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(21, 550);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(154, 13);
            this.label12.TabIndex = 38;
            this.label12.Text = "Island instances locations";
            // 
            // instancesListBox
            // 
            this.instancesListBox.FormattingEnabled = true;
            this.instancesListBox.Location = new System.Drawing.Point(24, 567);
            this.instancesListBox.Name = "instancesListBox";
            this.instancesListBox.Size = new System.Drawing.Size(194, 95);
            this.instancesListBox.TabIndex = 39;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(20, 18);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(114, 13);
            this.label13.TabIndex = 40;
            this.label13.Text = "Unique Mod Extension";
            // 
            // modNameTxtBox
            // 
            this.modNameTxtBox.Location = new System.Drawing.Point(140, 15);
            this.modNameTxtBox.Name = "modNameTxtBox";
            this.modNameTxtBox.Size = new System.Drawing.Size(109, 20);
            this.modNameTxtBox.TabIndex = 41;
            // 
            // islandPointsTxtBox
            // 
            this.islandPointsTxtBox.Location = new System.Drawing.Point(167, 381);
            this.islandPointsTxtBox.Name = "islandPointsTxtBox";
            this.islandPointsTxtBox.Size = new System.Drawing.Size(55, 20);
            this.islandPointsTxtBox.TabIndex = 43;
            this.islandPointsTxtBox.Text = "1";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(26, 382);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(67, 13);
            this.label14.TabIndex = 42;
            this.label14.Text = "Island Points";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(10, 674);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(84, 13);
            this.label16.TabIndex = 44;
            this.label16.Text = "SP Spawn Point";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(145, 713);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(14, 13);
            this.label17.TabIndex = 49;
            this.label17.Text = "Y";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(82, 713);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(14, 13);
            this.label18.TabIndex = 48;
            this.label18.Text = "X";
            // 
            // singleSpawnPointYTxtBox
            // 
            this.singleSpawnPointYTxtBox.Location = new System.Drawing.Point(130, 690);
            this.singleSpawnPointYTxtBox.Name = "singleSpawnPointYTxtBox";
            this.singleSpawnPointYTxtBox.Size = new System.Drawing.Size(55, 20);
            this.singleSpawnPointYTxtBox.TabIndex = 47;
            // 
            // singleSpawnPointXTxtBox
            // 
            this.singleSpawnPointXTxtBox.Location = new System.Drawing.Point(67, 690);
            this.singleSpawnPointXTxtBox.Name = "singleSpawnPointXTxtBox";
            this.singleSpawnPointXTxtBox.Size = new System.Drawing.Size(55, 20);
            this.singleSpawnPointXTxtBox.TabIndex = 46;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(209, 713);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(14, 13);
            this.label19.TabIndex = 51;
            this.label19.Text = "Z";
            // 
            // singleSpawnPointZTxtBox
            // 
            this.singleSpawnPointZTxtBox.Location = new System.Drawing.Point(194, 690);
            this.singleSpawnPointZTxtBox.Name = "singleSpawnPointZTxtBox";
            this.singleSpawnPointZTxtBox.Size = new System.Drawing.Size(55, 20);
            this.singleSpawnPointZTxtBox.TabIndex = 50;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(257, 596);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(132, 13);
            this.label15.TabIndex = 53;
            this.label15.Text = "TreasureMapSpawnPoints";
            // 
            // TreasureMapSpawnPointsTxtBox
            // 
            this.TreasureMapSpawnPointsTxtBox.Location = new System.Drawing.Point(260, 612);
            this.TreasureMapSpawnPointsTxtBox.Multiline = true;
            this.TreasureMapSpawnPointsTxtBox.Name = "TreasureMapSpawnPointsTxtBox";
            this.TreasureMapSpawnPointsTxtBox.Size = new System.Drawing.Size(332, 82);
            this.TreasureMapSpawnPointsTxtBox.TabIndex = 52;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(258, 697);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(144, 13);
            this.label20.TabIndex = 55;
            this.label20.Text = "WildPirateCampSpawnPoints";
            // 
            // WildPirateCampSpawnPointsTxtBox
            // 
            this.WildPirateCampSpawnPointsTxtBox.Location = new System.Drawing.Point(261, 713);
            this.WildPirateCampSpawnPointsTxtBox.Multiline = true;
            this.WildPirateCampSpawnPointsTxtBox.Name = "WildPirateCampSpawnPointsTxtBox";
            this.WildPirateCampSpawnPointsTxtBox.Size = new System.Drawing.Size(332, 82);
            this.WildPirateCampSpawnPointsTxtBox.TabIndex = 54;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(194, 733);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(55, 20);
            this.textBox1.TabIndex = 56;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(69, 736);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(119, 13);
            this.label22.TabIndex = 58;
            this.label22.Text = "Island Max Claim Flag Z";
            // 
            // isControlPointChkBox
            // 
            this.isControlPointChkBox.AutoSize = true;
            this.isControlPointChkBox.Location = new System.Drawing.Point(23, 499);
            this.isControlPointChkBox.Name = "isControlPointChkBox";
            this.isControlPointChkBox.Size = new System.Drawing.Size(97, 17);
            this.isControlPointChkBox.TabIndex = 59;
            this.isControlPointChkBox.Text = "Is Control Point";
            this.isControlPointChkBox.UseVisualStyleBackColor = true;
            // 
            // isControlPointAllowCaptureChckBox
            // 
            this.isControlPointAllowCaptureChckBox.AutoSize = true;
            this.isControlPointAllowCaptureChckBox.Checked = true;
            this.isControlPointAllowCaptureChckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.isControlPointAllowCaptureChckBox.Location = new System.Drawing.Point(23, 525);
            this.isControlPointAllowCaptureChckBox.Name = "isControlPointAllowCaptureChckBox";
            this.isControlPointAllowCaptureChckBox.Size = new System.Drawing.Size(180, 17);
            this.isControlPointAllowCaptureChckBox.TabIndex = 60;
            this.isControlPointAllowCaptureChckBox.Text = "Is Control Point  Allowed Capture";
            this.isControlPointAllowCaptureChckBox.UseVisualStyleBackColor = true;
            // 
            // harvestOverridesGrid
            // 
            this.harvestOverridesGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.harvestOverridesGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.FoliageOverrideKey});
            this.harvestOverridesGrid.Location = new System.Drawing.Point(268, 212);
            this.harvestOverridesGrid.Name = "harvestOverridesGrid";
            this.harvestOverridesGrid.Size = new System.Drawing.Size(323, 162);
            this.harvestOverridesGrid.TabIndex = 61;
            // 
            // label21
            // 
            this.label21.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.Location = new System.Drawing.Point(266, 189);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(135, 20);
            this.label21.TabIndex = 62;
            this.label21.Text = "Harvest Overrides";
            // 
            // ImportHarvestOverridesButton
            // 
            this.ImportHarvestOverridesButton.Location = new System.Drawing.Point(270, 375);
            this.ImportHarvestOverridesButton.Name = "ImportHarvestOverridesButton";
            this.ImportHarvestOverridesButton.Size = new System.Drawing.Size(159, 24);
            this.ImportHarvestOverridesButton.TabIndex = 63;
            this.ImportHarvestOverridesButton.Text = "Import Harvest Overrides...";
            this.ImportHarvestOverridesButton.UseVisualStyleBackColor = true;
            this.ImportHarvestOverridesButton.Visible = false;
            this.ImportHarvestOverridesButton.Click += new System.EventHandler(this.ImportHarvestOverridesButton_Click);
            // 
            // ExportHarvestOverridesButton
            // 
            this.ExportHarvestOverridesButton.Location = new System.Drawing.Point(435, 376);
            this.ExportHarvestOverridesButton.Name = "ExportHarvestOverridesButton";
            this.ExportHarvestOverridesButton.Size = new System.Drawing.Size(155, 24);
            this.ExportHarvestOverridesButton.TabIndex = 64;
            this.ExportHarvestOverridesButton.Text = "Export Harvest Overrides...";
            this.ExportHarvestOverridesButton.UseVisualStyleBackColor = true;
            this.ExportHarvestOverridesButton.Visible = false;
            this.ExportHarvestOverridesButton.Click += new System.EventHandler(this.ExportHarvestOverridesButton_Click);
            // 
            // FoliageOverrideKey
            // 
            this.FoliageOverrideKey.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.FoliageOverrideKey.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox;
            this.FoliageOverrideKey.HeaderText = "Foliage Override Key";
            this.FoliageOverrideKey.Name = "FoliageOverrideKey";
            this.FoliageOverrideKey.Width = 84;
            // 
            // CreateIslandForm
            // 
            this.AcceptButton = this.createBtn;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelBtn;
            this.ClientSize = new System.Drawing.Size(609, 823);
            this.Controls.Add(this.ExportHarvestOverridesButton);
            this.Controls.Add(this.ImportHarvestOverridesButton);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.harvestOverridesGrid);
            this.Controls.Add(this.isControlPointAllowCaptureChckBox);
            this.Controls.Add(this.isControlPointChkBox);
            this.Controls.Add(this.label22);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.WildPirateCampSpawnPointsTxtBox);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.TreasureMapSpawnPointsTxtBox);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.singleSpawnPointZTxtBox);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.singleSpawnPointYTxtBox);
            this.Controls.Add(this.singleSpawnPointXTxtBox);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.islandPointsTxtBox);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.modNameTxtBox);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.instancesListBox);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.extraSublevelsTxtBox);
            this.Controls.Add(this.IslandTreasureBottleSupplyCrateOverridesTxtBox);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.prioritizeVolumesForTreasuresChkBox);
            this.Controls.Add(this.useLevelBoundsForTreasuresChkBox);
            this.Controls.Add(this.useNpcVolumesForTreasuresChkBox);
            this.Controls.Add(this.maxTreasureQualityTxtBox);
            this.Controls.Add(this.minTreasureQualityTxtBox);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.spawnerOverridesGrid);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.landscapeMaterialOverrideTxtBox);
            this.Controls.Add(this.addSublevels);
            this.Controls.Add(this.sublevelsList);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.createBtn);
            this.Controls.Add(this.chooseImgBtn);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.sizeYTxtBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.sizeXTxtBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.islandNameTxtBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CreateIslandForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Create Island";
            this.Load += new System.EventHandler(this.Form2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spawnerOverridesGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.harvestOverridesGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox islandNameTxtBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox sizeXTxtBox;
        private System.Windows.Forms.TextBox sizeYTxtBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button chooseImgBtn;
        private System.Windows.Forms.Button createBtn;
        private System.Windows.Forms.Button cancelBtn;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ListBox sublevelsList;
        private System.Windows.Forms.Button addSublevels;
        private System.Windows.Forms.TextBox landscapeMaterialOverrideTxtBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DataGridView spawnerOverridesGrid;
        private System.Windows.Forms.DataGridViewTextBoxColumn SpawnerName;
        private System.Windows.Forms.DataGridViewComboBoxColumn SpawnerTemplate;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox minTreasureQualityTxtBox;
        private System.Windows.Forms.TextBox maxTreasureQualityTxtBox;
        private System.Windows.Forms.CheckBox useNpcVolumesForTreasuresChkBox;
        private System.Windows.Forms.CheckBox useLevelBoundsForTreasuresChkBox;
        private System.Windows.Forms.CheckBox prioritizeVolumesForTreasuresChkBox;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox IslandTreasureBottleSupplyCrateOverridesTxtBox;
        private System.Windows.Forms.TextBox extraSublevelsTxtBox;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ListBox instancesListBox;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox modNameTxtBox;
        private System.Windows.Forms.TextBox islandPointsTxtBox;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox singleSpawnPointYTxtBox;
        private System.Windows.Forms.TextBox singleSpawnPointXTxtBox;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.TextBox singleSpawnPointZTxtBox;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox TreasureMapSpawnPointsTxtBox;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.TextBox WildPirateCampSpawnPointsTxtBox;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.CheckBox isControlPointChkBox;
        private System.Windows.Forms.CheckBox isControlPointAllowCaptureChckBox;
        private System.Windows.Forms.DataGridView harvestOverridesGrid;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Button ImportHarvestOverridesButton;
        private System.Windows.Forms.Button ExportHarvestOverridesButton;
        private System.Windows.Forms.DataGridViewComboBoxColumn FoliageOverrideKey;
    }
}