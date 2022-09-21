using AtlasGridDataLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ServerGridEditor
{
    public partial class ShipInBottleDataConfigForm : Form
    {
        public ShipBiottleConfigInfo config;

        public ShipInBottleDataConfigForm()
        {
            InitializeComponent();
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {

            if (config != null)
            {
                config.S3KeyPrefix = s3KeyPrefixTxtBox.Text;
                config.HttpAPIKey = httpApiKeyTxtBox.Text;
                config.HttpBackupURL = httpBackupURLTxtBox.Text;
            }
            Close();
        }

        private void ShipInBottleDataConfigForm_Load(object sender, EventArgs e)
        {
            if (config != null)
            {
                s3KeyPrefixTxtBox.Text = config.S3KeyPrefix;
                httpApiKeyTxtBox.Text = config.HttpAPIKey;
                httpBackupURLTxtBox.Text = config.HttpBackupURL;
            }
        }
    }
}
