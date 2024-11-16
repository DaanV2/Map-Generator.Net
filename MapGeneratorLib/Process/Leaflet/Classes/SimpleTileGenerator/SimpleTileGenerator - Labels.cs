using System;
using System.Collections.Generic;
using System.Drawing;
using Map.Images;
using Map.Project;
using Range = Map.Project.Range;

namespace Map.Process.Leaflet;
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
        var Point = this.CRS.ToPointF(Value.Point);
        Point.Y = Point.Y * -1;
        Range ZRange = Value.Range;

        for (Int32 Zoom = ZRange.Minimum; Zoom <= ZRange.Maximum; Zoom++) {
            SizeF TileSizeAtScale = this.TileSize(Zoom);
            var ZoomPoint = new PointF(Point.X, Point.Y);

            Single tileX = MathF.Floor(ZoomPoint.X / TileSizeAtScale.Width);
            Single tileY = MathF.Floor(ZoomPoint.Y / TileSizeAtScale.Height);

            for (Single tX = 0; tX < 2; tX++) {
                for (Single tY = 0; tY < 2; tY++) {
                    Int32 X = (Int32)(tileX + tX);
                    Int32 Y = (Int32)(tileY + tY);

                    var TilePoint = new PointF(X * TileSizeAtScale.Width, Y * TileSizeAtScale.Height);
                    var TextPos = new PointF(ZoomPoint.X - TilePoint.X, ZoomPoint.Y - TilePoint.Y);

                    Single WidthTrans = this.TileSizeF.Width / TileSizeAtScale.Width;
                    Single HeightTrans = this.TileSizeF.Height / TileSizeAtScale.Height;

                    var TextPixelPos = new PointF(TextPos.X * WidthTrans, TextPos.Y * HeightTrans);

                    Console.WriteLine($"Label at: /{Zoom}/[{X},{Y}] => " + Value.Text);

                    ImageGate Tile = this.ImageHandler.Get(X, Y, Zoom);
                    System.Drawing.Image image = Tile.Get();
                    SizeF Size = ImageLabeler.SetLabel(image, TextPixelPos, Value.Text);
                    Tile.Set(ref image);
                }
            }
        }
    }
}
