using System;
using System.Drawing;

namespace Map.CRS {
    public readonly partial struct Area {
        /// <summary></summary>
        public Coordinate Center {
            get {
                Double lng = (this.Max.longitude + this.Min.longitude) / 2;
                Double lat = (this.Max.latitude + this.Min.latitude) / 2;

                return new Coordinate(lng, lat);
            }
        }
    }
}
