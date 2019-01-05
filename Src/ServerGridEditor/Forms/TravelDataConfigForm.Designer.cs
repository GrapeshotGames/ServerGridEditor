namespace ServerGridEditor
{
    partial class TravelDataConfigForm
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
            this.cancelBtn = new System.Windows.Forms.Button();
            this.saveBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.backupModeCombo = new System.Windows.Forms.ComboBox();
            this.httpBackupURLTxtBox = new System.Windows.Forms.TextBox();
            this.httpApiKeyTxtBox = new System.Windows.Forms.TextBox();
            this.s3KeyPrefixTxtBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // cancelBtn
            // 
            this.cancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelBtn.Location = new System.Drawing.Point(274, 249);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(90, 32);
            this.cancelBtn.TabIndex = 11;
            this.cancelBtn.Text = "Cancel";
            this.cancelBtn.UseVisualStyleBackColor = true;
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // saveBtn
            // 
            this.saveBtn.Location = new System.Drawing.Point(165, 249);
            this.saveBtn.Name = "saveBtn";
            this.saveBtn.Size = new System.Drawing.Size(90, 32);
            this.saveBtn.TabIndex = 64;
            this.saveBtn.Text = "Save";
            this.saveBtn.UseVisualStyleBackColor = true;
            this.saveBtn.Click += new System.EventHandler(this.saveBtn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(65, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 13);
            this.label1.TabIndex = 65;
            this.label1.Text = "Backup Mode";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Enabled = false;
            this.label3.Location = new System.Drawing.Point(38, 158);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(101, 13);
            this.label3.TabIndex = 67;
            this.label3.Text = "HTTP Backup URL";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Enabled = false;
            this.label4.Location = new System.Drawing.Point(62, 184);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 13);
            this.label4.TabIndex = 68;
            this.label4.Text = "HTTP API Key";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(69, 102);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(70, 13);
            this.label9.TabIndex = 73;
            this.label9.Text = "S3 Key Prefix";
            // 
            // backupModeCombo
            // 
            this.backupModeCombo.FormattingEnabled = true;
            this.backupModeCombo.Items.AddRange(new object[] {
            "off",
            "s3",
            "http"});
            this.backupModeCombo.Location = new System.Drawing.Point(145, 49);
            this.backupModeCombo.Name = "backupModeCombo";
            this.backupModeCombo.Size = new System.Drawing.Size(121, 21);
            this.backupModeCombo.TabIndex = 74;
            // 
            // httpBackupURLTxtBox
            // 
            this.httpBackupURLTxtBox.Enabled = false;
            this.httpBackupURLTxtBox.Location = new System.Drawing.Point(145, 154);
            this.httpBackupURLTxtBox.Name = "httpBackupURLTxtBox";
            this.httpBackupURLTxtBox.Size = new System.Drawing.Size(286, 20);
            this.httpBackupURLTxtBox.TabIndex = 76;
            // 
            // httpApiKeyTxtBox
            // 
            this.httpApiKeyTxtBox.Enabled = false;
            this.httpApiKeyTxtBox.Location = new System.Drawing.Point(145, 180);
            this.httpApiKeyTxtBox.Name = "httpApiKeyTxtBox";
            this.httpApiKeyTxtBox.Size = new System.Drawing.Size(286, 20);
            this.httpApiKeyTxtBox.TabIndex = 77;
            // 
            // s3KeyPrefixTxtBox
            // 
            this.s3KeyPrefixTxtBox.Location = new System.Drawing.Point(145, 99);
            this.s3KeyPrefixTxtBox.Name = "s3KeyPrefixTxtBox";
            this.s3KeyPrefixTxtBox.Size = new System.Drawing.Size(286, 20);
            this.s3KeyPrefixTxtBox.TabIndex = 82;
            // 
            // TravelDataConfigForm
            // 
            this.AcceptButton = this.saveBtn;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelBtn;
            this.ClientSize = new System.Drawing.Size(502, 304);
            this.Controls.Add(this.s3KeyPrefixTxtBox);
            this.Controls.Add(this.httpApiKeyTxtBox);
            this.Controls.Add(this.httpBackupURLTxtBox);
            this.Controls.Add(this.backupModeCombo);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.saveBtn);
            this.Controls.Add(this.cancelBtn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TravelDataConfigForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Travel Data Config";
            this.Load += new System.EventHandler(this.TravelDataConfigForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cancelBtn;
        private System.Windows.Forms.Button saveBtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox backupModeCombo;
        private System.Windows.Forms.TextBox httpBackupURLTxtBox;
        private System.Windows.Forms.TextBox httpApiKeyTxtBox;
        private System.Windows.Forms.TextBox s3KeyPrefixTxtBox;
    }
}