using System;

namespace FourthTask
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Write 3 sides of a triangle: ");
            if (!double.TryParse(Console.ReadLine(), out double firstSide)
                || !double.TryParse(Console.ReadLine(), out double secondSide)
                || !double.TryParse(Console.ReadLine(), out double thirdSide))
            {
                Console.WriteLine("Uncorrect value");

                return;
            }

            var triangle = new Triangle(firstSide, secondSide, thirdSide);

            if (!triangle.IsTriangle())
            {
                Console.WriteLine("This is not a triangle");

                return;
            }

            bool loopStatus = true;
            while (loopStatus)
            {
                Console.WriteLine("1: Get Area of a triangle \n" +
                    "2: Get perimetr of a triangle \n" +
                    "3: Exit");
                Console.WriteLine("Write ur choice");
                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        {
                            Console.WriteLine($"{triangle.GetAreaOfATriangle()}");
                            break;
                        }
                    case "2":
                        {
                            Console.WriteLine($"{triangle.GetPerimetrOfATriangle()}");
                            break;
                        }
                    case "3":
                        loopStatus = false;
                        break;

                    default:
                        break;
                }
            }
        }
    }
}
