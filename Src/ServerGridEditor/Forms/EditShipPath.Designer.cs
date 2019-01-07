namespace ServerGridEditor.Forms
{
    partial class EditShipPath
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
            this.loopingPathChckBox = new System.Windows.Forms.CheckBox();
            this.applyBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.pathNameTxtBox = new System.Windows.Forms.TextBox();
            this.autoSpawnChckBox = new System.Windows.Forms.CheckBox();
            this.autoSpawnEveryUTCIntervalTxtBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.autoSpawnShipClassTxtBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // loopingPathChckBox
            // 
            this.loopingPathChckBox.AutoSize = true;
            this.loopingPathChckBox.Location = new System.Drawing.Point(75, 130);
            this.loopingPathChckBox.Name = "loopingPathChckBox";
            this.loopingPathChckBox.Size = new System.Drawing.Size(114, 17);
            this.loopingPathChckBox.TabIndex = 0;
            this.loopingPathChckBox.Text = "Loop around world";
            this.loopingPathChckBox.UseVisualStyleBackColor = true;
            // 
            // applyBtn
            // 
            this.applyBtn.Location = new System.Drawing.Point(152, 179);
            this.applyBtn.Name = "applyBtn";
            this.applyBtn.Size = new System.Drawing.Size(75, 23);
            this.applyBtn.TabIndex = 1;
            this.applyBtn.Text = "Apply";
            this.applyBtn.UseVisualStyleBackColor = true;
            this.applyBtn.Click += new System.EventHandler(this.applyBtn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Path Name";
            // 
            // pathNameTxtBox
            // 
            this.pathNameTxtBox.Location = new System.Drawing.Point(75, 17);
            this.pathNameTxtBox.Name = "pathNameTxtBox";
            this.pathNameTxtBox.Size = new System.Drawing.Size(224, 20);
            this.pathNameTxtBox.TabIndex = 3;
            // 
            // autoSpawnChckBox
            // 
            this.autoSpawnChckBox.AutoSize = true;
            this.autoSpawnChckBox.Location = new System.Drawing.Point(75, 153);
            this.autoSpawnChckBox.Name = "autoSpawnChckBox";
            this.autoSpawnChckBox.Size = new System.Drawing.Size(148, 17);
            this.autoSpawnChckBox.TabIndex = 4;
            this.autoSpawnChckBox.Text = "Auto Spawn At First Node";
            this.autoSpawnChckBox.UseVisualStyleBackColor = true;
            // 
            // autoSpawnEveryUTCIntervalTxtBox
            // 
            this.autoSpawnEveryUTCIntervalTxtBox.Location = new System.Drawing.Point(164, 43);
            this.autoSpawnEveryUTCIntervalTxtBox.Name = "autoSpawnEveryUTCIntervalTxtBox";
            this.autoSpawnEveryUTCIntervalTxtBox.Size = new System.Drawing.Size(135, 20);
            this.autoSpawnEveryUTCIntervalTxtBox.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(149, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "AutoSpawnEveryUTCInterval:";
            // 
            // autoSpawnShipClassTxtBox
            // 
            this.autoSpawnShipClassTxtBox.Location = new System.Drawing.Point(12, 88);
            this.autoSpawnShipClassTxtBox.Name = "autoSpawnShipClassTxtBox";
            this.autoSpawnShipClassTxtBox.Size = new System.Drawing.Size(335, 20);
            this.autoSpawnShipClassTxtBox.TabIndex = 8;
            this.autoSpawnShipClassTxtBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.autoSpawnShipClass_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 72);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(111, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "AutoSpawnShipClass:";
            // 
            // EditShipPath
            // 
            this.AcceptButton = this.applyBtn;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(359, 216);
            this.Controls.Add(this.autoSpawnShipClassTxtBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.autoSpawnEveryUTCIntervalTxtBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.autoSpawnChckBox);
            this.Controls.Add(this.pathNameTxtBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.applyBtn);
            this.Controls.Add(this.loopingPathChckBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EditShipPath";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Edit Ship Path";
            this.Load += new System.EventHandler(this.EditShipPath_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox loopingPathChckBox;
        private System.Windows.Forms.Button applyBtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox pathNameTxtBox;
        private System.Windows.Forms.CheckBox autoSpawnChckBox;
        private System.Windows.Forms.TextBox autoSpawnEveryUTCIntervalTxtBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox autoSpawnShipClassTxtBox;
        private System.Windows.Forms.Label label3;
    }
}