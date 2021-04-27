using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            if (Data is ShipPathNode)
            {
                ShipPathNode shipPathNode = (ShipPathNode)Data;
                int idx = shipPathNode.shipPath.Nodes.IndexOf(shipPathNode) + 1;

                if (idx == shipPathNode.shipPath.Nodes.Count)
                    return shipPathNode.shipPath.Nodes[0];

                if (idx < 0 || idx > shipPathNode.shipPath.Nodes.Count)
                    return null;

                return shipPathNode.shipPath.Nodes[idx];
            }
            else if (Data is TradeWindNode)
            {
                TradeWindNode tradeWindNode = (TradeWindNode)Data;
                int idx = tradeWindNode.tradeWind.Nodes.IndexOf(tradeWindNode) + 1;

                if (idx == tradeWindNode.tradeWind.Nodes.Count)
                    return tradeWindNode.tradeWind.Nodes[0];

                if (idx < 0 || idx > tradeWindNode.tradeWind.Nodes.Count)
                    return null;

                return tradeWindNode.tradeWind.Nodes[idx];
            }

            return null;
        }

        public static BezierNodeData GetPrevNode(this BezierNodeData Data)
        {
            if (Data is ShipPathNode)
            {
                ShipPathNode shipPathNode = (ShipPathNode)Data;
                int idx = shipPathNode.shipPath.Nodes.IndexOf(shipPathNode) - 1;

                if (idx == -1)
                    return shipPathNode.shipPath.Nodes[shipPathNode.shipPath.Nodes.Count - 1];

                if (idx < 0 || idx >= shipPathNode.shipPath.Nodes.Count)
                    return null;

                return shipPathNode.shipPath.Nodes[idx];
            }
            else if (Data is TradeWindNode)
            {
                TradeWindNode tradeWindNode = (TradeWindNode)Data;
                int idx = tradeWindNode.tradeWind.Nodes.IndexOf(tradeWindNode) - 1;

                if (idx == -1)
                    return tradeWindNode.tradeWind.Nodes[tradeWindNode.tradeWind.Nodes.Count - 1];

                if (idx < 0 || idx >= tradeWindNode.tradeWind.Nodes.Count)
                    return null;

                return tradeWindNode.tradeWind.Nodes[idx];
            }
            return null;
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


    public static class SplinePathDataEx
    {
        public static bool DeleteNode(this SplinePathData Data, BezierNodeData nodeToDelete)
        {
            if (Data is ShipPathData)
            {
                ShipPathData shipPath = (ShipPathData)Data;
                if (shipPath.Nodes.Count <= 2)
                    return false;

                int idx = shipPath.Nodes.IndexOf((ShipPathNode)nodeToDelete);
                if (idx >= 0)
                    shipPath.Nodes.RemoveAt(idx);

                return true;
            }
            else if (Data is TradeWindData)
            {
                TradeWindData tradeWind = (TradeWindData)Data;
                if (tradeWind.Nodes.Count <= 2)
                    return false;

                int idx = tradeWind.Nodes.IndexOf((TradeWindNode)nodeToDelete);
                if (idx >= 0)
                    tradeWind.Nodes.RemoveAt(idx);

                return true;
            }
            return false;
        }
    }

    public static class ShipPathEx
    {
        public static ShipPathData SetFrom(this ShipPathData Data, MainForm mainForm, float worldX, float worldY)
        {
            float nodeSize = BezierNodeEx.GetBezierNodeSize(mainForm.currentProject);

            Data.Nodes.Add(new ShipPathNode() { worldX = worldX - nodeSize * 2, worldY = worldY + nodeSize, rotation = 0, shipPath = Data, controlPointsDistance = BezierNodeEx.GetBezierNodeSize(mainForm.currentProject) });
            Data.Nodes.Add(new ShipPathNode() { worldX = worldX, worldY = worldY, rotation = 0, shipPath = Data, controlPointsDistance = BezierNodeEx.GetBezierNodeSize(mainForm.currentProject) });
            Data.Nodes.Add(new ShipPathNode() { worldX = worldX + nodeSize * 2, worldY = worldY + nodeSize, rotation = 0, shipPath = Data, controlPointsDistance = BezierNodeEx.GetBezierNodeSize(mainForm.currentProject) });
            Data.PathId = mainForm.currentProject.GenerateNewShipPathId();

            return Data;
        }

        public static BezierNodeData AddNode(this ShipPathData Data, BezierNodeData afterNode)
        {
            int idx = Data.Nodes.IndexOf((ShipPathNode)afterNode);
            if (idx >= 0)
            {
                BezierNodeData nextNode = afterNode.GetNextNode();
                float midX = (afterNode.worldX + nextNode.worldX) / 2;
                float midY = (afterNode.worldY + nextNode.worldY) / 2;
                BezierNodeData newNode = new ShipPathNode() { worldX = midX, worldY = midY, rotation = 0, shipPath = Data/*, mainForm.currentProject*/ };
                Data.Nodes.Insert(idx + 1, (ShipPathNode)newNode);
            }

            return null;
        }
    }

    public static class TradeWindEx
    {
        public static TradeWindData SetFrom(this TradeWindData Data, MainForm mainForm, float worldX, float worldY)
        {
            float nodeSize = BezierNodeEx.GetBezierNodeSize(mainForm.currentProject);

            Data.Nodes.Add(new TradeWindNode() { worldX = worldX - nodeSize * 2, worldY = worldY + nodeSize, rotation = 0, tradeWind = Data, controlPointsDistance = BezierNodeEx.GetBezierNodeSize(mainForm.currentProject) });
            Data.Nodes.Add(new TradeWindNode() { worldX = worldX, worldY = worldY, rotation = 0, tradeWind = Data, controlPointsDistance = BezierNodeEx.GetBezierNodeSize(mainForm.currentProject) });
            Data.Nodes.Add(new TradeWindNode() { worldX = worldX + nodeSize * 2, worldY = worldY + nodeSize, rotation = 0, tradeWind = Data, controlPointsDistance = BezierNodeEx.GetBezierNodeSize(mainForm.currentProject) });
            Data.PathId = mainForm.currentProject.GenerateNewTradeWindId();

            return Data;
        }

        public static BezierNodeData AddNode(this TradeWindData Data, BezierNodeData afterNode)
        {
            int idx = Data.Nodes.IndexOf((TradeWindNode)afterNode);
            if (idx >= 0)
            {
                BezierNodeData nextNode = afterNode.GetNextNode();
                float midX = (afterNode.worldX + nextNode.worldX) / 2;
                float midY = (afterNode.worldY + nextNode.worldY) / 2;
                BezierNodeData newNode = new TradeWindNode() { worldX = midX, worldY = midY, rotation = 0, tradeWind = Data/*, mainForm.currentProject*/ };
                Data.Nodes.Insert(idx + 1, (TradeWindNode)newNode);
            }

            return null;
        }
    }
}
