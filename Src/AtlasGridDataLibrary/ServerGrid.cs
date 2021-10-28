using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtlasGridDataLibrary
{
    public static class AtlasDataGridLoader
    {
        private static string GetBaseDir()
        {
            return Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location) + "//";//GetExecutingAssembly().Location) + "//";
        }

        public static AtlasGridData Load()
        {
            return LoadAbsolutePath(GetBaseDir() + "ServerGrid.json");
        }
        public static AtlasGridData Load(string RelativePath)
        {
            return LoadAbsolutePath(GetBaseDir() + RelativePath);
        }
        public static AtlasGridData LoadAbsolutePath(string Path)
        {
            AtlasGridData LoadedConfig = new AtlasGridData(); //Default Object or null?
            string JsonString = File.ReadAllText(Path);
            LoadedConfig = JsonConvert.DeserializeObject<AtlasGridData>(JsonString);
            return LoadedConfig;
        }

        public static void Save(AtlasGridData config)
        {
            SaveAbsolutePath(config, GetBaseDir() + "ServerGrid.json");
        }
        public static void Save(AtlasGridData config, string RelativePath)
        {
            SaveAbsolutePath(config, GetBaseDir() + RelativePath);
        }
        public static void SaveAbsolutePath(AtlasGridData config, string Path)
        {
            string JsonData = JsonConvert.SerializeObject(config, Formatting.Indented, new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore
            });
            File.WriteAllText(Path, JsonData);
        }
    }


    public class AtlasGridData
    {
        [DeploymentOverrideAttribute]
        public string BaseServerArgs = "";
        public float gridSize;
        [DeploymentOverrideAttribute]
        public string MetaWorldURL = "";
        [DeploymentOverrideAttribute]
        public string MapImagesExtension = "";
        [DeploymentOverrideAttribute]
        public string WorldFriendlyName = "";
        [DeploymentOverrideAttribute]
        public string MainRegionName = "";
        [DeploymentOverrideAttribute]
        public string WorldAtlasId = "";
        public string AuthListURL = "";
        public string WorldAtlasPassword = "";
        [DeploymentOverrideAttribute]
        public string ModIDs = "";
        [DeploymentOverrideAttribute]
        public string MapImageURL = "";

        [DeploymentOverrideAttribute]
        public string OverAllMapImageURL = "";

        public int totalGridsX = 0;
        public int totalGridsY = 0;

        public bool bUseUTCTime = false;
        public bool usePVEServerConfiguration = false;
        public float columnUTCOffset = 0.0f;
        public string Day0 = "";
        public float globalTransitionMinZ = 0.0f;
        public string AdditionalCmdLineParams;
        public Dictionary<string, string> OverrideShooterGameModeDefaultGameIni = new Dictionary<string, string>();
        public string LocalS3URL = null;
        public string LocalS3AccessKeyId = "";
        public string LocalS3SecretKey = "";
        public string LocalS3BucketName = "";
        public string LocalS3Region = "";

        public string globalGameplaySetup = "";
        public int numPathingGridRows = 10;
        public int numPathingGridColumns = 10;

        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Populate)]
        public TribeLogConfigInfo TribeLogConfig = new TribeLogConfigInfo();

        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Populate)]
        public SharedLogConfigInfo SharedLogConfig = new SharedLogConfigInfo();

        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Populate)]
        public BackupConfigInfo TravelDataConfig = new BackupConfigInfo();

        public List<DatabaseConnectionInfo> DatabaseConnections = new List<DatabaseConnectionInfo>();

        [DefaultValue(0.01f)]
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Populate, NullValueHandling = NullValueHandling.Include)]
        public float coordsScaling = 0.01f;

        [DefaultValue(true)]
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Populate, NullValueHandling = NullValueHandling.Include)]
        public bool showServerInfo = true;

        [DefaultValue(true)]
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Populate, NullValueHandling = NullValueHandling.Include)]
        public bool showDiscoZoneInfo = true;

        [DefaultValue(true)]
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Populate, NullValueHandling = NullValueHandling.Include)]
        public bool showShipPathsInfo = true;

        [DefaultValue(true)]
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Populate, NullValueHandling = NullValueHandling.Include)]
        public bool showTradeWindsInfo = true;

        [DefaultValue(true)]
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Populate, NullValueHandling = NullValueHandling.Include)]
        public bool showPortalNodes = true;

        [DefaultValue(true)]
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Populate, NullValueHandling = NullValueHandling.Include)]
        public bool showIslandNames = true;

        [DefaultValue(true)]
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
        public bool showLines = true;

        [DefaultValue(false)]
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
        public bool alphaBackground = false;

        [DefaultValue(false)]
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
        public bool showBackground = false;

        [DefaultValue(false)]
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
        public bool showForeground = false;

        [DefaultValue(false)]
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
        public bool showTradeWindOverlay = false;

        public Dictionary<string, string> regionsBackgroundImgPath = new Dictionary<string, string>();

        public string foregroundImgPath = null;
        public string tradeWindOverlayImgPath = null;
        public Dictionary<string, string> regionsTradeWindOverlayImgPath = new Dictionary<string, string>();

        [DefaultValue("Resources/discoZoneBox.png")]
        public string discoZonesImagePath = null;

        [DeploymentConstAttribute]
        public List<ServerData> servers = new List<ServerData>();
        // public List<ServerSerializationObject> originalServers = new List<ServerSerializationObject>();

        public List<SpawnerInfoData> spawnerOverrideTemplates = new List<SpawnerInfoData>();

        [DefaultValue(0)]
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Populate)]
        public int idGenerator;

        [DefaultValue(0)]
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Populate)]
        public int regionsIdGenerator;

        [DefaultValue(0)]
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Populate)]
        public int shipPathsIdGenerator;

        [DefaultValue(0)]
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Populate)]
        public int PortalPathsIdGenerator;

        [DefaultValue(0)]
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Populate)]
        public int tradeWindsIdGenerator;

        public List<ShipPathData> shipPaths = new List<ShipPathData>();
        public List<TradeWindData> tradeWinds = new List<TradeWindData>();

        public List<PortalPathData> portalPaths = new List<PortalPathData>();
        
        public DateTime lastImageOverride;

        public List<ServerTemplateData> serverTemplates = new List<ServerTemplateData>();
        public List<ServerConfiguration> serverConfigurations = new List<ServerConfiguration>();
        public List<TransientNodeTemplate> transientNodeTemplates = new List<TransientNodeTemplate>();
        public List<FoliageAttachmentOverride> foliageAttachmentOverrides = new List<FoliageAttachmentOverride>();
        public List<RegionsCategory> regionsCategories = new List<RegionsCategory>();
    }

    // ==== SERVER INFO ===========================================
    public class ServerData
    {
        [DeploymentConstAttribute]
        public int gridX = 0;
        [DeploymentConstAttribute]
        public int gridY = 0;
        [DeploymentOverrideAttribute]
        public string MachineIdTag = "";
        [DeploymentOverrideAttribute]
        public string ip = "127.0.0.1";
        public string name = "Unnamed Server";
        [DeploymentOverrideAttribute]
        public int port = 50000;
        [DeploymentOverrideAttribute]
        public int gamePort = 6666;
        [DefaultValue(27000)]
        [DeploymentOverrideAttribute]
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Populate)]
        public int seamlessDataPort = 27000;
        public bool isHomeServer = false;
        public string hiddenAtlasId = "";
        public int forceServerRules = 0;
        public string AdditionalCmdLineParams = "";
        public Dictionary<string, string> OverrideShooterGameModeDefaultGameIni = new Dictionary<string, string>();
        public int floorZDist = 0;
        public int utcOffset = 0;
        public int transitionMinZ = 0;
        public string GlobalBiomeSeamlessServerGridPreOffsetValues = "";
        public string GlobalBiomeSeamlessServerGridPreOffsetValuesOceanWater = "";
        public string OceanDinoDepthEntriesOverride = "";
        [DefaultValue("")]
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string OceanEpicSpawnEntriesOverrideValues = "";
        public string oceanFloatsamCratesOverride = "";
        public string treasureMapLootTablesOverride = "";
        public string oceanEpicSpawnEntriesOverrideTemplateName = "";
        public string NPCShipSpawnEntriesOverrideTemplateName = "";
        public string regionOverrides = "";
        public float waterColorR = 0;
        public float waterColorG = 0;
        public float waterColorB = 0;

        public float billboardsOffsetX = 0;
        public float billboardsOffsetY = 0;
        public float billboardsOffsetZ = 0;

        public int skyStyleIndex = 0;
        [DefaultValue(1.0f)]
        public float serverIslandPointsMultiplier = 1.0f;
        [DefaultValue("")]
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string ServerCustomDatas1 = "";
        [DefaultValue("")]
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string ServerCustomDatas2 = "";
        [DefaultValue("")]
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string ClientCustomDatas1 = "";
        [DefaultValue("")]
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string ClientCustomDatas2 = "";
        public List<SublevelSerializationObject> sublevels = new List<SublevelSerializationObject>();
        public DateTime lastModified;
        public DateTime lastImageOverride;
        public bool islandLocked = false;
        public bool discoLocked = false;
        public bool pathsLocked = false;
        public bool windsLocked = false;
        public List<string> extraSublevels = new List<string>();
        public List<string> totalExtraSublevels = new List<string>();

        //[DefaultValue(null)]
        //[JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore)]
        public List<IslandInstanceData> islandInstances = new List<IslandInstanceData>();
        public List<DiscoveryZoneData> discoZones = new List<DiscoveryZoneData>();
        public List<SpawnRegionData> spawnRegions = new List<SpawnRegionData>();

        [DefaultValue("")]
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string serverTemplateName = "";

        public string serverConfigurationKeyPVP = "";
        public string serverConfigurationKeyPVE = "";

        public int[] ServerPathingGrid = new int[1];

        public string BackgroundImgPath = "";

        public string GetGridLocationHumanReadable()
        {
            const string letters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            var Column = "";
            if (gridX >= letters.Length)
                Column += letters[gridX / letters.Length - 1];
            Column += letters[gridX % letters.Length];
            return Column + (gridY + 1);
        }
    }
    public class ServerTemplateData : ServerData
    {
        public float templateColorR = 0;
        public float templateColorG = 0;
        public float templateColorB = 0;

    }

    public class RegionsCategory
    {
        public string CategoryName;
        public List<string> Regions = new List<string>();
    }

    public class ServerConfiguration
    {
        public string ParentName;
        public string Key;
        public Dictionary<string, string> GameVariable = new Dictionary<string, string>();
    }

    public class TransientNodeTemplate
    {
        public string Key;
        public Dictionary<string, double> NodeKeyWeights;
    }

    public class FoliageAttachmentOverride
    {
        public string Key;
        public Dictionary<string, string> FoliageMap = new Dictionary<string, string>();
    }

    public class SublevelSerializationObject
    {
        public string name = "";
        public float additionalTranslationX = 0;
        public float additionalTranslationY = 0;
        public float additionalTranslationZ = 0;
        public float additionalRotationPitch = 0;
        public float additionalRotationYaw = 0;
        public float additionalRotationRoll = 0;
        public int id = 0;
        public int landscapeMaterialOverride = -1;
    }

    public abstract class MoveableObjectData
    {
        public float worldX, worldY;
        public float rotation;
    }
    public class IslandInstanceData : MoveableObjectData
    {
        public string name;
        public int id;
        public Dictionary<string, string> spawnerOverrides = new Dictionary<string, string>();
        public List<string> harvestOverrideKeys = new List<string>(); //Dictionary<string, string> harvestOverrides = new Dictionary<string, string>();
        public List<string> harvestOverrideKeysTemplateInherited = new List<string>(); //Dictionary<string, string> harvestOverrides = new Dictionary<string, string>();

        public List<string> treasureMapSpawnPoints = new List<string>();
        public List<string> wildPirateCampSpawnPoints = new List<string>();
        public float minTreasureQuality = -1;
        public float maxTreasureQuality = -1;
        public bool useNpcVolumesForTreasures = false;
        public bool useLevelBoundsForTreasures = true;
        public bool prioritizeVolumesForTreasures = false;
        public bool isControlPoint = false;
        public bool isControlPointAllowCapture = true;
        public int islandPoints = 1;
        public string islandTreasureBottleSupplyCrateOverrides = "";
        public string landNodeKey = "";
        [DefaultValue(-1)]
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public int spawnPointRegionOverride = -1;
        [DefaultValue(1.0f)]
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public float finalNPCLevelMultiplier = 1.0f;
        [DefaultValue(0)]
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public int finalNPCLevelOffset = 0;
        [DefaultValue(1.0f)]
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public float instanceTreasureQualityMultiplier = 1.0f;
        [DefaultValue(0.0f)]
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public float instanceTreasureQualityAddition = 0.0f;
        [DefaultValue("")]
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string IslandInstanceCustomDatas1 = "";
        [DefaultValue("")]
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string IslandInstanceCustomDatas2 = "";
        [DefaultValue("")]
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string IslandInstanceClientCustomDatas1 = "";
        [DefaultValue("")]
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string IslandInstanceClientCustomDatas2 = "";

        public float islandWidth;
        public float islandHeight;

        public float singleSpawnPointX;
        public float singleSpawnPointY;
        public float singleSpawnPointZ;
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore)]
        public float maxIslandClaimFlagZ;

    }
    public class DiscoveryZoneData : MoveableObjectData
    {
        public string name;
        [NonSerialized]
        public float startWorldX;
        [NonSerialized]
        public float startWorldY;
        public float sizeX, sizeY, sizeZ;
        public int id;
        public float xp;
        public bool bIsManuallyPlaced = false;
        [DefaultValue("")]
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string ManualVolumeName = "";
        public int explorerNoteIndex;
        public bool allowSea;
    }
    public class SpawnRegionData
    {
        public string name { get; set; }
        [NonSerialized]
        public int X;
        [NonSerialized]
        public int Y;
    }


    // ==== MISC INFO ===========================================

    public class SpawnerInfoData
    {
        public string Name { get; set; }
        public string NPCSpawnEntries { get; set; }
        public string NPCSpawnLimits { get; set; }
        public float MaxDesiredNumEnemiesMultiplier { get; set; }
    }

    public abstract class SplinePathData
    {
        public int PathId;
        public bool isLooping = false;
        public string PathName = "";
    }

    public class ShipPathData : SplinePathData
    {
        public List<ShipPathNode> Nodes = new List<ShipPathNode>();
        public string AutoSpawnShipClass = "";
        public int AutoSpawnEveryUTCInterval = 0;

        [DefaultValue(true)]
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Populate, NullValueHandling = NullValueHandling.Include)]
        public bool autoSpawn = true;
    }

    public class TradeWindData : SplinePathData
    {
        public List<TradeWindNode> Nodes = new List<TradeWindNode>();
        public bool reverseDir = false;
        public bool isLoopingAroundWorld = false;
        public float StartInterpolatingOceanColorAtPercentage = 0.25f; //0.875f;
    }

    public enum PortalType
    {
        Perpetual,
        PlayerActivated,
        CentralBarmuda,
        NPC
    }

    public class PortalPathData : SplinePathData
    {
        public PortalType PathPortalType;
        public PortalPathData(PortalType pathPortalType)
        { PathPortalType = pathPortalType; }
        public List<PortalPathNode> Nodes = new List<PortalPathNode>();
    }

    public class BezierNodeData : MoveableObjectData
    {
        public float controlPointsDistance;
        public virtual SplinePathData GetSplinePath() { return null; }
    }

    public class ShipPathNode : BezierNodeData
    {
        [JsonIgnore]
        public ShipPathData shipPath;

        public override SplinePathData GetSplinePath()
        {
            return shipPath;
        }
    }

    public class TradeWindNode : BezierNodeData
    {
        [JsonIgnore]
        public TradeWindData tradeWind;
        public float width = 1000;
        public float strength = 1;

        public override SplinePathData GetSplinePath()
        {
            return tradeWind;
        }
    }

    public class PortalPathNode : MoveableObjectData
    {
        [JsonIgnore]
        public PortalPathData portalPathData;

        public string PortalName;

        public Dictionary<string, int> RequiredResource = new Dictionary<string, int>();
    }
}
