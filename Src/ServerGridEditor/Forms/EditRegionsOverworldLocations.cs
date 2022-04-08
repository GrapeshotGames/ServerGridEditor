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
    public partial class EditRegionsOverworldLocations : Form
    {
        MainForm mainForm;

        public EditRegionsOverworldLocations(MainForm mainForm)
        {
            InitializeComponent();
            this.mainForm = mainForm;

            foreach (RegionsOverworldLocation regionsOverworldLocation in mainForm.currentProject.regionsOverworldLocations)
            {
                int index = ParamsGrid.Rows.Add();
                ParamsGrid.Rows[index].Cells[0].Value = regionsOverworldLocation.RegionName;
                ParamsGrid.Rows[index].Cells[1].Value = regionsOverworldLocation.RegionDescription;
                ParamsGrid.Rows[index].Cells[2].Value = regionsOverworldLocation.X;
                ParamsGrid.Rows[index].Cells[3].Value = regionsOverworldLocation.Y;

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

            mainForm.currentProject.regionsOverworldLocations.Clear();

            foreach (DataGridViewRow row in ParamsGrid.Rows)
            {
                if (row.Index == ParamsGrid.Rows.Count - 1) continue; //Last row is the new row
                try
                {
                    mainForm.currentProject.regionsOverworldLocations.Add(new RegionsOverworldLocation {  RegionName = row.Cells[0].Value.ToString(), X = float.Parse(row.Cells[2].Value.ToString()), Y = float.Parse(row.Cells[3].Value.ToString()), RegionDescription = row.Cells[1].Value.ToString() });
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
