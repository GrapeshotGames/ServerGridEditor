using System;
using System.Drawing;
using AtlasGridDataLibrary;

namespace ServerGridEditor
{
    public static class DiscoveryZoneInstanceEx
    {
        public static DiscoveryZoneData SetFrom(this DiscoveryZoneData Data, string name, float worldX, float worldY, float sizeX, float sizeY, float rotation, int id)
        {
            Data.name = name;
            Data.worldX = worldX;
            Data.worldY = worldY;
            Data.rotation = rotation;
            Data.id = id;
            Data.sizeX = sizeX;
            Data.sizeY = sizeY;
            Data.xp = 0.0f;
            Data.startWorldX = worldX;
            Data.startWorldY = worldY;
            Data.sizeZ = 40000.0f;
            Data.explorerNoteIndex = 0;
            Data.allowSea = false;

            return Data;
        }

        public static Rectangle GetRect(this DiscoveryZoneData Data, Project currentProject)
        {
            if (currentProject == null)
                return new Rectangle();

            float relativeX = Data.sizeX * currentProject.coordsScaling;
            float relativeY = Data.sizeY * currentProject.coordsScaling;

            return new Rectangle((int)Math.Round(Data.worldX * currentProject.coordsScaling - relativeX / 2f), (int)Math.Round(Data.worldY * currentProject.coordsScaling - relativeY / 2f), (int)Math.Round(relativeX), (int)Math.Round(relativeY));
        }

        public static bool ContainsPoint(this DiscoveryZoneData Data, Point p, MainForm mainForm)
        {
            Rectangle Rect = Data.GetRect(mainForm.currentProject);

            PointF rotatedP = StaticHelpers.RotatePointAround(p, new PointF(Rect.Left + Rect.Width / 2.0f, Rect.Top + Rect.Height / 2.0f), -Data.rotation);
            p.X = (int)rotatedP.X;
            p.Y = (int)rotatedP.Y;

            return Rect.Contains(p);
        }
    }
}
