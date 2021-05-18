using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FifthTask.Test
{
    [TestClass]
    public class Vector3DTest
    {
        [TestClass]
        public class Vector3DTests
        {
            Vector3D firstVector = new Vector3D(1.0, 2.0, 3.0);
            Vector3D secondVector = new Vector3D(4.0, 5.0, 6.0);
            [TestMethod]
            public void Multiply_123and456_nimus36minus3returned()
            {
                string expected = "X:-3, Y:6, Z:-3";

                Assert.AreEqual(expected, firstVector.Multiply(secondVector).ToString());
            }

            [TestMethod]
            public void Subtract_123and456_333withminusreturned()
            {
                string expected = "X:-3, Y:-3, Z:-3";

                Assert.AreEqual(expected, firstVector.Subtract(secondVector).ToString());
            }

            [TestMethod]
            public void Add_123and456_579returned()
            {
                string expected = "X:5, Y:7, Z:9";

                Assert.AreEqual(expected, firstVector.Add(secondVector).ToString());
            }
        }
    }
}
