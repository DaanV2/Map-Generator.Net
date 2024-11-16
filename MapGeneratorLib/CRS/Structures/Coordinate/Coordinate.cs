using System;
using System.Text.Json.Serialization;

namespace Map.CRS;
///DOLATER <summary>add description for struct: Coordinate</summary>
[JsonConverter(typeof(Serialization.CoordinateSerializer))]
public readonly partial struct Coordinate {
    /// <summary>Creates a new instance of <see cref="Coordinate"/></summary>
    /// <param name="latitude">Y</param>
    /// <param name="longitude">X</param>
    public Coordinate(Double latitude, Double longitude) {
        this.latitude = latitude;
        this.longitude = longitude;
    }

    /// <summary>Y</summary>
    public readonly Double latitude;

    /// <summary>X</summary>
    public readonly Double longitude;
}
