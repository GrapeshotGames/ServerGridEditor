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
    public partial class EditRegionTemplate : Form
    {
        RegionTemplateData targetRegionTemplate;
        MainForm mainForm;

        public EditRegionTemplate(MainForm mainForm, RegionTemplateData targetRegionTemplate)
        {
            this.mainForm = mainForm;
            this.targetRegionTemplate = targetRegionTemplate;
            InitializeComponent();
        }

        private void EditServerTemplate_Load(object sender, EventArgs e)
        {
            nameTxtBox.Text = targetRegionTemplate.name;
            additionalCmdLineParamsTxtBox.Text = targetRegionTemplate.AdditionalCmdLineParams;
            oceanEpicSpawnEntriesOverrideTemplateNameTxtBox.Text = targetRegionTemplate.oceanEpicSpawnEntriesOverrideTemplateName;
            NPCShipSpawnEntriesOverrideTemplateNameTxtBox.Text = targetRegionTemplate.NPCShipSpawnEntriesOverrideTemplateName;

            waterColorRTxtBox.Text = targetRegionTemplate.waterColorR.ToString();
            waterColorGTxtBox.Text = targetRegionTemplate.waterColorG.ToString();
            waterColorBTxtBox.Text = targetRegionTemplate.waterColorB.ToString();
            skyStyleIndexTxtBox.Text = targetRegionTemplate.skyStyleIndex.ToString();
            serverIslandPointsMultiplierTxtBox.Text = targetRegionTemplate.serverIslandPointsMultiplier.ToString();
            char[] charSeparators = new char[] { ',' };
            String[] ServerCustomDataNames = targetRegionTemplate.ServerCustomDatas1.Split(charSeparators, StringSplitOptions.RemoveEmptyEntries);
            String[] ServerCustomDataValues = targetRegionTemplate.ServerCustomDatas2.Split(charSeparators, StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < ServerCustomDataNames.Length && i < ServerCustomDataValues.Length; i++)
            {
                if (ServerCustomDataNames[i].Length == 0)
                    continue;
                int index = ServerCustomDataGrid.Rows.Add();
                ServerCustomDataGrid.Rows[index].Cells[0].Value = ServerCustomDataNames[i];
                ServerCustomDataGrid.Rows[index].Cells[1].Value = ServerCustomDataValues[i];
            }

            String[] ClientCustomDataNames = targetRegionTemplate.ClientCustomDatas1.Split(charSeparators, StringSplitOptions.RemoveEmptyEntries);
            String[] ClientCustomDataValues = targetRegionTemplate.ClientCustomDatas2.Split(charSeparators, StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < ClientCustomDataNames.Length && i < ClientCustomDataValues.Length; i++)
            {
                if (ClientCustomDataNames[i].Length == 0)
                    continue;
                int index = ClientCustomDataGrid.Rows.Add();
                ClientCustomDataGrid.Rows[index].Cells[0].Value = ClientCustomDataNames[i];
                ClientCustomDataGrid.Rows[index].Cells[1].Value = ClientCustomDataValues[i];
            }

            BindingList<ConfigKeyValueEntry> pairs = new BindingList<ConfigKeyValueEntry>();
            pairs.AddingNew += (s, a) =>
            {
                a.NewObject = new ConfigKeyValueEntry("", "");
            };
            if (targetRegionTemplate.OverrideShooterGameModeDefaultGameIni != null)
                foreach (KeyValuePair<string, string> DicPair in targetRegionTemplate.OverrideShooterGameModeDefaultGameIni)
                    pairs.Add(new ConfigKeyValueEntry(DicPair.Key, DicPair.Value));

            overrideShooterGameModeDefaultGameIniDataGridView.DataSource = pairs;

            FloorZDist.Text = targetRegionTemplate.floorZDist + "";
            transitionMinZTxtBox.Text = targetRegionTemplate.transitionMinZ + "";
            GlobalBiomeSeamlessServerGridPreOffsetValuesTxtBox.Text = targetRegionTemplate.GlobalBiomeSeamlessServerGridPreOffsetValues;
            GlobalBiomeSeamlessServerGridPreOffsetValuesOceanWaterTxtBox.Text = targetRegionTemplate.GlobalBiomeSeamlessServerGridPreOffsetValuesOceanWater;
            OceanDinoDepthEntriesOverrideTxtBox.Text = targetRegionTemplate.OceanDinoDepthEntriesOverride;
            OceanEpicSpawnEntriesOverrideValuesTxtBox.Text = targetRegionTemplate.OceanEpicSpawnEntriesOverrideValues;
            OceanFloatsamCratesOverrideTxtBox.Text = targetRegionTemplate.oceanFloatsamCratesOverride;
            TreasureMapLootTablesOverrideTxtBox.Text = targetRegionTemplate.treasureMapLootTablesOverride;
            regionOverridesTxtBox.Text = targetRegionTemplate.regionOverrides;
            if (targetRegionTemplate.extraSublevels != null)
                extraSublevelTxtBox.Lines = targetRegionTemplate.extraSublevels.ToArray();
            Text += string.Format(" ({0},{1})", targetRegionTemplate.gridX, targetRegionTemplate.gridY);
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
                if(nameTxtBox.Text == template.name && targetRegionTemplate != template)
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


            targetRegionTemplate.name = nameTxtBox.Text;
            targetRegionTemplate.AdditionalCmdLineParams = additionalCmdLineParamsTxtBox.Text;
            targetRegionTemplate.oceanEpicSpawnEntriesOverrideTemplateName = oceanEpicSpawnEntriesOverrideTemplateNameTxtBox.Text;
            targetRegionTemplate.NPCShipSpawnEntriesOverrideTemplateName = NPCShipSpawnEntriesOverrideTemplateNameTxtBox.Text;


            targetRegionTemplate.waterColorR = waterColorR;
            targetRegionTemplate.waterColorG = waterColorG;
            targetRegionTemplate.waterColorB = waterColorB;
            targetRegionTemplate.skyStyleIndex = skyStyleIndex;
            targetRegionTemplate.serverIslandPointsMultiplier = serverIslandPointsMultiplier;
            targetRegionTemplate.ServerCustomDatas1 = ServerCustomDatas1 + ",";
            targetRegionTemplate.ServerCustomDatas2 = ServerCustomDatas2 + ",";
            targetRegionTemplate.ClientCustomDatas1 = ClientCustomDatas1 + ",";
            targetRegionTemplate.ClientCustomDatas2 = ClientCustomDatas2 + ",";

            if (targetRegionTemplate.OverrideShooterGameModeDefaultGameIni != null)
                targetRegionTemplate.OverrideShooterGameModeDefaultGameIni.Clear();
            else
                targetRegionTemplate.OverrideShooterGameModeDefaultGameIni = new Dictionary<string, string>();
            foreach (DataGridViewRow row in overrideShooterGameModeDefaultGameIniDataGridView.Rows)
                if (row.Cells[0].Value != null)
                    targetRegionTemplate.OverrideShooterGameModeDefaultGameIni.Add(row.Cells[0].Value.ToString(), row.Cells[1].Value != null ? row.Cells[1].Value.ToString() : "");

            targetRegionTemplate.floorZDist = floorZDist;
            targetRegionTemplate.transitionMinZ = transitionMinZ;
            targetRegionTemplate.GlobalBiomeSeamlessServerGridPreOffsetValues = GlobalBiomeSeamlessServerGridPreOffsetValuesTxtBox.Text;
            targetRegionTemplate.GlobalBiomeSeamlessServerGridPreOffsetValuesOceanWater = GlobalBiomeSeamlessServerGridPreOffsetValuesOceanWaterTxtBox.Text;
            targetRegionTemplate.OceanDinoDepthEntriesOverride = OceanDinoDepthEntriesOverrideTxtBox.Text;
            targetRegionTemplate.OceanEpicSpawnEntriesOverrideValues = OceanEpicSpawnEntriesOverrideValuesTxtBox.Text;
            targetRegionTemplate.oceanFloatsamCratesOverride = OceanFloatsamCratesOverrideTxtBox.Text;
            targetRegionTemplate.treasureMapLootTablesOverride = TreasureMapLootTablesOverrideTxtBox.Text;
            targetRegionTemplate.regionOverrides = regionOverridesTxtBox.Text;
            targetRegionTemplate.extraSublevels = new List<string>(extraSublevelTxtBox.Lines);
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
