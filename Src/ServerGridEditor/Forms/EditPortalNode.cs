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

namespace ServerGridEditor.Forms
{
    public partial class EditPortalNode : Form
    {
        public PortalPathData PortalPath;
        public PortalPathNode PortalNode;
        MainForm mainForm;

        public EditPortalNode(PortalPathNode PortalNode, MainForm mainForm)
        {
            InitializeComponent();
            this.PortalNode = PortalNode;
            PortalPath = PortalNode.portalPathData;
            nameTxtBox.Text = PortalNode.PortalName;
            this.mainForm = mainForm;

            foreach (KeyValuePair<string, int> NodeKeyWeight in PortalNode.RequiredResource)
            {
                int index = ParamsGrid.Rows.Add();
                ParamsGrid.Rows[index].Cells[0].Value = NodeKeyWeight.Key;
                ParamsGrid.Rows[index].Cells[1].Value = NodeKeyWeight.Value;
            }

            if (PortalNode.RequiredResourceOr != null)
                foreach (KeyValuePair<string, int> NodeKeyWeight in PortalNode.RequiredResourceOr)
                {
                    int index = ParamsOrGrid.Rows.Add();
                    ParamsOrGrid.Rows[index].Cells[0].Value = NodeKeyWeight.Key;
                    ParamsOrGrid.Rows[index].Cells[1].Value = NodeKeyWeight.Value;
                }

        }

        private void EditTradeWind_Load(object sender, EventArgs e)
        {

        }

        private void applyBtn_Click(object sender, EventArgs e)
        {
            Save();
            Close();
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


            List<PortalPathData> portalPaths = new List<PortalPathData>();

            portalPaths.AddRange(mainForm.currentProject.portalPaths);

            foreach (PortalPathData portalPathData in portalPaths)
            {
                foreach (PortalPathNode portalPathNode in portalPathData.Nodes)
                {
                    if (nameTxtBox.Text == portalPathNode.PortalName && portalPathNode != PortalNode)
                    {
                        MessageBox.Show("Another Portal Name exists with the same name", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }
            }
            PortalNode.PortalName = nameTxtBox.Text;
            PortalNode.RequiredResource.Clear();

            foreach (DataGridViewRow row in ParamsGrid.Rows)
            {
                if (row.Index == ParamsGrid.Rows.Count - 1) continue; //Last row is the new row
                try
                {
                    int Count;

                    if (!int.TryParse(row.Cells[1].Value.ToString(), out Count))
                    {
                        MessageBox.Show("Invalid number", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }

                    PortalNode.RequiredResource.Add(row.Cells[0].Value.ToString(), Count);
                }
                catch (Exception)
                {
                    MessageBox.Show("Params Must have unique name.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }

            if (PortalNode.RequiredResourceOr == null)
                PortalNode.RequiredResourceOr = new Dictionary<string, int>();
            else
                PortalNode.RequiredResourceOr.Clear();

            foreach (DataGridViewRow row in ParamsOrGrid.Rows)
            {
                if (row.Index == ParamsOrGrid.Rows.Count - 1) continue; //Last row is the new row
                try
                {
                    int Count;

                    if (!int.TryParse(row.Cells[1].Value.ToString(), out Count))
                    {
                        MessageBox.Show("Invalid number", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                    PortalNode.RequiredResourceOr.Add(row.Cells[0].Value.ToString(), Count);
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
