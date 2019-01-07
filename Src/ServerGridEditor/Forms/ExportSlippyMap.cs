using ServerGridEditor.Code;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ServerGridEditor.Forms
{
    public partial class ExportSlippyMap : Form
    {
        /// <summary>
        /// The tile image filesize varies based on zoom level, water background, and other factors.
        /// This value gives +-10% accuracy estimates for the projects that are included with the solution.
        /// </summary>
        private static readonly double AverageImageSizeMb = 0.05d;

        /// <summary>
        /// The currently selected maximum zoom level for the map. Values can range from 2 to 9.
        /// </summary>
        public int MaxZoom => maxZoomTrackBar.Value;

        /// <summary>
        /// The currently selected export directory for the map.
        /// </summary>
        public string ExportDirectory => exportDirTextBox.Text;

        /// <summary>
        /// If false, skip any tile where the file already exists.
        /// </summary>
        public bool OverwriteExisting => overwriteCheckBox.Checked;

        public ExportSlippyMap()
        {
            InitializeComponent();
            maxZoomTrackBar_ValueChanged(maxZoomTrackBar, EventArgs.Empty);
        }

        private void maxZoomTrackBar_ValueChanged(object sender, EventArgs e)
        {
            var tileCount = Enumerable
                .Range(0, MaxZoom + 1)
                .Aggregate(0, (accum, curr) =>
                    accum + (int)Math.Ceiling(Math.Pow(4, curr))
                );
            var estimatedSizeMb = Math.Round(AverageImageSizeMb * tileCount, 2);
            tileCountLabel.Text = $"{tileCount} tiles (~{estimatedSizeMb} MB)";
        }

        private void exportButton_Click(object sender, EventArgs e)
        {
            if (!Directory.Exists(ExportDirectory))
            {
                MessageBox.Show($"The path \"{ExportDirectory}\" does not exist!", "Invalid Path", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DialogResult = DialogResult.OK;
            Close();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void exportDirBrowseButton_Click(object sender, EventArgs e)
        {
            using (var browser = new FolderBrowserDialog())
            {
                if (browser.ShowDialog() != DialogResult.OK)
                {
                    return;
                }

                if (string.IsNullOrWhiteSpace(browser.SelectedPath))
                {
                    MessageBox.Show("Empty path supplied!", "Browse Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                exportDirTextBox.Text = browser.SelectedPath;
            }
        }
    }
}
