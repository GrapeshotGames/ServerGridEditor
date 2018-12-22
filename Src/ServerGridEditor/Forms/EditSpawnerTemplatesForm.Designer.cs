namespace ServerGridEditor.Forms
{
    partial class EditSpawnerTemplatesForm
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.spawnersGrid = new System.Windows.Forms.DataGridView();
            this.saveBtn = new System.Windows.Forms.Button();
            this.cancelBtn = new System.Windows.Forms.Button();
            this.spawnersBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.sublevelSerializationObjectBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.templateName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NPCSpawnEntries = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NPCSpawnLimits = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaxDesiredNumEnemiesMultiplier = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.spawnersGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spawnersBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sublevelSerializationObjectBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // spawnersGrid
            // 
            this.spawnersGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.spawnersGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.spawnersGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.templateName,
            this.NPCSpawnEntries,
            this.NPCSpawnLimits,
            this.MaxDesiredNumEnemiesMultiplier});
            this.spawnersGrid.Location = new System.Drawing.Point(12, 12);
            this.spawnersGrid.Name = "spawnersGrid";
            this.spawnersGrid.Size = new System.Drawing.Size(632, 398);
            this.spawnersGrid.TabIndex = 0;
            // 
            // saveBtn
            // 
            this.saveBtn.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.saveBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.saveBtn.Location = new System.Drawing.Point(198, 432);
            this.saveBtn.Name = "saveBtn";
            this.saveBtn.Size = new System.Drawing.Size(130, 35);
            this.saveBtn.TabIndex = 1;
            this.saveBtn.Text = "Save";
            this.saveBtn.UseVisualStyleBackColor = true;
            this.saveBtn.Click += new System.EventHandler(this.saveBtn_Click);
            // 
            // cancelBtn
            // 
            this.cancelBtn.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.cancelBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.cancelBtn.Location = new System.Drawing.Point(334, 432);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(130, 35);
            this.cancelBtn.TabIndex = 2;
            this.cancelBtn.Text = "Cancel";
            this.cancelBtn.UseVisualStyleBackColor = true;
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // spawnersBindingSource
            // 
            this.spawnersBindingSource.DataSource = typeof(ServerGridEditor.Spawners);
            // 
            // sublevelSerializationObjectBindingSource
            // 
            this.sublevelSerializationObjectBindingSource.DataSource = typeof(AtlasGridDataLibrary.SublevelSerializationObject);
            // 
            // templateName
            // 
            this.templateName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.templateName.FillWeight = 50F;
            this.templateName.HeaderText = "Name";
            this.templateName.Name = "templateName";
            // 
            // NPCSpawnEntries
            // 
            this.NPCSpawnEntries.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.NPCSpawnEntries.DefaultCellStyle = dataGridViewCellStyle1;
            this.NPCSpawnEntries.HeaderText = "NPCSpawnEntries";
            this.NPCSpawnEntries.MaxInputLength = 2147483647;
            this.NPCSpawnEntries.Name = "NPCSpawnEntries";
            // 
            // NPCSpawnLimits
            // 
            this.NPCSpawnLimits.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.NPCSpawnLimits.DefaultCellStyle = dataGridViewCellStyle2;
            this.NPCSpawnLimits.HeaderText = "NPCSpawnLimits";
            this.NPCSpawnLimits.MaxInputLength = 2147483647;
            this.NPCSpawnLimits.Name = "NPCSpawnLimits";
            // 
            // MaxDesiredNumEnemiesMultiplier
            // 
            this.MaxDesiredNumEnemiesMultiplier.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.MaxDesiredNumEnemiesMultiplier.HeaderText = "MaxDesiredNumEnemiesMultiplier";
            this.MaxDesiredNumEnemiesMultiplier.Name = "MaxDesiredNumEnemiesMultiplier";
            // 
            // EditSpawnerTemplatesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(656, 479);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.saveBtn);
            this.Controls.Add(this.spawnersGrid);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EditSpawnerTemplatesForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Edit Spawner Templates";
            this.TopMost = true;
            ((System.ComponentModel.ISupportInitialize)(this.spawnersGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spawnersBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sublevelSerializationObjectBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView spawnersGrid;
        private System.Windows.Forms.Button saveBtn;
        private System.Windows.Forms.Button cancelBtn;
        private System.Windows.Forms.BindingSource sublevelSerializationObjectBindingSource;
        private System.Windows.Forms.BindingSource spawnersBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn templateName;
        private System.Windows.Forms.DataGridViewTextBoxColumn NPCSpawnEntries;
        private System.Windows.Forms.DataGridViewTextBoxColumn NPCSpawnLimits;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaxDesiredNumEnemiesMultiplier;
    }
}