namespace ServerGridEditor.Forms
{
    partial class EditFoliageAttachmentOverride
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
            this.harvestOverridesGrid = new System.Windows.Forms.DataGridView();
            this.cancelBtn = new System.Windows.Forms.Button();
            this.saveBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.ServerConfigurationComboBox = new System.Windows.Forms.ComboBox();
            this.FoliageTypeName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.regionParent = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.harvestOverridesGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // harvestOverridesGrid
            // 
            this.harvestOverridesGrid.AllowUserToOrderColumns = true;
            this.harvestOverridesGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.harvestOverridesGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.harvestOverridesGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.FoliageTypeName,
            this.regionParent});
            this.harvestOverridesGrid.Location = new System.Drawing.Point(12, 68);
            this.harvestOverridesGrid.Name = "harvestOverridesGrid";
            this.harvestOverridesGrid.Size = new System.Drawing.Size(1152, 498);
            this.harvestOverridesGrid.TabIndex = 6;
            // 
            // cancelBtn
            // 
            this.cancelBtn.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.cancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.cancelBtn.Location = new System.Drawing.Point(590, 607);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(130, 35);
            this.cancelBtn.TabIndex = 8;
            this.cancelBtn.Text = "Cancel";
            this.cancelBtn.UseVisualStyleBackColor = true;
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // saveBtn
            // 
            this.saveBtn.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.saveBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.saveBtn.Location = new System.Drawing.Point(454, 607);
            this.saveBtn.Name = "saveBtn";
            this.saveBtn.Size = new System.Drawing.Size(130, 35);
            this.saveBtn.TabIndex = 7;
            this.saveBtn.Text = "Edit";
            this.saveBtn.UseVisualStyleBackColor = true;
            this.saveBtn.Click += new System.EventHandler(this.saveBtn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(72, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 13);
            this.label1.TabIndex = 26;
            this.label1.Text = "Configuration Name";
            // 
            // ServerConfigurationComboBox
            // 
            this.ServerConfigurationComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ServerConfigurationComboBox.FormattingEnabled = true;
            this.ServerConfigurationComboBox.Location = new System.Drawing.Point(189, 31);
            this.ServerConfigurationComboBox.Name = "ServerConfigurationComboBox";
            this.ServerConfigurationComboBox.Size = new System.Drawing.Size(121, 21);
            this.ServerConfigurationComboBox.TabIndex = 30;
            this.ServerConfigurationComboBox.SelectedIndexChanged += new System.EventHandler(this.ServerConfigurationComboBox_SelectedIndexChanged);
            // 
            // FoliageTypeName
            // 
            this.FoliageTypeName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.FoliageTypeName.HeaderText = "Foliage Type Name";
            this.FoliageTypeName.Name = "FoliageTypeName";
            this.FoliageTypeName.Width = 88;
            // 
            // regionParent
            // 
            this.regionParent.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.regionParent.HeaderText = "Override ActorComponent Name";
            this.regionParent.Name = "regionParent";
            // 
            // EditFoliageAttachmentOverride
            // 
            this.AcceptButton = this.saveBtn;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelBtn;
            this.ClientSize = new System.Drawing.Size(1176, 654);
            this.Controls.Add(this.ServerConfigurationComboBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.saveBtn);
            this.Controls.Add(this.harvestOverridesGrid);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EditFoliageAttachmentOverride";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Edit Foliage Overrides";
            ((System.ComponentModel.ISupportInitialize)(this.harvestOverridesGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView harvestOverridesGrid;
        private System.Windows.Forms.Button cancelBtn;
        private System.Windows.Forms.Button saveBtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox ServerConfigurationComboBox;
        private System.Windows.Forms.DataGridViewTextBoxColumn FoliageTypeName;
        private System.Windows.Forms.DataGridViewTextBoxColumn regionParent;
    }
}