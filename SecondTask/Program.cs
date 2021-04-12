using System;

namespace SecondTask
{
    class Program
    {
        static void Main(string[] args)
        {
            double input;
            int rootNumber;
            double lengthAfterDecimalPointDouble;

            Console.WriteLine("Write number for root");
            string inputNum = Console.ReadLine();

            Console.WriteLine("Write root");
            string rootNum = Console.ReadLine();

            Console.WriteLine("write lengthAfterDecimalPoint");
            string lengthAfterDecimalPointStr = Console.ReadLine();

            if(Double.TryParse(inputNum, out input)
                && Double.TryParse(lengthAfterDecimalPointStr, out lengthAfterDecimalPointDouble)
                && int.TryParse(rootNum, out rootNumber))
            {
                Sqrt sqrt = new Sqrt(input, rootNumber, lengthAfterDecimalPointDouble);
                Console.WriteLine(sqrt.GetSqrtByNewton().ToString());
                Console.WriteLine(sqrt.GetCompareWithPowValue().ToString());
            }
            else
                Console.WriteLine("Uncorrect values");
        }

        //при вызове метода, значение в out передает default value по этому не могу использовать DRY
        //static double TryParsing(string input, double num)
        //{
        //    if (double.TryParse(input, out num))
        //        return num;
        //    else 
        //        return Double.NaN;
        //}
    }
}
