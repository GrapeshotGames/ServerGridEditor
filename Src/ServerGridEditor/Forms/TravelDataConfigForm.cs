using AtlasGridDataLibrary;
using System;
using System.Windows.Forms;

namespace ServerGridEditor
{
    public partial class TravelDataConfigForm : Form
    {
        public BackupConfigInfo config;

        public TravelDataConfigForm()
        {
            InitializeComponent();
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
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
                config.S3KeyPrefix = s3KeyPrefixTxtBox.Text;
                config.HttpAPIKey = httpApiKeyTxtBox.Text;
                config.HttpBackupURL = httpBackupURLTxtBox.Text;
            }
            Close();
        }

        private void TravelDataConfigForm_Load(object sender, EventArgs e)
        {
            if (config != null)
            {
                backupModeCombo.SelectedIndex = backupModeCombo.FindStringExact(config.BackupMode);
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
