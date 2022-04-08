using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Newtonsoft.Json;
using System.Reflection;
using ImageMagick;
using System.Threading;
using System.Diagnostics;
using ServerGridEditor.Properties;
using System.Runtime.InteropServices;
using ServerGridEditor.Forms;
using ServerGridEditor.Code;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
using AtlasGridDataLibrary;
using System.Text.RegularExpressions;

namespace ServerGridEditor
{
    public partial class MainForm : Form
    {
        public static string imgsDir = "./IslandImages";
        public static string modImgsDir = "/Images/";
        public static string waterTilesDir = "./WaterTiles";
        public static string foregroundTilesDir = "./Foregrounds";
        public static string tradeWindsOverlayDir = "./TradeWinds";
        public static string dataDir = "./Data";
        public static string exportDir = "./Export";
        public static string islandModsDir = "./IslandExtensions";
        public static string configSaveFile = dataDir + "/config.json";
        public static string islandsJson = "/islands.json";
        public static string islandsSaveFile = dataDir + islandsJson;
        public static string spawnersSaveFile = dataDir + "/spawners.json";
        public static string islandsSaveFileBackup = dataDir + "/islands-backup.json";

        public void InvalidateMapPanel() { mapPanel.Invalidate(); }

        public static string lifecycleBucketsPrefix = "SeamlessTravelData";
        public static string lifecycleRuleName = "ExpireRule";
        public static string rootDir = "../..";
        public static string gameDir = rootDir + "/Projects/ShooterGame";
        public static string gameMapsRelativePath = gameDir + "/Content/Maps"; //This is relative to the current location of this directory, and will be overwritten by the saved location in the config
        public static string tempJsonFile = "TempGridData.json";
        public static string actualJsonFile = "ServerGrid.json";
        public static string cellImageNameTemplate = "/{0}_{1}-{2}{3}";

        public static string engineExe = rootDir + "/Engine/Binaries/Win64/UE4Editor.exe";
        public static string serverArgs = "\"ShooterGame/ShooterGame.uproject\" Ocean?listen?ServerX={0}?ServerY={1}?AltSaveDirectoryName=Server{2}?MapPlayerLocation=true?GridConfig=\"" + tempJsonFile + "\" -log -server -SkipSeamlessTravelCloudBackup -disablesaveload";
        public static string serverArgsWithAws = "\"ShooterGame/ShooterGame.uproject\" Ocean?listen?ServerX={0}?ServerY={1}?AltSaveDirectoryName=Server{2}?MapPlayerLocation=true -log -server";
        public static string clientArgs = "\"ShooterGame/ShooterGame.uproject\" {0}:{1} -game -Log";
        public static string clearSaveDataArg = " -ClearSaveData";
        public static string ImageOverridesDirectoryName = "ImageOverrides";
        public static int lifecycleDays = 8;
        public static float scrollSpeed = 1.5f;
        public static float outlineShift = 0.07f;
        public static int maxImageSize = 4096;
        public static string defaultDiscoImagePath = "Resources/discoZoneBox.png";
        public static float lockImgRatio = 0.05f;
        public static float bezierNodeRatio = 0.05f;
        public static float bezierNodeArrowRatio = 0.08f;
        public static float islandNameScale = 0.01f;
        public static float useFullIslandRes = 5000;
        public static float islandsNamesMaxRes = 10000;

        public Cursor editCursor;
        public Project currentProject = null;
        public bool bIsloadingProject = false;
        public Dictionary<string, Island> islands = new Dictionary<string, Island>();

        public Dictionary<string, Image> regionsTile = new Dictionary<string, Image>();
        public Dictionary<string, TextureBrush> regionsTileBrush = new Dictionary<string, TextureBrush>();

        static Image lockImg = null;
        public Image foreground = null;
        public TextureBrush foregroundBrush = null;
        public Image tradeWindOverlay = null;
        public TextureBrush tradeWindOverlayBrush = null;

        public Dictionary<string, Image> regionsTradeWindOverlay = new Dictionary<string, Image>();
        public Dictionary<string, TextureBrush> regionsTradeWindOverlayBrush = new Dictionary<string, TextureBrush>();

        MoveableObjectData CurrentHeldMoveableObject = null;
        MoveableObjectData CurrentRotatedMoveableObject = null;

        bool bResizingDiscoZone = false;
        Point LastMouseLocation;
        public Config editorConfig;

        public Spawners spawners;

        public struct MapRegion
        {
            public string AtlasID;
            public string RegionName;
            public int StartX;
            public int StartY;
            public int EndX;
            public int EndY;
        }

        public bool PopulateMapRegionsDirty = true;
        Dictionary<string, MapRegion> MapRegionsList = new Dictionary<string, MapRegion>();

        public MainForm()
        {
            //DoubleBuffered = true;
            InitializeComponent();

            //replace map panel with a custom one
            Panel originalPanel = mapPanel;

            Bitmap bmp = (Bitmap)Bitmap.FromFile("Resources/pencur.png");
            bmp.MakeTransparent(Color.Black);
            IntPtr ptr1 = bmp.GetHicon();
            editCursor = new Cursor(ptr1);

            lockImg = Image.FromFile("Resources/lock.png");

            if (File.Exists(spawnersSaveFile))
                spawners = JsonConvert.DeserializeObject<Spawners>(File.ReadAllText(spawnersSaveFile));
            else
                spawners = new Spawners();

            mapPanel = new MapPanel();
            mapPanel.AllowDrop = originalPanel.AllowDrop;
            mapPanel.BackColor = originalPanel.BackColor;
            mapPanel.Location = originalPanel.Location;
            mapPanel.Name = originalPanel.Name;
            mapPanel.Size = originalPanel.Size;
            mapPanel.TabIndex = originalPanel.TabIndex;
            mapPanel.Anchor = originalPanel.Anchor;
            mapPanel.DragDrop += new System.Windows.Forms.DragEventHandler(this.mapPanel_DragDrop);
            mapPanel.DragOver += new System.Windows.Forms.DragEventHandler(this.mapPanel_DragOver);
            mapPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.mapPanel_MouseDown);
            mapPanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.mapPanel_MouseMove);
            mapPanel.MouseUp += new System.Windows.Forms.MouseEventHandler(this.mapPanel_MouseUp);
            mapPanel.MouseWheel += new System.Windows.Forms.MouseEventHandler(this.mapPanel_MouseWheel);

            ((MapPanel)mapPanel).mainForm = this;

            Controls.Remove(originalPanel);
            Controls.Add(mapPanel);

            //Create local dirctories if not found
            if (!Directory.Exists(imgsDir))
                Directory.CreateDirectory(imgsDir);
            if (!Directory.Exists(dataDir))
                Directory.CreateDirectory(dataDir);
            if (!Directory.Exists(waterTilesDir))
                Directory.CreateDirectory(waterTilesDir);
            if (!Directory.Exists(foregroundTilesDir))
                Directory.CreateDirectory(foregroundTilesDir);
            if (!Directory.Exists(tradeWindsOverlayDir))
                Directory.CreateDirectory(tradeWindsOverlayDir);
            if (!Directory.Exists(islandModsDir))
                Directory.CreateDirectory(islandModsDir);
            //if (!Directory.Exists(exportDir))
            //    Directory.CreateDirectory(exportDir);

            if (File.Exists(configSaveFile))
            {
                try
                {
                    editorConfig = JsonConvert.DeserializeObject<Config>(File.ReadAllText(configSaveFile));
                }
                catch
                {
                    editorConfig = new Config();
                }
            }
            else
                editorConfig = new Config();

            cellImageSizetxtbox.Text = editorConfig.CellImagesRes + "";
            atlasImageSizeTxtBox.Text = editorConfig.AtlasImagesRes + "";
            imageQualityTxtbox.Text = editorConfig.ImageQuality + "";
            LoadIslands();

