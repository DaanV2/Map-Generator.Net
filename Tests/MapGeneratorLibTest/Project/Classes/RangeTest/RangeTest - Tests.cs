using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestMap.Project {
    public sealed partial class RangeTest {
        [TestMethod]
        [DataRow(0, 10)]
        [DataRow(256, 300)]
        [DataRow(256, -300)]
        [DataRow(5, -5)]
        public void SanityCheck(Int32 A, Int32 B) {
            Int32 Minimum = System.Math.Min(A, B);
            Int32 Maximum = System.Math.Max(A, B);

            var R = Map.Project.Range.Create(A, B);

            Assert.AreEqual(Minimum, R.Minimum, "Minimum wasn't set");
            Assert.AreEqual(Maximum, R.Maximum, "Maximum wasn't set");

            Int32 Average = (A + B) / 2;
            Assert.IsTrue(R.InRange(A));
            Assert.IsTrue(R.InRange(B));
            Assert.IsTrue(R.InRange(Average));

            Assert.IsFalse(R.InRange(Minimum - 1));
            Assert.IsFalse(R.InRange(Maximum + 1));
        }
    }
}
