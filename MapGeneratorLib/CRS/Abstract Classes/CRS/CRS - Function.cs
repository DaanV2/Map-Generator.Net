using System;
using System.Drawing;

namespace Map.CRS;

public abstract partial class CRS {
    /// <summary>
    /// 
    /// </summary>
    /// <param name="A"></param>
    /// <param name="B"></param>
    /// <returns></returns>
    public Double Distance(Coordinate A, Coordinate B) {
        return Math.Sqrt(this.DistanceSquared(A, B));
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="A"></param>
    /// <returns></returns>
    public PointF ToPoint(Coordinate A, Int32 Zoom) {
        Single Scale = this.Scale(Zoom);
        A = this.Transformation.UnTransform(A, Scale);

        return this.ToPoint(A);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="A"></param>
    /// <param name="Zoom"></param>
    /// <returns></returns>
    public Coordinate ToCoordinate(PointF A, Int32 Zoom) {
        Single Scale = this.Scale(Zoom);
        A = this.Transformation.Transform(A, Scale);

        return this.ToCoordinate(A);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="point"></param>
    /// <returns></returns>
    public virtual Point ToPoint(Coordinate point) {
        return new Point((Int32)point.longitude, (Int32)point.latitude);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="point"></param>
    /// <returns></returns>
    public virtual PointF ToPointF(Coordinate point) {
        return new PointF((Single)point.longitude, (Single)point.latitude);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="point"></param>
    /// <param name="Scale"></param>
    /// <returns></returns>
    public virtual Coordinate ToCoordinate(PointF point) {
        return new Coordinate((Double)point.Y, (Double)point.X);
    }
}
