using System;

namespace Map.Project {
    public partial struct Area : IEquatable<Area> {
        /// <inheritdoc/>
        public override Boolean Equals(Object obj) {
            return obj is Area area && this.Equals(area);
        }

        /// <inheritdoc/>
        public Boolean Equals(Area other) {
            return this.X == other.X &&
                   this.Y == other.Y &&
                   this.Length == other.Length &&
                   this.Height == other.Height;
        }

        /// <inheritdoc/>
        public override Int32 GetHashCode() {
            return HashCode.Combine(this.X, this.Y, this.Length, this.Height);
        }

        /// <inheritdoc/>
        public static Boolean operator ==(Area left, Area right) {
            return left.Equals(right);
        }

        /// <inheritdoc/>
        public static Boolean operator !=(Area left, Area right) {
            return !(left == right);
        }

        /// <inheritdoc/>
        public override String ToString() {
            return $"[{this.X}, {this.Y}, {this.Length}, {this.Height}]";
        }
    }
}
