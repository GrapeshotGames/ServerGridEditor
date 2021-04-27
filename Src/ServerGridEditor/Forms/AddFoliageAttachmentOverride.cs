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
    public partial class AddFoliageAttachmentOverride : Form
    {
        MainForm mainForm = null;
        EditFoliageAttachmentOverrides parentEditFoliageAttachmentOverrides = null;
        public AddFoliageAttachmentOverride(MainForm InMainForm, EditFoliageAttachmentOverrides editFoliageAttachmentOverrides)
        {
            parentEditFoliageAttachmentOverrides = editFoliageAttachmentOverrides;
            this.mainForm = InMainForm;
            InitializeComponent();
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            foreach (FoliageAttachmentOverride _foliageAttachmentOverride in mainForm.currentProject.foliageAttachmentOverrides)
            {
                if(_foliageAttachmentOverride.Key.ToLower() == ServerConfigurationTextBox.Text.ToLower())
                {
                    MessageBox.Show("Configuration name should be unique.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            FoliageAttachmentOverride foliageAttachmentOverride = new FoliageAttachmentOverride();
            foliageAttachmentOverride.Key = ServerConfigurationTextBox.Text;
            
            foreach (DataGridViewRow row in harvestOverridesGrid.Rows)
            {
                if (row.Index == harvestOverridesGrid.Rows.Count - 1) continue; //Last row is the new row
                try
                {
                    if(!foliageAttachmentOverride.FoliageMap.ContainsKey(row.Cells[0].Value.ToString()))
                        foliageAttachmentOverride.FoliageMap.Add(row.Cells[0].Value.ToString(), row.Cells[1].Value.ToString());
                }
                catch (Exception)
                {
                    MessageBox.Show("Params Must have unique name.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            mainForm.currentProject.foliageAttachmentOverrides.Add(foliageAttachmentOverride);
            mainForm.Invalidate();
            Close();
            parentEditFoliageAttachmentOverrides.InvalidateConfigurations();
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            parentEditFoliageAttachmentOverrides.InvalidateConfigurations();
            Close();
        }

        private void ParentServerConfigurationComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void AddFoliageAttachmentOverride_Load(object sender, EventArgs e)
        {

        }

        private void ParamsGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
