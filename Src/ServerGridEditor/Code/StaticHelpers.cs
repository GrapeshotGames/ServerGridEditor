using System;
using System.Windows.Forms;
using System.Drawing;
using System.IO;

namespace ServerGridEditor
{
    static class StaticHelpers
    {
        public static object BitmapCacheOption { get; private set; }

        public static void ForceNumericKeypress(object sender, KeyPressEventArgs e, bool allowDecimal = true)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (!allowDecimal || e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        public static float GetAngleOfPoint(Point center, Point p)
        {
            float xDiff = p.X - center.X;
            float yDiff = p.Y - center.Y;
            return (float)(Math.Atan2(yDiff, xDiff) * 180f / Math.PI);
        }

        public static float DegreeToRadian(float angle)
        {
            return (float)Math.PI * angle / 180.0f;
        }

        public static float RadianToDegree(float angle)
        {
            return angle * (180.0f / (float)Math.PI);
        }

        public static PointF RotatePointAround(PointF p, PointF axis, float angle)
        {
            float s = (float)Math.Sin(DegreeToRadian(angle));
            float c = (float)Math.Cos(DegreeToRadian(angle));

            // translate point back to origin:
            p.X -= axis.X;
            p.Y -= axis.Y;

            // rotate point
            float xnew = p.X * c - p.Y * s;
            float ynew = p.X * s + p.Y * c;

            // translate point back:
            p.X = xnew + axis.X;
            p.Y = ynew + axis.Y;

            return p;
        }

        public static string NormalizePath(string path)
        {
            return Path.GetFullPath(path)
                       .TrimEnd(Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar)
                       .ToUpperInvariant();
        }

        public static float GetDistance(PointF p1, PointF p2)
        {
            return GetDistance(p1.X, p1.Y, p2.X, p2.Y);
        }

        public static float GetDistance(float x1, float y1, float x2, float y2)
        {
            return (float)Math.Sqrt(Math.Pow((x2 - x1), 2) + Math.Pow((y2 - y1), 2));
        }
    }
}
