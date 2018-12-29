using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;

namespace AtlasGridDataLibrary
{
    public class ServerGrid_ServerOnlyData
    {
        public string LocalS3URL = "";
        public string LocalS3AccessKeyId = "";
        public string LocalS3SecretKey = "";
        public string LocalS3BucketName = "";
        public string LocalS3Region = "";
        public TribeLogConfigInfo TribeLogConfig = new TribeLogConfigInfo();
        public SharedLogConfigInfo SharedLogConfig = new SharedLogConfigInfo();
        public BackupConfigInfo TravelDataConfig = new BackupConfigInfo();
        public List<DatabaseConnectionInfo> DatabaseConnections = new List<DatabaseConnectionInfo>();

        public static AtlasGridData LoadAbsolutePath(string Path)
        {
            AtlasGridData LoadedConfig = new AtlasGridData();
            string JsonString = File.ReadAllText(Path);
            LoadedConfig = JsonConvert.DeserializeObject<AtlasGridData>(JsonString);
            return LoadedConfig;
        }

        //public static void SaveAbsolutePath(AtlasGridData config, string Path)
        //{
        //    string JsonData = JsonConvert.SerializeObject(config, Formatting.Indented, new JsonSerializerSettings
        //    {
        //        NullValueHandling = NullValueHandling.Ignore
        //    });
        //    File.WriteAllText(Path, JsonData);
        //}
    }

    public class SharedLogConfigData
    {
        [DefaultValue(60)]
        public int FetchRateSec = 60;

        [DefaultValue(900)]
        public int SnapshotCleanupSec = 900;

        [DefaultValue(1800)]
        public int SnapshotRateSec = 1800;

        [DefaultValue(48)]
        public int SnapshotExpirationHours = 48;
    }

    public class BackupConfigInfo
    {
        [DefaultValue("off")]
        public string BackupMode = "off";

        [DefaultValue(10)]
        public int MaxFileHistory = 10; // shared log and tribe log

        [DefaultValue("")]
        public string HttpBackupURL = "";

        [DefaultValue("")]
        public string HttpAPIKey = "";

        [DefaultValue("")]
        public string S3KeyPrefix = "";

        public void CopyFrom(BackupConfigInfo In)
        {
            BackupMode = In.BackupMode;
            MaxFileHistory = In.MaxFileHistory;
            HttpBackupURL = In.HttpBackupURL;
            HttpAPIKey = In.HttpAPIKey;
            S3KeyPrefix = In.S3KeyPrefix;
        }
    }

    public class TribeLogConfigInfo : BackupConfigInfo
    {
        [DefaultValue(1000)]
        public int MaxRedisEntries = 1000;

        public void CopyFrom(TribeLogConfigInfo In)
        {
            base.CopyFrom(In);
            MaxRedisEntries = In.MaxRedisEntries;
        }
    }

    public class SharedLogConfigInfo : BackupConfigInfo
    {
        [DefaultValue(60)]
        public int FetchRateSec = 60;

        [DefaultValue(900)]
        public int SnapshotCleanupSec = 900;

        [DefaultValue(1800)]
        public int SnapshotRateSec = 1800;

        [DefaultValue(48)]
        public int SnapshotExpirationHours = 48;

        public void CopyFrom(SharedLogConfigInfo In)
        {
            base.CopyFrom(In);
            FetchRateSec = In.FetchRateSec;
            SnapshotCleanupSec = In.SnapshotCleanupSec;
            SnapshotRateSec = In.SnapshotRateSec;
            SnapshotExpirationHours = In.SnapshotExpirationHours;
        }
    }

    public class DatabaseConnectionInfo
    {
        public string Name = "";    //public string Name { get; set; }
        public string URL = "";         //public string URL { get; set; }
        public int Port = 0;            //public int Port { get; set; }
        public string Password = "";    //public string Password { get; set; }
    }
}
