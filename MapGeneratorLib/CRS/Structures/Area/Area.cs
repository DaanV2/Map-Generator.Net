using System;
using System.Text.Json.Serialization;
using Map.CRS.Serialization;

namespace Map.CRS;
///DOLATER <summary>add description for struct: Area</summary>
[JsonConverter(typeof(AreaConverter))]
public readonly partial struct Area {
    /// <summary>Creates a new instance of <see cref="Area"/></summary>
    /// <param name="min"></param>
    /// <param name="max"></param>
    public Area(Coordinate min, Coordinate max) {
        this.Min = min;
        this.Max = max;
    }

    /// <summary>Creates a new instance of <see cref="Area"/></summary>
    /// <param name="a"></param>
    /// <param name="b"></param>
    /// <returns></returns>
    public static Area Create(Coordinate a, Coordinate b) {
        return new Area(
            new Coordinate(Math.Min(a.latitude, b.latitude), Math.Min(a.longitude, b.longitude)),
            new Coordinate(Math.Max(a.latitude, b.latitude), Math.Max(a.longitude, b.longitude))
            );
    }

    /// <summary>
    /// 
    /// </summary>
    public readonly Coordinate Min;

    /// <summary>
    /// 
    /// </summary>
    public readonly Coordinate Max;
}
