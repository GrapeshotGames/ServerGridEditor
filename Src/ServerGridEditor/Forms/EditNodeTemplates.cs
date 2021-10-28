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
    public partial class EditNodeTemplates : Form
    {
        MainForm mainForm;
        public EditNodeTemplates(MainForm mainForm)
        {
            this.mainForm = mainForm;
            InitializeComponent();

            foreach (TransientNodeTemplate template in mainForm.currentProject.transientNodeTemplates)
                templatesLstBox.Items.Add(template.Key);
        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            TransientNodeTemplate Template = new TransientNodeTemplate();

            var editForm = new EditNodeTemplate(mainForm, Template);
            if (editForm.ShowDialog() == DialogResult.OK)
            {
                mainForm.currentProject.transientNodeTemplates.Add(Template);
                templatesLstBox.Items.Add(Template.Key);
            }
            InvalidateConfigurations();
        }

        private void editBtn_Click(object sender, EventArgs e)
        {
            if (templatesLstBox.SelectedItem != null)
            {
                TransientNodeTemplate Template = mainForm.currentProject.GetTransientNodeTemplateByName(templatesLstBox.SelectedItem.ToString());
                if (Template != null)
                {
                    string originalName = Template.Key;
                    var editForm = new EditNodeTemplate(mainForm, Template);
                    if (editForm.ShowDialog() == DialogResult.OK)
                    {
                        if (Template.Key != originalName)
                        {
                            templatesLstBox.Items.Remove(originalName);
                            templatesLstBox.Items.Add(Template.Key);
                        }
                    }
                }
            }

            InvalidateConfigurations();
        }

        private void removeBtn_Click(object sender, EventArgs e)
        {
            if (templatesLstBox.SelectedItem != null)
            {
                TransientNodeTemplate transientNodeTemplate = mainForm.currentProject.GetTransientNodeTemplateByName(templatesLstBox.SelectedItem.ToString());
                if (transientNodeTemplate != null)
                {
                    var confirmResult = MessageBox.Show("You are about to delete the selected template\n\nAre you sure?",
                                            "Warning",
                                            MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (confirmResult == DialogResult.Yes)
                    {
                        templatesLstBox.Items.Remove(transientNodeTemplate.Key);
                        mainForm.currentProject.transientNodeTemplates.Remove(transientNodeTemplate);
                    }

                }
            }
        }

        private void EditNodeTemplates_Load(object sender, EventArgs e)
        {

        }

        public void InvalidateConfigurations()
        {
            templatesLstBox.Items.Clear();
            foreach (TransientNodeTemplate template in mainForm.currentProject.transientNodeTemplates)
                templatesLstBox.Items.Add(template.Key);
        }
    }
}