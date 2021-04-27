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
    public partial class EditServerConfiguration : Form
    {
        MainForm mainForm = null;
        EditServerConfigurations parentEditServerConfiguration = null;
        public EditServerConfiguration(MainForm InMainForm, EditServerConfigurations editServerConfigurations, int SelectedIndex)
        {
            this.mainForm = InMainForm;
            parentEditServerConfiguration = editServerConfigurations;
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

            if (ParentServerConfigurationComboBox.Items.Count > SelectedIndex)
            {
                ServerConfigurationComboBox.SelectedItem = mainForm.currentProject.serverConfigurations[SelectedIndex].Key;
            }
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            if(ParentServerConfigurationComboBox.SelectedIndex == ServerConfigurationComboBox.SelectedIndex)
            {
                MessageBox.Show("Choose different parent.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            mainForm.currentProject.serverConfigurations[ServerConfigurationComboBox.SelectedIndex].ParentName = ParentServerConfigurationComboBox.Text;
            mainForm.currentProject.serverConfigurations[ServerConfigurationComboBox.SelectedIndex].GameVariable.Clear();
            foreach (DataGridViewRow row in ParamsGrid.Rows)
            {
                if (row.Index == ParamsGrid.Rows.Count - 1) continue; //Last row is the new row
                try
                {
                    mainForm.currentProject.serverConfigurations[ServerConfigurationComboBox.SelectedIndex].GameVariable.Add(row.Cells[0].Value.ToString(), row.Cells[1].Value.ToString());
                }
                catch (Exception)
                {
                    MessageBox.Show("Params Must have unique name.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            mainForm.Invalidate();
            parentEditServerConfiguration.InvalidateConfigurations();
            Close();
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            parentEditServerConfiguration.InvalidateConfigurations();
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
