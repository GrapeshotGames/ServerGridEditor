using System;
using System.Drawing;
using AtlasGridDataLibrary;


namespace ServerGridEditor
{
    public static class BezierNodeEx
    {
        public static Rectangle GetRect(this BezierNodeData Data, Project currentProject)
        {
            if (currentProject == null)
                return new Rectangle();

            float relativeX = GetBezierNodeSize(currentProject) * currentProject.coordsScaling;
            float relativeY = relativeX;

            return new Rectangle((int)Math.Round(Data.worldX * currentProject.coordsScaling - relativeX / 2f), (int)Math.Round(Data.worldY * currentProject.coordsScaling - relativeY / 2f), (int)Math.Round(relativeX), (int)Math.Round(relativeY));
        }

        public static bool ContainsPoint(this BezierNodeData Data, Point p, MainForm mainForm)
        {
            Rectangle Rect = Data.GetRect(mainForm.currentProject);

            PointF rotatedP = StaticHelpers.RotatePointAround(p, new PointF(Rect.Left + Rect.Width / 2.0f, Rect.Top + Rect.Height / 2.0f), -Data.rotation);
            p.X = (int)rotatedP.X;
            p.Y = (int)rotatedP.Y;

            return Rect.Contains(p);
        }

        public static float GetBezierNodeSize(Project currentProject)
        {
            return currentProject.cellSize * MainForm.bezierNodeRatio;
        }

        public static BezierNodeData GetNextNode(this BezierNodeData Data)
        {
            int idx = Data.shipPath.Nodes.IndexOf(Data) + 1;

            if (idx == Data.shipPath.Nodes.Count)
                return Data.shipPath.Nodes[0];

            if (idx < 0 || idx > Data.shipPath.Nodes.Count)
                return null;

            return Data.shipPath.Nodes[idx];
        }

        public static BezierNodeData GetPrevNode(this BezierNodeData Data)
        {
            int idx = Data.shipPath.Nodes.IndexOf(Data) - 1;

            if (idx == -1)
                return Data.shipPath.Nodes[Data.shipPath.Nodes.Count - 1];

            if (idx < 0 || idx >= Data.shipPath.Nodes.Count)
                return null;

            return Data.shipPath.Nodes[idx];
        }

        public static PointF GetNextControlPoint(this BezierNodeData Data)
        {
            PointF controlPoint = new PointF(Data.worldX + Data.controlPointsDistance, Data.worldY);
            return StaticHelpers.RotatePointAround(controlPoint, new PointF(Data.worldX, Data.worldY), Data.rotation);
        }

        public static PointF GetPrevControlPoint(this BezierNodeData Data)
        {
            PointF controlPoint = new PointF(Data.worldX - Data.controlPointsDistance, Data.worldY);
            return StaticHelpers.RotatePointAround(controlPoint, new PointF(Data.worldX, Data.worldY), Data.rotation);
        }
    }

    public static class ShipPathEx
    {
        public static ShipPathData SetFrom(this ShipPathData Data, MainForm mainForm, float worldX, float worldY)
        {
            float nodeSize = BezierNodeEx.GetBezierNodeSize(mainForm.currentProject);

            Data.Nodes.Add(new BezierNodeData() { worldX = worldX - nodeSize * 2, worldY = worldY + nodeSize, rotation = 0, shipPath = Data, controlPointsDistance = BezierNodeEx.GetBezierNodeSize(mainForm.currentProject) });
            Data.Nodes.Add(new BezierNodeData() { worldX = worldX, worldY = worldY, rotation = 0, shipPath = Data, controlPointsDistance = BezierNodeEx.GetBezierNodeSize(mainForm.currentProject) });
            Data.Nodes.Add(new BezierNodeData() { worldX = worldX + nodeSize * 2, worldY = worldY + nodeSize, rotation = 0, shipPath = Data, controlPointsDistance = BezierNodeEx.GetBezierNodeSize(mainForm.currentProject) });
            Data.PathId = mainForm.currentProject.GenerateNewShipPathId();

            return Data;
        }

        public static bool DeleteNode(this ShipPathData Data, BezierNodeData nodeToDelete)
        {
            if (Data.Nodes.Count <= 2)
                return false;

            int idx = Data.Nodes.IndexOf(nodeToDelete);
            if(idx >= 0)
                Data.Nodes.RemoveAt(idx);

            return true;
        }

        public static BezierNodeData AddNode(this ShipPathData Data, BezierNodeData afterNode)
        {
            int idx = Data.Nodes.IndexOf(afterNode);
            if (idx >= 0)
            {
                BezierNodeData nextNode = afterNode.GetNextNode();
                float midX = (afterNode.worldX + nextNode.worldX) / 2;
                float midY = (afterNode.worldY + nextNode.worldY) / 2;
                BezierNodeData newNode = new BezierNodeData() { worldX = midX, worldY = midY, rotation = 0, shipPath = Data/*, mainForm.currentProject*/ };
                Data.Nodes.Insert(idx + 1, newNode);
            }

            return null;
        }
    }
}
