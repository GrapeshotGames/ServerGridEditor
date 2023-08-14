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
    public partial class RemoveServerConfiguration : Form
    {
        MainForm mainForm = null;
        public RemoveServerConfiguration(MainForm InMainForm)
        {
            this.mainForm = InMainForm;
            InitializeComponent();
            ParamsGrid.Rows.Clear();
            foreach (ServerConfiguration serverConfiguration in mainForm.currentProject.serverConfigurations)
            {
                ParentServerConfigurationComboBox.Items.Add(serverConfiguration.Key);
            }

            foreach (ServerConfiguration serverConfiguration in mainForm.currentProject.serverConfigurations)
            {
                ServerConfigurationComboBox.Items.Add(serverConfiguration.Key);
            }

            if (ParentServerConfigurationComboBox.Items.Count > 0)
            {
                ServerConfigurationComboBox.SelectedItem = mainForm.currentProject.serverConfigurations[0].Key;
            }
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            string ConfigurationKey = mainForm.currentProject.serverConfigurations[ServerConfigurationComboBox.SelectedIndex].Key;
            mainForm.currentProject.serverConfigurations.RemoveAt(ServerConfigurationComboBox.SelectedIndex);
            DeletAllChilds(ConfigurationKey);
            mainForm.Invalidate();
            Close();
        }

        private void DeletAllChilds(string ConfigurationKey)
        {
            for (int i = 0; i < mainForm.currentProject.serverConfigurations.Count; i++)
            {
                if (mainForm.currentProject.serverConfigurations[i].ParentName == ConfigurationKey)
                {
                    string ClildConfigurationKey = mainForm.currentProject.serverConfigurations[i].Key;
                    mainForm.currentProject.serverConfigurations.RemoveAt(i);
                    DeletAllChilds(ClildConfigurationKey);
                }
            }
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ServerConfigurationComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ParentServerConfigurationComboBox.SelectedItem = null;
            ParentServerConfigurationComboBox.SelectedItem = null;
            ParamsGrid.Rows.Clear();
            foreach (KeyValuePair<string, string> serverConfigurationParam in mainForm.currentProject.serverConfigurations[ServerConfigurationComboBox.SelectedIndex].GameVariable)
            {
                int index = ParamsGrid.Rows.Add();
                ParamsGrid.Rows[index].Cells[0].Value = serverConfigurationParam.Key;
                ParamsGrid.Rows[index].Cells[1].Value = serverConfigurationParam.Value;
            }

            ParentServerConfigurationComboBox.SelectedItem = mainForm.currentProject.serverConfigurations[ServerConfigurationComboBox.SelectedIndex].ParentName;

        }
    }
}
