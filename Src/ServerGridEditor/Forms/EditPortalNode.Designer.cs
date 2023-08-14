namespace ServerGridEditor.Forms
{
    partial class EditPortalNode
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
            this.label3 = new System.Windows.Forms.Label();
            this.nameTxtBox = new System.Windows.Forms.TextBox();
            this.ParamsOrGrid = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.ParamsGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ParamsOrGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // applyBtn
            // 
            this.applyBtn.Location = new System.Drawing.Point(146, 512);
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
            this.ParamsGrid.Location = new System.Drawing.Point(54, 64);
            this.ParamsGrid.Name = "ParamsGrid";
            this.ParamsGrid.Size = new System.Drawing.Size(252, 209);
            this.ParamsGrid.TabIndex = 21;
            // 
            // NodeType
            // 
            this.NodeType.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.NodeType.HeaderText = "Resource";
            this.NodeType.Name = "NodeType";
            // 
            // Weight
            // 
            this.Weight.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Weight.HeaderText = "Count";
            this.Weight.Name = "Weight";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(45, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 13);
            this.label3.TabIndex = 19;
            this.label3.Text = "Portal Name";
            // 
            // nameTxtBox
            // 
            this.nameTxtBox.Location = new System.Drawing.Point(116, 17);
            this.nameTxtBox.Name = "nameTxtBox";
            this.nameTxtBox.Size = new System.Drawing.Size(190, 20);
            this.nameTxtBox.TabIndex = 22;
            // 
            // ParamsOrGrid
            // 
            this.ParamsOrGrid.AllowUserToOrderColumns = true;
            this.ParamsOrGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ParamsOrGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ParamsOrGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2});
            this.ParamsOrGrid.Location = new System.Drawing.Point(54, 297);
            this.ParamsOrGrid.Name = "ParamsOrGrid";
            this.ParamsOrGrid.Size = new System.Drawing.Size(252, 209);
            this.ParamsOrGrid.TabIndex = 23;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn1.HeaderText = "Resource";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn2.HeaderText = "Count";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(51, 281);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 13);
            this.label1.TabIndex = 24;
            this.label1.Text = "Must have any of:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(51, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 13);
            this.label2.TabIndex = 25;
            this.label2.Text = "Must have all of:";
            // 
            // EditPortalNode
            // 
            this.AcceptButton = this.applyBtn;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(350, 549);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ParamsOrGrid);
            this.Controls.Add(this.nameTxtBox);
            this.Controls.Add(this.ParamsGrid);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.applyBtn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EditPortalNode";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Edit Portal Node";
            this.Load += new System.EventHandler(this.EditTradeWind_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ParamsGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ParamsOrGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button applyBtn;
        private System.Windows.Forms.DataGridView ParamsGrid;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridViewTextBoxColumn NodeType;
        private System.Windows.Forms.DataGridViewTextBoxColumn Weight;
        private System.Windows.Forms.TextBox nameTxtBox;
        private System.Windows.Forms.DataGridView ParamsOrGrid;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}