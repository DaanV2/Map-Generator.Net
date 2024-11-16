using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Map.CRS;
using Map.Images;
using Map.Project;
using Image = Map.Project.Image;

namespace Map.Process.Leaflet;
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
        //The area in coordinates of the image
        RectangleF PArea = this.ImageArea(Image.Area);

        Single WidthTrans = ImageRect.Width / PArea.Width;
        Single HeightTrans = ImageRect.Height / PArea.Height;

        for (Int32 Zoom = ZRange.Minimum; Zoom <= ZRange.Maximum; Zoom++) {
            this.Reporter.WriteLine($"Tiling zoom: {Zoom}");
            SizeF TileSizeAtScale = this.TileSize(Zoom);

            //To smal
            if (TileSizeAtScale.Width <= 0 || TileSizeAtScale.Height <= 0) {
                continue;
            }

            //Calculate the tile indexes the image occupies on this level
            (Int32 TileXStart, Int32 TileXEnd, Int32 TileYStart, Int32 TileYEnd) = this.TileIndexes(TileSizeAtScale, PArea);

            //Loop over all tiles
            for (Single X = TileXStart; X <= TileXEnd; X++) {
                for (Single Y = TileYStart; Y <= TileYEnd; Y++) {
                    //Get tile (area) At the specific coordinates
                    var TilePoint = new PointF(X * TileSizeAtScale.Width, Y * TileSizeAtScale.Height);
                    var TileArea = new RectangleF(TilePoint, TileSizeAtScale);

                    RectangleF overlap = Overlap(TileArea, PArea);
                    if (overlap.Height <= 0 || overlap.Width <= 0) {
                        continue;
                    }

                    //The pixel area of the image that need to go in the tile
                    var TileSource = new RectangleF(
                        new PointF((overlap.X - PArea.X) * WidthTrans, (overlap.Y - PArea.Y) * HeightTrans),
                        new SizeF(overlap.Width * WidthTrans, overlap.Height * HeightTrans)
                        );

                    //The relative area inside of the tile itself, used to convert to pixels
                    var TileTo = new RectangleF(
                        new PointF((overlap.X - TileArea.X), (overlap.Y - TileArea.Y)),
                        overlap.Size);

                    Points.Add(new TransformationSpec() {
                        From = TileSource,
                        To = this.TilePixelArea(TileTo, TileSizeAtScale),
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

    /// <summary>Calculates the size of the tile at the given index (expressed in coordinates)</summary>
    /// <param name="Zoom"></param>
    /// <returns></returns>
    public SizeF TileSize(Int32 Zoom) {
        Single Scale = this.CRS.Scale(Zoom);

        return new SizeF(this.TileSizeF.Width / Scale, this.TileSizeF.Height / Scale);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="TileSizeAtScale"></param>
    /// <param name="Area"></param>
    /// <returns></returns>
    public (Int32 xStart, Int32 xEnd, Int32 yStart, Int32 yEnd) TileIndexes(SizeF TileSizeAtScale, RectangleF Area) {
        //Calculate the tile indexes the image occupies on this level
        Int32 TileXStart = (Int32)(MathF.Floor(Area.X / TileSizeAtScale.Width));
        Int32 TileXEnd = (Int32)(MathF.Ceiling((Area.X + Area.Width) / TileSizeAtScale.Width));

        Int32 TileYStart = (Int32)(MathF.Floor(Area.Y / TileSizeAtScale.Height));
        Int32 TileYEnd = (Int32)(MathF.Ceiling((Area.Y + Area.Height) / TileSizeAtScale.Height));

        return (TileXStart, TileXEnd, TileYStart, TileYEnd);
    }

    /// <summary>Translates a tiles coordinate area to pixel area</summary>
    /// <param name="Coordinates"></param>
    /// <param name="TileSizeAtScale"></param>
    /// <returns></returns>
    public RectangleF TilePixelArea(RectangleF Coordinates, SizeF TileSizeAtScale) {
        Single WidthTrans = this.TileSizeF.Width / TileSizeAtScale.Width;
        Single HeightTrans = this.TileSizeF.Height / TileSizeAtScale.Height;

        return new RectangleF(
            new PointF(Coordinates.X * WidthTrans, Coordinates.Y * HeightTrans),
            new SizeF(Coordinates.Width * WidthTrans, Coordinates.Height * HeightTrans));
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
        var From = new PointF(Math.Max(A.Left, B.Left), Math.Max(A.Top, B.Top));
        var To = new PointF(Math.Min(A.Right, B.Right), Math.Min(A.Bottom, B.Bottom));

        return new RectangleF(From, new SizeF(To.X - From.X, To.Y - From.Y));
    }



    private class ImageTransformer {
        public System.Drawing.Image Source;
        public IReporter Reporter;
        public ImageHandler ImageHandler;


        [MethodImpl(MethodImplOptions.AggressiveOptimization)]
        public void Transform(TransformationSpec trans, ParallelLoopState State, Int64 Index) {
            this.Reporter.Progress((Int32)Index);
            ImageGate Gate = this.ImageHandler.Get(trans.TileX, trans.TileY, trans.TileZoom);

            System.Drawing.Image Destination = Gate.Get();
            ImageCutter.CutImage(this.Source, Destination, trans.From, trans.To);

            Task.Run(new Action(() => Gate.Set(ref Destination)));
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
