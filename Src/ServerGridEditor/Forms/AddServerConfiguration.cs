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
    public partial class AddServerConfiguration : Form
    {
        MainForm mainForm = null;
        EditServerConfigurations parentEditServerConfiguration = null;
        public AddServerConfiguration(MainForm InMainForm, EditServerConfigurations editServerConfiguration)
        {
            parentEditServerConfiguration = editServerConfiguration;
            this.mainForm = InMainForm;
            InitializeComponent();

            foreach (ServerConfiguration serverConfiguration in mainForm.currentProject.serverConfigurations)
            {
                ParentServerConfigurationComboBox.Items.Add(serverConfiguration.Key);
            }
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            foreach (ServerConfiguration _serverConfiguration in mainForm.currentProject.serverConfigurations)
            {
                if(_serverConfiguration.Key.ToLower() == ServerConfigurationTextBox.Text.ToLower())
                {
                    MessageBox.Show("Configuration name should be unique.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            ServerConfiguration serverConfiguration = new ServerConfiguration();
            serverConfiguration.Key = ServerConfigurationTextBox.Text;
            serverConfiguration.ParentName = ParentServerConfigurationComboBox.Text;

            foreach (DataGridViewRow row in ParamsGrid.Rows)
            {
                if (row.Index == ParamsGrid.Rows.Count - 1) continue; //Last row is the new row
                try
                {
                    serverConfiguration.GameVariable.Add(row.Cells[0].Value.ToString(), row.Cells[1].Value.ToString());
                }
                catch (Exception)
                {
                    MessageBox.Show("Params Must have unique name.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            mainForm.currentProject.serverConfigurations.Add(serverConfiguration);
            mainForm.Invalidate();
            Close();
            parentEditServerConfiguration.InvalidateConfigurations();
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            parentEditServerConfiguration.InvalidateConfigurations();
            Close();
        }

        private void ParentServerConfigurationComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
    }
}
