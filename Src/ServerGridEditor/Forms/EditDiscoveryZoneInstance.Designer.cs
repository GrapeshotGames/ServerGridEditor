namespace ServerGridEditor.Forms
{
    partial class EditDiscoveryZoneInstance
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
            this.zoneNameTxt = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.zoneIdTxt = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.zoneSizeXTxt = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.zoneSizeYTxt = new System.Windows.Forms.TextBox();
            this.zoneXPTxt = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.zoneSizeZTxt = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.explorerNoteIndexTxt = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.allowSeaCheckbox = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // cancelBtn
            // 
            this.cancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelBtn.Location = new System.Drawing.Point(119, 238);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(92, 32);
            this.cancelBtn.TabIndex = 5;
            this.cancelBtn.Text = "Cancel";
            this.cancelBtn.UseVisualStyleBackColor = true;
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // saveBtn
            // 
            this.saveBtn.Location = new System.Drawing.Point(12, 238);
            this.saveBtn.Name = "saveBtn";
            this.saveBtn.Size = new System.Drawing.Size(92, 32);
            this.saveBtn.TabIndex = 4;
            this.saveBtn.Text = "Save";
            this.saveBtn.UseVisualStyleBackColor = true;
            this.saveBtn.Click += new System.EventHandler(this.saveBtn_Click);
            // 
            // zoneNameTxt
            // 
            this.zoneNameTxt.Location = new System.Drawing.Point(119, 25);
            this.zoneNameTxt.Name = "zoneNameTxt";
            this.zoneNameTxt.Size = new System.Drawing.Size(92, 20);
            this.zoneNameTxt.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Zone Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 80);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Zone sizeX";
            // 
            // zoneIdTxt
            // 
            this.zoneIdTxt.Location = new System.Drawing.Point(119, 51);
            this.zoneIdTxt.Name = "zoneIdTxt";
            this.zoneIdTxt.Size = new System.Drawing.Size(92, 20);
            this.zoneIdTxt.TabIndex = 9;
            this.zoneIdTxt.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.zoneIdTxt_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(24, 106);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "Zone size Y";
            // 
            // zoneSizeXTxt
            // 
            this.zoneSizeXTxt.Location = new System.Drawing.Point(119, 77);
            this.zoneSizeXTxt.Name = "zoneSizeXTxt";
            this.zoneSizeXTxt.Size = new System.Drawing.Size(92, 20);
            this.zoneSizeXTxt.TabIndex = 11;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(24, 54);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 13);
            this.label4.TabIndex = 14;
            this.label4.Text = "Zone Id";
            // 
            // zoneSizeYTxt
            // 
            this.zoneSizeYTxt.Location = new System.Drawing.Point(119, 103);
            this.zoneSizeYTxt.Name = "zoneSizeYTxt";
            this.zoneSizeYTxt.Size = new System.Drawing.Size(92, 20);
            this.zoneSizeYTxt.TabIndex = 13;
            // 
            // zoneXPTxt
            // 
            this.zoneXPTxt.Location = new System.Drawing.Point(119, 155);
            this.zoneXPTxt.Name = "zoneXPTxt";
            this.zoneXPTxt.Size = new System.Drawing.Size(92, 20);
            this.zoneXPTxt.TabIndex = 16;
            this.zoneXPTxt.TextChanged += new System.EventHandler(this.zoneXPTxt_TextChanged);
            this.zoneXPTxt.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.zoneXPTxt_KeyPress);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(24, 158);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(49, 13);
            this.label5.TabIndex = 15;
            this.label5.Text = "Zone XP";
            // 
            // zoneSizeZTxt
            // 
            this.zoneSizeZTxt.Location = new System.Drawing.Point(119, 129);
            this.zoneSizeZTxt.Name = "zoneSizeZTxt";
            this.zoneSizeZTxt.Size = new System.Drawing.Size(92, 20);
            this.zoneSizeZTxt.TabIndex = 18;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(24, 132);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(63, 13);
            this.label6.TabIndex = 17;
            this.label6.Text = "Zone size Z";
            // 
            // explorerNoteIndexTxt
            // 
            this.explorerNoteIndexTxt.Location = new System.Drawing.Point(119, 181);
            this.explorerNoteIndexTxt.Name = "explorerNoteIndexTxt";
            this.explorerNoteIndexTxt.Size = new System.Drawing.Size(92, 20);
            this.explorerNoteIndexTxt.TabIndex = 20;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(24, 184);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(94, 13);
            this.label7.TabIndex = 19;
            this.label7.Text = "ExplorerNoteIndex";
            // 
            // allowSeaCheckbox
            // 
            this.allowSeaCheckbox.AutoSize = true;
            this.allowSeaCheckbox.Location = new System.Drawing.Point(59, 207);
            this.allowSeaCheckbox.Name = "allowSeaCheckbox";
            this.allowSeaCheckbox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.allowSeaCheckbox.Size = new System.Drawing.Size(73, 17);
            this.allowSeaCheckbox.TabIndex = 21;
            this.allowSeaCheckbox.Text = "Allow Sea";
            this.allowSeaCheckbox.UseVisualStyleBackColor = true;
            // 
            // EditDiscoveryZoneInstance
            // 
            this.AcceptButton = this.saveBtn;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelBtn;
            this.ClientSize = new System.Drawing.Size(224, 279);
            this.Controls.Add(this.allowSeaCheckbox);
            this.Controls.Add(this.explorerNoteIndexTxt);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.zoneSizeZTxt);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.zoneXPTxt);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.zoneSizeYTxt);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.zoneSizeXTxt);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.zoneIdTxt);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.zoneNameTxt);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.saveBtn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EditDiscoveryZoneInstance";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Edit Discovery Zone Instance";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cancelBtn;
        private System.Windows.Forms.Button saveBtn;
        private System.Windows.Forms.TextBox zoneNameTxt;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox zoneIdTxt;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox zoneSizeXTxt;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox zoneSizeYTxt;
        private System.Windows.Forms.TextBox zoneXPTxt;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox zoneSizeZTxt;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox explorerNoteIndexTxt;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.CheckBox allowSeaCheckbox;
    }
}