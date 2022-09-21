using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;
using System.IO;
using AtlasGridDataLibrary;

namespace ServerGridEditor
{
    class ConfigKeyValueEntry
    {
        public ConfigKeyValueEntry(string InKey, string InValue)
        {
            Key = InKey;
            Value = InValue;
        }
        public string Key { get; set; }
        public string Value { get; set; }
    }

    public static class ServerSerializationObjectEx
    {
        public static ServerData SetFrom(this ServerData Data, Server server, float gridSize, int gridX, int gridY, string MachineIdTag, string ip, int port,
            int gamePort, int seamlessDataPort, List<SublevelSerializationObject> sublevels, List<IslandInstanceData> islandInstances, List<DiscoveryZoneData> discoZones, List<SpawnRegionData> spawnRegions,
            bool isHomeServer, bool isMawWatersServer, string mawWaterDayTime, string hiddenAtlasId, int forceServerRules, string AdditionalCmdLineParams, Dictionary<string, string> OverrideShooterGameModeDefaultGameIni, string RegisteredAtSpoolGroup, string RegisteredAtClusterSet, string name, int floorZDist, int transitionMinZ, int utcOffset, string OceanDinoDepthEntriesOverride,
            string OceanFloatsamCratesOverride, string TreasureMapLootTablesOverride, DateTime lastModified, DateTime lastImageOverride, string GlobalBiomeSeamlessServerGridPreOffsetValues, string GlobalBiomeSeamlessServerGridPreOffsetValuesOceanWater,
            bool islandLocked, bool discoLocked, bool pathsLocked, bool windsLocked, List<string> extraSublevels, string oceanEpicSpawnEntriesOverrideTemplateName, string NPCShipSpawnEntriesOverrideTemplateName, string regionOverrides,
            float waterColorR, float waterColorG, float waterColorB, float billboardsOffsetX, float billboardsOffsetY, float billboardsOffsetZ,
            int overrideDestNorthX, int overrideDestNorthY, int overrideDestSouthX, int overrideDestSouthY, int overrideDestEastX, int overrideDestEastY, int overrideDestWestX, int overrideDestWestY,
            int maxPlayingSeconds,
            int maxPlayingSecondsKickToServerX, int maxPlayingSecondsKickToServerY,
            int skyStyleIndex, float serverIslandPointsMultiplier, string ServerCustomDatas1, string ServerCustomDatas2, string ClientCustomDatas1, string ClientCustomDatas2, string serverTemplateName, string serverConfigurationKeyPVE, string serverConfigurationKeyPVP, string OceanEpicSpawnEntriesOverrideValues, int[] ServerPathingGrid, string BackgroundImgPath)
        {
                    

        Data.gridX = gridX;
            Data.gridY = gridY;
            Data.MachineIdTag = MachineIdTag;
            Data.ip = ip;
            Data.port = port;
            Data.gamePort = gamePort;
            Data.seamlessDataPort = seamlessDataPort;
            Data.sublevels = sublevels;
            Data.islandInstances = islandInstances == null ? new List<IslandInstanceData>() : islandInstances;
            Data.isHomeServer = isHomeServer;
            Data.isMawWatersServer = isMawWatersServer;
            Data.mawWaterDayTime = mawWaterDayTime;
            Data.hiddenAtlasId = hiddenAtlasId;
            Data.forceServerRules = forceServerRules;
            Data.AdditionalCmdLineParams = AdditionalCmdLineParams;
            Data.OverrideShooterGameModeDefaultGameIni = OverrideShooterGameModeDefaultGameIni;
            Data.RegisteredAtSpoolGroup = RegisteredAtSpoolGroup;
            Data.RegisteredAtClusterSet = RegisteredAtClusterSet;
            Data.floorZDist = floorZDist;
            Data.transitionMinZ = transitionMinZ;
            Data.utcOffset = utcOffset;
            Data.OceanDinoDepthEntriesOverride = OceanDinoDepthEntriesOverride;
            Data.OceanEpicSpawnEntriesOverrideValues = OceanEpicSpawnEntriesOverrideValues;
            Data.oceanEpicSpawnEntriesOverrideTemplateName = oceanEpicSpawnEntriesOverrideTemplateName;
            Data.NPCShipSpawnEntriesOverrideTemplateName = NPCShipSpawnEntriesOverrideTemplateName;
            Data.regionOverrides = regionOverrides;
            Data.waterColorR = waterColorR;
            Data.waterColorG = waterColorG;
            Data.waterColorB = waterColorB;
            Data.billboardsOffsetX = billboardsOffsetX;
            Data.billboardsOffsetY = billboardsOffsetY;
            Data.billboardsOffsetZ = billboardsOffsetZ;
            Data.OverrideDestNorthX = overrideDestNorthX;
            Data.OverrideDestNorthY = overrideDestNorthY;
            Data.OverrideDestSouthX = overrideDestSouthX;
            Data.OverrideDestSouthY = overrideDestSouthY;
            Data.OverrideDestEastX = overrideDestEastX;
            Data.OverrideDestEastY = overrideDestEastY;
            Data.OverrideDestWestX = overrideDestWestX;
            Data.OverrideDestWestY = overrideDestWestY;
            Data.MaxPlayingSeconds = maxPlayingSeconds;
            Data.MaxPlayingSecondsKickToServerX = maxPlayingSecondsKickToServerX;
            Data.MaxPlayingSecondsKickToServerY = maxPlayingSecondsKickToServerY;
            Data.skyStyleIndex = skyStyleIndex;
            Data.serverIslandPointsMultiplier = serverIslandPointsMultiplier;
            Data.ServerCustomDatas1 = ServerCustomDatas1;
            Data.ServerCustomDatas2 = ServerCustomDatas2;
            Data.ClientCustomDatas1 = ClientCustomDatas1;
            Data.ClientCustomDatas2 = ClientCustomDatas2;
            Data.oceanFloatsamCratesOverride = OceanFloatsamCratesOverride;
            Data.treasureMapLootTablesOverride = TreasureMapLootTablesOverride;
            Data.lastModified = lastModified;
            Data.lastImageOverride = lastImageOverride;
            Data.GlobalBiomeSeamlessServerGridPreOffsetValues = GlobalBiomeSeamlessServerGridPreOffsetValues;
            Data.GlobalBiomeSeamlessServerGridPreOffsetValuesOceanWater = GlobalBiomeSeamlessServerGridPreOffsetValuesOceanWater;
            if (name != null)
                Data.name = name;
            Data.discoZones = discoZones == null ? new List<DiscoveryZoneData>() : discoZones;
            Data.islandLocked = islandLocked;
            Data.discoLocked = discoLocked;
            Data.pathsLocked = pathsLocked;
            Data.windsLocked = windsLocked;
            Data.spawnRegions = spawnRegions == null ? new List<SpawnRegionData>() : spawnRegions;
            Data.extraSublevels = extraSublevels;
            Data.serverTemplateName = serverTemplateName;
            Data.ServerPathingGrid = ServerPathingGrid;
            Data.serverConfigurationKeyPVE = serverConfigurationKeyPVE;
            Data.serverConfigurationKeyPVP = serverConfigurationKeyPVP;
            Data.BackgroundImgPath = BackgroundImgPath;
            return Data;
        }

