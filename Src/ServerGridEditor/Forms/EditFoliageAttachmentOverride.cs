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
    public partial class EditFoliageAttachmentOverride : Form
    {
        MainForm mainForm = null;
        EditFoliageAttachmentOverrides parentEditFoliageAttachmentOverride = null;
        public EditFoliageAttachmentOverride(MainForm InMainForm, EditFoliageAttachmentOverrides editFoliageAttachmentOverrides, int SelectedIndex)
        {
            this.mainForm = InMainForm;
            parentEditFoliageAttachmentOverride = editFoliageAttachmentOverrides;
            InitializeComponent();
            harvestOverridesGrid.Rows.Clear();
           
            foreach (FoliageAttachmentOverride foliageAttachmentOverride in mainForm.currentProject.foliageAttachmentOverrides)
            {
                ServerConfigurationComboBox.Items.Add(foliageAttachmentOverride.Key);
            }
            ServerConfigurationComboBox.SelectedItem = mainForm.currentProject.foliageAttachmentOverrides[SelectedIndex].Key;
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            mainForm.currentProject.foliageAttachmentOverrides[ServerConfigurationComboBox.SelectedIndex].FoliageMap.Clear();
            foreach (DataGridViewRow row in harvestOverridesGrid.Rows)
            {
                if (row.Index == harvestOverridesGrid.Rows.Count - 1) continue; //Last row is the new row
                try
                {
                    if (!mainForm.currentProject.foliageAttachmentOverrides[ServerConfigurationComboBox.SelectedIndex].FoliageMap.ContainsKey(row.Cells[0].Value.ToString()))
                        mainForm.currentProject.foliageAttachmentOverrides[ServerConfigurationComboBox.SelectedIndex].FoliageMap.Add(row.Cells[0].Value.ToString(), row.Cells[1].Value.ToString());
                }
                catch (Exception)
                {
                    MessageBox.Show("Params Must have unique name.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            mainForm.Invalidate();
            parentEditFoliageAttachmentOverride.InvalidateConfigurations();
            Close();
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            parentEditFoliageAttachmentOverride.InvalidateConfigurations();
            Close();
        }

        private void ServerConfigurationComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            harvestOverridesGrid.Rows.Clear();
            foreach (KeyValuePair<string, string> serverConfigurationParam in mainForm.currentProject.foliageAttachmentOverrides[ServerConfigurationComboBox.SelectedIndex].FoliageMap)
            {
                int index = harvestOverridesGrid.Rows.Add();
                harvestOverridesGrid.Rows[index].Cells[0].Value = serverConfigurationParam.Key;
                harvestOverridesGrid.Rows[index].Cells[1].Value = serverConfigurationParam.Value;
                harvestOverridesGrid.Rows[index].Cells[1].ToolTipText = serverConfigurationParam.Value;
            }
            //harvestOverridesGrid.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            //harvestOverridesGrid.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            //// Now that DataGridView has calculated it's Widths; we can now store each column Width values.
            //for (int i = 0; i <= harvestOverridesGrid.Columns.Count - 1; i++)
            //{
            //    // Store Auto Sized Widths:
            //    int colw = harvestOverridesGrid.Columns[i].Width;

            //    // Remove AutoSizing:
            //    harvestOverridesGrid.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;

            //    // Set Width to calculated AutoSize value:
            //    harvestOverridesGrid.Columns[i].Width = colw;
            //}
        }
    }
}
