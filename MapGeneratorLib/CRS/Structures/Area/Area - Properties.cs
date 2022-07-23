using System;

namespace Map.CRS {
    public readonly partial struct Area {
        /// <summary></summary>
        public Coordinate Center {
            get {
                Double lng = (this.Max.Longitude + this.Min.Longitude) / 2;
                Double lat = (this.Max.Latitude + this.Min.Latitude) / 2;

                return new Coordinate(lng, lat);
            }
        }

        /// <summary></summary>
        public Double Width => this.Max.Longitude - this.Min.Longitude;

        /// <summary></summary>
        public Double Height => this.Max.Latitude - this.Min.Latitude;
    }
}
