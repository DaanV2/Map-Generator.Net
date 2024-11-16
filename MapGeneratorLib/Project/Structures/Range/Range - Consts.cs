using System;

namespace Map.Project;
public partial struct Range {
    public static readonly Range Invalid = new(Int32.MaxValue, Int32.MinValue);
}