        public static ServerData SetFrom(this ServerData Data, Server server, float gridSize, int gridX, int gridY, string MachineIdTag, string ip, int port, 
            int gamePort, int seamlessDataPort, List<IslandInstanceData> islandInstances, List<DiscoveryZoneData> discoZones, List<SpawnRegionData> spawnRegions, MainForm mainForm, 
            bool isHomeServer, bool isMawWatersServer, string mawWaterDayTime, string hiddenAtlasId, int forceServerRules, string AdditionalCmdLineParams, Dictionary<string, string> OverrideShooterGameModeDefaultGameIni, string RegisteredAtSpoolGroup, string RegisteredAtClusterSet, string name, int floorZDist, int transitionMinZ, int utcOffset, string OceanDinoDepthEntriesOverride, 
            string OceanFloatsamCratesOverride, string TreasureMapLootTablesOverride, DateTime lastModified, DateTime lastImageOverride, string GlobalBiomeSeamlessServerGridPreOffsetValues, string GlobalBiomeSeamlessServerGridPreOffsetValuesOceanWater,
            bool islandLocked, bool discoLocked, bool pathsLocked, bool windsLocked, List<string> extraSublevels, string oceanEpicSpawnEntriesOverrideTemplateName, string NPCShipSpawnEntriesOverrideTemplateName, string regionOverrides,
            float waterColorR, float waterColorG, float waterColorB, float billboardsOffsetX, float billboardsOffsetY, float billboardsOffsetZ,
            int overrideDestNorthX, int overrideDestNorthY, int overrideDestSouthX, int overrideDestSouthY, int overrideDestEastX, int overrideDestEastY, int overrideDestWestX, int overrideDestWestY,
            int maxPlayingSeconds,
            int maxPlayingSecondsKickToServerX, int maxPlayingSecondsKickToServerY,
            int skyStyleIndex, float serverIslandPointsMultiplier, string ServerCustomDatas1, string ServerCustomDatas2, string ClientCustomDatas1, string ClientCustomDatas2, string serverTemplateName, string serverConfigurationKeyPVP, string serverConfigurationKeyPVE, string OceanEpicSpawnEntriesOverrideValues, int[] ServerPathingGrid, string BackgroundImgPath)
        {
            Data.gridX = gridX;
            Data.gridY = gridY;
            Data.MachineIdTag = MachineIdTag;
            Data.ip = ip;
            Data.port = port;
            Data.gamePort = gamePort;
            Data.seamlessDataPort = seamlessDataPort;
            Data.islandInstances = islandInstances;
            Data.discoZones = discoZones;
            Data.spawnRegions = spawnRegions;
            Data.isHomeServer = isHomeServer;
            Data.isMawWatersServer = isMawWatersServer;
            Data.mawWaterDayTime = mawWaterDayTime;
            Data.hiddenAtlasId = hiddenAtlasId;
            Data.forceServerRules = forceServerRules;
            Data.AdditionalCmdLineParams = AdditionalCmdLineParams;
            Data.OverrideShooterGameModeDefaultGameIni = OverrideShooterGameModeDefaultGameIni;
            Data.RegisteredAtSpoolGroup = RegisteredAtSpoolGroup;
            Data.RegisteredAtClusterSet = RegisteredAtClusterSet;
            Data.name = name;
            Data.floorZDist = floorZDist;
            Data.transitionMinZ = transitionMinZ;
            Data.utcOffset = utcOffset;
            Data.OceanDinoDepthEntriesOverride = OceanDinoDepthEntriesOverride;
            Data.OceanEpicSpawnEntriesOverrideValues = OceanEpicSpawnEntriesOverrideValues;
            Data.oceanEpicSpawnEntriesOverrideTemplateName = oceanEpicSpawnEntriesOverrideTemplateName;
            Data.NPCShipSpawnEntriesOverrideTemplateName = NPCShipSpawnEntriesOverrideTemplateName;
            Data.regionOverrides = regionOverrides;
            Data.waterColorR = waterColorR;
            Data.waterColorG = waterColorG;
            Data.waterColorB = waterColorB;
            Data.billboardsOffsetX = billboardsOffsetX;
            Data.billboardsOffsetY = billboardsOffsetY;
            Data.billboardsOffsetZ = billboardsOffsetZ;
            Data.OverrideDestNorthX = overrideDestNorthX;
            Data.OverrideDestNorthY = overrideDestNorthY;
            Data.OverrideDestSouthX = overrideDestSouthX;
            Data.OverrideDestSouthY = overrideDestSouthY;
            Data.OverrideDestEastX = overrideDestEastX;
            Data.OverrideDestEastY = overrideDestEastY;
            Data.OverrideDestWestX = overrideDestWestX;
            Data.OverrideDestWestY = overrideDestWestY;
            Data.MaxPlayingSeconds = maxPlayingSeconds;
            Data.MaxPlayingSecondsKickToServerX = maxPlayingSecondsKickToServerX;
            Data.MaxPlayingSecondsKickToServerY = maxPlayingSecondsKickToServerY;
            Data.skyStyleIndex = skyStyleIndex;
            Data.serverIslandPointsMultiplier = serverIslandPointsMultiplier;
            Data.ServerCustomDatas1 = ServerCustomDatas1;
            Data.ServerCustomDatas2 = ServerCustomDatas2;
            Data.ClientCustomDatas1 = ClientCustomDatas1;
            Data.ClientCustomDatas2 = ClientCustomDatas2;
            Data.oceanFloatsamCratesOverride = OceanFloatsamCratesOverride;
            Data.treasureMapLootTablesOverride = TreasureMapLootTablesOverride;
            Data.lastModified = lastModified;
            Data.lastImageOverride = lastImageOverride;
            Data.GlobalBiomeSeamlessServerGridPreOffsetValues = GlobalBiomeSeamlessServerGridPreOffsetValues;
            Data.GlobalBiomeSeamlessServerGridPreOffsetValuesOceanWater = GlobalBiomeSeamlessServerGridPreOffsetValuesOceanWater;
            Data.islandLocked = islandLocked;
            Data.discoLocked = discoLocked;
            Data.pathsLocked = pathsLocked;
            Data.windsLocked = windsLocked;
            Data.extraSublevels = extraSublevels;
            Data.serverTemplateName = serverTemplateName;
            Data.serverConfigurationKeyPVE = serverConfigurationKeyPVE;
            Data.serverConfigurationKeyPVP = serverConfigurationKeyPVP;
            Data.totalExtraSublevels = new List<string>();
            Data.BackgroundImgPath = BackgroundImgPath;

            foreach (IslandInstanceData instance in islandInstances)
            {
                PointF relativePoint = server.WorldToRelativePoint(gridSize, new PointF(instance.worldX, instance.worldY));

                Island referencedIsland = instance.GetReferencedIsland(mainForm.islands);
                if (referencedIsland != null)
                {
                    foreach (string sublevelName in referencedIsland.sublevelNames)
                        Data.sublevels.Add(new SublevelSerializationObject() { name = sublevelName, id = instance.id, additionalTranslationX = relativePoint.X, additionalTranslationY = relativePoint.Y, additionalRotationYaw = instance.rotation, landscapeMaterialOverride = referencedIsland.landscapeMaterialOverride });

                    instance.treasureMapSpawnPoints = referencedIsland.treasureMapSpawnPoints;
                    instance.wildPirateCampSpawnPoints = referencedIsland.wildPirateCampSpawnPoints;
                    instance.minTreasureQuality = referencedIsland.minTreasureQuality;
                    instance.maxTreasureQuality = referencedIsland.maxTreasureQuality;
                    instance.useNpcVolumesForTreasures = referencedIsland.useNpcVolumesForTreasures;
                    instance.islandTreasureBottleSupplyCrateOverrides = referencedIsland.islandTreasureBottleSupplyCrateOverrides;
                    //instance.landNodeKey = referencedIsland.landNodeKey;
					//instance.spawnPointRegionOverride = referencedIsland.spawnPointRegionOverride;
                    instance.useLevelBoundsForTreasures = referencedIsland.useLevelBoundsForTreasures;
                    instance.prioritizeVolumesForTreasures = referencedIsland.prioritizeVolumesForTreasures;
                    instance.isControlPoint = referencedIsland.isControlPoint;
                    instance.isControlPointAllowCapture = referencedIsland.isControlPointAllowCapture;
                    instance.islandWidth = referencedIsland.x;
                    instance.islandHeight = referencedIsland.y;
                    instance.islandPoints = referencedIsland.islandPoints;
                    instance.singleSpawnPointX = referencedIsland.singleSpawnPointX;
                    instance.singleSpawnPointY = referencedIsland.singleSpawnPointY;
                    instance.singleSpawnPointZ = referencedIsland.singleSpawnPointZ;
                    instance.maxIslandClaimFlagZ = referencedIsland.maxIslandClaimFlagZ;
                }

                instance.SyncOverridesWithTemplates(mainForm);

                //Add the template spawner overrides if not already existing in the island
                if (referencedIsland.spawnerOverrides != null)
                    foreach (KeyValuePair<string, string> spawnerOverride in referencedIsland.spawnerOverrides)
                    {
                        if (!instance.spawnerOverrides.ContainsKey(spawnerOverride.Key))
                        {
                            instance.spawnerOverrides.Add(spawnerOverride.Key, spawnerOverride.Value);
                        }
                    }

                instance.harvestOverrideKeysTemplateInherited = referencedIsland.harvestOverrideKeys;

                if (referencedIsland.extraSublevels != null)
                    foreach (string extraSublevel in referencedIsland.extraSublevels)
                        if (!Data.totalExtraSublevels.Contains(extraSublevel) && !string.IsNullOrWhiteSpace(extraSublevel))
                            Data.totalExtraSublevels.Add(extraSublevel);
            }


            if (extraSublevels != null)
                foreach (string extraSublevel in extraSublevels)
                    if (!Data.totalExtraSublevels.Contains(extraSublevel) && !string.IsNullOrWhiteSpace(extraSublevel))
                        Data.totalExtraSublevels.Add(extraSublevel);

            Data.ServerPathingGrid = ServerPathingGrid;

            return Data;
        }
    }

    public static class ServerGrid_ServerOnlyDataEx
    {
        public static ServerGrid_ServerOnlyData SetFromProject(this ServerGrid_ServerOnlyData Data, Project InProject)
        {
            Data.ServerGroupsAndClusterSetsScheduleBaseURL = InProject.ServerGroupsAndClusterSetsScheduleBaseURL;
            Data.ServerGroupsAndClusterSetsScheduleFilename = InProject.ServerGroupsAndClusterSetsScheduleFilename;
            Data.ServerGroupsAndClusterSetsScheduleS3AccessKeyId = InProject.ServerGroupsAndClusterSetsScheduleS3AccessKeyId;
            Data.ServerGroupsAndClusterSetsScheduleS3SecretKey = InProject.ServerGroupsAndClusterSetsScheduleS3SecretKey;
            Data.ServerGroupsAndClusterSetsScheduleS3BucketName = InProject.ServerGroupsAndClusterSetsScheduleS3BucketName;
            Data.ServerGroupsAndClusterSetsScheduleS3Region = InProject.ServerGroupsAndClusterSetsScheduleS3Region;

            Data.LocalS3URL = InProject.LocalS3URL;
            Data.LocalS3AccessKeyId = InProject.LocalS3AccessKeyId;
            Data.LocalS3SecretKey = InProject.LocalS3SecretKey;
            Data.LocalS3BucketName = InProject.LocalS3BucketName;
            Data.LocalS3Region = InProject.LocalS3Region;
            Data.TribeLogConfig = InProject.TribeLogConfig;
            Data.SharedLogConfig = InProject.SharedLogConfig;
            Data.TravelDataConfig = InProject.TravelDataConfig;
            Data.ShipBottleDataConfig = InProject.ShipBottleDataConfig;
            Data.DatabaseConnections = InProject.DatabaseConnections;

            return Data;
        }
    }

