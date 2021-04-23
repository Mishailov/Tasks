using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace ThirdTask
{
    public static class Euclide
    {
        public static uint EuclideanAlgorithmGCD(uint val1, uint val2, out long workingTime)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            while((val1 != 0) && (val2 != 0))
            {
                if (val1 > val2)
                    val1 -= val2;
                else
                    val2 -= val1;
            }

            uint result = Math.Max(val1, val2);
            stopwatch.Stop();
            workingTime = stopwatch.ElapsedMilliseconds;
            return result;
        }

        public static uint EuclideanAlgorithmGCD(uint val1, uint val2, uint val3)
        {
            return EuclideanAlgorithmGCD(val1, EuclideanAlgorithmGCD(val2, val3, out long _), out long workingTime);
        }

        public static uint EuclideanAlgorithmGCD(uint val1, uint val2, uint val3, uint val4)
        {
            return EuclideanAlgorithmGCD(val1
                , EuclideanAlgorithmGCD(val2, val3, val4), out long workingTime);
        }

        public static uint EuclideanAlgorithmGCD(uint val1, uint val2, uint val3, uint val4, uint val5)
        {
            return EuclideanAlgorithmGCD(val1
                , EuclideanAlgorithmGCD(val2, val3, val4, val5), out long workingTime);
        }

        private static uint BinaryEuclideanAlgorithmGCD(uint val1, uint val2)
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

        public static uint BinaryEuclideanAlgorithmGCD(uint val1, uint val2, out long workingTime)
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
