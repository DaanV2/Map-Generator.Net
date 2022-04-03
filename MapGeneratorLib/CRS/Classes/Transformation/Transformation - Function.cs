using System;
using System.Drawing;

namespace Map.CRS {
    public partial class Transformation {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="A"></param>
        /// <param name="B"></param>
        /// <returns></returns>
        public static Transformation FromRectangle(Rectangle From, Rectangle To) {
            Double A = (Double)To.Width / (Double)From.Width;
            Double C = (Double)To.Height / (Double)From.Height;

            Double B = To.Location.X - From.Location.X;
            Double D = To.Location.Y - From.Location.Y;

            return new Transformation(A, B, C, D);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="X"></param>
        /// <param name="Y"></param>
        public void SetOffset(Double X, Double Y) {
            this.B = X;
            this.D = Y;
        }
    }
}