    public static class ProjectSerializationObjectEx
    {
        public static AtlasGridData SetFromData(this AtlasGridData Data, float gridSize, List<Server> serverList, List<IslandInstanceData> islandInstances, List<DiscoveryZoneData> discoZones, List<SpawnRegionData> spawnRegions,
            string WorldAtlasId, string WorldFriendlyName, string MainRegionName, string MetaWorldURL, string ServerGroupsAndClusterSetsScheduleBaseURL, string ServerGroupsAndClusterSetsScheduleFilename, string ServerGroupsAndClusterSetsScheduleS3AccessKeyId, string ServerGroupsAndClusterSetsScheduleS3SecretKey, string ServerGroupsAndClusterSetsScheduleS3BucketName, string ServerGroupsAndClusterSetsScheduleS3Region, string MapImagesExtension, float coordsScaling, bool showServerInfo, bool showLines, bool alphaBackground, bool showBackground, Dictionary<string, string> regionsBackgroundImgPath, 
            MainForm mainForm, int idGenerator, int regionsIdGenerator, List<SpawnerInfoData> spawnerOverrideTemplates, bool bUseUTCTime, bool usePVEServerConfiguration, string Day0, float globalTransitionMinZ, string AdditionalCmdLineParams, 
            Dictionary<string, string> OverrideShooterGameModeDefaultGameIni, DateTime lastImageOverride, bool showDiscoZoneInfo, string discoZonesImagePath, List<ShipPathData> shipPaths, List<TradeWindData> tradeWinds,
            List<PortalPathData> portalPathData, int shipPathsIdGenerator, int tradeWindsIdGenerator, int portalPathsIdGenerator,
            bool showShipPathsInfo, bool showTradeWindsInfo, bool showPortalNodes, string modIDs, bool showIslandNames, bool showForeground, string foregroundImgPath, bool showTradeWindOverlay, string tradeWindOverlayImgPath, Dictionary<string, string> regionsTradeWindOverlayImgPath, string globalGameplaySetup,
            List<ServerTemplateData> serverTemplates, List<AppliedRegionTemplateData> appliedRegionTemplates, List<RegionTemplateData> regionTemplates, List<ServerConfiguration> serverConfigurations, List<RegionsCategory> regionsCategories, List<RegionsOverworldLocation> RegionsOverworldLocations, List<RegionsTreasureOverride> regionsTreasureOverrides, List<TransientNodeTemplate> transientNodeTemplates,List<FoliageAttachmentOverride> foliageAttachmentOverrides, bool bIsFinalExport, string MapImageURL, string OverallImageURL,string AuthListURL,
			string WorldAtlasPassword, float columnUTCOffset, int numPathingGridRows, int numPathingGridColumns, bool[,] PathingGrid,  bool bUseAutoServerRestart, string ServerRestartTime, bool bEnableWhitelistCheats)
        {
            Data.gridSize = gridSize;

            foreach (Server server in serverList)
            {
                List<IslandInstanceData> serverIslands = new List<IslandInstanceData>();

                foreach (IslandInstanceData instance in islandInstances)
                {
                    if (server.IsWorldPointInServer(new System.Drawing.PointF(instance.worldX, instance.worldY), gridSize))
                        serverIslands.Add(instance);
                }

                List<DiscoveryZoneData> serverDiscos = new List<DiscoveryZoneData>();
                foreach (DiscoveryZoneData instance in discoZones)
                {
                    if (server.IsWorldPointInServer(new System.Drawing.PointF(instance.worldX, instance.worldY), gridSize))
                        serverDiscos.Add(instance);
                }

                List<SpawnRegionData> serverSpawnRegions = new List<SpawnRegionData>();
                foreach (SpawnRegionData region in spawnRegions)
                {
                    if (server.gridX == region.X && server.gridY == region.Y)
                        serverSpawnRegions.Add(region);
                }

                List<Tuple<int, int>> ServerPathingGridTuples = new List<Tuple<int, int>>();
                int RowOffset = server.gridY * numPathingGridRows;
                int ColOffset = server.gridX * numPathingGridColumns;
                for (int Col = 0; Col < numPathingGridColumns; Col++)
                    for (int Row = 0; Row < numPathingGridRows; Row++)
                        if (!PathingGrid[Row + RowOffset, Col + ColOffset])
                            ServerPathingGridTuples.Add(new Tuple<int,int>(Row, Col));
				int[] ServerPathingGrid = new int[ServerPathingGridTuples.Count * 2];
                int i = 0;
                foreach (Tuple<int, int> ServerPathingGridTuple in ServerPathingGridTuples)
                {
                    ServerPathingGrid[i++] = ServerPathingGridTuple.Item1;
                    ServerPathingGrid[i++] = ServerPathingGridTuple.Item2;
                }

                if (!bIsFinalExport)
                {
                    Data.servers.Add(new ServerData().SetFrom(server, gridSize, server.gridX, server.gridY, server.MachineIdTag, server.ip, server.port,
                         server.gamePort, server.seamlessDataPort, serverIslands, serverDiscos, serverSpawnRegions, mainForm, server.isHomeServer, server.isMawWatersServer, server.mawWaterDayTime, server.hiddenAtlasId, server.forceServerRules, server.AdditionalCmdLineParams, server.OverrideShooterGameModeDefaultGameIni, server.RegisteredAtSpoolGroup, server.RegisteredAtClusterSet, server.name, server.floorZDist,
                         server.transitionMinZ, server.utcOffset, server.OceanDinoDepthEntriesOverride, server.oceanFloatsamCratesOverride,
                         server.treasureMapLootTablesOverride, server.lastModifiedUTC, server.lastImageOverrideUTC, server.GlobalBiomeSeamlessServerGridPreOffsetValues, server.GlobalBiomeSeamlessServerGridPreOffsetValuesOceanWater,
                         server.islandLocked, server.discoLocked, server.pathsLocked, server.windsLocked, server.extraSublevels, server.oceanEpicSpawnEntriesOverrideTemplateName, server.NPCShipSpawnEntriesOverrideTemplateName, server.regionOverrides,
                         server.waterColorR, server.waterColorG, server.waterColorB, server.billboardsOffsetX, server.billboardsOffsetY, server.billboardsOffsetZ,
                         server.OverrideDestNorthX, server.OverrideDestNorthY, server.OverrideDestSouthX, server.OverrideDestSouthY, server.OverrideDestEastX, server.OverrideDestEastY, server.OverrideDestWestX, server.OverrideDestWestY,
                         server.MaxPlayingSeconds,
                         server.MaxPlayingSecondsKickToServerX, server.MaxPlayingSecondsKickToServerY,
                    server.skyStyleIndex, server.serverIslandPointsMultiplier, server.ServerCustomDatas1, server.ServerCustomDatas2, server.ClientCustomDatas1, server.ClientCustomDatas2, server.serverTemplateName, server.serverConfigurationKeyPVP, server.serverConfigurationKeyPVE, server.OceanEpicSpawnEntriesOverrideValues, ServerPathingGrid, server.BackgroundImgPath));
                }
                else
                {
                    //Sublevels need to be overridden here to be processed in the constructor
                    List<string> overridenExtraSublevels = server.extraSublevels;
                    if (!string.IsNullOrEmpty(server.serverTemplateName))
                    {
                        ServerTemplateData serverTemplate = mainForm.currentProject.GetServerTemplateByName(server.serverTemplateName);
                        if (serverTemplate != null && server.extraSublevels.Count == 0)
                            overridenExtraSublevels = serverTemplate.extraSublevels;
                    }

                    //ServerSerializationObject exportServerObj = new ServerSerializationObject(server, gridSize, server.gridX, server.gridY, server.MachineIdTag, server.ip, server.port,
                    ServerData exportServerObj = new ServerData().SetFrom(server, gridSize, server.gridX, server.gridY, server.MachineIdTag, server.ip, server.port,
                        server.gamePort, server.seamlessDataPort, serverIslands, serverDiscos, serverSpawnRegions, mainForm, server.isHomeServer, server.isMawWatersServer, server.mawWaterDayTime, server.hiddenAtlasId, server.forceServerRules, server.AdditionalCmdLineParams, server.OverrideShooterGameModeDefaultGameIni, server.RegisteredAtSpoolGroup, server.RegisteredAtClusterSet, server.name, server.floorZDist,
                        server.transitionMinZ, server.utcOffset, server.OceanDinoDepthEntriesOverride, server.oceanFloatsamCratesOverride,
                        server.treasureMapLootTablesOverride, server.lastModifiedUTC, server.lastImageOverrideUTC, server.GlobalBiomeSeamlessServerGridPreOffsetValues, server.GlobalBiomeSeamlessServerGridPreOffsetValuesOceanWater,
                        server.islandLocked, server.discoLocked, server.pathsLocked, server.windsLocked, overridenExtraSublevels, server.oceanEpicSpawnEntriesOverrideTemplateName, server.NPCShipSpawnEntriesOverrideTemplateName, server.regionOverrides,
                        server.waterColorR, server.waterColorG, server.waterColorB, server.billboardsOffsetX, server.billboardsOffsetY, server.billboardsOffsetZ,
                        server.OverrideDestNorthX, server.OverrideDestNorthY, server.OverrideDestSouthX, server.OverrideDestSouthY, server.OverrideDestEastX, server.OverrideDestEastY, server.OverrideDestWestX, server.OverrideDestWestY,
                        server.MaxPlayingSeconds,
                        server.MaxPlayingSecondsKickToServerX, server.MaxPlayingSecondsKickToServerY,
                        server.skyStyleIndex, server.serverIslandPointsMultiplier, server.ServerCustomDatas1, server.ServerCustomDatas2, server.ClientCustomDatas1, server.ClientCustomDatas2, server.serverTemplateName, server.serverConfigurationKeyPVP, server.serverConfigurationKeyPVE, server.OceanEpicSpawnEntriesOverrideValues, ServerPathingGrid, server.BackgroundImgPath);

                    //Apply template
                    if(!string.IsNullOrEmpty(server.serverTemplateName))
                    {
                        ServerTemplateData serverTemplateData = mainForm.currentProject.GetServerTemplateByName(server.serverTemplateName);
                        AppliedRegionTemplateData appliedRegionTemplateData = mainForm.currentProject.GetAppliedRegionTemplateByName(server.hiddenAtlasId, true);
                        ServerData regionTemplateData = MergeTemplates(appliedRegionTemplateData, mainForm.currentProject.GetRegionTemplateByName(appliedRegionTemplateData.serverTemplateName));
                        ServerData serverTemplate = MergeTemplates(serverTemplateData, regionTemplateData);
                        if (serverTemplate != null)
                        {
                            //Overrides
                            exportServerObj.floorZDist = server.floorZDist != 0 ? server.floorZDist : serverTemplate.floorZDist;
                            exportServerObj.transitionMinZ = server.transitionMinZ != 0 ? server.transitionMinZ : serverTemplate.transitionMinZ;
                            exportServerObj.oceanEpicSpawnEntriesOverrideTemplateName = !string.IsNullOrEmpty(server.oceanEpicSpawnEntriesOverrideTemplateName) ? server.oceanEpicSpawnEntriesOverrideTemplateName : serverTemplate.oceanEpicSpawnEntriesOverrideTemplateName;
                            exportServerObj.NPCShipSpawnEntriesOverrideTemplateName = !string.IsNullOrEmpty(server.NPCShipSpawnEntriesOverrideTemplateName) ? server.NPCShipSpawnEntriesOverrideTemplateName : serverTemplate.NPCShipSpawnEntriesOverrideTemplateName;
                            exportServerObj.waterColorR = server.waterColorR != 0 ? server.waterColorR : serverTemplate.waterColorR;
                            exportServerObj.waterColorG = server.waterColorG != 0 ? server.waterColorG : serverTemplate.waterColorG;
                            exportServerObj.waterColorB = server.waterColorB != 0 ? server.waterColorB : serverTemplate.waterColorB;
                            exportServerObj.billboardsOffsetX = server.billboardsOffsetX != 0 ? server.billboardsOffsetX : serverTemplate.billboardsOffsetX;
                            exportServerObj.billboardsOffsetY = server.billboardsOffsetY != 0 ? server.billboardsOffsetY : serverTemplate.billboardsOffsetY;
                            exportServerObj.billboardsOffsetZ = server.billboardsOffsetZ != 0 ? server.billboardsOffsetZ : serverTemplate.billboardsOffsetZ;

                            exportServerObj.OverrideDestNorthX = server.OverrideDestNorthX != -1 ? server.OverrideDestNorthX : serverTemplate.OverrideDestNorthX;
                            exportServerObj.OverrideDestNorthY = server.OverrideDestNorthY != -1 ? server.OverrideDestNorthY : serverTemplate.OverrideDestNorthY;
                            exportServerObj.OverrideDestSouthX = server.OverrideDestSouthX != -1 ? server.OverrideDestSouthX : serverTemplate.OverrideDestSouthX;
                            exportServerObj.OverrideDestSouthY = server.OverrideDestSouthY != -1 ? server.OverrideDestSouthY : serverTemplate.OverrideDestSouthY;
                            exportServerObj.OverrideDestEastX = server.OverrideDestEastX != -1 ? server.OverrideDestEastX : serverTemplate.OverrideDestEastX;
                            exportServerObj.OverrideDestEastY = server.OverrideDestEastY != -1 ? server.OverrideDestEastY : serverTemplate.OverrideDestEastY;
                            exportServerObj.OverrideDestWestX = server.OverrideDestWestX != -1 ? server.OverrideDestWestX : serverTemplate.OverrideDestWestX;
                            exportServerObj.OverrideDestWestY = server.OverrideDestWestY != -1 ? server.OverrideDestWestY : serverTemplate.OverrideDestWestY;
                            exportServerObj.MaxPlayingSeconds = server.MaxPlayingSeconds > 0 ? server.MaxPlayingSeconds : serverTemplate.MaxPlayingSeconds;
                            exportServerObj.MaxPlayingSecondsKickToServerX = server.MaxPlayingSecondsKickToServerX != -1 ? server.MaxPlayingSecondsKickToServerX : serverTemplate.MaxPlayingSecondsKickToServerX;
                            exportServerObj.MaxPlayingSecondsKickToServerY = server.MaxPlayingSecondsKickToServerY != -1 ? server.MaxPlayingSecondsKickToServerY : serverTemplate.MaxPlayingSecondsKickToServerY;
                            exportServerObj.skyStyleIndex = server.skyStyleIndex != 0 ? server.skyStyleIndex : serverTemplate.skyStyleIndex;
                            exportServerObj.serverIslandPointsMultiplier = server.serverIslandPointsMultiplier != 1.0f ? server.serverIslandPointsMultiplier : serverTemplate.serverIslandPointsMultiplier;
                            exportServerObj.GlobalBiomeSeamlessServerGridPreOffsetValues = !string.IsNullOrEmpty(server.GlobalBiomeSeamlessServerGridPreOffsetValues) ? server.GlobalBiomeSeamlessServerGridPreOffsetValues : serverTemplate.GlobalBiomeSeamlessServerGridPreOffsetValues;
                            exportServerObj.GlobalBiomeSeamlessServerGridPreOffsetValuesOceanWater = !string.IsNullOrEmpty(server.GlobalBiomeSeamlessServerGridPreOffsetValuesOceanWater) ? server.GlobalBiomeSeamlessServerGridPreOffsetValuesOceanWater : serverTemplate.GlobalBiomeSeamlessServerGridPreOffsetValuesOceanWater;
                            exportServerObj.OceanDinoDepthEntriesOverride = !string.IsNullOrEmpty(server.OceanDinoDepthEntriesOverride) ? server.OceanDinoDepthEntriesOverride : serverTemplate.OceanDinoDepthEntriesOverride;
                            exportServerObj.OceanEpicSpawnEntriesOverrideValues = !string.IsNullOrEmpty(server.OceanEpicSpawnEntriesOverrideValues) ? server.OceanEpicSpawnEntriesOverrideValues : serverTemplate.OceanEpicSpawnEntriesOverrideValues;
                            exportServerObj.oceanFloatsamCratesOverride = !string.IsNullOrEmpty(server.oceanFloatsamCratesOverride) ? server.oceanFloatsamCratesOverride : serverTemplate.oceanFloatsamCratesOverride;
                            exportServerObj.treasureMapLootTablesOverride = !string.IsNullOrEmpty(server.treasureMapLootTablesOverride) ? server.treasureMapLootTablesOverride : serverTemplate.treasureMapLootTablesOverride;
                            exportServerObj.regionOverrides = !string.IsNullOrEmpty(server.regionOverrides) ? server.regionOverrides : serverTemplate.regionOverrides;

                            //Appends
                            exportServerObj.AdditionalCmdLineParams = exportServerObj.AdditionalCmdLineParams + serverTemplate.AdditionalCmdLineParams;

                            foreach (KeyValuePair<string, string> kvp in serverTemplate.OverrideShooterGameModeDefaultGameIni)
                                if (!exportServerObj.OverrideShooterGameModeDefaultGameIni.ContainsKey(kvp.Key))
                                    exportServerObj.OverrideShooterGameModeDefaultGameIni.Add(kvp.Key, kvp.Value);

                            exportServerObj.RegisteredAtSpoolGroup = server.RegisteredAtSpoolGroup;
                            exportServerObj.RegisteredAtClusterSet = server.RegisteredAtClusterSet;

                            //Splice these together cleanly:
                            if (!string.IsNullOrWhiteSpace(exportServerObj.ServerCustomDatas1))
                                exportServerObj.ServerCustomDatas1 = exportServerObj.ServerCustomDatas1.TrimEnd(',');
                            if (!string.IsNullOrWhiteSpace(exportServerObj.ServerCustomDatas2))
                                exportServerObj.ServerCustomDatas2 = exportServerObj.ServerCustomDatas2.TrimEnd(',');
                            if (!string.IsNullOrWhiteSpace(exportServerObj.ClientCustomDatas1))
                                exportServerObj.ClientCustomDatas1 = exportServerObj.ClientCustomDatas1.TrimEnd(',');
                            if (!string.IsNullOrWhiteSpace(exportServerObj.ClientCustomDatas2))
                                exportServerObj.ClientCustomDatas2 = exportServerObj.ClientCustomDatas2.TrimEnd(',');

                            if (!string.IsNullOrWhiteSpace(serverTemplate.ServerCustomDatas1))
                                exportServerObj.ServerCustomDatas1 = exportServerObj.ServerCustomDatas1 + "," + serverTemplate.ServerCustomDatas1.TrimStart(',');
                            if (!string.IsNullOrWhiteSpace(serverTemplate.ServerCustomDatas2))
                                exportServerObj.ServerCustomDatas2 = exportServerObj.ServerCustomDatas2 + "," + serverTemplate.ServerCustomDatas2.TrimStart(',');
                            if (!string.IsNullOrWhiteSpace(serverTemplate.ClientCustomDatas1))
                                exportServerObj.ClientCustomDatas1 = exportServerObj.ClientCustomDatas1 + "," + serverTemplate.ClientCustomDatas1.TrimStart(',');
                            if (!string.IsNullOrWhiteSpace(serverTemplate.ClientCustomDatas2))
                                exportServerObj.ClientCustomDatas2 = exportServerObj.ClientCustomDatas2 + "," + serverTemplate.ClientCustomDatas2.TrimStart(',');

                            exportServerObj.ServerPathingGrid = server.ServerPathingGrid;
                        }
                    }
                    Data.servers.Add(exportServerObj);
                }
            }

            Data.MetaWorldURL = MetaWorldURL;
            Data.ServerGroupsAndClusterSetsScheduleBaseURL = ServerGroupsAndClusterSetsScheduleBaseURL;
            Data.ServerGroupsAndClusterSetsScheduleFilename = ServerGroupsAndClusterSetsScheduleFilename;
            Data.ServerGroupsAndClusterSetsScheduleS3AccessKeyId = ServerGroupsAndClusterSetsScheduleS3AccessKeyId;
            Data.ServerGroupsAndClusterSetsScheduleS3SecretKey = ServerGroupsAndClusterSetsScheduleS3SecretKey;
            Data.ServerGroupsAndClusterSetsScheduleS3BucketName = ServerGroupsAndClusterSetsScheduleS3BucketName;
            Data.ServerGroupsAndClusterSetsScheduleS3Region = ServerGroupsAndClusterSetsScheduleS3Region;

            Data.MapImagesExtension = MapImagesExtension;
            Data.WorldFriendlyName = WorldFriendlyName;
            Data.MainRegionName = MainRegionName;
            Data.WorldAtlasId = WorldAtlasId;
            Data.usePVEServerConfiguration = usePVEServerConfiguration;
            Data.coordsScaling = coordsScaling;
            Data.showServerInfo = showServerInfo;
            Data.showDiscoZoneInfo = showDiscoZoneInfo;
            Data.showShipPathsInfo = showShipPathsInfo;
            Data.showTradeWindsInfo = showTradeWindsInfo;
            Data.showPortalNodes = showPortalNodes;
            Data.showLines = showLines;
            Data.alphaBackground = alphaBackground;
            Data.showBackground = showBackground;
            Data.showForeground = showForeground;
            Data.showTradeWindOverlay = showTradeWindOverlay;
            Data.regionsBackgroundImgPath = regionsBackgroundImgPath;
            Data.foregroundImgPath = foregroundImgPath;
            Data.tradeWindOverlayImgPath = tradeWindOverlayImgPath;

            if (regionsTradeWindOverlayImgPath != null)
                Data.regionsTradeWindOverlayImgPath = regionsTradeWindOverlayImgPath;
            else
                Data.regionsTradeWindOverlayImgPath = new Dictionary<string, string>();

            Data.idGenerator = idGenerator;
            Data.regionsIdGenerator = regionsIdGenerator;
            Data.spawnerOverrideTemplates = spawnerOverrideTemplates;
            Data.bUseUTCTime = bUseUTCTime;
            Data.bUseAutoServerRestart = bUseAutoServerRestart;
            Data.bEnableWhitelistCheats = bEnableWhitelistCheats;
        Data.ServerRestartTime = ServerRestartTime;
            Data.columnUTCOffset = columnUTCOffset;
            Data.globalTransitionMinZ = globalTransitionMinZ;
            Data.AdditionalCmdLineParams = AdditionalCmdLineParams;
            Data.OverrideShooterGameModeDefaultGameIni = OverrideShooterGameModeDefaultGameIni;
            Data.Day0 = Day0;
            Data.discoZonesImagePath = discoZonesImagePath;
            Data.lastImageOverride = lastImageOverride;
            Data.ModIDs = modIDs;
            Data.MapImageURL = MapImageURL;
            Data.OverAllMapImageURL = OverallImageURL;
            Data.AuthListURL = AuthListURL;
            if(shipPaths != null)
                Data.shipPaths = shipPaths;
            if (tradeWinds != null)
                Data.tradeWinds = tradeWinds;

            if (portalPathData != null)
                Data.portalPaths = portalPathData;
            
            Data.shipPathsIdGenerator = shipPathsIdGenerator;
            Data.PortalPathsIdGenerator = portalPathsIdGenerator;
            Data.tradeWindsIdGenerator = tradeWindsIdGenerator;
            Data.showIslandNames = showIslandNames;
            Data.globalGameplaySetup = globalGameplaySetup;
            if (serverTemplates == null)
                serverTemplates = new List<ServerTemplateData>();
            Data.serverTemplates = serverTemplates.ToList();

            if (appliedRegionTemplates == null)
                appliedRegionTemplates = new List<AppliedRegionTemplateData>();
            Data.appliedRegionTemplates = appliedRegionTemplates.ToList();

            if (regionTemplates == null)
                regionTemplates = new List<RegionTemplateData>();
            Data.regionTemplates = regionTemplates.ToList();

            if (regionsCategories == null)
                regionsCategories = new List<RegionsCategory>();

            if (serverConfigurations == null)
                serverConfigurations = new List<ServerConfiguration>();
        
            if (transientNodeTemplates == null)
                transientNodeTemplates = new List<TransientNodeTemplate>();

            if (foliageAttachmentOverrides == null)
                foliageAttachmentOverrides = new List<FoliageAttachmentOverride>();

            Data.regionsCategories = regionsCategories.ToList();
            Data.regionsOverworldLocations = RegionsOverworldLocations.ToList();
            Data.regionsTreasureOverrides = regionsTreasureOverrides.ToList();
            Data.serverConfigurations = serverConfigurations.ToList();
            Data.transientNodeTemplates = transientNodeTemplates.ToList();
            Data.foliageAttachmentOverrides = foliageAttachmentOverrides.ToList();
            Data.WorldAtlasPassword = WorldAtlasPassword;
            Data.numPathingGridRows = numPathingGridRows;
            Data.numPathingGridColumns = numPathingGridColumns;

            return Data;
        }

