using System;

namespace Map.Process {
    ///DOLATER <summary>add description for struct: TileArea</summary>
    public readonly partial struct TileArea {
        /// <summary>Creates a new instance of <see cref="TileArea"/></summary>
        /// <param name="min"></param>
        /// <param name="max"></param>
        public TileArea(TileCoordinate min, TileCoordinate max) {
            this.Min = min;
            this.Max = max;
        }

        /// <summary>Creates a new instance of <see cref="TileArea"/></summary>
        /// <param name="fX"></param>
        /// <param name="fY"></param>
        /// <param name="tX"></param>
        /// <param name="tY"></param>
        public TileArea(Int32 fX, Int32 fY, Int32 tX, Int32 tY) : this(new TileCoordinate(fX, fY), new TileCoordinate(tX, tY)) { }

        public readonly TileCoordinate Min;
        public readonly TileCoordinate Max;
    }
}
