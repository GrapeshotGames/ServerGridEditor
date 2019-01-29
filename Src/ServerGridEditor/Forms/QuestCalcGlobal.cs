using AtlasGridDataLibrary;
using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Globalization;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;




namespace ServerGridEditor.Forms
{
    public partial class QuestCalcGlobal : Form
    {
        private bool bIsDragging = false;
        private Point startpoint = new Point(0, 0);
        private string name = null;
        private string tempStr = null;
        private float calcGridX0 = 0.0f;
        private float calcGridY0 = 0.0f;
        private float calcGridX1 = 0.0f;
        private float calcGridY1 = 0.0f;
        private float calcGridX2 = 0.0f;
        private float calcGridY2 = 0.0f;
        private float calcGridX3 = 0.0f;
        private float calcGridY3 = 0.0f;
        private float calcGridX4 = 0.0f;
        private float calcGridY4 = 0.0f;
        private float calcGridX5 = 0.0f;
        private float calcGridY5 = 0.0f;
        private float calcGridX6 = 0.0f;
        private float calcGridY6 = 0.0f;
        private float calcGridX7 = 0.0f;
        private float calcGridY7 = 0.0f;
        private float calcGridX8 = 0.0f;
        private float calcGridY8 = 0.0f;
        private float calcGridX9 = 0.0f;
        private float calcGridY9 = 0.0f;
        private float gridSize = 0;
        private int cellsX = 0;
        private int cellsY = 0;
        private string glbGps = "\"globalGameplaySetup\":";
        private string ggsStart = "\"(QuestEntries=((QuestID=0,CompletedIcon=Texture2D'/Game/Atlas/UI/Icons/Icon_PowerStonesQuest_Complete.Icon_PowerStonesQuest_Complete',UncompletedIcon=Texture2D'/Game/Atlas/UI/Icons/Icon_PowerStonesQuest_Uncomplete.Icon_PowerStonesQuest_Uncomplete',QuestName=\\\"Voyage of Power\\\",QuestDescription=\\\"Journey across the ATLAS to hunt for the Power Stones, and then bring them to the Center Maw!\\\",UnlockFeatNames=(\\\"Dance10\\\"),QuestPointsOfInterest=(";
        private string ggsMid = ",Y=";
        private string[] ggs, ggsA;
        private string ggsEnd = "))))\"";
        private int newIndex = 0;
        private float totalX = 0.0f;
        private float totalY = 0.0f;

        List<String> dsNames;
        private JObject json;
        ArrayList parentCell = new ArrayList();
        ArrayList gridXArray = new ArrayList();
        ArrayList gridYArray = new ArrayList();
        ArrayList calcGridXArray = new ArrayList();
        ArrayList calcGridYArray = new ArrayList();
        ArrayList Index = new ArrayList();
        public int NumberDecimalDigits { get; set; }
        public JObject Json { get => json; set => json = value; }

        NumberFormatInfo qcgInfo = new CultureInfo("en-US", false).NumberFormat;

        MainForm mainForm;