        private static ServerData MergeTemplates(ServerData ServerTemplate1, ServerData ServerTemplate2)
        {
            if (ServerTemplate1 == null)
                return ServerTemplate2;
            if (ServerTemplate2 == null)
                return ServerTemplate1;
            ServerData serverTemplate = new ServerData();

            serverTemplate.floorZDist = ServerTemplate1.floorZDist != 0 ? ServerTemplate1.floorZDist : ServerTemplate2.floorZDist;
            serverTemplate.transitionMinZ = ServerTemplate1.transitionMinZ != 0 ? ServerTemplate1.transitionMinZ : ServerTemplate2.transitionMinZ;
            serverTemplate.oceanEpicSpawnEntriesOverrideTemplateName = !string.IsNullOrEmpty(ServerTemplate1.oceanEpicSpawnEntriesOverrideTemplateName) ? ServerTemplate1.oceanEpicSpawnEntriesOverrideTemplateName : ServerTemplate2.oceanEpicSpawnEntriesOverrideTemplateName;
            serverTemplate.NPCShipSpawnEntriesOverrideTemplateName = !string.IsNullOrEmpty(ServerTemplate1.NPCShipSpawnEntriesOverrideTemplateName) ? ServerTemplate1.NPCShipSpawnEntriesOverrideTemplateName : ServerTemplate2.NPCShipSpawnEntriesOverrideTemplateName;
            serverTemplate.waterColorR = ServerTemplate1.waterColorR != 0 ? ServerTemplate1.waterColorR : ServerTemplate2.waterColorR;
            serverTemplate.waterColorG = ServerTemplate1.waterColorG != 0 ? ServerTemplate1.waterColorG : ServerTemplate2.waterColorG;
            serverTemplate.waterColorB = ServerTemplate1.waterColorB != 0 ? ServerTemplate1.waterColorB : ServerTemplate2.waterColorB;
            serverTemplate.billboardsOffsetX = ServerTemplate1.billboardsOffsetX != 0 ? ServerTemplate1.billboardsOffsetX : ServerTemplate2.billboardsOffsetX;
            serverTemplate.billboardsOffsetY = ServerTemplate1.billboardsOffsetY != 0 ? ServerTemplate1.billboardsOffsetY : ServerTemplate2.billboardsOffsetY;
            serverTemplate.billboardsOffsetZ = ServerTemplate1.billboardsOffsetZ != 0 ? ServerTemplate1.billboardsOffsetZ : ServerTemplate2.billboardsOffsetZ;

            serverTemplate.OverrideDestNorthX = ServerTemplate1.OverrideDestNorthX != -1 ? ServerTemplate1.OverrideDestNorthX : ServerTemplate2.OverrideDestNorthX;
            serverTemplate.OverrideDestNorthY = ServerTemplate1.OverrideDestNorthY != -1 ? ServerTemplate1.OverrideDestNorthY : ServerTemplate2.OverrideDestNorthY;
            serverTemplate.OverrideDestSouthX = ServerTemplate1.OverrideDestSouthX != -1 ? ServerTemplate1.OverrideDestSouthX : ServerTemplate2.OverrideDestSouthX;
            serverTemplate.OverrideDestSouthY = ServerTemplate1.OverrideDestSouthY != -1 ? ServerTemplate1.OverrideDestSouthY : ServerTemplate2.OverrideDestSouthY;
            serverTemplate.OverrideDestEastX = ServerTemplate1.OverrideDestEastX != -1 ? ServerTemplate1.OverrideDestEastX : ServerTemplate2.OverrideDestEastX;
            serverTemplate.OverrideDestEastY = ServerTemplate1.OverrideDestEastY != -1 ? ServerTemplate1.OverrideDestEastY : ServerTemplate2.OverrideDestEastY;
            serverTemplate.OverrideDestWestX = ServerTemplate1.OverrideDestWestX != -1 ? ServerTemplate1.OverrideDestWestX : ServerTemplate2.OverrideDestWestX;
            serverTemplate.OverrideDestWestY = ServerTemplate1.OverrideDestWestY != -1 ? ServerTemplate1.OverrideDestWestY : ServerTemplate2.OverrideDestWestY;
            serverTemplate.MaxPlayingSeconds = ServerTemplate1.MaxPlayingSeconds > 0 ? ServerTemplate1.MaxPlayingSeconds : ServerTemplate2.MaxPlayingSeconds;
            serverTemplate.MaxPlayingSecondsKickToServerX = ServerTemplate1.MaxPlayingSecondsKickToServerX != -1 ? ServerTemplate1.MaxPlayingSecondsKickToServerX : ServerTemplate2.MaxPlayingSecondsKickToServerX;
            serverTemplate.MaxPlayingSecondsKickToServerY = ServerTemplate1.MaxPlayingSecondsKickToServerY != -1 ? ServerTemplate1.MaxPlayingSecondsKickToServerY : ServerTemplate2.MaxPlayingSecondsKickToServerY;
            serverTemplate.skyStyleIndex = ServerTemplate1.skyStyleIndex != 0 ? ServerTemplate1.skyStyleIndex : ServerTemplate2.skyStyleIndex;
            serverTemplate.serverIslandPointsMultiplier = ServerTemplate1.serverIslandPointsMultiplier != 1.0f ? ServerTemplate1.serverIslandPointsMultiplier : ServerTemplate2.serverIslandPointsMultiplier;
            serverTemplate.GlobalBiomeSeamlessServerGridPreOffsetValues = !string.IsNullOrEmpty(ServerTemplate1.GlobalBiomeSeamlessServerGridPreOffsetValues) ? ServerTemplate1.GlobalBiomeSeamlessServerGridPreOffsetValues : ServerTemplate2.GlobalBiomeSeamlessServerGridPreOffsetValues;
            serverTemplate.GlobalBiomeSeamlessServerGridPreOffsetValuesOceanWater = !string.IsNullOrEmpty(ServerTemplate1.GlobalBiomeSeamlessServerGridPreOffsetValuesOceanWater) ? ServerTemplate1.GlobalBiomeSeamlessServerGridPreOffsetValuesOceanWater : ServerTemplate2.GlobalBiomeSeamlessServerGridPreOffsetValuesOceanWater;
            serverTemplate.OceanDinoDepthEntriesOverride = !string.IsNullOrEmpty(ServerTemplate1.OceanDinoDepthEntriesOverride) ? ServerTemplate1.OceanDinoDepthEntriesOverride : ServerTemplate2.OceanDinoDepthEntriesOverride;
            serverTemplate.OceanEpicSpawnEntriesOverrideValues = !string.IsNullOrEmpty(ServerTemplate1.OceanEpicSpawnEntriesOverrideValues) ? ServerTemplate1.OceanEpicSpawnEntriesOverrideValues : ServerTemplate2.OceanEpicSpawnEntriesOverrideValues;
            serverTemplate.oceanFloatsamCratesOverride = !string.IsNullOrEmpty(ServerTemplate1.oceanFloatsamCratesOverride) ? ServerTemplate1.oceanFloatsamCratesOverride : ServerTemplate2.oceanFloatsamCratesOverride;
            serverTemplate.treasureMapLootTablesOverride = !string.IsNullOrEmpty(ServerTemplate1.treasureMapLootTablesOverride) ? ServerTemplate1.treasureMapLootTablesOverride : ServerTemplate2.treasureMapLootTablesOverride;
            serverTemplate.regionOverrides = !string.IsNullOrEmpty(ServerTemplate1.regionOverrides) ? ServerTemplate1.regionOverrides : ServerTemplate2.regionOverrides;

            //Appends
            serverTemplate.AdditionalCmdLineParams = ServerTemplate1.AdditionalCmdLineParams + ServerTemplate2.AdditionalCmdLineParams;

            foreach (KeyValuePair<string, string> kvp in ServerTemplate1.OverrideShooterGameModeDefaultGameIni)
                if (!serverTemplate.OverrideShooterGameModeDefaultGameIni.ContainsKey(kvp.Key))
                    serverTemplate.OverrideShooterGameModeDefaultGameIni.Add(kvp.Key, kvp.Value);

            foreach (KeyValuePair<string, string> kvp in ServerTemplate2.OverrideShooterGameModeDefaultGameIni)
                if (!serverTemplate.OverrideShooterGameModeDefaultGameIni.ContainsKey(kvp.Key))
                    serverTemplate.OverrideShooterGameModeDefaultGameIni.Add(kvp.Key, kvp.Value);

            serverTemplate.RegisteredAtSpoolGroup = !string.IsNullOrEmpty(ServerTemplate1.RegisteredAtSpoolGroup) ? ServerTemplate1.RegisteredAtSpoolGroup : ServerTemplate2.RegisteredAtSpoolGroup;
            serverTemplate.RegisteredAtClusterSet = !string.IsNullOrEmpty(ServerTemplate1.RegisteredAtClusterSet) ? ServerTemplate1.RegisteredAtClusterSet : ServerTemplate2.RegisteredAtClusterSet;
            
            //Splice these together cleanly:
            if (!string.IsNullOrWhiteSpace(ServerTemplate1.ServerCustomDatas1))
                serverTemplate.ServerCustomDatas1 = ServerTemplate1.ServerCustomDatas1.TrimEnd(',');
            if (!string.IsNullOrWhiteSpace(ServerTemplate1.ServerCustomDatas2))
                serverTemplate.ServerCustomDatas2 = ServerTemplate1.ServerCustomDatas2.TrimEnd(',');
            if (!string.IsNullOrWhiteSpace(ServerTemplate1.ClientCustomDatas1))
                serverTemplate.ClientCustomDatas1 = ServerTemplate1.ClientCustomDatas1.TrimEnd(',');
            if (!string.IsNullOrWhiteSpace(ServerTemplate1.ClientCustomDatas2))
                serverTemplate.ClientCustomDatas2 = ServerTemplate1.ClientCustomDatas2.TrimEnd(',');

            if (!string.IsNullOrWhiteSpace(ServerTemplate2.ServerCustomDatas1))
                serverTemplate.ServerCustomDatas1 = ServerTemplate2.ServerCustomDatas1 + "," + serverTemplate.ServerCustomDatas1.TrimStart(',');
            if (!string.IsNullOrWhiteSpace(serverTemplate.ServerCustomDatas2))
                serverTemplate.ServerCustomDatas2 = ServerTemplate2.ServerCustomDatas2 + "," + serverTemplate.ServerCustomDatas2.TrimStart(',');
            if (!string.IsNullOrWhiteSpace(serverTemplate.ClientCustomDatas1))
                serverTemplate.ClientCustomDatas1 = ServerTemplate2.ClientCustomDatas1 + "," + serverTemplate.ClientCustomDatas1.TrimStart(',');
            if (!string.IsNullOrWhiteSpace(serverTemplate.ClientCustomDatas2))
                serverTemplate.ClientCustomDatas2 = ServerTemplate2.ClientCustomDatas2 + "," + serverTemplate.ClientCustomDatas2.TrimStart(',');

            return serverTemplate;
        }
    }

