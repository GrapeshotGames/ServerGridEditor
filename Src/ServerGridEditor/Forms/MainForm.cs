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

namespace ServerGridEditor
{
    public partial class MainForm : Form
    {
        public static string imgsDir = "./IslandImages";
        public static string waterTilesDir = "./WaterTiles";
        public static string foregroundTilesDir = "./Foregrounds";
        public static string dataDir = "./Data";
        public static string exportDir = "./Export";
        public static string configSaveFile = dataDir + "/config.json";
        public static string islandsSaveFile = dataDir + "/islands.json";
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
        public static float islandNameScale = 0.01f;
        public static float useFullIslandRes = 5000;
        public static float islandsNamesMaxRes = 10000;

        public Cursor editCursor;
        public Project currentProject = null;

        public Dictionary<string, Island> islands = new Dictionary<string, Island>();

        Image tile = null;
        TextureBrush tileBrush = null;
        static Image lockImg = null;
        public Image foreground = null;
        public TextureBrush foregroundBrush = null;

        MoveableObjectData CurrentHeldMoveableObject = null;
        MoveableObjectData CurrentRotatedMoveableObject = null;

        bool bResizingDiscoZone = false;
        Point LastMouseLocation;
        public Config editorConfig;

        public Spawners spawners;
        public int mytestscroll;

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

