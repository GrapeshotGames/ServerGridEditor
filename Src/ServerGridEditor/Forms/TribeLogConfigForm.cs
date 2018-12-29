using AtlasGridDataLibrary;
using System;
using System.Windows.Forms;

namespace ServerGridEditor
{
    public partial class TribeLogConfigForm : Form
    {
        public TribeLogConfigInfo config;

        public TribeLogConfigForm()
        {
            InitializeComponent();
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            int maxFileHistory = 0;
            if (!int.TryParse(maxFileHistoryTxtBox.Text, out maxFileHistory))
            {
                MessageBox.Show("Invalid Max File History type, must be a number", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int maxRedis = 0;
            if (!int.TryParse(maxRedisLinesTxtBox.Text, out maxRedis))
            {
                MessageBox.Show("Invalid Max Redis Lines, must be a number", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                config.MaxRedisEntries = Int32.Parse(maxRedisLinesTxtBox.Text);
                config.S3KeyPrefix = s3KeyPrefixTxtBox.Text;
                config.HttpAPIKey = httpApiKeyTxtBox.Text;
                config.HttpBackupURL = httpBackupURLTxtBox.Text;
            }
            Close();
        }

        private void TribeLogConfigForm_Load(object sender, EventArgs e)
        {
            if (config != null)
            {
                backupModeCombo.SelectedIndex = backupModeCombo.FindStringExact(config.BackupMode);
                maxFileHistoryTxtBox.Text = config.MaxFileHistory.ToString();
                maxRedisLinesTxtBox.Text = config.MaxRedisEntries.ToString();
                s3KeyPrefixTxtBox.Text = config.S3KeyPrefix;
                httpApiKeyTxtBox.Text = config.HttpAPIKey;
                httpBackupURLTxtBox.Text = config.HttpBackupURL;
            }
            else
            {
                backupModeCombo.SelectedIndex = 0;
            }
        }
    }
}
