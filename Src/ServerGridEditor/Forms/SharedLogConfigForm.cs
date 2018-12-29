using AtlasGridDataLibrary;
using System;
using System.Windows.Forms;

namespace ServerGridEditor
{
    public partial class SharedLogConfigForm : Form
    {
        public SharedLogConfigInfo config;

        public SharedLogConfigForm()
        {
            InitializeComponent();
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            int tmp = 0;
            if (!int.TryParse(maxFileHistoryTxtBox.Text, out tmp))
            {
                MessageBox.Show("Invalid Max File History type, must be a number", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!int.TryParse(fetchRateSecTxtBox.Text, out tmp))
            {
                MessageBox.Show("Invalid Fetch Rate Sec, must be a number", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!int.TryParse(snapCleanSecTxtBox.Text, out tmp))
            {
                MessageBox.Show("Invalid Snapshot Cleanup Sec, must be a number", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!int.TryParse(snapRateSecTxtBox.Text, out tmp))
            {
                MessageBox.Show("Invalid Snapshot Rate Sec, must be a number", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!int.TryParse(snapExpHoursTxtBox.Text, out tmp))
            {
                MessageBox.Show("Invalid Snapshot Expiration Hours, must be a number", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            switch (backupModeCombo.SelectedIndex)
            {
                case 0: // off
                    break;
                case 1: // s3
                    break;
                case 2: // http
                    if (String.IsNullOrWhiteSpace(httpBackupURLTxtBox.Text))
                    {
                        MessageBox.Show("HTTP Backup URL must be provided", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    break;
            }

            if (config != null)
            {
                config.BackupMode = backupModeCombo.Items[backupModeCombo.SelectedIndex].ToString();
                config.MaxFileHistory = Int32.Parse(maxFileHistoryTxtBox.Text);
                config.S3KeyPrefix = s3KeyPrefixTxtBox.Text;
                config.HttpAPIKey = httpApiKeyTxtBox.Text;
                config.HttpBackupURL = httpBackupURLTxtBox.Text;
                config.FetchRateSec = Int32.Parse(fetchRateSecTxtBox.Text);
                config.SnapshotCleanupSec = Int32.Parse(snapCleanSecTxtBox.Text);
                config.SnapshotRateSec = Int32.Parse(snapRateSecTxtBox.Text);
                config.SnapshotExpirationHours = Int32.Parse(snapExpHoursTxtBox.Text);
            }
            Close();
        }

        private void SharedLogConfigForm_Load(object sender, EventArgs e)
        {
            if (config != null)
            {
                backupModeCombo.SelectedIndex = backupModeCombo.FindStringExact(config.BackupMode);
                maxFileHistoryTxtBox.Text = config.MaxFileHistory.ToString();
                s3KeyPrefixTxtBox.Text = config.S3KeyPrefix;
                httpApiKeyTxtBox.Text = config.HttpAPIKey;
                httpBackupURLTxtBox.Text = config.HttpBackupURL;
                fetchRateSecTxtBox.Text = config.FetchRateSec.ToString();
                snapCleanSecTxtBox.Text = config.SnapshotCleanupSec.ToString();
                snapRateSecTxtBox.Text = config.SnapshotRateSec.ToString();
                snapExpHoursTxtBox.Text = config.SnapshotExpirationHours.ToString();
            }
            else
            {
                backupModeCombo.SelectedIndex = 0;
            }
        }
    }
}
