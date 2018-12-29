using System.IO;

namespace ServerGridEditor
{
    public class GlobalSettings
    {
        #region Singleton Access
        private static GlobalSettings _Instance;
        public static GlobalSettings Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new GlobalSettings();
                }
                return _Instance;
            }
        }
        #endregion

        public string BaseDir
        {
            get
            {
                return Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location) + "\\";//GetExecutingAssembly().Location) + "//";
            }
        }

        public string ProjectsDir
        {
            get
            {
                return BaseDir + "Projects\\";
            }
        }

        public string ExportDir
        {
            get
            {
                return BaseDir + "Export\\";
            }
        }


        public string BaseRepositoryDir
        {
            get
            {
                return BaseDir + "..\\..\\";
            }
        }
        public string GameDir
        {
            get
            {
                return BaseRepositoryDir + "Projects\\ShooterGame\\";
            }
        }

        public string GameMapsDir
        {
            get
            {
                return GameDir + "Content\\Maps\\";
            }
        }

        public string GameSeamlessMapsDir
        {
            get
            {
                return GameDir + "Content\\Maps\\SeamlessTest\\";
            }
        }
    }
}
