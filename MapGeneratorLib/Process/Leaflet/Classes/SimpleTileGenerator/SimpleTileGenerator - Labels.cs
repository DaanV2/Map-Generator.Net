using System;
using System.Collections.Generic;
using System.Drawing;
using Map.Images;
using Map.Project;
using Range = Map.Project.Range;

namespace Map.Process.Leaflet {
    public partial class SimpleTileGenerator :
        IGenerator<Specification> {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Value"></param>
        /// <param name="Spec"></param>
        public void Process(List<Label> Value, Specification Spec) {
            foreach (Label image in Value) {
                this.Process(image, Spec);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Value"></param>
        /// <param name="Spec"></param>
        public void Process(Label Value, Specification Spec) {
            var Point = this.CRS.ToPoint(Value.Point);
            Point.Y = Point.Y * -1;
            var TileSize = new Size(ImagesConfig.Tiles.TileWidth, ImagesConfig.Tiles.TileHeight);
            Range ZRange = Value.Range;

            for (Int32 Zoom = ZRange.Minimum; Zoom <= ZRange.Maximum; Zoom++) {
                Single Scale = this.CRS.Scale(Zoom);
                var ZoomPoint = new PointF(Point.X, Point.Y);

                Single W = TileSize.Width / Scale;
                Single H = TileSize.Height / Scale;

                Single tileX = ZoomPoint.X / W;
                Single tileY = ZoomPoint.Y / H;

                Single tileXF = MathF.Floor(tileX);
                Single tileYF = MathF.Floor(tileY);

                for (Single tX = 0; tX < 2; tX++) {
                    for (Single tY = 0; tY < 2; tY++) {
                        Int32 X = (Int32)(tileXF + tX);
                        Int32 Y = (Int32)(tileYF + tY);

                        var TextPos = new PointF(ZoomPoint.X - ((tileXF + tX) * W), ZoomPoint.Y - ((tileYF + tY) * H));
                        TextPos.X = (TextPos.X * TileSize.Width) / W;
                        TextPos.Y = (TextPos.Y * TileSize.Height) / H;

                        Console.WriteLine($"Label at: /{Zoom}/[{X},{Y}] => " + Value.Text);

                        ImageGate Tile = this.ImageHandler.Get(X, Y, Zoom);
                        System.Drawing.Image image = Tile.Get();
                        SizeF Size = ImageLabeler.SetLabel(image, TextPos, Value.Text);
                        Tile.Set(ref image);
                    }
                }


            }
        }
    }
}
