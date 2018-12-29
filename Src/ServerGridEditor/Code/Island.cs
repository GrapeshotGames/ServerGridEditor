using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.ComponentModel;
using Newtonsoft.Json;
using AtlasGridDataLibrary;

namespace ServerGridEditor
{
    public class Island
    {
        public string name;
        public float x, y;
        public string imagePath;
        [DefaultValue(-1)]
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Populate)]
        public int landscapeMaterialOverride;
        public List<string> sublevelNames;
        public Dictionary<string, string> spawnerOverrides = new Dictionary<string, string>();
        public List<string> extraSublevels;
        [DefaultValue(-1.0f)]
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Populate)]
        public float minTreasureQuality;
        [DefaultValue(-1.0f)]
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Populate)]
        public float maxTreasureQuality;
        [DefaultValue(false)]
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Populate)]
        public bool useNpcVolumesForTreasures = false;
        [DefaultValue(true)]
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Populate)]
        public bool useLevelBoundsForTreasures = true;
        [DefaultValue(false)]
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Populate)]
        public bool prioritizeVolumesForTreasures = false;
        [DefaultValue("")]
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Populate)]
        public string islandTreasureBottleSupplyCrateOverrides = "";

        Image cachedImg = null;
        Image cachedOptimizedImg = null;

        public Image GetImage(bool optimized = false)
        {
            if (cachedImg == null)
            {
                if (File.Exists(imagePath))
                    cachedImg = Image.FromFile(imagePath);
                else
                {
                    MessageBox.Show("Could not find image (Setting to blank image):" + imagePath, "Missing Image Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Bitmap bmp = new Bitmap(78, 78);
                    cachedImg = Image.FromHbitmap(bmp.GetHbitmap());
                }
            }

            if(optimized)
            {
                if (cachedOptimizedImg == null)
                {
                    if (File.Exists(imagePath))
                    {
                        cachedOptimizedImg = Image.FromFile(imagePath);
                        Bitmap bmp = new Bitmap(cachedOptimizedImg, cachedOptimizedImg.Width / 16, cachedOptimizedImg.Height / 16);
                        cachedOptimizedImg = (Image)bmp;
                    }
                }

                if (cachedOptimizedImg != null)
                    return cachedOptimizedImg;
            }

            return cachedImg;
        }

        public void InvalidateImage()
        {
            if (cachedImg != null)
                cachedImg.Dispose();
            cachedImg = null;
            if (cachedOptimizedImg != null)
                cachedOptimizedImg.Dispose();
            cachedOptimizedImg = null;
        }

        public Island(string name, float x, float y, string imagePath, int landscapeMaterialOverride
            , List<string> sublevelNames, Dictionary<string, string> spawnerOverrides, float minTreasureQuality, float maxTreasureQuality, bool useNpcVolumesForTreasures,
            bool useLevelBoundsForTreasures, bool prioritizeVolumesForTreasures, string IslandTreasureBottleSupplyCrateOverrides, List<string> extraSublevels)
        {
            this.name = name;
            this.x = x;
            this.y = y;
            this.imagePath = imagePath;
            this.landscapeMaterialOverride = landscapeMaterialOverride;
            this.sublevelNames = sublevelNames;
            this.spawnerOverrides = spawnerOverrides;
            this.minTreasureQuality = minTreasureQuality;
            this.maxTreasureQuality = maxTreasureQuality;
            this.useNpcVolumesForTreasures = useNpcVolumesForTreasures;
            this.useLevelBoundsForTreasures = useLevelBoundsForTreasures;
            this.prioritizeVolumesForTreasures = prioritizeVolumesForTreasures;
            this.islandTreasureBottleSupplyCrateOverrides = IslandTreasureBottleSupplyCrateOverrides;
            this.extraSublevels = extraSublevels;
        }
    }


    public static class IslandInstanceEx
    {
        public static IslandInstanceData SetFrom(this IslandInstanceData Data, string name, float worldX, float worldY, float rotation, int id)
        {
            Data.name = name;
            Data.worldX = worldX;
            Data.worldY = worldY;
            Data.rotation = rotation;
            Data.id = id;
            Data.spawnerOverrides = new Dictionary<string, string>();

            Data.minTreasureQuality = Data.maxTreasureQuality = -1;
            Data.spawnPointRegionOverride = -1;
            Data.finalNPCLevelMultiplier = 1.0f;
            Data.instanceTreasureQualityMultiplier = 1.0f;
            Data.instanceTreasureQualityAddition = 0.0f;
            Data.finalNPCLevelOffset = 0;
            Data.IslandInstanceCustomDatas1 = "";
            Data.IslandInstanceCustomDatas2 = "";
            Data.IslandInstanceClientCustomDatas1 = "";
            Data.IslandInstanceClientCustomDatas2 = "";

            return Data;
        }

        public static Island GetReferencedIsland(this IslandInstanceData Data, IDictionary<string, Island> islands)
        {
            if (!islands.ContainsKey(Data.name))
                return null;
            return islands[Data.name];
        }

        public static Rectangle GetRect(this IslandInstanceData Data, Project currentProject, IDictionary<string, Island> islands)
        {
            if (currentProject == null)
                return new Rectangle();

            Island referencedIsland = Data.GetReferencedIsland(islands);

            float relativeX = referencedIsland.x * currentProject.coordsScaling;
            float relativeY = referencedIsland.y * currentProject.coordsScaling;

            return new Rectangle((int)Math.Round(Data.worldX * currentProject.coordsScaling - relativeX / 2f), (int)Math.Round(Data.worldY * currentProject.coordsScaling - relativeY / 2f), (int)Math.Round(relativeX), (int)Math.Round(relativeY));
        }

        public static bool ContainsPoint(this IslandInstanceData Data, Point p, MainForm mainForm)
        {
            Rectangle Rect = Data.GetRect(mainForm.currentProject, mainForm.islands);

            PointF rotatedP = StaticHelpers.RotatePointAround(p, new PointF(Rect.Left + Rect.Width / 2.0f, Rect.Top + Rect.Height / 2.0f), -Data.rotation);
            p.X = (int)rotatedP.X;
            p.Y = (int)rotatedP.Y;

            return Rect.Contains(p);
        }

        //Removes overrides with the same value as template
        public static void SyncOverridesWithTemplates(this IslandInstanceData Data, MainForm mainForm)
        {
            Island referencedIsland = Data.GetReferencedIsland(mainForm.islands);

            if (referencedIsland.spawnerOverrides == null)
                return;

            List<string> keysToRemove = new List<string>();
            foreach (KeyValuePair<string, string> templateSpawnerOverride in referencedIsland.spawnerOverrides)
            {
                if (Data.spawnerOverrides.ContainsKey(templateSpawnerOverride.Key) && Data.spawnerOverrides[templateSpawnerOverride.Key] == templateSpawnerOverride.Value)
                {
                    keysToRemove.Add(templateSpawnerOverride.Key);
                }
            }

            foreach (string keyToRemove in keysToRemove)
            {
                Data.spawnerOverrides.Remove(keyToRemove);
            }
        }
    }
}