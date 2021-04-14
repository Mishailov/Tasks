using System;

namespace SecondTask
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Write number for root");
            string inputNum = Console.ReadLine();

            Console.WriteLine("Write root");
            string rootNum = Console.ReadLine();

            Console.WriteLine("write lengthAfterDecimalPoint");
            string lengthAfterDecimalPointStr = Console.ReadLine();

            if (double.TryParse(inputNum, out double input)
                && double.TryParse(lengthAfterDecimalPointStr, out double lengthAfterDecimalPointDouble)
                && int.TryParse(rootNum, out int rootNumber))
            {
                Sqrt sqrt = new Sqrt(input, rootNumber, lengthAfterDecimalPointDouble);
                Console.WriteLine(sqrt.GetSqrtByNewton().ToString());
                Console.WriteLine(sqrt.GetCompareWithPowValue().ToString());
            }
            else
                Console.WriteLine("Uncorrect values");
        }
    }
}
