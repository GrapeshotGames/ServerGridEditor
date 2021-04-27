namespace ServerGridEditor.Forms
{
    partial class EditTradeWind
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
            this.loopingAroundWorldChckBox = new System.Windows.Forms.CheckBox();
            this.applyBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.pathNameTxtBox = new System.Windows.Forms.TextBox();
            this.isLoopingChkBox = new System.Windows.Forms.CheckBox();
            this.reverseDirChkBox = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.widthTxt = new System.Windows.Forms.TextBox();
            this.strengthTxt = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.InterploationPercTrackBar = new System.Windows.Forms.TrackBar();
            this.InterploationPercLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.InterploationPercTrackBar)).BeginInit();
            this.SuspendLayout();
            // 
            // loopingAroundWorldChckBox
            // 
            this.loopingAroundWorldChckBox.AutoSize = true;
            this.loopingAroundWorldChckBox.Location = new System.Drawing.Point(98, 58);
            this.loopingAroundWorldChckBox.Name = "loopingAroundWorldChckBox";
            this.loopingAroundWorldChckBox.Size = new System.Drawing.Size(114, 17);
            this.loopingAroundWorldChckBox.TabIndex = 0;
            this.loopingAroundWorldChckBox.Text = "Loop around world";
            this.loopingAroundWorldChckBox.UseVisualStyleBackColor = true;
            // 
            // applyBtn
            // 
            this.applyBtn.Location = new System.Drawing.Point(135, 206);
            this.applyBtn.Name = "applyBtn";
            this.applyBtn.Size = new System.Drawing.Size(75, 23);
            this.applyBtn.TabIndex = 1;
            this.applyBtn.Text = "Apply";
            this.applyBtn.UseVisualStyleBackColor = true;
            this.applyBtn.Click += new System.EventHandler(this.applyBtn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Path Name";
            // 
            // pathNameTxtBox
            // 
            this.pathNameTxtBox.Location = new System.Drawing.Point(77, 30);
            this.pathNameTxtBox.Name = "pathNameTxtBox";
            this.pathNameTxtBox.Size = new System.Drawing.Size(259, 20);
            this.pathNameTxtBox.TabIndex = 3;
            // 
            // isLoopingChkBox
            // 
            this.isLoopingChkBox.AutoSize = true;
            this.isLoopingChkBox.Location = new System.Drawing.Point(14, 58);
            this.isLoopingChkBox.Name = "isLoopingChkBox";
            this.isLoopingChkBox.Size = new System.Drawing.Size(75, 17);
            this.isLoopingChkBox.TabIndex = 4;
            this.isLoopingChkBox.Text = "Is Looping";
            this.isLoopingChkBox.UseVisualStyleBackColor = true;
            this.isLoopingChkBox.CheckedChanged += new System.EventHandler(this.isLoopingChkBox_CheckedChanged);
            // 
            // reverseDirChkBox
            // 
            this.reverseDirChkBox.AutoSize = true;
            this.reverseDirChkBox.Location = new System.Drawing.Point(229, 58);
            this.reverseDirChkBox.Name = "reverseDirChkBox";
            this.reverseDirChkBox.Size = new System.Drawing.Size(111, 17);
            this.reverseDirChkBox.TabIndex = 5;
            this.reverseDirChkBox.Text = "Reverse Direction";
            this.reverseDirChkBox.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(56, 176);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Width:";
            // 
            // widthTxt
            // 
            this.widthTxt.Location = new System.Drawing.Point(97, 172);
            this.widthTxt.Name = "widthTxt";
            this.widthTxt.Size = new System.Drawing.Size(63, 20);
            this.widthTxt.TabIndex = 7;
            this.widthTxt.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.widthTxt_KeyPress);
            // 
            // strengthTxt
            // 
            this.strengthTxt.Location = new System.Drawing.Point(225, 171);
            this.strengthTxt.Name = "strengthTxt";
            this.strengthTxt.Size = new System.Drawing.Size(63, 20);
            this.strengthTxt.TabIndex = 9;
            this.strengthTxt.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.strengthTxt_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(175, 175);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Strength:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(12, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(92, 15);
            this.label4.TabIndex = 10;
            this.label4.Text = "Path Settings";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(12, 142);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(97, 15);
            this.label5.TabIndex = 11;
            this.label5.Text = "Node Settings";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 88);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(191, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "Start Interploating Color At Percentage:";
            // 
            // InterploationPercTrackBar
            // 
            this.InterploationPercTrackBar.Location = new System.Drawing.Point(210, 88);
            this.InterploationPercTrackBar.Maximum = 100;
            this.InterploationPercTrackBar.Name = "InterploationPercTrackBar";
            this.InterploationPercTrackBar.Size = new System.Drawing.Size(78, 45);
            this.InterploationPercTrackBar.TabIndex = 13;
            this.InterploationPercTrackBar.Scroll += new System.EventHandler(this.InterploationPercTrackBar_Scroll);
            // 
            // InterploationPercLabel
            // 
            this.InterploationPercLabel.AutoSize = true;
            this.InterploationPercLabel.Location = new System.Drawing.Point(294, 88);
            this.InterploationPercLabel.Name = "InterploationPercLabel";
            this.InterploationPercLabel.Size = new System.Drawing.Size(21, 13);
            this.InterploationPercLabel.TabIndex = 14;
            this.InterploationPercLabel.Text = "0%";
            // 
            // EditTradeWind
            // 
            this.AcceptButton = this.applyBtn;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(350, 249);
            this.Controls.Add(this.InterploationPercLabel);
            this.Controls.Add(this.InterploationPercTrackBar);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.strengthTxt);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.widthTxt);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.reverseDirChkBox);
            this.Controls.Add(this.isLoopingChkBox);
            this.Controls.Add(this.pathNameTxtBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.applyBtn);
            this.Controls.Add(this.loopingAroundWorldChckBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EditTradeWind";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Edit Trade Wind";
            this.Load += new System.EventHandler(this.EditTradeWind_Load);
            ((System.ComponentModel.ISupportInitialize)(this.InterploationPercTrackBar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox loopingAroundWorldChckBox;
        private System.Windows.Forms.Button applyBtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox pathNameTxtBox;
        private System.Windows.Forms.CheckBox isLoopingChkBox;
        private System.Windows.Forms.CheckBox reverseDirChkBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox widthTxt;
        private System.Windows.Forms.TextBox strengthTxt;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TrackBar InterploationPercTrackBar;
        private System.Windows.Forms.Label InterploationPercLabel;
    }
}