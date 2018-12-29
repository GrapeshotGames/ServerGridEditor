using AtlasGridDataLibrary;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace ServerGridEditor.Forms
{
    public partial class EditSpawnRegions : Form
    {
        MainForm mainForm = null;
        Server ForServer = null;
        public EditSpawnRegions(MainForm InMainForm, Server InServer)
        {
            this.mainForm = InMainForm;
            this.ForServer = InServer;
            InitializeComponent();

            foreach (SpawnRegionData region in mainForm.currentProject.spawnRegions)
            {
                int index = spawnRegionsGrid.Rows.Add();
                spawnRegionsGrid.Rows[index].Cells[regionName.Name].Value = region.name;
                spawnRegionsGrid.Rows[index].Cells[regionParent.Name].Value = region.X + "," + region.Y;
                if (InServer != null && (InServer.gridX != region.X || InServer.gridY != region.Y))
                    spawnRegionsGrid.Rows[index].Visible = false;
            }

            if (ForServer != null)
            {
                messageLabel.Text = messageLabel.Text + ForServer.gridX + "," + ForServer.gridY;
                messageLabel.Visible = true;
            }
            else
                messageLabel.Visible = false;
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            HashSet<string> names = new HashSet<string>();
            foreach (DataGridViewRow row in spawnRegionsGrid.Rows)
            {
                if (row.Index == spawnRegionsGrid.Rows.Count - 1) continue; //Last row is the new row

                if (row.Cells[regionName.Name].Value == null || row.Cells[regionName.Name].Value.ToString().Length == 0)
                {
                    MessageBox.Show("You must assign a unique name to each row", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                string name = row.Cells[regionName.Name].Value.ToString();
                if (names.Contains(name))
                {
                    MessageBox.Show("Duplicate names " + name + " found\nRegion names must be unique across the atlas", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                names.Add(name);
            }

            mainForm.currentProject.spawnRegions.Clear();

            foreach (DataGridViewRow row in spawnRegionsGrid.Rows)
            {
                if (row.Index == spawnRegionsGrid.Rows.Count - 1) continue; //Last row is the new row

                string name = row.Cells[regionName.Name].Value != null ? row.Cells[regionName.Name].Value.ToString() : "";

                int serverX = -1, serverY = -1;
                string parent = row.Cells[regionParent.Name].Value != null ? row.Cells[regionParent.Name].Value.ToString() : "";
                string[] splits = parent.Split(',');
                if (splits.Length == 2)
                {
                    serverX = int.Parse(splits[0]);
                    serverY = int.Parse(splits[1]);
                }
                Server parentServer = mainForm.GetServerByIndex(new Point(serverX, serverY));
                if (parentServer == null)
                {
                    if (ForServer != null)
                    {
                        serverX = ForServer.gridX;
                        serverY = ForServer.gridY;
                    }
                    else
                    {
                        MessageBox.Show("Can't find parent server for region at index: " + row.Index, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }

                SpawnRegionData region = new SpawnRegionData() { name = name, X = serverX, Y = serverY };
                mainForm.currentProject.spawnRegions.Add(region);
            }

            mainForm.Invalidate();
            Close();
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