        public QuestCalcGlobal(MainForm mainForm)
        {
            this.mainForm = mainForm;
            InitializeComponent();
            ggs = new string[10] { "(PointOfInterestID=0,PointOfInterestName=\\\"Power Stone 1\\\",UnlockFeatNames=(\\\"Dance1\\\"),WorldMapPosition=(X=", "(PointOfInterestID=1,PointOfInterestName=\\\"Power Stone 2\\\",UnlockFeatNames=(\\\"Dance2\\\"),WorldMapPosition=(X=", "(PointOfInterestID=2,PointOfInterestName=\\\"Power Stone 3\\\",UnlockFeatNames=(\\\"Dance3\\\"),WorldMapPosition=(X=", "(PointOfInterestID=3,PointOfInterestName=\\\"Power Stone 4\\\",UnlockFeatNames=(\\\"Dance4\\\"),WorldMapPosition=(X=", "(PointOfInterestID=4,PointOfInterestName=\\\"Power Stone 5\\\",UnlockFeatNames=(\\\"Dance5\\\"),WorldMapPosition=(X=", "(PointOfInterestID=5,PointOfInterestName=\\\"Power Stone 6\\\",UnlockFeatNames=(\\\"Dance6\\\"),WorldMapPosition=(X=", "(PointOfInterestID=6,PointOfInterestName=\\\"Power Stone 7\\\",UnlockFeatNames=(\\\"Dance7\\\"),WorldMapPosition=(X=", "(PointOfInterestID=7,PointOfInterestName=\\\"Power Stone 8\\\",UnlockFeatNames=(\\\"Dance8\\\"),WorldMapPosition=(X=", "(PointOfInterestID=8,PointOfInterestName=\\\"Power Stone 9 - Ghost Ship Route\\\",UnlockFeatNames=(\\\"Dance9\\\"),WorldMapPosition=(X=", "(PointOfInterestID=9,PointOfInterestName=\\\"Bring all 9 Power Stones to Center Maw\\\",WorldMapPosition=(X=" };
            ggsA = new string[10] { "),CompletedIcon=Texture2D'/Game/Atlas/UI/Icons/Item_InfinityGem_Icon.Item_InfinityGem_Icon',UncompletedIcon=Texture2D'/Game/Atlas/UI/Icons/Item_InfinityGem_Icon10.Item_InfinityGem_Icon10'),", "),CompletedIcon=Texture2D'/Game/Atlas/UI/Icons/Item_InfinityGem_Icon2.Item_InfinityGem_Icon2',UncompletedIcon=Texture2D'/Game/Atlas/UI/Icons/Item_InfinityGem_Icon10.Item_InfinityGem_Icon10'),", "),CompletedIcon=Texture2D'/Game/Atlas/UI/Icons/Item_InfinityGem_Icon3.Item_InfinityGem_Icon3',UncompletedIcon=Texture2D'/Game/Atlas/UI/Icons/Item_InfinityGem_Icon10.Item_InfinityGem_Icon10'),", "),CompletedIcon=Texture2D'/Game/Atlas/UI/Icons/Item_InfinityGem_Icon4.Item_InfinityGem_Icon4',UncompletedIcon=Texture2D'/Game/Atlas/UI/Icons/Item_InfinityGem_Icon10.Item_InfinityGem_Icon10'),", "),CompletedIcon=Texture2D'/Game/Atlas/UI/Icons/Item_InfinityGem_Icon5.Item_InfinityGem_Icon5',UncompletedIcon=Texture2D'/Game/Atlas/UI/Icons/Item_InfinityGem_Icon10.Item_InfinityGem_Icon10'),", "),CompletedIcon=Texture2D'/Game/Atlas/UI/Icons/Item_InfinityGem_Icon6.Item_InfinityGem_Icon6',UncompletedIcon=Texture2D'/Game/Atlas/UI/Icons/Item_InfinityGem_Icon10.Item_InfinityGem_Icon10'),", "),CompletedIcon=Texture2D'/Game/Atlas/UI/Icons/Item_InfinityGem_Icon7.Item_InfinityGem_Icon7',UncompletedIcon=Texture2D'/Game/Atlas/UI/Icons/Item_InfinityGem_Icon10.Item_InfinityGem_Icon10'),", "),CompletedIcon=Texture2D'/Game/Atlas/UI/Icons/Item_InfinityGem_Icon8.Item_InfinityGem_Icon8',UncompletedIcon=Texture2D'/Game/Atlas/UI/Icons/Item_InfinityGem_Icon10.Item_InfinityGem_Icon10'),", "),CompletedIcon=Texture2D'/Game/Atlas/UI/Icons/HUD_GhostShip_Icon_Complete.HUD_GhostShip_Icon_Complete',UncompletedIcon=Texture2D'/Game/Atlas/UI/Icons/HUD_GhostShip_Icon.HUD_GhostShip_Icon'),", "),CompletedIcon=Texture2D'/Game/Atlas/UI/Icons/HUD_BossLocation_Icon_Complete.HUD_BossLocation_Icon_Complete',UncompletedIcon=Texture2D'/Game/Atlas/UI/Icons/HUD_BossLocation_Icon.HUD_BossLocation_Icon')" };

            int idx = 0;
            gridSize = mainForm.currentProject.cellSize;
            cellsX = mainForm.currentProject.numOfCellsX;
            cellsY = mainForm.currentProject.numOfCellsY;

            foreach (DiscoveryZoneData discoZone in mainForm.currentProject.discoZones)
            {
                
                dsNames = new List<string> { discoZone.name };
                name = discoZone.name;
                pwrStone0ComboBox.Items.Add(name);
                pwrStone1ComboBox.Items.Add(name);
                pwrStone2ComboBox.Items.Add(name);
                pwrStone3ComboBox.Items.Add(name);
                pwrStone4ComboBox.Items.Add(name);
                pwrStone5ComboBox.Items.Add(name);
                pwrStone6ComboBox.Items.Add(name);
                pwrStone7ComboBox.Items.Add(name);
                pwrStone8ComboBox.Items.Add(name);
                pwrStone9ComboBox.Items.Add(name);
                gridXArray.Add(discoZone.worldX);
                gridYArray.Add(discoZone.worldY);
                Index.Add(newIndex);
                newIndex += 1;
                idx += 1;

                foreach (Server servs in mainForm.currentProject.servers)
                    if (servs != null && servs.IsWorldPointInServer(new System.Drawing.PointF(discoZone.worldX, discoZone.worldY), mainForm.currentProject.cellSize))
                    {
                        parentCell.Add(servs.gridX.ToString() + "," + servs.gridY.ToString());
                    }

            }

            totalX = gridSize * cellsX;
            totalY = gridSize * cellsY;


            idx = 0;
            newIndex = 0;

        }
        
