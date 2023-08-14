namespace ServerGridEditor.Forms
{
    partial class EditNodeTemplates
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
            this.addBtn = new System.Windows.Forms.Button();
            this.editBtn = new System.Windows.Forms.Button();
            this.removeBtn = new System.Windows.Forms.Button();
            this.templatesLstBox = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // addBtn
            // 
            this.addBtn.Location = new System.Drawing.Point(12, 269);
            this.addBtn.Name = "addBtn";
            this.addBtn.Size = new System.Drawing.Size(77, 29);
            this.addBtn.TabIndex = 1;
            this.addBtn.Text = "Add";
            this.addBtn.UseVisualStyleBackColor = true;
            this.addBtn.Click += new System.EventHandler(this.addBtn_Click);
            // 
            // editBtn
            // 
            this.editBtn.Location = new System.Drawing.Point(95, 269);
            this.editBtn.Name = "editBtn";
            this.editBtn.Size = new System.Drawing.Size(74, 29);
            this.editBtn.TabIndex = 2;
            this.editBtn.Text = "Edit";
            this.editBtn.UseVisualStyleBackColor = true;
            this.editBtn.Click += new System.EventHandler(this.editBtn_Click);
            // 
            // removeBtn
            // 
            this.removeBtn.Location = new System.Drawing.Point(175, 269);
            this.removeBtn.Name = "removeBtn";
            this.removeBtn.Size = new System.Drawing.Size(77, 29);
            this.removeBtn.TabIndex = 3;
            this.removeBtn.Text = "Remove";
            this.removeBtn.UseVisualStyleBackColor = true;
            this.removeBtn.Click += new System.EventHandler(this.removeBtn_Click);
            // 
            // templatesLstBox
            // 
            this.templatesLstBox.FormattingEnabled = true;
            this.templatesLstBox.Location = new System.Drawing.Point(12, 12);
            this.templatesLstBox.Name = "templatesLstBox";
            this.templatesLstBox.Size = new System.Drawing.Size(240, 238);
            this.templatesLstBox.TabIndex = 4;
            // 
            // EditNodeTemplates
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(266, 307);
            this.Controls.Add(this.templatesLstBox);
            this.Controls.Add(this.removeBtn);
            this.Controls.Add(this.editBtn);
            this.Controls.Add(this.addBtn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EditNodeTemplates";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Edit Node Templates";
            this.Load += new System.EventHandler(this.EditNodeTemplates_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button addBtn;
        private System.Windows.Forms.Button editBtn;
        private System.Windows.Forms.Button removeBtn;
        private System.Windows.Forms.ListBox templatesLstBox;
    }
}