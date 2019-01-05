namespace ServerGridEditor.Forms
{
    partial class EditDiscoZonesForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.cancelBtn = new System.Windows.Forms.Button();
            this.saveBtn = new System.Windows.Forms.Button();
            this.discoZonesGrid = new System.Windows.Forms.DataGridView();
            this.IsManual = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.zoneManualName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.zoneName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.zoneId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.zoneParent = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.zoneSizeX = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.zoneSizeY = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.zoneSizeZ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.zoneRotation = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.zoneXP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LocX = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LocY = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ExplorerNoteIndex = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.allowSea = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.discoZonesGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // cancelBtn
            // 
            this.cancelBtn.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.cancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.cancelBtn.Location = new System.Drawing.Point(512, 489);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(130, 35);
            this.cancelBtn.TabIndex = 4;
            this.cancelBtn.Text = "Cancel";
            this.cancelBtn.UseVisualStyleBackColor = true;
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // saveBtn
            // 
            this.saveBtn.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.saveBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.saveBtn.Location = new System.Drawing.Point(376, 489);
            this.saveBtn.Name = "saveBtn";
            this.saveBtn.Size = new System.Drawing.Size(130, 35);
            this.saveBtn.TabIndex = 3;
            this.saveBtn.Text = "Save";
            this.saveBtn.UseVisualStyleBackColor = true;
            this.saveBtn.Click += new System.EventHandler(this.saveBtn_Click);
            // 
            // discoZonesGrid
            // 
            this.discoZonesGrid.AllowUserToOrderColumns = true;
            this.discoZonesGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.discoZonesGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.discoZonesGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IsManual,
            this.zoneManualName,
            this.zoneName,
            this.zoneId,
            this.zoneParent,
            this.zoneSizeX,
            this.zoneSizeY,
            this.zoneSizeZ,
            this.zoneRotation,
            this.zoneXP,
            this.LocX,
            this.LocY,
            this.ExplorerNoteIndex,
            this.allowSea});
            this.discoZonesGrid.Location = new System.Drawing.Point(12, 12);
            this.discoZonesGrid.Name = "discoZonesGrid";
            this.discoZonesGrid.Size = new System.Drawing.Size(1006, 471);
            this.discoZonesGrid.TabIndex = 5;
            // 
            // IsManual
            // 
            this.IsManual.HeaderText = "isManual";
            this.IsManual.Name = "IsManual";
            this.IsManual.Width = 30;
            // 
            // zoneManualName
            // 
            this.zoneManualName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.zoneManualName.HeaderText = "ManualName";
            this.zoneManualName.MinimumWidth = 250;
            this.zoneManualName.Name = "zoneManualName";
            this.zoneManualName.Width = 250;
            // 
            // zoneName
            // 
            this.zoneName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.zoneName.HeaderText = "Name";
            this.zoneName.MinimumWidth = 180;
            this.zoneName.Name = "zoneName";
            this.zoneName.Width = 180;
            // 
            // zoneId
            // 
            this.zoneId.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.zoneId.DefaultCellStyle = dataGridViewCellStyle3;
            this.zoneId.HeaderText = "Id";
            this.zoneId.Name = "zoneId";
            this.zoneId.Width = 41;
            // 
            // zoneParent
            // 
            this.zoneParent.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.zoneParent.HeaderText = "Parent";
            this.zoneParent.Name = "zoneParent";
            this.zoneParent.Width = 63;
            // 
            // zoneSizeX
            // 
            this.zoneSizeX.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.zoneSizeX.DefaultCellStyle = dataGridViewCellStyle4;
            this.zoneSizeX.HeaderText = "SizeX";
            this.zoneSizeX.MaxInputLength = 2147483647;
            this.zoneSizeX.Name = "zoneSizeX";
            this.zoneSizeX.Width = 59;
            // 
            // zoneSizeY
            // 
            this.zoneSizeY.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.zoneSizeY.HeaderText = "SizeY";
            this.zoneSizeY.Name = "zoneSizeY";
            this.zoneSizeY.Width = 59;
            // 
            // zoneSizeZ
            // 
            this.zoneSizeZ.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.zoneSizeZ.HeaderText = "SizeZ";
            this.zoneSizeZ.Name = "zoneSizeZ";
            this.zoneSizeZ.Width = 59;
            // 
            // zoneRotation
            // 
            this.zoneRotation.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.zoneRotation.HeaderText = "Rotation";
            this.zoneRotation.Name = "zoneRotation";
            this.zoneRotation.Width = 72;
            // 
            // zoneXP
            // 
            this.zoneXP.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.zoneXP.HeaderText = "XP";
            this.zoneXP.Name = "zoneXP";
            this.zoneXP.Width = 46;
            // 
            // LocX
            // 
            this.LocX.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.LocX.HeaderText = "LocX";
            this.LocX.Name = "LocX";
            this.LocX.Visible = false;
            this.LocX.Width = 57;
            // 
            // LocY
            // 
            this.LocY.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.LocY.HeaderText = "LocY";
            this.LocY.Name = "LocY";
            this.LocY.Visible = false;
            this.LocY.Width = 57;
            // 
            // ExplorerNoteIndex
            // 
            this.ExplorerNoteIndex.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCellsExceptHeader;
            this.ExplorerNoteIndex.HeaderText = "ExplorerNoteIndex";
            this.ExplorerNoteIndex.MinimumWidth = 35;
            this.ExplorerNoteIndex.Name = "ExplorerNoteIndex";
            this.ExplorerNoteIndex.Width = 35;
            // 
            // allowSea
            // 
            this.allowSea.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.allowSea.HeaderText = "allowSea";
            this.allowSea.Name = "allowSea";
            this.allowSea.Width = 56;
            // 
            // EditDiscoZonesForm
            // 
            this.AcceptButton = this.saveBtn;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelBtn;
            this.ClientSize = new System.Drawing.Size(1030, 536);
            this.Controls.Add(this.discoZonesGrid);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.saveBtn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EditDiscoZonesForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Edit Discovery Zones";
            ((System.ComponentModel.ISupportInitialize)(this.discoZonesGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button cancelBtn;
        private System.Windows.Forms.Button saveBtn;
        private System.Windows.Forms.DataGridView discoZonesGrid;
        private System.Windows.Forms.DataGridViewCheckBoxColumn IsManual;
        private System.Windows.Forms.DataGridViewTextBoxColumn zoneManualName;
        private System.Windows.Forms.DataGridViewTextBoxColumn zoneName;
        private System.Windows.Forms.DataGridViewTextBoxColumn zoneId;
        private System.Windows.Forms.DataGridViewTextBoxColumn zoneParent;
        private System.Windows.Forms.DataGridViewTextBoxColumn zoneSizeX;
        private System.Windows.Forms.DataGridViewTextBoxColumn zoneSizeY;
        private System.Windows.Forms.DataGridViewTextBoxColumn zoneSizeZ;
        private System.Windows.Forms.DataGridViewTextBoxColumn zoneRotation;
        private System.Windows.Forms.DataGridViewTextBoxColumn zoneXP;
        private System.Windows.Forms.DataGridViewTextBoxColumn LocX;
        private System.Windows.Forms.DataGridViewTextBoxColumn LocY;
        private System.Windows.Forms.DataGridViewTextBoxColumn ExplorerNoteIndex;
        private System.Windows.Forms.DataGridViewCheckBoxColumn allowSea;
    }
}