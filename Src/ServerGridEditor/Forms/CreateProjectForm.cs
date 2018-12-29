using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using AtlasGridDataLibrary;

namespace ServerGridEditor
{
    public partial class CreateProjectForm : Form
    {
        public MainForm mainForm;
        public Project editedProject = null;

        private TribeLogConfigInfo TribeLogConfig;
        private BackupConfigInfo TravelDataConfig;
        private SharedLogConfigInfo SharedLogConfig;

        public CreateProjectForm()
        {
            InitializeComponent();
        }

        private void CreateProjectForm_Load(object sender, EventArgs e)
        {
            TribeLogConfig = new TribeLogConfigInfo();
            TravelDataConfig = new BackupConfigInfo();
            SharedLogConfig = new SharedLogConfigInfo();

            //Load edit data
            if (editedProject != null)
            {
                if (editedProject.TribeLogConfig != null)
                    TribeLogConfig.CopyFrom(editedProject.TribeLogConfig);
                if (editedProject.TravelDataConfig != null)
                    TravelDataConfig.CopyFrom(editedProject.TravelDataConfig);
                if (editedProject.SharedLogConfig != null)
                    SharedLogConfig.CopyFrom(editedProject.SharedLogConfig);

                worldFriendlyNameTxtBox.Text = editedProject.WorldFriendlyName;
                worldAtlasPasswordTxtBox.Text = editedProject.WorldAtlasPassword;
                worldAtlasIdTxtBox.Text = editedProject.WorldAtlasId;
                mapImageURLTxtBox.Text = editedProject.MapImageURL;
                metaWorldURLTxtBox.Text = editedProject.MetaWorldURL;
                authListURLTxtBox.Text = editedProject.AuthListURL;
                baseServerArgsTxtBox.Text = editedProject.BaseServerArgs;
                if (worldAtlasIdTxtBox.Text.Length == 0)
                {
                    Random rand = new Random();
                    worldAtlasIdTxtBox.Text = rand.Next().ToString();
                }

                gridSizeTxtBox.Text = "" + editedProject.cellSize;
                columnUTCOffsetTxtBox.Text = "" + editedProject.columnUTCOffset.ToString("0.0#######");
                sizeXTxtBox.Text = "" + editedProject.numOfCellsX;
                sizeYTxtBox.Text = "" + editedProject.numOfCellsY;

                modIdTxtBox.Text = editedProject.ModIDs;

                S3localURLTxtBx.Text = editedProject.LocalS3URL;
                S3localAccesKeyIdTxtBx.Text = editedProject.LocalS3AccessKeyId;
                S3localSecretKeyTxtBx.Text = editedProject.LocalS3SecretKey;
                S3localBucketNameTxtBx.Text = editedProject.LocalS3BucketName;
                S3localRegionTxtBx.Text = editedProject.LocalS3Region;

                globalGameplaySetupTxtBox.Text = editedProject.globalGameplaySetup;

                useUTCTimeCheckbox.Checked = editedProject.bUseUTCTime;
                
                globalTransitionZTxtBox.Text = editedProject.globalTransitionMinZ.ToString();
                additionalCmdLineParamsTxtBox.Text = editedProject.AdditionalCmdLineParams;

                BindingList<ConfigKeyValueEntry> pairs = new BindingList<ConfigKeyValueEntry>();
                pairs.AddingNew += (s, a) =>
                {
                    a.NewObject = new ConfigKeyValueEntry("", "");
                };
                if (editedProject.OverrideShooterGameModeDefaultGameIni != null)
                    foreach (KeyValuePair<string, string> DicPair in editedProject.OverrideShooterGameModeDefaultGameIni)
                        pairs.Add(new ConfigKeyValueEntry(DicPair.Key, DicPair.Value));

                overrideShooterGameModeDefaultGameIniDataGridView.DataSource = pairs;

                DateTime Day0;
                if (DateTime.TryParse(editedProject.Day0, out Day0))
                    day0DateTimePicker.Value = Day0;
                else
                    day0DateTimePicker.Value = DateTime.UtcNow;

                if (editedProject.DatabaseConnections != null)
                {
                    if (editedProject.DatabaseConnections.Count > 0)
                    {
                        DBEntry1_NameTxtBx.Text = editedProject.DatabaseConnections[0].Name;
                        DBEntry1_URLTxtBx.Text = editedProject.DatabaseConnections[0].URL;
                        DBEntry1_PortTxtBx.Text = editedProject.DatabaseConnections[0].Port.ToString();
                        DBEntry1_PasswordTxtBx.Text = editedProject.DatabaseConnections[0].Password;
                    }
                    if (editedProject.DatabaseConnections.Count > 1)
                    {
                        DBEntry2_NameTxtBx.Text = editedProject.DatabaseConnections[1].Name;
                        DBEntry2_URLTxtBx.Text = editedProject.DatabaseConnections[1].URL;
                        DBEntry2_PortTxtBx.Text = editedProject.DatabaseConnections[1].Port.ToString();
                        DBEntry2_PasswordTxtBx.Text = editedProject.DatabaseConnections[1].Password;
                    }
                    if (editedProject.DatabaseConnections.Count > 2)
                    {
                        DBEntry3_NameTxtBx.Text = editedProject.DatabaseConnections[2].Name;
                        DBEntry3_URLTxtBx.Text = editedProject.DatabaseConnections[2].URL;
                        DBEntry3_PortTxtBx.Text = editedProject.DatabaseConnections[2].Port.ToString();
                        DBEntry3_PasswordTxtBx.Text = editedProject.DatabaseConnections[2].Password;
                    }
                    if (editedProject.DatabaseConnections.Count > 3)
                    {
                        DBEntry4_NameTxtBx.Text = editedProject.DatabaseConnections[3].Name;
                        DBEntry4_URLTxtBx.Text = editedProject.DatabaseConnections[3].URL;
                        DBEntry4_PortTxtBx.Text = editedProject.DatabaseConnections[3].Port.ToString();
                        DBEntry4_PasswordTxtBx.Text = editedProject.DatabaseConnections[3].Password;
                    }
                    if (editedProject.DatabaseConnections.Count > 4)
                    {
                        DBEntry5_NameTxtBx.Text = editedProject.DatabaseConnections[4].Name;
                        DBEntry5_URLTxtBx.Text = editedProject.DatabaseConnections[4].URL;
                        DBEntry5_PortTxtBx.Text = editedProject.DatabaseConnections[4].Port.ToString();
                        DBEntry5_PasswordTxtBx.Text = editedProject.DatabaseConnections[4].Password;
                    }
                }


                this.Text = "Edit project";
                createBtn.Text = "Edit";
            }
            else
            {
                Random rand = new Random();
                worldAtlasIdTxtBox.Text = rand.Next().ToString();
            }
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            Close();
        }