            foreach (string islandKey in SortedIslands)
            {
                Island island = islands[islandKey];
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

        public void DrawMapToGraphics(ref Graphics g, bool cull = false, bool ignoreTranslation = false, bool forExport = false)
        {
            if (currentProject == null)
                return;

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

            DrawMap(
                this, islands, g,
                showLinesCheckbox.Checked, showServerInfoCheckbox.Checked, showDiscoZoneInfoCheckbox.Checked,
                culling, alphaBackground,
                tiledBackgroundCheckbox.Checked ? tile : null,
                tiledBackgroundCheckbox.Checked ? tileBrush: null,
                tileScaleBox.Value,
                !ignoreTranslation ? mapHScrollBar.Value : 0,
                !ignoreTranslation ? mapVScrollBar.Value : 0,
                forExport);
        }

        static StringFormat centeredStringFormat = new StringFormat
        {
            LineAlignment = StringAlignment.Center,
            Alignment = StringAlignment.Center
        };

        public static void DrawMap(
            MainForm mainForm, IDictionary<string, Island> islands,
            Graphics g, bool showLines, bool showServerInfo, bool showDiscoZoneInfo,
            RectangleF? culling, Color? alphaBackground,
            Image tile, TextureBrush tileBrush, decimal tileScale,
            int translateH, int translateV, bool forExport)
        {

            g.InterpolationMode = InterpolationMode.High;


            Project currentProject = mainForm.currentProject;

            bool getOptimizedImage = !forExport && (1 / currentProject.coordsScaling > useFullIslandRes);
            if(getOptimizedImage)
            {
                g.InterpolationMode = InterpolationMode.Low;
                g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SingleBitPerPixelGridFit;
                //g.CompositingMode = CompositingMode.SourceCopy;
                g.SmoothingMode = SmoothingMode.HighSpeed;
                g.CompositingQuality = CompositingQuality.HighSpeed;
            }


            float cellSize = Math.Max(currentProject.cellSize * currentProject.coordsScaling, 0.00001f);

            float maxX = currentProject.numOfCellsX * cellSize;
            float maxY = currentProject.numOfCellsY * cellSize;

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
            if (tile != null && tileBrush != null)
            {
                tileBrush.ResetTransform();
                tileBrush.ScaleTransform((float)tileScale * currentProject.coordsScaling * 1000, (float)tileScale * currentProject.coordsScaling * 1000);
                g.FillRectangle(tileBrush, new Rectangle(0, 0, (int)maxX, (int)maxY));
            }

            //Draw  grid
            if (showLines)
            {
                //horizontal lines
                for (int y = 0; y < currentProject.numOfCellsY + 1; ++y)
                {
                    float drawY = y * cellSize;
                    if (!cull || (drawY >= canvasRect.Top && drawY <= canvasRect.Bottom))
                        g.DrawLine(p, 0, drawY, currentProject.numOfCellsX * cellSize, drawY);
                }

                //vertical lines
                for (int x = 0; x < currentProject.numOfCellsX + 1; ++x)
                {
                    float drawX = x * cellSize;
                    if (!cull || (drawX >= canvasRect.Left && drawX <= canvasRect.Right))
                        g.DrawLine(p, drawX, 0, drawX, currentProject.numOfCellsY * cellSize);
                }
            }

            //Draw islands
            float maxWorldX = currentProject.numOfCellsX * currentProject.cellSize;
            float maxWorldY = currentProject.numOfCellsY * currentProject.cellSize;

            bool optimizeOutIslandNames = !forExport && (1 / currentProject.coordsScaling > islandsNamesMaxRes);

            foreach (IslandInstanceData instance in currentProject.islandInstances)
            {
                Island referencedIsland = instance.GetReferencedIsland(islands);

                //Clamp to map
                instance.SetWorldLocation(mainForm, new PointF(instance.worldX, instance.worldY));

                //Reverse translation to rotate around self
                g.TranslateTransform(instance.worldX * currentProject.coordsScaling, instance.worldY * currentProject.coordsScaling);
                g.RotateTransform(instance.rotation, System.Drawing.Drawing2D.MatrixOrder.Prepend);

                Rectangle drawRect = instance.GetRect(currentProject, islands);

                if (!cull || canvasRect.IntersectsWith(drawRect))
                {
                    drawRect.X = -drawRect.Width / 2;
                    drawRect.Y = -drawRect.Height / 2;

                    g.DrawImage(referencedIsland.GetImage(getOptimizedImage), drawRect);

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
            if(currentProject.showForeground && mainForm.foregroundBrush != null)
            {
                mainForm.foregroundBrush.ResetTransform();
                mainForm.foregroundBrush.ScaleTransform((float)mainForm.foregroundScaleBox.Value * currentProject.coordsScaling * 1000, (float)mainForm.foregroundScaleBox.Value * currentProject.coordsScaling * 1000);
                g.FillRectangle(mainForm.foregroundBrush, new Rectangle(0, 0, (int)maxX, (int)maxY));
            }


            if (currentProject.DiscoveryZoneImage != null && showDiscoZoneInfo)
            {
                //Draw Discovery Zones
                foreach (DiscoveryZoneData discoInst in currentProject.discoZones)
                {
                    if (discoInst.bIsManuallyPlaced)
                        continue;
                    //Clamp to map
                    discoInst.SetWorldLocation(mainForm, new PointF(discoInst.worldX, discoInst.worldY));

                    //Reverse translation to rotate around self
                    g.TranslateTransform(discoInst.worldX * currentProject.coordsScaling, discoInst.worldY * currentProject.coordsScaling);
                    g.RotateTransform(discoInst.rotation, System.Drawing.Drawing2D.MatrixOrder.Prepend);

                    Rectangle drawRect = discoInst.GetRect(currentProject);

                    if (drawRect.Width < 0)
                        drawRect.Width *= -1;

                    if (drawRect.Height < 0)
                        drawRect.Height *= -1;

                    if (!cull || canvasRect.IntersectsWith(drawRect))
                    {
                        drawRect.X = -drawRect.Width / 2;
                        drawRect.Y = -drawRect.Height / 2;
                        g.DrawImage(currentProject.DiscoveryZoneImage, drawRect);
                    }

                    g.RotateTransform(-discoInst.rotation);
                    g.TranslateTransform(-discoInst.worldX * currentProject.coordsScaling, -discoInst.worldY * currentProject.coordsScaling);
                }

                //Draw discoZone info
                // if (showDiscoZoneInfo)
                {
                    foreach (DiscoveryZoneData zoneInst in currentProject.discoZones)
                    {
                        float zoneSize = Math.Max(zoneInst.sizeX * currentProject.coordsScaling, 0.00001f);
                        Font font = new Font(SystemFonts.DefaultFont.FontFamily, DefaultFont.SizeInPoints * zoneSize / 200, FontStyle.Regular);
                        SizeF stringSize = g.MeasureString("T", font);
                        float dynamicOutlineShift = stringSize.Height * outlineShift;

                        PointF zoneCenter = new PointF(zoneInst.worldX, zoneInst.worldY);
                        zoneCenter = new PointF(zoneCenter.X * currentProject.coordsScaling, zoneCenter.Y * currentProject.coordsScaling);
                        if (cull)
                        {
                            RectangleF drawRect = new RectangleF(zoneCenter.X - stringSize.Width / 2, zoneCenter.Y - stringSize.Width / 2, stringSize.Width, 3.3f * stringSize.Height);
                            if (RectangleF.Intersect(canvasRect, drawRect).IsEmpty)
                                continue;
                        }

                        g.DrawString("name: " + zoneInst.name, font, Brushes.Black, new PointF(zoneCenter.X + dynamicOutlineShift, zoneCenter.Y + dynamicOutlineShift), centeredStringFormat);
                        zoneCenter.Y += stringSize.Height * 1.1f;
                        g.DrawString("xp: " + zoneInst.xp, font, Brushes.White, zoneCenter, centeredStringFormat);
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
                    serverCenter.Y -= cellSize * 0.15f;
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
                    }

                    if (cull)
                    {
                        RectangleF drawRect = new RectangleF(serverCenter.X - stringSize.Width / 2, serverCenter.Y - stringSize.Width / 2, stringSize.Width, 3.3f * stringSize.Height);
                        if (RectangleF.Intersect(canvasRect, drawRect).IsEmpty) //not being drawn, cull
                            continue;
                    }


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
                        PointF NodeCenter = mainForm.UnrealToMapPoint(new PointF(lastNode.worldX - mainForm.currentProject.cellSize * mainForm.currentProject.numOfCellsX, lastNode.worldY));
                        bezierPoints.Add(NodeCenter);

                        PointF NextControlCenter = lastNode.GetNextControlPoint();
                        NextControlCenter.X -= mainForm.currentProject.cellSize * mainForm.currentProject.numOfCellsX;
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
                            if(i == shipPath.Nodes.Count - 1 && shipPath.isLooping)
                            {
                                PointF PrevControl = node.GetNextNode().GetPrevControlPoint();
                                PrevControl.X += mainForm.currentProject.cellSize * mainForm.currentProject.numOfCellsX;
                                bezierPoints.Add(mainForm.UnrealToMapPoint(PrevControl));
                            }
                            else
                                bezierPoints.Add(mainForm.UnrealToMapPoint(node.GetNextNode().GetPrevControlPoint()));
                        }
                    }

                    if (shipPath.isLooping)
                    {
                        BezierNodeData firstNode = shipPath.Nodes[0];
                        PointF NodeCenter = mainForm.UnrealToMapPoint(new PointF(firstNode.worldX + mainForm.currentProject.cellSize * mainForm.currentProject.numOfCellsX, firstNode.worldY));
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
            currentProject.islandInstances.Add(new IslandInstanceData().SetFrom((string)e.Data.GetData("".GetType()), worldPoint.X, worldPoint.Y, 0, id));
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

            if (CurrentHeldMoveableObject != null)
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
        private void mapPanel_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
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
                        BezierNodeData node = GetFirstBezierNodeAtLocation(GetTarnsformedMapPoint(e.Location));
                        if (node != null)
                        {
                            var editForm = new EditShipPath(node.shipPath);
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
                }
            }
            else if (e.Button == MouseButtons.Right)
            {
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

            //// This section has been modified to include value modification to the global value mytestscroll
            //// The Control Key will zoom in, the Shift key will zoom out using the middle mouse button click.
            else if (e.Button == MouseButtons.Middle)
            {
                middlePressLocation.X = mapHScrollBar.Value;
                middlePressLocation.Y = mapVScrollBar.Value;

                if (ModifierKeys == Keys.Control)
                {
                    mytestscroll = 1;
                    mapPanel_MouseWheel(this, e);
                }
                if (ModifierKeys == Keys.Shift)
                {
                    mytestscroll = -1;
                    mapPanel_MouseWheel(this, e);
                }

            }

        }


        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                Point cursorMapPoint = GetTarnsformedMapPoint(mapPanel.PointToClient(Cursor.Position));
                IslandInstanceData islandInst = GetFirstInstanceAtLocation(cursorMapPoint);
                DiscoveryZoneData discoInst;
                BezierNodeData bezierNode;

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
                        currentProject.shipPaths.Remove(bezierNode.shipPath);
                        mapPanel.Invalidate();
                    }
                    else
                    {
                        if (!bezierNode.shipPath.DeleteNode(bezierNode))
                            MessageBox.Show("A bezier path can't have less than 2 points\nTo delete the whole path use Shift + Delete");
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
            else if (e.KeyCode == Keys.Add || e.KeyCode == Keys.Oemplus)
            {
                //Create new ship path
                BezierNodeData selectedBezierNode = GetFirstBezierNodeAtLocation(GetTarnsformedMapPoint(previousMousePos));
                if (selectedBezierNode != null) //To ensure being in-grid
                {
                    selectedBezierNode.shipPath.AddNode(selectedBezierNode);
                    mapPanel.Invalidate();
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
            }
            else if (e.Button == MouseButtons.Right)
            {
                CurrentRotatedMoveableObject = null;
            }
            else if (e.Button == MouseButtons.Middle)
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



        public void SaveIslands()
        {
            //Take backup
            if (File.Exists(islandsSaveFile))
                File.Copy(islandsSaveFile, islandsSaveFileBackup, true);

            string json = JsonConvert.SerializeObject(islands, Formatting.Indented);
            File.WriteAllText(islandsSaveFile, json);
        }

        public void LoadIslands()
        {
            if (File.Exists(islandsSaveFile))
            {
                islands = JsonConvert.DeserializeObject<Dictionary<string, Island>>(File.ReadAllText(islandsSaveFile));
                RefreshIslandList();
            }
        }

        public void SaveProject()
        {
            JsonSerializerSettings settings = new JsonSerializerSettings();
            string json = JsonConvert.SerializeObject(islands, Formatting.Indented);
            File.WriteAllText(islandsSaveFile, json);
        }

        /// <summary>
        /// Creats a completely new project replacing the current one if already there
        /// </summary>
        public void CreateProject(float CellSize, int xCells, int yCells, string worldFriendlyName, string worldAtlasId, string worldAtlasPassword)
        {
            currentProject = new Project(CellSize, xCells, yCells);
            currentProject.WorldFriendlyName = worldFriendlyName;
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
            disableImageExportingCheckBox.Checked = currentProject.disableImageExporting;
            showLinesCheckbox.Checked = currentProject.showLines;
            alphaBgCheckbox.Checked = currentProject.alphaBackground;
            tiledBackgroundCheckbox.Checked = currentProject.showBackground;
            SetTileImage(currentProject.backgroundImgPath);
            showForegroundChckBox.Checked = currentProject.showForeground;
            SetForegroundImage(currentProject.foregroundImgPath);
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

        /// <summary>
        /// Gets the first discovery zone instance at a map location
        /// </summary>
        public BezierNodeData GetFirstBezierNodeAtLocation(Point p)
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
                    if(node.ContainsPoint(p, this))
                    {
                        return node;
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


        public Bitmap DrawMapToImage(int cellX = -1, int cellY = -1, float resOverride = -1, bool forceResForSingleCell = false)
        {
            if (currentProject == null || ((cellX == -1 || cellY == -1) && cellX != cellY))
                return null;

            bool isSingleCell = cellX > -1;

            float originalCoordScale = currentProject.coordsScaling;
            if (resOverride > -1)
            {
                float totalUnrealSize = currentProject.cellSize;
                if (!isSingleCell)
                {
                    resOverride -= 2; //these pixels are added below in calculations
                    totalUnrealSize *= Math.Max(currentProject.numOfCellsX, currentProject.numOfCellsY);
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
                sizeX = (int)(currentProject.numOfCellsX * currentProject.cellSize * currentProject.coordsScaling);
                sizeY = (int)(currentProject.numOfCellsY * currentProject.cellSize * currentProject.coordsScaling);
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

            Bitmap image = new Bitmap(imgSize.Width, imgSize.Height, PixelFormat.Format16bppRgb555);

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

            if (largerDimension > maxImageSize)
            {
                g.ScaleTransform(scale, scale);
            }

            int previousH = mapHScrollBar.Value;
            int previousV = mapVScrollBar.Value;
            mapVScrollBar.Value = mapHScrollBar.Value = 0;
            DrawMapToGraphics(ref g, false, isSingleCell, true);
            mapHScrollBar.Value = previousH;
            mapVScrollBar.Value = previousV;
            currentProject.coordsScaling = originalCoordScale;

            //g.DrawImage(image, imgSize);

            return image;
        }

        public void ExportImage(string filePath, int cellX = -1, int cellY = -1, bool exportOverrides = true, float resOverride = -1)
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

            if (image == null)
            {
                if(cellX == -1 && cellY == -1 && resOverride > maxImageSize)
                {
                    //Using a large resolution, combine cell images instead of exporting a huge one at once
                    int maxCells = Math.Max(currentProject.numOfCellsX, currentProject.numOfCellsY);
                    float resPerCell = (float)Math.Round(resOverride / currentProject.numOfCellsX);

                    Bitmap[,] cellImages = new Bitmap[currentProject.numOfCellsX, currentProject.numOfCellsY];
                    string dir = Path.GetDirectoryName(filePath);
                    MagickAnyCPU.CacheDirectory = dir;
                    if (!Directory.Exists(dir + "/magicktemp"))
                        Directory.CreateDirectory(dir + "/magicktemp");
                    MagickNET.SetTempDirectory(dir+"/magicktemp");
                    ImageMagick.ResourceLimits.Memory = 8388608;

                    for (int i = 0; i < currentProject.numOfCellsX; i++)
                        for (int j = 0; j < currentProject.numOfCellsY; j++)
                        {
                            //Bitmap drawnCell = DrawMapToImage(i, j, resPerCell, true);
                            //MagickImage mgickCell = new MagickImage(drawnCell);
                            //mgickCell.Format = MagickFormat.Bmp;
                            //mgickCell.Write(dir + "/tmpimgCompImg" + i + "-" + j + ".bmp");
                            //drawnCell.Dispose();
                            cellImages[i, j] = DrawMapToImage(i, j, resPerCell, true);
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

                        atlasMontage.Format = MagickFormat.Png;
                        atlasMontage.Depth = 16;
                        atlasMontage.Quality = editorConfig.ImageQuality;
                        //filePath = filePath.Replace(".png", ".tiff").Replace(".jpg", ".tiff");
                        filePath = filePath.Replace(".jpg", ".png");
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
                    image = DrawMapToImage(cellX, cellY, resOverride);
            }

            if (image == null)
                return;

            MagickImage tgaImg = new MagickImage(image);
            tgaImg.Format = MagickFormat.Jpeg;
            tgaImg.Quality = editorConfig.ImageQuality;
            tgaImg.Write(filePath);
            tgaImg.Dispose();

        }

        public void ExportCellImages(string path)
        {
            if (currentProject == null)
                return;

            string FullPath = Path.GetDirectoryName(path);
            string Extension = Path.GetExtension(path);
            string FilenameWithoutExtension = Path.GetFileNameWithoutExtension(path);
            for (int i = 0; i < currentProject.numOfCellsX; i++)
            {
                for (int j = 0; j < currentProject.numOfCellsY; j++)
                {
                    string CellFile = FullPath + string.Format(cellImageNameTemplate, FilenameWithoutExtension , i, j, Extension);
                    ExportImage(CellFile, i, j, true, editorConfig.CellImagesRes);
                }
            }
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

            saveFileDialog.Filter = "json files (*.json)|*.json";
            saveFileDialog.FileName = actualJsonFile;
            saveFileDialog.InitialDirectory = GlobalSettings.Instance.ProjectsDir;
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                File.WriteAllText(saveFileDialog.FileName, currentProject.Serialize(this));
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
                    EnableProjectMenuItems();
                    actualJsonFile = openFileDialog.SafeFileName;
                    currentProject = loadedProj;
                    SetScaleTxt(1 / currentProject.coordsScaling);
                    SetToolsVisibility(true);

                    showServerInfoCheckbox.Checked = currentProject.showServerInfo;
                    showDiscoZoneInfoCheckbox.Checked = currentProject.showDiscoZoneInfo;
                    showIslandNamesChckBox.Checked = currentProject.showIslandNames;
                    showShipPathsInfoChckBox.Checked = currentProject.showShipPathsInfo;
                    disableImageExportingCheckBox.Checked = currentProject.disableImageExporting;
                    showLinesCheckbox.Checked = currentProject.showLines;
                    alphaBgCheckbox.Checked = currentProject.alphaBackground;
                    tiledBackgroundCheckbox.Checked = currentProject.showBackground;
                    SetTileImage(currentProject.backgroundImgPath);
                    showForegroundChckBox.Checked = currentProject.showForeground;
                    SetForegroundImage(currentProject.foregroundImgPath);
                    SetDiscoverZoneImage(currentProject.discoZonesImagePath);

                    mapPanel.Invalidate();
                    mapPanel.Update();
                }
            }
        }

        private void mapImageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (currentProject == null)
                return;

            saveFileDialog.Filter = "jpg files (*.jpg)|*.jpg";
            string ExportPath = Path.GetFullPath(GlobalSettings.Instance.ExportDir + actualJsonFile.Replace(".json", ""));
            if (!Directory.Exists(ExportPath))
                Directory.CreateDirectory(ExportPath);
            saveFileDialog.InitialDirectory = ExportPath;
            saveFileDialog.FileName = "MapImg.jpg";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                ExportImage(saveFileDialog.FileName, -1, -1, true, editorConfig.AtlasImagesRes);
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
                "L while hovered on cell (Open locks form)\n"+
                "P while on map (Spawn ship path)\n" +
                "Delete on path nodes (Delete node)\n" +
                "Ctrl + click on path node (Edit path)\n" +
                "Shift + Delete on path nodes (Delete whole path)\n" +
                "Shift + middle mouse Zooms out\n" +
                "Ctrl + middle mouse Zooms in\n", "Controls");
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
                for (int i = 0; i < currentProject.islandInstances.Count; i++)
                    foreach (string islandToRemove in islandsToRemove)
                        if (currentProject.islandInstances[i].name == islandToRemove)
                        {
                            currentProject.islandInstances[i].SetDirty(this);
                            currentProject.islandInstances.RemoveAt(i);
                            i--;
                        }
            }

            foreach (string islandToRemove in islandsToRemove)
            {
                //delete the image
                islands[islandToRemove].InvalidateImage();
                File.Delete(islands[islandToRemove].imagePath);

                islands.Remove(islandToRemove);
            }

            RefreshIslandList();
            mapPanel.Invalidate();
            SaveIslands();
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

                if (tileBrush != null)
                    tileBrush.Dispose();
                if (tile != null)
                    tile.Dispose();

                //File.Copy(openFileDialog.FileName, imgName + openFileDialog.SafeFileName, true);
                currentProject.showBackground = true;
                currentProject.backgroundImgPath = imgName + openFileDialog.SafeFileName;
                SetTileImage(currentProject.backgroundImgPath);
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


        void SetTileImage(string fileName)
        {
            if (tileBrush != null)
                tileBrush.Dispose();
            tileBrush = null;

            if (tile != null)
                tile.Dispose();
            tile = null;

            if (File.Exists(fileName))
            {
                tile = Image.FromFile(fileName);
                tileBrush = new TextureBrush(tile);
            }

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

            saveFileDialog.Filter = "jpg files (*.jpg)|*.jpg";
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
                            tile, tileBrush, mapPanel.BackColor, exportMapForm.ExportDirectory,
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

                string imgPath = mapExportDir + "/MapImg.jpg";
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

                    ExportImage(gameMapExportDir + "/MapImg.jpg", -1, -1, true, editorConfig.AtlasImagesRes);
                    ExportCellImages(gameMapExportDir + string.Format("/{0}.jpg", cellImgName));
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

        private void chooseForegroundBtn_Click(object sender, EventArgs e)
        {
            if (currentProject == null)
                return;

            openFileDialog.Filter = "png files (*.png)|*.png";
            openFileDialog.InitialDirectory = GlobalSettings.Instance.BaseDir + foregroundTilesDir.Replace("./", "");
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string imgName = foregroundTilesDir;// + "/" + currentProject.SeamlessWorldId;

                if (foregroundBrush != null)
                    foregroundBrush.Dispose();
                if (foreground != null)
                    foreground.Dispose();

                File.Copy(openFileDialog.FileName, imgName, true);
                SetForegroundImage(openFileDialog.FileName);
                currentProject.showForeground = true;
                currentProject.foregroundImgPath = imgName;
                showForegroundChckBox.Checked = true;
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

            if (invalidCount > 0)
            {
                MessageBox.Show($"Found and removed {invalidCount} invalid paths!", "Invalid Paths Culled", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Did not find any invalid paths to cull!", "No Invalid Paths", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void mapPanel_MouseWheel(object sender, MouseEventArgs e)
        {
            Point mouseLocation = e.Location;
            PointF desiredMouseLocation = e.Location;

            //// Test code msgbox for proper entry into event.
            ///int mytestscroll = 1;
            ///string Str_mytestscroll = mytestscroll.ToString();
           /// MessageBox.Show("The value scroll = " + Str_mytestscroll);



            float desiredHScroll = mapHScrollBar.Value;
            float desiredVScroll = mapVScrollBar.Value;


            //// This if statement has been altered from the original e.Delta value check to use the global public variable mytestscroll.
            if (mytestscroll > 0)
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
