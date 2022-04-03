using System;
using System.Drawing;

namespace Map.CRS {
    public partial class Transformation {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="A"></param>
        /// <returns></returns>
        public SizeF UnTransform(SizeF A, Single Scale) {
            Single w = ((A.Width / Scale) - this.B) / this.A;
            Single h = ((A.Height / Scale) - this.D) / this.C;

            return new SizeF(w, h);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="A"></param>
        /// <param name="Scale"></param>
        /// <returns></returns>
        public PointF UnTransform(PointF A, Single Scale) {
            Single X = ((A.X / Scale) - this.B) / this.A;
            Single Y = ((A.Y / Scale) - this.D) / this.C;

            return new PointF(X, Y);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="A"></param>
        /// <param name="Scale"></param>
        /// <returns></returns>
        public Coordinate UnTransform(Coordinate A, Single Scale) {
            Double longitude = ((A.longitude / Scale) - this.B) / this.A;
            Double latitude = ((A.latitude / Scale) - this.D) / this.C;

            return new Coordinate(latitude, longitude);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="A"></param>
        /// <param name="Scale"></param>
        /// <returns></returns>
        public RectangleF UnTransform(RectangleF A, Single Scale) {
            return new RectangleF(this.UnTransform(A.Location, Scale), this.UnTransform(A.Size, Scale));
        }
    }
}
