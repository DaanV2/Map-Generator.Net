using System;

namespace Map.Process {
    public readonly partial struct TileArea {
        public static TileArea Create(TileCoordinate A, TileCoordinate B) {
            Int32 fX, fY, tX, tY;

            if (A.X < B.X) {
                fX = A.X;
                tX = B.X;
            } else {
                tX = A.X;
                fX = B.X;
            }

            if (A.Y < B.Y) {
                fY = A.Y;
                tY = B.Y;
            }
            else {
                tY = A.Y;
                fY = B.Y;
            }

            return new TileArea(fX, fY, tX, tY);
        }
    }
}
