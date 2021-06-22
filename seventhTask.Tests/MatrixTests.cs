using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace seventhTask.Tests
{
    [TestClass]
    public class MatrixTests
    {
        MatrixComparer test = new MatrixComparer();
        Matrix firstMatrix = new Matrix(new float[,] { { 1, 2 }, { 4, 5 } });
        Matrix secondMatrix = new Matrix(new float[,] { { 2, 3 }, { 5, 6 } });

        [TestMethod]
        public void MatrixOperatorMyltiply_returned12153342()
        {
            var expected = new Matrix(new float[,] { { 12, 15 }, { 33, 42 } });

            var actual = firstMatrix * secondMatrix;

            Assert.IsTrue(test.Equals(expected, actual));
        }

        [TestMethod]
        public void MatrixOperatorAdd_returned35911()
        {
            var expected = new Matrix(new float[,] { { 3, 5 }, { 9, 11 } });

            var actual = firstMatrix + secondMatrix;

            Assert.IsTrue(test.Equals(expected, actual));
        }

        [TestMethod]
        public void MatrixOperatorSubtract_returnedFullOneWithMinus()
        {
            var expected = new Matrix(new float[,] { { -1, -1 }, { -1, -1 } });

            var actual = firstMatrix - secondMatrix;

            Assert.IsTrue(test.Equals(expected, actual));
        }
    }
}
