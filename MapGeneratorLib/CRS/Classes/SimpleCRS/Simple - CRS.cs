using System;
using System.Drawing;

namespace Map.CRS {
    public partial class SimpleCRS : CRS {
        /// <inheritdoc/>
        public override Area Bounds => new(new Coordinate(Double.MinValue, Double.MinValue), new Coordinate(Double.MaxValue, Double.MaxValue));

        /// <inheritdoc/>
        public override Boolean Infinite => true;

        /// <inheritdoc/>
        public override Int32 Scale(Int32 Zoom) {
            return Convert.ToInt32(Math.Pow(2, Zoom));
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

        /// <inheritdoc/>
        public override Point Transform(Point point, Int32 Scale) {
            Int32 x = ((point.X * 1) + 0) * Scale;
            Int32 y = ((point.Y * -1) + 0) * Scale;

            return new Point(x, y);
        }

        /// <inheritdoc/>
        public override Point UnTransform(Point point, Int32 Scale) {
            Int32 x = ((point.X / Scale) - 0) / 1;
            Int32 y = ((point.Y / Scale) - 0) / -1;
            return new Point(x, y);
        }
    }
}
