using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;
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
            var Points = new List<TransformationSpec>();
            var TileSize = new Size(ImagesConfig.Tiles.TileWidth, ImagesConfig.Tiles.TileHeight);
            var TileRect = new Rectangle(new Point(0, 0), TileSize);

            this.Reporter.WriteLine("Loading: " + Image.Filepath);
            var transformer = new ImageTransformer() {
                Source = System.Drawing.Image.FromFile(Image.Filepath),
                Reporter = this.Reporter,
                ImageHandler = this.ImageHandler
            };

            this.Reporter.WriteLine("Tiling...");

            //Coordinates
            Project.Range ZRange = Image.Range;
            Size ImageRect = transformer.Source.Size;
            //The area in pixels
            Rectangle PArea = this.ImageArea(Image.Area);
            var PAreaMax = new Point(PArea.X + PArea.Width, PArea.Y + PArea.Height);
            var Offset = new Point(PArea.Location.X * -1, PArea.Location.Y * -1);

            Int32 WidthTrans = ImageRect.Width / PArea.Width;
            Int32 HeightTrans = ImageRect.Height / PArea.Height;


            for (Int32 Zoom = ZRange.Minimum; Zoom <= ZRange.Maximum; Zoom++) {
                Int32 Scale = this.CRS.Scale(Zoom);

                Int32 W = TileSize.Width / Scale;
                Int32 H = TileSize.Height / Scale;

                Int32 xStart = ((PArea.X * Scale) / W);
                Int32 yStart = ((PArea.Y * Scale) / H);
                Int32 xEnd = ((PAreaMax.X * Scale) / W);
                Int32 yEnd = ((PAreaMax.Y * Scale) / H);

                for (Int32 X = xStart; X <= xEnd; X++) {
                    for (Int32 Y = yStart; Y <= yEnd; Y++) {
                        var TileZoom0 = new Rectangle(X * W, Y * H, W, H);
                        if (!TileZoom0.IntersectsWith(PArea)) continue;

                        Rectangle overlap = Overlap(TileZoom0, PArea);
                        var TileSource = new Rectangle(
                            new Point(overlap.X * WidthTrans, overlap.Y * HeightTrans),
                            new Size(overlap.Width * WidthTrans, overlap.Height * HeightTrans)                            );

                        Points.Add(new TransformationSpec() {
                            From = TileSource,
                            To = new Rectangle(0, 0, overlap.Width * Scale, overlap.Height * Scale),
                            TileX = X,
                            TileY = Y,
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


        private Rectangle ImageArea(Area area) {
            var minp = this.CRS.ToPoint(area.Min);
            var maxp = this.CRS.ToPoint(area.Max);

            return new Rectangle(minp.X, minp.Y, maxp.X - minp.X, maxp.Y - minp.Y);
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


        private class ImageTransformer {
            public System.Drawing.Image Source;
            public IReporter Reporter;
            public ImageHandler ImageHandler;

            public void Transform(TransformationSpec trans, ParallelLoopState State, Int64 Index) {
                this.Reporter.Progress((Int32)Index);
                ImageGate Gate = this.ImageHandler.Get(trans.TileX, trans.TileY, trans.TileZoom);

                System.Drawing.Image Destination = Gate.Get();
                ImageCutter.CutImage(this.Source, Destination, trans.From, trans.To);

                Gate.Set(ref Destination);
            }

            ~ImageTransformer() {
                this.Source.Dispose();
                this.Source = null;
                this.Reporter = null;
                this.ImageHandler = null;
                GC.Collect();
            }
        }
    }
}
