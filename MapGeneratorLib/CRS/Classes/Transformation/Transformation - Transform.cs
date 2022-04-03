using System;
using System.Drawing;

namespace Map.CRS {
    public partial class Transformation {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="A"></param>
        /// <returns></returns>
        public Size Transform(Size A, Int32 Scale) {
            Double w = ((A.Width * this.A) + this.B) * Scale;
            Double h = ((A.Height * this.C) + this.D) * Scale;

            return new Size((Int32)w, (Int32)h);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="A"></param>
        /// <param name="Scale"></param>
        /// <returns></returns>
        public Point Transform(Point A, Int32 Scale) {
            Double X = ((A.X * this.A) + this.B) * Scale;
            Double Y = ((A.Y * this.C) + this.D) * Scale;

            return new Point((Int32)X, (Int32)Y);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="A"></param>
        /// <param name="Scale"></param>
        /// <returns></returns>
        public Coordinate Transform(Coordinate A, Int32 Scale) {
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
        public Rectangle Transform(Rectangle A, Int32 Scale) {
            return new Rectangle(this.Transform(A.Location, Scale), this.Transform(A.Size, Scale));
        }
    }
}