        private void closeBtn_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void QuestCalcGlobal_MouseDown(object sender, MouseEventArgs e)
        {
            bIsDragging = true;
            startpoint = new Point(e.X, e.Y);

        }

        private void QuestCalcGlobal_MouseUp(object sender, MouseEventArgs e)
        {
            bIsDragging = false;
        }

        private void QuestCalcGlobal_MouseMove(object sender, MouseEventArgs e)
        {
            if(bIsDragging)
            {
                Point p = PointToScreen(e.Location);
                Location = new Point(p.X - this.startpoint.X, p.Y - this.startpoint.Y);
            }
        }

        private void closeBtn1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void closeBtn1_MouseEnter(object sender, EventArgs e)
        {
            closeBtn1.ForeColor = Color.White;
            closeBtn1.BackColor = Color.Red;
        }

        private void pwrStone0ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            float gxA = 0.0f;
            float gyA = 0.0f;
            float gX = 0.0f;
            float gY = 0.0f;
            int ind = 0;

            ind = pwrStone0ComboBox.SelectedIndex;

            foreach (int i in Index) 
                if (i == pwrStone0ComboBox.SelectedIndex)
                {
                    

                    parentCell0TxtBox.Text = parentCell[i].ToString();
                    qcgInfo.NumberDecimalDigits = 1;
                    gxA = (float)gridXArray[i];
                    gyA = (float)gridYArray[i];
                    ps0GridXTxtBox.Text = gxA.ToString("F", qcgInfo);
                    ps0GridYTxtBox.Text = gyA.ToString("F", qcgInfo);
                    gX = (float)gridXArray[i];
                    gY = (float)gridYArray[i];
                    calcGridX0 = gX / totalX;
                    calcGridY0 = gY / totalY;
                    qcgInfo.NumberDecimalDigits = 6;
                    ps0GridXCalcTxtBox.Text = calcGridX0.ToString("F", qcgInfo);
                    ps0GridYCalcTxtBox.Text = calcGridY0.ToString("F", qcgInfo);
                }

        }

        private void pwrStone1ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            float gxA = 0.0f;
            float gyA = 0.0f;
            float gX = 0.0f;
            float gY = 0.0f;
            int ind = 0;

            ind = pwrStone1ComboBox.SelectedIndex;

