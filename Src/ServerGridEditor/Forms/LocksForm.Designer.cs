namespace ServerGridEditor.Forms
{
    partial class LocksForm
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
            this.lockIslandsChkbox = new System.Windows.Forms.CheckBox();
            this.applyBtn = new System.Windows.Forms.Button();
            this.lockDiscoChckbox = new System.Windows.Forms.CheckBox();
            this.lockShipPathsChckbox = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // lockIslandsChkbox
            // 
            this.lockIslandsChkbox.AutoSize = true;
            this.lockIslandsChkbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lockIslandsChkbox.ForeColor = System.Drawing.Color.Green;
            this.lockIslandsChkbox.Location = new System.Drawing.Point(26, 33);
            this.lockIslandsChkbox.Name = "lockIslandsChkbox";
            this.lockIslandsChkbox.Size = new System.Drawing.Size(117, 24);
            this.lockIslandsChkbox.TabIndex = 0;
            this.lockIslandsChkbox.Text = "Lock Islands";
            this.lockIslandsChkbox.UseVisualStyleBackColor = true;
            // 
            // applyBtn
            // 
            this.applyBtn.Location = new System.Drawing.Point(68, 140);
            this.applyBtn.Name = "applyBtn";
            this.applyBtn.Size = new System.Drawing.Size(75, 23);
            this.applyBtn.TabIndex = 1;
            this.applyBtn.Text = "Apply";
            this.applyBtn.UseVisualStyleBackColor = true;
            this.applyBtn.Click += new System.EventHandler(this.button1_Click);
            // 
            // lockDiscoChckbox
            // 
            this.lockDiscoChckbox.AutoSize = true;
            this.lockDiscoChckbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lockDiscoChckbox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.lockDiscoChckbox.Location = new System.Drawing.Point(26, 63);
            this.lockDiscoChckbox.Name = "lockDiscoChckbox";
            this.lockDiscoChckbox.Size = new System.Drawing.Size(155, 24);
            this.lockDiscoChckbox.TabIndex = 2;
            this.lockDiscoChckbox.Text = "Lock Disco Zones";
            this.lockDiscoChckbox.UseVisualStyleBackColor = true;
            // 
            // lockShipPathsChckbox
            // 
            this.lockShipPathsChckbox.AutoSize = true;
            this.lockShipPathsChckbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lockShipPathsChckbox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lockShipPathsChckbox.Location = new System.Drawing.Point(26, 93);
            this.lockShipPathsChckbox.Name = "lockShipPathsChckbox";
            this.lockShipPathsChckbox.Size = new System.Drawing.Size(143, 24);
            this.lockShipPathsChckbox.TabIndex = 3;
            this.lockShipPathsChckbox.Text = "Lock Ship Paths";
            this.lockShipPathsChckbox.UseVisualStyleBackColor = true;
            // 
            // LocksForm
            // 
            this.AcceptButton = this.applyBtn;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(217, 189);
            this.Controls.Add(this.lockShipPathsChckbox);
            this.Controls.Add(this.lockDiscoChckbox);
            this.Controls.Add(this.applyBtn);
            this.Controls.Add(this.lockIslandsChkbox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LocksForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Locks";
            this.Load += new System.EventHandler(this.LocksForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox lockIslandsChkbox;
        private System.Windows.Forms.Button applyBtn;
        private System.Windows.Forms.CheckBox lockDiscoChckbox;
        private System.Windows.Forms.CheckBox lockShipPathsChckbox;
    }
}