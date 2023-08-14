namespace ServerGridEditor.Forms
{
    partial class AddServerConfiguration
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
            this.regionName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.regionParent = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cancelBtn = new System.Windows.Forms.Button();
            this.saveBtn = new System.Windows.Forms.Button();
            this.ServerConfigurationTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.ParentServerConfigurationComboBox = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
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
            this.regionName,
            this.regionParent});
            this.ParamsGrid.Location = new System.Drawing.Point(12, 68);
            this.ParamsGrid.Name = "ParamsGrid";
            this.ParamsGrid.Size = new System.Drawing.Size(350, 498);
            this.ParamsGrid.TabIndex = 6;
            // 
            // regionName
            // 
            this.regionName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.regionName.FillWeight = 99.23664F;
            this.regionName.HeaderText = "ParamName";
            this.regionName.Name = "regionName";
            // 
            // regionParent
            // 
            this.regionParent.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.regionParent.FillWeight = 100.7634F;
            this.regionParent.HeaderText = "Value";
            this.regionParent.Name = "regionParent";
            // 
            // cancelBtn
            // 
            this.cancelBtn.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.cancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.cancelBtn.Location = new System.Drawing.Point(189, 607);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(130, 35);
            this.cancelBtn.TabIndex = 8;
            this.cancelBtn.Text = "Cancel";
            this.cancelBtn.UseVisualStyleBackColor = true;
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // saveBtn
            // 
            this.saveBtn.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.saveBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.saveBtn.Location = new System.Drawing.Point(53, 607);
            this.saveBtn.Name = "saveBtn";
            this.saveBtn.Size = new System.Drawing.Size(130, 35);
            this.saveBtn.TabIndex = 7;
            this.saveBtn.Text = "Add";
            this.saveBtn.UseVisualStyleBackColor = true;
            this.saveBtn.Click += new System.EventHandler(this.saveBtn_Click);
            // 
            // ServerConfigurationTextBox
            // 
            this.ServerConfigurationTextBox.Location = new System.Drawing.Point(189, 576);
            this.ServerConfigurationTextBox.Name = "ServerConfigurationTextBox";
            this.ServerConfigurationTextBox.Size = new System.Drawing.Size(100, 20);
            this.ServerConfigurationTextBox.TabIndex = 25;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(83, 579);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 13);
            this.label1.TabIndex = 26;
            this.label1.Text = "Configuration Name";
            // 
            // ParentServerConfigurationComboBox
            // 
            this.ParentServerConfigurationComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ParentServerConfigurationComboBox.FormattingEnabled = true;
            this.ParentServerConfigurationComboBox.Location = new System.Drawing.Point(189, 31);
            this.ParentServerConfigurationComboBox.Name = "ParentServerConfigurationComboBox";
            this.ParentServerConfigurationComboBox.Size = new System.Drawing.Size(121, 21);
            this.ParentServerConfigurationComboBox.TabIndex = 27;
            this.ParentServerConfigurationComboBox.SelectedIndexChanged += new System.EventHandler(this.ParentServerConfigurationComboBox_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(49, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(134, 13);
            this.label2.TabIndex = 28;
            this.label2.Text = "Parent Configuration Name";
            // 
            // AddServerConfiguration
            // 
            this.AcceptButton = this.saveBtn;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelBtn;
            this.ClientSize = new System.Drawing.Size(374, 654);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ParentServerConfigurationComboBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ServerConfigurationTextBox);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.saveBtn);
            this.Controls.Add(this.ParamsGrid);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddServerConfiguration";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Add Server Configuration";
            ((System.ComponentModel.ISupportInitialize)(this.ParamsGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView ParamsGrid;
        private System.Windows.Forms.Button cancelBtn;
        private System.Windows.Forms.Button saveBtn;
        private System.Windows.Forms.TextBox ServerConfigurationTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox ParentServerConfigurationComboBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridViewTextBoxColumn regionName;
        private System.Windows.Forms.DataGridViewTextBoxColumn regionParent;
    }
}