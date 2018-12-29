using AtlasGridDataLibrary;
using System;
using System.Windows.Forms;

namespace ServerGridEditor.Forms
{
    public partial class EditDiscoveryZoneInstance : Form
    {
        DiscoveryZoneData targetInstance;
        MainForm mainForm;

        public EditDiscoveryZoneInstance(MainForm mainForm, DiscoveryZoneData targetInstance)
        {
            InitializeComponent();
            this.mainForm = mainForm;
            this.targetInstance = targetInstance;
            this.zoneIdTxt.Text = targetInstance.id + "";
            this.zoneNameTxt.Text = targetInstance.name;
            this.zoneSizeXTxt.Text = targetInstance.sizeX + "";
            this.zoneSizeYTxt.Text = targetInstance.sizeY + "";
            this.zoneSizeZTxt.Text = targetInstance.sizeZ + "";
            this.zoneXPTxt.Text = targetInstance.xp + "";
            this.explorerNoteIndexTxt.Text = targetInstance.explorerNoteIndex + "";
            this.allowSeaCheckbox.Checked = targetInstance.allowSea;
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            int.TryParse(zoneIdTxt.Text, out targetInstance.id);
            float.TryParse(zoneSizeYTxt.Text, out targetInstance.sizeY);
            float.TryParse(zoneSizeXTxt.Text, out targetInstance.sizeX);
            float.TryParse(zoneSizeZTxt.Text, out targetInstance.sizeZ);
            targetInstance.name = zoneNameTxt.Text;
            float.TryParse(zoneXPTxt.Text, out targetInstance.xp);
            int.TryParse(explorerNoteIndexTxt.Text, out targetInstance.explorerNoteIndex);
            targetInstance.allowSea = allowSeaCheckbox.Checked;
            mainForm.InvalidateMapPanel();
            Close();
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void zoneIdTxt_KeyPress(object sender, KeyPressEventArgs e)
        {
            StaticHelpers.ForceNumericKeypress(sender, e, false);
        }

        private void zoneXPTxt_KeyPress(object sender, KeyPressEventArgs e)
        {
            StaticHelpers.ForceNumericKeypress(sender, e, false);
        }

        private void zoneXPTxt_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
