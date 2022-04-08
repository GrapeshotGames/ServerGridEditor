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
    public partial class EditNodeTemplate : Form
    {
        TransientNodeTemplate targetNodeTemplate;
        MainForm mainForm;

        public EditNodeTemplate(MainForm mainForm, TransientNodeTemplate targetNodeTemplate)
        {
            this.mainForm = mainForm;
            this.targetNodeTemplate = targetNodeTemplate;

            InitializeComponent();
            ParamsGrid.Rows.Clear();
            if (targetNodeTemplate.NodeKeyWeights == null)
                targetNodeTemplate.NodeKeyWeights = new Dictionary<string, KeyValuePair<int, double>>();

            foreach (KeyValuePair<string, KeyValuePair<int, double>> NodeKeyWeight in targetNodeTemplate.NodeKeyWeights)
            {
                int index = ParamsGrid.Rows.Add();
                ParamsGrid.Rows[index].Cells[0].Value = NodeKeyWeight.Key;
                ParamsGrid.Rows[index].Cells[1].Value = NodeKeyWeight.Value.Key;
                ParamsGrid.Rows[index].Cells[2].Value = NodeKeyWeight.Value.Value;
            }

        }

        private void EditNodeTemplate_Load(object sender, EventArgs e)
        {
            nameTxtBox.Text = targetNodeTemplate.Key;
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

            foreach (TransientNodeTemplate template in mainForm.currentProject.transientNodeTemplates)
            {
                if(nameTxtBox.Text == template.Key && targetNodeTemplate != template)
                {
                    MessageBox.Show("Another template exists with the same name", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }

            targetNodeTemplate.Key = nameTxtBox.Text;

            targetNodeTemplate.NodeKeyWeights.Clear();

            foreach (DataGridViewRow row in ParamsGrid.Rows)
            {
                if (row.Index == ParamsGrid.Rows.Count - 1) continue; //Last row is the new row
                try
                {

                    int Group;
                    if (!int.TryParse(row.Cells[1].Value.ToString(), out Group))
                    {
                        MessageBox.Show("Invalid Group", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }


                    float Weight;
                    if (!float.TryParse(row.Cells[2].Value.ToString(), out Weight))
                    {
                        MessageBox.Show("Invalid Weight", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }

                    targetNodeTemplate.NodeKeyWeights.Add(row.Cells[0].Value.ToString(), new KeyValuePair<int, double>(Group, Weight));
                }
                catch (Exception)
                {
                    MessageBox.Show("Params Must have unique name.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }

            mainForm.Invalidate();
            

            return true;
        }
    }
}
