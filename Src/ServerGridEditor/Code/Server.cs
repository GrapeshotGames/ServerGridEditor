using AtlasGridDataLibrary;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerGridEditor
{
    public class Server
    {
        public string name = "";
        public string MachineIdTag = "";
        public string ip = "";
        public int port;
        public int gamePort;
        public int seamlessDataPort = 27000;
        public int gridX;
        public int gridY;
        public bool isHomeServer;
        public bool isMawWatersServer;
        public string mawWaterDayTime;
        public string hiddenAtlasId = "";
        public int forceServerRules;
        public string AdditionalCmdLineParams;
        public Dictionary<string, string> OverrideShooterGameModeDefaultGameIni = new Dictionary<string, string>();
        public int floorZDist;
        public int transitionMinZ;
        public int utcOffset;
        public string GlobalBiomeSeamlessServerGridPreOffsetValues = "";
        public string GlobalBiomeSeamlessServerGridPreOffsetValuesOceanWater = "";
        public string OceanDinoDepthEntriesOverride = "";
        public string OceanEpicSpawnEntriesOverrideValues = "";
        public string oceanFloatsamCratesOverride = "";
        public string treasureMapLootTablesOverride = "";
        public string oceanEpicSpawnEntriesOverrideTemplateName = "";
        public string NPCShipSpawnEntriesOverrideTemplateName = "";
        public string regionOverrides = "";
        public float waterColorR;
        public float waterColorG;
        public float waterColorB;
        public float billboardsOffsetX = 0;
        public float billboardsOffsetY = 0;
        public float billboardsOffsetZ = 0;

        public int OverrideDestNorthX = -1;
        public int OverrideDestNorthY = -1;
        public int OverrideDestSouthX = -1;
        public int OverrideDestSouthY = -1;
        public int OverrideDestEastX = -1;
        public int OverrideDestEastY = -1;
        public int OverrideDestWestX = -1;
        public int OverrideDestWestY = -1;

        public int MaxPlayingSeconds = 0;
        public int MaxPlayingSecondsKickToServerX = -1;
        public int MaxPlayingSecondsKickToServerY = -1;
        
        public int skyStyleIndex;
        public float serverIslandPointsMultiplier = 1.0f;
        public string ServerCustomDatas1 = "";
        public string ServerCustomDatas2 = "";
        public string ClientCustomDatas1 = "";
        public string ClientCustomDatas2 = "";

        public DateTime lastModifiedUTC;
        public DateTime lastImageOverrideUTC;
        public bool islandLocked = false;
        public bool discoLocked = false;
        public bool pathsLocked = false;
        public bool windsLocked = false;
        public List<string> extraSublevels;

        public string serverTemplateName = "";
        public string serverConfigurationKeyPVP = "";
        public string serverConfigurationKeyPVE = "";
        public int[] ServerPathingGrid = new int[1];

        public string RegisteredAtSpoolGroup = "";
        public string RegisteredAtClusterSet = "";


        public string BackgroundImgPath = "";

        public Server() { }

        public Server(int gridX, int gridY)
        {
            this.gridX = gridX;
            this.gridY = gridY;
        }

        public bool IsWorldPointInServer(PointF point, float gridSize)
        {
            return GetWorldRect(gridSize).Contains(point);
        }

        public PointF GetLocalLocation(PointF point, float gridSize)
        {
            return new PointF(point.X - gridX * gridSize, point.Y - gridY * gridSize);
        }

        public PointF TranslateLocalToGlobal(PointF point, float gridSize)
        {
            return new PointF(point.X + gridX * gridSize, point.Y + gridY * gridSize);
        }

        public RectangleF GetWorldRect(float gridSize)
        {
            return new RectangleF(new PointF(gridX * gridSize, gridY * gridSize), new SizeF(gridSize, gridSize));
        }

        /// <summary>
        /// Transforms a world point to a local server point relative to its center
        /// </summary>
        public PointF WorldToRelativePoint(float gridSize, PointF worldPoint)
        {
            PointF ServerWorldCenter = new PointF(gridX * gridSize + gridSize / 2, gridY * gridSize + gridSize / 2);
            return new PointF(worldPoint.X - ServerWorldCenter.X, worldPoint.Y - ServerWorldCenter.Y);
        }

        /// <summary>
        /// Transforms a relative point to a meta world point
        /// </summary>
        public PointF RelativeToWorldPoint(float gridSize, PointF relativePoint)
        {
            PointF ServerWorldCenter = new PointF(gridX * gridSize + gridSize / 2, gridY * gridSize + gridSize / 2);
            return new PointF(relativePoint.X + ServerWorldCenter.X, relativePoint.Y + ServerWorldCenter.Y);
        }

        public void LaunchPreview(out ProcessStartInfo serverStartInfo, out ProcessStartInfo clientStartInfo, bool runClient = true, bool clearSaveData = false, bool skipCloud = true, int serverNum = 1)
        {
            using (Process startRedisBatch = new Process())
            {
                startRedisBatch.StartInfo = new ProcessStartInfo() {
                    FileName = Path.GetFullPath(MainForm.rootDir + "/AtlasTools/RedisDatabase/redis-server_start.bat"),
                    WorkingDirectory = Path.GetFullPath(MainForm.rootDir + "/AtlasTools/RedisDatabase"),
                    UseShellExecute = true,
                    CreateNoWindow = true,
                };
                startRedisBatch.Start();
            }
            string serverArgs = string.Format(skipCloud ? MainForm.serverArgs : MainForm.serverArgsWithAws, gridX, gridY, serverNum);
            if (clearSaveData)
                serverArgs += MainForm.clearSaveDataArg;
			
			serverArgs += " -SeamlessLocalHost";
            
            serverStartInfo = new ProcessStartInfo(Path.GetFullPath(MainForm.engineExe), serverArgs);

            clientStartInfo = runClient ? new ProcessStartInfo(Path.GetFullPath(MainForm.engineExe), string.Format(MainForm.clientArgs, "127.0.0.1", gamePort) + " -SeamlessLocalHost") : null;

            if (runClient)
            {
                clientStartInfo.UseShellExecute = true;
                clientStartInfo.CreateNoWindow = true;
                clientStartInfo.WorkingDirectory = MainForm.rootDir;

                using (Process clientProcess = new Process())
                {
                    clientProcess.StartInfo = clientStartInfo;
                    clientProcess.Start();
                }
            }

            serverStartInfo.UseShellExecute = true;
            serverStartInfo.CreateNoWindow = true;
            serverStartInfo.WorkingDirectory = MainForm.rootDir;

            using (Process serverProcess = new Process())
            {
                serverProcess.StartInfo = serverStartInfo;
                serverProcess.Start();
            }

        }

        public void SetDirty()
        {
            lastModifiedUTC = DateTime.UtcNow;
        }

        public override bool Equals(object obj)
        {
            Server server = obj as Server;
            if(server != null)
                return gridX == server.gridX && gridY == server.gridY;
            return false;
        }
    }

    public static class ServerTemplateDataEx
    {
        public static Color GetTemplateColor(this ServerTemplateData Data)
        {
            return Color.FromArgb((int)(255 * Data.templateColorR), (int)(255 * Data.templateColorG), (int)(255 * Data.templateColorB));
        }
    }
}