    public class Project
    {
        public bool successfullyLoaded;
        public List<IslandInstanceData> islandInstances = new List<IslandInstanceData>();
        public List<Server> servers = new List<Server>();
        public List<DiscoveryZoneData> discoZones = new List<DiscoveryZoneData>();
        public List<TransientNodeTemplate> transientNodeTemplates = new List<TransientNodeTemplate>();
        public List<SpawnRegionData> spawnRegions = new List<SpawnRegionData>();
        public List<RegionTemplateData> regionTemplates = new List<RegionTemplateData>();
        public List<AppliedRegionTemplateData> appliedRegionTemplates = new List<AppliedRegionTemplateData>();
        public List<ServerTemplateData> serverTemplates = new List<ServerTemplateData>();
        public List<ServerConfiguration> serverConfigurations = new List<ServerConfiguration>();
        public List<RegionsCategory> regionsCategories = new List<RegionsCategory>();
        public List<RegionsOverworldLocation> regionsOverworldLocations = new List<RegionsOverworldLocation>();
        public List<RegionsTreasureOverride> regionsTreasureOverrides = new List<RegionsTreasureOverride>();
        public List<FoliageAttachmentOverride> foliageAttachmentOverrides = new List<FoliageAttachmentOverride>();


        public int numOfCellsX = 5;
        public int numOfCellsY = 4;

