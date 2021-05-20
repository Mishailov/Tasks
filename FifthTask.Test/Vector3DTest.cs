using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace FifthTask.Test
{
    [TestClass]
    public class Vector3DTest
    {
        [TestClass]
        public class Vector3DTests
        {
            EqualsTest test = new EqualsTest();
            Vector3D firstVector = new Vector3D(1.0, 2.0, 3.0);
            Vector3D secondVector = new Vector3D(4.0, 5.0, 6.0);
            [TestMethod]
            public void Multiply_123and456_nimus36minus3returned()
            {
                var expected = new Vector3D(-3, 6, -3);

                var actual = firstVector.Multiply(secondVector);

                Assert.IsTrue(test.Equals(expected, actual));
            }

            [TestMethod]
            public void Subtract_123and456_333withminusreturned()
            {
                var expected = new Vector3D(-3, -3, -3);

                var actual = firstVector.Subtract(secondVector);

                Assert.IsTrue(test.Equals(expected, actual));
            }

            [TestMethod]
            public void Add_123and456_579returned()
            {
                var expected = new Vector3D(5, 7, 9);

                var actual = firstVector.Add(secondVector);

                Assert.IsTrue(test.Equals(expected, actual));
            }

            [TestMethod]
            public void ToString_123_X1Y2Z3returned()
            {
                var expected = "X:1, Y:2, Z:3";

                Assert.AreEqual(expected, firstVector.ToString());
            }

            [TestMethod]
            public void ScalarMultiplication_123and3_369returned()
            {
                var expected = new Vector3D(3, 6, 9);

                var actual = firstVector.ScalarMultiplicationOnPrimitiveValue(3.0);

                Assert.IsTrue(test.Equals(expected, actual));
            }
        }
    }
}
