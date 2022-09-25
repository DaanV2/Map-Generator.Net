using System;
using System.Drawing;
using Map.Process.Leaflet;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace TestMap.Process.Leaflet {
    public sealed partial class SimpleTileGeneratorTest {
        [TestMethod]
        [DataRow(0, 256F, 256F)]
        [DataRow(1, 128F, 128F)]
        [DataRow(2, 64F, 64F)]
        [DataRow(3, 32F, 32F)]
        [DataRow(4, 16F, 16F)]
        [DataRow(5, 8F, 8F)]
        [DataRow(6, 4F, 4F)]
        [DataRow(7, 2F, 2F)]
        public void TileSize(Int32 Zoom, Single Height, Single Width) {
            var gen = new SimpleTileGenerator(null);

            SizeF actual = gen.TileSize(Zoom);
            Assert.AreEqual(Height, actual.Height);
            Assert.AreEqual(Width, actual.Width);
        }

        [TestMethod]
        [DataRow(4, 0F, 0F, 45.5F, 30F, 0, 0, 3, 2)]
        [DataRow(5, 0F, 0F, 45.5F, 30F, 0, 0, 6, 4)]
        [DataRow(2, -32F, 64F, 45.5F, 30F, -1, 1, 1, 2)]
        [DataRow(4, 45.5F, 30F, 45.5F, 30F, 2, 1, 6, 4)]
        public void TileIndexes(Int32 Zoom, Single xP, Single yP, Single Width, Single Height, Int32 TileXStart, Int32 TileYStart, Int32 TileXEnd, Int32 TileYEnd) {
            var gen = new SimpleTileGenerator(null);
            SizeF TileSizeAtScale = gen.TileSize(Zoom);
            //Expressed in coordinates
            var ImageArea = new RectangleF(xP, yP, Width, Height);

            (Int32 xStart, Int32 xEnd, Int32 yStart, Int32 yEnd) = gen.TileIndexes(TileSizeAtScale, ImageArea);

            Assert.AreEqual(TileXStart, xStart);
            Assert.AreEqual(TileXEnd, xEnd);

            Assert.AreEqual(TileYStart, yStart);
            Assert.AreEqual(TileYEnd, yEnd);
        }
    }
}