        private struct InstanceScaling
        {
            public Server ParentServer;
            public PointF DistanceToCenter;
        }

        private void createBtn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(worldFriendlyNameTxtBox.Text))
            {
                MessageBox.Show("You must input a world friendly name", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            float size;
            int x, y;

            if (!float.TryParse(gridSizeTxtBox.Text, out size))
            {
                MessageBox.Show("Invalid grid size", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if(size > 1400000.00)
            {
                DialogResult result = MessageBox.Show("Warning grid size is greater then the recommended value of 1400000 units, you can continue but loss of floating point precision may occur. Do you wish to continue?", "Alert", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if(result == DialogResult.No)
                {
                    return;
                }
            }

            float columnUTCOffset;
            if (!float.TryParse(columnUTCOffsetTxtBox.Text, out columnUTCOffset))
            {
                MessageBox.Show("Invalid columnUTCOffset", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!int.TryParse(sizeXTxtBox.Text, out x) || !int.TryParse(sizeYTxtBox.Text, out y))
            {
                MessageBox.Show("Invalid cell dimensions", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (editedProject != null)
            {
                editedProject.WorldFriendlyName = worldFriendlyNameTxtBox.Text;
                editedProject.WorldAtlasId = worldAtlasIdTxtBox.Text;
                editedProject.WorldAtlasPassword = worldAtlasPasswordTxtBox.Text;
                if (mapImageURLTxtBox.Text != "")
                    editedProject.MapImageURL = mapImageURLTxtBox.Text;

                editedProject.MetaWorldURL = metaWorldURLTxtBox.Text;
                editedProject.AuthListURL = authListURLTxtBox.Text;
                editedProject.MetaWorldURL = editedProject.MetaWorldURL.Trim();

                editedProject.BaseServerArgs = baseServerArgsTxtBox.Text;
                editedProject.BaseServerArgs = editedProject.BaseServerArgs.Trim();

                editedProject.LocalS3URL = S3localURLTxtBx.Text;
                editedProject.LocalS3AccessKeyId = S3localAccesKeyIdTxtBx.Text;
                editedProject.LocalS3SecretKey = S3localSecretKeyTxtBx.Text;
                editedProject.LocalS3BucketName = S3localBucketNameTxtBx.Text;
                editedProject.LocalS3Region = S3localRegionTxtBx.Text;

                editedProject.globalGameplaySetup = globalGameplaySetupTxtBox.Text;

                editedProject.bUseUTCTime = useUTCTimeCheckbox.Checked;
                editedProject.columnUTCOffset = columnUTCOffset;
                editedProject.Day0 = day0DateTimePicker.Value.ToString("yyyy-MM-dd HH:mm:ss");

                editedProject.ModIDs = modIdTxtBox.Text;

                float transitionMinZ;
                if (!float.TryParse(globalTransitionZTxtBox.Text, out transitionMinZ))
                {
                    MessageBox.Show("Invalid number for global transition minimum Z", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                editedProject.globalTransitionMinZ = transitionMinZ;


                editedProject.AdditionalCmdLineParams = additionalCmdLineParamsTxtBox.Text;

                if (editedProject.OverrideShooterGameModeDefaultGameIni != null)
                    editedProject.OverrideShooterGameModeDefaultGameIni.Clear();
                else
                    editedProject.OverrideShooterGameModeDefaultGameIni = new Dictionary<string, string>();
                foreach (DataGridViewRow row in overrideShooterGameModeDefaultGameIniDataGridView.Rows)
                    if (row.Cells[0].Value != null)
                        editedProject.OverrideShooterGameModeDefaultGameIni.Add(row.Cells[0].Value.ToString(), row.Cells[1].Value != null ?  row.Cells[1].Value.ToString() : "");

                if (editedProject.DatabaseConnections == null)
                    editedProject.DatabaseConnections = new List<DatabaseConnectionInfo>();
                editedProject.DatabaseConnections.Clear();
                if (!string.IsNullOrWhiteSpace(DBEntry1_NameTxtBx.Text) && !string.IsNullOrWhiteSpace(DBEntry1_URLTxtBx.Text))
                {
                    int Port = 0;
                    int.TryParse(DBEntry1_PortTxtBx.Text, out Port);
                    editedProject.DatabaseConnections.Add(new DatabaseConnectionInfo() { Name = DBEntry1_NameTxtBx.Text, URL = DBEntry1_URLTxtBx.Text, Port = Port, Password = DBEntry1_PasswordTxtBx.Text });
                }
                if (!string.IsNullOrWhiteSpace(DBEntry2_NameTxtBx.Text) && !string.IsNullOrWhiteSpace(DBEntry2_URLTxtBx.Text))
                {
                    int Port = 0;
                    int.TryParse(DBEntry2_PortTxtBx.Text, out Port);
                    editedProject.DatabaseConnections.Add(new DatabaseConnectionInfo() { Name = DBEntry2_NameTxtBx.Text, URL = DBEntry2_URLTxtBx.Text, Port = Port, Password = DBEntry2_PasswordTxtBx.Text });
                }
                if (!string.IsNullOrWhiteSpace(DBEntry3_NameTxtBx.Text) && !string.IsNullOrWhiteSpace(DBEntry3_URLTxtBx.Text))
                {
                    int Port = 0;
                    int.TryParse(DBEntry3_PortTxtBx.Text, out Port);
                    editedProject.DatabaseConnections.Add(new DatabaseConnectionInfo() { Name = DBEntry3_NameTxtBx.Text, URL = DBEntry3_URLTxtBx.Text, Port = Port, Password = DBEntry3_PasswordTxtBx.Text });
                }
                if (!string.IsNullOrWhiteSpace(DBEntry4_NameTxtBx.Text) && !string.IsNullOrWhiteSpace(DBEntry4_URLTxtBx.Text))
                {
                    int Port = 0;
                    int.TryParse(DBEntry4_PortTxtBx.Text, out Port);
                    editedProject.DatabaseConnections.Add(new DatabaseConnectionInfo() { Name = DBEntry4_NameTxtBx.Text, URL = DBEntry4_URLTxtBx.Text, Port = Port, Password = DBEntry4_PasswordTxtBx.Text });
                }
                if (!string.IsNullOrWhiteSpace(DBEntry5_NameTxtBx.Text) && !string.IsNullOrWhiteSpace(DBEntry5_URLTxtBx.Text))
                {
                    int Port = 0;
                    int.TryParse(DBEntry5_PortTxtBx.Text, out Port);
                    editedProject.DatabaseConnections.Add(new DatabaseConnectionInfo() { Name = DBEntry5_NameTxtBx.Text, URL = DBEntry5_URLTxtBx.Text, Port = Port, Password = DBEntry5_PasswordTxtBx.Text });
                }

                if (size > 0)
                {
                    Dictionary<IslandInstanceData, InstanceScaling> scalingDict = new Dictionary<IslandInstanceData, InstanceScaling>();

                    foreach (IslandInstanceData instance in editedProject.islandInstances)
                    {
                        InstanceScaling instanceScaling = new InstanceScaling();

                        PointF worldLoc = new PointF(instance.worldX, instance.worldY);
                        instanceScaling.ParentServer = instance.GetCurrentServer(mainForm);
                        PointF serverCenter = new PointF(instanceScaling.ParentServer.GetWorldRect(editedProject.cellSize).Left + editedProject.cellSize / 2,
                                                          instanceScaling.ParentServer.GetWorldRect(editedProject.cellSize).Top + editedProject.cellSize / 2);
                        instanceScaling.DistanceToCenter = new PointF(worldLoc.X - serverCenter.X, worldLoc.Y - serverCenter.Y);

                        scalingDict.Add(instance, instanceScaling);
                    }

                    Dictionary<DiscoveryZoneData, InstanceScaling> discoScalingDict = new Dictionary<DiscoveryZoneData, InstanceScaling>();

                    foreach (DiscoveryZoneData instance in editedProject.discoZones)
                    {
                        InstanceScaling instanceScaling = new InstanceScaling();

                        PointF worldLoc = new PointF(instance.worldX, instance.worldY);
                        instanceScaling.ParentServer = instance.GetCurrentServer(mainForm);
                        PointF serverCenter = new PointF(instanceScaling.ParentServer.GetWorldRect(editedProject.cellSize).Left + editedProject.cellSize / 2,
                                                          instanceScaling.ParentServer.GetWorldRect(editedProject.cellSize).Top + editedProject.cellSize / 2);
                        instanceScaling.DistanceToCenter = new PointF(worldLoc.X - serverCenter.X, worldLoc.Y - serverCenter.Y);

                        discoScalingDict.Add(instance, instanceScaling);
                    }

                    editedProject.cellSize = size;

                    foreach (IslandInstanceData instance in editedProject.islandInstances)
                    {
                        InstanceScaling instanceScaling = scalingDict[instance];

                        PointF newLoc = new PointF(instanceScaling.ParentServer.GetWorldRect(editedProject.cellSize).Left + editedProject.cellSize / 2,
                                                          instanceScaling.ParentServer.GetWorldRect(editedProject.cellSize).Top + editedProject.cellSize / 2);

                        newLoc.X += instanceScaling.DistanceToCenter.X;
                        newLoc.Y += instanceScaling.DistanceToCenter.Y;

                        instance.SetWorldLocation(mainForm, newLoc);
                    }

                    foreach (DiscoveryZoneData instance in editedProject.discoZones)
                    {
                        InstanceScaling instanceScaling = discoScalingDict[instance];

                        PointF newLoc = new PointF(instanceScaling.ParentServer.GetWorldRect(editedProject.cellSize).Left + editedProject.cellSize / 2,
                                                          instanceScaling.ParentServer.GetWorldRect(editedProject.cellSize).Top + editedProject.cellSize / 2);

                        newLoc.X += instanceScaling.DistanceToCenter.X;
                        newLoc.Y += instanceScaling.DistanceToCenter.Y;

                        instance.SetWorldLocation(mainForm, newLoc);
                    }
                }

                //add missing servers
                if (x > editedProject.numOfCellsX)
                {
                    for (int i = editedProject.numOfCellsX; i < x; i++)
                        for (int j = 0; j < editedProject.numOfCellsY; j++)
                            editedProject.servers.Add(new Server(i, j));
                }
                editedProject.numOfCellsX = x;

                if (y > editedProject.numOfCellsY)
                {
                    for (int i = editedProject.numOfCellsY; i < y; i++)
                        for (int j = 0; j < editedProject.numOfCellsX; j++)
                            editedProject.servers.Add(new Server(j, i));
                }
                editedProject.numOfCellsY = y;

                //remove removed server objects
                for (int i = 0; i < editedProject.servers.Count; i++)
                {
                    if (editedProject.servers[i].gridX >= x || editedProject.servers[i].gridY >= y)
                    {
                        editedProject.servers.RemoveAt(i);
                        i--;
                    }
                }

                ////Fix server seamlessdataPorts
                //for (int i = 0; i < editedProject.servers.Count; i++)
                //{
                //    editedProject.servers[i].seamlessDataPort = 27000 + (editedProject.servers[i].gridX + editedProject.servers[i].gridY * editedProject.numOfCellsX);
                //}

                if (editedProject.TribeLogConfig == null)
                    editedProject.TribeLogConfig = new TribeLogConfigInfo();
                editedProject.TribeLogConfig.CopyFrom(TribeLogConfig);

                if (editedProject.TravelDataConfig == null)
                    editedProject.TravelDataConfig = new BackupConfigInfo();
                editedProject.TravelDataConfig.CopyFrom(TravelDataConfig);

                if (editedProject.SharedLogConfig == null)
                    editedProject.SharedLogConfig = new SharedLogConfigInfo();
                editedProject.SharedLogConfig.CopyFrom(SharedLogConfig);
            }
            else
            {
                mainForm.CreateProject(size, x, y, worldFriendlyNameTxtBox.Text.Trim(), worldAtlasIdTxtBox.Text.Trim(), worldAtlasPasswordTxtBox.Text.Trim());

                //Just edit values vs passing everything down
                mainForm.currentProject.LocalS3URL = S3localURLTxtBx.Text;
                mainForm.currentProject.LocalS3AccessKeyId = S3localAccesKeyIdTxtBx.Text;
                mainForm.currentProject.LocalS3SecretKey = S3localSecretKeyTxtBx.Text;
                mainForm.currentProject.LocalS3BucketName = S3localBucketNameTxtBx.Text;
                mainForm.currentProject.LocalS3Region = S3localRegionTxtBx.Text;
                mainForm.currentProject.globalGameplaySetup = globalGameplaySetupTxtBox.Text;
                if (mainForm.currentProject.DatabaseConnections == null)
                    mainForm.currentProject.DatabaseConnections = new List<DatabaseConnectionInfo>();
                mainForm.currentProject.DatabaseConnections.Clear();
                if (!string.IsNullOrWhiteSpace(DBEntry1_NameTxtBx.Text) && !string.IsNullOrWhiteSpace(DBEntry1_URLTxtBx.Text))
                {
                    int Port = 0;
                    int.TryParse(DBEntry1_PortTxtBx.Text, out Port);
                    mainForm.currentProject.DatabaseConnections.Add(new DatabaseConnectionInfo() { Name = DBEntry1_NameTxtBx.Text, URL = DBEntry1_URLTxtBx.Text, Port = Port, Password = DBEntry1_PasswordTxtBx.Text });
                }
                if (!string.IsNullOrWhiteSpace(DBEntry2_NameTxtBx.Text) && !string.IsNullOrWhiteSpace(DBEntry2_URLTxtBx.Text))
                {
                    int Port = 0;
                    int.TryParse(DBEntry2_PortTxtBx.Text, out Port);
                    mainForm.currentProject.DatabaseConnections.Add(new DatabaseConnectionInfo() { Name = DBEntry2_NameTxtBx.Text, URL = DBEntry2_URLTxtBx.Text, Port = Port, Password = DBEntry2_PasswordTxtBx.Text });
                }
                if (!string.IsNullOrWhiteSpace(DBEntry3_NameTxtBx.Text) && !string.IsNullOrWhiteSpace(DBEntry3_URLTxtBx.Text))
                {
                    int Port = 0;
                    int.TryParse(DBEntry3_PortTxtBx.Text, out Port);
                    mainForm.currentProject.DatabaseConnections.Add(new DatabaseConnectionInfo() { Name = DBEntry3_NameTxtBx.Text, URL = DBEntry3_URLTxtBx.Text, Port = Port, Password = DBEntry3_PasswordTxtBx.Text });
                }
                if (!string.IsNullOrWhiteSpace(DBEntry4_NameTxtBx.Text) && !string.IsNullOrWhiteSpace(DBEntry4_URLTxtBx.Text))
                {
                    int Port = 0;
                    int.TryParse(DBEntry4_PortTxtBx.Text, out Port);
                    mainForm.currentProject.DatabaseConnections.Add(new DatabaseConnectionInfo() { Name = DBEntry4_NameTxtBx.Text, URL = DBEntry4_URLTxtBx.Text, Port = Port, Password = DBEntry4_PasswordTxtBx.Text });
                }
                if (!string.IsNullOrWhiteSpace(DBEntry5_NameTxtBx.Text) && !string.IsNullOrWhiteSpace(DBEntry5_URLTxtBx.Text))
                {
                    int Port = 0;
                    int.TryParse(DBEntry5_PortTxtBx.Text, out Port);
                    mainForm.currentProject.DatabaseConnections.Add(new DatabaseConnectionInfo() { Name = DBEntry5_NameTxtBx.Text, URL = DBEntry5_URLTxtBx.Text, Port = Port, Password = DBEntry5_PasswordTxtBx.Text });
                }

                mainForm.currentProject.TribeLogConfig.CopyFrom(TribeLogConfig);
                mainForm.currentProject.TravelDataConfig.CopyFrom(TravelDataConfig);
                mainForm.currentProject.SharedLogConfig.CopyFrom(SharedLogConfig);
            }
            Close();
        }

        private void sizeXTxtBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            StaticHelpers.ForceNumericKeypress(sender, e, false);
        }

        private void sizeYTxtBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            StaticHelpers.ForceNumericKeypress(sender, e, false);
        }

        private void gridSizeTxtBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            StaticHelpers.ForceNumericKeypress(sender, e);
        }

        private void tribeLogCfgBtn_Click(object sender, EventArgs e)
        {
            var ConfigForm = new TribeLogConfigForm();
            ConfigForm.config = TribeLogConfig;
            ConfigForm.ShowDialog();
        }

        private void travelConfigBtn_Click(object sender, EventArgs e)
        {
            var ConfigForm = new TravelDataConfigForm();
            ConfigForm.config = TravelDataConfig;
            ConfigForm.ShowDialog();
        }

        private void sharedLogBtn_Click(object sender, EventArgs e)
        {
            var ConfigForm = new SharedLogConfigForm();
            ConfigForm.config = SharedLogConfig;
            ConfigForm.ShowDialog();
        }

    }
}
