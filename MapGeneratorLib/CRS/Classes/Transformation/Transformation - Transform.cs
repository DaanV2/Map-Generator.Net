using System;
using System.Drawing;

namespace Map.CRS;
public partial class Transformation {
    /// <summary>
    /// 
    /// </summary>
    /// <param name="A"></param>
    /// <returns></returns>
    public SizeF Transform(SizeF A, Single Scale) {
        Single w = ((A.Width * this.A) + this.B) * Scale;
        Single h = ((A.Height * this.C) + this.D) * Scale;

        return new SizeF(w, h);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="A"></param>
    /// <param name="Scale"></param>
    /// <returns></returns>
    public PointF Transform(PointF A, Single Scale) {
        Single X = ((A.X * this.A) + this.B) * Scale;
        Single Y = ((A.Y * this.C) + this.D) * Scale;

        return new PointF(X, Y);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="A"></param>
    /// <param name="Scale"></param>
    /// <returns></returns>
    public Coordinate Transform(Coordinate A, Single Scale) {
        Double longitude = ((A.longitude * this.A) + this.B) * Scale;
        Double latitude = ((A.latitude * this.C) + this.D) * Scale;

        return new Coordinate(latitude, longitude);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="A"></param>
    /// <param name="Scale"></param>
    /// <returns></returns>
    public RectangleF Transform(RectangleF A, Single Scale) {
        return new RectangleF(this.Transform(A.Location, Scale), this.Transform(A.Size, Scale));
    }
}
