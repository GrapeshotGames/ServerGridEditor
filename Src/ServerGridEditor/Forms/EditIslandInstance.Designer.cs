namespace ServerGridEditor.Forms
{
    partial class EditIslandInstance
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
            this.spawnerOverridesGrid = new System.Windows.Forms.DataGridView();
            this.SpawnerName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SpawnerTemplate = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.saveBtn = new System.Windows.Forms.Button();
            this.cancelBtn = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.spawnPointRegionOverrideTxtBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.IslandInstanceCustomDatas1TxtBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.IslandInstanceCustomDatas2TxtBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.IslandInstanceClientCustomDatas1TxtBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.IslandInstanceClientCustomDatas2TxtBox = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.finalNPCLevelMultiplierTxtBox = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.finalNPCLevelOffsetTxtBox = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.instanceTreasureQualityMultiplierTxtBox = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.instanceTreasureQualityAdditionTxtBox = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.spawnerOverridesGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // spawnerOverridesGrid
            // 
            this.spawnerOverridesGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.spawnerOverridesGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.SpawnerName,
            this.SpawnerTemplate});
            this.spawnerOverridesGrid.Location = new System.Drawing.Point(17, 358);
            this.spawnerOverridesGrid.Name = "spawnerOverridesGrid";
            this.spawnerOverridesGrid.Size = new System.Drawing.Size(323, 238);
            this.spawnerOverridesGrid.TabIndex = 0;
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
            // label1
            // 
            this.label1.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(17, 335);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(143, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Spawner Overrides";
            // 
            // saveBtn
            // 
            this.saveBtn.Location = new System.Drawing.Point(79, 612);
            this.saveBtn.Name = "saveBtn";
            this.saveBtn.Size = new System.Drawing.Size(92, 32);
            this.saveBtn.TabIndex = 2;
            this.saveBtn.Text = "Save";
            this.saveBtn.UseVisualStyleBackColor = true;
            this.saveBtn.Click += new System.EventHandler(this.saveBtn_Click);
            // 
            // cancelBtn
            // 
            this.cancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelBtn.Location = new System.Drawing.Point(192, 612);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(92, 32);
            this.cancelBtn.TabIndex = 3;
            this.cancelBtn.Text = "Cancel";
            this.cancelBtn.UseVisualStyleBackColor = true;
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(93, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(139, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "spawnPointRegionOverride:";
            // 
            // spawnPointRegionOverrideTxtBox
            // 
            this.spawnPointRegionOverrideTxtBox.Location = new System.Drawing.Point(240, 22);
            this.spawnPointRegionOverrideTxtBox.Name = "spawnPointRegionOverrideTxtBox";
            this.spawnPointRegionOverrideTxtBox.Size = new System.Drawing.Size(55, 20);
            this.spawnPointRegionOverrideTxtBox.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 168);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(148, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "IslandInstanceCustomDatas1:";
            // 
            // IslandInstanceCustomDatas1TxtBox
            // 
            this.IslandInstanceCustomDatas1TxtBox.Location = new System.Drawing.Point(15, 184);
            this.IslandInstanceCustomDatas1TxtBox.Name = "IslandInstanceCustomDatas1TxtBox";
            this.IslandInstanceCustomDatas1TxtBox.Size = new System.Drawing.Size(325, 20);
            this.IslandInstanceCustomDatas1TxtBox.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 205);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(148, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "IslandInstanceCustomDatas2:";
            // 
            // IslandInstanceCustomDatas2TxtBox
            // 
            this.IslandInstanceCustomDatas2TxtBox.Location = new System.Drawing.Point(15, 221);
            this.IslandInstanceCustomDatas2TxtBox.Name = "IslandInstanceCustomDatas2TxtBox";
            this.IslandInstanceCustomDatas2TxtBox.Size = new System.Drawing.Size(325, 20);
            this.IslandInstanceCustomDatas2TxtBox.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 254);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(174, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "IslandInstanceClientCustomDatas1:";
            // 
            // IslandInstanceClientCustomDatas1TxtBox
            // 
            this.IslandInstanceClientCustomDatas1TxtBox.Location = new System.Drawing.Point(15, 270);
            this.IslandInstanceClientCustomDatas1TxtBox.Name = "IslandInstanceClientCustomDatas1TxtBox";
            this.IslandInstanceClientCustomDatas1TxtBox.Size = new System.Drawing.Size(325, 20);
            this.IslandInstanceClientCustomDatas1TxtBox.TabIndex = 10;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 292);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(174, 13);
            this.label6.TabIndex = 13;
            this.label6.Text = "IslandInstanceClientCustomDatas2:";
            // 
            // IslandInstanceClientCustomDatas2TxtBox
            // 
            this.IslandInstanceClientCustomDatas2TxtBox.Location = new System.Drawing.Point(15, 308);
            this.IslandInstanceClientCustomDatas2TxtBox.Name = "IslandInstanceClientCustomDatas2TxtBox";
            this.IslandInstanceClientCustomDatas2TxtBox.Size = new System.Drawing.Size(325, 20);
            this.IslandInstanceClientCustomDatas2TxtBox.TabIndex = 12;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(114, 51);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(118, 13);
            this.label7.TabIndex = 15;
            this.label7.Text = "finalNPCLevelMultiplier:";
            // 
            // finalNPCLevelMultiplierTxtBox
            // 
            this.finalNPCLevelMultiplierTxtBox.Location = new System.Drawing.Point(240, 48);
            this.finalNPCLevelMultiplierTxtBox.Name = "finalNPCLevelMultiplierTxtBox";
            this.finalNPCLevelMultiplierTxtBox.Size = new System.Drawing.Size(55, 20);
            this.finalNPCLevelMultiplierTxtBox.TabIndex = 14;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(127, 77);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(105, 13);
            this.label8.TabIndex = 17;
            this.label8.Text = "finalNPCLevelOffset:";
            // 
            // finalNPCLevelOffsetTxtBox
            // 
            this.finalNPCLevelOffsetTxtBox.Location = new System.Drawing.Point(240, 74);
            this.finalNPCLevelOffsetTxtBox.Name = "finalNPCLevelOffsetTxtBox";
            this.finalNPCLevelOffsetTxtBox.Size = new System.Drawing.Size(55, 20);
            this.finalNPCLevelOffsetTxtBox.TabIndex = 16;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(67, 103);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(165, 13);
            this.label9.TabIndex = 19;
            this.label9.Text = "instanceTreasureQualityMultiplier:";
            // 
            // instanceTreasureQualityMultiplierTxtBox
            // 
            this.instanceTreasureQualityMultiplierTxtBox.Location = new System.Drawing.Point(240, 100);
            this.instanceTreasureQualityMultiplierTxtBox.Name = "instanceTreasureQualityMultiplierTxtBox";
            this.instanceTreasureQualityMultiplierTxtBox.Size = new System.Drawing.Size(55, 20);
            this.instanceTreasureQualityMultiplierTxtBox.TabIndex = 18;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(70, 129);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(162, 13);
            this.label10.TabIndex = 21;
            this.label10.Text = "instanceTreasureQualityAddition:";
            // 
            // instanceTreasureQualityAdditionTxtBox
            // 
            this.instanceTreasureQualityAdditionTxtBox.Location = new System.Drawing.Point(240, 126);
            this.instanceTreasureQualityAdditionTxtBox.Name = "instanceTreasureQualityAdditionTxtBox";
            this.instanceTreasureQualityAdditionTxtBox.Size = new System.Drawing.Size(55, 20);
            this.instanceTreasureQualityAdditionTxtBox.TabIndex = 20;
            // 
            // EditIslandInstance
            // 
            this.AcceptButton = this.saveBtn;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelBtn;
            this.ClientSize = new System.Drawing.Size(347, 660);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.instanceTreasureQualityAdditionTxtBox);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.instanceTreasureQualityMultiplierTxtBox);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.finalNPCLevelOffsetTxtBox);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.finalNPCLevelMultiplierTxtBox);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.IslandInstanceClientCustomDatas2TxtBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.IslandInstanceClientCustomDatas1TxtBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.IslandInstanceCustomDatas2TxtBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.IslandInstanceCustomDatas1TxtBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.spawnPointRegionOverrideTxtBox);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.saveBtn);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.spawnerOverridesGrid);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EditIslandInstance";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Edit Island Instance";
            this.TopMost = true;
            ((System.ComponentModel.ISupportInitialize)(this.spawnerOverridesGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView spawnerOverridesGrid;
        private System.Windows.Forms.DataGridViewTextBoxColumn SpawnerName;
        private System.Windows.Forms.DataGridViewComboBoxColumn SpawnerTemplate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button saveBtn;
        private System.Windows.Forms.Button cancelBtn;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox spawnPointRegionOverrideTxtBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox IslandInstanceCustomDatas1TxtBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox IslandInstanceCustomDatas2TxtBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox IslandInstanceClientCustomDatas1TxtBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox IslandInstanceClientCustomDatas2TxtBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox finalNPCLevelMultiplierTxtBox;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox finalNPCLevelOffsetTxtBox;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox instanceTreasureQualityMultiplierTxtBox;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox instanceTreasureQualityAdditionTxtBox;
    }
}