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
            this.Reporter.WriteLine("Processing Images");
            this.Reporter.Progress(0, Value.Count);

            for (Int32 I = 0; I < Value.Count; I++) {
                Image Item = Value[I];

                this.Process(Item, Spec);
                this.Reporter.Progress(I, Value.Count);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Value"></param>
        /// <param name="Spec"></param>
        public void Process(Image Value, Specification Spec) {
            var Points = new List<Transformation>();
            var TileSize = new Size(ImagesConfig.Tiles.TileWidth, ImagesConfig.Tiles.TileHeight);

            var transformer = new ImageTransformer() {
                Source = System.Drawing.Image.FromFile(Value.Filepath),
                Reporter = this.Reporter,
                ImageHandler = this.ImageHandler
            };

            Area sourceArea = Value.Area;
            var Source = new Rectangle(new Point(0, 0), transformer.Source.Size);

            Project.Range ZoomRange = Value.Range;
            for (Int32 Zoom = ZoomRange.Minimum; Zoom < ZoomRange.Maximum; Zoom++) {
                Point Start = this.TilePoint(sourceArea.Min, Zoom, TileSize);
                Point End = this.TilePoint(sourceArea.Max, Zoom, TileSize);
                Int32 ScaleDiff = this.CRS.Scale(Zoom - ZoomRange.Minimum);

                for (Int32 X = Start.X; X < End.X; X += TileSize.Width) {
                    for (Int32 Y = Start.Y; Y < End.Y; Y += TileSize.Height) {
                        var destmin = new Point(X, Y);
                        var dest = new Rectangle(destmin, TileSize);

                        var trans = new Transformation {
                            To = dest,
                            TileX = X,
                            TileY = Y,
                            TileZoom = Zoom,
                            From = this.CRS.UnTransform(new Rectangle(destmin - (Size)Start, TileSize), ScaleDiff)
                        };
                    }
                }
            }

            this.Reporter.Progress(0, Points.Count);
            Parallel.ForEach(Points, transformer.Transform);
        }

        private Point TilePoint(Coordinate p, Int32 Zoom, Size TileSize) {
            var A = this.CRS.ToPoint(p, Zoom);
            Int32 X = (A.X / TileSize.Width);
            Int32 Y = (A.Y / TileSize.Height);

            return new Point(X * TileSize.Width, Y * TileSize.Height);
        }

        private class ImageTransformer {
            public System.Drawing.Image Source;
            public IReporter Reporter;
            public ImageHandler ImageHandler;

            public void Transform(Transformation trans, ParallelLoopState State, Int64 Index) {
                this.Reporter.Progress((Int32)Index);
                ImageGate Gate = this.ImageHandler.Get(trans.TileX, trans.TileY, trans.TileZoom);

                System.Drawing.Image Destination = Gate.Get();
                Map.Images.ImageCutter.CutImage(this.Source, Destination, trans.From, trans.To);

                Gate.Set(ref Destination);
            }
        }
    }
}
