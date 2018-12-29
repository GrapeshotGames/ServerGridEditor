using AtlasGridDataLibrary;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ServerGridEditor.Forms
{
    public partial class EditSpawnerTemplatesForm : Form
    {
        MainForm mainForm;

        public EditSpawnerTemplatesForm(MainForm mainForm)
        {
            this.mainForm = mainForm;
            InitializeComponent();
            foreach (SpawnerInfoData spawnerInfo in mainForm.spawners.spawnersInfo)
            {
                int index = spawnersGrid.Rows.Add();
                spawnersGrid.Rows[index].Cells[templateName.Name].Value = spawnerInfo.Name;
                spawnersGrid.Rows[index].Cells[NPCSpawnEntries.Name].Value = spawnerInfo.NPCSpawnEntries == null ? "" : spawnerInfo.NPCSpawnEntries;
                spawnersGrid.Rows[index].Cells[NPCSpawnLimits.Name].Value = spawnerInfo.NPCSpawnLimits == null ? "" : spawnerInfo.NPCSpawnLimits;
                spawnersGrid.Rows[index].Cells[MaxDesiredNumEnemiesMultiplier.Name].Value = "" + spawnerInfo.MaxDesiredNumEnemiesMultiplier;
            }
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            //Make sure there are no duplicate names
            HashSet<string> names = new HashSet<string>();
            foreach (DataGridViewRow row in spawnersGrid.Rows)
            {
                if (row.Index == spawnersGrid.Rows.Count - 1) continue; //Last row is the new row

                string name = (string)row.Cells[templateName.Name].Value;

                if (names.Contains(name))
                {
                    //Duplicate name
                    MessageBox.Show("Duplicate names found\nTemplate names must be unique", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                names.Add(name);
            }

            foreach (DataGridViewRow row in spawnersGrid.Rows)
            {
                if (row.Index == spawnersGrid.Rows.Count - 1) continue; //Last row is the new row

                float tmp;
                string val = (string)row.Cells[MaxDesiredNumEnemiesMultiplier.Name].Value;
                if (!float.TryParse(val, out tmp))
                {
                    //Invalid multiplier
                    MessageBox.Show(string.Format("Invalid multiplier value {0}", val), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            mainForm.spawners.ClearSpawners();


            foreach (DataGridViewRow row in spawnersGrid.Rows)
            {
                if (row.Index == spawnersGrid.Rows.Count - 1) continue; //Last row is the new row

                string name = (string)row.Cells[templateName.Name].Value;
                string entries = (string)row.Cells[NPCSpawnEntries.Name].Value;
                string limits = (string)row.Cells[NPCSpawnLimits.Name].Value;
                float multiplier = float.Parse((string)row.Cells[MaxDesiredNumEnemiesMultiplier.Name].Value);

                SpawnerInfoData spawnerInfo = new SpawnerInfoData() { Name = name, NPCSpawnEntries = entries, NPCSpawnLimits = limits, MaxDesiredNumEnemiesMultiplier = multiplier };
                mainForm.spawners.AddSpawnerInfo(spawnerInfo);
            }

            mainForm.spawners.SaveToFile(MainForm.spawnersSaveFile);

            Close();
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void spawnersGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
