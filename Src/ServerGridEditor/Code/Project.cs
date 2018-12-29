using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using System.Drawing;
using System.Windows.Forms;
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
            bool isHomeServer, string AdditionalCmdLineParams, Dictionary<string, string> OverrideShooterGameModeDefaultGameIni, string name, int floorZDist, int transitionMinZ, int utcOffset, string OceanDinoDepthEntriesOverride, 
            string OceanFloatsamCratesOverride, string TreasureMapLootTablesOverride, DateTime lastModified, DateTime lastImageOverride, string GlobalBiomeSeamlessServerGridPreOffsetValues, string GlobalBiomeSeamlessServerGridPreOffsetValuesOceanWater,
            bool islandLocked, bool discoLocked, bool pathsLocked, List<string> extraSublevels, string oceanEpicSpawnEntriesOverrideTemplateName, string NPCShipSpawnEntriesOverrideTemplateName, string regionOverrides,
            float waterColorR, float waterColorG, float waterColorB, int skyStyleIndex, string ServerCustomDatas1, string ServerCustomDatas2, string ClientCustomDatas1, string ClientCustomDatas2, string serverTemplateName, string OceanEpicSpawnEntriesOverrideValues)
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
            Data.AdditionalCmdLineParams = AdditionalCmdLineParams;
            Data.OverrideShooterGameModeDefaultGameIni = OverrideShooterGameModeDefaultGameIni;
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
            Data.skyStyleIndex = skyStyleIndex;
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
            Data.spawnRegions = spawnRegions == null ? new List<SpawnRegionData>() : spawnRegions;
            Data.extraSublevels = extraSublevels;
            Data.serverTemplateName = serverTemplateName;

            return Data;
        }

        public static ServerData SetFrom(this ServerData Data, Server server, float gridSize, int gridX, int gridY, string MachineIdTag, string ip, int port, 
            int gamePort, int seamlessDataPort, List<IslandInstanceData> islandInstances, List<DiscoveryZoneData> discoZones, List<SpawnRegionData> spawnRegions, MainForm mainForm, 
            bool isHomeServer, string AdditionalCmdLineParams, Dictionary<string, string> OverrideShooterGameModeDefaultGameIni, string name, int floorZDist, int transitionMinZ, int utcOffset, string OceanDinoDepthEntriesOverride, 
            string OceanFloatsamCratesOverride, string TreasureMapLootTablesOverride, DateTime lastModified, DateTime lastImageOverride, string GlobalBiomeSeamlessServerGridPreOffsetValues, string GlobalBiomeSeamlessServerGridPreOffsetValuesOceanWater,
            bool islandLocked, bool discoLocked, bool pathsLocked, List<string> extraSublevels, string oceanEpicSpawnEntriesOverrideTemplateName, string NPCShipSpawnEntriesOverrideTemplateName, string regionOverrides,
            float waterColorR, float waterColorG, float waterColorB, int skyStyleIndex, string ServerCustomDatas1, string ServerCustomDatas2, string ClientCustomDatas1, string ClientCustomDatas2, string serverTemplateName, string OceanEpicSpawnEntriesOverrideValues)
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
            Data.AdditionalCmdLineParams = AdditionalCmdLineParams;
            Data.OverrideShooterGameModeDefaultGameIni = OverrideShooterGameModeDefaultGameIni;
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
            Data.skyStyleIndex = skyStyleIndex;
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
            Data.extraSublevels = extraSublevels;
            Data.serverTemplateName = serverTemplateName;

            Data.totalExtraSublevels = new List<string>();

            foreach (IslandInstanceData instance in islandInstances)
            {
                PointF relativePoint = server.WorldToRelativePoint(gridSize, new PointF(instance.worldX, instance.worldY));

                Island referencedIsland = instance.GetReferencedIsland(mainForm.islands);
                if (referencedIsland != null)
                {
                    foreach (string sublevelName in referencedIsland.sublevelNames)
                        Data.sublevels.Add(new SublevelSerializationObject() { name = sublevelName, id = instance.id, additionalTranslationX = relativePoint.X, additionalTranslationY = relativePoint.Y, additionalRotationYaw = instance.rotation, landscapeMaterialOverride = referencedIsland.landscapeMaterialOverride });
                    
                    instance.minTreasureQuality = referencedIsland.minTreasureQuality;
                    instance.maxTreasureQuality = referencedIsland.maxTreasureQuality;
                    instance.useNpcVolumesForTreasures = referencedIsland.useNpcVolumesForTreasures;
                    instance.islandTreasureBottleSupplyCrateOverrides = referencedIsland.islandTreasureBottleSupplyCrateOverrides;
					//instance.spawnPointRegionOverride = referencedIsland.spawnPointRegionOverride;
                    instance.useLevelBoundsForTreasures = referencedIsland.useLevelBoundsForTreasures;
                    instance.prioritizeVolumesForTreasures = referencedIsland.prioritizeVolumesForTreasures;
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

                if (referencedIsland.extraSublevels != null)
                    foreach (string extraSublevel in referencedIsland.extraSublevels)
                        if (!Data.totalExtraSublevels.Contains(extraSublevel) && !string.IsNullOrWhiteSpace(extraSublevel))
                            Data.totalExtraSublevels.Add(extraSublevel);
            }


            if (extraSublevels != null)
                foreach (string extraSublevel in extraSublevels)
                    if (!Data.totalExtraSublevels.Contains(extraSublevel) && !string.IsNullOrWhiteSpace(extraSublevel))
                        Data.totalExtraSublevels.Add(extraSublevel);

            return Data;
        }
    }

    public static class ServerGrid_ServerOnlyDataEx
    {
        public static ServerGrid_ServerOnlyData SetFromProject(this ServerGrid_ServerOnlyData Data, Project InProject)
        {
            Data.LocalS3URL = InProject.LocalS3URL;
            Data.LocalS3AccessKeyId = InProject.LocalS3AccessKeyId;
            Data.LocalS3SecretKey = InProject.LocalS3SecretKey;
            Data.LocalS3BucketName = InProject.LocalS3BucketName;
            Data.LocalS3Region = InProject.LocalS3Region;
            Data.TribeLogConfig = InProject.TribeLogConfig;
            Data.SharedLogConfig = InProject.SharedLogConfig;
            Data.TravelDataConfig = InProject.TravelDataConfig;
            Data.DatabaseConnections = InProject.DatabaseConnections;

            return Data;
        }
    }


    public static class ProjectSerializationObjectEx
    {
        public static AtlasGridData SetFromData(this AtlasGridData Data, float gridSize, List<Server> serverList, List<IslandInstanceData> islandInstances, List<DiscoveryZoneData> discoZones, List<SpawnRegionData> spawnRegions,
            string WorldAtlasId, string WorldFriendlyName, string MetaWorldURL, float coordsScaling, bool showServerInfo, bool showLines, bool alphaBackground, bool showBackground, string backgroundImgPath, 
            MainForm mainForm, int idGenerator, int regionsIdGenerator, List<SpawnerInfoData> spawnerOverrideTemplates, bool bUseUTCTime, string Day0, float globalTransitionMinZ, string AdditionalCmdLineParams, 
            Dictionary<string, string> OverrideShooterGameModeDefaultGameIni, DateTime lastImageOverride, bool showDiscoZoneInfo, string discoZonesImagePath, List<ShipPathData> shipPaths, int shipPathsIdGenerator,
            bool showShipPathsInfo, string modIDs, bool showIslandNames, bool showForeground, string foregroundImgPath, string globalGameplaySetup,
            List<ServerTemplateData> serverTemplates, bool bIsFinalExport, string MapImageURL,string AuthListURL,
			string WorldAtlasPassword, float columnUTCOffset)
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

                if(!bIsFinalExport)
                {
                    Data.servers.Add(new ServerData().SetFrom(server, gridSize, server.gridX, server.gridY, server.MachineIdTag, server.ip, server.port,
                         server.gamePort, server.seamlessDataPort, serverIslands, serverDiscos, serverSpawnRegions, mainForm, server.isHomeServer, server.AdditionalCmdLineParams, server.OverrideShooterGameModeDefaultGameIni, server.name, server.floorZDist,
                         server.transitionMinZ, server.utcOffset, server.OceanDinoDepthEntriesOverride, server.oceanFloatsamCratesOverride,
                         server.treasureMapLootTablesOverride, server.lastModifiedUTC, server.lastImageOverrideUTC, server.GlobalBiomeSeamlessServerGridPreOffsetValues, server.GlobalBiomeSeamlessServerGridPreOffsetValuesOceanWater,
                         server.islandLocked, server.discoLocked, server.pathsLocked, server.extraSublevels, server.oceanEpicSpawnEntriesOverrideTemplateName, server.NPCShipSpawnEntriesOverrideTemplateName, server.regionOverrides,
                         server.waterColorR, server.waterColorG, server.waterColorB, server.skyStyleIndex, server.ServerCustomDatas1, server.ServerCustomDatas2, server.ClientCustomDatas1, server.ClientCustomDatas2, server.serverTemplateName, server.OceanEpicSpawnEntriesOverrideValues));
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
                        server.gamePort, server.seamlessDataPort, serverIslands, serverDiscos, serverSpawnRegions, mainForm, server.isHomeServer, server.AdditionalCmdLineParams, server.OverrideShooterGameModeDefaultGameIni, server.name, server.floorZDist,
                        server.transitionMinZ, server.utcOffset, server.OceanDinoDepthEntriesOverride, server.oceanFloatsamCratesOverride,
                        server.treasureMapLootTablesOverride, server.lastModifiedUTC, server.lastImageOverrideUTC, server.GlobalBiomeSeamlessServerGridPreOffsetValues, server.GlobalBiomeSeamlessServerGridPreOffsetValuesOceanWater,
                        server.islandLocked, server.discoLocked, server.pathsLocked, overridenExtraSublevels, server.oceanEpicSpawnEntriesOverrideTemplateName, server.NPCShipSpawnEntriesOverrideTemplateName, server.regionOverrides,
                        server.waterColorR, server.waterColorG, server.waterColorB, server.skyStyleIndex, server.ServerCustomDatas1, server.ServerCustomDatas2, server.ClientCustomDatas1, server.ClientCustomDatas2, server.serverTemplateName, server.OceanEpicSpawnEntriesOverrideValues);

                    //Apply template
                    if(!string.IsNullOrEmpty(server.serverTemplateName))
                    {
                        ServerTemplateData serverTemplate = mainForm.currentProject.GetServerTemplateByName(server.serverTemplateName);
                        if(serverTemplate != null)
                        {
                            //Overrides
                            exportServerObj.floorZDist = server.floorZDist != 0 ? server.floorZDist : serverTemplate.floorZDist;
                            exportServerObj.transitionMinZ = server.transitionMinZ != 0 ? server.transitionMinZ : serverTemplate.transitionMinZ;
                            exportServerObj.oceanEpicSpawnEntriesOverrideTemplateName = !string.IsNullOrEmpty(server.oceanEpicSpawnEntriesOverrideTemplateName) ? server.oceanEpicSpawnEntriesOverrideTemplateName : serverTemplate.oceanEpicSpawnEntriesOverrideTemplateName;
                            exportServerObj.NPCShipSpawnEntriesOverrideTemplateName = !string.IsNullOrEmpty(server.NPCShipSpawnEntriesOverrideTemplateName) ? server.NPCShipSpawnEntriesOverrideTemplateName : serverTemplate.NPCShipSpawnEntriesOverrideTemplateName;
                            exportServerObj.waterColorR = server.waterColorR != 0 ? server.waterColorR : serverTemplate.waterColorR;
                            exportServerObj.waterColorG = server.waterColorG != 0 ? server.waterColorG : serverTemplate.waterColorG;
                            exportServerObj.waterColorB = server.waterColorB != 0 ? server.waterColorB : serverTemplate.waterColorB;
                            exportServerObj.skyStyleIndex = server.skyStyleIndex != 0 ? server.skyStyleIndex : serverTemplate.skyStyleIndex;
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
                        }
                    }
                    Data.servers.Add(exportServerObj);
                }
            }

            Data.MetaWorldURL = MetaWorldURL;
            Data.WorldFriendlyName = WorldFriendlyName;
            Data.WorldAtlasId = WorldAtlasId;
            Data.coordsScaling = coordsScaling;
            Data.showServerInfo = showServerInfo;
            Data.showDiscoZoneInfo = showDiscoZoneInfo;
            Data.showShipPathsInfo = showShipPathsInfo;
            Data.showLines = showLines;
            Data.alphaBackground = alphaBackground;
            Data.showBackground = showBackground;
            Data.showForeground = showForeground;
            Data.backgroundImgPath = backgroundImgPath;
            Data.foregroundImgPath = foregroundImgPath;
            Data.idGenerator = idGenerator;
            Data.regionsIdGenerator = regionsIdGenerator;
            Data.spawnerOverrideTemplates = spawnerOverrideTemplates;
            Data.bUseUTCTime = bUseUTCTime;
            Data.columnUTCOffset = columnUTCOffset;
            Data.globalTransitionMinZ = globalTransitionMinZ;
            Data.AdditionalCmdLineParams = AdditionalCmdLineParams;
            Data.OverrideShooterGameModeDefaultGameIni = OverrideShooterGameModeDefaultGameIni;
            Data.Day0 = Day0;
            Data.discoZonesImagePath = discoZonesImagePath;
            Data.lastImageOverride = lastImageOverride;
            Data.ModIDs = modIDs;
            Data.MapImageURL = MapImageURL;
            Data.AuthListURL = AuthListURL;
            if(shipPaths != null)
                Data.shipPaths = shipPaths;
            Data.shipPathsIdGenerator = shipPathsIdGenerator;
            Data.showIslandNames = showIslandNames;
            Data.globalGameplaySetup = globalGameplaySetup;
            if (serverTemplates == null)
                serverTemplates = new List<ServerTemplateData>();
            Data.serverTemplates = serverTemplates.ToList();
			Data.WorldAtlasPassword = WorldAtlasPassword;

            return Data;
        }
    }
    public class Project
    {
        public bool successfullyLoaded;
        public List<IslandInstanceData> islandInstances = new List<IslandInstanceData>();
        public List<Server> servers = new List<Server>();
        public List<DiscoveryZoneData> discoZones = new List<DiscoveryZoneData>();
        public List<SpawnRegionData> spawnRegions = new List<SpawnRegionData>();
        public List<ServerTemplateData> serverTemplates = new List<ServerTemplateData>();

        public int numOfCellsX = 5;
        public int numOfCellsY = 4;

        public float cellSize = 200000;
        public float columnUTCOffset = 0.0f;

        public string Day0 = "";
        public bool bUseUTCTime = false;
        public float globalTransitionMinZ = 0.0f;
        public string AdditionalCmdLineParams;
        public Dictionary<string, string> OverrideShooterGameModeDefaultGameIni = new Dictionary<string, string>();
        public string MetaWorldURL = "";
        public string WorldFriendlyName = "AtlasWorld";
        public string WorldAtlasId = "";
        public string AuthListURL = "";
        public string WorldAtlasPassword = "";
        public string ModIDs = "";
        public string MapImageURL = "";
        public string BaseServerArgs = "";

        public string LocalS3URL = "";
        public string LocalS3AccessKeyId = "";
        public string LocalS3SecretKey = "";
        public string LocalS3BucketName = "";
        public string LocalS3Region = "";
        public string globalGameplaySetup = "";
        public TribeLogConfigInfo TribeLogConfig = new TribeLogConfigInfo();
        public SharedLogConfigInfo SharedLogConfig = new SharedLogConfigInfo();
        public BackupConfigInfo TravelDataConfig = new BackupConfigInfo();
        public List<DatabaseConnectionInfo> DatabaseConnections = new List<DatabaseConnectionInfo>();

        public float coordsScaling = 0.01f;
        public bool showServerInfo = true;
        public bool showDiscoZoneInfo = true;
        public bool showShipPathsInfo = true;
        public bool showIslandNames = true;
        public bool disableImageExporting = false;
        public bool showLines = true;
        public bool alphaBackground = false;
        public bool showBackground = false;
        public bool showForeground = false;
        public string backgroundImgPath = null;
        public string foregroundImgPath = null;

        public int idGenerator = 0;
        public int regionsIdGenerator = 0;
        public int shipPathsIdGenerator = 0;
        public DateTime LastImageOverrideUTC;

        public List<ShipPathData> shipPaths = new List<ShipPathData>();

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


            AtlasGridData ProjectObj = new AtlasGridData().SetFromData(cellSize, servers, islandInstances, discoZones, spawnRegions, WorldAtlasId, WorldFriendlyName, MetaWorldURL, 
                coordsScaling, showServerInfo, showLines, alphaBackground, showBackground, backgroundImgPath, mainForm, idGenerator, regionsIdGenerator, mainForm.spawners.spawnersInfo, bUseUTCTime, 
                Day0, globalTransitionMinZ, AdditionalCmdLineParams, OverrideShooterGameModeDefaultGameIni, LastImageOverrideUTC, showDiscoZoneInfo, discoZonesImagePath, shipPaths, 
                shipPathsIdGenerator, showShipPathsInfo, ModIDs, showIslandNames, showForeground, foregroundImgPath, globalGameplaySetup, serverTemplates, bIsFinalExport, MapImageURL, AuthListURL,
				WorldAtlasPassword, columnUTCOffset);
            ProjectObj.BaseServerArgs = BaseServerArgs;
            ProjectObj.totalGridsX = numOfCellsX;
            ProjectObj.totalGridsY = numOfCellsY;
            if (!bIsFinalExport)
            {
                ProjectObj.LocalS3URL = LocalS3URL;
                ProjectObj.LocalS3AccessKeyId = LocalS3AccessKeyId;
                ProjectObj.LocalS3SecretKey = LocalS3SecretKey;
                ProjectObj.LocalS3BucketName = LocalS3BucketName;
                ProjectObj.LocalS3Region = LocalS3Region;
                ProjectObj.TribeLogConfig = TribeLogConfig;
                ProjectObj.SharedLogConfig = SharedLogConfig;
                ProjectObj.TravelDataConfig = TravelDataConfig;
                ProjectObj.DatabaseConnections = DatabaseConnections;
            }
            else
            {
                ProjectObj.LocalS3URL = null;
                ProjectObj.LocalS3AccessKeyId = null;
                ProjectObj.LocalS3SecretKey = null;
                ProjectObj.LocalS3BucketName = null;
                ProjectObj.LocalS3Region = null;
                ProjectObj.TribeLogConfig = null;
                ProjectObj.SharedLogConfig = null;
                ProjectObj.TravelDataConfig = null;
                ProjectObj.DatabaseConnections = null;
                ProjectObj.serverTemplates.Clear();
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
                    s.AdditionalCmdLineParams = deserializedServer.AdditionalCmdLineParams;
                    s.OverrideShooterGameModeDefaultGameIni = deserializedServer.OverrideShooterGameModeDefaultGameIni;
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
                    s.skyStyleIndex = deserializedServer.skyStyleIndex;
                    s.ServerCustomDatas1 = deserializedServer.ServerCustomDatas1;
                    s.ServerCustomDatas2 = deserializedServer.ServerCustomDatas2;
                    s.ClientCustomDatas1 = deserializedServer.ClientCustomDatas1;
                    s.ClientCustomDatas2 = deserializedServer.ClientCustomDatas2;
                    s.oceanFloatsamCratesOverride = deserializedServer.oceanFloatsamCratesOverride;
                    s.treasureMapLootTablesOverride = deserializedServer.treasureMapLootTablesOverride;
                    s.lastModifiedUTC = deserializedServer.lastModified;
                    s.lastImageOverrideUTC = deserializedServer.lastImageOverride;
                    s.serverTemplateName = deserializedServer.serverTemplateName;
                    if (s.serverTemplateName == null)
                        s.serverTemplateName = "";
                    if (s.floorZDist <= 0)
                        s.floorZDist = 0;
                    s.islandLocked = deserializedServer.islandLocked;
                    s.discoLocked = deserializedServer.discoLocked;
                    s.pathsLocked = deserializedServer.pathsLocked;
                    s.extraSublevels = deserializedServer.extraSublevels;
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
                }

                numOfCellsX = maxX + 1;
                numOfCellsY = maxY + 1;

                WorldFriendlyName = deserializedProject.WorldFriendlyName;
                WorldAtlasId = deserializedProject.WorldAtlasId;
                AuthListURL = deserializedProject.AuthListURL;
                MetaWorldURL = deserializedProject.MetaWorldURL;
                coordsScaling = deserializedProject.coordsScaling;
                showServerInfo = deserializedProject.showServerInfo;
                showDiscoZoneInfo = deserializedProject.showDiscoZoneInfo;
                showIslandNames = deserializedProject.showIslandNames;
                showShipPathsInfo = deserializedProject.showShipPathsInfo;
                showLines = deserializedProject.showLines;
                alphaBackground = deserializedProject.alphaBackground;
                showBackground = deserializedProject.showBackground;
                showForeground = deserializedProject.showForeground;
                backgroundImgPath = deserializedProject.backgroundImgPath;
                foregroundImgPath = deserializedProject.foregroundImgPath;
                discoZonesImagePath = deserializedProject.discoZonesImagePath;
                ModIDs = deserializedProject.ModIDs;
                MapImageURL = deserializedProject.MapImageURL;
                BaseServerArgs = deserializedProject.BaseServerArgs;
                LocalS3URL = deserializedProject.LocalS3URL;
                LocalS3AccessKeyId = deserializedProject.LocalS3AccessKeyId;
                LocalS3SecretKey = deserializedProject.LocalS3SecretKey;
                LocalS3BucketName = deserializedProject.LocalS3BucketName;
                LocalS3Region = deserializedProject.LocalS3Region;
                globalGameplaySetup = deserializedProject.globalGameplaySetup;
                TribeLogConfig = deserializedProject.TribeLogConfig;
                TravelDataConfig = deserializedProject.TravelDataConfig;
                SharedLogConfig = deserializedProject.SharedLogConfig;
                DatabaseConnections = deserializedProject.DatabaseConnections;

                bUseUTCTime = deserializedProject.bUseUTCTime;
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
                        foreach (BezierNodeData bezierNode in shipPath.Nodes)
                            bezierNode.shipPath = shipPath;
                    }
                }
                shipPathsIdGenerator = deserializedProject.shipPathsIdGenerator;
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
    }
}
