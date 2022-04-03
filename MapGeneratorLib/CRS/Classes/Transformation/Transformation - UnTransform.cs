using System;
using System.Drawing;

namespace Map.CRS {
    public partial class Transformation {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="A"></param>
        /// <returns></returns>
        public Size UnTransform(Size A, Int32 Scale) {
            Double w = ((A.Width / Scale) - this.B) / this.A;
            Double h = ((A.Height / Scale) - this.D) / this.C;

            return new Size((Int32)w, (Int32)h);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="A"></param>
        /// <param name="Scale"></param>
        /// <returns></returns>
        public Point UnTransform(Point A, Int32 Scale) {
            Double X = ((A.X / Scale) - this.B) / this.A;
            Double Y = ((A.Y / Scale) - this.D) / this.C;

            return new Point((Int32)X, (Int32)Y);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="A"></param>
        /// <param name="Scale"></param>
        /// <returns></returns>
        public Coordinate UnTransform(Coordinate A, Int32 Scale) {
            Double longitude = ((A.longitude / Scale) - (Double)this.B) / (Double)this.A;
            Double latitude = ((A.latitude / Scale) - (Double)this.D) / (Double)this.C;

            return new Coordinate(latitude, longitude);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="A"></param>
        /// <param name="Scale"></param>
        /// <returns></returns>
        public Rectangle UnTransform(Rectangle A, Int32 Scale) {
            return new Rectangle(this.UnTransform(A.Location, Scale), this.UnTransform(A.Size, Scale));
        }
    }
}
