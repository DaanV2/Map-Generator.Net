using System;

namespace Map.CRS;
public readonly partial struct Area : IEquatable<Area> {
    /// <inheritdoc/>
    public override Boolean Equals(Object obj) {
        return obj is Area area && this.Equals(area);
    }

    /// <inheritdoc/>
    public Boolean Equals(Area other) {
        return this.Min.Equals(other.Min) &&
               this.Max.Equals(other.Max);
    }

    /// <inheritdoc/>
    public override Int32 GetHashCode() {
        return HashCode.Combine(this.Min, this.Max);
    }

    /// <inheritdoc/>
    public static Boolean operator ==(Area left, Area right) {
        return left.Equals(right);
    }

    /// <inheritdoc/>
    public static Boolean operator !=(Area left, Area right) {
        return !(left == right);
    }
}
