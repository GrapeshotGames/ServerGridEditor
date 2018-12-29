using System;
using System.Windows.Forms;

namespace ServerGridEditor.Forms
{
    public partial class LocksForm : Form
    {
        MainForm mainForm;
        Server targetServer;
        public LocksForm(MainForm mainForm, Server targetServer)
        {
            this.mainForm = mainForm;
            this.targetServer = targetServer;

            InitializeComponent();
        }

        private void LocksForm_Load(object sender, EventArgs e)
        {
            lockIslandsChkbox.Checked = targetServer.islandLocked;
            lockDiscoChckbox.Checked = targetServer.discoLocked;
            lockShipPathsChckbox.Checked = targetServer.pathsLocked;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            targetServer.islandLocked = lockIslandsChkbox.Checked;
            targetServer.discoLocked = lockDiscoChckbox.Checked;
            targetServer.pathsLocked = lockShipPathsChckbox.Checked;
            Close();
        }
    }
}
