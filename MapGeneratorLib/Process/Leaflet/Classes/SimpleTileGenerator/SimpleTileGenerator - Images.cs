using System;
using System.Collections.Generic;
using System.Drawing;
using Map.CRS;
using Map.Images;
using Map.Project;
using Image = Map.Project.Image;

namespace Map.Process.Leaflet {
    public partial class SimpleTileGenerator :
        IGenerator<Specification> {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Value"></param>
        /// <param name="Spec"></param>
        public void Process(List<Image> Value, Specification Spec) {
            this.Reporter.WriteLine("Processing Images...");
            this.Reporter.Progress(0, Value.Count);

            for (Int32 I = 0; I < Value.Count; I++) {
                Image Item = Value[I];

                this.Process(Item, Spec);
                this.Reporter.Progress(I, Value.Count);
            }

            this.Reporter.WriteLine("Processing Images Done!");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Image"></param>
        /// <param name="Spec"></param>
        public void Process(Image Image, Specification Spec) {
            var TileSize = new Size(ImagesConfig.Tiles.TileWidth, ImagesConfig.Tiles.TileHeight);
            var TileRect = new Rectangle(new Point(0, 0), TileSize);

            this.Reporter.WriteLine("Loading: " + Image.Filepath);
            var transformer = new ImageTransformer(
                System.Drawing.Image.FromFile(Image.Filepath),
                this.Reporter,
                this.ImageHandler);

            List<TransformationSpec> Points = transformer.TileImage(Image);

            //Coordinates
            Project.Range ZRange = Image.Range;
            Size ImageRect = transformer.Source.Size;
            //The area in pixels
            RectangleF PArea = this.ImageArea(Image.Area);
            var PAreaMax = new PointF(PArea.X + PArea.Width, PArea.Y + PArea.Height);

            Single WidthTrans = ImageRect.Width / PArea.Width;
            Single HeightTrans = ImageRect.Height / PArea.Height;

            for (Int32 Zoom = ZRange.Minimum; Zoom <= ZRange.Maximum; Zoom++) {
                Single Scale = this.CRS.Scale(Zoom);

                Single W = TileSize.Width / Scale;
                Single H = TileSize.Height / Scale;

                //To smal
                if (W < 1 || H < 1) {
                    continue;
                }

                Single xStart = (PArea.X / W);
                Single yStart = (PArea.Y / H);
                Single xEnd = (PAreaMax.X / W);
                Single yEnd = (PAreaMax.Y / H);

                for (Single X = xStart; X <= xEnd; X++) {
                    for (Single Y = yStart; Y <= yEnd; Y++) {
                        var TileZoom0 = new RectangleF(X * W, Y * H, W, H);
                        if (!TileZoom0.IntersectsWith(PArea)) continue;

                        RectangleF overlap = Overlap(TileZoom0, PArea);
                        var TileSource = new RectangleF(
                            new PointF((overlap.X - PArea.X) * WidthTrans, (overlap.Y - PArea.Y) * HeightTrans),
                            new SizeF(overlap.Width * WidthTrans, overlap.Height * HeightTrans)
                            );

                        Points.Add(new TransformationSpec() {
                            From = TileSource,
                            To = new RectangleF(overlap.X - TileZoom0.X, overlap.Y - TileZoom0.Y, overlap.Width * Scale, overlap.Height * Scale),
                            TileX = (Int32)X,
                            TileY = (Int32)Y,
                            TileZoom = Zoom
                        });
                    }
                }
            }


            this.Reporter.WriteLine("Transforming...");
            this.Reporter.Progress(0, Points.Count);

            for (Int32 I = 0; I < Points.Count; I++) {
                TransformationSpec Current = Points[I];

                transformer.Transform(Current, null, I);
            }
        }

        private RectangleF ImageArea(Area area) {
            var minp = this.CRS.ToPointF(area.Min);
            var maxp = this.CRS.ToPointF(area.Max);

            return new RectangleF(
                minp.X,
                minp.Y,
                maxp.X - minp.X,
                maxp.Y - minp.Y
            );
        }

        public static Rectangle Overlap(Rectangle A, Rectangle B) {
            Point point1 = A.Location;
            Point point2 = B.Location;

            var From = new Point(Math.Max(point1.X, point2.X), Math.Max(point1.Y, point2.Y));
            point1.Offset(A.Width, A.Height);
            point2.Offset(B.Width, B.Height);
            var To = new Point(Math.Min(point1.X, point2.X), Math.Min(point1.Y, point2.Y));

            return new Rectangle(From, (Size)(To - (Size)From));
        }

        public static RectangleF Overlap(RectangleF A, RectangleF B) {
            PointF point1 = A.Location;
            PointF point2 = B.Location;

            var From = new PointF(Math.Max(point1.X, point2.X), Math.Max(point1.Y, point2.Y));
            point1.X += A.Width;
            point1.Y += A.Height;
            point2.X += B.Width;
            point2.Y += B.Height;
            var To = new PointF(Math.Min(point1.X, point2.X), Math.Min(point1.Y, point2.Y));

            return new RectangleF(From, new SizeF(To.X - From.X, To.Y - From.Y));
        }
    }
}
