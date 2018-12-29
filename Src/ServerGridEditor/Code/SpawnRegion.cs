using System;
using System.Drawing;

namespace Atlas.ServerGridEditor
{
    public class SpawnRegion
    {
        public string name;
        [NonSerialized]
        public Point serverIdx;
    
        public SpawnRegion(string name, Point serverIdx)
        {
            this.name = name;
            this.serverIdx = serverIdx;
        }
    }
}