        public float cellSize = 200000;
        public float columnUTCOffset = 0.0f;

        public string Day0 = "";
        public string ServerRestartTime = "";
        public bool bUseUTCTime = false;
        public bool bUseAutoServerRestart = false;
        public bool bEnableWhitelistCheats = false;
        public float globalTransitionMinZ = 0.0f;
        public string AdditionalCmdLineParams;
        public Dictionary<string, string> OverrideShooterGameModeDefaultGameIni = new Dictionary<string, string>();
        public string MetaWorldURL = "";
        public string MapImagesExtension = "jpg";
        public string WorldFriendlyName = "AtlasWorld";
        public string MainRegionName = "";
        public string WorldAtlasId = "";
        public string AuthListURL = "";
        public string WorldAtlasPassword = "";
        public string ModIDs = "";
        public string MapImageURL = "";
        public string OverallImageURL = "";
        public string BaseServerArgs = "";

        
        public string ServerGroupsAndClusterSetsScheduleBaseURL = "";
        public string ServerGroupsAndClusterSetsScheduleFilename = "";
        public string ServerGroupsAndClusterSetsScheduleS3AccessKeyId = "";
        public string ServerGroupsAndClusterSetsScheduleS3SecretKey = "";
        public string ServerGroupsAndClusterSetsScheduleS3BucketName = "";
        public string ServerGroupsAndClusterSetsScheduleS3Region = "";

        public string LocalS3URL = "";
        public string LocalS3AccessKeyId = "";
        public string LocalS3SecretKey = "";
        public string LocalS3BucketName = "";
        public string LocalS3Region = "";
        public string globalGameplaySetup = "";
        public TribeLogConfigInfo TribeLogConfig = new TribeLogConfigInfo();
        public SharedLogConfigInfo SharedLogConfig = new SharedLogConfigInfo();
        public BackupConfigInfo TravelDataConfig = new BackupConfigInfo();
        public ShipBiottleConfigInfo ShipBottleDataConfig = new ShipBiottleConfigInfo();
        public List<DatabaseConnectionInfo> DatabaseConnections = new List<DatabaseConnectionInfo>();

        public float coordsScaling = 0.01f;
        public bool usePVEServerConfiguration = false;
        public bool showServerInfo = true;
        public bool showDiscoZoneInfo = true;
        public bool showShipPathsInfo = true;
        public bool showTradeWindsInfo = true;
        public bool showPortalNodes = true;
        public bool showIslandNames = true;
        public bool disableImageExporting = false;
        public bool showLines = true;
        public bool alphaBackground = false;
        public bool showBackground = false;
        public bool showForeground = false;
        public bool showTradeWindOverlay = false;
        public Dictionary<string, string> regionsBackgroundImgPath = new Dictionary<string, string>();
        public string foregroundImgPath = null;
        public string tradeWindOverlayImgPath = null;
        public Dictionary<string, string> regionsTradeWindOverlayImgPath = new Dictionary<string, string>();

        public int idGenerator = 0;
        public int regionsIdGenerator = 0;
        public int shipPathsIdGenerator = 0;
        public int portalPathsIdGenerator = 0;
        public int tradeWindsIdGenerator = 0;
        public DateTime LastImageOverrideUTC;
        public int numPathingGridColumns = 10;
        public int numPathingGridRows = 10;

        public List<ShipPathData> shipPaths = new List<ShipPathData>();
        public List<TradeWindData> tradeWinds = new List<TradeWindData>();
        public List<PortalPathData> portalPaths = new List<PortalPathData>();

        public bool[,] AtlasPathingGrid = new bool[1,1];
        public bool AtlasPathingGridDirty = false;

        public int GenerateNewId() { return ++idGenerator; }
        public int GenerateNewSpawnRegionId() { return ++regionsIdGenerator; }

        public int GenerateUniqueDiscoZoneId()
        {
            ++idGenerator;
            for (int i = 0; i < discoZones.Count; i++)
            {
                if (discoZones[i].id == idGenerator)
                {
                    ++idGenerator;
                    i = 0;
                    break;
                }
            }
            return idGenerator;
        }
        public int GenerateNewShipPathId() { return ++shipPathsIdGenerator; }
        public int GenerateNewTradeWindId() { return ++tradeWindsIdGenerator; }
        public int GenetateNewPortalPathId() { return ++portalPathsIdGenerator; }

        public string discoZonesImagePath = "Resources/discoZoneBox.png";
        public Image DiscoveryZoneImage = null;

        public Project(float cellSize, int numOfCellsX, int numOfCellsY)
        {
            this.cellSize = cellSize;
            this.numOfCellsX = numOfCellsX;
            this.numOfCellsY = numOfCellsY;

            for (int i = 0; i < numOfCellsX; i++)
            {
                for (int j = 0; j < numOfCellsY; j++)
                {
                    servers.Add(new Server(i, j));
                    servers[servers.Count - 1].seamlessDataPort += (i + j * numOfCellsX);
                }
            }
        }

        public Project(string json, MainForm mainForm)
        {
            successfullyLoaded = false;
            Deserialize(json, mainForm);
        }

