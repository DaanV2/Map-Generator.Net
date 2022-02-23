using System;

namespace Map.Project {
    public partial struct Range : IEquatable<Range> {
        /// <inheritdoc/>
        public override Boolean Equals(Object obj) {
            return obj is Range range && this.Equals(range);
        }

        /// <inheritdoc/>
        public Boolean Equals(Range other) {
            return this.Minimum == other.Minimum &&
                   this.Maximum == other.Maximum;
        }

        /// <inheritdoc/>
        public override Int32 GetHashCode() {
            return HashCode.Combine(this.Minimum, this.Maximum);
        }

        /// <inheritdoc/>
        public static Boolean operator ==(Range left, Range right) {
            return left.Equals(right);
        }

        /// <inheritdoc/>
        public static Boolean operator !=(Range left, Range right) {
            return !(left == right);
        }

        /// <inheritdoc/>
        public override String ToString() {
            return $"{this.Minimum}..{this.Maximum}";
        }
    }
}
