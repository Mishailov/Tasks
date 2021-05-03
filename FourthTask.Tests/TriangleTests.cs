using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FourthTask.Tests
{
    [TestClass]
    public class TriangleTests
    {
        Triangle correctTriangle = new Triangle(3, 4, 5);
        Triangle uncorrectTriangle = new Triangle(12.0, 6.0, 6.0);

        [TestMethod]
        public void IsTriangle_trueReturned()
        {
            Assert.IsTrue(correctTriangle.IsTriangle());
        }

        [TestMethod]
        public void IsTriangle_falseReturned()
        {
            Assert.IsFalse(uncorrectTriangle.IsTriangle());
        }

        [TestMethod]
        public void GetAreaOfATriangle_withCorrectValues_6returned()
        {
            double expected = 6.0;

            Assert.AreEqual(expected, correctTriangle.GetAreaOfATriangle());
        }

        [TestMethod]
        public void GetAreaOfATriangle_withUncorrectValues_0dot0returned()
        {
            double expected = 0.0;

            Assert.AreEqual(expected, uncorrectTriangle.GetAreaOfATriangle());
        }

        [TestMethod]
        public void GetPerimetrOfATriangle_withCorrectValues_12returned()
        {
            double expected = 12.0;

            Assert.AreEqual(expected, correctTriangle.GetPerimetrOfATriangle());
        }

        [TestMethod]
        public void GetPerimetrOfATriangle_withUncorrectValues_0dot0returned()
        {
            double expected = 0.0;

            Assert.AreEqual(expected, uncorrectTriangle.GetPerimetrOfATriangle());
        }
    }
}
