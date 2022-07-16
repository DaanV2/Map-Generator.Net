using System;

namespace Map.CRS {
    public readonly partial struct Transformation {
        /// <summary>X * A + B</summary>
        internal readonly Double _A;

        /// <summary>X * A + B</summary>
        internal readonly Double _B;

        /// <summary>Y * C + D</summary>
        internal readonly Double _C;

        /// <summary>Y * C + D</summary>
        internal readonly Double _D;
    }
}
