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
    public partial class EditServerConfigurations : Form
    {
        MainForm mainForm;
        public EditServerConfigurations(MainForm mainForm)
        {
            this.mainForm = mainForm;
            InitializeComponent();

            foreach (ServerConfiguration serverConfiguration in mainForm.currentProject.serverConfigurations)
                templatesLstBox.Items.Add(serverConfiguration.Key);
        }

        public void InvalidateConfigurations()
        {
            templatesLstBox.Items.Clear();
            foreach (ServerConfiguration serverConfiguration in mainForm.currentProject.serverConfigurations)
                templatesLstBox.Items.Add(serverConfiguration.Key);
        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            var addServerConfiguration = new AddServerConfiguration(mainForm, this);
            addServerConfiguration.ShowDialog();
        }

        private void editBtn_Click(object sender, EventArgs e)
        {
            if (templatesLstBox.SelectedItem != null)
            {
                ServerConfiguration serverConfiguration = mainForm.currentProject.GetServerConfigurationByName(templatesLstBox.SelectedItem.ToString());
                if (serverConfiguration != null)
                {
                    var editServerConfiguration = new EditServerConfiguration(mainForm, this, templatesLstBox.SelectedIndex);
                    editServerConfiguration.ShowDialog();
                }
            }
        }

        private void removeBtn_Click(object sender, EventArgs e)
        {
            if (templatesLstBox.SelectedItem != null)
            {
                ServerConfiguration serverConfiguration = mainForm.currentProject.GetServerConfigurationByName(templatesLstBox.SelectedItem.ToString());
                if (serverConfiguration != null)
                {
                    var confirmResult = MessageBox.Show("You are about to delete the selected configuration\n\nAre you sure?",
                                            "Warning",
                                            MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (confirmResult == DialogResult.Yes)
                    {
                        string ConfigurationKey = mainForm.currentProject.serverConfigurations[templatesLstBox.SelectedIndex].Key;
                        mainForm.currentProject.serverConfigurations.RemoveAt(templatesLstBox.SelectedIndex);
                        DeletAllChilds(ConfigurationKey);
                        InvalidateConfigurations();
                        Invalidate();
                    }
                }
            }
        }

        private void templatesLstBox_DrawItem(object sender, DrawItemEventArgs e)
        {
            e.DrawBackground();
            Graphics g = e.Graphics;


            e.DrawFocusRectangle();
        }

        private void EditServerConfigurations_Load(object sender, EventArgs e)
        {

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
    }
}