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
    public partial class EditRegionsTreasureMapOverride : Form
    {
        MainForm mainForm;

        public EditRegionsTreasureMapOverride(MainForm mainForm)
        {
            InitializeComponent();
            this.mainForm = mainForm;

            foreach (RegionsTreasureOverride regionsTreasureOverride in mainForm.currentProject.regionsTreasureOverrides)
            {
                int index = ParamsGrid.Rows.Add();
                ParamsGrid.Rows[index].Cells[0].Value = regionsTreasureOverride.Region;
                string RegionList = "";
                for (int i = 0; i < regionsTreasureOverride.RegionOverrides.Count; i++)
                {
                    if (i == 0)
                        RegionList = regionsTreasureOverride.RegionOverrides[i];
                    else
                    {
                        RegionList = string.Concat(RegionList, ",", regionsTreasureOverride.RegionOverrides[i]);
                    }
                }
                ParamsGrid.Rows[index].Cells[1].Value = RegionList;
            }

        }

        private void EditTradeWind_Load(object sender, EventArgs e)
        {

        }

        private void applyBtn_Click(object sender, EventArgs e)
        {
            Save();
            Close();
        }


        private bool Save()
        {

            mainForm.currentProject.regionsTreasureOverrides.Clear();

            foreach (DataGridViewRow row in ParamsGrid.Rows)
            {
                if (row.Index == ParamsGrid.Rows.Count - 1) continue; //Last row is the new row
                try
                {
                    mainForm.currentProject.regionsTreasureOverrides.Add(new RegionsTreasureOverride {  Region = row.Cells[0].Value.ToString(), RegionOverrides = row.Cells[1].Value.ToString().Split(',').ToList() });
                }
                catch (Exception)
                {
                    MessageBox.Show("Params Must have unique name.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }

            mainForm.Invalidate();


            return true;
        }
    }
}
