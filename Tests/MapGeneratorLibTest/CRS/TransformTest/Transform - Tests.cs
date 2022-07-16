using System;
using System.Drawing;
using Map.CRS;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestMap.CRS.TransformTest {
    [TestClass]
    public sealed partial class TransformTest {
        public static RectangleF From = new RectangleF(0, 0, 10, 10);
        public static RectangleF To = new RectangleF(10, 25, 10, 25);
        public static Transformation Trans = Transformation.FromRectangle(From, To);

        [TestMethod]
        [DataRow(0, 0, 10, 25, DisplayName ="0, 0 => 10, 25")]
        [DataRow(10, 10, 20, 50, DisplayName = "10, 10 => 20, 50")]
        [DataRow(0, 10, 10, 50, DisplayName = "0, 10 => 10, 50")]
        [DataRow(10, 0, 20, 25, DisplayName = "10, 0 => 20, 25")]
        [DataRow(5, 5, 15, 37.5, DisplayName = "10, 0 => 20, 25")]
        public void Test_Transform(Double X, Double Y, Double expectedX, Double expectedY) {
            (Double X, Double Y) Data = Trans.Transform(X, Y);

            Assert.AreEqual(expectedX, Data.X, nameof(expectedX));
            Assert.AreEqual(expectedY, Data.Y, nameof(expectedY));
        }

        [TestMethod]
        [DataRow(0, 0, 10, 25, DisplayName = "0, 0 <= 10, 25")]
        [DataRow(10, 10, 20, 50, DisplayName = "10, 10 <= 20, 50")]
        [DataRow(0, 10, 10, 50, DisplayName = "0, 10 <= 10, 50")]
        [DataRow(10, 0, 20, 25, DisplayName = "10, 0 <= 20, 25")]
        [DataRow(5, 5, 15, 37.5, DisplayName = "10, 0 <= 20, 25")]
        public void Test_UnTransform(Double expectedX, Double expectedY, Double X, Double Y) {
            (Double X, Double Y) Data = Trans.Untransform(X, Y);

            Assert.AreEqual(expectedX, Data.X, nameof(expectedX));
            Assert.AreEqual(expectedY, Data.Y, nameof(expectedY));
        }
    }
}
