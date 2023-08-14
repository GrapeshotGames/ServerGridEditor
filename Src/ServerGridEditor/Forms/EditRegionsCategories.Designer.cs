namespace ServerGridEditor.Forms
{
    partial class EditRegionsCategories
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
            this.applyBtn = new System.Windows.Forms.Button();
            this.ParamsGrid = new System.Windows.Forms.DataGridView();
            this.NodeType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Weight = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.ParamsGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // applyBtn
            // 
            this.applyBtn.Location = new System.Drawing.Point(245, 326);
            this.applyBtn.Name = "applyBtn";
            this.applyBtn.Size = new System.Drawing.Size(75, 23);
            this.applyBtn.TabIndex = 1;
            this.applyBtn.Text = "Apply";
            this.applyBtn.UseVisualStyleBackColor = true;
            this.applyBtn.Click += new System.EventHandler(this.applyBtn_Click);
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
            this.ParamsGrid.Location = new System.Drawing.Point(54, 25);
            this.ParamsGrid.Name = "ParamsGrid";
            this.ParamsGrid.Size = new System.Drawing.Size(464, 283);
            this.ParamsGrid.TabIndex = 21;
            // 
            // NodeType
            // 
            this.NodeType.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.NodeType.FillWeight = 40F;
            this.NodeType.HeaderText = "Category";
            this.NodeType.Name = "NodeType";
            // 
            // Weight
            // 
            this.Weight.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Weight.FillWeight = 98.47716F;
            this.Weight.HeaderText = "Regions";
            this.Weight.Name = "Weight";
            // 
            // EditRegionsCategories
            // 
            this.AcceptButton = this.applyBtn;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(562, 375);
            this.Controls.Add(this.ParamsGrid);
            this.Controls.Add(this.applyBtn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EditRegionsCategories";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Edit Regions Categories";
            this.Load += new System.EventHandler(this.EditTradeWind_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ParamsGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button applyBtn;
        private System.Windows.Forms.DataGridView ParamsGrid;
        private System.Windows.Forms.DataGridViewTextBoxColumn NodeType;
        private System.Windows.Forms.DataGridViewTextBoxColumn Weight;
    }
}