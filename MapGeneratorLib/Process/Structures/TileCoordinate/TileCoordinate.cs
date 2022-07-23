using System;

namespace Map.Process {
    ///DOLATER <summary>add description for struct: TileCoordinate</summary>
    public readonly partial struct TileCoordinate {
        /// <summary>Creates a new instance of <see cref="TileCoordinate"/></summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public TileCoordinate(Int32 x, Int32 y) {
            this.X = x;
            this.Y = y;
        }

        public readonly Int32 X;
        public readonly Int32 Y;
    }
}
