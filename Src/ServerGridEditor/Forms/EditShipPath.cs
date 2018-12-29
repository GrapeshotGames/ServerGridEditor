using AtlasGridDataLibrary;
using System;
using System.Windows.Forms;

namespace ServerGridEditor.Forms
{
    public partial class EditShipPath : Form
    {
        public ShipPathData TargetPath;

        public EditShipPath(ShipPathData TargetPath)
        {
            this.TargetPath = TargetPath;
            InitializeComponent();
        }

        private void EditShipPath_Load(object sender, EventArgs e)
        {
            loopingPathChckBox.Checked = TargetPath.isLooping;
            pathNameTxtBox.Text = TargetPath.PathName;
            autoSpawnChckBox.Checked = TargetPath.autoSpawn;
            autoSpawnShipClassTxtBox.Text = TargetPath.AutoSpawnShipClass;
            autoSpawnEveryUTCIntervalTxtBox.Text = TargetPath.AutoSpawnEveryUTCInterval + "";
        }

        private void applyBtn_Click(object sender, EventArgs e)
        {
            TargetPath.isLooping = loopingPathChckBox.Checked;
            TargetPath.PathName = pathNameTxtBox.Text;
            if (!int.TryParse(autoSpawnEveryUTCIntervalTxtBox.Text, out TargetPath.AutoSpawnEveryUTCInterval))
            {
                MessageBox.Show("Invalid number for AutoSpawnEveryUTCInterval", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.Cancel;
                return;
            }
            TargetPath.AutoSpawnShipClass = autoSpawnShipClassTxtBox.Text;
            TargetPath.autoSpawn = autoSpawnChckBox.Checked;
            Close();
        }

        private void autoSpawnShipClass_KeyPress(object sender, KeyPressEventArgs e)
        {
            StaticHelpers.ForceNumericKeypress(sender, e, false);
        }
    }
}
