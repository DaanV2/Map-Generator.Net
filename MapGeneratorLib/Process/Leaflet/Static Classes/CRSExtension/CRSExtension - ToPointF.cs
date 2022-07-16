using System;
using System.Drawing;
using Map.CRS;

namespace Map.Process.Leaflet {
    public static partial class CRSExtension {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="CRS"></param>
        /// <param name="coordinate"></param>
        /// <returns></returns>
        public static PointF ToPointF(this CRS.CRS CRS, Coordinate coordinate) {
            (Double X, Double Y) = CRS.Transformation.Transform(coordinate.longitude, coordinate.latitude);
            return new PointF((Single)X, (Single)Y);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="CRS"></param>
        /// <param name="coordinate"></param>
        /// <returns></returns>
        public static Point ToPoint(this CRS.CRS CRS, Coordinate coordinate) {
            (Double X, Double Y) = CRS.Transformation.Transform(coordinate.longitude, coordinate.latitude);
            return new Point((Int32)X, (Int32)Y);
        }
    }
}
