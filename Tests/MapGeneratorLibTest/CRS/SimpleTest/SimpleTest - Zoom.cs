using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestMap.CRS {
    [TestClass]
    public sealed partial class SimpleTest {
        [TestMethod]
        [DataRow(1)]
        [DataRow(2)]
        [DataRow(3)]
        [DataRow(4)]
        [DataRow(8)]
        [DataRow(16)]
        public void TestZoom(Int32 Zoom) {
            var Simple = new Map.CRS.SimpleCRS();

            Single ActualScale = Simple.Scale(Zoom);

            Assert.AreEqual(ActualScale, Convert.ToSingle(Math.Pow(2, Zoom)));

            Int32 ActualZoom = Simple.Zoom((Int32)ActualScale);
            Assert.AreEqual(ActualZoom, Zoom);
        }
    }
}
