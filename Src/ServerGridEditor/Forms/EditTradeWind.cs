using AtlasGridDataLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ServerGridEditor.Forms
{
    public partial class EditTradeWind : Form
    {
        public TradeWindData TargetWind;
        public TradeWindNode TargetWindNode;

        public EditTradeWind(TradeWindNode TargetWindNode)
        {
            this.TargetWindNode = TargetWindNode;
            TargetWind = TargetWindNode.tradeWind;
            InitializeComponent();
        }

        private void EditTradeWind_Load(object sender, EventArgs e)
        {
            isLoopingChkBox.Checked = TargetWind.isLooping;
            loopingAroundWorldChckBox.Checked = TargetWind.isLoopingAroundWorld;
            loopingAroundWorldChckBox.Enabled = TargetWind.isLooping;
            reverseDirChkBox.Checked = TargetWind.reverseDir;
            pathNameTxtBox.Text = TargetWind.PathName;
            InterploationPercTrackBar.Value = (int)(TargetWind.StartInterpolatingOceanColorAtPercentage * 100);
            UpdateInterploationPercLabel();

            strengthTxt.Text = TargetWindNode.strength.ToString();
            widthTxt.Text = TargetWindNode.width.ToString();
        }

        private void applyBtn_Click(object sender, EventArgs e)
        {
            float parsedStrength;
            if (!float.TryParse(strengthTxt.Text, out parsedStrength))
            {
                MessageBox.Show("Invalid number for strength", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            float parsedWidth;
            if (!float.TryParse(widthTxt.Text, out parsedWidth))
            {
                MessageBox.Show("Invalid number for width", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            TargetWind.isLooping = isLoopingChkBox.Checked;
            TargetWind.isLoopingAroundWorld = loopingAroundWorldChckBox.Checked;
            TargetWind.reverseDir = reverseDirChkBox.Checked;
            TargetWind.PathName = pathNameTxtBox.Text;
            TargetWind.StartInterpolatingOceanColorAtPercentage = InterploationPercTrackBar.Value / 100.0f;

            TargetWindNode.strength = parsedStrength;
            TargetWindNode.width = parsedWidth;

            Close();
        }

        private void isLoopingChkBox_CheckedChanged(object sender, EventArgs e)
        {
            loopingAroundWorldChckBox.Enabled = isLoopingChkBox.Enabled;
        }

        private void widthTxt_KeyPress(object sender, KeyPressEventArgs e)
        {
            StaticHelpers.ForceNumericKeypress(sender, e);
        }

        private void strengthTxt_KeyPress(object sender, KeyPressEventArgs e)
        {
            StaticHelpers.ForceNumericKeypress(sender, e);
        }

        private void InterploationPercTrackBar_Scroll(object sender, EventArgs e)
        {
            UpdateInterploationPercLabel();
        }


        private void UpdateInterploationPercLabel()
        {
            InterploationPercLabel.Text = InterploationPercTrackBar.Value + "%";
        }
    }
}
