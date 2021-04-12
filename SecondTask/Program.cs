using System;

namespace SecondTask
{
    class Program
    {
        static void Main(string[] args)
        {
            double input = 0.0;
            double lengthAfterDecimalPointDouble = 0.0;

            Console.WriteLine("Write number for root");
            string inputNum = Console.ReadLine();

            Console.WriteLine("Write root");
            string rootNum = Console.ReadLine();

            Console.WriteLine("write lengthAfterDecimalPoint");
            string lengthAfterDecimalPointStr = Console.ReadLine();

            if (TryParsing(inputNum, ref input)
                && TryParsing(lengthAfterDecimalPointStr, ref lengthAfterDecimalPointDouble)
                && int.TryParse(rootNum, out int rootNumber))
            {
                Sqrt sqrt = new Sqrt(input, rootNumber, lengthAfterDecimalPointDouble);
                Console.WriteLine(sqrt.GetSqrtByNewton().ToString());
                Console.WriteLine(sqrt.GetCompareWithPowValue().ToString());
            }
            else
                Console.WriteLine("Uncorrect values");
        }

        static bool TryParsing(string input, ref double num)
        {
            return double.TryParse(input, out num);
        }
    }
}
