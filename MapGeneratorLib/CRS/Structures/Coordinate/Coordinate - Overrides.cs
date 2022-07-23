using System;

namespace Map.CRS {
    public readonly partial struct Coordinate : IEquatable<Coordinate> {
        /// <inheritdoc/>
        public override Boolean Equals(Object obj) {
            return obj is Coordinate coordinate && this.Equals(coordinate);
        }

        /// <inheritdoc/>
        public Boolean Equals(Coordinate other) {
            return this.Latitude == other.Latitude &&
                   this.Longitude == other.Longitude;
        }

        /// <inheritdoc/>
        public override Int32 GetHashCode() {
            return HashCode.Combine(this.Latitude, this.Longitude);
        }

        /// <inheritdoc/>
        public static Boolean operator ==(Coordinate left, Coordinate right) {
            return left.Equals(right);
        }

        /// <inheritdoc/>
        public static Boolean operator !=(Coordinate left, Coordinate right) {
            return !(left == right);
        }

        /// <inheritdoc/>
        public override String ToString() {
            return $"latLng[{this.Latitude},{this.Longitude}]";
        }
    }
}