            foreach (int i in Index)
                if (i == pwrStone1ComboBox.SelectedIndex)
                {


                    parentCell1TxtBox.Text = parentCell[i].ToString();
                    qcgInfo.NumberDecimalDigits = 1;
                    gxA = (float)gridXArray[i];
                    gyA = (float)gridYArray[i];
                    ps1GridXTxtBox.Text = gxA.ToString("F", qcgInfo);
                    ps1GridYTxtBox.Text = gyA.ToString("F", qcgInfo);
                    gX = (float)gridXArray[i];
                    gY = (float)gridYArray[i];
                    calcGridX1 = gX / totalX;
                    calcGridY1 = gY / totalY;
                    qcgInfo.NumberDecimalDigits = 6;
                    ps1GridXCalcTxtBox.Text = calcGridX1.ToString("F", qcgInfo);
                    ps1GridYCalcTxtBox.Text = calcGridY1.ToString("F", qcgInfo);
                }

        }

        private void pwrStone2ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            float gxA = 0.0f;
            float gyA = 0.0f;
            float gX = 0.0f;
            float gY = 0.0f;
            int ind = 0;

            ind = pwrStone2ComboBox.SelectedIndex;

            foreach (int i in Index)
                if (i == pwrStone2ComboBox.SelectedIndex)
                {


                    parentCell2TxtBox.Text = parentCell[i].ToString();
                    qcgInfo.NumberDecimalDigits = 1;
                    gxA = (float)gridXArray[i];
                    gyA = (float)gridYArray[i];
                    ps2GridXTxtBox.Text = gxA.ToString("F", qcgInfo);
                    ps2GridYTxtBox.Text = gyA.ToString("F", qcgInfo);
                    gX = (float)gridXArray[i];
                    gY = (float)gridYArray[i];
                    calcGridX2 = gX / totalX;
                    calcGridY2 = gY / totalY;
                    qcgInfo.NumberDecimalDigits = 6;
                    ps2GridXCalcTxtBox.Text = calcGridX2.ToString("F", qcgInfo);
                    ps2GridYCalcTxtBox.Text = calcGridY2.ToString("F", qcgInfo);
                }

        }

        private void pwrStone3ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            float gxA = 0.0f;
            float gyA = 0.0f;
            float gX = 0.0f;
            float gY = 0.0f;
            int ind = 0;

            ind = pwrStone3ComboBox.SelectedIndex;

            foreach (int i in Index)
                if (i == pwrStone3ComboBox.SelectedIndex)
                {


                    parentCell3TxtBox.Text = parentCell[i].ToString();
                    qcgInfo.NumberDecimalDigits = 1;
                    gxA = (float)gridXArray[i];
                    gyA = (float)gridYArray[i];
                    ps3GridXTxtBox.Text = gxA.ToString("F", qcgInfo);
                    ps3GridYTxtBox.Text = gyA.ToString("F", qcgInfo);
                    gX = (float)gridXArray[i];
                    gY = (float)gridYArray[i];
                    calcGridX3 = gX / totalX;
                    calcGridY3 = gY / totalY;
                    qcgInfo.NumberDecimalDigits = 6;
                    ps3GridXCalcTxtBox.Text = calcGridX3.ToString("F", qcgInfo);
                    ps3GridYCalcTxtBox.Text = calcGridY3.ToString("F", qcgInfo);
                }

        }

        private void pwrStone4ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            float gxA = 0.0f;
            float gyA = 0.0f;
            float gX = 0.0f;
            float gY = 0.0f;
            int ind = 0;

            ind = pwrStone4ComboBox.SelectedIndex;

            foreach (int i in Index)
                if (i == pwrStone4ComboBox.SelectedIndex)
                {


                    parentCell4TxtBox.Text = parentCell[i].ToString();
                    qcgInfo.NumberDecimalDigits = 1;
                    gxA = (float)gridXArray[i];
                    gyA = (float)gridYArray[i];
                    ps4GridXTxtBox.Text = gxA.ToString("F", qcgInfo);
                    ps4GridYTxtBox.Text = gyA.ToString("F", qcgInfo);
                    gX = (float)gridXArray[i];
                    gY = (float)gridYArray[i];
                    calcGridX4 = gX / totalX;
                    calcGridY4 = gY / totalY;
                    qcgInfo.NumberDecimalDigits = 6;
                    ps4GridXCalcTxtBox.Text = calcGridX4.ToString("F", qcgInfo);
                    ps4GridYCalcTxtBox.Text = calcGridY4.ToString("F", qcgInfo);
                }

        }

        private void pwrStone5ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            float gxA = 0.0f;
            float gyA = 0.0f;
            float gX = 0.0f;
            float gY = 0.0f;
            int ind = 0;

            ind = pwrStone5ComboBox.SelectedIndex;

            foreach (int i in Index)
                if (i == pwrStone5ComboBox.SelectedIndex)
                {


                    parentCell5TxtBox.Text = parentCell[i].ToString();
                    qcgInfo.NumberDecimalDigits = 1;
                    gxA = (float)gridXArray[i];
                    gyA = (float)gridYArray[i];
                    ps5GridXTxtBox.Text = gxA.ToString("F", qcgInfo);
                    ps5GridYTxtBox.Text = gyA.ToString("F", qcgInfo);
                    gX = (float)gridXArray[i];
                    gY = (float)gridYArray[i];
                    calcGridX5 = gX / totalX;
                    calcGridY5 = gY / totalY;
                    qcgInfo.NumberDecimalDigits = 6;
                    ps5GridXCalcTxtBox.Text = calcGridX5.ToString("F", qcgInfo);
                    ps5GridYCalcTxtBox.Text = calcGridY5.ToString("F", qcgInfo);
                }

        }

        private void pwrStone6ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            float gxA = 0.0f;
            float gyA = 0.0f;
            float gX = 0.0f;
            float gY = 0.0f;
            int ind = 0;

            ind = pwrStone6ComboBox.SelectedIndex;

            foreach (int i in Index)
                if (i == pwrStone6ComboBox.SelectedIndex)
                {


                    parentCell6TxtBox.Text = parentCell[i].ToString();
                    qcgInfo.NumberDecimalDigits = 1;
                    gxA = (float)gridXArray[i];
                    gyA = (float)gridYArray[i];
                    ps6GridXTxtBox.Text = gxA.ToString("F", qcgInfo);
                    ps6GridYTxtBox.Text = gyA.ToString("F", qcgInfo);
                    gX = (float)gridXArray[i];
                    gY = (float)gridYArray[i];
                    calcGridX6 = gX / totalX;
                    calcGridY6 = gY / totalY;
                    qcgInfo.NumberDecimalDigits = 6;
                    ps6GridXCalcTxtBox.Text = calcGridX6.ToString("F", qcgInfo);
                    ps6GridYCalcTxtBox.Text = calcGridY6.ToString("F", qcgInfo);
                }

        }

        private void pwrStone7ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            float gxA = 0.0f;
            float gyA = 0.0f;
            float gX = 0.0f;
            float gY = 0.0f;
            int ind = 0;

            ind = pwrStone7ComboBox.SelectedIndex;

            foreach (int i in Index)
                if (i == pwrStone7ComboBox.SelectedIndex)
                {


                    parentCell7TxtBox.Text = parentCell[i].ToString();
                    qcgInfo.NumberDecimalDigits = 1;
                    gxA = (float)gridXArray[i];
                    gyA = (float)gridYArray[i];
                    ps7GridXTxtBox.Text = gxA.ToString("F", qcgInfo);
                    ps7GridYTxtBox.Text = gyA.ToString("F", qcgInfo);
                    gX = (float)gridXArray[i];
                    gY = (float)gridYArray[i];
                    calcGridX7 = gX / totalX;
                    calcGridY7 = gY / totalY;
                    qcgInfo.NumberDecimalDigits = 6;
                    ps7GridXCalcTxtBox.Text = calcGridX7.ToString("F", qcgInfo);
                    ps7GridYCalcTxtBox.Text = calcGridY7.ToString("F", qcgInfo);
                }

        }

        private void pwrStone8ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            float gxA = 0.0f;
            float gyA = 0.0f;
            float gX = 0.0f;
            float gY = 0.0f;
            int ind = 0;

            ind = pwrStone8ComboBox.SelectedIndex;

            foreach (int i in Index)
                if (i == pwrStone8ComboBox.SelectedIndex)
                {


                    parentCell8TxtBox.Text = parentCell[i].ToString();
                    qcgInfo.NumberDecimalDigits = 1;
                    gxA = (float)gridXArray[i];
                    gyA = (float)gridYArray[i];
                    ps8GridXTxtBox.Text = gxA.ToString("F", qcgInfo);
                    ps8GridYTxtBox.Text = gyA.ToString("F", qcgInfo);
                    gX = (float)gridXArray[i];
                    gY = (float)gridYArray[i];
                    calcGridX8 = gX / totalX;
                    calcGridY8 = gY / totalY;
                    qcgInfo.NumberDecimalDigits = 6;
                    ps8GridXCalcTxtBox.Text = calcGridX8.ToString("F", qcgInfo);
                    ps8GridYCalcTxtBox.Text = calcGridY8.ToString("F", qcgInfo);
                }

        }

        private void pwrStone9ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            float gxA = 0.0f;
            float gyA = 0.0f;
            float gX = 0.0f;
            float gY = 0.0f;
            int ind = 0;

            ind = pwrStone9ComboBox.SelectedIndex;

            foreach (int i in Index)
                if (i == pwrStone9ComboBox.SelectedIndex)
                {


                    parentCell9TxtBox.Text = parentCell[i].ToString();
                    qcgInfo.NumberDecimalDigits = 1;
                    gxA = (float)gridXArray[i];
                    gyA = (float)gridYArray[i];
                    ps9GridXTxtBox.Text = gxA.ToString("F", qcgInfo);
                    ps9GridYTxtBox.Text = gyA.ToString("F", qcgInfo);
                    gX = (float)gridXArray[i];
                    gY = (float)gridYArray[i];
                    calcGridX9 = gX / totalX;
                    calcGridY9 = gY / totalY;
                    qcgInfo.NumberDecimalDigits = 6;
                    ps9GridXCalcTxtBox.Text = calcGridX9.ToString("F", qcgInfo);
                    ps9GridYCalcTxtBox.Text = calcGridY9.ToString("F", qcgInfo);
                }

        }

        private void GenerateBtn_Click(object sender, EventArgs e)
        {
            string tempString = null;
            string sectStr = null;
            if (ps0GridXCalcTxtBox.Text != "")
            {
                calcGridXArray.Add(ps0GridXCalcTxtBox.Text);
            }
            else
            {
                calcGridXArray.Add("0.000000");
            }
            if (ps1GridXCalcTxtBox.Text != "")
            {
                calcGridXArray.Add(ps1GridXCalcTxtBox.Text);
            }
            else
            {
                calcGridXArray.Add("0.000000");
            }
            if (ps2GridXCalcTxtBox.Text != "")
            {
                calcGridXArray.Add(ps2GridXCalcTxtBox.Text);
            }
            else
            {
                calcGridXArray.Add("0.000000");
            }
            if (ps3GridXCalcTxtBox.Text != "")
            {
                calcGridXArray.Add(ps3GridXCalcTxtBox.Text);
            }
            else
            {
                calcGridXArray.Add("0.000000");
            }
            if (ps4GridXCalcTxtBox.Text != "")
            {
                calcGridXArray.Add(ps4GridXCalcTxtBox.Text);
            }
            else
            {
                calcGridXArray.Add("0.000000");
            }
            if (ps5GridXCalcTxtBox.Text != "")
            {
                calcGridXArray.Add(ps5GridXCalcTxtBox.Text);
            }
            else
            {
                calcGridXArray.Add("0.000000");
            }
            if (ps6GridXCalcTxtBox.Text != "")
            {
                calcGridXArray.Add(ps6GridXCalcTxtBox.Text);
            }
            else
            {
                calcGridXArray.Add("0.000000");
            }
            if (ps7GridXCalcTxtBox.Text != "")
            {
                calcGridXArray.Add(ps7GridXCalcTxtBox.Text);
            }
            else
            {
                calcGridXArray.Add("0.000000");
            }
            if (ps8GridXCalcTxtBox.Text != "")
            {
                calcGridXArray.Add(ps8GridXCalcTxtBox.Text);
            }
            else
            {
                calcGridXArray.Add("0.000000");
            }
            if (ps9GridXCalcTxtBox.Text != "")
            {
                calcGridXArray.Add(ps9GridXCalcTxtBox.Text);
            }
            else
            {
                calcGridXArray.Add("0.000000");
            }



            if (ps0GridYCalcTxtBox.Text != "")
            {
                calcGridYArray.Add(ps0GridYCalcTxtBox.Text);
            }
            else
            {
                calcGridYArray.Add("0.000000");
            }
            if (ps1GridYCalcTxtBox.Text != "")
            {
                calcGridYArray.Add(ps1GridYCalcTxtBox.Text);
            }
            else
            {
                calcGridYArray.Add("0.000000");
            }
            if (ps2GridYCalcTxtBox.Text != "")
            {
                calcGridYArray.Add(ps2GridYCalcTxtBox.Text);
            }
            else
            {
                calcGridYArray.Add("0.000000");
            }
            if (ps3GridYCalcTxtBox.Text != "")
            {
                calcGridYArray.Add(ps3GridYCalcTxtBox.Text);
            }
            else
            {
                calcGridYArray.Add("0.000000");
            }
            if (ps4GridYCalcTxtBox.Text != "")
            {
                calcGridYArray.Add(ps4GridYCalcTxtBox.Text);
            }
            else
            {
                calcGridYArray.Add("0.000000");
            }
            if (ps5GridYCalcTxtBox.Text != "")
            {
                calcGridYArray.Add(ps5GridYCalcTxtBox.Text);
            }
            else
            {
                calcGridYArray.Add("0.000000");
            }
            if (ps6GridYCalcTxtBox.Text != "")
            {
                calcGridYArray.Add(ps6GridYCalcTxtBox.Text);
            }
            else
            {
                calcGridYArray.Add("0.000000");
            }
            if (ps7GridYCalcTxtBox.Text != "")
            {
                calcGridYArray.Add(ps7GridYCalcTxtBox.Text);
            }
            else
            {
                calcGridYArray.Add("0.000000");
            }
            if (ps8GridYCalcTxtBox.Text != "")
            {
                calcGridYArray.Add(ps8GridYCalcTxtBox.Text);
            }
            else
            {
                calcGridYArray.Add("0.000000");
            }
            if (ps9GridYCalcTxtBox.Text != "")
            {
                calcGridYArray.Add(ps9GridYCalcTxtBox.Text);
            }
            else
            {
                calcGridYArray.Add("0.000000");
            }

            tempString = "{ " + glbGps + ggsStart;

            for(int i = 0; i < 10; ++i)
            {
                sectStr += ggs[i] + calcGridXArray[i] + ggsMid + calcGridYArray[i] + ggsA[i];

            }
            tempString += sectStr + ggsEnd + " }";

            ApplyBtn.Visible = true;


            json = JObject.Parse(tempString);

            QuestEntriesTxtBox.Text = (String)json.ToString().TrimStart('\r','\n','{',' ').TrimEnd('\r','\n',' ','}') + ",";
            tempStr = QuestEntriesTxtBox.Text;
            tempStr = tempStr.Replace("\"globalGameplaySetup\":", "").TrimStart(' ');
            QuestEntriesTxtBox.Text = tempStr;

            calcGridYArray.Clear();
            calcGridYArray.Clear();
        }

        private void ApplyBtn_Click(object sender, EventArgs e)
        {
            tempStr = tempStr.TrimEnd(',');
            if (mainForm.currentProject != null)
            {
                mainForm.currentProject.globalGameplaySetup = (string)JsonConvert.DeserializeObject<JValue>(tempStr);
            }
            else
            {
                MessageBox.Show("No Project Found!");
            }

            ApplyBtn.Visible = false;

            newIndex = 0;
            Close();

        }

        private void closeBtn1_MouseLeave(object sender, EventArgs e)
        {
            closeBtn1.ForeColor = ForeColor;
            closeBtn1.BackColor = BackColor;
        }
    }
}
