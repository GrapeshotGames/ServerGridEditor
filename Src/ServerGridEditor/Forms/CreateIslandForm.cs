using AtlasGridDataLibrary;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace ServerGridEditor
{
    public partial class CreateIslndForm : Form
    {
        public MainForm mainForm;
        public Island editedIsland;
        
        public bool bIslandNameChanged = false;
        public CreateIslndForm()
        {
            InitializeComponent();
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            foreach (SpawnerInfoData spawnerInfo in mainForm.spawners.spawnersInfo)
                SpawnerTemplate.Items.Add((string)spawnerInfo.Name);

            if (editedIsland != null)
            {
                bIslandNameChanged = false;
                islandNameTxtBox.Text = editedIsland.name;
                pictureBox1.ImageLocation = editedIsland.imagePath;
                sizeXTxtBox.Text = editedIsland.x + "";
                sizeYTxtBox.Text = editedIsland.y + "";
                landscapeMaterialOverrideTxtBox.Text = editedIsland.landscapeMaterialOverride + "";

                if (editedIsland.sublevelNames != null)
                    sublevelsList.Items.AddRange(editedIsland.sublevelNames.ToArray());

                this.Text = "Edit Island";
                createBtn.Text = "Edit";


                if (editedIsland.spawnerOverrides != null)
                    foreach (KeyValuePair<string, string> overrides in editedIsland.spawnerOverrides)
                    {
                        int index = spawnerOverridesGrid.Rows.Add();
                        spawnerOverridesGrid.Rows[index].Cells[SpawnerName.Name].Value = overrides.Key;
                        if (SpawnerTemplate.Items.Contains(overrides.Value))
                            spawnerOverridesGrid.Rows[index].Cells[SpawnerTemplate.Name].Value = overrides.Value;
                    }


                minTreasureQualityTxtBox.Text = editedIsland.minTreasureQuality + "";
                maxTreasureQualityTxtBox.Text = editedIsland.maxTreasureQuality + "";

                useNpcVolumesForTreasuresChkBox.Checked = editedIsland.useNpcVolumesForTreasures;
                useLevelBoundsForTreasuresChkBox.Checked = editedIsland.useLevelBoundsForTreasures;
                prioritizeVolumesForTreasuresChkBox.Checked = editedIsland.prioritizeVolumesForTreasures;
                IslandTreasureBottleSupplyCrateOverridesTxtBox.Text = editedIsland.islandTreasureBottleSupplyCrateOverrides;

                if (editedIsland.extraSublevels != null)
                    extraSublevelsTxtBox.Lines = editedIsland.extraSublevels.ToArray();

                foreach (IslandInstanceData islandInstance in mainForm.currentProject.islandInstances)
                    if(islandInstance.name == editedIsland.name)
                    {
                        Server s = islandInstance.GetCurrentServer(mainForm);
                        if (s != null)
                            instancesListBox.Items.Add(string.Format("({0}, {1})", s.gridX, s.gridY));
                    }
            }
        }

        private void chooseImgBtn_Click(object sender, EventArgs e)
        {
            openFileDialog.Filter = "png files (*.png)|*.png";
            openFileDialog.Multiselect = false;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string fileName = openFileDialog.FileName;
                pictureBox1.ImageLocation = fileName;
            }
        }

        private void sizeXTxtBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            StaticHelpers.ForceNumericKeypress(sender, e);
        }

        private void sizeYTxtBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            StaticHelpers.ForceNumericKeypress(sender, e);
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void createBtn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(islandNameTxtBox.Text))
            {
                MessageBox.Show("Invalid island name", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            float x, y;
            if (!float.TryParse(sizeXTxtBox.Text, out x) || !float.TryParse(sizeYTxtBox.Text, out y))
            {
                MessageBox.Show("Invalid island dimensions", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrEmpty(pictureBox1.ImageLocation))
            {
                MessageBox.Show("Invalid image", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            int landscapeMaterialOverride = -1;
            if (!int.TryParse(landscapeMaterialOverrideTxtBox.Text, out landscapeMaterialOverride))
            {
                MessageBox.Show("Invalid landscape material override index", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //Make sure there are no duplicate names
            HashSet<string> names = new HashSet<string>();
            foreach (DataGridViewRow row in spawnerOverridesGrid.Rows)
            {
                if (row.Index == spawnerOverridesGrid.Rows.Count - 1) continue; //Last row is the new row

                string name = (string)row.Cells[SpawnerName.Name].Value;

                if (names.Contains(name))
                {
                    //Duplicate name
                    MessageBox.Show("Duplicate spawner override names found\nOverride names must be unique", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                names.Add(name);
            }

            foreach (DataGridViewRow row in spawnerOverridesGrid.Rows)
            {
                if (row.Index == spawnerOverridesGrid.Rows.Count - 1) continue; //Last row is the new row

                string val = (string)row.Cells[SpawnerTemplate.Name].Value;
                if (string.IsNullOrEmpty(val))
                {
                    //invalid template
                    MessageBox.Show(string.Format("Template not selected for {0}", (string)row.Cells[SpawnerName.Name].Value), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            float minTreasureQuality = -1;
            float maxTreasureQuality = -1;

            float.TryParse(minTreasureQualityTxtBox.Text, out minTreasureQuality);
            float.TryParse(maxTreasureQualityTxtBox.Text, out maxTreasureQuality);

            if (editedIsland != null)
            {
                if (islandNameTxtBox.Text != editedIsland.name) //name changed
                {
                    if (mainForm.islands.ContainsKey(islandNameTxtBox.Text))
                    {
                        MessageBox.Show("An island with the same name already exist.", "Error", MessageBoxButtons.OK);
                        return;
                    }

                    if (MessageBox.Show("Renaming islands will result in renaming all placed islands in the opened project.\nNote: The editor will not be able to load projects that contained the old name.\nSave?", "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.Cancel)
                        return;

                    //rename all the instances in the current project
                    if (mainForm.currentProject != null)
                    {
                        foreach (IslandInstanceData instance in mainForm.currentProject.islandInstances)
                        {
                            if (instance.name == editedIsland.name)
                                instance.name = islandNameTxtBox.Text;
                        }
                    }

                    mainForm.islands.Remove(editedIsland.name);
                    if (islandNameTxtBox.Text != editedIsland.name)
                    {
                        bIslandNameChanged = true;
                    }
                    editedIsland.name = islandNameTxtBox.Text;
                    mainForm.islands.Add(editedIsland.name, editedIsland);

                    //rename image
                    string newImgPath = MainForm.imgsDir + "/" + editedIsland.name + "_img.jpg";
                    editedIsland.InvalidateImage();
                    File.Move(editedIsland.imagePath, newImgPath);

                    if (pictureBox1.ImageLocation == editedIsland.imagePath)
                        pictureBox1.ImageLocation = newImgPath;

                    editedIsland.imagePath = newImgPath;
                }

                editedIsland.x = x;
                editedIsland.y = y;

                if (pictureBox1.ImageLocation != editedIsland.imagePath) //picture changed
                {
                    editedIsland.InvalidateImage();
                    File.Copy(pictureBox1.ImageLocation, editedIsland.imagePath, true);
                }

                editedIsland.landscapeMaterialOverride = landscapeMaterialOverride;

                editedIsland.sublevelNames = new List<string>(sublevelsList.Items.Cast<string>());


                editedIsland.spawnerOverrides = new Dictionary<string, string>();

                foreach (DataGridViewRow row in spawnerOverridesGrid.Rows)
                {
                    if (row.Index == spawnerOverridesGrid.Rows.Count - 1) continue; //Last row is the new row

                    string name = (string)row.Cells[SpawnerName.Name].Value;
                    string template = (string)row.Cells[SpawnerTemplate.Name].Value;

                    editedIsland.spawnerOverrides.Add(name, template);
                }

                editedIsland.minTreasureQuality = minTreasureQuality;
                editedIsland.maxTreasureQuality = maxTreasureQuality;

                editedIsland.useNpcVolumesForTreasures = useNpcVolumesForTreasuresChkBox.Checked;
                editedIsland.useLevelBoundsForTreasures = useLevelBoundsForTreasuresChkBox.Checked;
                editedIsland.prioritizeVolumesForTreasures = prioritizeVolumesForTreasuresChkBox.Checked;

                editedIsland.islandTreasureBottleSupplyCrateOverrides = IslandTreasureBottleSupplyCrateOverridesTxtBox.Text;

                List<string> NewEntries = new List<string>(extraSublevelsTxtBox.Lines);
                NewEntries.RemoveAll(item => { return string.IsNullOrWhiteSpace(item); });
                editedIsland.extraSublevels = NewEntries;

                mainForm.SaveIslands();
                DialogResult = DialogResult.OK;
                Close();
            }
            else
            {
                string Name = islandNameTxtBox.Text;

                if (mainForm.islands.ContainsKey(Name))
                {
                    MessageBox.Show("Duplicate island name", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                string ImgLocation = pictureBox1.ImageLocation;
                List<string> sublevelNames = new List<string>(sublevelsList.Items.Cast<string>());

                Dictionary<string, string> spawnerOverrides = new Dictionary<string, string>();

                foreach (DataGridViewRow row in spawnerOverridesGrid.Rows)
                {
                    if (row.Index == spawnerOverridesGrid.Rows.Count - 1) continue; //Last row is the new row

                    string name = (string)row.Cells[SpawnerName.Name].Value;
                    string template = (string)row.Cells[SpawnerTemplate.Name].Value;

                    spawnerOverrides.Add(name, template);
                }

                //Copy the image to our local imgs directory
                string newImgPath = MainForm.imgsDir + "/" + Name + "_img.jpg";
                File.Copy(ImgLocation, newImgPath, true);


                mainForm.islands.Add(Name, new Island(Name, x, y, newImgPath, landscapeMaterialOverride, sublevelNames, spawnerOverrides, 
                    minTreasureQuality, maxTreasureQuality, useNpcVolumesForTreasuresChkBox.Checked, useLevelBoundsForTreasuresChkBox.Checked, 
                    prioritizeVolumesForTreasuresChkBox.Checked, IslandTreasureBottleSupplyCrateOverridesTxtBox.Text, new List<string>(extraSublevelsTxtBox.Lines)));

                mainForm.RefreshIslandList();
                mainForm.SaveIslands();

                DialogResult = DialogResult.OK;
                Close();
            }
        }

        private void addSublevels_Click(object sender, EventArgs e)
        {
            openFileDialog.InitialDirectory = Path.GetFullPath(GlobalSettings.Instance.GameSeamlessMapsDir);//mainForm.editorConfig.LastMapsFolder;
            //if (string.IsNullOrEmpty(openFileDialog.InitialDirectory) || !Directory.Exists(openFileDialog.InitialDirectory))
            //{
            //    //revert back to the maps folder defined
            //    openFileDialog.InitialDirectory = Path.GetFullPath(MainForm.gameMapsRelativePath);
            //}

            openFileDialog.Multiselect = true;

            openFileDialog.Filter = "umap files (*.umap)|*.umap";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                //mainForm.editorConfig.LastMapsFolder = Path.GetDirectoryName(openFileDialog.FileName);
                mainForm.SaveConfig();

                foreach (string fileName in openFileDialog.FileNames)
                {
                    string nameWithoutExt = Path.GetFileNameWithoutExtension(fileName);
                    if (!sublevelsList.Items.Contains(nameWithoutExt))
                        sublevelsList.Items.Add(nameWithoutExt);
                }
            }
        }

        private void sublevelsList_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                List<string> selectedItems = new List<string>(sublevelsList.SelectedItems.Cast<string>());

                foreach (string item in selectedItems)
                    sublevelsList.Items.Remove(item);
            }
        }
    }
}
