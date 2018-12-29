using AtlasGridDataLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
            nameTxtBox.Text = targetServerTemplate.name;
            additionalCmdLineParamsTxtBox.Text = targetServerTemplate.AdditionalCmdLineParams;
            oceanEpicSpawnEntriesOverrideTemplateNameTxtBox.Text = targetServerTemplate.oceanEpicSpawnEntriesOverrideTemplateName;
            NPCShipSpawnEntriesOverrideTemplateNameTxtBox.Text = targetServerTemplate.NPCShipSpawnEntriesOverrideTemplateName;

            waterColorRTxtBox.Text = targetServerTemplate.waterColorR.ToString();
            waterColorGTxtBox.Text = targetServerTemplate.waterColorG.ToString();
            waterColorBTxtBox.Text = targetServerTemplate.waterColorB.ToString();
            skyStyleIndexTxtBox.Text = targetServerTemplate.skyStyleIndex.ToString();
            ServerCustomDatas1TxtBox.Text = targetServerTemplate.ServerCustomDatas1;
            ServerCustomDatas2TxtBox.Text = targetServerTemplate.ServerCustomDatas2;
            ClientCustomDatas1TxtBox.Text = targetServerTemplate.ClientCustomDatas1;
            ClientCustomDatas2TxtBox.Text = targetServerTemplate.ClientCustomDatas2;

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
                if(nameTxtBox.Text == template.name && targetServerTemplate != template)
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

            targetServerTemplate.name = nameTxtBox.Text;
            targetServerTemplate.AdditionalCmdLineParams = additionalCmdLineParamsTxtBox.Text;
            targetServerTemplate.oceanEpicSpawnEntriesOverrideTemplateName = oceanEpicSpawnEntriesOverrideTemplateNameTxtBox.Text;
            targetServerTemplate.NPCShipSpawnEntriesOverrideTemplateName = NPCShipSpawnEntriesOverrideTemplateNameTxtBox.Text;


            targetServerTemplate.waterColorR = waterColorR;
            targetServerTemplate.waterColorG = waterColorG;
            targetServerTemplate.waterColorB = waterColorB;
            targetServerTemplate.skyStyleIndex = skyStyleIndex;
            targetServerTemplate.ServerCustomDatas1 = ServerCustomDatas1TxtBox.Text;
            targetServerTemplate.ServerCustomDatas2 = ServerCustomDatas2TxtBox.Text;
            targetServerTemplate.ClientCustomDatas1 = ClientCustomDatas1TxtBox.Text;
            targetServerTemplate.ClientCustomDatas2 = ClientCustomDatas2TxtBox.Text;

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
