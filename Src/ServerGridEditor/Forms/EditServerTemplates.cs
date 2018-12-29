using AtlasGridDataLibrary;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace ServerGridEditor.Forms
{
    public partial class EditServerTemplates : Form
    {
        MainForm mainForm;
        public EditServerTemplates(MainForm mainForm)
        {
            this.mainForm = mainForm;
            InitializeComponent();

            foreach (ServerTemplateData template in mainForm.currentProject.serverTemplates)
                templatesLstBox.Items.Add(template.name);
        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            ServerTemplateData serverTemplate = new ServerTemplateData();

            var editForm = new EditServerTemplate(mainForm, serverTemplate);
            if (editForm.ShowDialog() == DialogResult.OK)
            {
                mainForm.currentProject.serverTemplates.Add(serverTemplate);
                templatesLstBox.Items.Add(serverTemplate.name);
            }
        }

        private void editBtn_Click(object sender, EventArgs e)
        {
            if (templatesLstBox.SelectedItem != null)
            {
                ServerTemplateData serverTemplate = mainForm.currentProject.GetServerTemplateByName(templatesLstBox.SelectedItem.ToString());
                if (serverTemplate != null)
                {
                    string originalName = serverTemplate.name;
                    var editForm = new EditServerTemplate(mainForm, serverTemplate);
                    if (editForm.ShowDialog() == DialogResult.OK)
                    {
                        if (serverTemplate.name != originalName)
                        {
                            templatesLstBox.Items.Remove(originalName);
                            templatesLstBox.Items.Add(serverTemplate.name);
                        }
                    }
                }
            }
        }

        private void removeBtn_Click(object sender, EventArgs e)
        {
            if (templatesLstBox.SelectedItem != null)
            {
                ServerTemplateData serverTemplate = mainForm.currentProject.GetServerTemplateByName(templatesLstBox.SelectedItem.ToString());
                if (serverTemplate != null)
                {
                    var confirmResult = MessageBox.Show("You are about to delete the selected template\n\nAre you sure?",
                                            "Warning",
                                            MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);

                    if (confirmResult == DialogResult.OK)
                    {
                        templatesLstBox.Items.Remove(serverTemplate.name);
                        mainForm.currentProject.serverTemplates.Remove(serverTemplate);
                    }

                }
            }
        }

        private void templatesLstBox_DrawItem(object sender, DrawItemEventArgs e)
        {
            e.DrawBackground();
            Graphics g = e.Graphics;

            // draw the background color you want
            // mine is set to olive, change it to whatever you want
            //g.FillRectangle(new SolidBrush(Color.White), e.Bounds);

            // draw the text of the list item, not doing this will only show
            // the background color
            // you will need to get the text of item to display

            if (e.Index != -1)
            {
                ServerTemplateData template = mainForm.currentProject.GetServerTemplateByName(templatesLstBox.Items[e.Index].ToString());
                if (template != null)
                    g.DrawString(templatesLstBox.Items[e.Index].ToString(), e.Font, new SolidBrush(template.GetTemplateColor()),
                        new PointF(e.Bounds.X, e.Bounds.Y));
                else
                    g.DrawString(templatesLstBox.Items[e.Index].ToString(), e.Font, new SolidBrush(e.ForeColor), new PointF(e.Bounds.X, e.Bounds.Y));
            }

            e.DrawFocusRectangle();
        }
    }
}