            SetToolsVisibility(false);
        }

        public void SaveConfig()
        {
            string json = JsonConvert.SerializeObject(editorConfig, Formatting.Indented);
            File.WriteAllText(configSaveFile, json);
        }

        public void SetToolsVisibility(bool isVisible)
        {
            //Hide everything prior to loading
            foreach (Control Cont in Controls)
            {
                if (!(Cont is MenuStrip))
                {
                    Cont.Visible = isVisible;
                }
            }

            loadProjBtn.Visible = !isVisible;
            createProjBtn.Visible = !isVisible;
        }

        public void EnableProjectMenuItems()
        {
            editToolStripMenuItem.Enabled = true;
            saveToolStripMenuItem.Enabled = true;
            mapImageToolStripMenuItem.Enabled = true;
            slippyMapToolStripMenuItem.Enabled = true;
            cellImagesToolStripMenuItem.Enabled = true;
            exportAllToolStripMenuItem.Enabled = true;
            editServerTemplatesToolStripMenuItem.Enabled = true;
            testAllServersWithoutDataClearToolStripMenuItem.Enabled = true;
        }

        public void SetScaleTxt(float unrealUnits)
        {
            scaleLbl.Text = "1 pixel = " + unrealUnits + " unreal units";
        }

        public void RefreshIslandList()
        {
            ImageList imgList = new ImageList();
            imgList.ImageSize = new Size(64, 64);
            imgList.ColorDepth = ColorDepth.Depth32Bit;

            int selectedIndex = islandListBox.SelectedItems.Count > 0 ? islandListBox.SelectedItems[0].Index : 0;
            int topItemIndex = islandListBox.TopItem != null ? islandListBox.TopItem.Index : selectedIndex;

            islandListBox.Items.Clear();
            islandListBox.LargeImageList = imgList;
            islandListBox.SmallImageList = imgList;
            int i = 0;

            List<string> SortedIslands = islands.Keys.ToList();
            SortedIslands.Sort();

            Regex rx = new Regex(this.txtSearch.Text, RegexOptions.Compiled | RegexOptions.IgnoreCase);
            foreach (string islandKey in SortedIslands)
            {
                Island island = islands[islandKey];
                if (!String.IsNullOrEmpty(this.txtSearch.Text))
                {
                    if (!rx.IsMatch(island.name))
                    {
                        continue;
                    }
                }

                imgList.Images.Add(island.GetImage());
                ListViewItem listItem = new ListViewItem();
                listItem.ImageIndex = i;
                listItem.SubItems.Add(island.x + "x" + island.y);
                listItem.SubItems.Add(island.name);
                islandListBox.Items.Add(listItem);

                i++;
            }

            islandListBox.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);

            if (topItemIndex < islandListBox.Items.Count)
                islandListBox.TopItem =  islandListBox.Items[topItemIndex];

            islandListBox.Select();
            islandListBox.HideSelection = false;

            ListViewItem item = null;
            if (selectedIndex < islandListBox.Items.Count)
                item = islandListBox.Items[selectedIndex];
            else if (islandListBox.Items.Count > 0)
                item = islandListBox.Items[islandListBox.Items.Count - 1];

            if (item != null)
            {
                item.EnsureVisible();
                islandListBox.FocusedItem = item;
                item.Selected = true;
            }
        }

        public void mapPanel_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            DrawMapToGraphics(ref g, true);
        }

        public void UpdateScrollBars()
        {
            if (currentProject == null)
                return;

            float cellSize = currentProject.cellSize * currentProject.coordsScaling;

            float maxX = currentProject.numOfCellsX * cellSize;
            float maxY = currentProject.numOfCellsY * cellSize;

            //mapHScrollBar.Maximum = 1;
            mapHScrollBar.Enabled = maxX > mapPanel.Width;
            if (mapHScrollBar.Enabled)
                mapHScrollBar.Maximum = (int)Math.Ceiling(maxX - mapPanel.Width);

            mapVScrollBar.Enabled = maxY > mapPanel.Height;
            if (mapVScrollBar.Enabled)
                mapVScrollBar.Maximum = (int)Math.Ceiling(maxY - mapPanel.Height);
        }
        
        public Dictionary<long, int> DrawMapToGraphics(ref Graphics g, bool cull = false, bool isSingleCell = false, bool forExport = false, int startX = 0, int startY = 0, int cellX = -1, int cellY = -1, int OverrideNumCellsX = -1, int OverrideNumCellsY = -1)
        {
            bool bHasOverrideNumCells = OverrideNumCellsX > -1 || OverrideNumCellsY > -1;
            bool ignoreTranslation = isSingleCell;
            if (currentProject == null)
                return null;
            if (!forExport)
                UpdateScrollBars();
            
            RectangleF? culling = null;
            if (cull)
            {
                float cullMargin = 10;
                culling = new RectangleF(mapHScrollBar.Value - cullMargin, mapVScrollBar.Value - cullMargin, mapPanel.Size.Width + 2 * cullMargin, mapPanel.Size.Height + 2 * cullMargin);
            }
            
            Color? alphaBackground = null;
            if (!alphaBgCheckbox.Checked)
            {
                alphaBackground = mapPanel.BackColor;
            }

            int mapHScrollBarValue = 0;
            int mapVScrollBarValue = 0;
            if (!ignoreTranslation)
            {
                lock(mapVScrollBar)
                {
                    mapHScrollBarValue = mapHScrollBar.Value;
                    mapVScrollBarValue = mapVScrollBar.Value;

                }
            }

            if(!forExport)
                PopulateMapRegions();
            return DrawMap(
                this, islands, g,
                showLinesCheckbox.Checked, showServerInfoCheckbox.Checked, showDiscoZoneInfoCheckbox.Checked,
                culling, alphaBackground,
                tiledBackgroundCheckbox.Checked ? regionsTile : null,
                tiledBackgroundCheckbox.Checked ? regionsTileBrush : null,
                tileScaleBox.Value,
                mapHScrollBarValue,
                mapVScrollBarValue,
                forExport, showPathingGridCheckbox.Checked, startX, startY, isSingleCell, cellX, cellY, OverrideNumCellsX, OverrideNumCellsY);
        }

        static StringFormat centeredStringFormat = new StringFormat
        {
            LineAlignment = StringAlignment.Center,
            Alignment = StringAlignment.Center
        };


        private static Point CubicBezier(float t, PointF Point0, PointF Point1, PointF Point2, PointF Point3)
        {
            return new Point(
                (int)(Point0.X * Math.Pow((1 - t), 3) + Point1.X * 3 * t * Math.Pow((1 - t), 2) + Point2.X * 3 * Math.Pow(t, 2) * (1 - t) + Point3.X * Math.Pow(t, 3)),
                (int)(Point0.Y * Math.Pow((1 - t), 3) + Point1.Y * 3 * t * Math.Pow((1 - t), 2) + Point2.Y * 3 * Math.Pow(t, 2) * (1 - t) + Point3.Y * Math.Pow(t, 3))
            );
        }

        public static float MapValueFromTo(float Value, float FromMin, float ToMin, float FromMax, float ToMax)
        {
            if (FromMin == ToMin)
                return FromMax;
            return (Value - FromMin) / (ToMin - FromMin) * (ToMax - FromMax) + FromMax;
        }

        static long PackTwoInts(int FirstInt, int SecondInt)
        {
            return (long)FirstInt | ((long)SecondInt << (sizeof(int) * 8));
        }
        
        static void UnpackIntoToTwoInts(long Packed, out int FirstInt, out int SecondInt)
        {
            FirstInt = (int)Packed &  0xFFFF;
            SecondInt = (int)(Packed >> (sizeof(int) * 8));
        }

        static void DrawCircle(int CenterX, int CenterY, int r, List<Point> circlePoints)
        {
            for (int y = -r; y <= r; y++)
                for (int x = -r; x <= r; x++)
                    if (x * x + y * y <= r * r)
                    {
                        Point p = new Point(CenterX + x, CenterY + y);
                        circlePoints.Add(p);
                    }
        }

        public static void GetHiddenGridsStart(Project forProject , out int hiddenGridsStartX, out int hiddenGridsStartY)
        {
            hiddenGridsStartX = forProject.numOfCellsX;
            hiddenGridsStartY = forProject.numOfCellsY;
            foreach (Server server in forProject.servers)
                if (server.hiddenAtlasId != null && server.hiddenAtlasId.Length > 0)
                {
                    if (server.gridX == 0 && server.gridY == 0)
                        continue;
                    int maxDimension = Math.Max(server.gridX, server.gridY);
                    if (maxDimension < hiddenGridsStartX)
                        hiddenGridsStartX = maxDimension;
                    if (maxDimension < hiddenGridsStartY)
                        hiddenGridsStartY = maxDimension;
                }
        }

        public static int GetMaxMainRegionDimension(Project forProject)
        {
            GetHiddenGridsStart(forProject, out int hiddenGridsStartX, out int hiddenGridsStartY);
            return Math.Max(hiddenGridsStartX, hiddenGridsStartY);
        }

        public static Dictionary<long, int> DrawMap(
            MainForm mainForm, IDictionary<string, Island> islands,
            Graphics g, bool showLines, bool showServerInfo, bool showDiscoZoneInfo,
            RectangleF? culling, Color? alphaBackground,
           Dictionary<string, Image> regionsTile, Dictionary<string, TextureBrush> regionsTileBrush, decimal tileScale,
            int translateH, int translateV, bool forExport, bool bShowPathingGrid, int startX, int startY, bool isSingleCell, int cellX = -1, int cellY = -1, int OverrideNumCellsX = -1, int OverrideNumCellsY = -1)
        {
            Dictionary<long, int> AlphaBuf = null;
            g.InterpolationMode = InterpolationMode.High;
            bool bHasOverrideNumCells = OverrideNumCellsX > -1 || OverrideNumCellsY > -1;

            Project currentProject = mainForm.currentProject;

            bool getOptimizedImage = !forExport && (1 / currentProject.coordsScaling > useFullIslandRes);
            if (getOptimizedImage)
            {
                g.InterpolationMode = InterpolationMode.Low;
                g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SingleBitPerPixelGridFit;
                //g.CompositingMode = CompositingMode.SourceCopy;
                g.SmoothingMode = SmoothingMode.HighSpeed;
                g.CompositingQuality = CompositingQuality.HighSpeed;
            }


            float cellSize = Math.Max(currentProject.cellSize * currentProject.coordsScaling, 0.00001f);

            int numOfCellsX = currentProject.numOfCellsX;
            int numOfCellsY = currentProject.numOfCellsY;

            if (forExport && !isSingleCell)
            {
                int maxDimension = GetMaxMainRegionDimension(currentProject);

                numOfCellsX = maxDimension;
                numOfCellsY = maxDimension;

                if (OverrideNumCellsX > 0)
                    numOfCellsX = OverrideNumCellsX;
                if (OverrideNumCellsY > 0)
                    numOfCellsY = OverrideNumCellsY;
            }

            float maxX = numOfCellsX * cellSize;
            float maxY = numOfCellsY * cellSize;

            bool cull = culling.HasValue;
            RectangleF canvasRect = culling.GetValueOrDefault();

            if (alphaBackground.HasValue)
            {
                g.Clear(alphaBackground.Value);
            }

            Pen p = new Pen(Color.Black);

            if (translateH != 0 || translateV != 0)
            {
                g.TranslateTransform(-translateH, -translateV);
            }


            //Draw background
            if (mainForm.regionsTile != null && mainForm.regionsTileBrush != null)
            {

                if (!forExport)
                    mainForm.PopulateMapRegions();

                lock (mainForm.MapRegionsList)
                    lock (mainForm.regionsTileBrush)
                    {
                        foreach (KeyValuePair<string, Image> regionTile in mainForm.regionsTile)
                        {
                            MapRegion mapRegion = mainForm.MapRegionsList[regionTile.Key];
                            if (cellX >= 0 && cellY >= 0)
                            {
                                if (cellX < mapRegion.StartX || cellX > mapRegion.EndX || cellY < mapRegion.StartY || cellY > mapRegion.EndY)
                                    continue;
                                if (OverrideNumCellsX >= 0 && (cellX + OverrideNumCellsX - 1) < mapRegion.EndX)
                                    continue;
                                if (OverrideNumCellsY >= 0 && (cellY + OverrideNumCellsY - 1) < mapRegion.EndY)
                                    continue;
                            }

                            Image image = regionTile.Value;
                            TextureBrush textureBrush = mainForm.regionsTileBrush[regionTile.Key];

                            if (image != null && textureBrush != null)
                            {
                                textureBrush.ResetTransform();

                                float wrminX = (mapRegion.StartX) * cellSize;
                                float wrminY = (mapRegion.StartY) * cellSize;

                                float wrmaxX = (mapRegion.EndX - mapRegion.StartX + 1) * cellSize;
                                float wrmaxY = (mapRegion.EndY - mapRegion.StartY + 1) * cellSize;

                                float rscaleX = wrmaxX / image.Size.Width;
                                float rscaleY = wrmaxY / image.Size.Height;

                                textureBrush.ScaleTransform(rscaleX, rscaleY);
                                if (bHasOverrideNumCells)
                                    g.FillRectangle(textureBrush, new Rectangle(startX, startY, (int)maxX, (int)maxY));
                                else
                                    g.FillRectangle(textureBrush, new Rectangle(Math.Max(startX, (int)wrminX), Math.Max(startY, (int)wrminY), (int)wrmaxX, (int)wrmaxY));

                            }
                        }
                    }



                foreach (Server s in currentProject.servers)
                {
                    if (s.BackgroundImgPath != null && s.BackgroundImgPath.Length > 0)
                    {
                        Image image = Image.FromFile(s.BackgroundImgPath);
                        TextureBrush textureBrush = new TextureBrush(image);
                        if (image != null && textureBrush != null)
                        {
                            PointF serverCenter = new PointF(s.gridX * cellSize + cellSize / 2f, s.gridY * cellSize + cellSize / 2f);
                            serverCenter.Y += cellSize * 0.02f;

                            textureBrush.ResetTransform();

                            float wrminX = s.gridX * cellSize;
                            float wrminY = s.gridY * cellSize;

                            float wrmaxX =  cellSize;
                            float wrmaxY = cellSize;

                            float rscaleX = wrmaxX / image.Size.Width;
                            float rscaleY = wrmaxY / image.Size.Height;


                            textureBrush.ScaleTransform(rscaleX, rscaleY);
                            g.FillRectangle(textureBrush, new Rectangle((int)wrminX, (int)wrminY, (int)wrmaxX, (int)wrmaxY));



                        }
                    }
                }
            }


            //Draw  pathing grid
            if (bShowPathingGrid)
            {
                //horizontal lines
                p.Color = Color.Blue;
                for (int y = 0; y < (currentProject.numPathingGridRows * numOfCellsX) + 1; ++y)
                {
                    float drawY = y * (cellSize / currentProject.numPathingGridRows);
                    if (!cull || (drawY >= canvasRect.Top && drawY <= canvasRect.Bottom))
                    {
                        g.DrawLine(p, 0, drawY, numOfCellsX * cellSize, drawY);
                    }
                }

                //vertical lines
                for (int x = 0; x < (currentProject.numPathingGridColumns * numOfCellsY) + 1; ++x)
                {
                    float drawX = x * (cellSize / currentProject.numPathingGridColumns);
                    if (!cull || (drawX >= canvasRect.Left && drawX <= canvasRect.Right))
                    {
                        g.DrawLine(p, drawX, 0, drawX, numOfCellsY * cellSize);
                    }
                }
            }

            if (currentProject.AtlasPathingGridDirty || (currentProject.AtlasPathingGrid.GetLength(0) != (currentProject.numPathingGridRows * numOfCellsX)) || (currentProject.AtlasPathingGrid.GetLength(0) != (currentProject.numPathingGridColumns * numOfCellsY)))
                RecalcPathingGrid(currentProject, islands);

            //Draw invalid pathing cells
            if (bShowPathingGrid)
            {
                p.Color = Color.Red;
                float CellWidth = cellSize / (currentProject.numPathingGridColumns);
                float CellHeight = cellSize / (currentProject.numPathingGridRows);
                for (int Row = 0; Row < currentProject.AtlasPathingGrid.GetLength(0); Row++)
                {
                    for (int Col = 0; Col < currentProject.AtlasPathingGrid.GetLength(1); Col++)
                    {
                        if (!currentProject.AtlasPathingGrid[Row, Col])
                        {
                            float StartX = Col * CellWidth;
                            float StartY = Row * CellHeight;
                            RectangleF CellRect = new RectangleF(StartX, StartY, CellWidth, CellHeight);
                            g.DrawRectangle(p, StartX, StartY, CellRect.Width, CellRect.Height);
                            //Console.WriteLine(Row + ", " + Col);
                        }
                    }
                }
                p.Color = Color.Black;
            }


            //Draw  grid
            if (showLines)
            {
                //horizontal lines
                for (int y = 0; y < numOfCellsY + 1; ++y)
                {
                    float drawY = y * cellSize;
                    if (!cull || (drawY >= canvasRect.Top && drawY <= canvasRect.Bottom))
                        g.DrawLine(p, 0, drawY, numOfCellsX * cellSize, drawY);
                }

                //vertical lines
                for (int x = 0; x < numOfCellsX + 1; ++x)
                {
                    float drawX = x * cellSize;
                    if (!cull || (drawX >= canvasRect.Left && drawX <= canvasRect.Right))
                        g.DrawLine(p, drawX, 0, drawX, numOfCellsY * cellSize);
                }
            }

            //Draw islands
            float maxWorldX = numOfCellsX * currentProject.cellSize;
            float maxWorldY = numOfCellsY * currentProject.cellSize;

            bool optimizeOutIslandNames = !forExport && (1 / currentProject.coordsScaling > islandsNamesMaxRes);

            foreach (IslandInstanceData instance in currentProject.islandInstances)
            {
                Island referencedIsland = instance.GetReferencedIsland(islands);

                //Clamp to map
                //instance.SetWorldLocation(mainForm, new PointF(instance.worldX, instance.worldY));

                //Reverse translation to rotate around self
                g.TranslateTransform(instance.worldX * currentProject.coordsScaling, instance.worldY * currentProject.coordsScaling);
                g.RotateTransform(instance.rotation, System.Drawing.Drawing2D.MatrixOrder.Prepend);

                Rectangle drawRect = instance.GetRect(currentProject, islands);

                if (!cull || canvasRect.IntersectsWith(drawRect))
                {
                    drawRect.X = -drawRect.Width / 2;
                    drawRect.Y = -drawRect.Height / 2;

                    var ReferencedIslandImage = referencedIsland.GetImage(getOptimizedImage);
                    lock (ReferencedIslandImage)
                    {
                        g.DrawImage(referencedIsland.GetImage(getOptimizedImage), drawRect);
                    }

                    if (currentProject.showIslandNames)
                    {
                        g.RotateTransform(-instance.rotation);
                        drawRect.X += drawRect.Width / 2;
                        drawRect.Y += drawRect.Height / 2;
                        float IslandSize = Math.Max(Math.Min(referencedIsland.x, referencedIsland.y) * currentProject.coordsScaling, 0.00001f);
                        Font font = new Font(SystemFonts.DefaultFont.FontFamily, DefaultFont.SizeInPoints * IslandSize * islandNameScale, FontStyle.Regular);
                        SizeF stringSize = g.MeasureString("T", font);
                        float dynamicOutlineShift = stringSize.Height * outlineShift;
                        if (!optimizeOutIslandNames)
                        {
                            g.DrawString(referencedIsland.name, font, Brushes.Black, new PointF(drawRect.X + dynamicOutlineShift, drawRect.Y + dynamicOutlineShift), centeredStringFormat);
                            g.DrawString(referencedIsland.name, font, Brushes.White, new PointF(drawRect.X, drawRect.Y), centeredStringFormat);
                        }
                        g.RotateTransform(instance.rotation, System.Drawing.Drawing2D.MatrixOrder.Prepend);
                    }

                }

                g.RotateTransform(-instance.rotation);
                g.TranslateTransform(-instance.worldX * currentProject.coordsScaling, -instance.worldY * currentProject.coordsScaling);
            }

            //Draw foreground
            if (currentProject.showForeground && mainForm.foregroundBrush != null)
            {
                mainForm.foregroundBrush.ResetTransform();
                mainForm.foregroundBrush.ScaleTransform((float)mainForm.foregroundScaleBox.Value * currentProject.coordsScaling * 1000, (float)mainForm.foregroundScaleBox.Value * currentProject.coordsScaling * 1000);
                g.FillRectangle(mainForm.foregroundBrush, new Rectangle(0, 0, (int)maxX, (int)maxY));
            }

            //Draw trade wind overlay
            if (currentProject.showTradeWindOverlay && ( mainForm.tradeWindOverlayBrush != null || mainForm.regionsTradeWindOverlayBrush.Count > 0))
            {
                int maxDimension = GetMaxMainRegionDimension(currentProject);
                

                float wmaxX = maxDimension * cellSize;
                float wmaxY = maxDimension * cellSize;
                if (mainForm.tradeWindOverlayBrush != null)
                {
                    mainForm.tradeWindOverlayBrush.ResetTransform();
                    float scaleX = wmaxX / mainForm.tradeWindOverlay.Size.Width;
                    float scaleY = wmaxY / mainForm.tradeWindOverlay.Size.Height;
                    mainForm.tradeWindOverlayBrush.ScaleTransform(scaleX, scaleY);
                    g.FillRectangle(mainForm.tradeWindOverlayBrush, new Rectangle(0, 0, (int)wmaxX, (int)wmaxY));
                }
                if (!forExport)
                    mainForm.PopulateMapRegions();

                foreach (KeyValuePair<string, Image> regionTradeWindOverlay in mainForm.regionsTradeWindOverlay)
                {
                    MapRegion mapRegion = mainForm.MapRegionsList[regionTradeWindOverlay.Key];
                    Image image = regionTradeWindOverlay.Value;
                    TextureBrush textureBrush = mainForm.regionsTradeWindOverlayBrush[regionTradeWindOverlay.Key];


                    textureBrush.ResetTransform();

                    float wrminX = (mapRegion.StartX) * cellSize;
                    float wrminY = (mapRegion.StartY) * cellSize;

                    float wrmaxX = (mapRegion.EndX - mapRegion.StartX + 1) * cellSize;
                    float wrmaxY = (mapRegion.EndY - mapRegion.StartY + 1) * cellSize;

                    float rscaleX = (wrmaxX) / image.Size.Width;
                    float rscaleY = (wrmaxY) / image.Size.Height;

                    textureBrush.TranslateTransform((mapRegion.StartX) * cellSize, (mapRegion.StartY) * cellSize);

                    textureBrush.ScaleTransform(rscaleX, rscaleY);

                    g.FillRectangle(textureBrush, new Rectangle((int)wrminX, (int)wrminY, (int)wrmaxX, (int)wrmaxY));
                }
            }

            if (currentProject.DiscoveryZoneImage != null && showDiscoZoneInfo)
            {
                //Draw Discovery Zones
                foreach (DiscoveryZoneData discoInst in currentProject.discoZones)
                {
                    if (discoInst.bIsManuallyPlaced)
                        continue;
                    //Clamp to map
                    //discoInst.SetWorldLocation(mainForm, new PointF(discoInst.worldX, discoInst.worldY));

                    //Reverse translation to rotate around self
                    g.TranslateTransform(discoInst.worldX * currentProject.coordsScaling, discoInst.worldY * currentProject.coordsScaling);
                    g.RotateTransform(discoInst.rotation, System.Drawing.Drawing2D.MatrixOrder.Prepend);

                    Rectangle drawRect = discoInst.GetRect(currentProject);

                    if (drawRect.Width < 0)
                        drawRect.Width *= -1;

                    if (drawRect.Height < 0)
                        drawRect.Height *= -1;

                    bool culled = true;
                    if (!cull || canvasRect.IntersectsWith(drawRect))
                    {
                        drawRect.X = -drawRect.Width / 2;
                        drawRect.Y = -drawRect.Height / 2;
                        lock (currentProject.DiscoveryZoneImage)
                        {
                            g.DrawImage(currentProject.DiscoveryZoneImage, drawRect);
                        }

                        culled = false;
                    }

                    g.RotateTransform(-discoInst.rotation);
                    g.TranslateTransform(-discoInst.worldX * currentProject.coordsScaling, -discoInst.worldY * currentProject.coordsScaling);

                    if (!culled)
                    {
                        float zoneSize = Math.Max(discoInst.sizeX * currentProject.coordsScaling, 0.00001f);

                        float fontSize = Math.Max(1.0f, DefaultFont.SizeInPoints * zoneSize / 200);
                        Font font = new Font(SystemFonts.DefaultFont.FontFamily, fontSize, FontStyle.Regular);

                        SizeF stringSize = g.MeasureString("T", font);
                        float dynamicOutlineShift = stringSize.Height * outlineShift;

                        PointF zoneCenter = new PointF(discoInst.worldX, discoInst.worldY);
                        zoneCenter = new PointF(zoneCenter.X * currentProject.coordsScaling, zoneCenter.Y * currentProject.coordsScaling);
                        //if (cull)
                        //{
                        //    RectangleF drawRect = new RectangleF(zoneCenter.X - stringSize.Width / 2, zoneCenter.Y - stringSize.Width / 2, stringSize.Width, 3.3f * stringSize.Height);
                        //    if (canvasRect.IntersectsWith(drawRect))
                        //        continue;
                        //}

                        g.DrawString("name: " + discoInst.name, font, Brushes.Black, new PointF(zoneCenter.X + dynamicOutlineShift, zoneCenter.Y + dynamicOutlineShift), centeredStringFormat);
                        zoneCenter.Y += stringSize.Height * 1.1f;
                        g.DrawString("xp: " + discoInst.xp, font, Brushes.White, zoneCenter, centeredStringFormat);
                    }

                }
            }

            //Draw server info
            if (showServerInfo)
            {
                Font font = new Font(SystemFonts.DefaultFont.FontFamily, DefaultFont.SizeInPoints * cellSize / 200, FontStyle.Regular);
                SizeF stringSize = g.MeasureString("T", font);
                float dynamicOutlineShift = stringSize.Height * outlineShift;

                float lockImgSize = lockImgRatio * cellSize;

                foreach (Server s in currentProject.servers)
                {
                    PointF serverCenter = new PointF(s.gridX * cellSize + cellSize / 2f, s.gridY * cellSize + cellSize / 2f);
                    serverCenter.Y += cellSize * 0.02f;
                    //Draw locks
                    if (!forExport)
                    {
                        float locksShift = 0;
                        if (s.islandLocked)
                        {
                            var cm = new ColorMatrix(new float[][]
                            {
                              new float[] {1, 0, 0, 0, 0},
                              new float[] {0, 1, 0, 0, 0},
                              new float[] {0, 0, 1, 0, 0},
                              new float[] {0, 0, 0, 1, 0},
                              new float[] {0, 1, 0, 0, 1}
                             });

                            var ia = new ImageAttributes();
                            ia.SetColorMatrix(cm);

                            g.DrawImage(lockImg, new Rectangle((int)(serverCenter.X + cellSize / 2 - lockImgSize), (int)(serverCenter.Y - cellSize / 2), (int)lockImgSize, (int)lockImgSize),
                                        0, 0, lockImg.Width, lockImg.Height, GraphicsUnit.Pixel, ia);
                            locksShift += lockImgSize;
                        }
                        if (s.discoLocked)
                        {
                            var cm = new ColorMatrix(new float[][]
                            {
                              new float[] {1, 0, 0, 0, 0},
                              new float[] {0, 1, 0, 0, 0},
                              new float[] {0, 0, 1, 0, 0},
                              new float[] {0, 0, 0, 1, 0},
                              new float[] {1, 0.5f, 0, 0, 1}
                             });

                            var ia = new ImageAttributes();
                            ia.SetColorMatrix(cm);

                            g.DrawImage(lockImg, new Rectangle((int)(serverCenter.X + cellSize / 2 - lockImgSize), (int)(serverCenter.Y - cellSize / 2 + locksShift), (int)lockImgSize, (int)lockImgSize),
                                        0, 0, lockImg.Width, lockImg.Height, GraphicsUnit.Pixel, ia);
                            locksShift += lockImgSize;
                        }
                        if (s.pathsLocked)
                        {
                            var cm = new ColorMatrix(new float[][]
                            {
                              new float[] {1, 0, 0, 0, 0},
                              new float[] {0, 1, 0, 0, 0},
                              new float[] {0, 0, 1, 0, 0},
                              new float[] {0, 0, 0, 1, 0},
                              new float[] {0, 0, 2, 0, 1}
                             });

                            var ia = new ImageAttributes();
                            ia.SetColorMatrix(cm);

                            g.DrawImage(lockImg, new Rectangle((int)(serverCenter.X + cellSize / 2 - lockImgSize), (int)(serverCenter.Y - cellSize / 2 + locksShift), (int)lockImgSize, (int)lockImgSize),
                                        0, 0, lockImg.Width, lockImg.Height, GraphicsUnit.Pixel, ia);
                            locksShift += lockImgSize;
                        }
                        if (s.windsLocked)
                        {
                            var cm = new ColorMatrix(new float[][]
                            {
                              new float[] {1, 0, 0, 0, 0},
                              new float[] {0, 1, 0, 0, 0},
                              new float[] {0, 0, 1, 0, 0},
                              new float[] {0, 0, 0, 1, 0},
                              new float[] {0.25f, 0.87f, 0.815f, 0, 1}
                             });

                            var ia = new ImageAttributes();
                            ia.SetColorMatrix(cm);

                            g.DrawImage(lockImg, new Rectangle((int)(serverCenter.X + cellSize / 2 - lockImgSize), (int)(serverCenter.Y - cellSize / 2 + locksShift), (int)lockImgSize, (int)lockImgSize),
                                        0, 0, lockImg.Width, lockImg.Height, GraphicsUnit.Pixel, ia);
                            locksShift += lockImgSize;
                        }
                    }

                    if (cull)
                    {
                        RectangleF drawRect = new RectangleF(serverCenter.X - stringSize.Width / 2, serverCenter.Y - stringSize.Width / 2, stringSize.Width, 3.3f * stringSize.Height);
                        if (RectangleF.Intersect(canvasRect, drawRect).IsEmpty) //not being drawn, cull
                            continue;
                    }

                    string easyName = string.Format("{0}{1}", (char)(((int)'A') + s.gridX), s.gridY + 1);
                    g.DrawString(easyName, font, Brushes.Black, new PointF(serverCenter.X + dynamicOutlineShift, serverCenter.Y + dynamicOutlineShift), centeredStringFormat);
                    g.DrawString(easyName, font, Brushes.White, serverCenter, centeredStringFormat);
                    serverCenter.Y += stringSize.Height * 1.1f;

                    if (!string.IsNullOrWhiteSpace(s.MachineIdTag))
                    {
                        string nameToDraw = "(MachineId: " + s.MachineIdTag + ")";
                        g.DrawString(nameToDraw, font, Brushes.Black, new PointF(serverCenter.X + dynamicOutlineShift, serverCenter.Y + dynamicOutlineShift), centeredStringFormat);
                        g.DrawString(nameToDraw, font, Brushes.White, serverCenter, centeredStringFormat);
                        serverCenter.Y += stringSize.Height * 1.1f;
                    }
                    if (!string.IsNullOrWhiteSpace(s.name))
                    {
                        string nameToDraw = "Name: " + s.name;
                        g.DrawString(nameToDraw, font, Brushes.Black, new PointF(serverCenter.X + dynamicOutlineShift, serverCenter.Y + dynamicOutlineShift), centeredStringFormat);
                        g.DrawString(nameToDraw, font, (s.isHomeServer) ? Brushes.Lime : Brushes.White, serverCenter, centeredStringFormat);
                        serverCenter.Y += stringSize.Height * 1.1f;
                    }

                    g.DrawString(string.Format("({0},{1})", s.gridX, s.gridY), font, Brushes.Black, new PointF(serverCenter.X + dynamicOutlineShift, serverCenter.Y + dynamicOutlineShift), centeredStringFormat);
                    g.DrawString(string.Format("({0},{1})", s.gridX, s.gridY), font, Brushes.White, serverCenter, centeredStringFormat);

                    serverCenter.Y += stringSize.Height * 1.1f;
                    g.DrawString("ip: " + s.ip, font, Brushes.Black, new PointF(serverCenter.X + dynamicOutlineShift, serverCenter.Y + dynamicOutlineShift), centeredStringFormat);
                    g.DrawString("ip: " + s.ip, font, Brushes.White, serverCenter, centeredStringFormat);

                    serverCenter.Y += stringSize.Height * 1.1f;

                    g.DrawString("port: " + s.port, font, Brushes.Black, new PointF(serverCenter.X + dynamicOutlineShift, serverCenter.Y + dynamicOutlineShift), centeredStringFormat);
                    g.DrawString("port: " + s.port, font, Brushes.White, serverCenter, centeredStringFormat);

                    serverCenter.Y += stringSize.Height * 1.1f;

                    g.DrawString("gamePort: " + s.gamePort, font, Brushes.Black, new PointF(serverCenter.X + dynamicOutlineShift, serverCenter.Y + dynamicOutlineShift), centeredStringFormat);
                    g.DrawString("gamePort: " + s.gamePort, font, Brushes.White, serverCenter, centeredStringFormat);

                    serverCenter.Y += stringSize.Height * 1.1f;

                    if (!string.IsNullOrWhiteSpace(s.serverTemplateName))
                    {
                        ServerTemplateData sT = mainForm.currentProject.GetServerTemplateByName(s.serverTemplateName);
                        if (sT != null)
                        {
                            string templateName = "Template: " + s.serverTemplateName;
                            g.DrawString(templateName, font, Brushes.Black, new PointF(serverCenter.X + dynamicOutlineShift, serverCenter.Y + dynamicOutlineShift), centeredStringFormat);
                            g.DrawString(templateName, font, new SolidBrush(sT.GetTemplateColor()), serverCenter, centeredStringFormat);
                            serverCenter.Y += stringSize.Height * 1.1f;
                        }
                    }
                }
            }

            //Draw Ship Paths
            if (mainForm.showShipPathsInfoChckBox.Checked)
            {
                foreach (ShipPathData shipPath in currentProject.shipPaths)
                {
                    List<PointF> bezierPoints = new List<PointF>();

                    if (shipPath.isLooping)
                    {
                        BezierNodeData lastNode = shipPath.Nodes[shipPath.Nodes.Count - 1];
                        PointF NodeCenter = mainForm.UnrealToMapPoint(new PointF(lastNode.worldX - mainForm.currentProject.cellSize * numOfCellsX, lastNode.worldY));
                        bezierPoints.Add(NodeCenter);

                        PointF NextControlCenter = lastNode.GetNextControlPoint();
                        NextControlCenter.X -= mainForm.currentProject.cellSize * numOfCellsX;
                        NextControlCenter = mainForm.UnrealToMapPoint(NextControlCenter);

                        if (lastNode.GetNextNode() != null)
                        {
                            bezierPoints.Add(NextControlCenter);
                            bezierPoints.Add(mainForm.UnrealToMapPoint(lastNode.GetNextNode().GetPrevControlPoint()));
                        }
                    }

                    for (int i = 0; i < shipPath.Nodes.Count; i++)
                    {
                        BezierNodeData node = shipPath.Nodes[i];

                        //Draw control nodes
                        Rectangle nodeRect = node.GetRect(currentProject);
                        Pen pen = new Pen(i == 0 ? Color.Blue : Color.Black, 5f);
                        if (!forExport)
                            g.DrawEllipse(pen, nodeRect);

                        //Draw the control points as half the size
                        PointF NodeCenter = mainForm.UnrealToMapPoint(new PointF(node.worldX, node.worldY));
                        PointF NextControlCenter = mainForm.UnrealToMapPoint(node.GetNextControlPoint());
                        PointF PrevControlCenter = mainForm.UnrealToMapPoint(node.GetPrevControlPoint());
                        nodeRect.Width /= 2;
                        nodeRect.Height /= 2;
                        nodeRect.Offset(nodeRect.Width / 2, nodeRect.Height / 2);
                        pen.Width = 2.5f;
                        pen.Color = Color.Red;
                        nodeRect.Offset((int)(NextControlCenter.X - NodeCenter.X), (int)(NextControlCenter.Y - NodeCenter.Y));
                        if (!forExport)
                            g.DrawEllipse(pen, nodeRect);
                        nodeRect.Offset((int)(PrevControlCenter.X - NextControlCenter.X), (int)(PrevControlCenter.Y - NextControlCenter.Y));
                        if (!forExport)
                            g.DrawEllipse(pen, nodeRect);

                        bezierPoints.Add(NodeCenter);
                        if (node.GetNextNode() != null)
                        {
                            bezierPoints.Add(NextControlCenter);
                            if (i == shipPath.Nodes.Count - 1 && shipPath.isLooping)
                            {
                                PointF PrevControl = node.GetNextNode().GetPrevControlPoint();
                                PrevControl.X += mainForm.currentProject.cellSize * numOfCellsX;
                                bezierPoints.Add(mainForm.UnrealToMapPoint(PrevControl));
                            }
                            else
                                bezierPoints.Add(mainForm.UnrealToMapPoint(node.GetNextNode().GetPrevControlPoint()));
                        }
                    }

                    if (shipPath.isLooping)
                    {
                        BezierNodeData firstNode = shipPath.Nodes[0];
                        PointF NodeCenter = mainForm.UnrealToMapPoint(new PointF(firstNode.worldX + mainForm.currentProject.cellSize * numOfCellsX, firstNode.worldY));
                        bezierPoints.Add(NodeCenter);
                    }
                    else
                    {
                        //Re add the starting point to close loop
                        if (shipPath.Nodes.Count > 0)
                            bezierPoints.Add(shipPath.Nodes[0].GetMapLocation(mainForm));
                    }

                    g.DrawBeziers(p, bezierPoints.ToArray());
                }
            }

            if (mainForm.showPortalNodesChckBox.Checked)
            {

                List<PortalPathData> portalPaths = new List<PortalPathData>();

                portalPaths.AddRange(currentProject.portalPaths);

                foreach (PortalPathData portalPerpetualPath in portalPaths)
                {
                    for (int i = 0; i < portalPerpetualPath.Nodes.Count; i++)
                    {
                        PortalPathNode node = portalPerpetualPath.Nodes[i];
                        //Draw control nodes
                        Rectangle nodeRect = node.GetRect(currentProject);
                        Pen pen = new Pen(i == 0 ? Color.Green : Color.Red, 5f);
                        if (i == 0)
                        {
                            switch (portalPerpetualPath.PathPortalType)
                            {
                                case PortalType.Perpetual:
                                    pen.Color = Color.Green;
                                    break;

                                case PortalType.PlayerActivated:
                                    pen.Color = Color.Yellow;
                                    break;

                                case PortalType.CentralBarmuda:
                                    pen.Color = Color.Violet;
                                    break;

                                case PortalType.NPC:
                                    pen.Color = Color.Gray;
                                    break;
                            }
                        }
                        else
                            pen.Color = Color.Red;
                        g.DrawEllipse(pen, nodeRect);

                        //Draw the control points as half the size
                        PointF NodeCenter = mainForm.UnrealToMapPoint(new PointF(node.worldX, node.worldY));

                        nodeRect.Width /= 2;
                        nodeRect.Height /= 2;
                        nodeRect.Offset(nodeRect.Width / 2, nodeRect.Height / 2);
                        pen.Width = 2.5f;

                        //horizontal lines

                        if (i != 0)
                        {
                            MoveableObjectData originNode = portalPerpetualPath.Nodes[0];
                            PointF OriginNodeCenter = mainForm.UnrealToMapPoint(new PointF(originNode.worldX, originNode.worldY));
                            switch (portalPerpetualPath.PathPortalType)
                            {
                                case PortalType.Perpetual:
                                    pen.Color = Color.Green;
                                    break;

                                case PortalType.PlayerActivated:
                                    pen.Color = Color.Yellow;
                                    break;

                                case PortalType.CentralBarmuda:
                                    pen.Color = Color.Violet;
                                    break;
                                case PortalType.NPC:
                                    pen.Color = Color.Gray;
                                    break;

                            }
                            g.DrawLine(pen, NodeCenter.X, NodeCenter.Y, OriginNodeCenter.X, OriginNodeCenter.Y);
                        }

                        //Draw direction arrow
                        /*AdjustableArrowCap arrowCap = new AdjustableArrowCap(0.25f * bezierNodeArrowRatio * currentProject.cellSize * currentProject.coordsScaling,
                                                                             0.25f * bezierNodeArrowRatio * currentProject.cellSize * currentProject.coordsScaling, true);

                        pen.EndCap = System.Drawing.Drawing2D.LineCap.Custom;
                        pen.CustomEndCap = arrowCap;
                        //pen.CustomEndCap.BaseCap = System.Drawing.Drawing2D.LineCap.ArrowAnchor;
                        pen.CustomEndCap.WidthScale = 2;

                        float arrowLength = bezierNodeArrowRatio * currentProject.cellSize * currentProject.coordsScaling;
                        PointF arrowStart = new PointF(NodeCenter.X - arrowLength / 2, NodeCenter.Y);
                        arrowStart = StaticHelpers.RotatePointAround(arrowStart, new PointF(NodeCenter.X, NodeCenter.Y), node.rotation);
                        PointF arrowEnd = new PointF(NodeCenter.X + arrowLength / 2, NodeCenter.Y);
                        arrowEnd = StaticHelpers.RotatePointAround(arrowEnd, new PointF(NodeCenter.X, NodeCenter.Y), node.rotation);
                        pen.Color = Color.WhiteSmoke;
                        g.DrawLine(pen, arrowStart, arrowEnd);

                        pen.EndCap = System.Drawing.Drawing2D.LineCap.NoAnchor;*/

                    }
                }
            }
            //Draw Trade Winds
            bool bDisableTradewindsExporting = false;
            if ((!bDisableTradewindsExporting && forExport && !bHasOverrideNumCells) || mainForm.showTradeWindsChckBox.Checked)
            {
                AlphaBuf = new Dictionary<long, int>();
                foreach (TradeWindData tradeWind in currentProject.tradeWinds)
                {
                    List<PointF> bezierPoints = new List<PointF>();

                    if (tradeWind.isLooping && tradeWind.isLoopingAroundWorld)
                    {
                        BezierNodeData lastNode = tradeWind.Nodes[tradeWind.Nodes.Count - 1];
                        PointF NodeCenter = mainForm.UnrealToMapPoint(new PointF(lastNode.worldX - mainForm.currentProject.cellSize * numOfCellsX, lastNode.worldY));
                        bezierPoints.Add(NodeCenter);

                        PointF NextControlCenter = lastNode.GetNextControlPoint();
                        NextControlCenter.X -= mainForm.currentProject.cellSize * numOfCellsX;
                        NextControlCenter = mainForm.UnrealToMapPoint(NextControlCenter);

                        if (lastNode.GetNextNode() != null)
                        {
                            bezierPoints.Add(NextControlCenter);
                            bezierPoints.Add(mainForm.UnrealToMapPoint(lastNode.GetNextNode().GetPrevControlPoint()));
                        }
                    }

                    for (int i = 0; i < tradeWind.Nodes.Count; i++)
                    {
                        BezierNodeData node = tradeWind.Nodes[i];

                        PointF NodeCenter = mainForm.UnrealToMapPoint(new PointF(node.worldX, node.worldY));
                        PointF NextControlCenter = mainForm.UnrealToMapPoint(node.GetNextControlPoint());
                        PointF PrevControlCenter = mainForm.UnrealToMapPoint(node.GetPrevControlPoint());

                        bezierPoints.Add(NodeCenter);
                        if (node.GetNextNode() != null)
                        {
                            if (i == tradeWind.Nodes.Count - 1)
                            {
                                if (tradeWind.isLooping)
                                {
                                    bezierPoints.Add(NextControlCenter);
                                    if (tradeWind.isLoopingAroundWorld)
                                    {
                                        PointF PrevControl = node.GetNextNode().GetPrevControlPoint();
                                        PrevControl.X += mainForm.currentProject.cellSize * numOfCellsX;
                                        bezierPoints.Add(mainForm.UnrealToMapPoint(PrevControl));
                                    }
                                    else
                                        bezierPoints.Add(mainForm.UnrealToMapPoint(node.GetNextNode().GetPrevControlPoint()));
                                }
                            }
                            else
                            {
                                bezierPoints.Add(NextControlCenter);
                                bezierPoints.Add(mainForm.UnrealToMapPoint(node.GetNextNode().GetPrevControlPoint()));
                            }
                        }
                    }

                    if (tradeWind.isLooping)
                    {
                        if (tradeWind.isLoopingAroundWorld)
                        {
                            BezierNodeData firstNode = tradeWind.Nodes[0];
                            PointF NodeCenter = mainForm.UnrealToMapPoint(new PointF(firstNode.worldX + mainForm.currentProject.cellSize * numOfCellsX, firstNode.worldY));
                            bezierPoints.Add(NodeCenter);
                        }
                        else
                        {
                            //Re add the starting point to close loop
                            if (tradeWind.Nodes.Count > 0)
                                bezierPoints.Add(tradeWind.Nodes[0].GetMapLocation(mainForm));
                        }
                    }

                    for (int bi = 0; bi < bezierPoints.Count; bi++)
                        bezierPoints[bi] = new PointF(bezierPoints[bi].X - startX, bezierPoints[bi].Y - startY);

                    for (int bi = 0; bi + 3 < bezierPoints.Count; bi += 3)
                    {
                        List<Tuple<float, Point>> points = new List<Tuple<float, Point>>();
                        float dt = 1.0f / cellSize;
                        for (float t = 0.0f; t < 1.0; t += dt)
                        {
                            Point PointTOnCurve = CubicBezier(t, bezierPoints[bi], bezierPoints[bi + 1], bezierPoints[bi + 2], bezierPoints[bi + 3]);
                            if (points.Count > 0)
                            {
                                Point PrevPoint = points[points.Count - 1].Item2;
                                if (PointTOnCurve.X == PrevPoint.X && PointTOnCurve.Y == PrevPoint.Y)
                                    continue;
                            }
                            if (forExport ||
                                (PointTOnCurve.X >= canvasRect.Left && PointTOnCurve.X <= canvasRect.Right &&
                                PointTOnCurve.Y >= canvasRect.Top && PointTOnCurve.Y <= canvasRect.Bottom))
                                points.Add(new Tuple<float, Point>(t, PointTOnCurve));
                        }

                        Point LastPointOnCurve = CubicBezier(1.0f, bezierPoints[0], bezierPoints[1], bezierPoints[2], bezierPoints[3]);
                        points.Add(new Tuple<float, Point>(1.0f, LastPointOnCurve));
                        int CurrentNodeIndex = bi / 3;
                        int NextNodeIndex = CurrentNodeIndex + 1;
                        if (tradeWind.isLooping && NextNodeIndex >= tradeWind.Nodes.Count)
                            NextNodeIndex = 0;


                            List<Point> CirclePoints = new List<Point>();
                        for (int i = 0; i < points.Count - 1; i++)
                        {
                            int widthAtPoint = (int)((tradeWind.Nodes[CurrentNodeIndex].width * (1.0f - points[i].Item1) + tradeWind.Nodes[NextNodeIndex].width * points[i].Item1) * currentProject.coordsScaling);
                            if (widthAtPoint < 1)
                                widthAtPoint = 1;
                            CirclePoints.Clear();
                            if (!mainForm.visualizeTradewindsWidthCheckBox.Checked && widthAtPoint > 10 && !forExport)
                                widthAtPoint = 10;
                            DrawCircle(points[i].Item2.X, points[i].Item2.Y, widthAtPoint, CirclePoints);
                            for (int k = 0; k < CirclePoints.Count; k++)
                            {
                                int circlePointX = CirclePoints[k].X;
                                int circlePointY = CirclePoints[k].Y;
                                int DistToCenter = (int)Math.Sqrt((circlePointX - points[i].Item2.X) * (circlePointX - points[i].Item2.X) + ((circlePointY - points[i].Item2.Y) * (circlePointY - points[i].Item2.Y)));
                                int a = (int)MapValueFromTo(DistToCenter, tradeWind.StartInterpolatingOceanColorAtPercentage * widthAtPoint, widthAtPoint, 255, 0);
                                if (a < 0)
                                    a = 0;
                                else if (a > 255)
                                    a = 255;
                                long AlphaBuffIndex = PackTwoInts(circlePointX, circlePointY);
                                if (a > 0 && AlphaBuffIndex > 0 && circlePointX >= 0 && circlePointY >= 0)
                                {
                                    lock (AlphaBuf)
                                    {
                                        int currentA = -1;
                                        if (AlphaBuf.TryGetValue(AlphaBuffIndex, out currentA))
                                        {
                                            if (a > currentA)
                                                AlphaBuf[AlphaBuffIndex] = a;
                                        }
                                        else
                                            AlphaBuf.Add(AlphaBuffIndex, a);
                                    }
                                }
                            }


                        }


                        if (!forExport)
                        {
                            lock (g)
                            {
                                lock (AlphaBuf)
                                {
                                    foreach (KeyValuePair<long, int> PixelAlpha in AlphaBuf)
                                    {
                                        int ax = -1;
                                        int ay = -1;
                                        UnpackIntoToTwoInts(PixelAlpha.Key, out ax, out ay);
                                        if (PixelAlpha.Value > 0)
                                        {
                                            p.Color = Color.Turquoise;
                                            SolidBrush aBrush = new SolidBrush(Color.FromArgb(PixelAlpha.Value, 64, 224, 208));
                                            g.FillRectangle(aBrush, ax, ay, 1, 1);
                                        }
                                    }
                                    /*
                                    for (int i = 1; i < points.Count; i++)
                                    {
                                        Point p1 = points[i - 1];
                                        Point p2 = points[i];
                                        Brush aBrush = (Brush)Brushes.Green;
                                        g.FillRectangle(aBrush, points[i].X, points[i].Y, 1, 1);
                                    }
                                    */

                                    g.DrawLine(Pens.Blue, bezierPoints[bi], bezierPoints[bi + 1]);
                                    g.DrawLine(Pens.Blue, bezierPoints[bi + 1], bezierPoints[bi + 2]);
                                    g.DrawLine(Pens.Blue, bezierPoints[bi + 2], bezierPoints[bi + 3]);
                                }
                            }
                        }
                        p.Color = Color.Black;
                    }
                }
                if (!forExport)
                {
                    foreach (TradeWindData tradeWind in currentProject.tradeWinds)
                    {
                        for (int i = 0; i < tradeWind.Nodes.Count; i++)
                        {
                            BezierNodeData node = tradeWind.Nodes[i];
                            //Draw control nodes
                            Rectangle nodeRect = node.GetRect(currentProject);
                            Pen pen = new Pen(i == 0 ? Color.Turquoise : Color.Black, 5f);
                            g.DrawEllipse(pen, nodeRect);

                            //Draw the control points as half the size
                            PointF NodeCenter = mainForm.UnrealToMapPoint(new PointF(node.worldX, node.worldY));
                            PointF NextControlCenter = mainForm.UnrealToMapPoint(node.GetNextControlPoint());
                            PointF PrevControlCenter = mainForm.UnrealToMapPoint(node.GetPrevControlPoint());

                            nodeRect.Width /= 2;
                            nodeRect.Height /= 2;
                            nodeRect.Offset(nodeRect.Width / 2, nodeRect.Height / 2);
                            pen.Width = 2.5f;
                            pen.Color = Color.Red;
                            nodeRect.Offset((int)(NextControlCenter.X - NodeCenter.X), (int)(NextControlCenter.Y - NodeCenter.Y));
                            g.DrawEllipse(pen, nodeRect);
                            nodeRect.Offset((int)(PrevControlCenter.X - NextControlCenter.X), (int)(PrevControlCenter.Y - NextControlCenter.Y));
                            g.DrawEllipse(pen, nodeRect);

                            //Draw direction arrow
                            AdjustableArrowCap arrowCap = new AdjustableArrowCap(0.25f * bezierNodeArrowRatio * currentProject.cellSize * currentProject.coordsScaling,
                                                                                 0.25f * bezierNodeArrowRatio * currentProject.cellSize * currentProject.coordsScaling, true);

                            pen.EndCap = System.Drawing.Drawing2D.LineCap.Custom;
                            pen.CustomEndCap = arrowCap;
                            //pen.CustomEndCap.BaseCap = System.Drawing.Drawing2D.LineCap.ArrowAnchor;
                            pen.CustomEndCap.WidthScale = 2;

                            float arrowLength = bezierNodeArrowRatio * currentProject.cellSize * currentProject.coordsScaling;
                            PointF arrowStart = new PointF(NodeCenter.X - arrowLength / 2, NodeCenter.Y);
                            arrowStart = StaticHelpers.RotatePointAround(arrowStart, new PointF(NodeCenter.X, NodeCenter.Y), node.rotation);
                            PointF arrowEnd = new PointF(NodeCenter.X + arrowLength / 2, NodeCenter.Y);
                            arrowEnd = StaticHelpers.RotatePointAround(arrowEnd, new PointF(NodeCenter.X, NodeCenter.Y), node.rotation);
                            if (tradeWind.reverseDir)
                                g.DrawLine(pen, arrowEnd, arrowStart);
                            else
                                g.DrawLine(pen, arrowStart, arrowEnd);

                            pen.EndCap = System.Drawing.Drawing2D.LineCap.NoAnchor;
                        }
                    }
                }
            } 
            
            if (mainForm.makingSelectionBox || mainForm.selectedMovableObjects.Count > 0)
            {
                Pen pen = new Pen(Color.Black, 2.5f);
                pen.DashStyle = DashStyle.Dash;
                RectangleF selBox = mainForm.selectionBox;
                //RectangleF selBox = new RectangleF(selBoxRef.Location, selBoxRef.Size);
                selBox.X *= currentProject.coordsScaling;
                selBox.Y *= currentProject.coordsScaling;
                selBox.Width *= currentProject.coordsScaling;
                selBox.Height *= currentProject.coordsScaling;

                g.TranslateTransform(selBox.X + selBox.Width / 2, selBox.Y + selBox.Height / 2);
                g.RotateTransform(mainForm.selectionBoxRotation, System.Drawing.Drawing2D.MatrixOrder.Prepend);
                g.TranslateTransform(-selBox.Width / 2, -selBox.Height / 2);
                g.DrawRectangle(pen, 0, 0, selBox.Width, selBox.Height);
                //g.RotateTransform(-mainForm.selectionBoxRotation, System.Drawing.Drawing2D.MatrixOrder.Prepend);
                //g.TranslateTransform(-selBox.Y - selBox.Width / 2, -selBox.Y - selBox.Height / 2);
            }

            if (!forExport)
            {
                GetHiddenGridsStart(currentProject, out int hiddenGridsStartX, out int hiddenGridsStartY);

                if (hiddenGridsStartX > 0 || hiddenGridsStartY > 0)
                {
                    SolidBrush overlayBrush = new SolidBrush(Color.FromArgb(50, 0, 0, 0));
                    Font font = new Font(SystemFonts.DefaultFont.FontFamily, DefaultFont.SizeInPoints * cellSize / 200, FontStyle.Regular);
                    foreach (Server server in currentProject.servers)
                        if (server.gridX >= hiddenGridsStartX || server.gridY >= hiddenGridsStartY)
                        {
                            g.FillRectangle(overlayBrush, server.gridX * cellSize, server.gridY * cellSize, (int)cellSize, (int)cellSize);
                            string subAtlasID = server.hiddenAtlasId != null && server.hiddenAtlasId.Length > 0 ? server.hiddenAtlasId : "";
                            g.DrawString("SubATLAS: " + subAtlasID, font, Brushes.White, new PointF(server.gridX * cellSize, server.gridY * cellSize));
                        }
                }
            }
            return forExport ? AlphaBuf : null;
        }

        private void mapPanel_DragDrop(object sender, DragEventArgs e)
        {
            if (currentProject == null)
                return;

            Point p = new Point(e.X, e.Y);
            p = mapPanel.PointToClient(p);
            p = GetTarnsformedMapPoint(p);
            PointF worldPoint = MapToUnrealPoint(p);
            int id = currentProject.GenerateNewId();

            float width = 0, height = 0;
            string name = (string)e.Data.GetData("".GetType());
            if (islands.ContainsKey(name))
            {
                Island island = islands[name];
                width = island.x;
                height = island.y;
            }

            currentProject.islandInstances.Add(new IslandInstanceData().SetFrom(name, worldPoint.X, worldPoint.Y, 0, id, width, height));
            currentProject.islandInstances.Last().SetDirty(this);
            islandListBox.Invalidate();
            mapPanel.Invalidate();
        }

        Point previousMousePos = new Point(0, 0);
        float? startRotation = null;
        float islandStartRotation = 0;

        private void mapPanel_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Location == previousMousePos)
                return;

            Point moveDelta = new Point(e.Location.X - previousMousePos.X, e.Location.Y - previousMousePos.Y);

            if(makingSelectionBox)
            {
                PointF p = MapToUnrealPoint(GetTarnsformedMapPoint(e.Location));
                selectionBox.Width = p.X - selectionBox.X;
                selectionBox.Height = p.Y - selectionBox.Y;

                mapPanel.Invalidate();
            }
            else if (CurrentHeldMoveableObject != null)
            {
                if (CurrentHeldMoveableObject is DiscoveryZoneData && bResizingDiscoZone)
                {
                    DiscoveryZoneData CurrentHeldDiscoZoneInstance = (DiscoveryZoneData)CurrentHeldMoveableObject;
                    Point p = e.Location;
                    p = GetTarnsformedMapPoint(p);
                    PointF worldPoint = MapToUnrealPoint(p);
                    PointF MouseDelta = new PointF(CurrentHeldDiscoZoneInstance.startWorldX - worldPoint.X, CurrentHeldDiscoZoneInstance.startWorldY - worldPoint.Y);
                    CurrentHeldDiscoZoneInstance.sizeX = MouseDelta.X;
                    CurrentHeldDiscoZoneInstance.sizeY = MouseDelta.Y;
                    CurrentHeldDiscoZoneInstance.SetWorldLocation(
                        this, new PointF(CurrentHeldDiscoZoneInstance.startWorldX - CurrentHeldDiscoZoneInstance.sizeX / 2,
                        CurrentHeldDiscoZoneInstance.startWorldY - CurrentHeldDiscoZoneInstance.sizeY / 2));
                }
                else
                {
                    CurrentHeldMoveableObject.SetWorldLocation(
                        this,
                        new PointF(CurrentHeldMoveableObject.worldX + moveDelta.X / currentProject.coordsScaling,
                        CurrentHeldMoveableObject.worldY + moveDelta.Y / currentProject.coordsScaling)
                    );
                }

                this.Cursor = Cursor.Current = Cursors.SizeAll;
                mapPanel.Invalidate();
            }
            else if (CurrentRotatedMoveableObject != null)
            {
                float angleToCenter = StaticHelpers.GetAngleOfPoint(new Point((int)(CurrentRotatedMoveableObject.worldX * currentProject.coordsScaling), (int)(CurrentRotatedMoveableObject.worldY * currentProject.coordsScaling)), GetTarnsformedMapPoint(e.Location));

                if (startRotation.HasValue)
                    CurrentRotatedMoveableObject.rotation = islandStartRotation + angleToCenter - startRotation.Value;
                else
                {
                    startRotation = angleToCenter;
                    islandStartRotation = CurrentRotatedMoveableObject.rotation;
                }

                if(CurrentRotatedMoveableObject is BezierNodeData)
                {
                    float distanceFromCenter = StaticHelpers.GetDistance(GetTarnsformedMapPoint(e.Location), CurrentRotatedMoveableObject.GetMapLocation(this));

                    BezierNodeData scaledNode = (BezierNodeData)CurrentRotatedMoveableObject;
                    scaledNode.controlPointsDistance = MapToUnrealDistance(distanceFromCenter);
                    scaledNode.controlPointsDistance = Math.Max(BezierNodeEx.GetBezierNodeSize(currentProject), scaledNode.controlPointsDistance);
                }

                CurrentRotatedMoveableObject.SetDirty(this);
                this.Cursor = Cursor.Current = Cursors.UpArrow;
                mapPanel.Invalidate();
            }
            else if (e.Button == MouseButtons.Middle)
            {
                if (mapHScrollBar.Enabled)
                    mapHScrollBar.Value = Math.Max(mapHScrollBar.Minimum, Math.Min(mapHScrollBar.Maximum, mapHScrollBar.Value - moveDelta.X));

                if (mapVScrollBar.Enabled)
                    mapVScrollBar.Value = Math.Max(mapVScrollBar.Minimum, Math.Min(mapVScrollBar.Maximum, mapVScrollBar.Value - moveDelta.Y));
                this.Cursor = Cursor.Current = Cursors.NoMove2D;
                mapPanel.Invalidate();
            }
            else if (selectedMovableObjects.Count > 0)
            {
                if (selectionBoxHeld)
                {
                    selectionBox.X += moveDelta.X / currentProject.coordsScaling;
                    selectionBox.Y += moveDelta.Y / currentProject.coordsScaling;

                    for (int i = 0; i < selectedMovableObjects.Count; i++)
                        selectedMovableObjects[i].SetWorldLocation(
                            this,
                            new PointF(selectedMovableObjects[i].worldX + moveDelta.X / currentProject.coordsScaling,
                            selectedMovableObjects[i].worldY + moveDelta.Y / currentProject.coordsScaling)
                        );

                    this.Cursor = Cursor.Current = Cursors.SizeAll;
                    mapPanel.Invalidate();
                }
                else if(selectionBoxRotated)
                {
                    PointF selectionCenter = selectionBox.Location;
                    selectionCenter.X += selectionBox.Width / 2;
                    selectionCenter.Y += selectionBox.Height / 2;

                    float angleToCenter = StaticHelpers.GetAngleOfPoint(new Point((int)(selectionCenter.X * currentProject.coordsScaling), (int)(selectionCenter.Y * currentProject.coordsScaling)), GetTarnsformedMapPoint(e.Location));

                    if (startRotation.HasValue)
                    {
                        float lastFrameRotation = angleToCenter - startRotation.Value;

                        for (int i = 0; i < selectedMovableObjects.Count; i++)
                        {
                            selectedMovableObjects[i].rotation += angleToCenter - startRotation.Value;

                            PointF MovableLoc = new PointF(selectedMovableObjects[i].worldX, selectedMovableObjects[i].worldY);
                            MovableLoc = StaticHelpers.RotatePointAround(MovableLoc, selectionCenter, lastFrameRotation);
                            selectedMovableObjects[i].SetWorldLocation(this, MovableLoc);
                        }

                        selectionBoxRotation += lastFrameRotation;
                        startRotation = angleToCenter;
                    }
                    else
                    {
                        startRotation = angleToCenter;
                    }

                    this.Cursor = Cursor.Current = Cursors.UpArrow;
                    mapPanel.Invalidate();
                }
                else
                {
                    Point p = e.Location;
                    p = GetTarnsformedMapPoint(p);
                    PointF worldPoint = MapToUnrealPoint(p);

                    PointF selectionCenter = selectionBox.Location;
                    selectionCenter.X += selectionBox.Width / 2;
                    selectionCenter.Y += selectionBox.Height / 2;
                    worldPoint = StaticHelpers.RotatePointAround(worldPoint, selectionCenter, -selectionBoxRotation);

                    if (selectionBox.Contains(worldPoint))
                        this.Cursor = Cursor.Current = Cursors.Hand;
                    else
                        this.Cursor = Cursor.Current = Cursors.Default;
                }
            }
            else
            {
                if (mapPanel.Visible && GetFirstMoveableObjectAtLocation(GetTarnsformedMapPoint(e.Location)) != null)
                    this.Cursor = Cursor.Current = (ModifierKeys == Keys.Control) ? editCursor : Cursors.Hand;
                else
                    this.Cursor = Cursor.Current = Cursors.Default;
            }

            previousMousePos = e.Location;

            Point atlasPoint = GetTarnsformedMapPoint(e.Location);
            double LocX = atlasPoint.X / currentProject.coordsScaling;
            double LocY = atlasPoint.Y / currentProject.coordsScaling;
            if( LocX <= currentProject.cellSize * currentProject.numOfCellsX  && LocY <= currentProject.cellSize * currentProject.numOfCellsY)
                atlasLocation.Text = "X: " + LocX + "  Y: " + LocY;
        }

        Point middlePressLocation;

        RectangleF selectionBox;
        bool makingSelectionBox = false;
        bool selectionBoxHeld = false;
        bool selectionBoxRotated = false;
        float selectionBoxRotation = 0;
        List<MoveableObjectData> selectedMovableObjects = new List<MoveableObjectData>();

        private void mapPanel_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (selectedMovableObjects.Count > 0)
                {
                    Point p = e.Location;
                    p = GetTarnsformedMapPoint(p);
                    PointF worldPoint = MapToUnrealPoint(p);
                    
                    PointF selectionCenter = selectionBox.Location;
                    selectionCenter.X += selectionBox.Width / 2;
                    selectionCenter.Y += selectionBox.Height / 2;
                    worldPoint = StaticHelpers.RotatePointAround(worldPoint, selectionCenter, -selectionBoxRotation);

                    if (selectionBox.Contains(worldPoint))
                    {
                        selectionBoxHeld = true;
                    }
                    else
                    {
                        makingSelectionBox = true;
                        selectionBox.Location = MapToUnrealPoint(GetTarnsformedMapPoint(e.Location));
                        selectionBox.Width = 0;
                        selectionBox.Height = 0;
                        selectionBoxRotation = 0;
                    }
                    return;
                }

                if (ModifierKeys == Keys.Control)
                {
                    IslandInstanceData IslandInst = GetFirstInstanceAtLocation(GetTarnsformedMapPoint(e.Location));

                    if (IslandInst != null)
                    {
                        var editForm = new EditIslandInstance(this, IslandInst);
                        if (editForm.ShowDialog() == DialogResult.OK)
                        {
                            mapPanel.Invalidate();
                        }
                    }
                    else
                    {
                        ShipPathNode shipPathNode = GetFirstShipPathNodeAtLocation(GetTarnsformedMapPoint(e.Location));
                        if (shipPathNode != null)
                        {
                            var editForm = new EditShipPath(shipPathNode.shipPath);
                            editForm.ShowDialog();
                            mapPanel.Invalidate();
                        }
                        else
                        {
                            TradeWindNode tradeWindNode = GetFirstTradeWindNodeAtLocation(GetTarnsformedMapPoint(e.Location));
                            if (tradeWindNode != null)
                            {
                                var editForm = new EditTradeWind(tradeWindNode);
                                editForm.ShowDialog();
                                mapPanel.Invalidate();
                            }
                            else
                            {

                                PortalPathNode portalPathNode = GetFirstPortalPathNodeAtLocation(GetTarnsformedMapPoint(e.Location));
                                if (portalPathNode != null)
                                {
                                    var editForm = new EditPortalNode(portalPathNode, this);
                                    editForm.ShowDialog();
                                    mapPanel.Invalidate();
                                }
                                else
                                {
                                    Server s = GetServerAtPoint(GetTarnsformedMapPoint(e.Location));
                                    if (s != null)
                                    {
                                        var editForm = new EditServerForm(this);
                                        editForm.targetServer = s;
                                        if (editForm.ShowDialog() == DialogResult.OK)
                                        {
                                            mapPanel.Invalidate();
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                else if(ModifierKeys == Keys.Shift)
                {
                    if (currentProject == null || currentProject.DiscoveryZoneImage == null)
                        return;

                    LastMouseLocation = e.Location;
                    DiscoveryZoneData ZoneInst = GetFirstDiscoZoneAtLocation(GetTarnsformedMapPoint(e.Location));
                    if (ZoneInst != null)
                    {
                        CurrentHeldMoveableObject = ZoneInst;
                        ZoneInst.startWorldX = ZoneInst.worldX - ZoneInst.sizeX / 2;
                        ZoneInst.startWorldY = ZoneInst.worldY - ZoneInst.sizeX / 2;
                        bResizingDiscoZone = true;
                        mapPanel.Invalidate();
                    }
                    else
                    {
                        Point p = e.Location;
                        p = GetTarnsformedMapPoint(p);
                        PointF worldPoint = MapToUnrealPoint(p);
                        int id = currentProject.GenerateNewId();
                        currentProject.discoZones.Add(new DiscoveryZoneData().SetFrom("", worldPoint.X, worldPoint.Y, 0.0f, 0.0f, 0, id));
                        CurrentHeldMoveableObject = currentProject.discoZones[currentProject.discoZones.Count - 1];
                        bResizingDiscoZone = true;
                        mapPanel.Invalidate();
                    }
                }
                else
                {
                    CurrentHeldMoveableObject = GetFirstMoveableObjectAtLocation(GetTarnsformedMapPoint(e.Location));
                    if (CurrentHeldMoveableObject != null)
                        CurrentHeldMoveableObject.SetDirty(this);
                    else
                    {
                        makingSelectionBox = true;
                        selectionBox.Location = MapToUnrealPoint(GetTarnsformedMapPoint(e.Location));
                        selectionBox.Width = 0;
                        selectionBox.Height = 0;
                        selectionBoxRotation = 0;
                    }
                }
            }
            else if (e.Button == MouseButtons.Right)
            {
                if (selectedMovableObjects.Count > 0)
                {
                    Point p = e.Location;
                    p = GetTarnsformedMapPoint(p);
                    PointF worldPoint = MapToUnrealPoint(p);

                    PointF selectionCenter = selectionBox.Location;
                    selectionCenter.X += selectionBox.Width / 2;
                    selectionCenter.Y += selectionBox.Height / 2;
                    worldPoint = StaticHelpers.RotatePointAround(worldPoint, selectionCenter, -selectionBoxRotation);

                    if (selectionBox.Contains(worldPoint))
                        selectionBoxRotated = true;
                    return;
                }
                
                Server s = GetServerAtPoint(GetTarnsformedMapPoint(e.Location));
                if (ModifierKeys == Keys.Control)
                {
                    if (s != null)
                    {
                        var editForm = new EditDiscoZonesForm(this, s);
                        editForm.ShowDialog();
                    }
                }
                else
                {
                    CurrentRotatedMoveableObject = GetFirstMoveableObjectAtLocation(GetTarnsformedMapPoint(e.Location));
                    startRotation = null;
                }
            }
            else if (e.Button == MouseButtons.Middle)
            {
                middlePressLocation.X = mapHScrollBar.Value;
                middlePressLocation.Y = mapVScrollBar.Value;
            }
        }


        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (this.txtSearch.Focused)
            {
                // there's got to be a better way to prevent events from triggering here when typing in the search box.
                // I don't really do WinForms though, so, meh?
                return;
            }

            if (e.KeyCode == Keys.Delete)
            {
                Point cursorMapPoint = GetTarnsformedMapPoint(mapPanel.PointToClient(Cursor.Position));
                IslandInstanceData islandInst = GetFirstInstanceAtLocation(cursorMapPoint);
                DiscoveryZoneData discoInst;
                BezierNodeData bezierNode;
                PortalPathNode PortalNode;

                if (islandInst != null)
                {
                    islandInst.SetDirty(this);
                    currentProject.islandInstances.Remove(islandInst);
                    islandListBox.Invalidate();
                    mapPanel.Invalidate();
                }
                else if ((discoInst = GetFirstDiscoZoneAtLocation(cursorMapPoint)) != null)
                {
                    currentProject.discoZones.Remove(discoInst);
                    mapPanel.Invalidate();
                }
                else if ((bezierNode = GetFirstBezierNodeAtLocation(cursorMapPoint)) != null)
                {
                    if (ModifierKeys == Keys.Shift)
                    {
                        if (bezierNode is ShipPathNode)
                            currentProject.shipPaths.Remove(((ShipPathNode)bezierNode).shipPath);
                        else if (bezierNode is TradeWindNode)
                            currentProject.tradeWinds.Remove(((TradeWindNode)bezierNode).tradeWind);
                      
                        mapPanel.Invalidate();
                    }
                    else
                    {
                        if (!bezierNode.GetSplinePath().DeleteNode(bezierNode))
                            MessageBox.Show("A bezier path can't have less than 2 points\nTo delete the whole path use Shift + Delete");
                        else
                            mapPanel.Invalidate();
                    }
                }
                else if ((PortalNode = GetFirsPortalPathNodeAtLocation(cursorMapPoint)) != null)
                {
                    if (ModifierKeys == Keys.Shift)
                    {
                        currentProject.portalPaths.Remove(PortalNode.portalPathData);
                        mapPanel.Invalidate();
                    }
                    else
                    {
                        if (!PortalNode.portalPathData.DeleteNode(PortalNode))
                            MessageBox.Show("A Portal path can't have less than 2 points\nTo delete the whole path use Shift + Delete");
                        else
                            mapPanel.Invalidate();
                    }
                }
            }
            if (mapPanel.Visible)
            {
                if (GetFirstInstanceAtLocation(GetTarnsformedMapPoint(previousMousePos)) != null || GetFirstDiscoZoneAtLocation(GetTarnsformedMapPoint(previousMousePos)) != null)
                    this.Cursor = Cursor.Current = (ModifierKeys == Keys.Control) ? editCursor : Cursors.Hand;
            }

            if (e.KeyCode == Keys.L)
            {
                Server server = GetServerAtPoint(GetTarnsformedMapPoint(previousMousePos));
                if (server != null)
                {
                    var locksForm = new LocksForm(this, server);
                    locksForm.ShowDialog();
                    mapPanel.Invalidate();
                }
            }
            else if (e.KeyCode == Keys.P)
            {
                //Create new ship path
                if (currentProject != null)
                {
                    Server server = GetServerAtPoint(GetTarnsformedMapPoint(previousMousePos));
                    if (server != null) //To ensure being in-grid
                    {
                        PointF unrealPoint = MapToUnrealPoint(GetTarnsformedMapPoint(previousMousePos));
                        currentProject.shipPaths.Add(new ShipPathData().SetFrom(this, unrealPoint.X, unrealPoint.Y));
                        mapPanel.Invalidate();
                    }
                }
            }
            else if (e.KeyCode == Keys.Q)
            {
                //Create new Perpetual path
                if (currentProject != null)
                {
                    Server server = GetServerAtPoint(GetTarnsformedMapPoint(previousMousePos));
                    if (server != null) //To ensure being in-grid
                    {
                        PointF unrealPoint = MapToUnrealPoint(GetTarnsformedMapPoint(previousMousePos));
                        currentProject.portalPaths.Add(new PortalPathData(PortalType.Perpetual).SetFrom(this, unrealPoint.X, unrealPoint.Y));
                        mapPanel.Invalidate();
                    }
                }
            }
            else if (e.KeyCode == Keys.W)
            {
                //Create new Perpetual path
                if (currentProject != null)
                {
                    Server server = GetServerAtPoint(GetTarnsformedMapPoint(previousMousePos));
                    if (server != null) //To ensure being in-grid
                    {
                        PointF unrealPoint = MapToUnrealPoint(GetTarnsformedMapPoint(previousMousePos));
                        currentProject.portalPaths.Add(new PortalPathData(PortalType.PlayerActivated).SetFrom(this, unrealPoint.X, unrealPoint.Y));
                        mapPanel.Invalidate();
                    }
                }
            }
            else if (e.KeyCode == Keys.E)
            {
                //Create new Perpetual path
                if (currentProject != null)
                {
                    Server server = GetServerAtPoint(GetTarnsformedMapPoint(previousMousePos));
                    if (server != null) //To ensure being in-grid
                    {
                        PointF unrealPoint = MapToUnrealPoint(GetTarnsformedMapPoint(previousMousePos));
                        currentProject.portalPaths.Add(new PortalPathData(PortalType.CentralBarmuda).SetFrom(this, unrealPoint.X, unrealPoint.Y));
                        mapPanel.Invalidate();
                    }
                }
            }
            else if (e.KeyCode == Keys.R)
            {
                if (currentProject != null)
                {
                    Server server = GetServerAtPoint(GetTarnsformedMapPoint(previousMousePos));
                    if (server != null) //To ensure being in-grid
                    {
                        PointF unrealPoint = MapToUnrealPoint(GetTarnsformedMapPoint(previousMousePos));
                        currentProject.portalPaths.Add(new PortalPathData(PortalType.NPC).SetFrom(this, unrealPoint.X, unrealPoint.Y));
                        mapPanel.Invalidate();
                    }
                }
            }
            else if (e.KeyCode == Keys.T)
            {
                //Create new trade wind
                if (currentProject != null)
                {
                    Server server = GetServerAtPoint(GetTarnsformedMapPoint(previousMousePos));
                    if (server != null) //To ensure being in-grid
                    {
                        PointF unrealPoint = MapToUnrealPoint(GetTarnsformedMapPoint(previousMousePos));
                        currentProject.tradeWinds.Add(new TradeWindData().SetFrom(this, unrealPoint.X, unrealPoint.Y));
                        mapPanel.Invalidate();
                    }
                }
            }
            else if (e.KeyCode == Keys.Add || e.KeyCode == Keys.Oemplus)
            {
                //Create new ship path
                BezierNodeData selectedBezierNode = GetFirstBezierNodeAtLocation(GetTarnsformedMapPoint(previousMousePos));
                if (selectedBezierNode != null) //To ensure being in-grid
                {
                    if (selectedBezierNode is ShipPathNode)
                        ((ShipPathNode)selectedBezierNode).shipPath.AddNode(selectedBezierNode);
                    else if (selectedBezierNode is TradeWindNode)
                        ((TradeWindNode)selectedBezierNode).tradeWind.AddNode(selectedBezierNode);
                   
                    mapPanel.Invalidate();
                }
                else
                {
                    PortalPathNode portalPathNode = GetFirsPortalPathNodeAtLocation(GetTarnsformedMapPoint(previousMousePos));
                    if (portalPathNode != null)
                    {
                        switch (portalPathNode.portalPathData.PathPortalType)
                        {
                            case PortalType.Perpetual:
                                break;
                            case PortalType.PlayerActivated:
                                portalPathNode.portalPathData.AddNode(portalPathNode);

                                mapPanel.Invalidate();
                                break;
                            case PortalType.CentralBarmuda:
                                break;
                            case PortalType.NPC:
                                break;
                        }
                    }
                }
            }
        }

        private void MainForm_KeyUp(object sender, KeyEventArgs e)
        {
            if (mapPanel.Visible)
            {
                if (GetFirstInstanceAtLocation(GetTarnsformedMapPoint(previousMousePos)) != null || GetFirstDiscoZoneAtLocation(GetTarnsformedMapPoint(previousMousePos)) != null)
                    this.Cursor = Cursor.Current = (ModifierKeys == Keys.Control) ? editCursor : Cursors.Hand;
            }
        }

        private void mapPanel_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (CurrentHeldMoveableObject != null)
                {
                    if(CurrentHeldMoveableObject is DiscoveryZoneData)
                    {
                        DiscoveryZoneData DiscoZoneInst = (DiscoveryZoneData)CurrentHeldMoveableObject;
                        if (e.Location == LastMouseLocation)
                        {
                            var editForm = new EditDiscoveryZoneInstance(this, DiscoZoneInst);
                            if (editForm.ShowDialog() == DialogResult.OK)
                            {
                                mapPanel.Invalidate();
                            }
                            bResizingDiscoZone = false;
                        }
                        else
                        {
                            if (bResizingDiscoZone)
                            {
                                // Fix image if size is -ve
                                if (DiscoZoneInst.sizeX < 0)
                                    DiscoZoneInst.sizeX *= -1;
                                if (DiscoZoneInst.sizeY < 0)
                                    DiscoZoneInst.sizeY *= -1;
                                mapPanel.Invalidate();
                            }
                            bResizingDiscoZone = false;
                        }
                    }

                    CurrentHeldMoveableObject.SetDirty(this);
                    CurrentHeldMoveableObject = null;
                }
                else if(makingSelectionBox)
                {
                    selectedMovableObjects.Clear();
                    makingSelectionBox = false;
                    foreach (IslandInstanceData instance in currentProject.islandInstances)
                    {
                        if (selectionBox.Contains(new PointF(instance.worldX, instance.worldY)))
                            selectedMovableObjects.Add(instance);
                    }
                    foreach (DiscoveryZoneData instance in currentProject.discoZones)
                    {
                        if (selectionBox.Contains(new PointF(instance.worldX, instance.worldY)))
                            selectedMovableObjects.Add(instance);
                    }

                    mapPanel.Invalidate();
                }
                else if(selectionBoxHeld)
                {
                    selectionBoxHeld = false;
                }
            }
            else if (e.Button == MouseButtons.Right)
            {
                if(selectedMovableObjects.Count > 0)
                {
                    selectionBoxRotated = false;
                    startRotation = null;
                }
                else
                    CurrentRotatedMoveableObject = null;
            }
            else if (e.Button == MouseButtons.Middle && selectedMovableObjects.Count == 0)
            {
                if (Math.Abs(middlePressLocation.X - mapHScrollBar.Value) < 10 && Math.Abs(middlePressLocation.Y - mapVScrollBar.Value) < 10)
                {
                    IslandInstanceData selectedIsland = GetFirstInstanceAtLocation(GetTarnsformedMapPoint(e.Location), true);
                    if (selectedIsland != null)
                    {
                        EditIsland(selectedIsland.GetReferencedIsland(islands));
                    }
                }
            }
        }

        private void mapPanel_MouseWheel(object sender, MouseEventArgs e)
        {
            Point mouseLocation = e.Location;
            PointF desiredMouseLocation = e.Location;

            float desiredHScroll = mapHScrollBar.Value;
            float desiredVScroll = mapVScrollBar.Value;

            if (e.Delta > 0)
            {
                currentProject.coordsScaling *= scrollSpeed;

                UpdateScrollBars();

                desiredMouseLocation.X *= scrollSpeed;
                desiredMouseLocation.Y *= scrollSpeed;

                desiredHScroll *= scrollSpeed;
                desiredVScroll *= scrollSpeed;
            }
            else
            {
                currentProject.coordsScaling /= scrollSpeed;

                UpdateScrollBars();

                desiredMouseLocation.X /= scrollSpeed;
                desiredMouseLocation.Y /= scrollSpeed;

                desiredHScroll /= scrollSpeed;
                desiredVScroll /= scrollSpeed;
            }

            SetScaleTxt(1 / currentProject.coordsScaling);

            if (mapHScrollBar.Enabled)
                mapHScrollBar.Value = Math.Max(0, Math.Min(mapHScrollBar.Maximum, (int)(desiredHScroll + desiredMouseLocation.X - mouseLocation.X)));
            else
                mapHScrollBar.Value = 0;

            if (mapVScrollBar.Enabled)
                mapVScrollBar.Value = Math.Max(0, Math.Min(mapVScrollBar.Maximum, (int)(desiredVScroll + desiredMouseLocation.Y - mouseLocation.Y)));
            else
                mapVScrollBar.Value = 0;

            mapPanel.Invalidate();
        }

        public void SaveIslands(string islandRemovedFromMod = null)
        {
            //Take backup
            if (File.Exists(islandsSaveFile))
                File.Copy(islandsSaveFile, islandsSaveFileBackup, true);

            //Separate mod islands to be saved in their respective files
            Dictionary<string, Dictionary<string, Island>> modsDict = new Dictionary<string, Dictionary<string, Island>>();

            List<Island> allIslands = islands.Values.ToList();
            Dictionary<string, Island> originalIslands = new Dictionary<string, Island>();

            foreach (Island island in allIslands)
            {
                if (!string.IsNullOrWhiteSpace(island.modDir))
                {
                    //This is a mod island group it to be saved
                    Dictionary<string, Island> modIslandsDict = null;
                    if (!modsDict.TryGetValue(island.modDir, out modIslandsDict))
                    {
                        modIslandsDict = new Dictionary<string, Island>();
                        modsDict.Add(island.modDir, modIslandsDict);
                    }

                    modIslandsDict.Add(island.name, island);
                }
                else
                {
                    originalIslands.Add(island.name, island);
                }
            }

            //Serialize Main island file
            string json = JsonConvert.SerializeObject(originalIslands, Formatting.Indented);
            File.WriteAllText(islandsSaveFile, json);

            //Serialize mod island files
            foreach (KeyValuePair<string, Dictionary<string, Island>> kvp in modsDict)
            {
                string islandDataJson = islandModsDir + "/" + kvp.Key + islandsJson;
                json = JsonConvert.SerializeObject(kvp.Value, Formatting.Indented);
                File.WriteAllText(islandDataJson, json);
            }

            //Delete mod files if there are no more islands in it
            if (islandRemovedFromMod != null && !modsDict.ContainsKey(islandRemovedFromMod))
            {
                string modDirPath = islandModsDir + "/" + islandRemovedFromMod;
                if (Directory.Exists(modDirPath))
                    Directory.Delete(modDirPath, true);
            }
        }

        public void LoadIslands()
        {
            if (File.Exists(islandsSaveFile))
            {
                islands = JsonConvert.DeserializeObject<Dictionary<string, Island>>(File.ReadAllText(islandsSaveFile));

                string[] modDirs = Directory.GetDirectories(islandModsDir);
                
                foreach (string islandModDir in modDirs)
                {
                    string dataFile = islandModDir + islandsJson;
                    if (File.Exists(dataFile))
                    {
                        Dictionary <string, Island> ModIslands = JsonConvert.DeserializeObject<Dictionary<string, Island>>(File.ReadAllText(dataFile));
                        if(ModIslands != null)
                            foreach(KeyValuePair<string, Island> kvp in ModIslands)
                            {
                                if (islands.ContainsKey(kvp.Key))
                                {
                                    MessageBox.Show(string.Format("File {0} contains duplicate island named {1}, this island will not be imported", Path.GetFileName(dataFile), kvp.Key), 
                                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    continue;
                                }

                                if (kvp.Value != null)
                                    kvp.Value.modDir = Path.GetFileName(islandModDir);

                                islands.Add(kvp.Key, kvp.Value);
                            }
                    }
                }
                RefreshIslandList();
            }
        }

        public void SaveProject()
        {
            SaveIslands();
        }

        /// <summary>
        /// Creats a completely new project replacing the current one if already there
        /// </summary>
        public void CreateProject(float CellSize, int xCells, int yCells, string worldFriendlyName, string MainRegionName, string worldAtlasId, string worldAtlasPassword)
        {
            currentProject = new Project(CellSize, xCells, yCells);
            currentProject.WorldFriendlyName = worldFriendlyName;
            currentProject.MainRegionName = MainRegionName;
            currentProject.WorldAtlasPassword = worldAtlasPassword;
            currentProject.WorldAtlasId = worldAtlasId;
            currentProject.TribeLogConfig = new TribeLogConfigInfo();
            currentProject.TravelDataConfig = new BackupConfigInfo();
            currentProject.SharedLogConfig = new SharedLogConfigInfo();
            SetScaleTxt(1 / currentProject.coordsScaling);

            showServerInfoCheckbox.Checked = currentProject.showServerInfo;
            showDiscoZoneInfoCheckbox.Checked = currentProject.showDiscoZoneInfo;
            showIslandNamesChckBox.Checked = currentProject.showIslandNames;
            showShipPathsInfoChckBox.Checked = currentProject.showShipPathsInfo;
            showTradeWindsChckBox.Checked = currentProject.showTradeWindsInfo;
            showPortalNodesChckBox.Checked = currentProject.showPortalNodes;
            disableImageExportingCheckBox.Checked = currentProject.disableImageExporting;
            showLinesCheckbox.Checked = currentProject.showLines;
            alphaBgCheckbox.Checked = currentProject.alphaBackground;
            tiledBackgroundCheckbox.Checked = currentProject.showBackground;
            SetTileImages(null);
            showForegroundChckBox.Checked = currentProject.showForeground;
            SetForegroundImage(currentProject.foregroundImgPath);
            tradeWindOverlayChckBox.Checked = currentProject.showTradeWindOverlay;
            SetTradeWindOverlayImage(currentProject.tradeWindOverlayImgPath, currentProject.regionsTradeWindOverlayImgPath);

            SetDiscoverZoneImage(currentProject.discoZonesImagePath);

            mapPanel.Invalidate();
            mapPanel.Update();

            SetToolsVisibility(true);
        }

        /// <summary>
        /// Takes a point relative to the map panel and returns a point with the scrolling transformations applied
        /// </summary>
        public Point GetTarnsformedMapPoint(Point p)
        {
            return new Point(p.X + mapHScrollBar.Value, p.Y + mapVScrollBar.Value);
        }

        /// <summary>
        /// Takes a panel point and returns an unreal world point
        /// </summary>
        public PointF MapToUnrealPoint(Point p)
        {
            return new PointF(p.X / currentProject.coordsScaling, p.Y / currentProject.coordsScaling);
        }

        /// <summary>
        /// Takes a panel point and returns an unreal world point
        /// </summary>
        public PointF UnrealToMapPoint(PointF p)
        {
            return new PointF(p.X * currentProject.coordsScaling, p.Y * currentProject.coordsScaling);
        }

        /// <summary>
        /// Takes a panel point and returns an unreal world point
        /// </summary>
        public float MapToUnrealDistance(float dist)
        {
            return dist / currentProject.coordsScaling;
        }

        /// <summary>
        /// Takes a panel point and returns an unreal world point
        /// </summary>
        public float UnrealToMapDistance(float dist)
        {
            return dist * currentProject.coordsScaling;
        }

        /// <summary>
        /// Gets the first island instance at a map location
        /// </summary>
        public IslandInstanceData GetFirstInstanceAtLocation(Point p, bool includeLocked = false)
        {
            if (currentProject == null)
                return null;

            Server s = GetServerAtPoint(p);
            if (s != null && s.islandLocked && !includeLocked)
                return null;

            for (int i = currentProject.islandInstances.Count - 1; i >= 0; i--)
            {
                IslandInstanceData instance = currentProject.islandInstances[i];
                if (instance.ContainsPoint(p, this))
                {
                    return instance;
                }
            }

            return null;
        }

        /// <summary>
        /// Gets the first discovery zone instance at a map location
        /// </summary>
        public DiscoveryZoneData GetFirstDiscoZoneAtLocation(Point p)
        {
            if (currentProject == null)
                return null;

            Server s = GetServerAtPoint(p);
            if (s != null && s.discoLocked)
                return null;

            for (int i = currentProject.discoZones.Count - 1; i >= 0; i--)
            {
                DiscoveryZoneData instance = currentProject.discoZones[i];
                if (instance.ContainsPoint(p, this))
                {
                    return instance;
                }
            }

            return null;
        }

        public PortalPathNode GetFirsPortalPathNodeAtLocation(Point p)
        {

            if (currentProject == null)
                return null;

            Server s = GetServerAtPoint(p);

            if (s != null && !s.windsLocked)
            {
                foreach (PortalPathData portalPathData in currentProject.portalPaths)
                {
                    foreach (PortalPathNode node in portalPathData.Nodes)
                    {
                        if (node.ContainsPoint(p, this))
                        {
                            return node;
                        }
                    }
                }
            }
            return null;
        }

        /// <summary>
        /// Gets the first spline bezier node at a map location
        /// </summary>
        public BezierNodeData GetFirstBezierNodeAtLocation(Point p)
        {
            if (currentProject == null)
                return null;

            Server s = GetServerAtPoint(p);
            if (s != null && !s.pathsLocked)
            {
                foreach (ShipPathData shipPath in currentProject.shipPaths)
                {
                    foreach (BezierNodeData node in shipPath.Nodes)
                    {
                        if (node.ContainsPoint(p, this))
                        {
                            return node;
                        }
                    }
                }
            }


            if (s != null && !s.windsLocked)
            {
                foreach (TradeWindData tradeWind in currentProject.tradeWinds)
                {
                    foreach (BezierNodeData node in tradeWind.Nodes)
                    {
                        if (node.ContainsPoint(p, this))
                        {
                            return node;
                        }
                    }
                }
            }

            return null;
        }

        /// <summary>
        /// Gets the first ship path node at a map location
        /// </summary>
        public ShipPathNode GetFirstShipPathNodeAtLocation(Point p)
        {
            if (currentProject == null)
                return null;

            Server s = GetServerAtPoint(p);
            if (s != null && s.pathsLocked)
                return null;

            foreach (ShipPathData shipPath in currentProject.shipPaths)
            {
                foreach (BezierNodeData node in shipPath.Nodes)
                {
                    if (node.ContainsPoint(p, this))
                    {
                        return (ShipPathNode)node;
                    }
                }
            }

            return null;
        }

        /// <summary>
        /// Gets the first ship path node at a map location
        /// </summary>
        public TradeWindNode GetFirstTradeWindNodeAtLocation(Point p)
        {
            if (currentProject == null)
                return null;

            Server s = GetServerAtPoint(p);
            if (s != null && s.windsLocked)
                return null;

            foreach (TradeWindData tradeWind in currentProject.tradeWinds)
            {
                foreach (BezierNodeData node in tradeWind.Nodes)
                {
                    if (node.ContainsPoint(p, this))
                    {
                        return (TradeWindNode)node;
                    }
                }
            }
            return null;
        }

        /// <summary>
        /// Gets the first portal path node at a map location
        /// </summary>
        public PortalPathNode GetFirstPortalPathNodeAtLocation(Point p)
        {
            if (currentProject == null)
                return null;

            Server s = GetServerAtPoint(p);
            if (s != null && s.windsLocked)
                return null;

            foreach (PortalPathData portalPathData in currentProject.portalPaths)
            {
                foreach (PortalPathNode node in portalPathData.Nodes)
                {
                    if (node.ContainsPoint(p, this))
                    {
                        return (PortalPathNode)node;
                    }
                }
            }
            
            return null;
        }

        /// <summary>
        /// Gets the first Moveable Object at a map location
        /// </summary>
        public MoveableObjectData GetFirstMoveableObjectAtLocation(Point p)
        {
            MoveableObjectData foundObj = GetFirstInstanceAtLocation(p);

            if (foundObj == null)
                foundObj = GetFirstDiscoZoneAtLocation(p);

            if (foundObj == null)
                foundObj = GetFirstBezierNodeAtLocation(p);

            if (foundObj == null)
                foundObj = GetFirstPortalPathNodeAtLocation(p);

            return foundObj;
        }

        /// <summary>
        /// Gets the server by index
        /// </summary>
        public Server GetServerByIndex(Point idx)
        {
            if (currentProject == null)
                return null;

            foreach (Server server in currentProject.servers)
            {
                if (server.gridX == idx.X && server.gridY == idx.Y)
                    return server;
            }

            return null;
        }

        /// <summary>
        /// Gets the server at map point
        /// </summary>
        public Server GetServerAtPoint(PointF p)
        {
            if (currentProject == null)
                return null;

            Point? idx = GetGridIndexAtPoint(p);
            if (idx.HasValue)
            {
                return GetServerByIndex(idx.Value);
            }
            return null;
        }

        /// <summary>
        /// Gets the grid index of a map point
        /// </summary>
        public Point? GetGridIndexAtPoint(PointF p)
        {
            if (currentProject == null)
                return null;

            float cellSize = currentProject.cellSize * currentProject.coordsScaling;

            int x = (int)(p.X / cellSize);
            int y = (int)(p.Y / cellSize);

            x = Math.Min(currentProject.numOfCellsX - 1, x);
            y = Math.Min(currentProject.numOfCellsY - 1, y);

            return new Point(x, y);
        }


        public Bitmap DrawMapToImage(out Dictionary<long, int> tradewindsBuffer, int cellX = -1, int cellY = -1, float resOverride = -1, bool forceResForSingleCell = false, bool tradewindsWorldMap = false, int OverrideNumCellsX = -1, int OverrideNumCellsY = -1)
        {
            tradewindsBuffer = null;
            if (currentProject == null || ((cellX == -1 || cellY == -1) && cellX != cellY))
                return null;
            bool bHasOverrideNumCells = OverrideNumCellsX > -1 || OverrideNumCellsY > -1;
            bool isSingleCell = cellX > -1 && !bHasOverrideNumCells;

           
            int numOfCellsX = OverrideNumCellsX > 0 ? OverrideNumCellsX : currentProject.numOfCellsX;
            int numOfCellsY = OverrideNumCellsY> 0 ? OverrideNumCellsY : currentProject.numOfCellsY;
            if (!isSingleCell && !bHasOverrideNumCells)
            {
                int maxDimension = GetMaxMainRegionDimension(currentProject);
                numOfCellsX = maxDimension;
                numOfCellsY = maxDimension;
            }

            float originalCoordScale = currentProject.coordsScaling;
            if (resOverride > -1)
            {
                float totalUnrealSize = currentProject.cellSize;
                if (!isSingleCell)
                {
                    resOverride -= 2; //these pixels are added below in calculations
                    totalUnrealSize *= Math.Max(numOfCellsX, numOfCellsY);
                }

                currentProject.coordsScaling = resOverride / totalUnrealSize;
            }

            int startX = isSingleCell ? (int)(cellX * currentProject.cellSize * currentProject.coordsScaling) : 0;
            int startY = isSingleCell ? (int)(cellY * currentProject.cellSize * currentProject.coordsScaling) : 0;

            int sizeX;
            int sizeY;

            if (isSingleCell)
            {
                if(forceResForSingleCell && resOverride > -1)
                    sizeY = sizeX = Math.Min(maxImageSize, (int)resOverride) - 2;
                else
                    sizeY = sizeX = Math.Min(maxImageSize, editorConfig.CellImagesRes) - 2;
            }
            else
            {
                sizeX = (int)(numOfCellsX * currentProject.cellSize * currentProject.coordsScaling);
                sizeY = (int)(numOfCellsY * currentProject.cellSize * currentProject.coordsScaling);
            }

            if(bHasOverrideNumCells)
            {
                startX = (int)(cellX * currentProject.cellSize * currentProject.coordsScaling);
                startY = (int)(cellY * currentProject.cellSize * currentProject.coordsScaling);
                sizeX = OverrideNumCellsX > 0 ? (int)(OverrideNumCellsX * currentProject.cellSize * currentProject.coordsScaling) : forceResForSingleCell && resOverride > -1 ? Math.Min(maxImageSize, (int)resOverride) - 2 : Math.Min(maxImageSize, editorConfig.CellImagesRes) - 2;

                if (OverrideNumCellsY > 0)
                {
                    sizeY = (int)(OverrideNumCellsY * currentProject.cellSize * currentProject.coordsScaling);
                }
                else
                {
                    if (forceResForSingleCell && resOverride > -1)
                        sizeY  = Math.Min(maxImageSize, (int)resOverride) - 2;
                    else
                        sizeY  = Math.Min(maxImageSize, editorConfig.CellImagesRes) - 2;

                }

            }
            Rectangle imgSize = new Rectangle(startX, startY, sizeX, sizeY);

            float largerDimension = Math.Max(imgSize.Width, imgSize.Height);

            float scale = (maxImageSize - 2) / largerDimension;
            if (largerDimension > maxImageSize)
            {
                //Rescale img to avoid memory exceptions
                imgSize.Width = Convert.ToInt32(imgSize.Width * scale);
                imgSize.Height = Convert.ToInt32(imgSize.Height * scale);
            }

            imgSize.Width += 2;
            imgSize.Height += 2;

            //borders margin, add an extra pixel that will be subtracted from the montage export
            if (forceResForSingleCell && resOverride > -1)
            {
                imgSize.Width += 2;
                imgSize.Height += 2;
            }

            Bitmap image = new Bitmap(imgSize.Width, imgSize.Height, PixelFormat.Format32bppArgb);

            
            Graphics g = Graphics.FromImage(image);
            
            if (isSingleCell)
            {
                float scaleToFixRes;
                if (forceResForSingleCell && resOverride > -1)
                    scaleToFixRes = (Math.Min(maxImageSize, resOverride) - 2) / (currentProject.cellSize * currentProject.coordsScaling);
                else
                    scaleToFixRes = (Math.Min(maxImageSize, editorConfig.CellImagesRes) - 2) / (currentProject.cellSize * currentProject.coordsScaling);
                g.ScaleTransform(scaleToFixRes, scaleToFixRes);
                g.TranslateTransform(-startX, -startY);
            }
            if(bHasOverrideNumCells)
            {
                g.TranslateTransform(-startX, -startY);
            }

            if (largerDimension > maxImageSize)
            {
                g.ScaleTransform(scale, scale);
            }

            

            int previousH = mapHScrollBar.Value;
            int previousV = mapVScrollBar.Value;
            mapVScrollBar.Value = mapHScrollBar.Value = 0;

            tradewindsBuffer = DrawMapToGraphics(ref g, false, isSingleCell, true, startX, startY, cellX, cellY, OverrideNumCellsX, OverrideNumCellsY);
            mapHScrollBar.Value = previousH;
            mapVScrollBar.Value = previousV;
            currentProject.coordsScaling = originalCoordScale;

            if (tradewindsBuffer != null)
                if (tradewindsWorldMap)
                {
                    foreach (KeyValuePair<long, int> PixelAlpha in tradewindsBuffer)
                    {
                        int x = -1;
                        int y = -1;
                        UnpackIntoToTwoInts(PixelAlpha.Key, out x, out y);
                        if (PixelAlpha.Value > 0 && x < image.Size.Width && y < image.Size.Height)
                            image.SetPixel(x, y, Color.FromArgb(255 - PixelAlpha.Value, image.GetPixel(x, y)));
                    }
                }
                else if (cellX < 0 || cellY < 0)
                    tradewindsBuffer = null;

            return image;
        }
        public void ExportRegionImages(string filePath,float resOverride = -1)
        {
            foreach (KeyValuePair<string, MapRegion> entry in MapRegionsList)
            {
                if (entry.Key == "Main")
                    continue;

                Bitmap image = null;
                Dictionary<long, int> tradewindsBuffer = null;
                image = DrawMapToImage(out tradewindsBuffer, entry.Value.StartX, entry.Value.StartY, resOverride, false, false, entry.Value.EndX - entry.Value.StartX + 1 , entry.Value.EndY - entry.Value.StartY + 1);
                MagickImage tgaImg = null;

                int TrimStartIndex = filePath.LastIndexOf("\\");

                if (filePath.LastIndexOf('/') > filePath.LastIndexOf("\\"))
                    TrimStartIndex = filePath.LastIndexOf('/');

                int charactersToTrim = filePath.Length - TrimStartIndex;
                //filePath.TrimEnd(charactersToTrim);
                string modifiedFilePath = filePath.Remove(TrimStartIndex + 1, charactersToTrim -  1);

                modifiedFilePath = modifiedFilePath + "Region" + entry.Key + "." + GetImagesExtension();
                tgaImg = new MagickImage(image);
                tgaImg.Format = filePath.EndsWith("png", StringComparison.OrdinalIgnoreCase) ? MagickFormat.Png : MagickFormat.Jpeg;
                tgaImg.Quality = editorConfig.ImageQuality;
                tgaImg.Write(modifiedFilePath);
                tgaImg.Dispose();
                tgaImg = null;

            }
        }

        public void ExportRegionTradewindOverlays(string filePath, float resOverride = -1)
        {
            foreach (KeyValuePair<string, MapRegion> entry in MapRegionsList)
            {
                if (entry.Key == "Main")
                    continue;

                Bitmap image = null;
                Dictionary<long, int> tradewindsBuffer = null;
                image = DrawMapToImage(out tradewindsBuffer, entry.Value.StartX, entry.Value.StartY, resOverride, false, true, entry.Value.EndX - entry.Value.StartX + 1, entry.Value.EndY - entry.Value.StartY + 1);
                MagickImage tgaImg = null;

                int TrimStartIndex = filePath.LastIndexOf("\\");

                if (filePath.LastIndexOf('/') > filePath.LastIndexOf("\\"))
                    TrimStartIndex = filePath.LastIndexOf('/');

                int charactersToTrim = filePath.Length - TrimStartIndex;
                //filePath.TrimEnd(charactersToTrim);
                string modifiedFilePath = filePath.Remove(TrimStartIndex + 1, charactersToTrim - 1);

                modifiedFilePath = modifiedFilePath + "MapImg_TradeWinds_Region" + entry.Key + "." + GetImagesExtension();
                tgaImg = new MagickImage(image);
                tgaImg.Format = filePath.EndsWith("png", StringComparison.OrdinalIgnoreCase) ? MagickFormat.Png : MagickFormat.Jpeg;
                tgaImg.Quality = editorConfig.ImageQuality;
                tgaImg.Write(modifiedFilePath);
                tgaImg.Dispose();
                tgaImg = null;

            }
        }

        public void ExportImage(string filePath, int cellX = -1, int cellY = -1, bool exportOverrides = true, float resOverride = -1, bool tradeWindsWorldMap = false)
        {
            Bitmap image = null;
            //if (exportOverrides)
            //{
            //    if (cellX == -1 && cellY == -1)
            //    {
            //        image = currentProject.GetImageOverride();
            //    }
            //    else
            //    {
            //        Server correspondingServer = GetServerByIndex(new Point(cellX, cellY));
            //        image = correspondingServer.GetImageOverride(currentProject);
            //    }
            //}

            Dictionary<long, int> tradewindsBuffer = null;
            if (image == null)
            {
                if (cellX == -1 && cellY == -1 && resOverride > maxImageSize)
                {
                    //Using a large resolution, combine cell images instead of exporting a huge one at once
                    int maxCells = Math.Max(currentProject.numOfCellsX, currentProject.numOfCellsY);
                    float resPerCell = (float)Math.Round(resOverride / currentProject.numOfCellsX);

                    Bitmap[,] cellImages = new Bitmap[currentProject.numOfCellsX, currentProject.numOfCellsY];
                    string dir = Path.GetDirectoryName(filePath);
                    MagickAnyCPU.CacheDirectory = dir;
                    if (!Directory.Exists(dir + "/magicktemp"))
                        Directory.CreateDirectory(dir + "/magicktemp");
                    MagickNET.SetTempDirectory(dir + "/magicktemp");
                    ImageMagick.ResourceLimits.Memory = 8388608;

                    for (int i = 0; i < currentProject.numOfCellsX; i++)
                        for (int j = 0; j < currentProject.numOfCellsY; j++)
                        {
                            //Bitmap drawnCell = DrawMapToImage(i, j, resPerCell, true);
                            //MagickImage mgickCell = new MagickImage(drawnCell);
                            //mgickCell.Format = MagickFormat.Bmp;
                            //mgickCell.Write(dir + "/tmpimgCompImg" + i + "-" + j + ".bmp");
                            //drawnCell.Dispose();
                            cellImages[i, j] = DrawMapToImage(out tradewindsBuffer, i, j, resPerCell, true);
                        }

                    using (MagickImageCollection images = new MagickImageCollection())
                    {
                        for (int i = 0; i < currentProject.numOfCellsY; i++)
                            for (int j = 0; j < currentProject.numOfCellsX; j++)
                            {
                                //images.Add(new MagickImage(dir + "/tmpimgCompImg" + j + "-" + i + ".bmp"));
                                images.Add(new MagickImage(cellImages[j, i]));
                                cellImages[j, i].Dispose();
                                cellImages[j, i] = null;
                            }

                        MontageSettings montageSettings = new MontageSettings()
                        {
                            BackgroundColor = MagickColors.Black,
                            Geometry = new MagickGeometry(-1, -1, 0, 0),
                            TileGeometry = new MagickGeometry(currentProject.numOfCellsX, currentProject.numOfCellsY),
                            BorderWidth = 0,
                            FrameGeometry = new MagickGeometry(0, 0, 0, 0)
                        };
                        IMagickImage atlasMontage = images.Montage(montageSettings);

                        atlasMontage.Format = filePath.EndsWith("png", StringComparison.OrdinalIgnoreCase) ? MagickFormat.Png : MagickFormat.Jpeg;
                        atlasMontage.Depth = 16;
                        atlasMontage.Quality = editorConfig.ImageQuality;
                        //filePath = filePath.Replace(".png", ".tiff").Replace(".jpg", ".tiff");
                        //filePath = filePath.Replace(".jpg", ".png");
                        atlasMontage.Write(filePath);
                    }

                    for (int i = 0; i < currentProject.numOfCellsX; i++)
                        for (int j = 0; j < currentProject.numOfCellsY; j++)
                        {
                            string fName = dir + "/tmpimgCompImg" + i + "-" + j + ".bmp";
                            if (File.Exists(fName))
                                File.Delete(fName);
                        }

                    return;
                }
                else
                {
                    image = DrawMapToImage(out tradewindsBuffer, cellX, cellY, resOverride, false, tradeWindsWorldMap);
                   
                }
                    
            }

            if (image == null)
                return;

            MagickImage tgaImg = null;
            if (!tradeWindsWorldMap && cellX >= 0 && cellY >= 0)
            {

                Bitmap cellTradewindsImage = new Bitmap(image.Size.Width, image.Size.Height, PixelFormat.Format8bppIndexed);

                ColorPalette grayscalePalette = cellTradewindsImage.Palette;
                Color[] grayscalePalletteEntries = grayscalePalette.Entries;
                byte grayscaleIndex = 0;
                do
                {
                    grayscalePalletteEntries[grayscaleIndex] = Color.FromArgb(grayscaleIndex, grayscaleIndex, grayscaleIndex);
                    grayscaleIndex++;
                } while (grayscaleIndex < 255);

                cellTradewindsImage.Palette = grayscalePalette;

                System.Drawing.Imaging.BitmapData bitmapData = cellTradewindsImage.LockBits(new Rectangle(0, 0, cellTradewindsImage.Width, cellTradewindsImage.Height), System.Drawing.Imaging.ImageLockMode.ReadWrite, cellTradewindsImage.PixelFormat);
                int bytes = Math.Abs(bitmapData.Stride) * cellTradewindsImage.Height;
                byte[] rgbValues = new byte[bytes];
                System.Runtime.InteropServices.Marshal.Copy(bitmapData.Scan0, rgbValues, 0, bytes);

                if (tradewindsBuffer != null)
                {
                    foreach (KeyValuePair<long, int> PixelAlpha in tradewindsBuffer)
                    {
                        int x = -1;
                        int y = -1;
                        UnpackIntoToTwoInts(PixelAlpha.Key, out x, out y);
                        if (PixelAlpha.Value > 0 && x < image.Size.Width && y < image.Size.Height)
                            rgbValues[x + y * image.Size.Width] = (byte)PixelAlpha.Value;
                    }
                }

                System.Runtime.InteropServices.Marshal.Copy(rgbValues, 0, bitmapData.Scan0, bytes);
                cellTradewindsImage.UnlockBits(bitmapData);

                tgaImg = new MagickImage(cellTradewindsImage);
                tgaImg.Format = MagickFormat.Jpeg;
                tgaImg.Quality = editorConfig.ImageQuality;
                tgaImg.Write(filePath.Replace("CellImg_", "CellTradewindImg_"));
                tgaImg.Dispose();
                tgaImg = null;
                cellTradewindsImage.Dispose();
                cellTradewindsImage = null;
            }

            tgaImg = new MagickImage(image);
            tgaImg.Format = filePath.EndsWith("png", StringComparison.OrdinalIgnoreCase) ? MagickFormat.Png : MagickFormat.Jpeg;
            tgaImg.Quality = editorConfig.ImageQuality;
            //using(var fi = new FileInfo)
            using (var fs = File.Open(filePath, FileMode.OpenOrCreate, FileAccess.Write))
            {
                tgaImg.Write(fs);
            }
            tgaImg.Dispose();
            tgaImg = null;

        }

        public void ExportCellImages(string path)
        {
            if (currentProject == null)
                return;

            string FullPath = Path.GetDirectoryName(path);
            string Extension = Path.GetExtension(path);
            string FilenameWithoutExtension = Path.GetFileNameWithoutExtension(path);

#warning shitty parallelism doesn't work if underlying stuff needs to access UI objects that, by definition, have thread affinity!
            //List<Task> DrawTasks = new List<Task>();
            for (int i = 0; i < currentProject.numOfCellsX; i++)
            {
                for (int j = 0; j < currentProject.numOfCellsY; j++)
                {
                    int icopy = i;
                    int jcopy = j;
                    string CellFile = FullPath + string.Format(cellImageNameTemplate, FilenameWithoutExtension , i, j, Extension);
                    //var DrawTask = Task.Run(async () =>
                    //{
                        ExportImage(CellFile, icopy, jcopy, true, editorConfig.CellImagesRes);
                    //});
                    //DrawTasks.Add(DrawTask);
                }
            }
            //for (int i = 0; i < DrawTasks.Count; i++)
            //    DrawTasks[i].Wait();
        }

        ///////////////////////////Action Handlers///////////////////////////////////
        private void addIslandBtn_Click(object sender, EventArgs e)
        {
            var createForm = new CreateIslandForm();
            createForm.mainForm = this;
            createForm.ShowDialog();
        }

        private void islandListBox_ItemDrag(object sender, ItemDragEventArgs e)
        {
            if (islandListBox.SelectedItems.Count > 0)
                islandListBox.DoDragDrop(islandListBox.SelectedItems[0].SubItems[2].Text, DragDropEffects.All);
        }

        private void mapPanel_DragOver(object sender, DragEventArgs e)
        {
            if (currentProject == null)
                e.Effect = DragDropEffects.None;
            else
                e.Effect = DragDropEffects.All;
        }

        private void mapHScrollBar_Scroll(object sender, ScrollEventArgs e)
        {
            mapPanel.Invalidate();
            mapPanel.Update();
        }

        private void mapVScrollBar_Scroll(object sender, ScrollEventArgs e)
        {
            mapPanel.Invalidate();
            mapPanel.Update();
        }

        private void createToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (currentProject != null)
            {
                MessageBox.Show("If you create a new project, any unsaved changes to your current project will be LOST!");
            }

            var createForm = new CreateProjectForm();
            createForm.mainForm = this;
            createForm.ShowDialog();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (currentProject == null)
                return;
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "json files (*.json)|*.json";
                saveFileDialog.FileName = actualJsonFile;
                saveFileDialog.InitialDirectory = GlobalSettings.Instance.ProjectsDir;
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    File.WriteAllText(saveFileDialog.FileName, currentProject.Serialize(this));
                }
            }

        }

        void LoadProject()
        {
            if (currentProject != null)
            {
                var confirmResult = MessageBox.Show("If you click OK, any unsaved changes to your current project will be LOST!",
                                     "Warning",
                                     MessageBoxButtons.OKCancel);
                if (confirmResult != DialogResult.OK)
                    return;
            }

            openFileDialog.Filter = "json files (*.json)|*.json";
            openFileDialog.InitialDirectory = GlobalSettings.Instance.ProjectsDir;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string fileName = openFileDialog.FileName;
                Project loadedProj = new Project(File.ReadAllText(fileName), this);

                if (loadedProj.successfullyLoaded)
                {
                    bIsloadingProject = true;
                    EnableProjectMenuItems();
                    actualJsonFile = openFileDialog.SafeFileName;
                    currentProject = loadedProj;
                    SetScaleTxt(1 / currentProject.coordsScaling);
                    SetToolsVisibility(true);

                    showServerInfoCheckbox.Checked = currentProject.showServerInfo;
                    showDiscoZoneInfoCheckbox.Checked = currentProject.showDiscoZoneInfo;
                    showIslandNamesChckBox.Checked = currentProject.showIslandNames;
                    showShipPathsInfoChckBox.Checked = currentProject.showShipPathsInfo;
                    showTradeWindsChckBox.Checked = currentProject.showTradeWindsInfo;
                    showPortalNodesChckBox.Checked = currentProject.showPortalNodes;
                    disableImageExportingCheckBox.Checked = currentProject.disableImageExporting;
                    showLinesCheckbox.Checked = currentProject.showLines;
                    alphaBgCheckbox.Checked = currentProject.alphaBackground;
                    tiledBackgroundCheckbox.Checked = currentProject.showBackground;
                    SetTileImages(currentProject.regionsBackgroundImgPath);
                    showForegroundChckBox.Checked = currentProject.showForeground;
                    SetForegroundImage(currentProject.foregroundImgPath);
                    tradeWindOverlayChckBox.Checked = currentProject.showTradeWindOverlay;
                    SetTradeWindOverlayImage(currentProject.tradeWindOverlayImgPath, currentProject.regionsTradeWindOverlayImgPath);
                    SetDiscoverZoneImage(currentProject.discoZonesImagePath);

                    GridColumnsTxtBox.Text = currentProject.numPathingGridColumns + "";
                    GridRowsTxtBox.Text = currentProject.numPathingGridRows + "";
                    gridRowsLabel.Visible = showPathingGridCheckbox.Checked;
                    gridColumnsLabel.Visible = showPathingGridCheckbox.Checked;
                    GridRowsTxtBox.Visible = showPathingGridCheckbox.Checked;
                    GridColumnsTxtBox.Visible = showPathingGridCheckbox.Checked;
                    mapPanel.Invalidate();
                    mapPanel.Update();
                    bIsloadingProject = false;
                }
                PopulateMapRegionsDirty = true;
                PopulateMapRegions();
            }
        }

        private void mapImageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (currentProject == null)
                return;
            string imageExtension = GetImagesExtension();
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = String.Equals(imageExtension, "png", StringComparison.OrdinalIgnoreCase) ? "PNG files (*.png)|*.png" : "JPEG files (*.jpg)|*.jpg";
                string ExportPath = Path.GetFullPath(GlobalSettings.Instance.ExportDir + actualJsonFile.Replace(".json", ""));
                if (!Directory.Exists(ExportPath))
                    Directory.CreateDirectory(ExportPath);
                saveFileDialog.InitialDirectory = ExportPath;
                saveFileDialog.FileName = "MapImg." + imageExtension;
                string fileName;
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    fileName = saveFileDialog.FileName;
                    saveFileDialog.FileName = null;
                    PopulateMapRegions();
                    ExportImage(fileName, -1, -1, true, editorConfig.AtlasImagesRes);
                    ExportRegionImages(saveFileDialog.FileName, editorConfig.AtlasImagesRes);
                }
            }
        }

        private void controlsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Hold Left click (Move island)\n" +
                "Hold Right click (Rotate island)\n" + 
                "Mouse wheel (Zoom)\n" + 
                "Delete button (Remove island)\n" + 
                "Ctrl + click on grid (Edit server info)\n" + 
                "Ctrl + click on island (Edit island info)\n" + 
                "Hold middle mouse + drag (Scroll map)\n" + 
                "Shift + drag (Create discovery zone)\n" +
                "Shift + click on discovery zone (Edit discovery zone)\n" +
                "L while hovered on cell (Open locks form)\n" +
                "P while on map (Spawn ship path)\n" +
                "T while on map (Spawn trade wind)\n" +
                "Q while on map (Spawn perpetual portal)\n" +
                "W while on map (Spawn player activated portal)\n" +
                "E while on map (Spawn Central Bermuda portal)\n" +
                "R while on map (Spawn NPC portal)\n" +
                "Shift + Delete on portal nodes (Delete portal)\n" +
                "Delete on path nodes (Delete node)\n" +
                "Ctrl + click on path node (Edit path)\n" +
                "Shift + Delete on path nodes (Delete whole path)\n", "Controls");
        }

        private void customRatioTxtBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            StaticHelpers.ForceNumericKeypress(sender, e);
        }

        private void setRatioBtn_Click(object sender, EventArgs e)
        {
            float newScaling;
            if (float.TryParse(customRatioTxtBox.Text, out newScaling))
            {
                float desiredHScroll = mapHScrollBar.Value;
                float desiredVScroll = mapVScrollBar.Value;
                float oldScaling = currentProject.coordsScaling;
                PointF centerPoint = GetTarnsformedMapPoint(new Point(mapPanel.Width / 2, mapPanel.Height / 2));
                PointF topLeftPoint = GetTarnsformedMapPoint(new Point(0, 0));

                PointF centerPointOffset = new PointF(centerPoint.X - topLeftPoint.X, centerPoint.Y - topLeftPoint.Y);
                PointF originalCenterPointOffset = new PointF(centerPointOffset.X, centerPointOffset.Y);

                currentProject.coordsScaling = 1 / newScaling;
                SetScaleTxt(newScaling);

                float changeRatio = currentProject.coordsScaling / oldScaling;
                desiredHScroll *= changeRatio;
                desiredVScroll *= changeRatio;
                centerPointOffset.X *= changeRatio;
                centerPointOffset.X -= originalCenterPointOffset.X;
                centerPointOffset.Y *= changeRatio;
                centerPointOffset.Y -= originalCenterPointOffset.Y;

                UpdateScrollBars();

                float centerChange = (mapPanel.Width / 2) * changeRatio;

                if (mapHScrollBar.Enabled)
                    mapHScrollBar.Value = Math.Max(0, Math.Min(mapHScrollBar.Maximum, (int)(desiredHScroll + centerPointOffset.X)));
                else
                    mapHScrollBar.Value = 0;

                if (mapVScrollBar.Enabled)
                    mapVScrollBar.Value = Math.Max(0, Math.Min(mapVScrollBar.Maximum, (int)(desiredVScroll + centerPointOffset.Y)));
                else
                    mapVScrollBar.Value = 0;

                mapPanel.Invalidate();
            }
        }

        private void removeIslandBtn_Click(object sender, EventArgs e)
        {
            var confirmResult = MessageBox.Show("Removing an island will remove all its instances in the map!\n\nAre you sure?",
                                    "Warning",
                                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirmResult != DialogResult.Yes)
                return;

            List<string> islandsToRemove = new List<string>();

            foreach (ListViewItem item in islandListBox.SelectedItems)
            {
                islandsToRemove.Add(item.SubItems[2].Text);
            }

            if (currentProject != null)
            {
                foreach (string islandToRemove in islandsToRemove)
                    for (int i = 0; i < currentProject.islandInstances.Count; i++)
                        if (currentProject.islandInstances[i].name == islandToRemove)
                        {
                            currentProject.islandInstances[i].SetDirty(this);
                            currentProject.islandInstances.RemoveAt(i);
                            break;
                        }
            }

            string islandRemovedFromMod = null;
            foreach (string islandToRemove in islandsToRemove)
            {
                //delete the image
                islands[islandToRemove].InvalidateImage();
                islandRemovedFromMod = islands[islandToRemove].modDir;
                File.Delete(islands[islandToRemove].imagePath);

                islands.Remove(islandToRemove);
            }

            RefreshIslandList();
            mapPanel.Invalidate();
            SaveIslands(islandRemovedFromMod);
        }

        private void showServerInfoCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            if (currentProject != null)
                currentProject.showServerInfo = showServerInfoCheckbox.Checked;
            mapPanel.Invalidate();
        }

        private void showDiscoZoneInfoCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            if (currentProject != null)
                currentProject.showDiscoZoneInfo = showDiscoZoneInfoCheckbox.Checked;
            mapPanel.Invalidate();
        }

        private void showLinesCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            if (currentProject != null)
                currentProject.showLines = showLinesCheckbox.Checked;
            mapPanel.Invalidate();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (currentProject == null)
                return;

            var createForm = new CreateProjectForm();
            createForm.mainForm = this;
            createForm.editedProject = currentProject;
            createForm.ShowDialog();
            mapPanel.Invalidate();
        }

        private void editIslandBtn_Click(object sender, EventArgs e)
        {
            if (islandListBox.SelectedItems.Count == 0)
                return;

            Island selectedIsland = islands[islandListBox.SelectedItems[0].SubItems[2].Text];
            EditIsland(selectedIsland);
        }

        private void EditIsland(Island isle)
        {
            if (isle == null)
                return;

            var createForm = new CreateIslandForm();
            createForm.mainForm = this;
            createForm.editedIsland = isle;
            if(createForm.ShowDialog() != DialogResult.Cancel && createForm.bIslandNameChanged)
               RefreshIslandList();
            mapPanel.Invalidate();
        }

        private void chooseTileBtn_Click(object sender, EventArgs e)
        {
            if (currentProject == null)
                return;

            openFileDialog.Filter = "png files (*.png)|*.png|All files (*.*)|*.*";
            openFileDialog.FileName = "";
            openFileDialog.InitialDirectory = GlobalSettings.Instance.BaseDir + waterTilesDir.Replace("./","");
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string imgName = waterTilesDir + "/";// + "/" + currentProject.SeamlessWorldId;
                
                if (string.IsNullOrEmpty(RegionComboBox.Text))
                    RegionComboBox.Text = "Main";

                //File.Copy(openFileDialog.FileName, imgName + openFileDialog.SafeFileName, true);
                if (currentProject.regionsBackgroundImgPath == null)
                    currentProject.regionsBackgroundImgPath = new Dictionary<string, string>();
                currentProject.regionsBackgroundImgPath[RegionComboBox.Text] = imgName + openFileDialog.SafeFileName;

                SetTileImage(RegionComboBox.Text, currentProject.regionsBackgroundImgPath[RegionComboBox.Text]);

                currentProject.showBackground = true;
                tiledBackgroundCheckbox.Checked = true;
            }
        }

        private void chooseDiscoZoneBtn_Click(object sender, EventArgs e)
        {
            if (currentProject == null)
                return;

            openFileDialog.Filter = "png files (*.png)|*.png";
            openFileDialog.InitialDirectory = GlobalSettings.Instance.BaseDir + "Resources";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string imgName = "Resources/discoZoneBox.png";
                if (currentProject.DiscoveryZoneImage != null)
                    currentProject.DiscoveryZoneImage.Dispose();
                File.Copy(openFileDialog.FileName, imgName, true);
                SetDiscoverZoneImage(openFileDialog.FileName);
                currentProject.discoZonesImagePath = imgName;
            }
        }

        void SetTileImage(string regionName, string fileName, bool ShouldInvalidateMap = true)
        {

            //public Dictionary<string, Image> regionsTile = new Dictionary<string, Image>();
            //public Dictionary<string, TextureBrush> regionsTileBrush = new Dictionary<string, TextureBrush>();
            if (regionsTileBrush.ContainsKey(regionName) && regionsTileBrush[regionName] != null)
            {
                regionsTileBrush[regionName].Dispose();
                regionsTileBrush[regionName] = null;
            }

            if (regionsTile.ContainsKey(regionName) && regionsTile[regionName] != null)
            {
                regionsTile[regionName].Dispose();
                regionsTile[regionName] = null;
            }

            if (File.Exists(fileName))
            {
                regionsTile[regionName] = Image.FromFile(fileName);
                regionsTileBrush[regionName] = new TextureBrush(regionsTile[regionName]);
            }

            if (ShouldInvalidateMap)
                mapPanel.Invalidate();
        }

        void SetTileImages(Dictionary<string, string> regionsBackgroundImgPath)
        {
            foreach (KeyValuePair<string, Image> regionTile in regionsTile)
                regionTile.Value.Dispose();
            regionsTile.Clear();

            foreach (KeyValuePair<string, TextureBrush> regionTileBrush in regionsTileBrush)
                regionTileBrush.Value.Dispose();
            regionsTileBrush.Clear();
            
            if (regionsBackgroundImgPath != null)
                foreach (KeyValuePair<string, string> regionBackgroundImgPath in regionsBackgroundImgPath)
                    SetTileImage(regionBackgroundImgPath.Key, regionBackgroundImgPath.Value, false);
            mapPanel.Invalidate();
        }

        
        void SetForegroundImage(string fileName)
        {
            if (foregroundBrush != null)
                foregroundBrush.Dispose();
            foregroundBrush = null;

            if (foreground != null)
                foreground.Dispose();
            foreground = null;

            if (File.Exists(fileName))
            {
                foreground = Image.FromFile(fileName);
                foregroundBrush = new TextureBrush(foreground);
            }

            mapPanel.Invalidate();
        }

        void SetTradeWindOverlayImage(string fileName, Dictionary<string, string> RegionsFileName)
        {
            if (tradeWindOverlayBrush != null)
                tradeWindOverlayBrush.Dispose();
            tradeWindOverlayBrush = null;

            if (tradeWindOverlay != null)
                tradeWindOverlay.Dispose();
            tradeWindOverlay = null;

            foreach (KeyValuePair<string, Image> entry in regionsTradeWindOverlay)
            {
                entry.Value.Dispose();
            }
            regionsTradeWindOverlay.Clear();

            foreach (KeyValuePair<string, TextureBrush> entry in regionsTradeWindOverlayBrush)
            {
                entry.Value.Dispose();
            }
            regionsTradeWindOverlayBrush.Clear();

            if (File.Exists(fileName))
            {
                tradeWindOverlay = Image.FromFile(fileName);
                tradeWindOverlayBrush = new TextureBrush(tradeWindOverlay);
            }

            foreach (KeyValuePair<string, string> entry in RegionsFileName)
            {
                if (File.Exists(entry.Value))
                {
                    Image regionTradeWindOverlay = Image.FromFile(entry.Value);
                    regionsTradeWindOverlay.Add(entry.Key, regionTradeWindOverlay);
                    regionsTradeWindOverlayBrush.Add(entry.Key, new TextureBrush(regionTradeWindOverlay));
                }
            }
            mapPanel.Invalidate();
        }

        void SetDiscoverZoneImage(string fileName)
        {
            if (currentProject == null)
                return;
            
            if (currentProject.DiscoveryZoneImage != null)
                currentProject.DiscoveryZoneImage.Dispose();
            currentProject.DiscoveryZoneImage = null;

            if (File.Exists(fileName))
            {
                currentProject.DiscoveryZoneImage = Image.FromFile(fileName);
            }

            mapPanel.Invalidate();
        }

        private void tileScaleBox_ValueChanged(object sender, EventArgs e)
        {
            mapPanel.Invalidate();
        }

        private void tiledBackgroundCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            currentProject.showBackground = tiledBackgroundCheckbox.Checked;

            mapPanel.Invalidate();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (currentProject != null)
            {
                var confirmResult = MessageBox.Show("All unsaved changes to your current project will be LOST!", "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
                e.Cancel = confirmResult == DialogResult.Cancel;
            }
        }


        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadProject();
        }

        private void loadProjBtn_Click(object sender, EventArgs e)
        {
            LoadProject();
        }

        private void createProjBtn_Click(object sender, EventArgs e)
        {
            if (currentProject != null)
            {
                MessageBox.Show("If you create a new project, any unsaved changes to your current project will be LOST!");
            }

            var createForm = new CreateProjectForm();
            createForm.mainForm = this;
            createForm.ShowDialog();
        }

        private void alphaBgCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            if (currentProject != null)
                currentProject.alphaBackground = alphaBgCheckbox.Checked;
        }

        private void testAllServersWithoutDataClearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TestAllServers();
        }

        void TestAllServers(bool clearSaveData = false)
        {
            if (currentProject == null)
                return;

            string jsonFileName = MainForm.gameDir + "/" + MainForm.actualJsonFile;
            var enclosingDirectory = Path.GetDirectoryName(jsonFileName);
            if (!Directory.Exists(enclosingDirectory))
            {
                MessageBox.Show($"Asked to create {MainForm.actualJsonFile} in non-existent directory:\n{enclosingDirectory}", "Test Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            File.WriteAllText(jsonFileName, currentProject.Serialize(this));

            int i = 0;
            foreach (Server server in currentProject.servers)
            {
                ProcessStartInfo serverStartInfo, clientStartInfo;
                server.LaunchPreview(out serverStartInfo, out clientStartInfo, false, clearSaveData, false, ++i);
            }
        }

        private void editSpawnerTemplatesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var editForm = new EditSpawnerTemplatesForm(this);
            editForm.ShowDialog();
        }


        //private void editImageOverridesToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    if (currentProject == null)
        //        return;
        //
        //    var imageOverridesForm = new ImageOverridesForm(this);
        //    imageOverridesForm.ShowDialog();
        //}

        private void cellImagesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (currentProject == null)
                return;

            string imageExtension = GetImagesExtension();
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = String.Equals(imageExtension, "png", StringComparison.OrdinalIgnoreCase) ? "PNG files (*.png)|*.png" : "JPEG files (*.jpg)|*.jpg";
                string ExportPath = Path.GetFullPath(GlobalSettings.Instance.ExportDir + actualJsonFile.Replace(".json", ""));
                if (!Directory.Exists(ExportPath))
                    Directory.CreateDirectory(ExportPath);
                saveFileDialog.InitialDirectory = ExportPath;
                saveFileDialog.FileName = "CellImg";
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    ExportCellImages(saveFileDialog.FileName);
                }
            }
        }

        private void cellImageSizeTxtBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            StaticHelpers.ForceNumericKeypress(sender, e, false);
        }

        private void cellImageSizeTxtBox_TextChanged(object sender, EventArgs e)
        {
            int parsed;
            if (int.TryParse(cellImageSizetxtbox.Text, out parsed))
                editorConfig.CellImagesRes = parsed;
            SaveConfig();
        }


        private void atlasImageSizeTxtBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            StaticHelpers.ForceNumericKeypress(sender, e, false);
        }

        private void atlasImageSizeTxtBox_TextChanged(object sender, EventArgs e)
        {
            int parsed;
            if (int.TryParse(atlasImageSizeTxtBox.Text, out parsed))
                editorConfig.AtlasImagesRes = parsed;
            SaveConfig();
        }

        private void slippyMapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (currentProject == null)
                return;

            using (var exportMapForm = new ExportSlippyMap())
            {
                if (exportMapForm.ShowDialog() != DialogResult.OK)
                    return;

                try
                {
                    using (var progressForm = new ProgressForm())
                    {
                        progressForm.Initialize(exportMapForm.MaxZoom + 2, "Starting...");
                        progressForm.Show();

                        this.ExportSlippyMap(
                            islands, showLinesCheckbox.Checked, showServerInfoCheckbox.Checked, showDiscoZoneInfoCheckbox.Checked,
                            regionsTile, regionsTileBrush, mapPanel.BackColor, exportMapForm.ExportDirectory,
                            (string text) =>
                            {
                                Console.WriteLine(text);
                                progressForm.NextStep(text);
                            }, exportMapForm.MaxZoom, exportMapForm.OverwriteExisting);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Export Failed",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                MessageBox.Show("Slippy Map exported.", "Slippy Map Exported",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private string GetImagesExtension()
        {
            return currentProject.MapImagesExtension;
        }

        private void localExportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (currentProject == null)
                return;

            try
            {
                using (FolderBrowserDialog fbd = new FolderBrowserDialog())
                {
                    fbd.SelectedPath = GlobalSettings.Instance.ExportDir;
                    //if (string.IsNullOrWhiteSpace(editorConfig.LastOpenedFolder) || !Directory.Exists(editorConfig.LastOpenedFolder))
                    //    fbd.SelectedPath = Path.GetFullPath(exportDir);
                    //else
                    //    fbd.SelectedPath = editorConfig.LastOpenedFolder;

                    DialogResult result = fbd.ShowDialog();

                    if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                    {
                        //editorConfig.LastOpenedFolder = exportDir = fbd.SelectedPath;
                        exportDir = fbd.SelectedPath;
                        SaveConfig();
                    }
                    else
                        return;
                }

                string JsonNameNoExtension = "";
                string[] strAr = actualJsonFile.Split('.');
                if (strAr.Length > 0)
                    JsonNameNoExtension = "/" + strAr[0];
                string mapExportDir = exportDir + JsonNameNoExtension;
                if (!Directory.Exists(mapExportDir))
                    Directory.CreateDirectory(mapExportDir);
                string extension = GetImagesExtension();
                string imgPath = mapExportDir + "/MapImg." + extension;
                string cellImgName = "CellImg";

                string serverConfigPath = exportDir + "/" + actualJsonFile;

                //ServerGrid.json
                File.WriteAllText(serverConfigPath, currentProject.Serialize(this, true));

                //ServerGrid.ServerOnly.json
                ServerGrid_ServerOnlyData ServerOnlyObject = new ServerGrid_ServerOnlyData().SetFromProject(currentProject);//(currentProject);
                string serverConfigPathServerOnly = serverConfigPath.Replace(".json", ".ServerOnly.json");
                File.WriteAllText(serverConfigPathServerOnly, JsonConvert.SerializeObject(ServerOnlyObject, Formatting.Indented)); //ServerGrid.ServerOnly.json

                string gameMapExportDir = Path.GetFullPath(GlobalSettings.Instance.ExportDir + "/" + JsonNameNoExtension);

                //Copy to Project/ShooterGame/
                if (Directory.Exists(gameDir + "/Build")) //Just end client folder people are unlikely to have for now
                {
                    string path = Path.GetFullPath(gameDir + "/" + Path.GetFileName(serverConfigPath));
                    if (path != Path.GetFullPath(serverConfigPath))
                    {
                        File.Copy(serverConfigPath, path, true);
                        path = Path.GetFullPath(gameDir + "/" + Path.GetFileName(serverConfigPathServerOnly));
                        File.Copy(serverConfigPathServerOnly, path, true);

                        //Overwrite where to export images
                        gameMapExportDir = Path.GetFullPath(gameDir + "/" + JsonNameNoExtension);
                    }
                }

                if (!disableImageExportingCheckBox.Checked)
                {
                    if (!Directory.Exists(gameMapExportDir))
                        Directory.CreateDirectory(gameMapExportDir);

                    PopulateMapRegions();
                    ExportImage(gameMapExportDir + "/MapImg." + extension, -1, -1, true, editorConfig.AtlasImagesRes);
                    ExportCellImages(gameMapExportDir + string.Format("/{0}." + extension, cellImgName));
                    ExportRegionImages(gameMapExportDir + "/MapImg." + extension, editorConfig.AtlasImagesRes);
                    if (!string.IsNullOrEmpty(currentProject.tradeWindOverlayImgPath) && File.Exists(currentProject.tradeWindOverlayImgPath))
                        File.Copy(currentProject.tradeWindOverlayImgPath, gameMapExportDir + "/TradeWindMapImg.png", true);

                    foreach (KeyValuePair<string, string> entry in currentProject.regionsTradeWindOverlayImgPath)
                    {
                        if (!string.IsNullOrEmpty(entry.Value) && File.Exists(entry.Value))
                            File.Copy(entry.Value, gameMapExportDir + "/TradeWindMapImg" + entry.Key + ".png", true);
                    }
                }
                MessageBox.Show("Export successful!\nFiles in " + exportDir, "Success");
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("Export failed!! Ex: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
                  
        }


        private void editAllDiscoveryZonesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var editForm = new EditDiscoZonesForm(this);
            editForm.ShowDialog();
        }

        private void editSpawnPointsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var editForm = new EditSpawnRegions(this, null);
            editForm.ShowDialog();
        }

        private void showShipPathsInfoChckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (currentProject != null)
                currentProject.showShipPathsInfo = showShipPathsInfoChckBox.Checked;
            mapPanel.Invalidate();
        }

        private void showTradeWindsChckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (currentProject != null)
            {
                currentProject.showTradeWindsInfo = showTradeWindsChckBox.Checked;
            }
            mapPanel.Invalidate();
        }

        public void ShowServerEditSpawnRegionsForm(Server TargetServer)
        {
            var editForm = new EditSpawnRegions(this, TargetServer);
            editForm.ShowDialog();
        }

        private void disableImageExportingCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (currentProject != null)
                currentProject.disableImageExporting = disableImageExportingCheckBox.Checked;
        }

        private void imageQualityTxtbox_TextChanged(object sender, EventArgs e)
        {
            int parsed;
            if (int.TryParse(imageQualityTxtbox.Text, out parsed))
                editorConfig.ImageQuality = parsed;
            SaveConfig();
        }

        private void imageQualityTxtbox_KeyPress(object sender, KeyPressEventArgs e)
        {
            StaticHelpers.ForceNumericKeypress(sender, e, false);
        }

        private void showIslandNamesChckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (currentProject != null)
                currentProject.showIslandNames = showIslandNamesChckBox.Checked;
            mapPanel.Invalidate();
        }

        private void showForegroundChckBox_CheckedChanged(object sender, EventArgs e)
        {
            currentProject.showForeground = showForegroundChckBox.Checked;
            mapPanel.Invalidate();
        }

        private void tradeWindOverlayChckBox_CheckedChanged(object sender, EventArgs e)
        {
            currentProject.showTradeWindOverlay = tradeWindOverlayChckBox.Checked;
            mapPanel.Invalidate();
        }

        private void chooseForegroundBtn_Click(object sender, EventArgs e)
        {
            if (currentProject == null)
                return;

            openFileDialog.Filter = "png files (*.png)|*.png";
            openFileDialog.InitialDirectory = GlobalSettings.Instance.BaseDir + foregroundTilesDir.Replace("./", "");
            openFileDialog.FileName = string.IsNullOrEmpty(currentProject.foregroundImgPath) ? "" : Path.GetFileName(currentProject.foregroundImgPath);
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                if (foregroundBrush != null)
                    foregroundBrush.Dispose();
                if (foreground != null)
                    foreground.Dispose();


                string imgPath= Path.Combine(foregroundTilesDir, Path.GetFileName(openFileDialog.FileName));
                if (!openFileDialog.FileName.StartsWith(Path.GetFullPath(foregroundTilesDir)))
                    File.Copy(openFileDialog.FileName, imgPath, true);

                SetForegroundImage(imgPath);
                currentProject.showForeground = true;
                currentProject.foregroundImgPath = imgPath;
                showForegroundChckBox.Checked = true;
            }
        }


        private void chooseTradeWindOverlayBtn_Click(object sender, EventArgs e)
        {
            if (currentProject == null)
                return;

            openFileDialog.Filter = "png files (*.png)|*.png";
            openFileDialog.InitialDirectory = GlobalSettings.Instance.BaseDir + tradeWindsOverlayDir.Replace("./", "");
            openFileDialog.FileName = string.IsNullOrEmpty(currentProject.tradeWindOverlayImgPath) ? "" : Path.GetFileName(currentProject.tradeWindOverlayImgPath);
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                if (tradeWindOverlayBrush != null)
                    tradeWindOverlayBrush.Dispose();
                if (tradeWindOverlay != null)
                    tradeWindOverlay.Dispose();


                foreach (KeyValuePair<string, Image> entry in regionsTradeWindOverlay)
                {
                    entry.Value.Dispose();
                }
                regionsTradeWindOverlay.Clear();

                foreach (KeyValuePair<string, TextureBrush> entry in regionsTradeWindOverlayBrush)
                {
                    entry.Value.Dispose();
                }
                regionsTradeWindOverlayBrush.Clear();



                string imgPath = Path.Combine(tradeWindsOverlayDir, Path.GetFileName(openFileDialog.FileName));
                if (!openFileDialog.FileName.StartsWith(Path.GetFullPath(tradeWindsOverlayDir)))
                    File.Copy(openFileDialog.FileName, imgPath, true);

                if (string.IsNullOrEmpty(RegionComboBox.Text) || RegionComboBox.Text == "Main")
                {
                    currentProject.tradeWindOverlayImgPath = imgPath;
                }
                else
                {
                    if (!currentProject.regionsTradeWindOverlayImgPath.ContainsKey(RegionComboBox.Text))
                        currentProject.regionsTradeWindOverlayImgPath.Add(RegionComboBox.Text, imgPath);
                    else
                    {
                        currentProject.regionsTradeWindOverlayImgPath[RegionComboBox.Text] = imgPath;
                    }
                }

                currentProject.showTradeWindOverlay = true;

                SetTradeWindOverlayImage(currentProject.tradeWindOverlayImgPath, currentProject.regionsTradeWindOverlayImgPath);

                tradeWindOverlayChckBox.Checked = true;
            }
        }

        private void foregroundScaleBox_ValueChanged(object sender, EventArgs e)
        {
            mapPanel.Invalidate();
        }

        private void editServerTemplatesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var editForm = new EditServerTemplates(this);
            editForm.ShowDialog();
        }

        static Font astrixFont = new Font(SystemFonts.DefaultFont.FontFamily, DefaultFont.SizeInPoints * 1.5f, FontStyle.Bold);
        private void islandListBox_DrawItem(object sender, DrawListViewItemEventArgs e)
        {
            if (e.Item.Selected)
            {
                Rectangle rowBounds = e.Bounds;
                int leftMargin = e.Item.GetBounds(ItemBoundsPortion.Entire).Left;
                Rectangle bounds = new Rectangle(leftMargin, rowBounds.Top, rowBounds.Width - leftMargin, rowBounds.Height);
                e.Graphics.FillRectangle(SystemBrushes.Highlight, bounds);
            }

            //e.DrawDefault = true;
            //e.DrawFocusRectangle();
            e.DrawText();
        }

        private void islandListBox_DrawSubItem(object sender, DrawListViewSubItemEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                Point p = e.Bounds.Location;
                p.X += 20;
                e.Item.ImageList.Draw(e.Graphics, p, e.ItemIndex);


                int instanceCount = 0;
                if (currentProject != null)
                    foreach (IslandInstanceData islandInstance in currentProject.islandInstances)
                        if (islandInstance.name == e.Item.SubItems[2].Text)
                            instanceCount++;

                if (instanceCount > 0)
                {
                    e.Graphics.DrawString("*" + instanceCount, astrixFont, new SolidBrush(Color.Red), e.Bounds.X + 10, e.Bounds.Y + e.Bounds.Height / 2, centeredStringFormat);
                    return;
                }
            }
            e.DrawText(TextFormatFlags.VerticalCenter);
            //e.DrawFocusRectangle(e.Bounds);
            //e.DrawDefault = true;
        }

        private void islandListBox_DrawColumnHeader(object sender, DrawListViewColumnHeaderEventArgs e)
        {
            e.DrawDefault = true;
        }

        private void editLocksToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var editForm = new EditAllLocksForm(this);
            editForm.ShowDialog();
        }

        private void cullInvalidPathsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (currentProject == null)
                return;

            // hold on to the count of culled paths for display purposes
            var invalidCount = 0;

            // determine the maximum X and Y coordinate that would be valid for this grid
            var maxWidth = currentProject.cellSize * currentProject.numOfCellsX;
            var maxHeight = currentProject.cellSize * currentProject.numOfCellsY;
            var maxDimensions = new PointF(maxWidth, maxHeight);

            // remove any path with any node with a coordinate below origin or above the calculated maximum
            currentProject.shipPaths.RemoveAll((path) =>
            {
                foreach (var node in path.Nodes)
                {
                    if (node.worldX < 0 || node.worldX > maxDimensions.X || node.worldY < 0 ||
                        node.worldY > maxDimensions.Y)
                    {
                        invalidCount++;
                        return true;
                    }
                }

                return false;
            });

            // remove any trade wind with any node with a coordinate below origin or above the calculated maximum
            currentProject.tradeWinds.RemoveAll((path) =>
            {
                foreach (var node in path.Nodes)
                {
                    if (node.worldX < 0 || node.worldX > maxDimensions.X || node.worldY < 0 ||
                        node.worldY > maxDimensions.Y)
                    {
                        invalidCount++;
                        return true;
                    }
                }

                return false;
            });

            currentProject.portalPaths.RemoveAll((path) =>
            {
                foreach (var node in path.Nodes)
                {
                    if (node.worldX < 0 || node.worldX > maxDimensions.X || node.worldY < 0 ||
                        node.worldY > maxDimensions.Y)
                    {
                        invalidCount++;
                        return true;
                    }
                }

                return false;
            });
            
            if (invalidCount > 0)
            {
                MessageBox.Show($"Found and removed {invalidCount} invalid paths!", "Invalid Paths Culled", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Did not find any invalid paths to cull!", "No Invalid Paths", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            RefreshIslandList();
        }

        private void GridColumnsTxtBox_TextChanged(object sender, EventArgs e)
        {
            if (currentProject == null)
                return;
            int parsed = 0;
            if (int.TryParse(GridColumnsTxtBox.Text, out parsed))
                currentProject.numPathingGridColumns = parsed;
            if(!bIsloadingProject)
            currentProject.AtlasPathingGridDirty = true;
            mapPanel.Invalidate();
        }

        private void GridRowsTxtBox_TextChanged(object sender, EventArgs e)
        {
            if (currentProject == null)
                return;
            int parsed = 0;
            if (int.TryParse(GridRowsTxtBox.Text, out parsed))
                currentProject.numPathingGridRows = parsed;
            if(!bIsloadingProject)
            currentProject.AtlasPathingGridDirty = true;
            mapPanel.Invalidate();
        }

        private void showPathingGridCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            gridRowsLabel.Visible = showPathingGridCheckbox.Checked;
            gridColumnsLabel.Visible = showPathingGridCheckbox.Checked;
            GridRowsTxtBox.Visible = showPathingGridCheckbox.Checked;
            GridColumnsTxtBox.Visible = showPathingGridCheckbox.Checked;
            mapPanel.Invalidate();
        }

        private void RecalcPathingGridButton_Click(object sender, EventArgs e)
        {
            RecalcPathingGrid(currentProject, islands);
        }

        private static void RecalcPathingGrid(Project currentProject, IDictionary<string, Island> islands)
        {
            bool[,] Validity = new bool[(currentProject.numPathingGridRows * currentProject.numOfCellsY), (currentProject.numPathingGridColumns * currentProject.numOfCellsX)];
            for (int Row = 0; Row < Validity.GetLength(0); Row++)
                for (int Col = 0; Col < Validity.GetLength(1); Col++)
                    Validity[Row, Col] = true;
            float PrevScaling = currentProject.coordsScaling;
            currentProject.coordsScaling = 0.001f;
            float MyCellSize = Math.Max(currentProject.cellSize * currentProject.coordsScaling, 0.00001f);
            float CellWidth = MyCellSize / (currentProject.numPathingGridColumns);
            float CellHeight = MyCellSize / (currentProject.numPathingGridRows);


            for (int Row = 0; Row < Validity.GetLength(0); Row++)
            {
                for (int Col = 0; Col < Validity.GetLength(1); Col++)
                {
                    float StartX = Col * CellWidth;
                    float StartY = Row * CellHeight;
                    RectangleF CellRect = new RectangleF(StartX, StartY, CellWidth, CellHeight);
                    foreach (IslandInstanceData instance in currentProject.islandInstances)
                    {
                        Island referencedIsland = instance.GetReferencedIsland(islands);

                        //Clamp to map
                        //instance.SetWorldLocation(mainForm, new PointF(instance.worldX, instance.worldY));

                        //Reverse translation to rotate around self
                        //g.TranslateTransform(instance.worldX * currentProject.coordsScaling, instance.worldY * currentProject.coordsScaling);
                        //g.RotateTransform(instance.rotation, System.Drawing.Drawing2D.MatrixOrder.Prepend);

                        Rectangle drawRect = instance.GetRect(currentProject, islands);
                        if (CellRect.IntersectsWith(drawRect))
                        {
                            Validity[Row, Col] = false;
                        }

                        //g.RotateTransform(-instance.rotation);
                        //g.TranslateTransform(-instance.worldX * currentProject.coordsScaling, -instance.worldY * currentProject.coordsScaling);

                        if (!Validity[Row, Col])
                            break;
                    }

                }
            }

            currentProject.coordsScaling = PrevScaling;
            currentProject.AtlasPathingGrid = Validity;
            currentProject.AtlasPathingGridDirty = false;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void tradewindsWorldMapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (currentProject == null)
                return;

            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "PNG files (*.png)|*.png";
                string ExportPath = Path.GetFullPath(GlobalSettings.Instance.ExportDir + actualJsonFile.Replace(".json", ""));
                if (!Directory.Exists(ExportPath))
                    Directory.CreateDirectory(ExportPath);
                saveFileDialog.InitialDirectory = ExportPath;
                saveFileDialog.FileName = "MapImg_TradeWinds.png";
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    PopulateMapRegions();
                    ExportImage(saveFileDialog.FileName, -1, -1, true, editorConfig.AtlasImagesRes, true);
                    ExportRegionTradewindOverlays(saveFileDialog.FileName, editorConfig.AtlasImagesRes);
                }
            }
        }

        private void editServerConfigurationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var editServerConfiguration = new EditServerConfigurations(this);
            editServerConfiguration.ShowDialog();
        }

        private void visualizeTradewindsWidthCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            mapPanel.Invalidate();
        }

        private void editFoliageAttachmentOverrideToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var editFoliageAttachmentOverrides = new EditFoliageAttachmentOverrides(this);
            editFoliageAttachmentOverrides.ShowDialog();
        }

        private void editNodeTemplateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EditNodeTemplates editNodeTemplates = new EditNodeTemplates(this);
            editNodeTemplates.ShowDialog();
        }



        public Server GetServerAt(int x, int y)
        {
            foreach (Server server in currentProject.servers)
                if (server.gridX == x && server.gridY == y)
                    return server;
            return null;
        }


        public int GetSmallestServerXWithSameHiddenAtlasId(Server server)
        {
            int minX = 0;
            int PrevServerX = server.gridX;
            while (PrevServerX > minX)
            {
                int CandidateServerX = PrevServerX - 1;
                Server CandidateServer = GetServerAt(CandidateServerX, server.gridY);
                if (CandidateServer != null && CandidateServer.hiddenAtlasId == server.hiddenAtlasId)
                    PrevServerX = CandidateServerX;
                else
                    break;
            }
            return PrevServerX;
        }


        public int GetLargestServerXWithSameHiddenAtlasId(Server server)
        {
            int maxX = currentProject.numOfCellsX - 1;
            int NextServerX = server.gridX;
            while (NextServerX + 1 <= maxX)
            {
                int CandidateServerX = NextServerX + 1;
                Server CandidateServer = GetServerAt(CandidateServerX, server.gridY);
                if (CandidateServer != null && CandidateServer.hiddenAtlasId == server.hiddenAtlasId)
                    NextServerX = CandidateServerX;
                else
                    break;
            }
            return NextServerX;
        }


        public int GetSmallestServerYWithSameHiddenAtlasId(Server server)
        {
            int minY = 0;
            int PrevServerY = server.gridY;
            while (PrevServerY > minY)
            {
                int CandidateServerY = PrevServerY - 1;
                Server CandidateServer = GetServerAt(server.gridX, CandidateServerY);
                if (CandidateServer != null && CandidateServer.hiddenAtlasId == server.hiddenAtlasId)
                    PrevServerY = CandidateServerY;
                else
                    break;
            }
            return PrevServerY;
        }

        public int GetLargestServerYWithSameHiddenAtlasId(Server server)
        {
            int maxY = currentProject.numOfCellsY - 1;
            int NextServerY = server.gridY;
            while (NextServerY + 1 <= maxY)
            {
                int CandidateServerY = NextServerY + 1;
                Server CandidateServer = GetServerAt(server.gridX, CandidateServerY);
                if (CandidateServer != null && CandidateServer.hiddenAtlasId == server.hiddenAtlasId)
                    NextServerY = CandidateServerY;
                else
                    break;
            }
            return NextServerY;
        }


        public void PopulateMapRegions(bool bIsExporting = false)
        {
            if (MapRegionsList.Count > 0 && MapRegionsList.Count == regionsTile.Count && !PopulateMapRegionsDirty)
                return;
            PopulateMapRegionsDirty = false;
            //Project currentProject = mainForm.currentProject;
            MapRegionsList.Clear();
            if(!bIsExporting)
                RegionComboBox.Items.Clear();

            int maxDimension = GetMaxMainRegionDimension(currentProject);
            MapRegion MainRegion = new MapRegion();
            MainRegion.AtlasID = "Main";
            MainRegion.StartX = 0;
            MainRegion.StartY = 0;
            MainRegion.EndX = maxDimension - 1;
            MainRegion.EndY = maxDimension - 1;
            MapRegionsList.Add(MainRegion.AtlasID, MainRegion);
            if(!bIsExporting)
                RegionComboBox.Items.Add(MainRegion.AtlasID);
            foreach (Server myServer in currentProject.servers)
                if (myServer.hiddenAtlasId != null && myServer.hiddenAtlasId.Length > 0)
                    if (!MapRegionsList.ContainsKey(myServer.hiddenAtlasId))
                    {
                        MapRegion myRegion = new MapRegion();
                        myRegion.AtlasID = myServer.hiddenAtlasId;
                        myRegion.StartX = GetSmallestServerXWithSameHiddenAtlasId(myServer);
                        myRegion.StartY = GetSmallestServerYWithSameHiddenAtlasId(myServer);
                        myRegion.EndX = GetLargestServerXWithSameHiddenAtlasId(myServer);
                        myRegion.EndY = GetLargestServerYWithSameHiddenAtlasId(myServer);
                        MapRegionsList.Add(myServer.hiddenAtlasId, myRegion);
                        if (!bIsExporting)
                            RegionComboBox.Items.Add(myRegion.AtlasID);
                    }
            if (!bIsExporting)
            {
                RegionComboBox.Text = MainRegion.AtlasID;
                RegionComboBox.SelectedItem = MainRegion.AtlasID;
                RegionComboBox.Update();
            }

            List<string> RegionTileKeysToRemove = new List<string>();
            foreach (KeyValuePair<string, Image> regionTile in regionsTile)
                if (!MapRegionsList.ContainsKey(regionTile.Key))
                    RegionTileKeysToRemove.Add(regionTile.Key);

            foreach (string regionTileKey in RegionTileKeysToRemove)
            {
                regionsTile.Remove(regionTileKey);
                regionsTileBrush.Remove(regionTileKey);
            }
            if(!bIsExporting)
                this.Update();
        }

        private void showPortalNodesChckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (currentProject != null)
            {
                currentProject.showPortalNodes = showPortalNodesChckBox.Checked;
            }
            mapPanel.Invalidate();
        }

        private void editRegionsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void editRegionCategoriesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EditRegionsCategories editRegionsCategories = new EditRegionsCategories(this);
            editRegionsCategories.ShowDialog();
        }

        private void editRegionTemplateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EditRegionsTemplates editRegionsTemplates = new EditRegionsTemplates(this);
            editRegionsTemplates.ShowDialog();
        }

        public List<string> GetRegionNames()
        {
            List<string> RegionsNames = new List<string>();
            foreach(string RegionName in RegionComboBox.Items)
            {
                RegionsNames.Add(RegionName);
            }
            return RegionsNames;
        }

        private void RegionTemplateOverridebtn_Click(object sender, EventArgs e)
        {
            AppliedRegionTemplateData serverTemplate = currentProject.GetAppliedRegionTemplateByName(RegionComboBox.Text);
            if (serverTemplate != null)
            {
                string originalName = serverTemplate.name;
                var editForm = new EditAppliedRegionTemplate(this, serverTemplate);
                if (editForm.ShowDialog() == DialogResult.OK)
                {
                    if (serverTemplate.name != originalName)
                    {
                    }
                }
            }
        }

        private void editRegionsTreasureMapOverrideToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EditRegionsTreasureMapOverride editRegionsTreasureMapOverride = new EditRegionsTreasureMapOverride(this);
            editRegionsTreasureMapOverride.ShowDialog();
        }

        private void editRegionsOverworldLocationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EditRegionsOverworldLocations editRegionsOverworldLocations = new EditRegionsOverworldLocations(this);
            editRegionsOverworldLocations.ShowDialog();
        }
    }

    public class Config
    {
        //public string LastOpenedFolder = "";
        //public string LastMapsFolder = "";
        public int CellImagesRes = 2048;
        public int AtlasImagesRes = 2048;
        public int ImageQuality = 75;
    }


}