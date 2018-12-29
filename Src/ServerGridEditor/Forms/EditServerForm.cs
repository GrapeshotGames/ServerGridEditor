using AtlasGridDataLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace ServerGridEditor
{
    public partial class EditServerForm : Form
    {

        public Server targetServer;

        MainForm mainForm;

        public EditServerForm(MainForm mainForm)
        {
            this.mainForm = mainForm;
            InitializeComponent();
        }

        private void EditServerForm_Load(object sender, EventArgs e)
        {
            nameTxtBox.Text = targetServer.name;
            ipTxtBox.Text = targetServer.ip;
            portTxtBox.Text = targetServer.port + "";
            gamePortTxtBox.Text = targetServer.gamePort + "";
            seamlessDataPortTxt.Text = targetServer.seamlessDataPort + "";
            homeServerCheckbox.Checked = targetServer.isHomeServer;
            additionalCmdLineParamsTxtBox.Text = targetServer.AdditionalCmdLineParams;
            oceanEpicSpawnEntriesOverrideTemplateNameTxtBox.Text = targetServer.oceanEpicSpawnEntriesOverrideTemplateName;
            NPCShipSpawnEntriesOverrideTemplateNameTxtBox.Text = targetServer.NPCShipSpawnEntriesOverrideTemplateName;

            waterColorRTxtBox.Text = targetServer.waterColorR.ToString();
            waterColorGTxtBox.Text = targetServer.waterColorG.ToString();
            waterColorBTxtBox.Text = targetServer.waterColorB.ToString();
            skyStyleIndexTxtBox.Text = targetServer.skyStyleIndex.ToString();
            ServerCustomDatas1TxtBox.Text = targetServer.ServerCustomDatas1;
            ServerCustomDatas2TxtBox.Text = targetServer.ServerCustomDatas2;
            ClientCustomDatas1TxtBox.Text = targetServer.ClientCustomDatas1;
            ClientCustomDatas2TxtBox.Text = targetServer.ClientCustomDatas2;

            BindingList<ConfigKeyValueEntry> pairs = new BindingList<ConfigKeyValueEntry>();
            pairs.AddingNew += (s, a) =>
            {
                a.NewObject = new ConfigKeyValueEntry("", "");
            };
            if (targetServer.OverrideShooterGameModeDefaultGameIni != null)
                foreach (KeyValuePair<string, string> DicPair in targetServer.OverrideShooterGameModeDefaultGameIni)
                    pairs.Add(new ConfigKeyValueEntry(DicPair.Key, DicPair.Value));

            overrideShooterGameModeDefaultGameIniDataGridView.DataSource = pairs;



            FloorZDist.Text = targetServer.floorZDist + "";
            transitionMinZTxtBox.Text = targetServer.transitionMinZ + "";
            utcOffsetTxtBox.Text = targetServer.utcOffset + "";
            GlobalBiomeSeamlessServerGridPreOffsetValuesTxtBox.Text = targetServer.GlobalBiomeSeamlessServerGridPreOffsetValues;
            GlobalBiomeSeamlessServerGridPreOffsetValuesOceanWaterTxtBox.Text = targetServer.GlobalBiomeSeamlessServerGridPreOffsetValuesOceanWater;
            OceanDinoDepthEntriesOverrideTxtBox.Text = targetServer.OceanDinoDepthEntriesOverride;
            OceanEpicSpawnEntriesOverrideValuesTxtBox.Text = targetServer.OceanEpicSpawnEntriesOverrideValues;
            OceanFloatsamCratesOverrideTxtBox.Text = targetServer.oceanFloatsamCratesOverride;
            TreasureMapLootTablesOverrideTxtBox.Text = targetServer.treasureMapLootTablesOverride;
            regionOverridesTxtBox.Text = targetServer.regionOverrides;
            if (targetServer.extraSublevels != null)
                extraSublevelTxtBox.Lines = targetServer.extraSublevels.ToArray();
            coordsLbl.Text = string.Format("Coords ({0},{1})", targetServer.gridX, targetServer.gridY);
            Text += string.Format(" ({0},{1})", targetServer.gridX, targetServer.gridY);

            templateComboBox.Items.Add("None");
            foreach (ServerTemplateData template in mainForm.currentProject.serverTemplates)
                templateComboBox.Items.Add(template.name);

            if (string.IsNullOrEmpty(targetServer.serverTemplateName))
                templateComboBox.SelectedItem = "None";

            if(templateComboBox.Items.Contains(targetServer.serverTemplateName))
                templateComboBox.SelectedItem = targetServer.serverTemplateName;
            else
                templateComboBox.SelectedItem = "None";
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
            int port, gamePort, floorZDist, transitionMinZ, utcOffset, seamlessDataPort;

            if (!int.TryParse(portTxtBox.Text, out port) || !int.TryParse(gamePortTxtBox.Text, out gamePort) || !int.TryParse(seamlessDataPortTxt.Text, out seamlessDataPort))
            {
                MessageBox.Show("Invalid port numbers", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

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

            if (!int.TryParse(utcOffsetTxtBox.Text, out utcOffset))
            {
                MessageBox.Show("Invalid number for UTC Offset", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            float waterColorR, waterColorG, waterColorB;
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


            targetServer.name = nameTxtBox.Text;
            targetServer.ip = ipTxtBox.Text;
            targetServer.port = port;
            targetServer.gamePort = gamePort;
            targetServer.seamlessDataPort = seamlessDataPort;
            targetServer.isHomeServer = homeServerCheckbox.Checked;
            targetServer.AdditionalCmdLineParams = additionalCmdLineParamsTxtBox.Text;
            targetServer.oceanEpicSpawnEntriesOverrideTemplateName = oceanEpicSpawnEntriesOverrideTemplateNameTxtBox.Text;
            targetServer.NPCShipSpawnEntriesOverrideTemplateName = NPCShipSpawnEntriesOverrideTemplateNameTxtBox.Text;


            targetServer.waterColorR = waterColorR;
            targetServer.waterColorG = waterColorG;
            targetServer.waterColorB = waterColorB;
            targetServer.skyStyleIndex = skyStyleIndex;
            targetServer.ServerCustomDatas1 = ServerCustomDatas1TxtBox.Text;
            targetServer.ServerCustomDatas2 = ServerCustomDatas2TxtBox.Text;
            targetServer.ClientCustomDatas1 = ClientCustomDatas1TxtBox.Text;
            targetServer.ClientCustomDatas2 = ClientCustomDatas2TxtBox.Text;

            if (targetServer.OverrideShooterGameModeDefaultGameIni != null)
                targetServer.OverrideShooterGameModeDefaultGameIni.Clear();
            else
                targetServer.OverrideShooterGameModeDefaultGameIni = new Dictionary<string, string>();
            foreach (DataGridViewRow row in overrideShooterGameModeDefaultGameIniDataGridView.Rows)
                if (row.Cells[0].Value != null)
                    targetServer.OverrideShooterGameModeDefaultGameIni.Add(row.Cells[0].Value.ToString(), row.Cells[1].Value != null ? row.Cells[1].Value.ToString() : "");

            targetServer.floorZDist = floorZDist;
            targetServer.transitionMinZ = transitionMinZ;
            targetServer.utcOffset = utcOffset;
            targetServer.GlobalBiomeSeamlessServerGridPreOffsetValues = GlobalBiomeSeamlessServerGridPreOffsetValuesTxtBox.Text;
            targetServer.GlobalBiomeSeamlessServerGridPreOffsetValuesOceanWater = GlobalBiomeSeamlessServerGridPreOffsetValuesOceanWaterTxtBox.Text;
            targetServer.OceanDinoDepthEntriesOverride = OceanDinoDepthEntriesOverrideTxtBox.Text;
            targetServer.OceanEpicSpawnEntriesOverrideValues = OceanEpicSpawnEntriesOverrideValuesTxtBox.Text;
            targetServer.oceanFloatsamCratesOverride = OceanFloatsamCratesOverrideTxtBox.Text;
            targetServer.treasureMapLootTablesOverride = TreasureMapLootTablesOverrideTxtBox.Text;
            targetServer.regionOverrides = regionOverridesTxtBox.Text;
            targetServer.extraSublevels = new List<string>(extraSublevelTxtBox.Lines);

            if (templateComboBox.SelectedItem != null)
            {
                if (templateComboBox.SelectedItem.ToString() == "None")
                    targetServer.serverTemplateName = "";
                else
                    targetServer.serverTemplateName = templateComboBox.SelectedItem + "";
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

        private void runTestsBtn_Click(object sender, EventArgs e)
        {
            if (Save())
            {
                string jsonFileName = MainForm.gameDir + "/" + MainForm.tempJsonFile;
                File.WriteAllText(jsonFileName, mainForm.currentProject.Serialize(mainForm));

                ProcessStartInfo serverStartInfo, clientStartInfo;
                targetServer.LaunchPreview(out serverStartInfo, out clientStartInfo);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void editSpawnRegions_Click(object sender, EventArgs e)
        {
            if (mainForm != null)
                mainForm.ShowServerEditSpawnRegionsForm(targetServer);
        }

        private void templateComboBox_DrawItem(object sender, DrawItemEventArgs e)
        {
            e.DrawBackground();

            Graphics g = e.Graphics;

            ServerTemplateData template = mainForm.currentProject.GetServerTemplateByName(templateComboBox.Items[e.Index].ToString());
            if (template != null)
                g.DrawString(templateComboBox.Items[e.Index].ToString(), e.Font, new SolidBrush(template.GetTemplateColor()),
                    new PointF(e.Bounds.X, e.Bounds.Y));
            else
                g.DrawString(templateComboBox.Items[e.Index].ToString(), e.Font, new SolidBrush(e.ForeColor), new PointF(e.Bounds.X, e.Bounds.Y));


            e.DrawFocusRectangle();
        }
    }
}
