using System;

namespace Map.CRS {
    public partial class SimpleCRS : CRS {
        /// <inheritdoc/>
        public override Area Bounds => new(new Coordinate(Double.MinValue, Double.MinValue), new Coordinate(Double.MaxValue, Double.MaxValue));

        /// <inheritdoc/>
        public override Boolean Infinite => true;

        /// <inheritdoc/>
        public override Single Scale(Int32 Zoom) {
            return Convert.ToSingle(Math.Pow(2, Zoom));
        }

        /// <inheritdoc/>
        public override Int32 Zoom(Int32 Scale) {
            return Convert.ToInt32(Math.Log2(Scale));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="A"></param>
        /// <param name="B"></param>
        /// <returns></returns>
        public override Double DistanceSquared(Coordinate A, Coordinate B) {
            Double dx = B.longitude - A.longitude;
            Double dy = B.latitude - A.latitude;

            return (dx * dx) + (dy * dy);
        }
    }
}
