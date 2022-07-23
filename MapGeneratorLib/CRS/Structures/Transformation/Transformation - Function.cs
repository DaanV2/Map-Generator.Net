using System;
using System.Drawing;

namespace Map.CRS {
    public readonly partial struct Transformation {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="From"></param>
        /// <param name="To"></param>
        /// <returns></returns>
        public static Transformation FromRectangle(RectangleF From, RectangleF To) {
            Double A = (Double)To.Width / (Double)From.Width;
            Double C = (Double)To.Height / (Double)From.Height;

            Double B = (Double)To.Location.X - (Double)From.Location.X;
            Double D = (Double)To.Location.Y - (Double)From.Location.Y;

            return new Transformation(A, B, C, D);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="From"></param>
        /// <param name="To"></param>
        /// <returns></returns>
        public static Transformation FromRectangle(Area From, Area To) {
            Double A = To.Width / From.Width;
            Double C = To.Height /From.Height;

            Double B = To.Min.Longitude - From.Min.Longitude;
            Double D = To.Min.Latitude - From.Min.Latitude;

            return new Transformation(A, B, C, D);
        }
    }
}
