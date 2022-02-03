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
    public partial class EditRegionsTemplates : Form
    {
        MainForm mainForm;

        public EditRegionsTemplates(MainForm mainForm)
        {
            InitializeComponent();
            this.mainForm = mainForm;

            templatesLstBox.Items.Clear();
            foreach (RegionTemplateData regionTemplateData in mainForm.currentProject.regionTemplates)
            {
                templatesLstBox.Items.Add(regionTemplateData.name);
            }
        }

        private void editBtn_Click(object sender, EventArgs e)
        {
            if (templatesLstBox.SelectedItem != null)
            {
                RegionTemplateData regionTemplateData = mainForm.currentProject.GetRegionTemplateByName(templatesLstBox.SelectedItem.ToString());
                if (regionTemplateData != null)
                {
                    string originalName = regionTemplateData.name;
                    var editForm = new EditRegionTemplate(mainForm, regionTemplateData);
                    if (editForm.ShowDialog() == DialogResult.OK)
                    {
                        if (regionTemplateData.name != originalName)
                        {
                            templatesLstBox.Items.Remove(originalName);
                            templatesLstBox.Items.Add(regionTemplateData.name);
                        }
                    }
                }
            }
        }
        
        private void addBtn_Click_1(object sender, EventArgs e)
        {
            RegionTemplateData serverTemplate = new RegionTemplateData();
            serverTemplate.name = "Unnamed Region Template";
            var editForm = new EditRegionTemplate(mainForm, serverTemplate);
            if (editForm.ShowDialog() == DialogResult.OK)
            {
                mainForm.currentProject.regionTemplates.Add(serverTemplate);
                templatesLstBox.Items.Add(serverTemplate.name);
            }
        }

        private void removeBtn_Click_1(object sender, EventArgs e)
        {
            if (templatesLstBox.SelectedItem != null)
            {
                RegionTemplateData regionTemplateData = mainForm.currentProject.GetRegionTemplateByName(templatesLstBox.SelectedItem.ToString());
                if (regionTemplateData != null)
                {
                    var confirmResult = MessageBox.Show("You are about to delete the selected template\n\nAre you sure?",
                                            "Warning",
                                            MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (confirmResult == DialogResult.Yes)
                    {
                        templatesLstBox.Items.Remove(regionTemplateData.name);
                        mainForm.currentProject.regionTemplates.Remove(regionTemplateData);
                    }

                }
            }
        }
    }
}