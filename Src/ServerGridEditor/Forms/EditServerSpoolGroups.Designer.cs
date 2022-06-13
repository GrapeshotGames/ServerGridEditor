namespace ServerGridEditor.Forms
{
    partial class EditServerSpoolGroups
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
            this.ParamsGrid = new System.Windows.Forms.DataGridView();
            this.applyBtn = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.NodeType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Weight = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.ParamsGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // ParamsGrid
            // 
            this.ParamsGrid.AllowUserToOrderColumns = true;
            this.ParamsGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ParamsGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ParamsGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.NodeType,
            this.Weight});
            this.ParamsGrid.Location = new System.Drawing.Point(28, 22);
            this.ParamsGrid.Name = "ParamsGrid";
            this.ParamsGrid.Size = new System.Drawing.Size(623, 258);
            this.ParamsGrid.TabIndex = 23;
            // 
            // applyBtn
            // 
            this.applyBtn.Location = new System.Drawing.Point(263, 286);
            this.applyBtn.Name = "applyBtn";
            this.applyBtn.Size = new System.Drawing.Size(75, 23);
            this.applyBtn.TabIndex = 22;
            this.applyBtn.Text = "Apply";
            this.applyBtn.UseVisualStyleBackColor = true;
            this.applyBtn.Click += new System.EventHandler(this.applyBtn_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(344, 286);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 24;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            // 
            // NodeType
            // 
            this.NodeType.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.NodeType.FillWeight = 51.40197F;
            this.NodeType.HeaderText = "Group Name";
            this.NodeType.Name = "NodeType";
            // 
            // Weight
            // 
            this.Weight.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Weight.FillWeight = 126.548F;
            this.Weight.HeaderText = "Buff To Give";
            this.Weight.Name = "Weight";
            // 
            // EditServerSpoolGroups
            // 
            this.AcceptButton = this.applyBtn;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size(663, 330);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.ParamsGrid);
            this.Controls.Add(this.applyBtn);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EditServerSpoolGroups";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Edit Server Spool Groups";
            ((System.ComponentModel.ISupportInitialize)(this.ParamsGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView ParamsGrid;
        private System.Windows.Forms.Button applyBtn;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.DataGridViewTextBoxColumn NodeType;
        private System.Windows.Forms.DataGridViewTextBoxColumn Weight;
    }
}