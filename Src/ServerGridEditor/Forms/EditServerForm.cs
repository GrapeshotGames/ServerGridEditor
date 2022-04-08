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

            BillboardsOffsetXTextBox.Text = targetServer.billboardsOffsetX.ToString();
            BillboardsOffsetYTextBox.Text = targetServer.billboardsOffsetY.ToString();
            BillboardsOffsetZTextBox.Text = targetServer.billboardsOffsetZ.ToString();

            OverrideDestNorthXTextBox.Text = targetServer.OverrideDestNorthX >= 0 && (targetServer.OverrideDestNorthX < mainForm.currentProject.numOfCellsX) ? targetServer.OverrideDestNorthX.ToString() : "";
            OverrideDestNorthYTextBox.Text = targetServer.OverrideDestNorthY >= 0 && (targetServer.OverrideDestNorthY < mainForm.currentProject.numOfCellsY) ? targetServer.OverrideDestNorthY.ToString() : "";
            OverrideDestSouthXTextBox.Text = targetServer.OverrideDestSouthX >= 0 && (targetServer.OverrideDestSouthX < mainForm.currentProject.numOfCellsX) ? targetServer.OverrideDestSouthX.ToString() : "";
            OverrideDestSouthYTextBox.Text = targetServer.OverrideDestSouthY >= 0 && (targetServer.OverrideDestSouthY < mainForm.currentProject.numOfCellsY) ? targetServer.OverrideDestSouthY.ToString() : "";
            OverrideDestEastXTextBox.Text = targetServer.OverrideDestEastX >= 0 && (targetServer.OverrideDestEastX < mainForm.currentProject.numOfCellsX) ? targetServer.OverrideDestEastX.ToString() : "";
            OverrideDestEastYTextBox.Text = targetServer.OverrideDestEastY >= 0 && (targetServer.OverrideDestEastY < mainForm.currentProject.numOfCellsY) ? targetServer.OverrideDestEastY.ToString() : "";
            OverrideDestWestXTextBox.Text = targetServer.OverrideDestWestX >= 0 && (targetServer.OverrideDestWestX < mainForm.currentProject.numOfCellsX) ? targetServer.OverrideDestWestX.ToString() : "";
            OverrideDestWestYTextBox.Text = targetServer.OverrideDestWestY >= 0 && (targetServer.OverrideDestWestY < mainForm.currentProject.numOfCellsY) ? targetServer.OverrideDestWestY.ToString() : "";

            MaxPlayingSecondsTextBox.Text = targetServer.MaxPlayingSeconds >= 0 ? targetServer.MaxPlayingSeconds.ToString() : "0";
            MaxPlayingSecondsTextBox.Text = targetServer.MaxPlayingSeconds >= 0 ? targetServer.MaxPlayingSeconds.ToString() : "0";

            MaxPlayingSecondsKickToServerXTextBox.Text = targetServer.MaxPlayingSecondsKickToServerX >= 0 && (targetServer.MaxPlayingSecondsKickToServerX < mainForm.currentProject.numOfCellsX) ? targetServer.MaxPlayingSecondsKickToServerX.ToString() : "";
            MaxPlayingSecondsKickToServerYTextBox.Text = targetServer.MaxPlayingSecondsKickToServerY >= 0 && (targetServer.MaxPlayingSecondsKickToServerY < mainForm.currentProject.numOfCellsY) ? targetServer.MaxPlayingSecondsKickToServerY.ToString() : "";


            char[] charSeparators = new char[] { ',' };
            skyStyleIndexTxtBox.Text = targetServer.skyStyleIndex.ToString();
            serverIslandPointsMultiplierTxtBox.Text = targetServer.serverIslandPointsMultiplier.ToString();
            String[] ServerCustomDataNames = targetServer.ServerCustomDatas1.Split(charSeparators, StringSplitOptions.RemoveEmptyEntries);
            String[] ServerCustomDataValues = targetServer.ServerCustomDatas2.Split(charSeparators, StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < ServerCustomDataNames.Length && i < ServerCustomDataValues.Length; i++)
            {
                if (ServerCustomDataNames[i].Length == 0)
                    continue;
                int index = ServerCustomDataGrid.Rows.Add();
                ServerCustomDataGrid.Rows[index].Cells[0].Value = ServerCustomDataNames[i];
                ServerCustomDataGrid.Rows[index].Cells[1].Value = ServerCustomDataValues[i];
            }

            String[] ClientCustomDataNames = targetServer.ClientCustomDatas1.Split(charSeparators, StringSplitOptions.RemoveEmptyEntries);
            String[] ClientCustomDataValues = targetServer.ClientCustomDatas2.Split(charSeparators, StringSplitOptions.RemoveEmptyEntries);

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
            if (targetServer.OverrideShooterGameModeDefaultGameIni != null)
                foreach (KeyValuePair<string, string> DicPair in targetServer.OverrideShooterGameModeDefaultGameIni)
                    pairs.Add(new ConfigKeyValueEntry(DicPair.Key, DicPair.Value));

            overrideShooterGameModeDefaultGameIniDataGridView.DataSource = pairs;

            hiddenAtlasIDTextBox.Text = targetServer.hiddenAtlasId;

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

            if (templateComboBox.Items.Contains(targetServer.serverTemplateName))
                templateComboBox.SelectedItem = targetServer.serverTemplateName;
            else
                templateComboBox.SelectedItem = "None";

            rulesComboBox.Items.Add("Unset");
            rulesComboBox.Items.Add("Lawless");
            rulesComboBox.Items.Add("Lawless Claim");
            rulesComboBox.Items.Add("Island Claim");
            rulesComboBox.Items.Add("FreePort");
            rulesComboBox.Items.Add("Golden Age");
            rulesComboBox.SelectedIndex = targetServer.forceServerRules;
            if (mainForm.currentProject.serverConfigurations != null)
            {
                foreach (ServerConfiguration serverConfiguration in mainForm.currentProject.serverConfigurations)
                {
                    PVPServerConfigurationComboBox.Items.Add(serverConfiguration.Key);
                    PVEServerConfigurationComboBox.Items.Add(serverConfiguration.Key);
                }
                PVPServerConfigurationComboBox.Text = targetServer.serverConfigurationKeyPVP;
                PVPServerConfigurationComboBox.SelectedItem = targetServer.serverConfigurationKeyPVP;

                PVEServerConfigurationComboBox.Text = targetServer.serverConfigurationKeyPVE;
                PVEServerConfigurationComboBox.SelectedItem = targetServer.serverConfigurationKeyPVE;

                BackgroundImgPathTextBox.Text = targetServer.BackgroundImgPath;
            }
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
            float billboardsOffsetX, billboardsOffsetY, billboardsOffsetZ;
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
            if (!float.TryParse(BillboardsOffsetXTextBox.Text, out billboardsOffsetX))
            {
                MessageBox.Show("Invalid number for billboardsOffsetX", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (!float.TryParse(BillboardsOffsetYTextBox.Text, out billboardsOffsetY))
            {
                MessageBox.Show("Invalid number for billboardsOffsetX", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (!float.TryParse(BillboardsOffsetZTextBox.Text, out billboardsOffsetZ))
            {
                MessageBox.Show("Invalid number for billboardsOffsetX", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

                ClientCustomDatas1 += row.Cells[0].Value.ToString() + ",";

                if (row.Cells[1].Value == null || row.Cells[1].Value.ToString().Length == 0)
                {
                    MessageBox.Show("You must assign a value to each row", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                ClientCustomDatas2 += row.Cells[1].Value.ToString() + ",";
            }

            targetServer.name = nameTxtBox.Text;
            targetServer.ip = ipTxtBox.Text;
            targetServer.port = port;
            targetServer.gamePort = gamePort;
            targetServer.seamlessDataPort = seamlessDataPort;
            targetServer.isHomeServer = homeServerCheckbox.Checked;

            if (!hiddenAtlasIDTextBox.Text.Equals(targetServer.hiddenAtlasId != null ? targetServer.hiddenAtlasId : ""))
                mainForm.PopulateMapRegionsDirty = true;
            targetServer.hiddenAtlasId = hiddenAtlasIDTextBox.Text;

            targetServer.forceServerRules = rulesComboBox.SelectedIndex;
            targetServer.AdditionalCmdLineParams = additionalCmdLineParamsTxtBox.Text;
            targetServer.oceanEpicSpawnEntriesOverrideTemplateName = oceanEpicSpawnEntriesOverrideTemplateNameTxtBox.Text;
            targetServer.NPCShipSpawnEntriesOverrideTemplateName = NPCShipSpawnEntriesOverrideTemplateNameTxtBox.Text;

            targetServer.serverConfigurationKeyPVP = PVPServerConfigurationComboBox.Text;
            targetServer.serverConfigurationKeyPVE = PVEServerConfigurationComboBox.Text;
            targetServer.BackgroundImgPath = BackgroundImgPathTextBox.Text;
            targetServer.waterColorR = waterColorR;
            targetServer.waterColorG = waterColorG;
            targetServer.waterColorB = waterColorB;
            targetServer.billboardsOffsetX = billboardsOffsetX;
            targetServer.billboardsOffsetY = billboardsOffsetY;
            targetServer.billboardsOffsetZ = billboardsOffsetZ;

            targetServer.OverrideDestNorthX = EnsureValidCellX(OverrideDestNorthXTextBox.Text);
            targetServer.OverrideDestNorthY = EnsureValidCellX(OverrideDestNorthYTextBox.Text);
            targetServer.OverrideDestSouthX = EnsureValidCellX(OverrideDestSouthXTextBox.Text);
            targetServer.OverrideDestSouthY = EnsureValidCellX(OverrideDestSouthYTextBox.Text);
            targetServer.OverrideDestEastX = EnsureValidCellX(OverrideDestEastXTextBox.Text);
            targetServer.OverrideDestEastY = EnsureValidCellX(OverrideDestEastYTextBox.Text);
            targetServer.OverrideDestWestX = EnsureValidCellX(OverrideDestWestXTextBox.Text);
            targetServer.OverrideDestWestY = EnsureValidCellX(OverrideDestWestYTextBox.Text);

            targetServer.MaxPlayingSeconds = EnsureValidPositiveInt(MaxPlayingSecondsTextBox.Text);
            targetServer.MaxPlayingSecondsKickToServerX = EnsureValidCellX(MaxPlayingSecondsKickToServerXTextBox.Text);
            targetServer.MaxPlayingSecondsKickToServerY = EnsureValidCellY(MaxPlayingSecondsKickToServerYTextBox.Text);

            targetServer.skyStyleIndex = skyStyleIndex;
            targetServer.serverIslandPointsMultiplier = serverIslandPointsMultiplier;
            targetServer.ServerCustomDatas1 = ServerCustomDatas1;
            targetServer.ServerCustomDatas2 = ServerCustomDatas2;
            targetServer.ClientCustomDatas1 = ClientCustomDatas1;
            targetServer.ClientCustomDatas2 = ClientCustomDatas2;

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


        private void rulesComboBox_DrawItem(object sender, DrawItemEventArgs e)
        {
            e.DrawBackground();
            Graphics g = e.Graphics;
            g.DrawString(rulesComboBox.Items[e.Index].ToString(), e.Font, new SolidBrush(e.ForeColor), new PointF(e.Bounds.X, e.Bounds.Y));
            e.DrawFocusRectangle();
        }


        private int EnsureValidCellX(string cellXStr)
        {
            return EnsureValidCellDimension(cellXStr, mainForm.currentProject.numOfCellsX - 1);
        }

        private int EnsureValidCellY(string cellXStr)
        {
            return EnsureValidCellDimension(cellXStr, mainForm.currentProject.numOfCellsY - 1);
        }

        private int EnsureValidCellDimension(string cellStr, int maxDimension)
        {
            if (cellStr != null && cellStr.Length > 0 && int.TryParse(cellStr, out int n))
            {
                if (n < 0)
                    n = -n;
                n = Math.Min(n, maxDimension);
                return n;
            }
            return -1;
        }

        private string CellIndexToString(int cellIndex)
        {
            return cellIndex < 0 ? "" : cellIndex.ToString();
        }


        private void OverrideDestNorthXTextBox_TextChanged(object sender, EventArgs e)
        {
            OverrideDestNorthXTextBox.Text = CellIndexToString(EnsureValidCellX(OverrideDestNorthXTextBox.Text));
        }

        private void OverrideDestNorthYTextBox_TextChanged(object sender, EventArgs e)
        {
            OverrideDestNorthYTextBox.Text = CellIndexToString(EnsureValidCellY(OverrideDestNorthYTextBox.Text));
        }

        private void OverrideDestSouthXTextBox_TextChanged(object sender, EventArgs e)
        {
            OverrideDestSouthXTextBox.Text = CellIndexToString(EnsureValidCellX(OverrideDestSouthXTextBox.Text));
        }

        private void OverrideDestSouthYTextBox_TextChanged(object sender, EventArgs e)
        {
            OverrideDestSouthYTextBox.Text = CellIndexToString(EnsureValidCellY(OverrideDestSouthYTextBox.Text));
        }

        private void OverrideDestEastXTextBox_TextChanged(object sender, EventArgs e)
        {
            OverrideDestEastXTextBox.Text = CellIndexToString(EnsureValidCellX(OverrideDestEastXTextBox.Text));
        }

        private void OverrideDestEastYTextBox_TextChanged(object sender, EventArgs e)
        {
            OverrideDestEastYTextBox.Text = CellIndexToString(EnsureValidCellY(OverrideDestEastYTextBox.Text));
        }

        private void OverrideDestWestXTextBox_TextChanged(object sender, EventArgs e)
        {
            OverrideDestWestXTextBox.Text = CellIndexToString(EnsureValidCellX(OverrideDestWestXTextBox.Text));
        }
        private void OverrideDestWestYTextBox_TextChanged(object sender, EventArgs e)
        {
            OverrideDestWestYTextBox.Text = CellIndexToString(EnsureValidCellY(OverrideDestWestYTextBox.Text));
        }

        private int EnsureValidPositiveInt(string str)
        {
            if (str != null && str.Length > 0 && int.TryParse(str, out int n))
            {
                if (n < 0)
                    n = -n;
                return n;
            }
            return 0;
        }

        private void MaxPlayingSecondsTextBox_TextChanged(object sender, EventArgs e)
        {
            MaxPlayingSecondsTextBox.Text = EnsureValidPositiveInt(MaxPlayingSecondsTextBox.Text).ToString();
        }

        private void MaxPlayingSecondsKickToServerXTextBox_TextChanged(object sender, EventArgs e)
        {
            MaxPlayingSecondsKickToServerXTextBox.Text = CellIndexToString(EnsureValidCellY(MaxPlayingSecondsKickToServerXTextBox.Text));
        }

        private void MaxPlayingSecondsKickToServerYTextBox_TextChanged(object sender, EventArgs e)
        {
            MaxPlayingSecondsKickToServerYTextBox.Text = CellIndexToString(EnsureValidCellY(MaxPlayingSecondsKickToServerYTextBox.Text));
        }
    }
}

