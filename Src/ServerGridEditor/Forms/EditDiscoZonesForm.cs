using AtlasGridDataLibrary;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace ServerGridEditor.Forms
{
    public partial class EditDiscoZonesForm : Form
    {
        MainForm mainForm;

        public EditDiscoZonesForm(MainForm mainForm, Server SpecificServer = null)
        {
            this.mainForm = mainForm;
            InitializeComponent();

            foreach (DiscoveryZoneData discoZone in mainForm.currentProject.discoZones)
            {
                int index = discoZonesGrid.Rows.Add();
                discoZonesGrid.Rows[index].Cells[zoneName.Name].Value = discoZone.name;
                discoZonesGrid.Rows[index].Cells[zoneId.Name].Value = discoZone.id;
                discoZonesGrid.Rows[index].Cells[zoneSizeX.Name].Value = discoZone.sizeX;
                discoZonesGrid.Rows[index].Cells[zoneSizeY.Name].Value = discoZone.sizeY;
                discoZonesGrid.Rows[index].Cells[zoneSizeZ.Name].Value = discoZone.sizeZ;
                discoZonesGrid.Rows[index].Cells[zoneXP.Name].Value = discoZone.xp;
                discoZonesGrid.Rows[index].Cells[LocX.Name].Value = discoZone.worldX;
                discoZonesGrid.Rows[index].Cells[LocY.Name].Value = discoZone.worldY;
                discoZonesGrid.Rows[index].Cells[zoneRotation.Name].Value = discoZone.rotation;
                discoZonesGrid.Rows[index].Cells[IsManual.Name].Value = discoZone.bIsManuallyPlaced;
                discoZonesGrid.Rows[index].Cells[ExplorerNoteIndex.Name].Value = discoZone.explorerNoteIndex;
                discoZonesGrid.Rows[index].Cells[allowSea.Name].Value = discoZone.allowSea;
                discoZonesGrid.Rows[index].Cells[zoneManualName.Name].Value = discoZone.ManualVolumeName;
                foreach (Server serv in mainForm.currentProject.servers)
                    if (serv != null && serv.IsWorldPointInServer(new System.Drawing.PointF(discoZone.worldX, discoZone.worldY), mainForm.currentProject.cellSize))
                    {
                        discoZonesGrid.Rows[index].Cells[zoneParent.Name].Value = serv.gridX + "," + serv.gridY;
                        break;
                    }

                if (SpecificServer != null && !SpecificServer.IsWorldPointInServer(new System.Drawing.PointF(discoZone.worldX, discoZone.worldY), mainForm.currentProject.cellSize))
                    discoZonesGrid.Rows[index].Visible = false;
            }
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            //Make sure there are no duplicate ids
            HashSet<int> ids = new HashSet<int>();
            foreach (DataGridViewRow row in discoZonesGrid.Rows)
            {
                if (row.Index == discoZonesGrid.Rows.Count - 1) continue; //Last row is the new row

                int id = -1;
                if(row.Cells[zoneId.Name].Value == null || !int.TryParse(row.Cells[zoneId.Name].Value.ToString(), out id))
                {
                    MessageBox.Show("You must assign a unique numeric only id to each row", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (ids.Contains(id))
                {
                    MessageBox.Show("Duplicate ids " + id + " found\nZone ids must be unique across the atlas", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                ids.Add(id);
            }

            mainForm.currentProject.discoZones.Clear();

            foreach (DataGridViewRow row in discoZonesGrid.Rows)
            {
                if (row.Index == discoZonesGrid.Rows.Count - 1) continue; //Last row is the new row

                string name = row.Cells[zoneName.Name].Value != null ? row.Cells[zoneName.Name].Value.ToString() : "";

                int id = -1;
                int.TryParse(row.Cells[zoneId.Name].Value.ToString(), out id);

                float worldX = 0.0f;
                if (row.Cells[LocX.Name].Value != null)
                    float.TryParse(row.Cells[LocX.Name].Value.ToString(), out worldX);

                float worldY = 0.0f;
                if (row.Cells[LocY.Name].Value != null)
                    float.TryParse(row.Cells[LocY.Name].Value.ToString(), out worldY);

                float sizeX = 0.0f;
                if (row.Cells[zoneSizeX.Name].Value != null)
                    float.TryParse(row.Cells[zoneSizeX.Name].Value.ToString(), out sizeX);

                float sizeY = 0.0f;
                if (row.Cells[zoneSizeY.Name].Value != null)
                    float.TryParse(row.Cells[zoneSizeY.Name].Value.ToString(), out sizeY);

                float sizeZ = 0.0f;
                if (row.Cells[zoneSizeZ.Name].Value != null)
                    float.TryParse(row.Cells[zoneSizeZ.Name].Value.ToString(), out sizeZ);
                
                float rotation = 0.0f;
                if (row.Cells[zoneRotation.Name].Value != null)
                    float.TryParse(row.Cells[zoneRotation.Name].Value.ToString(), out rotation);

                float xp = 0.0f;
                if (row.Cells[zoneXP.Name].Value != null)
                    float.TryParse(row.Cells[zoneXP.Name].Value.ToString(), out xp);

                string manualZoneName = row.Cells[zoneManualName.Name].Value != null? row.Cells[zoneManualName.Name].Value.ToString() : "";
                bool bAllowSea = row.Cells[allowSea.Name].Value != null ? (bool)row.Cells[allowSea.Name].Value : false;
                bool bIsManual = row.Cells[IsManual.Name].Value != null? (bool)row.Cells[IsManual.Name].Value : false;
                if (manualZoneName.Length == 0 && bIsManual)
                {
                    MessageBox.Show("Empty manual zone name at index: " + row.Index.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (bIsManual) //Put the zone in the correct server's center
                {
                    int serverX = -1, serverY = -1;
                    string parent = row.Cells[zoneParent.Name].Value != null? row.Cells[zoneParent.Name].Value.ToString() : "";
                    string[] splits = parent.Split(',');
                    if(splits.Length == 2)
                    {
                        serverX = int.Parse(splits[0]);
                        serverY = int.Parse(splits[1]);
                    }
                    Server parentServer = mainForm.GetServerByIndex(new Point(serverX, serverY));
                    if (parentServer == null)
                    {
                        MessageBox.Show("Can't find parent server for manual discovery zone: " + manualZoneName, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    else
                    {
                        worldX = parentServer.GetWorldRect(mainForm.currentProject.cellSize).X + parentServer.GetWorldRect(mainForm.currentProject.cellSize).Width / 2;
                        worldY = parentServer.GetWorldRect(mainForm.currentProject.cellSize).Y + parentServer.GetWorldRect(mainForm.currentProject.cellSize).Height / 2;
                    }
                }

                int explorerNoteIndex = -1;
                if (row.Cells[zoneRotation.Name].Value != null)
                    int.TryParse(row.Cells[ExplorerNoteIndex.Name].Value.ToString(), out explorerNoteIndex);

                DiscoveryZoneData discoZone = new DiscoveryZoneData().SetFrom(name, worldX, worldY, sizeX, sizeY, rotation, id);
                discoZone.xp = xp;
                discoZone.sizeZ = sizeZ;
                discoZone.bIsManuallyPlaced = bIsManual;
                discoZone.allowSea = bAllowSea;
                discoZone.ManualVolumeName = manualZoneName;
                discoZone.explorerNoteIndex = explorerNoteIndex;
                mainForm.currentProject.discoZones.Add(discoZone);
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
