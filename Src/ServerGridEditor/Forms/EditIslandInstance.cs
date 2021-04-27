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
    public partial class EditIslandInstance : Form
    {
        IslandInstanceData targetInstance;
        MainForm mainForm;

        public EditIslandInstance(MainForm mainForm, IslandInstanceData targetInstance)
        {
            this.mainForm = mainForm;
            this.targetInstance = targetInstance;
            InitializeComponent();

            targetInstance.SyncOverridesWithTemplates(mainForm);

            foreach (SpawnerInfoData spawnerInfo in mainForm.spawners.spawnersInfo)
                SpawnerTemplate.Items.Add((string)spawnerInfo.Name);

            foreach (FoliageAttachmentOverride foliageAttachmentOverride in mainForm.currentProject.foliageAttachmentOverrides)
                FoliageOverrideKey.Items.Add(foliageAttachmentOverride.Key);

            spawnPointRegionOverrideTxtBox.Text = targetInstance.spawnPointRegionOverride.ToString();
            finalNPCLevelMultiplierTxtBox.Text = (targetInstance.finalNPCLevelMultiplier == 1.0f) ? "1.0" :targetInstance.finalNPCLevelMultiplier.ToString();
            finalNPCLevelOffsetTxtBox.Text = targetInstance.finalNPCLevelOffset.ToString();
            instanceTreasureQualityMultiplierTxtBox.Text = (targetInstance.instanceTreasureQualityMultiplier == 1.0f) ? "1.0" : targetInstance.instanceTreasureQualityMultiplier.ToString();
            instanceTreasureQualityAdditionTxtBox.Text = (targetInstance.instanceTreasureQualityAddition == 0.0f) ? "0.0" : targetInstance.instanceTreasureQualityAddition.ToString();
            IslandInstanceCustomDatas1TxtBox.Text = targetInstance.IslandInstanceCustomDatas1;
            IslandInstanceCustomDatas2TxtBox.Text = targetInstance.IslandInstanceCustomDatas2;
            IslandInstanceClientCustomDatas1TxtBox.Text = targetInstance.IslandInstanceClientCustomDatas1;
            IslandInstanceClientCustomDatas2TxtBox.Text = targetInstance.IslandInstanceClientCustomDatas2;

            if (targetInstance.spawnerOverrides != null)
            {
                foreach (KeyValuePair<string, string> overrides in targetInstance.spawnerOverrides)
                {
                    int index = spawnerOverridesGrid.Rows.Add();
                    spawnerOverridesGrid.Rows[index].Cells[SpawnerName.Name].Value = overrides.Key;
                    if (SpawnerTemplate.Items.Contains(overrides.Value))
                        spawnerOverridesGrid.Rows[index].Cells[SpawnerTemplate.Name].Value = overrides.Value;
                }
            }

            if (targetInstance.harvestOverrideKeys != null)
            {
                foreach (string harvestOverrideKey in targetInstance.harvestOverrideKeys)
                {
                    int index = harvestOverridesGrid.Rows.Add();
                    harvestOverridesGrid.Rows[index].Cells[FoliageOverrideKey.Name].Value = harvestOverrideKey;
                }
            }
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            int NewspawnPointRegionOverride = -1;
            if (!int.TryParse(spawnPointRegionOverrideTxtBox.Text, out NewspawnPointRegionOverride))
            {
                MessageBox.Show("Invalid number for spawnPointRegionOverride", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.Cancel;
                return;
            }
            float NewfinalNPCLevelMultiplier = 1.0f;
            if (!float.TryParse(finalNPCLevelMultiplierTxtBox.Text, out NewfinalNPCLevelMultiplier))
            {
                MessageBox.Show("Invalid number for finalNPCLevelMultiplier", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.Cancel;
                return;
            }
            int NewfinalNPCLevelOffset = 0;
            if (!int.TryParse(finalNPCLevelOffsetTxtBox.Text, out NewfinalNPCLevelOffset))
            {
                MessageBox.Show("Invalid number for finalNPCLevelOffset", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.Cancel;
                return;
            }

            float NewinstanceTreasureQualityMultiplier = 1.0f;
            if (!float.TryParse(instanceTreasureQualityMultiplierTxtBox.Text, out NewinstanceTreasureQualityMultiplier))
            {
                MessageBox.Show("Invalid number for instanceTreasureQualityMultiplier", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.Cancel;
                return;
            }
            float NewinstanceTreasureQualityAddition = 1.0f;
            if (!float.TryParse(instanceTreasureQualityAdditionTxtBox.Text, out NewinstanceTreasureQualityAddition))
            {
                MessageBox.Show("Invalid number for instanceTreasureQualityAddition", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.Cancel;
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
                    MessageBox.Show("Duplicate names found\nOverride names must be unique", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

            targetInstance.spawnPointRegionOverride = NewspawnPointRegionOverride;
            targetInstance.finalNPCLevelMultiplier = NewfinalNPCLevelMultiplier;
            targetInstance.finalNPCLevelOffset = NewfinalNPCLevelOffset;
            targetInstance.instanceTreasureQualityMultiplier = NewinstanceTreasureQualityMultiplier;
            targetInstance.instanceTreasureQualityAddition = NewinstanceTreasureQualityAddition;
            targetInstance.IslandInstanceCustomDatas1 = IslandInstanceCustomDatas1TxtBox.Text;
            targetInstance.IslandInstanceCustomDatas2 = IslandInstanceCustomDatas2TxtBox.Text;
            targetInstance.IslandInstanceClientCustomDatas1 = IslandInstanceClientCustomDatas1TxtBox.Text;
            targetInstance.IslandInstanceClientCustomDatas2 = IslandInstanceClientCustomDatas2TxtBox.Text;
            targetInstance.spawnerOverrides = new Dictionary<string, string>();
            foreach (DataGridViewRow row in spawnerOverridesGrid.Rows)
            {
                if (row.Index == spawnerOverridesGrid.Rows.Count - 1) continue; //Last row is the new row

                string name = (string)row.Cells[SpawnerName.Name].Value;
                string template = (string)row.Cells[SpawnerTemplate.Name].Value;

                targetInstance.spawnerOverrides.Add(name, template);
            }

            if (targetInstance.harvestOverrideKeys == null)
                targetInstance.harvestOverrideKeys = new List<string>();
            foreach (DataGridViewRow row in harvestOverridesGrid.Rows)
            {
                if (row.Index == harvestOverridesGrid.Rows.Count - 1) continue; //Last row is the new row
                string foliageOverrideKey = (string)row.Cells[FoliageOverrideKey.Name].Value;
                if (!targetInstance.harvestOverrideKeys.Contains(foliageOverrideKey))
                    targetInstance.harvestOverrideKeys.Add(foliageOverrideKey);
            }
            Close();
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ImportHarvestOverridesButton_Click(object sender, EventArgs e)
        {
            /*openFileDialog.Filter = "csv files (*.csv)|*.csv";
            openFileDialog.Multiselect = false;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string fileName = openFileDialog.FileName;
                StreamReader CSVReader = new StreamReader(openFileDialog.FileName);
                if (CSVReader != null && !CSVReader.EndOfStream)
                {
                    harvestOverridesGrid.Rows.Clear();
                    do
                    {
                        String Line = CSVReader.ReadLine();
                        if (Line != null && Line.Length > 0)
                        {
                            String[] Values = Line.Split(',');
                            if (Values.Length >= 2)
                            {
                                int index = harvestOverridesGrid.Rows.Add();
                                harvestOverridesGrid.Rows[index].Cells[FoliageTypeName.Name].Value = Values[0];
                                harvestOverridesGrid.Rows[index].Cells[OverrideActorComponentName.Name].Value = Values[1];
                            }
                        }
                    }
                    while (!CSVReader.EndOfStream);
                }

            }*/
        }

        private void ExportHarvestOverridesButton_Click(object sender, EventArgs e)
        {
            /*saveFileDialog.Filter = "csv files (*.csv)|*.csv";
            string ExportPath = Path.GetFullPath(GlobalSettings.Instance.ExportDir);
            if (!Directory.Exists(ExportPath))
                Directory.CreateDirectory(ExportPath);
            saveFileDialog.InitialDirectory = ExportPath;
            saveFileDialog.FileName = "harvestoverrrides.csv";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string fileName = saveFileDialog.FileName;
                StreamWriter CSVWriter = new StreamWriter(saveFileDialog.FileName);
                if (CSVWriter != null)
                {
                    foreach (DataGridViewRow Row in harvestOverridesGrid.Rows)
                    {
                        if (Row.Index == harvestOverridesGrid.Rows.Count - 1) continue; //Last row is the new row
                        CSVWriter.WriteLine(Row.Cells[FoliageTypeName.Name].Value + "," + Row.Cells[OverrideActorComponentName.Name].Value);
                    }
                    CSVWriter.Close();
                }
            }*/
        }

        private void harvestOverridesGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
