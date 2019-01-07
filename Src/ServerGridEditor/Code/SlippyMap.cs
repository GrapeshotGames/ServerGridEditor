using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ServerGridEditor.Code
{
    /// <summary>
    /// A SlippyMap is a tiled web map, such as OpenStreetMap.
    /// </summary>
    /// <remarks>
    /// For each zoom level, there exists a set of identically sized images
    /// (256x256 px by default) which make up the map. In the browser, a User
    /// can zoom and pan around the map. The JavaScript framework, Leaflet, is
    /// used to handle the streaming of tiles that represent a particular
    /// location (X, Y) for the current zoom level.
    /// 
    /// This class is used to generate such sets of tiles.
    /// </remarks>
    static class SlippyMap
    {
        public static readonly string extension = ".png";
        public static readonly int tileSize = 256;

        // largestSize needs to be a power of 2 and create a Bitmap that is
        // smaller than 2GB (GDI+ limit). 2^14 fits both the constraints.
        // @see https://stackoverflow.com/a/29176435
        public static readonly float largestSize = (float)Math.Pow(2, 14);

        public static void ExportSlippyMap(this MainForm mainForm, IDictionary<string, Island> islands, bool showLines, 
            bool showServerInfo, bool showDiscoZoneInfo, Image tile, TextureBrush tileBrush, Color backgroundColor,
            string outdir, Action<string> update, int maxZoom, bool overwrite)
        {
            Project project = mainForm.currentProject;

            if (project == null)
                throw new ArgumentNullException("project");

            float prevCoordsScaling = project.coordsScaling;
            int numCells = Math.Max(project.numOfCellsX, project.numOfCellsY);
            project.coordsScaling = largestSize / (project.cellSize * numCells);
            float cellSize = project.cellSize * project.coordsScaling;
            float maxX = project.numOfCellsX * cellSize;
            float maxY = project.numOfCellsY * cellSize;
            var mapSize = (int)Math.Ceiling(Math.Max(maxX, maxY));

            try
            {
                using (var map = new Bitmap(mapSize, mapSize))
                {
                    Graphics g = Graphics.FromImage(map);

                    MainForm.DrawMap(
                        mainForm, islands, g,
                        showLines: showLines, showServerInfo: showServerInfo, showDiscoZoneInfo : showDiscoZoneInfo, 
                        culling: null, alphaBackground: backgroundColor,
                        tile: tile, tileBrush: tileBrush, tileScale: 0,
                        translateH: 0, translateV: 0, forExport: true);

                    // map.Save(Path.Combine(outdir, "export.png"), ImageFormat.Png);

                    for (int zoomLevel = 0; zoomLevel <= maxZoom; zoomLevel++)
                    {
                        update?.Invoke(string.Format("Generating tiles for zoom level {0}", zoomLevel));
                        Task.Run(() => GenerateTiles(map, outdir, zoomLevel, overwrite)).Wait();
                    }
                }
            }
            finally
            {
                project.coordsScaling = prevCoordsScaling;
            }
        }

        static void GenerateTiles(Bitmap map, string outdir, int zoomLevel, bool overwrite)
        {
            string z = zoomLevel.ToString();
            int numTiles = (int)Math.Floor(Math.Pow(2, zoomLevel));
            int resize = tileSize * numTiles;

            if (resize > Math.Max(map.Width, map.Height))
                return;

            // Create all paths {outdir}\{z}\{x}
            for (int x = 0; x < numTiles; x++)
                Directory.CreateDirectory(Path.Combine(outdir, z, x.ToString()));

            using (var img = ResizeImage(map, resize, resize))
                for (int x = 0; x < numTiles; x++)
                    for (int y = 0; y < numTiles; y++)
                    {
                        var geom =
                            new Rectangle(x * tileSize, y * tileSize, tileSize, tileSize);

                        string filename =
                            Path.Combine(outdir, z, x.ToString(), y.ToString() + extension);

                        if (!overwrite && File.Exists(filename))
                        {
                            continue;
                        }

                        using (var tile = CropImage(img, geom))
                            tile.Save(filename);
                    }
        }

        /// <summary>
        /// Resize the image to the specified width and height.
        /// </summary>
        /// <param name="image">The image to resize.</param>
        /// <param name="width">The width to resize to.</param>
        /// <param name="height">The height to resize to.</param>
        /// <returns>The resized image.</returns>
        /// <see cref="https://stackoverflow.com/a/24199315"/>
        public static Bitmap ResizeImage(Image image, int width, int height)
        {
            var destRect = new Rectangle(0, 0, width, height);
            var destImage = new Bitmap(width, height);

            destImage.SetResolution(image.HorizontalResolution, image.VerticalResolution);

            using (var graphics = Graphics.FromImage(destImage))
            {
                graphics.CompositingMode = CompositingMode.SourceCopy;
                graphics.CompositingQuality = CompositingQuality.HighQuality;
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.SmoothingMode = SmoothingMode.HighQuality;
                graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

                using (var wrapMode = new ImageAttributes())
                {
                    wrapMode.SetWrapMode(WrapMode.TileFlipXY);
                    graphics.DrawImage(image, destRect, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, wrapMode);
                }
            }

            return destImage;
        }

        public static Bitmap CropImage(Image src, Rectangle area)
        {
            var dst = new Bitmap(area.Width, area.Height);

            using (Graphics g = Graphics.FromImage(dst))
                g.DrawImage(
                    src,
                    new Rectangle(0, 0, dst.Width, dst.Height),
                    area,
                    GraphicsUnit.Pixel
                );

            return dst;
        }
    }
}
