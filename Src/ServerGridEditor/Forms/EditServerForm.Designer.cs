namespace ServerGridEditor
{
    partial class EditServerForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.portTxtBox = new System.Windows.Forms.TextBox();
            this.gamePortTxtBox = new System.Windows.Forms.TextBox();
            this.saveBtn = new System.Windows.Forms.Button();
            this.ipTxtBox = new System.Windows.Forms.TextBox();
            this.cancelBtn = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.homeServerCheckbox = new System.Windows.Forms.CheckBox();
            this.runTestsBtn = new System.Windows.Forms.Button();
            this.nameTxtBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.FloorZDist = new System.Windows.Forms.TextBox();
            this.OceanDinoDepthEntriesOverrideLbl = new System.Windows.Forms.Label();
            this.OceanDinoDepthEntriesOverrideTxtBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.OceanFloatsamCratesOverrideTxtBox = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.transitionMinZTxtBox = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.utcOffsetTxtBox = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.TreasureMapLootTablesOverrideTxtBox = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.seamlessDataPortTxt = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.GlobalBiomeSeamlessServerGridPreOffsetValuesTxtBox = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.GlobalBiomeSeamlessServerGridPreOffsetValuesOceanWaterTxtBox = new System.Windows.Forms.TextBox();
            this.editSpawnRegions = new System.Windows.Forms.Button();
            this.additionalCmdLineParamsTxtBox = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label29 = new System.Windows.Forms.Label();
            this.overrideShooterGameModeDefaultGameIniDataGridView = new System.Windows.Forms.DataGridView();
            this.label16 = new System.Windows.Forms.Label();
            this.extraSublevelTxtBox = new System.Windows.Forms.TextBox();
            this.oceanEpicSpawnEntriesOverrideTemplateNameTxtBox = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.NPCShipSpawnEntriesOverrideTemplateNameTxtBox = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.regionOverridesTxtBox = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.coordsLbl = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.skyStyleIndexTxtBox = new System.Windows.Forms.TextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.waterColorRTxtBox = new System.Windows.Forms.TextBox();
            this.waterColorGTxtBox = new System.Windows.Forms.TextBox();
            this.waterColorBTxtBox = new System.Windows.Forms.TextBox();
            this.label22 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.ServerCustomDatas1TxtBox = new System.Windows.Forms.TextBox();
            this.label25 = new System.Windows.Forms.Label();
            this.ServerCustomDatas2TxtBox = new System.Windows.Forms.TextBox();
            this.label26 = new System.Windows.Forms.Label();
            this.ClientCustomDatas2TxtBox = new System.Windows.Forms.TextBox();
            this.label27 = new System.Windows.Forms.Label();
            this.ClientCustomDatas1TxtBox = new System.Windows.Forms.TextBox();
            this.label28 = new System.Windows.Forms.Label();
            this.label30 = new System.Windows.Forms.Label();
            this.templateComboBox = new System.Windows.Forms.ComboBox();
            this.OceanEpicSpawnEntriesOverrideValuesTxtBox = new System.Windows.Forms.TextBox();
            this.label31 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.overrideShooterGameModeDefaultGameIniDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(20, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "IP:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Port:";
            // 
            // portTxtBox
            // 
            this.portTxtBox.Location = new System.Drawing.Point(46, 67);
            this.portTxtBox.Name = "portTxtBox";
            this.portTxtBox.Size = new System.Drawing.Size(55, 20);
            this.portTxtBox.TabIndex = 2;
            this.portTxtBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.portTxtBox_KeyPress);
            // 
            // gamePortTxtBox
            // 
            this.gamePortTxtBox.Location = new System.Drawing.Point(189, 70);
            this.gamePortTxtBox.Name = "gamePortTxtBox";
            this.gamePortTxtBox.Size = new System.Drawing.Size(55, 20);
            this.gamePortTxtBox.TabIndex = 4;
            this.gamePortTxtBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.gamePortTxtBox_KeyPress);
            // 
            // saveBtn
            // 
            this.saveBtn.Location = new System.Drawing.Point(7, 679);
            this.saveBtn.Name = "saveBtn";
            this.saveBtn.Size = new System.Drawing.Size(94, 32);
            this.saveBtn.TabIndex = 9;
            this.saveBtn.Text = "Save";
            this.saveBtn.UseVisualStyleBackColor = true;
            this.saveBtn.Click += new System.EventHandler(this.createBtn_Click);
            // 
            // ipTxtBox
            // 
            this.ipTxtBox.Location = new System.Drawing.Point(46, 38);
            this.ipTxtBox.Name = "ipTxtBox";
            this.ipTxtBox.Size = new System.Drawing.Size(133, 20);
            this.ipTxtBox.TabIndex = 13;
            // 
            // cancelBtn
            // 
            this.cancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelBtn.Location = new System.Drawing.Point(107, 679);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(96, 32);
            this.cancelBtn.TabIndex = 10;
            this.cancelBtn.Text = "Cancel";
            this.cancelBtn.UseVisualStyleBackColor = true;
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(119, 72);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(60, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Game Port:";
            // 
            // homeServerCheckbox
            // 
            this.homeServerCheckbox.AutoSize = true;
            this.homeServerCheckbox.Location = new System.Drawing.Point(19, 650);
            this.homeServerCheckbox.Name = "homeServerCheckbox";
            this.homeServerCheckbox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.homeServerCheckbox.Size = new System.Drawing.Size(88, 17);
            this.homeServerCheckbox.TabIndex = 14;
            this.homeServerCheckbox.Text = "Home Server";
            this.homeServerCheckbox.UseVisualStyleBackColor = true;
            // 
            // runTestsBtn
            // 
            this.runTestsBtn.Location = new System.Drawing.Point(243, 679);
            this.runTestsBtn.Name = "runTestsBtn";
            this.runTestsBtn.Size = new System.Drawing.Size(96, 32);
            this.runTestsBtn.TabIndex = 15;
            this.runTestsBtn.Text = "Launch Preview";
            this.runTestsBtn.UseVisualStyleBackColor = true;
            this.runTestsBtn.Click += new System.EventHandler(this.runTestsBtn_Click);
            // 
            // nameTxtBox
            // 
            this.nameTxtBox.Location = new System.Drawing.Point(46, 12);
            this.nameTxtBox.Name = "nameTxtBox";
            this.nameTxtBox.Size = new System.Drawing.Size(133, 20);
            this.nameTxtBox.TabIndex = 17;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(5, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 13);
            this.label3.TabIndex = 16;
            this.label3.Text = "Name:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 115);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(150, 13);
            this.label4.TabIndex = 19;
            this.label4.Text = "OceanFloorZDistFromSurface:";
            // 
            // FloorZDist
            // 
            this.FloorZDist.Location = new System.Drawing.Point(164, 112);
            this.FloorZDist.Name = "FloorZDist";
            this.FloorZDist.Size = new System.Drawing.Size(55, 20);
            this.FloorZDist.TabIndex = 18;
            // 
            // OceanDinoDepthEntriesOverrideLbl
            // 
            this.OceanDinoDepthEntriesOverrideLbl.AutoSize = true;
            this.OceanDinoDepthEntriesOverrideLbl.Location = new System.Drawing.Point(364, 141);
            this.OceanDinoDepthEntriesOverrideLbl.Name = "OceanDinoDepthEntriesOverrideLbl";
            this.OceanDinoDepthEntriesOverrideLbl.Size = new System.Drawing.Size(165, 13);
            this.OceanDinoDepthEntriesOverrideLbl.TabIndex = 21;
            this.OceanDinoDepthEntriesOverrideLbl.Text = "OceanDinoDepthEntriesOverride:";
            // 
            // OceanDinoDepthEntriesOverrideTxtBox
            // 
            this.OceanDinoDepthEntriesOverrideTxtBox.Location = new System.Drawing.Point(371, 157);
            this.OceanDinoDepthEntriesOverrideTxtBox.Multiline = true;
            this.OceanDinoDepthEntriesOverrideTxtBox.Name = "OceanDinoDepthEntriesOverrideTxtBox";
            this.OceanDinoDepthEntriesOverrideTxtBox.Size = new System.Drawing.Size(285, 83);
            this.OceanDinoDepthEntriesOverrideTxtBox.TabIndex = 20;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(364, 255);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(154, 13);
            this.label6.TabIndex = 23;
            this.label6.Text = "OceanFloatsamCratesOverride:";
            // 
            // OceanFloatsamCratesOverrideTxtBox
            // 
            this.OceanFloatsamCratesOverrideTxtBox.Location = new System.Drawing.Point(367, 272);
            this.OceanFloatsamCratesOverrideTxtBox.Multiline = true;
            this.OceanFloatsamCratesOverrideTxtBox.Name = "OceanFloatsamCratesOverrideTxtBox";
            this.OceanFloatsamCratesOverrideTxtBox.Size = new System.Drawing.Size(289, 90);
            this.OceanFloatsamCratesOverrideTxtBox.TabIndex = 22;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(186, 174);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(63, 13);
            this.label9.TabIndex = 33;
            this.label9.Text = "(ex: -12000)";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(8, 174);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(83, 13);
            this.label8.TabIndex = 32;
            this.label8.Text = "Transition MinZ:";
            // 
            // transitionMinZTxtBox
            // 
            this.transitionMinZTxtBox.Location = new System.Drawing.Point(93, 170);
            this.transitionMinZTxtBox.Name = "transitionMinZTxtBox";
            this.transitionMinZTxtBox.Size = new System.Drawing.Size(86, 20);
            this.transitionMinZTxtBox.TabIndex = 31;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(164, 143);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(60, 13);
            this.label7.TabIndex = 30;
            this.label7.Text = "(in minutes)";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(8, 143);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(63, 13);
            this.label10.TabIndex = 29;
            this.label10.Text = "UTC Offset:";
            // 
            // utcOffsetTxtBox
            // 
            this.utcOffsetTxtBox.Location = new System.Drawing.Point(72, 140);
            this.utcOffsetTxtBox.Name = "utcOffsetTxtBox";
            this.utcOffsetTxtBox.Size = new System.Drawing.Size(86, 20);
            this.utcOffsetTxtBox.TabIndex = 28;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(364, 364);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(166, 13);
            this.label11.TabIndex = 35;
            this.label11.Text = "TreasureMapLootTablesOverride:";
            // 
            // TreasureMapLootTablesOverrideTxtBox
            // 
            this.TreasureMapLootTablesOverrideTxtBox.Location = new System.Drawing.Point(367, 381);
            this.TreasureMapLootTablesOverrideTxtBox.Multiline = true;
            this.TreasureMapLootTablesOverrideTxtBox.Name = "TreasureMapLootTablesOverrideTxtBox";
            this.TreasureMapLootTablesOverrideTxtBox.Size = new System.Drawing.Size(289, 90);
            this.TreasureMapLootTablesOverrideTxtBox.TabIndex = 34;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(7, 94);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(94, 13);
            this.label12.TabIndex = 37;
            this.label12.Text = "SeamlessDataPort";
            // 
            // seamlessDataPortTxt
            // 
            this.seamlessDataPortTxt.Location = new System.Drawing.Point(109, 92);
            this.seamlessDataPortTxt.Name = "seamlessDataPortTxt";
            this.seamlessDataPortTxt.Size = new System.Drawing.Size(55, 20);
            this.seamlessDataPortTxt.TabIndex = 36;
            this.seamlessDataPortTxt.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(364, 13);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(240, 13);
            this.label13.TabIndex = 39;
            this.label13.Text = "GlobalBiomeSeamlessServerGridPreOffsetValues:";
            // 
            // GlobalBiomeSeamlessServerGridPreOffsetValuesTxtBox
            // 
            this.GlobalBiomeSeamlessServerGridPreOffsetValuesTxtBox.Location = new System.Drawing.Point(371, 29);
            this.GlobalBiomeSeamlessServerGridPreOffsetValuesTxtBox.Multiline = true;
            this.GlobalBiomeSeamlessServerGridPreOffsetValuesTxtBox.Name = "GlobalBiomeSeamlessServerGridPreOffsetValuesTxtBox";
            this.GlobalBiomeSeamlessServerGridPreOffsetValuesTxtBox.Size = new System.Drawing.Size(285, 41);
            this.GlobalBiomeSeamlessServerGridPreOffsetValuesTxtBox.TabIndex = 38;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(362, 76);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(301, 13);
            this.label14.TabIndex = 41;
            this.label14.Text = "GlobalBiomeSeamlessServerGridPreOffsetValuesOceanWater:";
            // 
            // GlobalBiomeSeamlessServerGridPreOffsetValuesOceanWaterTxtBox
            // 
            this.GlobalBiomeSeamlessServerGridPreOffsetValuesOceanWaterTxtBox.Location = new System.Drawing.Point(369, 92);
            this.GlobalBiomeSeamlessServerGridPreOffsetValuesOceanWaterTxtBox.Multiline = true;
            this.GlobalBiomeSeamlessServerGridPreOffsetValuesOceanWaterTxtBox.Name = "GlobalBiomeSeamlessServerGridPreOffsetValuesOceanWaterTxtBox";
            this.GlobalBiomeSeamlessServerGridPreOffsetValuesOceanWaterTxtBox.Size = new System.Drawing.Size(287, 41);
            this.GlobalBiomeSeamlessServerGridPreOffsetValuesOceanWaterTxtBox.TabIndex = 40;
            // 
            // editSpawnRegions
            // 
            this.editSpawnRegions.Location = new System.Drawing.Point(225, 641);
            this.editSpawnRegions.Name = "editSpawnRegions";
            this.editSpawnRegions.Size = new System.Drawing.Size(114, 32);
            this.editSpawnRegions.TabIndex = 42;
            this.editSpawnRegions.Text = "Spawn Regions";
            this.editSpawnRegions.UseVisualStyleBackColor = true;
            this.editSpawnRegions.Click += new System.EventHandler(this.editSpawnRegions_Click);
            // 
            // additionalCmdLineParamsTxtBox
            // 
            this.additionalCmdLineParamsTxtBox.Location = new System.Drawing.Point(16, 218);
            this.additionalCmdLineParamsTxtBox.Name = "additionalCmdLineParamsTxtBox";
            this.additionalCmdLineParamsTxtBox.Size = new System.Drawing.Size(281, 20);
            this.additionalCmdLineParamsTxtBox.TabIndex = 44;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(13, 199);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(182, 13);
            this.label15.TabIndex = 43;
            this.label15.Text = "Additional CommandLine Parameters:";
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Location = new System.Drawing.Point(13, 249);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(255, 13);
            this.label29.TabIndex = 68;
            this.label29.Text = "Override ShooterGameMode DefaultGame.ini Values";
            // 
            // overrideShooterGameModeDefaultGameIniDataGridView
            // 
            this.overrideShooterGameModeDefaultGameIniDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.overrideShooterGameModeDefaultGameIniDataGridView.Location = new System.Drawing.Point(18, 270);
            this.overrideShooterGameModeDefaultGameIniDataGridView.Name = "overrideShooterGameModeDefaultGameIniDataGridView";
            this.overrideShooterGameModeDefaultGameIniDataGridView.Size = new System.Drawing.Size(249, 110);
            this.overrideShooterGameModeDefaultGameIniDataGridView.TabIndex = 67;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(364, 479);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(77, 13);
            this.label16.TabIndex = 69;
            this.label16.Text = "ExtraSublevels";
            // 
            // extraSublevelTxtBox
            // 
            this.extraSublevelTxtBox.Location = new System.Drawing.Point(367, 498);
            this.extraSublevelTxtBox.Multiline = true;
            this.extraSublevelTxtBox.Name = "extraSublevelTxtBox";
            this.extraSublevelTxtBox.Size = new System.Drawing.Size(289, 53);
            this.extraSublevelTxtBox.TabIndex = 70;
            // 
            // oceanEpicSpawnEntriesOverrideTemplateNameTxtBox
            // 
            this.oceanEpicSpawnEntriesOverrideTemplateNameTxtBox.Location = new System.Drawing.Point(19, 402);
            this.oceanEpicSpawnEntriesOverrideTemplateNameTxtBox.Name = "oceanEpicSpawnEntriesOverrideTemplateNameTxtBox";
            this.oceanEpicSpawnEntriesOverrideTemplateNameTxtBox.Size = new System.Drawing.Size(281, 20);
            this.oceanEpicSpawnEntriesOverrideTemplateNameTxtBox.TabIndex = 72;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(16, 383);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(240, 13);
            this.label17.TabIndex = 71;
            this.label17.Text = "OceanEpicSpawnEntriesOverrideTemplateName:";
            // 
            // NPCShipSpawnEntriesOverrideTemplateNameTxtBox
            // 
            this.NPCShipSpawnEntriesOverrideTemplateNameTxtBox.Location = new System.Drawing.Point(19, 452);
            this.NPCShipSpawnEntriesOverrideTemplateNameTxtBox.Name = "NPCShipSpawnEntriesOverrideTemplateNameTxtBox";
            this.NPCShipSpawnEntriesOverrideTemplateNameTxtBox.Size = new System.Drawing.Size(281, 20);
            this.NPCShipSpawnEntriesOverrideTemplateNameTxtBox.TabIndex = 74;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(16, 433);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(230, 13);
            this.label18.TabIndex = 73;
            this.label18.Text = "NPCShipSpawnEntriesOverrideTemplateName:";
            // 
            // regionOverridesTxtBox
            // 
            this.regionOverridesTxtBox.Location = new System.Drawing.Point(369, 580);
            this.regionOverridesTxtBox.Multiline = true;
            this.regionOverridesTxtBox.Name = "regionOverridesTxtBox";
            this.regionOverridesTxtBox.Size = new System.Drawing.Size(289, 86);
            this.regionOverridesTxtBox.TabIndex = 76;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(366, 564);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(86, 13);
            this.label19.TabIndex = 75;
            this.label19.Text = "RegionOverrides";
            // 
            // coordsLbl
            // 
            this.coordsLbl.AutoSize = true;
            this.coordsLbl.Location = new System.Drawing.Point(189, 42);
            this.coordsLbl.Name = "coordsLbl";
            this.coordsLbl.Size = new System.Drawing.Size(64, 13);
            this.coordsLbl.TabIndex = 77;
            this.coordsLbl.Text = "Coords (0,0)";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(221, 486);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(75, 13);
            this.label20.TabIndex = 79;
            this.label20.Text = "skyStyleIndex:";
            // 
            // skyStyleIndexTxtBox
            // 
            this.skyStyleIndexTxtBox.Location = new System.Drawing.Point(299, 483);
            this.skyStyleIndexTxtBox.Name = "skyStyleIndexTxtBox";
            this.skyStyleIndexTxtBox.Size = new System.Drawing.Size(55, 20);
            this.skyStyleIndexTxtBox.TabIndex = 78;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(7, 486);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(60, 13);
            this.label21.TabIndex = 80;
            this.label21.Text = "waterColor:";
            // 
            // waterColorRTxtBox
            // 
            this.waterColorRTxtBox.Location = new System.Drawing.Point(71, 480);
            this.waterColorRTxtBox.Name = "waterColorRTxtBox";
            this.waterColorRTxtBox.Size = new System.Drawing.Size(42, 20);
            this.waterColorRTxtBox.TabIndex = 81;
            // 
            // waterColorGTxtBox
            // 
            this.waterColorGTxtBox.Location = new System.Drawing.Point(119, 480);
            this.waterColorGTxtBox.Name = "waterColorGTxtBox";
            this.waterColorGTxtBox.Size = new System.Drawing.Size(42, 20);
            this.waterColorGTxtBox.TabIndex = 82;
            // 
            // waterColorBTxtBox
            // 
            this.waterColorBTxtBox.Location = new System.Drawing.Point(167, 480);
            this.waterColorBTxtBox.Name = "waterColorBTxtBox";
            this.waterColorBTxtBox.Size = new System.Drawing.Size(42, 20);
            this.waterColorBTxtBox.TabIndex = 83;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(83, 502);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(15, 13);
            this.label22.TabIndex = 84;
            this.label22.Text = "R";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(132, 502);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(15, 13);
            this.label23.TabIndex = 85;
            this.label23.Text = "G";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(180, 501);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(14, 13);
            this.label24.TabIndex = 86;
            this.label24.Text = "B";
            // 
            // ServerCustomDatas1TxtBox
            // 
            this.ServerCustomDatas1TxtBox.Location = new System.Drawing.Point(122, 531);
            this.ServerCustomDatas1TxtBox.Name = "ServerCustomDatas1TxtBox";
            this.ServerCustomDatas1TxtBox.Size = new System.Drawing.Size(230, 20);
            this.ServerCustomDatas1TxtBox.TabIndex = 88;
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(13, 534);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(110, 13);
            this.label25.TabIndex = 87;
            this.label25.Text = "ServerCustomDatas1:";
            // 
            // ServerCustomDatas2TxtBox
            // 
            this.ServerCustomDatas2TxtBox.Location = new System.Drawing.Point(122, 554);
            this.ServerCustomDatas2TxtBox.Name = "ServerCustomDatas2TxtBox";
            this.ServerCustomDatas2TxtBox.Size = new System.Drawing.Size(230, 20);
            this.ServerCustomDatas2TxtBox.TabIndex = 90;
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(13, 557);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(110, 13);
            this.label26.TabIndex = 89;
            this.label26.Text = "ServerCustomDatas2:";
            // 
            // ClientCustomDatas2TxtBox
            // 
            this.ClientCustomDatas2TxtBox.Location = new System.Drawing.Point(122, 603);
            this.ClientCustomDatas2TxtBox.Name = "ClientCustomDatas2TxtBox";
            this.ClientCustomDatas2TxtBox.Size = new System.Drawing.Size(230, 20);
            this.ClientCustomDatas2TxtBox.TabIndex = 94;
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(13, 606);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(105, 13);
            this.label27.TabIndex = 93;
            this.label27.Text = "ClientCustomDatas2:";
            // 
            // ClientCustomDatas1TxtBox
            // 
            this.ClientCustomDatas1TxtBox.Location = new System.Drawing.Point(122, 580);
            this.ClientCustomDatas1TxtBox.Name = "ClientCustomDatas1TxtBox";
            this.ClientCustomDatas1TxtBox.Size = new System.Drawing.Size(230, 20);
            this.ClientCustomDatas1TxtBox.TabIndex = 92;
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Location = new System.Drawing.Point(13, 583);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(105, 13);
            this.label28.TabIndex = 91;
            this.label28.Text = "ClientCustomDatas1:";
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Location = new System.Drawing.Point(189, 15);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(54, 13);
            this.label30.TabIndex = 95;
            this.label30.Text = "Template:";
            // 
            // templateComboBox
            // 
            this.templateComboBox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.templateComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.templateComboBox.FormattingEnabled = true;
            this.templateComboBox.Location = new System.Drawing.Point(243, 12);
            this.templateComboBox.Name = "templateComboBox";
            this.templateComboBox.Size = new System.Drawing.Size(96, 21);
            this.templateComboBox.TabIndex = 96;
            this.templateComboBox.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.templateComboBox_DrawItem);
            // 
            // OceanEpicSpawnEntriesOverrideValuesTxtBox
            // 
            this.OceanEpicSpawnEntriesOverrideValuesTxtBox.Location = new System.Drawing.Point(369, 695);
            this.OceanEpicSpawnEntriesOverrideValuesTxtBox.Multiline = true;
            this.OceanEpicSpawnEntriesOverrideValuesTxtBox.Name = "OceanEpicSpawnEntriesOverrideValuesTxtBox";
            this.OceanEpicSpawnEntriesOverrideValuesTxtBox.Size = new System.Drawing.Size(289, 53);
            this.OceanEpicSpawnEntriesOverrideValuesTxtBox.TabIndex = 98;
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Location = new System.Drawing.Point(366, 676);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(197, 13);
            this.label31.TabIndex = 97;
            this.label31.Text = "OceanEpicSpawnEntriesOverrideValues";
            // 
            // EditServerForm
            // 
            this.AcceptButton = this.saveBtn;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelBtn;
            this.ClientSize = new System.Drawing.Size(667, 762);
            this.Controls.Add(this.OceanEpicSpawnEntriesOverrideValuesTxtBox);
            this.Controls.Add(this.label31);
            this.Controls.Add(this.templateComboBox);
            this.Controls.Add(this.label30);
            this.Controls.Add(this.ClientCustomDatas2TxtBox);
            this.Controls.Add(this.label27);
            this.Controls.Add(this.ClientCustomDatas1TxtBox);
            this.Controls.Add(this.label28);
            this.Controls.Add(this.ServerCustomDatas2TxtBox);
            this.Controls.Add(this.label26);
            this.Controls.Add(this.ServerCustomDatas1TxtBox);
            this.Controls.Add(this.label25);
            this.Controls.Add(this.label24);
            this.Controls.Add(this.label23);
            this.Controls.Add(this.label22);
            this.Controls.Add(this.waterColorBTxtBox);
            this.Controls.Add(this.waterColorGTxtBox);
            this.Controls.Add(this.waterColorRTxtBox);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.skyStyleIndexTxtBox);
            this.Controls.Add(this.coordsLbl);
            this.Controls.Add(this.regionOverridesTxtBox);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.NPCShipSpawnEntriesOverrideTemplateNameTxtBox);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.oceanEpicSpawnEntriesOverrideTemplateNameTxtBox);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.extraSublevelTxtBox);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label29);
            this.Controls.Add(this.overrideShooterGameModeDefaultGameIniDataGridView);
            this.Controls.Add(this.additionalCmdLineParamsTxtBox);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.editSpawnRegions);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.GlobalBiomeSeamlessServerGridPreOffsetValuesOceanWaterTxtBox);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.GlobalBiomeSeamlessServerGridPreOffsetValuesTxtBox);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.seamlessDataPortTxt);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.TreasureMapLootTablesOverrideTxtBox);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.transitionMinZTxtBox);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.utcOffsetTxtBox);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.OceanFloatsamCratesOverrideTxtBox);
            this.Controls.Add(this.OceanDinoDepthEntriesOverrideLbl);
            this.Controls.Add(this.OceanDinoDepthEntriesOverrideTxtBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.FloorZDist);
            this.Controls.Add(this.nameTxtBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.runTestsBtn);
            this.Controls.Add(this.homeServerCheckbox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.ipTxtBox);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.saveBtn);
            this.Controls.Add(this.gamePortTxtBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.portTxtBox);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EditServerForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Edit Server";
            this.Load += new System.EventHandler(this.EditServerForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.overrideShooterGameModeDefaultGameIniDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox portTxtBox;
        private System.Windows.Forms.TextBox gamePortTxtBox;
        private System.Windows.Forms.Button saveBtn;
        private System.Windows.Forms.TextBox ipTxtBox;
        private System.Windows.Forms.Button cancelBtn;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox homeServerCheckbox;
        private System.Windows.Forms.Button runTestsBtn;
        private System.Windows.Forms.TextBox nameTxtBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox FloorZDist;
        private System.Windows.Forms.Label OceanDinoDepthEntriesOverrideLbl;
        private System.Windows.Forms.TextBox OceanDinoDepthEntriesOverrideTxtBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox OceanFloatsamCratesOverrideTxtBox;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox transitionMinZTxtBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox utcOffsetTxtBox;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox TreasureMapLootTablesOverrideTxtBox;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox seamlessDataPortTxt;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox GlobalBiomeSeamlessServerGridPreOffsetValuesTxtBox;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox GlobalBiomeSeamlessServerGridPreOffsetValuesOceanWaterTxtBox;
        private System.Windows.Forms.Button editSpawnRegions;
        private System.Windows.Forms.TextBox additionalCmdLineParamsTxtBox;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.DataGridView overrideShooterGameModeDefaultGameIniDataGridView;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox extraSublevelTxtBox;
        private System.Windows.Forms.TextBox oceanEpicSpawnEntriesOverrideTemplateNameTxtBox;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox NPCShipSpawnEntriesOverrideTemplateNameTxtBox;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox regionOverridesTxtBox;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label coordsLbl;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.TextBox skyStyleIndexTxtBox;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.TextBox waterColorRTxtBox;
        private System.Windows.Forms.TextBox waterColorGTxtBox;
        private System.Windows.Forms.TextBox waterColorBTxtBox;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.TextBox ServerCustomDatas1TxtBox;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.TextBox ServerCustomDatas2TxtBox;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.TextBox ClientCustomDatas2TxtBox;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.TextBox ClientCustomDatas1TxtBox;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.ComboBox templateComboBox;
        private System.Windows.Forms.TextBox OceanEpicSpawnEntriesOverrideValuesTxtBox;
        private System.Windows.Forms.Label label31;
    }
}