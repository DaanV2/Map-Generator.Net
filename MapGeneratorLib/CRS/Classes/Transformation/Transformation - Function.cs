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
        public static Transformation FromRectangle(RectangleF From, RectangleF To) {
            Single A = (Single)To.Width / (Single)From.Width;
            Single C = (Single)To.Height / (Single)From.Height;

            Single B = To.Location.X - From.Location.X;
            Single D = To.Location.Y - From.Location.Y;

            return new Transformation(A, B, C, D);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="X"></param>
        /// <param name="Y"></param>
        public void SetOffset(Single X, Single Y) {
            this.B = X;
            this.D = Y;
        }
    }
}