        public string Serialize(MainForm mainForm, bool bIsFinalExport = false)
        {
            List<string> referencedIslandNames = new List<string>();
            foreach (IslandInstanceData instance in islandInstances)
            {
                Island referenceIsland = instance.GetReferencedIsland(mainForm.islands);
                if (referenceIsland == null)
                    continue;

                if (referenceIsland.sublevelNames == null || referenceIsland.sublevelNames.Count == 0)
                {
                    string emptyIslandName = referenceIsland.name;
                    if (!referencedIslandNames.Contains(emptyIslandName))
                        referencedIslandNames.Add(emptyIslandName);
                }
            }

            foreach (string islandName in referencedIslandNames)
                MessageBox.Show(string.Format("The island \"{0}\" has no defined sublevels and will not appear ingame", islandName), "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);


            AtlasGridData ProjectObj = new AtlasGridData().SetFromData(cellSize, servers, islandInstances, discoZones, spawnRegions, WorldAtlasId, WorldFriendlyName, MainRegionName,MetaWorldURL, ServerGroupsAndClusterSetsScheduleBaseURL, ServerGroupsAndClusterSetsScheduleS3AccessKeyId, ServerGroupsAndClusterSetsScheduleS3SecretKey, ServerGroupsAndClusterSetsScheduleS3BucketName, ServerGroupsAndClusterSetsScheduleS3Region, ServerGroupsAndClusterSetsScheduleFilename, MapImagesExtension,
                coordsScaling, showServerInfo, showLines, alphaBackground, showBackground, regionsBackgroundImgPath, mainForm, idGenerator, regionsIdGenerator, mainForm.spawners.spawnersInfo, bUseUTCTime, usePVEServerConfiguration,
                Day0, globalTransitionMinZ, AdditionalCmdLineParams, OverrideShooterGameModeDefaultGameIni, LastImageOverrideUTC, showDiscoZoneInfo, discoZonesImagePath, shipPaths, tradeWinds, portalPaths,
                shipPathsIdGenerator, tradeWindsIdGenerator, portalPathsIdGenerator, showShipPathsInfo, showTradeWindsInfo, showPortalNodes, ModIDs, showIslandNames, showForeground, foregroundImgPath, showTradeWindOverlay, tradeWindOverlayImgPath, regionsTradeWindOverlayImgPath, globalGameplaySetup, serverTemplates, appliedRegionTemplates, regionTemplates, serverConfigurations, regionsCategories, regionsOverworldLocations, regionsTreasureOverrides, transientNodeTemplates, foliageAttachmentOverrides,
                bIsFinalExport, MapImageURL, OverallImageURL, AuthListURL,
				WorldAtlasPassword, columnUTCOffset, numPathingGridRows, numPathingGridColumns, AtlasPathingGrid, bUseAutoServerRestart, ServerRestartTime, bEnableWhitelistCheats);
            ProjectObj.BaseServerArgs = BaseServerArgs;
            ProjectObj.totalGridsX = numOfCellsX;
            ProjectObj.totalGridsY = numOfCellsY;
            if (!bIsFinalExport)
            {
                ProjectObj.ServerGroupsAndClusterSetsScheduleBaseURL = ServerGroupsAndClusterSetsScheduleBaseURL;
                ProjectObj.ServerGroupsAndClusterSetsScheduleFilename = ServerGroupsAndClusterSetsScheduleFilename;
                ProjectObj.ServerGroupsAndClusterSetsScheduleS3AccessKeyId = ServerGroupsAndClusterSetsScheduleS3AccessKeyId;
                ProjectObj.ServerGroupsAndClusterSetsScheduleS3SecretKey = ServerGroupsAndClusterSetsScheduleS3SecretKey;
                ProjectObj.ServerGroupsAndClusterSetsScheduleS3BucketName = ServerGroupsAndClusterSetsScheduleS3BucketName;
                ProjectObj.ServerGroupsAndClusterSetsScheduleS3Region = ServerGroupsAndClusterSetsScheduleS3Region;


                ProjectObj.LocalS3URL = LocalS3URL;
                ProjectObj.LocalS3AccessKeyId = LocalS3AccessKeyId;
                ProjectObj.LocalS3SecretKey = LocalS3SecretKey;
                ProjectObj.LocalS3BucketName = LocalS3BucketName;
                ProjectObj.LocalS3Region = LocalS3Region;
                ProjectObj.TribeLogConfig = TribeLogConfig;
                ProjectObj.SharedLogConfig = SharedLogConfig;
                ProjectObj.TravelDataConfig = TravelDataConfig;
                ProjectObj.ShipBottleDataConfig = ShipBottleDataConfig;
                ProjectObj.DatabaseConnections = DatabaseConnections;
            }
            else
            {
                ProjectObj.ServerGroupsAndClusterSetsScheduleBaseURL = null;
                ProjectObj.ServerGroupsAndClusterSetsScheduleFilename = null;
                ProjectObj.ServerGroupsAndClusterSetsScheduleS3AccessKeyId = null;
                ProjectObj.ServerGroupsAndClusterSetsScheduleS3SecretKey = null;
                ProjectObj.ServerGroupsAndClusterSetsScheduleS3BucketName = null;
                ProjectObj.ServerGroupsAndClusterSetsScheduleS3Region = null;

                ProjectObj.LocalS3URL = null;
                ProjectObj.LocalS3AccessKeyId = null;
                ProjectObj.LocalS3SecretKey = null;
                ProjectObj.LocalS3BucketName = null;
                ProjectObj.LocalS3Region = null;
                ProjectObj.TribeLogConfig = null;
                ProjectObj.SharedLogConfig = null;
                ProjectObj.TravelDataConfig = null;
                ProjectObj.ShipBottleDataConfig = null;
                ProjectObj.DatabaseConnections = null;
                ProjectObj.serverTemplates.Clear();
                ProjectObj.appliedRegionTemplates.Clear();
                ProjectObj.regionTemplates.Clear();
            }
            return JsonConvert.SerializeObject(ProjectObj, Formatting.Indented, new JsonSerializerSettings()
            {
                NullValueHandling = NullValueHandling.Ignore
            });
        }

        public void Deserialize(string json, MainForm mainForm)
        {
            try
            {
                AtlasGridData deserializedProject = JsonConvert.DeserializeObject<AtlasGridData>(json, new JsonSerializerSettings
                {
                    DefaultValueHandling = DefaultValueHandling.Populate,
                    NullValueHandling = NullValueHandling.Ignore
                });
                if (deserializedProject.TribeLogConfig == null)
                    deserializedProject.TribeLogConfig = new TribeLogConfigInfo();
                if (deserializedProject.SharedLogConfig == null)
                    deserializedProject.SharedLogConfig = new SharedLogConfigInfo();
                if (deserializedProject.TravelDataConfig == null)
                    deserializedProject.TravelDataConfig = new BackupConfigInfo();
                if (deserializedProject.ShipBottleDataConfig == null)
                    deserializedProject.ShipBottleDataConfig = new ShipBiottleConfigInfo();

                this.cellSize = deserializedProject.gridSize;
                idGenerator = deserializedProject.idGenerator;
                regionsIdGenerator = deserializedProject.regionsIdGenerator;

                int maxX = 0, maxY = 0;
                List<ServerData> targetServerList = /*deserializedProject.originalServers != null ? deserializedProject.originalServers : */deserializedProject.servers;
                foreach (ServerData deserializedServer in targetServerList)
                {
                    if (deserializedServer.gridX > maxX)
                        maxX = deserializedServer.gridX;

                    if (deserializedServer.gridY > maxY)
                        maxY = deserializedServer.gridY;

                    Server s = new Server(deserializedServer.gridX, deserializedServer.gridY);
                    s.MachineIdTag = deserializedServer.MachineIdTag;
                    s.ip = deserializedServer.ip;
                    s.port = deserializedServer.port;
                    s.gamePort = deserializedServer.gamePort;
                    s.seamlessDataPort = deserializedServer.seamlessDataPort;
                    s.isHomeServer = deserializedServer.isHomeServer;
                    s.isMawWatersServer = deserializedServer.isMawWatersServer;
                    s.mawWaterDayTime = deserializedServer.mawWaterDayTime;
                    s.hiddenAtlasId = deserializedServer.hiddenAtlasId;
                    s.forceServerRules = deserializedServer.forceServerRules;
                    s.AdditionalCmdLineParams = deserializedServer.AdditionalCmdLineParams;
                    s.OverrideShooterGameModeDefaultGameIni = deserializedServer.OverrideShooterGameModeDefaultGameIni;
                    s.RegisteredAtSpoolGroup = deserializedServer.RegisteredAtSpoolGroup;
                    s.RegisteredAtClusterSet = deserializedServer.RegisteredAtClusterSet;
                    s.name = deserializedServer.name;
                    s.floorZDist = deserializedServer.floorZDist;
                    s.transitionMinZ = deserializedServer.transitionMinZ;
                    s.utcOffset = deserializedServer.utcOffset;
                    s.GlobalBiomeSeamlessServerGridPreOffsetValues = deserializedServer.GlobalBiomeSeamlessServerGridPreOffsetValues;
                    s.GlobalBiomeSeamlessServerGridPreOffsetValuesOceanWater = deserializedServer.GlobalBiomeSeamlessServerGridPreOffsetValuesOceanWater;
                    s.OceanDinoDepthEntriesOverride = deserializedServer.OceanDinoDepthEntriesOverride;
                    s.OceanEpicSpawnEntriesOverrideValues = deserializedServer.OceanEpicSpawnEntriesOverrideValues;
                    s.oceanEpicSpawnEntriesOverrideTemplateName = deserializedServer.oceanEpicSpawnEntriesOverrideTemplateName;
                    s.NPCShipSpawnEntriesOverrideTemplateName = deserializedServer.NPCShipSpawnEntriesOverrideTemplateName;
                    s.regionOverrides = deserializedServer.regionOverrides;
                    s.waterColorR = deserializedServer.waterColorR;
                    s.waterColorG = deserializedServer.waterColorG;
                    s.waterColorB = deserializedServer.waterColorB;
                    s.billboardsOffsetX = deserializedServer.billboardsOffsetX;
                    s.billboardsOffsetY = deserializedServer.billboardsOffsetY;
                    s.billboardsOffsetZ = deserializedServer.billboardsOffsetZ;
                    s.OverrideDestNorthX = deserializedServer.OverrideDestNorthX;
                    s.OverrideDestNorthY = deserializedServer.OverrideDestNorthY;
                    s.OverrideDestSouthX = deserializedServer.OverrideDestSouthX;
                    s.OverrideDestSouthY = deserializedServer.OverrideDestSouthY;
                    s.OverrideDestEastX = deserializedServer.OverrideDestEastX;
                    s.OverrideDestEastY = deserializedServer.OverrideDestEastY;
                    s.OverrideDestWestX = deserializedServer.OverrideDestWestX;
                    s.OverrideDestWestY = deserializedServer.OverrideDestWestY;
                    s.MaxPlayingSeconds = deserializedServer.MaxPlayingSeconds;
                    s.MaxPlayingSecondsKickToServerX = deserializedServer.MaxPlayingSecondsKickToServerX;
                    s.MaxPlayingSecondsKickToServerY = deserializedServer.MaxPlayingSecondsKickToServerY;
                    s.skyStyleIndex = deserializedServer.skyStyleIndex;
                    s.serverIslandPointsMultiplier = deserializedServer.serverIslandPointsMultiplier;
                    s.ServerCustomDatas1 = deserializedServer.ServerCustomDatas1;
                    s.ServerCustomDatas2 = deserializedServer.ServerCustomDatas2;
                    s.ClientCustomDatas1 = deserializedServer.ClientCustomDatas1;
                    s.ClientCustomDatas2 = deserializedServer.ClientCustomDatas2;
                    s.oceanFloatsamCratesOverride = deserializedServer.oceanFloatsamCratesOverride;
                    s.treasureMapLootTablesOverride = deserializedServer.treasureMapLootTablesOverride;
                    s.lastModifiedUTC = deserializedServer.lastModified;
                    s.lastImageOverrideUTC = deserializedServer.lastImageOverride;
                    s.serverTemplateName = deserializedServer.serverTemplateName;
                    s.serverConfigurationKeyPVE = deserializedServer.serverConfigurationKeyPVE;
                    s.serverConfigurationKeyPVP = deserializedServer.serverConfigurationKeyPVP;
                    s.BackgroundImgPath = deserializedServer.BackgroundImgPath;
                    if (s.serverTemplateName == null)
                        s.serverTemplateName = "";
                    if (s.floorZDist <= 0)
                        s.floorZDist = 0;
                    s.islandLocked = deserializedServer.islandLocked;
                    s.discoLocked = deserializedServer.discoLocked;
                    s.pathsLocked = deserializedServer.pathsLocked;
                    s.windsLocked = deserializedServer.windsLocked;
                    s.extraSublevels = deserializedServer.extraSublevels;




                    List<string> newExtraSublevels = new List<string>();
                    if (s.extraSublevels != null)
                        foreach (string extraSublevel in s.extraSublevels)
                            if (extraSublevel != null)
                            {
                                string newExtraSublevel = extraSublevel.Trim();
                                if (newExtraSublevel.Length > 0 && !string.IsNullOrWhiteSpace(newExtraSublevel))
                                {
                                    string[] names = newExtraSublevel.Split(',');
                                    foreach (string extraSublevelName in names)
                                        if (extraSublevelName != null)
                                        {
                                            string newName = extraSublevelName.Trim();
                                            if (newName.Length > 0)
                                                newExtraSublevels.Add(newName);
                                        }
                                }
                            }
                    s.extraSublevels = newExtraSublevels;



                    servers.Add(s);

                    foreach (IslandInstanceData deserializedIslandInstance in deserializedServer.islandInstances)
                    {
                        if (!mainForm.islands.ContainsKey(deserializedIslandInstance.name))
                            continue;

                        //PointF worldPoint = s.RelativeToWorldPoint(cellSize, new PointF(deserializedIsland.additionalTranslationX, deserializedIsland.additionalTranslationY));
                        //islandInstances.Add(new IslandInstance(deserializedIsland.name, worldPoint.X, worldPoint.Y, deserializedIsland.additionalRotationYaw));
                        bool bRepeatedId = false;
                        foreach (IslandInstanceData prevIslands in islandInstances)
                            if (prevIslands.id == deserializedIslandInstance.id)
                            {
                                bRepeatedId = true;
                                break;
                            }
                        if (deserializedIslandInstance.id == 0 || bRepeatedId)
                            deserializedIslandInstance.id = GenerateNewId();

                        deserializedIslandInstance.SyncOverridesWithTemplates(mainForm);

                        deserializedIslandInstance.maxTreasureQuality = deserializedIslandInstance.minTreasureQuality = -1;
                        deserializedIslandInstance.useNpcVolumesForTreasures = false;
                        deserializedIslandInstance.islandTreasureBottleSupplyCrateOverrides = "";
                        deserializedIslandInstance.islandPoints = 1;
                        deserializedIslandInstance.singleSpawnPointX = 0;
                        deserializedIslandInstance.singleSpawnPointY = 0;
                        deserializedIslandInstance.singleSpawnPointZ = 0;
						//deserializedIslandInstance.spawnPointRegionOverride = -1;

                        islandInstances.Add(deserializedIslandInstance);
                    }

                    foreach (DiscoveryZoneData deserializedDiscoZone in deserializedServer.discoZones)
                    {
                        bool bRepeatedId = false;
                        foreach (DiscoveryZoneData prevDiscoZones in discoZones)
                            if (prevDiscoZones.id == deserializedDiscoZone.id)
                            {
                                bRepeatedId = true;
                                break;
                            }
                        if (deserializedDiscoZone.id == 0 || bRepeatedId)
                            deserializedDiscoZone.id = GenerateUniqueDiscoZoneId();

                        discoZones.Add(deserializedDiscoZone);
                    }

                    foreach (SpawnRegionData spawnRegion in deserializedServer.spawnRegions)
                    {
                        spawnRegion.X = deserializedServer.gridX; spawnRegion.Y = deserializedServer.gridY;
                        spawnRegions.Add(spawnRegion);
                    }

                    s.ServerPathingGrid = deserializedServer.ServerPathingGrid;
                }

                int TempNumPathingGridRows = deserializedProject.numPathingGridRows;
                int TempNumPathingGridColumns = deserializedProject.numPathingGridColumns;
                int TempNumOfCellsX = maxX + 1;
                int TempNumOfCellsY = maxY + 1;

                regionsTreasureOverrides = deserializedProject.regionsTreasureOverrides;
                if (regionsTreasureOverrides == null)
                    regionsTreasureOverrides = new List<RegionsTreasureOverride>();

                regionsCategories = deserializedProject.regionsCategories;
                if (regionsCategories == null)
                    regionsCategories = new List<RegionsCategory>();

                regionsOverworldLocations = deserializedProject.regionsOverworldLocations;
                if (regionsOverworldLocations == null)
                    regionsOverworldLocations = new List<RegionsOverworldLocation>(); 

                serverConfigurations = deserializedProject.serverConfigurations;
                if (serverConfigurations == null)
                    serverConfigurations = new List<ServerConfiguration>();
                transientNodeTemplates = deserializedProject.transientNodeTemplates;
                if (transientNodeTemplates == null)
                    transientNodeTemplates = new List<TransientNodeTemplate>();

                AtlasPathingGrid = new bool[(TempNumPathingGridRows * TempNumOfCellsY), (TempNumPathingGridColumns * TempNumOfCellsX)];

                foliageAttachmentOverrides = deserializedProject.foliageAttachmentOverrides;
                if (foliageAttachmentOverrides == null)
                    foliageAttachmentOverrides = new List<FoliageAttachmentOverride>();

                for (int Row = 0; Row < AtlasPathingGrid.GetLength(0); Row++)
                    for (int Col = 0; Col < AtlasPathingGrid.GetLength(1); Col++)
                        AtlasPathingGrid[Row, Col] = true;

                foreach (ServerData deserializedServer in targetServerList)
                {

                    int RowOffset = deserializedServer.gridY * TempNumPathingGridRows;
                    int ColOffset = deserializedServer.gridX * TempNumPathingGridColumns;

                    if (deserializedServer.ServerPathingGrid != null)
                    for (int i = 0; i < deserializedServer.ServerPathingGrid.Length; i += 2)
                    {
                        AtlasPathingGrid[RowOffset + deserializedServer.ServerPathingGrid[i], ColOffset + deserializedServer.ServerPathingGrid[i + 1]] = false;
                    }
                }

                numPathingGridRows = deserializedProject.numPathingGridRows;
                numPathingGridColumns = deserializedProject.numPathingGridColumns;
                numOfCellsX = maxX + 1;
                numOfCellsY = maxY + 1; 
                WorldFriendlyName = deserializedProject.WorldFriendlyName;
                MainRegionName = deserializedProject.MainRegionName;
                WorldAtlasId = deserializedProject.WorldAtlasId;
                usePVEServerConfiguration = deserializedProject.usePVEServerConfiguration;
                AuthListURL = deserializedProject.AuthListURL;
                MetaWorldURL = deserializedProject.MetaWorldURL;
                MapImagesExtension = deserializedProject.MapImagesExtension;
                if (MapImagesExtension != "png" && MapImagesExtension != "jpg")
                    MapImagesExtension = "jpg";
                coordsScaling = deserializedProject.coordsScaling;
                showServerInfo = deserializedProject.showServerInfo;
                showDiscoZoneInfo = deserializedProject.showDiscoZoneInfo;
                showIslandNames = deserializedProject.showIslandNames;
                showShipPathsInfo = deserializedProject.showShipPathsInfo;
                showTradeWindsInfo = deserializedProject.showTradeWindsInfo;
                showPortalNodes = deserializedProject.showPortalNodes;
                showLines = deserializedProject.showLines;
                alphaBackground = deserializedProject.alphaBackground;
                showBackground = deserializedProject.showBackground;
                showForeground = deserializedProject.showForeground;
                showTradeWindOverlay = deserializedProject.showTradeWindOverlay;
                regionsBackgroundImgPath = deserializedProject.regionsBackgroundImgPath;
                foregroundImgPath = deserializedProject.foregroundImgPath;
                tradeWindOverlayImgPath = deserializedProject.tradeWindOverlayImgPath;
                regionsTradeWindOverlayImgPath = deserializedProject.regionsTradeWindOverlayImgPath != null ? deserializedProject.regionsTradeWindOverlayImgPath : new Dictionary<string, string> ();
                discoZonesImagePath = deserializedProject.discoZonesImagePath;
                ModIDs = deserializedProject.ModIDs;
                MapImageURL = deserializedProject.MapImageURL;
                OverallImageURL = deserializedProject.OverAllMapImageURL;
                BaseServerArgs = deserializedProject.BaseServerArgs;
                ServerGroupsAndClusterSetsScheduleBaseURL = deserializedProject.ServerGroupsAndClusterSetsScheduleBaseURL;
                ServerGroupsAndClusterSetsScheduleFilename = deserializedProject.ServerGroupsAndClusterSetsScheduleFilename;
                ServerGroupsAndClusterSetsScheduleS3AccessKeyId = deserializedProject.ServerGroupsAndClusterSetsScheduleS3AccessKeyId;
                ServerGroupsAndClusterSetsScheduleS3SecretKey = deserializedProject.ServerGroupsAndClusterSetsScheduleS3SecretKey;
                ServerGroupsAndClusterSetsScheduleS3BucketName = deserializedProject.ServerGroupsAndClusterSetsScheduleS3BucketName;
                ServerGroupsAndClusterSetsScheduleS3Region = deserializedProject.ServerGroupsAndClusterSetsScheduleS3Region;


                LocalS3URL = deserializedProject.LocalS3URL;
                LocalS3AccessKeyId = deserializedProject.LocalS3AccessKeyId;
                LocalS3SecretKey = deserializedProject.LocalS3SecretKey;
                LocalS3BucketName = deserializedProject.LocalS3BucketName;
                LocalS3Region = deserializedProject.LocalS3Region;
                globalGameplaySetup = deserializedProject.globalGameplaySetup;
                TribeLogConfig = deserializedProject.TribeLogConfig;
                TravelDataConfig = deserializedProject.TravelDataConfig;
                SharedLogConfig = deserializedProject.SharedLogConfig;
                ShipBottleDataConfig = deserializedProject.ShipBottleDataConfig;
                DatabaseConnections = deserializedProject.DatabaseConnections;

                bUseUTCTime = deserializedProject.bUseUTCTime;
                bUseAutoServerRestart = deserializedProject.bUseAutoServerRestart;
                bEnableWhitelistCheats = deserializedProject.bEnableWhitelistCheats;
                ServerRestartTime = deserializedProject.ServerRestartTime;
                columnUTCOffset = deserializedProject.columnUTCOffset;
                globalTransitionMinZ = deserializedProject.globalTransitionMinZ;
                AdditionalCmdLineParams = deserializedProject.AdditionalCmdLineParams;
                OverrideShooterGameModeDefaultGameIni = deserializedProject.OverrideShooterGameModeDefaultGameIni;
                Day0 = deserializedProject.Day0;
                LastImageOverrideUTC = deserializedProject.lastImageOverride;
                WorldAtlasPassword = deserializedProject.WorldAtlasPassword;
                if (deserializedProject.shipPaths != null)
                {
                    shipPaths = deserializedProject.shipPaths;
                    foreach (ShipPathData shipPath in shipPaths)
                    {
                        foreach (ShipPathNode shipPathNode in shipPath.Nodes)
                            shipPathNode.shipPath = shipPath;
                    }
                }
                shipPathsIdGenerator = deserializedProject.shipPathsIdGenerator;
                
                if (deserializedProject.tradeWinds != null)
                {
                    tradeWinds = deserializedProject.tradeWinds;
                    foreach (TradeWindData tradeWind in tradeWinds)
                    {
                        foreach (TradeWindNode tradeWindNode in tradeWind.Nodes)
                            tradeWindNode.tradeWind = tradeWind;
                    }
                }
                tradeWindsIdGenerator = deserializedProject.tradeWindsIdGenerator;

                if (deserializedProject.portalPaths != null)
                {
                    portalPaths = deserializedProject.portalPaths;
                    foreach (PortalPathData portalPath in portalPaths)
                    {
                        foreach (PortalPathNode portalPathNode in portalPath.Nodes)
                            portalPathNode.portalPathData = portalPath;
                    }
                }

                portalPathsIdGenerator = deserializedProject.PortalPathsIdGenerator;


                appliedRegionTemplates = deserializedProject.appliedRegionTemplates;
                if (appliedRegionTemplates == null)
                    appliedRegionTemplates = new List<AppliedRegionTemplateData>();

                regionTemplates = deserializedProject.regionTemplates;
                if (regionTemplates == null)
                    regionTemplates = new List<RegionTemplateData>();

                serverTemplates = deserializedProject.serverTemplates;
                if (serverTemplates == null)
                    serverTemplates = new List<ServerTemplateData>();

                successfullyLoaded = true;
            }
            catch (Exception e)
            {
                MessageBox.Show("Failed to parse project json, Message: " + e.Message, "Error");
            }
        }

        public ServerTemplateData GetServerTemplateByName(string templateName)
        {
            foreach (ServerTemplateData template in serverTemplates)
                if (template.name == templateName)
                    return template;

            return null;
        }

        public RegionTemplateData GetRegionTemplateByName(string templateName)
        {
            foreach (RegionTemplateData template in regionTemplates)
                if (template.name == templateName)
                    return template;
            return null;
        }

        public AppliedRegionTemplateData GetAppliedRegionTemplateByName(string templateName, bool bCanAdd = true)
        {
            foreach (AppliedRegionTemplateData template in appliedRegionTemplates)
                if (template.name == templateName)
                    return template;
            if (!bCanAdd)
                return null;

            AppliedRegionTemplateData regionTemplateData = new AppliedRegionTemplateData();
            regionTemplateData.name = templateName;

            appliedRegionTemplates.Add(regionTemplateData);
            return appliedRegionTemplates[appliedRegionTemplates.Count - 1];
        }

        public TransientNodeTemplate GetTransientNodeTemplateByName(string Key)
        {
            foreach (TransientNodeTemplate template in transientNodeTemplates)
                if (template.Key == Key)
                    return template;

            return null;
        }

        public ServerConfiguration GetServerConfigurationByName(string Key)
        {
            foreach (ServerConfiguration template in serverConfigurations)
                if (template.Key == Key)
                    return template;

            return null;
        }

        public FoliageAttachmentOverride GetFoliageAttachmentOverrideByName(string Key)
        {
            foreach (FoliageAttachmentOverride template in foliageAttachmentOverrides)
                if (template.Key == Key)
                    return template;

            return null;
        }
    }
}
