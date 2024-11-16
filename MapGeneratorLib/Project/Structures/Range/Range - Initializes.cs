using System;
using System.Text.Json.Serialization;
using Map.Project.Serialization;

namespace Map.Project;
/// <summary>A range of numbers</summary>
[JsonConverter(typeof(RangeConverter))]
public partial struct Range {
    /// <summary>Creates a new instance of <see cref="Range"/></summary>
    /// <param name="minimum">The minimum value</param>
    /// <param name="maximum">The maximum value</param>
    public Range(Int32 minimum, Int32 maximum) {
        this.Minimum = minimum;
        this.Maximum = maximum;
    }

    /// <summary>Creates a new instance of <see cref="Range"/>, determining if A or B is the minimum/maximum value</summary>
    /// <param name="A">The first value</param>
    /// <param name="B">The second value</param>
    /// <returns>A new range</returns>
    public static Range Create(Int32 A, Int32 B) {
        if (A < B) {
            return new Range(A, B);
        }

        return new Range(B, A);
    }
}
