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
    public partial class EditServerTemplate : Form
    {
        ServerTemplateData targetServerTemplate;
        MainForm mainForm;

        public EditServerTemplate(MainForm mainForm, ServerTemplateData targetServerTemplate)
        {
            this.mainForm = mainForm;
            this.targetServerTemplate = targetServerTemplate;
            InitializeComponent();
        }

        private void EditServerTemplate_Load(object sender, EventArgs e)
        {
            char[] charSeparators = new char[] { ',' };
            nameTxtBox.Text = targetServerTemplate.name;
            additionalCmdLineParamsTxtBox.Text = targetServerTemplate.AdditionalCmdLineParams;
            oceanEpicSpawnEntriesOverrideTemplateNameTxtBox.Text = targetServerTemplate.oceanEpicSpawnEntriesOverrideTemplateName;
            NPCShipSpawnEntriesOverrideTemplateNameTxtBox.Text = targetServerTemplate.NPCShipSpawnEntriesOverrideTemplateName;

            waterColorRTxtBox.Text = targetServerTemplate.waterColorR.ToString();
            waterColorGTxtBox.Text = targetServerTemplate.waterColorG.ToString();
            waterColorBTxtBox.Text = targetServerTemplate.waterColorB.ToString();
            skyStyleIndexTxtBox.Text = targetServerTemplate.skyStyleIndex.ToString();
            serverIslandPointsMultiplierTxtBox.Text = targetServerTemplate.serverIslandPointsMultiplier.ToString();

            String[] ServerCustomDataNames = targetServerTemplate.ServerCustomDatas1.Split(charSeparators, StringSplitOptions.RemoveEmptyEntries);
            String[] ServerCustomDataValues = targetServerTemplate.ServerCustomDatas2.Split(charSeparators, StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < ServerCustomDataNames.Length && i < ServerCustomDataValues.Length; i++)
            {
                if (ServerCustomDataNames[i].Length == 0)
                    continue;
                int index = ServerCustomDataGrid.Rows.Add();
                ServerCustomDataGrid.Rows[index].Cells[0].Value = ServerCustomDataNames[i];
                ServerCustomDataGrid.Rows[index].Cells[1].Value = ServerCustomDataValues[i];
            }

            String[] ClientCustomDataNames = targetServerTemplate.ClientCustomDatas1.Split(charSeparators, StringSplitOptions.RemoveEmptyEntries);
            String[] ClientCustomDataValues = targetServerTemplate.ClientCustomDatas2.Split(charSeparators, StringSplitOptions.RemoveEmptyEntries);

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
            if (targetServerTemplate.OverrideShooterGameModeDefaultGameIni != null)
                foreach (KeyValuePair<string, string> DicPair in targetServerTemplate.OverrideShooterGameModeDefaultGameIni)
                    pairs.Add(new ConfigKeyValueEntry(DicPair.Key, DicPair.Value));

            overrideShooterGameModeDefaultGameIniDataGridView.DataSource = pairs;

            FloorZDist.Text = targetServerTemplate.floorZDist + "";
            transitionMinZTxtBox.Text = targetServerTemplate.transitionMinZ + "";
            GlobalBiomeSeamlessServerGridPreOffsetValuesTxtBox.Text = targetServerTemplate.GlobalBiomeSeamlessServerGridPreOffsetValues;
            GlobalBiomeSeamlessServerGridPreOffsetValuesOceanWaterTxtBox.Text = targetServerTemplate.GlobalBiomeSeamlessServerGridPreOffsetValuesOceanWater;
            OceanDinoDepthEntriesOverrideTxtBox.Text = targetServerTemplate.OceanDinoDepthEntriesOverride;
            OceanEpicSpawnEntriesOverrideValuesTxtBox.Text = targetServerTemplate.OceanEpicSpawnEntriesOverrideValues;
            OceanFloatsamCratesOverrideTxtBox.Text = targetServerTemplate.oceanFloatsamCratesOverride;
            TreasureMapLootTablesOverrideTxtBox.Text = targetServerTemplate.treasureMapLootTablesOverride;
            regionOverridesTxtBox.Text = targetServerTemplate.regionOverrides;
            if (targetServerTemplate.extraSublevels != null)
                extraSublevelTxtBox.Lines = targetServerTemplate.extraSublevels.ToArray();
            Text += string.Format(" ({0},{1})", targetServerTemplate.gridX, targetServerTemplate.gridY);

            templateColRTxtBox.Text = targetServerTemplate.templateColorR + "";
            templateColGTxtBox.Text = targetServerTemplate.templateColorG + "";
            templateColBTxtBox.Text = targetServerTemplate.templateColorB + "";
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

            foreach (ServerTemplateData template in mainForm.currentProject.serverTemplates)
            {
                if (nameTxtBox.Text == template.name && targetServerTemplate != template)
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
            float templateColorR, templateColorG, templateColorB;
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


            if (!float.TryParse(templateColRTxtBox.Text, out templateColorR))
            {
                MessageBox.Show("Invalid number for templateColorR", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (!float.TryParse(templateColGTxtBox.Text, out templateColorG))
            {
                MessageBox.Show("Invalid number for templateColorG", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (!float.TryParse(templateColBTxtBox.Text, out templateColorB))
            {
                MessageBox.Show("Invalid number for templateColorB", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

            targetServerTemplate.name = nameTxtBox.Text;
            targetServerTemplate.AdditionalCmdLineParams = additionalCmdLineParamsTxtBox.Text;
            targetServerTemplate.oceanEpicSpawnEntriesOverrideTemplateName = oceanEpicSpawnEntriesOverrideTemplateNameTxtBox.Text;
            targetServerTemplate.NPCShipSpawnEntriesOverrideTemplateName = NPCShipSpawnEntriesOverrideTemplateNameTxtBox.Text;


            targetServerTemplate.waterColorR = waterColorR;
            targetServerTemplate.waterColorG = waterColorG;
            targetServerTemplate.waterColorB = waterColorB;
            targetServerTemplate.skyStyleIndex = skyStyleIndex;
            targetServerTemplate.serverIslandPointsMultiplier = serverIslandPointsMultiplier;


            targetServerTemplate.ServerCustomDatas1 = ServerCustomDatas1 + ",";
            targetServerTemplate.ServerCustomDatas2 = ServerCustomDatas2 + ",";
            targetServerTemplate.ClientCustomDatas1 = ClientCustomDatas1 + ",";
            targetServerTemplate.ClientCustomDatas2 = ClientCustomDatas2 + ",";


            if (targetServerTemplate.OverrideShooterGameModeDefaultGameIni != null)
                targetServerTemplate.OverrideShooterGameModeDefaultGameIni.Clear();
            else
                targetServerTemplate.OverrideShooterGameModeDefaultGameIni = new Dictionary<string, string>();
            foreach (DataGridViewRow row in overrideShooterGameModeDefaultGameIniDataGridView.Rows)
                if (row.Cells[0].Value != null)
                    targetServerTemplate.OverrideShooterGameModeDefaultGameIni.Add(row.Cells[0].Value.ToString(), row.Cells[1].Value != null ? row.Cells[1].Value.ToString() : "");

            targetServerTemplate.floorZDist = floorZDist;
            targetServerTemplate.transitionMinZ = transitionMinZ;
            targetServerTemplate.GlobalBiomeSeamlessServerGridPreOffsetValues = GlobalBiomeSeamlessServerGridPreOffsetValuesTxtBox.Text;
            targetServerTemplate.GlobalBiomeSeamlessServerGridPreOffsetValuesOceanWater = GlobalBiomeSeamlessServerGridPreOffsetValuesOceanWaterTxtBox.Text;
            targetServerTemplate.OceanDinoDepthEntriesOverride = OceanDinoDepthEntriesOverrideTxtBox.Text;
            targetServerTemplate.OceanEpicSpawnEntriesOverrideValues = OceanEpicSpawnEntriesOverrideValuesTxtBox.Text;
            targetServerTemplate.oceanFloatsamCratesOverride = OceanFloatsamCratesOverrideTxtBox.Text;
            targetServerTemplate.treasureMapLootTablesOverride = TreasureMapLootTablesOverrideTxtBox.Text;
            targetServerTemplate.regionOverrides = regionOverridesTxtBox.Text;
            targetServerTemplate.extraSublevels = new List<string>(extraSublevelTxtBox.Lines);

            targetServerTemplate.templateColorR = templateColorR;
            targetServerTemplate.templateColorG = templateColorG;
            targetServerTemplate.templateColorB = templateColorB;
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
