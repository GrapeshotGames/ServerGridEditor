namespace ServerGridEditor.Forms
{
    partial class EditSpawnRegions
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
            this.spawnRegionsGrid = new System.Windows.Forms.DataGridView();
            this.regionName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.regionParent = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cancelBtn = new System.Windows.Forms.Button();
            this.saveBtn = new System.Windows.Forms.Button();
            this.messageLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.spawnRegionsGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // spawnRegionsGrid
            // 
            this.spawnRegionsGrid.AllowUserToOrderColumns = true;
            this.spawnRegionsGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.spawnRegionsGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.spawnRegionsGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.regionName,
            this.regionParent});
            this.spawnRegionsGrid.Location = new System.Drawing.Point(12, 29);
            this.spawnRegionsGrid.Name = "spawnRegionsGrid";
            this.spawnRegionsGrid.Size = new System.Drawing.Size(350, 332);
            this.spawnRegionsGrid.TabIndex = 6;
            // 
            // cancelBtn
            // 
            this.cancelBtn.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.cancelBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.cancelBtn.Location = new System.Drawing.Point(189, 372);
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
            this.saveBtn.Location = new System.Drawing.Point(53, 372);
            this.saveBtn.Name = "saveBtn";
            this.saveBtn.Size = new System.Drawing.Size(130, 35);
            this.saveBtn.TabIndex = 7;
            this.saveBtn.Text = "Save";
            this.saveBtn.UseVisualStyleBackColor = true;
            this.saveBtn.Click += new System.EventHandler(this.saveBtn_Click);
            // 
            // regionName
            // 
            this.regionName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.regionName.HeaderText = "Name";
            this.regionName.Name = "regionName";
            // 
            // regionParent
            // 
            this.regionParent.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.regionParent.HeaderText = "Parent Cell";
            this.regionParent.Name = "regionParent";
            // 
            // messageLabel
            // 
            this.messageLabel.AutoSize = true;
            this.messageLabel.Location = new System.Drawing.Point(32, 9);
            this.messageLabel.Name = "messageLabel";
            this.messageLabel.Size = new System.Drawing.Size(321, 13);
            this.messageLabel.TabIndex = 24;
            this.messageLabel.Text = "Rows with empty Parent Cell  fields will automatically be set to cell: ";
            // 
            // EditSpawnRegions
            // 
            this.AcceptButton = this.saveBtn;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelBtn;
            this.ClientSize = new System.Drawing.Size(374, 419);
            this.Controls.Add(this.messageLabel);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.saveBtn);
            this.Controls.Add(this.spawnRegionsGrid);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EditSpawnRegions";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Edit Spawn Regions";
            ((System.ComponentModel.ISupportInitialize)(this.spawnRegionsGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView spawnRegionsGrid;
        private System.Windows.Forms.Button cancelBtn;
        private System.Windows.Forms.Button saveBtn;
        private System.Windows.Forms.DataGridViewTextBoxColumn regionName;
        private System.Windows.Forms.DataGridViewTextBoxColumn regionParent;
        private System.Windows.Forms.Label messageLabel;
    }
}