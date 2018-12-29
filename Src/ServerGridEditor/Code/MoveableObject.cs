using AtlasGridDataLibrary;
using System;
using System.Drawing;

namespace ServerGridEditor
{
    public static class MoveableObjectEx
    {
        public static Server GetCurrentServer(this MoveableObjectData Data, MainForm mainForm)
        {
            return mainForm.GetServerAtPoint(mainForm.UnrealToMapPoint(new PointF(Data.worldX, Data.worldY)));
        }

        public static void SetWorldLocation(this MoveableObjectData Data, MainForm mainForm, PointF NewLoc, bool preventDirtying = false)
        {
            Project currentProject = mainForm.currentProject;

            float OriginalX = Data.worldX;
            float OriginalY = Data.worldY;

            Data.worldX = NewLoc.X;
            Data.worldY = NewLoc.Y;

            //Clamp to map
            float maxWorldX = currentProject.numOfCellsX * currentProject.cellSize;
            float maxWorldY = currentProject.numOfCellsY * currentProject.cellSize;

            RectangleF Bounds = Data.GetBoundingBox(mainForm);
            Bounds.X /= currentProject.coordsScaling;
            Bounds.Y /= currentProject.coordsScaling;
            Bounds.Width /= currentProject.coordsScaling;
            Bounds.Height /= currentProject.coordsScaling;

            RectangleF MapArea = new RectangleF(0, 0, maxWorldX, maxWorldY);

            RectangleF AreaInMap = RectangleF.Intersect(Bounds, MapArea);

            PointF BoundsCenter = new PointF(Bounds.X + Bounds.Width / 2f, Bounds.Y + Bounds.Height / 2f);

            PointF MapCenter = new PointF(MapArea.X + MapArea.Width / 2f, MapArea.Y + MapArea.Height / 2f);

            if ((int)AreaInMap.Width < (int)Bounds.Width)
            {
                float clippedWidth = Bounds.Width - AreaInMap.Width;
                if (BoundsCenter.X < MapCenter.X)
                    Data.worldX += clippedWidth; // Clipped from the left
                else
                    Data.worldX -= clippedWidth;
            }

            if ((int)AreaInMap.Height < (int)Bounds.Height)
            {
                float clippedHeight = Bounds.Height - AreaInMap.Height;
                if (BoundsCenter.Y < MapCenter.Y)
                    Data.worldY += clippedHeight; // Clipped from the Right
                else
                    Data.worldY -= clippedHeight;
            }

            //Clamp center as well to avoid overshooting from the bounds clamping
            Data.worldX = Math.Max(0, Math.Min(maxWorldX, Data.worldX));
            Data.worldY = Math.Max(0, Math.Min(maxWorldY, Data.worldY));

            if (!preventDirtying && (Math.Abs(Data.worldX - OriginalX) > 0.01f || Math.Abs(Data.worldY - OriginalY) > 0.01f))
                Data.SetDirty(mainForm);
        }

        public static PointF GetMapLocation(this MoveableObjectData Data, MainForm mainForm)
        {
            return mainForm.UnrealToMapPoint(new PointF(Data.worldX, Data.worldY));
        }

        public static void SetDirty(this MoveableObjectData Data, MainForm mainForm)
        {
            Data.GetCurrentServer(mainForm).SetDirty();
        }

        public static Rectangle GetRect(this MoveableObjectData Data, MainForm mainForm)
        {
            if (Data is BezierNodeData)
                return ((BezierNodeData)Data).GetRect(mainForm.currentProject);
            else if (Data is DiscoveryZoneData)
                return ((DiscoveryZoneData)Data).GetRect(mainForm.currentProject);
            else if (Data is IslandInstanceData)
                return ((IslandInstanceData)Data).GetRect(mainForm.currentProject, mainForm.islands);

            return new Rectangle();
        }

        public static Rectangle GetBoundingBox(this MoveableObjectData Data, MainForm mainForm)
        {
            Rectangle Rect = Data.GetRect(mainForm/*.currentProject*/);

            //Collect corner points
            Point TopLeft = Rect.Location;
            Point TopRight = new Point(Rect.Location.X + Rect.Width, Rect.Location.Y);
            Point BottomLeft = new Point(Rect.Location.X, Rect.Location.Y + Rect.Height);
            Point BottomRight = new Point(Rect.Location.X + Rect.Width, Rect.Location.Y + Rect.Height);

            //Rotate corner points
            PointF Center = new PointF(Rect.Location.X + Rect.Width / 2f, Rect.Location.Y + Rect.Height / 2f);
            TopLeft = Point.Round(StaticHelpers.RotatePointAround(TopLeft, Center, Data.rotation));
            TopRight = Point.Round(StaticHelpers.RotatePointAround(TopRight, Center, Data.rotation));
            BottomLeft = Point.Round(StaticHelpers.RotatePointAround(BottomLeft, Center, Data.rotation));
            BottomRight = Point.Round(StaticHelpers.RotatePointAround(BottomRight, Center, Data.rotation));

            int minX = Math.Min(TopLeft.X, Math.Min(TopRight.X, Math.Min(BottomLeft.X, BottomRight.X)));
            int maxX = Math.Max(TopLeft.X, Math.Max(TopRight.X, Math.Max(BottomLeft.X, BottomRight.X)));
            int minY = Math.Min(TopLeft.Y, Math.Min(TopRight.Y, Math.Min(BottomLeft.Y, BottomRight.Y)));
            int maxY = Math.Max(TopLeft.Y, Math.Max(TopRight.Y, Math.Max(BottomLeft.Y, BottomRight.Y)));

            return new Rectangle(minX, minY, maxX - minX, maxY - minY);
        }
    }
}
