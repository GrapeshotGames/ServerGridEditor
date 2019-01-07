namespace ServerGridEditor.Forms
{
    partial class ExportSlippyMap
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
            this.maxZoomTrackBar = new System.Windows.Forms.TrackBar();
            this.maxZoomLabel = new System.Windows.Forms.Label();
            this.maxZoomMaxLabel = new System.Windows.Forms.Label();
            this.maxZoomMinLabel = new System.Windows.Forms.Label();
            this.exportButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.tileCountLabel = new System.Windows.Forms.Label();
            this.exportDirBrowseButton = new System.Windows.Forms.Button();
            this.exportDirTextBox = new System.Windows.Forms.TextBox();
            this.exportDirLabel = new System.Windows.Forms.Label();
            this.overwriteCheckBox = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.maxZoomTrackBar)).BeginInit();
            this.SuspendLayout();
            // 
            // maxZoomTrackBar
            // 
            this.maxZoomTrackBar.LargeChange = 2;
            this.maxZoomTrackBar.Location = new System.Drawing.Point(78, 12);
            this.maxZoomTrackBar.Maximum = 6;
            this.maxZoomTrackBar.Minimum = 2;
            this.maxZoomTrackBar.Name = "maxZoomTrackBar";
            this.maxZoomTrackBar.Size = new System.Drawing.Size(222, 45);
            this.maxZoomTrackBar.TabIndex = 0;
            this.maxZoomTrackBar.Value = 6;
            this.maxZoomTrackBar.ValueChanged += new System.EventHandler(this.maxZoomTrackBar_ValueChanged);
            // 
            // maxZoomLabel
            // 
            this.maxZoomLabel.AutoSize = true;
            this.maxZoomLabel.Location = new System.Drawing.Point(12, 28);
            this.maxZoomLabel.Name = "maxZoomLabel";
            this.maxZoomLabel.Size = new System.Drawing.Size(60, 13);
            this.maxZoomLabel.TabIndex = 1;
            this.maxZoomLabel.Text = "Max. Zoom";
            // 
            // maxZoomMaxLabel
            // 
            this.maxZoomMaxLabel.AutoSize = true;
            this.maxZoomMaxLabel.Location = new System.Drawing.Point(279, 56);
            this.maxZoomMaxLabel.Name = "maxZoomMaxLabel";
            this.maxZoomMaxLabel.Size = new System.Drawing.Size(13, 13);
            this.maxZoomMaxLabel.TabIndex = 2;
            this.maxZoomMaxLabel.Text = "6";
            this.maxZoomMaxLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // maxZoomMinLabel
            // 
            this.maxZoomMinLabel.AutoSize = true;
            this.maxZoomMinLabel.Location = new System.Drawing.Point(84, 56);
            this.maxZoomMinLabel.Name = "maxZoomMinLabel";
            this.maxZoomMinLabel.Size = new System.Drawing.Size(13, 13);
            this.maxZoomMinLabel.TabIndex = 3;
            this.maxZoomMinLabel.Text = "2";
            this.maxZoomMinLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // exportButton
            // 
            this.exportButton.Location = new System.Drawing.Point(144, 105);
            this.exportButton.Name = "exportButton";
            this.exportButton.Size = new System.Drawing.Size(75, 23);
            this.exportButton.TabIndex = 4;
            this.exportButton.Text = "Export";
            this.exportButton.UseVisualStyleBackColor = true;
            this.exportButton.Click += new System.EventHandler(this.exportButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(225, 105);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 5;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // tileCountLabel
            // 
            this.tileCountLabel.Location = new System.Drawing.Point(103, 56);
            this.tileCountLabel.Name = "tileCountLabel";
            this.tileCountLabel.Size = new System.Drawing.Size(169, 13);
            this.tileCountLabel.TabIndex = 6;
            this.tileCountLabel.Text = "0 tiles";
            this.tileCountLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // exportDirBrowseButton
            // 
            this.exportDirBrowseButton.Location = new System.Drawing.Point(270, 76);
            this.exportDirBrowseButton.Name = "exportDirBrowseButton";
            this.exportDirBrowseButton.Size = new System.Drawing.Size(30, 23);
            this.exportDirBrowseButton.TabIndex = 7;
            this.exportDirBrowseButton.Text = "...";
            this.exportDirBrowseButton.UseVisualStyleBackColor = true;
            this.exportDirBrowseButton.Click += new System.EventHandler(this.exportDirBrowseButton_Click);
            // 
            // exportDirTextBox
            // 
            this.exportDirTextBox.Location = new System.Drawing.Point(78, 78);
            this.exportDirTextBox.Name = "exportDirTextBox";
            this.exportDirTextBox.Size = new System.Drawing.Size(186, 20);
            this.exportDirTextBox.TabIndex = 8;
            // 
            // exportDirLabel
            // 
            this.exportDirLabel.AutoSize = true;
            this.exportDirLabel.Location = new System.Drawing.Point(12, 81);
            this.exportDirLabel.Name = "exportDirLabel";
            this.exportDirLabel.Size = new System.Drawing.Size(52, 13);
            this.exportDirLabel.TabIndex = 9;
            this.exportDirLabel.Text = "Directory:";
            // 
            // overwriteCheckBox
            // 
            this.overwriteCheckBox.AutoSize = true;
            this.overwriteCheckBox.Checked = true;
            this.overwriteCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.overwriteCheckBox.Location = new System.Drawing.Point(12, 109);
            this.overwriteCheckBox.Name = "overwriteCheckBox";
            this.overwriteCheckBox.Size = new System.Drawing.Size(71, 17);
            this.overwriteCheckBox.TabIndex = 10;
            this.overwriteCheckBox.Text = "Overwrite";
            this.overwriteCheckBox.UseVisualStyleBackColor = true;
            // 
            // ExportSlippyMap
            // 
            this.AcceptButton = this.exportButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size(309, 136);
            this.Controls.Add(this.overwriteCheckBox);
            this.Controls.Add(this.exportDirLabel);
            this.Controls.Add(this.exportDirTextBox);
            this.Controls.Add(this.exportDirBrowseButton);
            this.Controls.Add(this.tileCountLabel);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.exportButton);
            this.Controls.Add(this.maxZoomMinLabel);
            this.Controls.Add(this.maxZoomMaxLabel);
            this.Controls.Add(this.maxZoomLabel);
            this.Controls.Add(this.maxZoomTrackBar);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(325, 175);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(325, 175);
            this.Name = "ExportSlippyMap";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Export Slippy Map";
            ((System.ComponentModel.ISupportInitialize)(this.maxZoomTrackBar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TrackBar maxZoomTrackBar;
        private System.Windows.Forms.Label maxZoomLabel;
        private System.Windows.Forms.Label maxZoomMaxLabel;
        private System.Windows.Forms.Label maxZoomMinLabel;
        private System.Windows.Forms.Button exportButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Label tileCountLabel;
        private System.Windows.Forms.Button exportDirBrowseButton;
        private System.Windows.Forms.TextBox exportDirTextBox;
        private System.Windows.Forms.Label exportDirLabel;
        private System.Windows.Forms.CheckBox overwriteCheckBox;
    }
}