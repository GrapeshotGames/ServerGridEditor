namespace ServerGridEditor.Forms
{
    partial class EditAllLocksForm
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
            this.label3 = new System.Windows.Forms.Label();
            this.lockIslndsBtn = new System.Windows.Forms.Button();
            this.unlockIslndsBtn = new System.Windows.Forms.Button();
            this.unlockDiscoBtn = new System.Windows.Forms.Button();
            this.lockDiscoBtn = new System.Windows.Forms.Button();
            this.unlockPaths = new System.Windows.Forms.Button();
            this.lockPaths = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label1.ForeColor = System.Drawing.Color.Green;
            this.label1.Location = new System.Drawing.Point(22, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 20);
            this.label1.TabIndex = 4;
            this.label1.Text = "Islands";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.label2.Location = new System.Drawing.Point(22, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 20);
            this.label2.TabIndex = 5;
            this.label2.Text = "Disco Zones";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.label3.Location = new System.Drawing.Point(22, 93);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 20);
            this.label3.TabIndex = 6;
            this.label3.Text = "Ship Paths";
            // 
            // lockIslndsBtn
            // 
            this.lockIslndsBtn.Location = new System.Drawing.Point(139, 30);
            this.lockIslndsBtn.Name = "lockIslndsBtn";
            this.lockIslndsBtn.Size = new System.Drawing.Size(75, 23);
            this.lockIslndsBtn.TabIndex = 7;
            this.lockIslndsBtn.Text = "LockAll";
            this.lockIslndsBtn.UseVisualStyleBackColor = true;
            this.lockIslndsBtn.Click += new System.EventHandler(this.lockIslndsBtn_Click);
            // 
            // unlockIslndsBtn
            // 
            this.unlockIslndsBtn.Location = new System.Drawing.Point(230, 30);
            this.unlockIslndsBtn.Name = "unlockIslndsBtn";
            this.unlockIslndsBtn.Size = new System.Drawing.Size(75, 23);
            this.unlockIslndsBtn.TabIndex = 8;
            this.unlockIslndsBtn.Text = "UnlockAll";
            this.unlockIslndsBtn.UseVisualStyleBackColor = true;
            this.unlockIslndsBtn.Click += new System.EventHandler(this.unlockIslndsBtn_Click);
            // 
            // unlockDiscoBtn
            // 
            this.unlockDiscoBtn.Location = new System.Drawing.Point(230, 61);
            this.unlockDiscoBtn.Name = "unlockDiscoBtn";
            this.unlockDiscoBtn.Size = new System.Drawing.Size(75, 23);
            this.unlockDiscoBtn.TabIndex = 10;
            this.unlockDiscoBtn.Text = "UnlockAll";
            this.unlockDiscoBtn.UseVisualStyleBackColor = true;
            this.unlockDiscoBtn.Click += new System.EventHandler(this.unlockDiscoBtn_Click);
            // 
            // lockDiscoBtn
            // 
            this.lockDiscoBtn.Location = new System.Drawing.Point(139, 61);
            this.lockDiscoBtn.Name = "lockDiscoBtn";
            this.lockDiscoBtn.Size = new System.Drawing.Size(75, 23);
            this.lockDiscoBtn.TabIndex = 9;
            this.lockDiscoBtn.Text = "LockAll";
            this.lockDiscoBtn.UseVisualStyleBackColor = true;
            this.lockDiscoBtn.Click += new System.EventHandler(this.lockDiscoBtn_Click);
            // 
            // unlockPaths
            // 
            this.unlockPaths.Location = new System.Drawing.Point(230, 93);
            this.unlockPaths.Name = "unlockPaths";
            this.unlockPaths.Size = new System.Drawing.Size(75, 23);
            this.unlockPaths.TabIndex = 12;
            this.unlockPaths.Text = "UnlockAll";
            this.unlockPaths.UseVisualStyleBackColor = true;
            this.unlockPaths.Click += new System.EventHandler(this.unlockPaths_Click);
            // 
            // lockPaths
            // 
            this.lockPaths.Location = new System.Drawing.Point(139, 93);
            this.lockPaths.Name = "lockPaths";
            this.lockPaths.Size = new System.Drawing.Size(75, 23);
            this.lockPaths.TabIndex = 11;
            this.lockPaths.Text = "LockAll";
            this.lockPaths.UseVisualStyleBackColor = true;
            this.lockPaths.Click += new System.EventHandler(this.lockPaths_Click);
            // 
            // EditAllLocksForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(317, 148);
            this.Controls.Add(this.unlockPaths);
            this.Controls.Add(this.lockPaths);
            this.Controls.Add(this.unlockDiscoBtn);
            this.Controls.Add(this.lockDiscoBtn);
            this.Controls.Add(this.unlockIslndsBtn);
            this.Controls.Add(this.lockIslndsBtn);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EditAllLocksForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Locks";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button lockIslndsBtn;
        private System.Windows.Forms.Button unlockIslndsBtn;
        private System.Windows.Forms.Button unlockDiscoBtn;
        private System.Windows.Forms.Button lockDiscoBtn;
        private System.Windows.Forms.Button unlockPaths;
        private System.Windows.Forms.Button lockPaths;
    }
}