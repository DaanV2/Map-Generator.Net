using System.Drawing;
using Map.CRS;

namespace Map.Process.Leaflet {
    public static partial class Format {
        public static partial class Transformers {
            /// <summary>
            /// 
            /// </summary>
            /// <param name="area"></param>
            /// <param name="Coordinates"></param>
            /// <returns></returns>
            public static Transformation CoordinateToPixel(Area area, Size Coordinates) {
                var To = new Area(new Coordinate(0, 0), new Coordinate(Coordinates.Height, Coordinates.Width));

                return Transformation.FromRectangle(area, To);
            }

            /// <summary>
            /// 
            /// </summary>
            /// <param name="area"></param>
            /// <param name="Coordinates"></param>
            /// <returns></returns>
            public static Transformation PixelToCoordinate(Area area, Size Coordinates) {
                var From = new Area(new Coordinate(0, 0), new Coordinate(Coordinates.Height, Coordinates.Width));

                return Transformation.FromRectangle(From, area);
            }
        }
    }
}
