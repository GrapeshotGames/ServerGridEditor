using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerGridEditor
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
