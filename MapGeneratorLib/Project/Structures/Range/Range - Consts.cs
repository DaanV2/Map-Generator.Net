using System;

namespace Map.Project {
    public partial struct Range {
        public static readonly Range Invalid = new Range(Int32.MaxValue, Int32.MinValue);
    }
}
