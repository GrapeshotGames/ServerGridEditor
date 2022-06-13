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
    public partial class EditServerSpoolGroups : Form
    {
        MainForm mainForm;

        public EditServerSpoolGroups(MainForm mainForm)
        {
            InitializeComponent();
            this.mainForm = mainForm;
            if (mainForm.currentProject.serverSpoolGroups != null)
                foreach (AtlasGridDataLibrary.SpoolGroup spoolGroup in mainForm.currentProject.serverSpoolGroups)
                {
                    int index = ParamsGrid.Rows.Add();
                    ParamsGrid.Rows[index].Cells[0].Value = spoolGroup.GroupName;
                    ParamsGrid.Rows[index].Cells[1].Value = spoolGroup.BuffToApply;
                }
        }

        private void applyBtn_Click(object sender, EventArgs e)
        {
            Save();
            Close();
        }


        private bool Save()
        {
            if (mainForm.currentProject.serverSpoolGroups == null)
                mainForm.currentProject.serverSpoolGroups = new List<AtlasGridDataLibrary.SpoolGroup>();
            mainForm.currentProject.serverSpoolGroups.Clear();
            foreach (DataGridViewRow row in ParamsGrid.Rows)
            {
                if (row.Index == ParamsGrid.Rows.Count - 1) continue; //Last row is the new row
                try
                {
                    mainForm.currentProject.serverSpoolGroups.Add(new AtlasGridDataLibrary.SpoolGroup { GroupName = row.Cells[0].Value.ToString(), BuffToApply = row.Cells[1].Value.ToString() });
                }
                catch (Exception)
                {
                    MessageBox.Show("Group names must be unique.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }

            mainForm.Invalidate();


            return true;
        }
    }
}
