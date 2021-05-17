using System;

namespace FifthTask
{
    class Program
    {
        static void Main(string[] args)
        {
            var firstVector = VectorCoordinates();
            var secondVector = VectorCoordinates();

            if(firstVector is null || secondVector is null)
            {
                return;
            }

            bool loopStatus = true;
            while (loopStatus)
            {
                Console.WriteLine("1: Add two vectors \n" +
                    "2: Subtract two vectors \n" +
                    "3: Myltiply two vectors \n" +
                    "4: Exit");
                Console.WriteLine("Write ur choice");
                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        {
                            Console.WriteLine(firstVector.Add(secondVector).ToString());
                            break;
                        }
                    case "2":
                        {
                            Console.WriteLine(firstVector.Subtract(secondVector).ToString());
                            break;
                        }
                    case "3":
                        {
                            Console.WriteLine(firstVector.Multiply(secondVector).ToString());
                            break;
                        }
                    case "4":
                        loopStatus = false;
                        break;

                    default:
                        break;
                }
            }
        }

        private static Vector3D VectorCoordinates()
        {
            Console.WriteLine("Write coordinates: ");
            if (double.TryParse(Console.ReadLine(), out double firstPoint)
                && double.TryParse(Console.ReadLine(), out double secondPoint)
                && double.TryParse(Console.ReadLine(), out double thirdPoint))
            {
                return new Vector3D(firstPoint, secondPoint, thirdPoint);
            }

            return null;
        }
    }
}
