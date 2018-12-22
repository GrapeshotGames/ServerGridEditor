using AtlasGridDataLibrary;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerGridEditor
{
    public class Spawners
    {
        public List<SpawnerInfoData> spawnersInfo = new List<SpawnerInfoData>();

        public void ClearSpawners()
        {
            spawnersInfo.Clear();
        }

        public SpawnerInfoData GetSpawnerInfoByName(string Name)
        {
            return spawnersInfo.Find((SpawnerInfoData s) => { return s.Name == Name; });
        }

        public bool AddSpawnerInfo(SpawnerInfoData spawnerInfoToAdd)
        {
            if (GetSpawnerInfoByName(spawnerInfoToAdd.Name) != null)
                return false;

            spawnersInfo.Add(spawnerInfoToAdd);
            return true;
        }

        public string Serialize()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }

        public void SaveToFile(string fileName)
        {
            File.WriteAllText(fileName, Serialize());
        }
    }
}
