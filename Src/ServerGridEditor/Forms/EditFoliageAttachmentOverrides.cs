using AtlasGridDataLibrary;
using System;
using System.IO;
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
    public partial class EditFoliageAttachmentOverrides : Form
    {
        MainForm mainForm;
        public EditFoliageAttachmentOverrides(MainForm mainForm)
        {
            this.mainForm = mainForm;
            InitializeComponent();

            foreach (FoliageAttachmentOverride foliageAttachmentOverride in mainForm.currentProject.foliageAttachmentOverrides)
                templatesLstBox.Items.Add(foliageAttachmentOverride.Key);
        }

        public void InvalidateConfigurations()
        {
            templatesLstBox.Items.Clear();
            foreach (FoliageAttachmentOverride foliageAttachmentOverride in mainForm.currentProject.foliageAttachmentOverrides)
                templatesLstBox.Items.Add(foliageAttachmentOverride.Key);
        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            var addFoliageAttachmentOverride = new AddFoliageAttachmentOverride(mainForm, this);
            addFoliageAttachmentOverride.ShowDialog();
        }

        private void editBtn_Click(object sender, EventArgs e)
        {
            if (templatesLstBox.SelectedItem != null)
            {
                FoliageAttachmentOverride foliageAttachmentOverride = mainForm.currentProject.GetFoliageAttachmentOverrideByName(templatesLstBox.SelectedItem.ToString());
                if (foliageAttachmentOverride != null)
                {
                    var editFoliageAttachmentOverride = new EditFoliageAttachmentOverride(mainForm, this, templatesLstBox.SelectedIndex);
                    editFoliageAttachmentOverride.ShowDialog();
                }
            }
        }

        private void removeBtn_Click(object sender, EventArgs e)
        {
            if (templatesLstBox.SelectedItem != null)
            {
                FoliageAttachmentOverride foliageAttachmentOverride = mainForm.currentProject.GetFoliageAttachmentOverrideByName(templatesLstBox.SelectedItem.ToString());
                if (foliageAttachmentOverride != null)
                {
                    var confirmResult = MessageBox.Show("You are about to delete the selected configuration\n\nAre you sure?",
                                            "Warning",
                                            MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (confirmResult == DialogResult.Yes)
                    {
                        string ConfigurationKey = mainForm.currentProject.foliageAttachmentOverrides[templatesLstBox.SelectedIndex].Key;
                        mainForm.currentProject.foliageAttachmentOverrides.RemoveAt(templatesLstBox.SelectedIndex);
                        InvalidateConfigurations();

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

        private void import_Click(object sender, EventArgs e)
        {
            openFileDialog.Filter = "csv files (*.csv)|*.csv";
            openFileDialog.Multiselect = false;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string fileName = openFileDialog.SafeFileName.Split('.')[0];
                StreamReader CSVReader = new StreamReader(openFileDialog.FileName);

                foreach (FoliageAttachmentOverride _foliageAttachmentOverride in mainForm.currentProject.foliageAttachmentOverrides)
                {
                    if (_foliageAttachmentOverride.Key.ToLower() == fileName.ToLower())
                    {
                        var confirmResult = MessageBox.Show("This foliage override already exists.\n\nAre you sure you want to overwrite the old one ?",
                                          "Warning",
                                          MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                        if (confirmResult == DialogResult.Yes)
                        {
                            mainForm.currentProject.foliageAttachmentOverrides.Remove(_foliageAttachmentOverride);
                            break;

                        }
                        else
                        {
                            return;
                        }
                        // MessageBox.Show("Configuration name should be unique.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        // return;
                      

                    }
                }
       
                FoliageAttachmentOverride foliageAttachmentOverride = new FoliageAttachmentOverride();
                foliageAttachmentOverride.Key = fileName;

                if (CSVReader != null && !CSVReader.EndOfStream)
                {
                    do
                    {
                        String Line = CSVReader.ReadLine();
                        if (Line != null && Line.Length > 0)
                        {
                            String[] Values = Line.Split(',');
                            if (Values.Length >= 2)
                            {
                                if(!foliageAttachmentOverride.FoliageMap.ContainsKey(Values[0]))
                                foliageAttachmentOverride.FoliageMap.Add(Values[0], Values[1]);
                            }
                        }
                    }
                    while (!CSVReader.EndOfStream);
                }
                mainForm.currentProject.foliageAttachmentOverrides.Add(foliageAttachmentOverride);
                mainForm.Invalidate();

                InvalidateConfigurations();
            }
        }
    }
}