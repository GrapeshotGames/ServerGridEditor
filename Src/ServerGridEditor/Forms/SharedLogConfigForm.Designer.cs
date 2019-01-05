namespace ServerGridEditor
{
    partial class SharedLogConfigForm
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
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.backupModeCombo = new System.Windows.Forms.ComboBox();
            this.maxFileHistoryTxtBox = new System.Windows.Forms.TextBox();
            this.httpBackupURLTxtBox = new System.Windows.Forms.TextBox();
            this.httpApiKeyTxtBox = new System.Windows.Forms.TextBox();
            this.s3KeyPrefixTxtBox = new System.Windows.Forms.TextBox();
            this.fetchRateSecTxtBox = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.snapCleanSecTxtBox = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.snapRateSecTxtBox = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.snapExpHoursTxtBox = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cancelBtn
            // 
            this.cancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelBtn.Location = new System.Drawing.Point(274, 362);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(90, 32);
            this.cancelBtn.TabIndex = 11;
            this.cancelBtn.Text = "Cancel";
            this.cancelBtn.UseVisualStyleBackColor = true;
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // saveBtn
            // 
            this.saveBtn.Location = new System.Drawing.Point(165, 362);
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
            this.label1.Location = new System.Drawing.Point(65, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 13);
            this.label1.TabIndex = 65;
            this.label1.Text = "Backup Mode";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(64, 83);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 13);
            this.label2.TabIndex = 66;
            this.label2.Text = "MaxFileHistory";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(38, 287);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(101, 13);
            this.label3.TabIndex = 67;
            this.label3.Text = "HTTP Backup URL";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(62, 313);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 13);
            this.label4.TabIndex = 68;
            this.label4.Text = "HTTP API Key";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(69, 245);
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
            this.backupModeCombo.Location = new System.Drawing.Point(145, 37);
            this.backupModeCombo.Name = "backupModeCombo";
            this.backupModeCombo.Size = new System.Drawing.Size(121, 21);
            this.backupModeCombo.TabIndex = 74;
            // 
            // maxFileHistoryTxtBox
            // 
            this.maxFileHistoryTxtBox.Location = new System.Drawing.Point(145, 80);
            this.maxFileHistoryTxtBox.Name = "maxFileHistoryTxtBox";
            this.maxFileHistoryTxtBox.Size = new System.Drawing.Size(62, 20);
            this.maxFileHistoryTxtBox.TabIndex = 75;
            // 
            // httpBackupURLTxtBox
            // 
            this.httpBackupURLTxtBox.Location = new System.Drawing.Point(145, 283);
            this.httpBackupURLTxtBox.Name = "httpBackupURLTxtBox";
            this.httpBackupURLTxtBox.Size = new System.Drawing.Size(286, 20);
            this.httpBackupURLTxtBox.TabIndex = 76;
            // 
            // httpApiKeyTxtBox
            // 
            this.httpApiKeyTxtBox.Location = new System.Drawing.Point(145, 309);
            this.httpApiKeyTxtBox.Name = "httpApiKeyTxtBox";
            this.httpApiKeyTxtBox.Size = new System.Drawing.Size(286, 20);
            this.httpApiKeyTxtBox.TabIndex = 77;
            // 
            // s3KeyPrefixTxtBox
            // 
            this.s3KeyPrefixTxtBox.Location = new System.Drawing.Point(145, 242);
            this.s3KeyPrefixTxtBox.Name = "s3KeyPrefixTxtBox";
            this.s3KeyPrefixTxtBox.Size = new System.Drawing.Size(286, 20);
            this.s3KeyPrefixTxtBox.TabIndex = 82;
            // 
            // fetchRateSecTxtBox
            // 
            this.fetchRateSecTxtBox.Location = new System.Drawing.Point(145, 122);
            this.fetchRateSecTxtBox.Name = "fetchRateSecTxtBox";
            this.fetchRateSecTxtBox.Size = new System.Drawing.Size(62, 20);
            this.fetchRateSecTxtBox.TabIndex = 84;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(57, 125);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(82, 13);
            this.label10.TabIndex = 83;
            this.label10.Text = "Fetch Rate Sec";
            // 
            // snapCleanSecTxtBox
            // 
            this.snapCleanSecTxtBox.Location = new System.Drawing.Point(145, 148);
            this.snapCleanSecTxtBox.Name = "snapCleanSecTxtBox";
            this.snapCleanSecTxtBox.Size = new System.Drawing.Size(62, 20);
            this.snapCleanSecTxtBox.TabIndex = 86;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(23, 151);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(116, 13);
            this.label11.TabIndex = 85;
            this.label11.Text = "Snapshot Cleanup Sec";
            // 
            // snapRateSecTxtBox
            // 
            this.snapRateSecTxtBox.Location = new System.Drawing.Point(145, 174);
            this.snapRateSecTxtBox.Name = "snapRateSecTxtBox";
            this.snapRateSecTxtBox.Size = new System.Drawing.Size(62, 20);
            this.snapRateSecTxtBox.TabIndex = 88;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(38, 177);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(100, 13);
            this.label12.TabIndex = 87;
            this.label12.Text = "Snapshot Rate Sec";
            // 
            // snapExpHoursTxtBox
            // 
            this.snapExpHoursTxtBox.Location = new System.Drawing.Point(145, 200);
            this.snapExpHoursTxtBox.Name = "snapExpHoursTxtBox";
            this.snapExpHoursTxtBox.Size = new System.Drawing.Size(62, 20);
            this.snapExpHoursTxtBox.TabIndex = 90;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(3, 203);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(135, 13);
            this.label13.TabIndex = 89;
            this.label13.Text = "Snapshot Expiration Hours ";
            // 
            // SharedLogConfigForm
            // 
            this.AcceptButton = this.saveBtn;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelBtn;
            this.ClientSize = new System.Drawing.Size(472, 417);
            this.Controls.Add(this.snapExpHoursTxtBox);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.snapRateSecTxtBox);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.snapCleanSecTxtBox);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.fetchRateSecTxtBox);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.s3KeyPrefixTxtBox);
            this.Controls.Add(this.httpApiKeyTxtBox);
            this.Controls.Add(this.httpBackupURLTxtBox);
            this.Controls.Add(this.maxFileHistoryTxtBox);
            this.Controls.Add(this.backupModeCombo);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.saveBtn);
            this.Controls.Add(this.cancelBtn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SharedLogConfigForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Shared Log Config";
            this.Load += new System.EventHandler(this.SharedLogConfigForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cancelBtn;
        private System.Windows.Forms.Button saveBtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox backupModeCombo;
        private System.Windows.Forms.TextBox maxFileHistoryTxtBox;
        private System.Windows.Forms.TextBox httpBackupURLTxtBox;
        private System.Windows.Forms.TextBox httpApiKeyTxtBox;
        private System.Windows.Forms.TextBox s3KeyPrefixTxtBox;
        private System.Windows.Forms.TextBox fetchRateSecTxtBox;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox snapCleanSecTxtBox;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox snapRateSecTxtBox;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox snapExpHoursTxtBox;
        private System.Windows.Forms.Label label13;
    }
}