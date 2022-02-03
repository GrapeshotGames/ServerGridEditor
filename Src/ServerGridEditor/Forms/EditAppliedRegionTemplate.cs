using AtlasGridDataLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ServerGridEditor
{
    public partial class EditAppliedRegionTemplate : Form
    {
        AppliedRegionTemplateData appliedTargetRegionTemplate;
        MainForm mainForm;

        public EditAppliedRegionTemplate(MainForm mainForm, AppliedRegionTemplateData appliedTargetRegionTemplate)
        {
            this.mainForm = mainForm;
            this.appliedTargetRegionTemplate = appliedTargetRegionTemplate;
            InitializeComponent();
        }

        private void EditServerTemplate_Load(object sender, EventArgs e)
        {
            nameTxtBox.Text = appliedTargetRegionTemplate.name;
            additionalCmdLineParamsTxtBox.Text = appliedTargetRegionTemplate.AdditionalCmdLineParams;
            oceanEpicSpawnEntriesOverrideTemplateNameTxtBox.Text = appliedTargetRegionTemplate.oceanEpicSpawnEntriesOverrideTemplateName;
            NPCShipSpawnEntriesOverrideTemplateNameTxtBox.Text = appliedTargetRegionTemplate.NPCShipSpawnEntriesOverrideTemplateName;
            char[] charSeparators = new char[] { ',' };
            waterColorRTxtBox.Text = appliedTargetRegionTemplate.waterColorR.ToString();
            waterColorGTxtBox.Text = appliedTargetRegionTemplate.waterColorG.ToString();
            waterColorBTxtBox.Text = appliedTargetRegionTemplate.waterColorB.ToString();
            skyStyleIndexTxtBox.Text = appliedTargetRegionTemplate.skyStyleIndex.ToString();
            serverIslandPointsMultiplierTxtBox.Text = appliedTargetRegionTemplate.serverIslandPointsMultiplier.ToString();

            String[] ServerCustomDataNames = appliedTargetRegionTemplate.ServerCustomDatas1.Split(charSeparators, StringSplitOptions.RemoveEmptyEntries);
            String[] ServerCustomDataValues = appliedTargetRegionTemplate.ServerCustomDatas2.Split(charSeparators, StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < ServerCustomDataNames.Length && i < ServerCustomDataValues.Length; i++)
            {
                if (ServerCustomDataNames[i].Length == 0)
                    continue;
                int index = ServerCustomDataGrid.Rows.Add();
                ServerCustomDataGrid.Rows[index].Cells[0].Value = ServerCustomDataNames[i];
                ServerCustomDataGrid.Rows[index].Cells[1].Value = ServerCustomDataValues[i];
            }

            String[] ClientCustomDataNames = appliedTargetRegionTemplate.ClientCustomDatas1.Split(charSeparators, StringSplitOptions.RemoveEmptyEntries);
            String[] ClientCustomDataValues = appliedTargetRegionTemplate.ClientCustomDatas2.Split(charSeparators, StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < ClientCustomDataNames.Length && i < ClientCustomDataValues.Length; i++)
            {
                if (ClientCustomDataNames[i].Length == 0)
                    continue;
                int index = ClientCustomDataGrid.Rows.Add();
                ClientCustomDataGrid.Rows[index].Cells[0].Value = ClientCustomDataNames[i];
                ClientCustomDataGrid.Rows[index].Cells[1].Value = ClientCustomDataValues[i];
            }


            templateComboBox.Items.Add("None");
            foreach (RegionTemplateData template in mainForm.currentProject.regionTemplates)
                templateComboBox.Items.Add(template.name);

            if (string.IsNullOrEmpty(appliedTargetRegionTemplate.serverTemplateName))
                templateComboBox.SelectedItem = "None";

            if (templateComboBox.Items.Contains(appliedTargetRegionTemplate.serverTemplateName))
                templateComboBox.SelectedItem = appliedTargetRegionTemplate.serverTemplateName;
            else
                templateComboBox.SelectedItem = "None";

            BindingList<ConfigKeyValueEntry> pairs = new BindingList<ConfigKeyValueEntry>();
            pairs.AddingNew += (s, a) =>
            {
                a.NewObject = new ConfigKeyValueEntry("", "");
            };
            if (appliedTargetRegionTemplate.OverrideShooterGameModeDefaultGameIni != null)
                foreach (KeyValuePair<string, string> DicPair in appliedTargetRegionTemplate.OverrideShooterGameModeDefaultGameIni)
                    pairs.Add(new ConfigKeyValueEntry(DicPair.Key, DicPair.Value));

            overrideShooterGameModeDefaultGameIniDataGridView.DataSource = pairs;

            FloorZDist.Text = appliedTargetRegionTemplate.floorZDist + "";
            transitionMinZTxtBox.Text = appliedTargetRegionTemplate.transitionMinZ + "";
            GlobalBiomeSeamlessServerGridPreOffsetValuesTxtBox.Text = appliedTargetRegionTemplate.GlobalBiomeSeamlessServerGridPreOffsetValues;
            GlobalBiomeSeamlessServerGridPreOffsetValuesOceanWaterTxtBox.Text = appliedTargetRegionTemplate.GlobalBiomeSeamlessServerGridPreOffsetValuesOceanWater;
            OceanDinoDepthEntriesOverrideTxtBox.Text = appliedTargetRegionTemplate.OceanDinoDepthEntriesOverride;
            OceanEpicSpawnEntriesOverrideValuesTxtBox.Text = appliedTargetRegionTemplate.OceanEpicSpawnEntriesOverrideValues;
            OceanFloatsamCratesOverrideTxtBox.Text = appliedTargetRegionTemplate.oceanFloatsamCratesOverride;
            TreasureMapLootTablesOverrideTxtBox.Text = appliedTargetRegionTemplate.treasureMapLootTablesOverride;
            regionOverridesTxtBox.Text = appliedTargetRegionTemplate.regionOverrides;
            if (appliedTargetRegionTemplate.extraSublevels != null)
                extraSublevelTxtBox.Lines = appliedTargetRegionTemplate.extraSublevels.ToArray();
            Text += string.Format(" ({0},{1})", appliedTargetRegionTemplate.gridX, appliedTargetRegionTemplate.gridY);
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void createBtn_Click(object sender, EventArgs e)
        {
            if (Save())
            {
                DialogResult = DialogResult.OK;
                Close();
            }
        }

        private bool Save()
        {
            nameTxtBox.Text = nameTxtBox.Text.Trim();

            if (string.IsNullOrEmpty(nameTxtBox.Text))
            {
                MessageBox.Show("You must specify a template name", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (nameTxtBox.Text == "None")
            {
                MessageBox.Show("You can't create a template called None", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            foreach (RegionTemplateData template in mainForm.currentProject.regionTemplates)
            {
                if(nameTxtBox.Text == template.name && appliedTargetRegionTemplate != template)
                {
                    MessageBox.Show("Another template exists with the same name", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }

            int floorZDist, transitionMinZ;

            if (!int.TryParse(FloorZDist.Text, out floorZDist))
            {
                MessageBox.Show("Invalid number for floor distance from ocean surface", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (!int.TryParse(transitionMinZTxtBox.Text, out transitionMinZ))
            {
                MessageBox.Show("Invalid number for transition minimum Z", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            float waterColorR, waterColorG, waterColorB;
            int skyStyleIndex;
            float serverIslandPointsMultiplier;

            if (!float.TryParse(waterColorRTxtBox.Text, out waterColorR))
            {
                MessageBox.Show("Invalid number for waterColorR", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (!float.TryParse(waterColorGTxtBox.Text, out waterColorG))
            {
                MessageBox.Show("Invalid number for waterColorG", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (!float.TryParse(waterColorBTxtBox.Text, out waterColorB))
            {
                MessageBox.Show("Invalid number for waterColorB", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (!int.TryParse(skyStyleIndexTxtBox.Text, out skyStyleIndex))
            {
                MessageBox.Show("Invalid number for skyStyleIndex", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            
            if (!float.TryParse(serverIslandPointsMultiplierTxtBox.Text, out serverIslandPointsMultiplier))
            {
                MessageBox.Show("Invalid number for serverIslandPointsMultiplier", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            string ServerCustomDatas1 = "";
            string ServerCustomDatas2 = "";

            foreach (DataGridViewRow row in ServerCustomDataGrid.Rows)
            {
                if (row.Index == ServerCustomDataGrid.Rows.Count - 1) continue; //Last row is the new row

                if (row.Cells[0].Value == null || row.Cells[0].Value.ToString().Length == 0)
                {
                    MessageBox.Show("You must assign a name to each row", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

                ServerCustomDatas1 += "," + row.Cells[0].Value.ToString();

                if (row.Cells[1].Value == null || row.Cells[1].Value.ToString().Length == 0)
                {
                    MessageBox.Show("You must assign a value to each row", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                ServerCustomDatas2 += "," + row.Cells[1].Value.ToString();
            }

            string ClientCustomDatas1 = "";
            string ClientCustomDatas2 = "";

            foreach (DataGridViewRow row in ClientCustomDataGrid.Rows)
            {
                if (row.Index == ClientCustomDataGrid.Rows.Count - 1) continue; //Last row is the new row

                if (row.Cells[0].Value == null || row.Cells[0].Value.ToString().Length == 0)
                {
                    MessageBox.Show("You must assign a name to each row", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

                ClientCustomDatas1 += "," + row.Cells[0].Value.ToString();

                if (row.Cells[1].Value == null || row.Cells[1].Value.ToString().Length == 0)
                {
                    MessageBox.Show("You must assign a value to each row", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                ClientCustomDatas2 += "," + row.Cells[1].Value.ToString();
            }


            appliedTargetRegionTemplate.name = nameTxtBox.Text;
            appliedTargetRegionTemplate.AdditionalCmdLineParams = additionalCmdLineParamsTxtBox.Text;
            appliedTargetRegionTemplate.oceanEpicSpawnEntriesOverrideTemplateName = oceanEpicSpawnEntriesOverrideTemplateNameTxtBox.Text;
            appliedTargetRegionTemplate.NPCShipSpawnEntriesOverrideTemplateName = NPCShipSpawnEntriesOverrideTemplateNameTxtBox.Text;


            appliedTargetRegionTemplate.waterColorR = waterColorR;
            appliedTargetRegionTemplate.waterColorG = waterColorG;
            appliedTargetRegionTemplate.waterColorB = waterColorB;
            appliedTargetRegionTemplate.skyStyleIndex = skyStyleIndex;
            appliedTargetRegionTemplate.serverIslandPointsMultiplier = serverIslandPointsMultiplier;
            appliedTargetRegionTemplate.ServerCustomDatas1 = ServerCustomDatas1 + ",";
            appliedTargetRegionTemplate.ServerCustomDatas2 = ServerCustomDatas2 + ",";
            appliedTargetRegionTemplate.ClientCustomDatas1 = ClientCustomDatas1 + ",";
            appliedTargetRegionTemplate.ClientCustomDatas2 = ClientCustomDatas2 + ",";

            if (appliedTargetRegionTemplate.OverrideShooterGameModeDefaultGameIni != null)
                appliedTargetRegionTemplate.OverrideShooterGameModeDefaultGameIni.Clear();
            else
                appliedTargetRegionTemplate.OverrideShooterGameModeDefaultGameIni = new Dictionary<string, string>();
            foreach (DataGridViewRow row in overrideShooterGameModeDefaultGameIniDataGridView.Rows)
                if (row.Cells[0].Value != null)
                    appliedTargetRegionTemplate.OverrideShooterGameModeDefaultGameIni.Add(row.Cells[0].Value.ToString(), row.Cells[1].Value != null ? row.Cells[1].Value.ToString() : "");

            appliedTargetRegionTemplate.floorZDist = floorZDist;
            appliedTargetRegionTemplate.transitionMinZ = transitionMinZ;
            appliedTargetRegionTemplate.GlobalBiomeSeamlessServerGridPreOffsetValues = GlobalBiomeSeamlessServerGridPreOffsetValuesTxtBox.Text;
            appliedTargetRegionTemplate.GlobalBiomeSeamlessServerGridPreOffsetValuesOceanWater = GlobalBiomeSeamlessServerGridPreOffsetValuesOceanWaterTxtBox.Text;
            appliedTargetRegionTemplate.OceanDinoDepthEntriesOverride = OceanDinoDepthEntriesOverrideTxtBox.Text;
            appliedTargetRegionTemplate.OceanEpicSpawnEntriesOverrideValues = OceanEpicSpawnEntriesOverrideValuesTxtBox.Text;
            appliedTargetRegionTemplate.oceanFloatsamCratesOverride = OceanFloatsamCratesOverrideTxtBox.Text;
            appliedTargetRegionTemplate.treasureMapLootTablesOverride = TreasureMapLootTablesOverrideTxtBox.Text;
            appliedTargetRegionTemplate.regionOverrides = regionOverridesTxtBox.Text;
            appliedTargetRegionTemplate.extraSublevels = new List<string>(extraSublevelTxtBox.Lines);
            if (templateComboBox.SelectedItem != null)
            {
                if (templateComboBox.SelectedItem.ToString() == "None")
                    appliedTargetRegionTemplate.serverTemplateName = "";
                else
                    appliedTargetRegionTemplate.serverTemplateName = templateComboBox.SelectedItem + "";
            }
            return true;
        }

        private void portTxtBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            StaticHelpers.ForceNumericKeypress(sender, e, false);
        }

        private void gamePortTxtBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            StaticHelpers.ForceNumericKeypress(sender, e, false);
        }

        private void seamlessDataPortTxt_KeyPress(object sender, KeyPressEventArgs e)
        {
            StaticHelpers.ForceNumericKeypress(sender, e, false);
        }

        private void gFloorZDist_KeyPress(object sender, KeyPressEventArgs e)
        {
            StaticHelpers.ForceNumericKeypress(sender, e, false);
        }
    }
}
