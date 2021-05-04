using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace ThirdTask
{
    public class Euclide
    {
        private uint EuclideanAlgorithmGCD(uint val1, uint val2)
        {
            while ((val1 != 0) && (val2 != 0))
            {
                if (val1 > val2)
                    val1 -= val2;
                else
                    val2 -= val1;
            }

            uint result = Math.Max(val1, val2);

            return result;
        }

        public uint EuclideanAlgorithmGCD(uint val1, uint val2, uint val3)
        {
            return EuclideanAlgorithmGCD(val1, EuclideanAlgorithmGCD(val2, val3));
        }

        public uint EuclideanAlgorithmGCD(uint val1, uint val2, uint val3, uint val4)
        {
            return EuclideanAlgorithmGCD(val1
                , EuclideanAlgorithmGCD(val2, val3, val4));
        }

        public uint EuclideanAlgorithmGCD(uint val1, uint val2, uint val3, uint val4, uint val5)
        {
            return EuclideanAlgorithmGCD(val1
                , EuclideanAlgorithmGCD(val2, val3, val4, val5));
        }

        public uint EuclideanAlgorithmGCD(uint val1, uint val2, out long workingTime)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            uint result = EuclideanAlgorithmGCD(val1, val2);
            stopwatch.Stop();
            workingTime = stopwatch.ElapsedMilliseconds;
            return result;
        }

        private uint BinaryEuclideanAlgorithmGCD(uint val1, uint val2)
        {
            if (val1 == 0 || val2 == val1)
            {
                return val2;
            }

            else if (val2 == 0)
            {
                return val1;
            }

            if(val1 == 1 || val2 == 1)
            {
                return 1;
            }

            if ((val1 & 1) == 0)
            {
                return ((val2 & 1) == 0)
                    ? BinaryEuclideanAlgorithmGCD(val1 >> 1, val2 >> 1) << 1
                    : BinaryEuclideanAlgorithmGCD(val1 >> 1, val2);
            }

            else
            {
                return ((val2 & 1) == 0)
                    ? BinaryEuclideanAlgorithmGCD(val1, val2 >> 1)
                    : BinaryEuclideanAlgorithmGCD(val2, val1 > val2 ? val1 - val2 : val2 - val1);
            }
        }

        public uint BinaryEuclideanAlgorithmGCD(uint val1, uint val2, out long workingTime)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            uint result = BinaryEuclideanAlgorithmGCD(val1, val2);
            stopwatch.Stop();
            workingTime = stopwatch.ElapsedMilliseconds;
            return result;
        }
    }
}
