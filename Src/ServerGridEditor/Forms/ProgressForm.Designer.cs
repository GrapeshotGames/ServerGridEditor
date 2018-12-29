namespace Atlas.ServerGridEditor
{
    partial class ProgressForm
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
            this.stepDescLbl = new System.Windows.Forms.Label();
            this.stepLbl = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // stepDescLbl
            // 
            this.stepDescLbl.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.stepDescLbl.AutoEllipsis = true;
            this.stepDescLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stepDescLbl.Location = new System.Drawing.Point(-26, 32);
            this.stepDescLbl.Name = "stepDescLbl";
            this.stepDescLbl.Size = new System.Drawing.Size(394, 44);
            this.stepDescLbl.TabIndex = 0;
            this.stepDescLbl.Text = "Step Description";
            this.stepDescLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.stepDescLbl.Click += new System.EventHandler(this.stepDescLbl_Click);
            // 
            // stepLbl
            // 
            this.stepLbl.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.stepLbl.AutoEllipsis = true;
            this.stepLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stepLbl.Location = new System.Drawing.Point(-26, 67);
            this.stepLbl.Name = "stepLbl";
            this.stepLbl.Size = new System.Drawing.Size(394, 27);
            this.stepLbl.TabIndex = 1;
            this.stepLbl.Text = "(1/5)";
            this.stepLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ProgressForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(343, 128);
            this.ControlBox = false;
            this.Controls.Add(this.stepLbl);
            this.Controls.Add(this.stepDescLbl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "ProgressForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Please wait";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label stepDescLbl;
        private System.Windows.Forms.Label stepLbl;
    }
}