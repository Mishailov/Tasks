using System;

namespace SecondTask
{
    class Program
    {
        static void Main(string[] args)
        {
            double input = 0.0;
            int rootNumber = 0;
            double epsil = 0.0;

            Console.WriteLine("Write number for root");
            string inputNum = Console.ReadLine();

            Console.WriteLine("Write root");
            string rootNum = Console.ReadLine();

            Console.WriteLine("write eps");
            string eps = Console.ReadLine();

            if(TryParsing(inputNum) && TryParsing(eps))
            {
                input = double.Parse(inputNum);
                epsil = double.Parse(eps);
            }
            else
                Console.WriteLine("Uncorrect double value");

            if (int.TryParse(rootNum, out int num))
                rootNumber = int.Parse(rootNum);
            else
                Console.WriteLine("Uncorrect root");

            Sqrt sqrt = new Sqrt(input, rootNumber, epsil);
            Console.WriteLine(sqrt.GetSqrtByNewton().ToString());
            Console.WriteLine(sqrt.GetCompareWithPowValue().ToString());
        }

        static bool TryParsing(string input)
        {
            return (double.TryParse(input, out double num));
        }
    }
}
