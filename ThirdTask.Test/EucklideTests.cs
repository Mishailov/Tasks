using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ThirdTask.Test
{
    [TestClass]
    public class EucklideTests
    {
        [TestMethod]
        public void EuclideanAlgorithmGCD_300181and223744_19returned()
        {
            //arrange
            uint val1 = 300181;
            uint val2 = 223744;
            uint expected = 19;

            //act
            uint actual = Euclide.EuclideanAlgorithmGCD(val1, val2, out long workingTime);

            //assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void EuclideanAlgorithmGCD_300181and223744and236645_19returned()
        {
            //arrange
            uint val1 = 300181;
            uint val2 = 223744;
            uint val3 = 236645;
            uint expected = 19;

            //act
            uint actual = Euclide.EuclideanAlgorithmGCD(val1, val2, val3);

            //assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void EuclideanAlgorithmGCD_300181and223744and236645and336262_19returned()
        {
            //arrange
            uint val1 = 300181;
            uint val2 = 223744;
            uint val3 = 236645;
            uint val4 = 336262;
            uint expected = 19;

            //act
            uint actual = Euclide.EuclideanAlgorithmGCD(val1, val2, val3, val4);

            //assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void EuclideanAlgorithmGCD_300181and223744and236645and336262and253327_19returned()
        {
            //arrange
            uint val1 = 300181;
            uint val2 = 223744;
            uint val3 = 236645;
            uint val4 = 336262;
            uint val5 = 253327;
            uint expected = 19;

            //act
            uint actual = Euclide.EuclideanAlgorithmGCD(val1, val2, val3, val4, val5);

            //assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void BinaryEuclideanAlgorithmGCD_300181and223744_19returned()
        {
            //arrange
            uint val1 = 300181;
            uint val2 = 223744;
            uint expected = 19;

            //act
            uint actual = Euclide.BinaryEuclideanAlgorithmGCD(val1, val2, out long workingTime);

            //assert
            Assert.AreEqual(expected, actual);
        }
    }
}
