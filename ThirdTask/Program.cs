using System;

namespace ThirdTask
{
    class Program
    {
        static void Main(string[] args)
        {
            bool loopStatus = true;
            while (loopStatus)
            {
                Console.WriteLine("1: Eucklide algorithm with 2 param \n" +
                    "2: Eucklide algorithm with 3 param \n" +
                    "3: Eucklide algorithm with 4 param \n" +
                    "4: Eucklide algorithm with 5 param \n" +
                    "5: Binary Eucklide algorithm /n" +
                    "6: Exit");
                Console.WriteLine("Write ur choice");
                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        {
                            Console.WriteLine("Write 2 param: ");
                            if(uint.TryParse(Console.ReadLine(), out uint val1) 
                                && uint.TryParse(Console.ReadLine(), out uint val2))
                            {
                                //two boxing. How to fix(optimize)? 
                                Console.WriteLine($"{Euclide.EuclideanAlgorithmGCD(val1, val2, out long workingTime)} \n {workingTime} ");
                            }
                            break;
                        }
                    case "2":
                        {
                            Console.WriteLine("Write 3 param: ");
                            if (uint.TryParse(Console.ReadLine(), out uint val1)
                                && uint.TryParse(Console.ReadLine(), out uint val2)
                                && uint.TryParse(Console.ReadLine(), out uint val3))
                            {
                                Console.WriteLine($"{Euclide.EuclideanAlgorithmGCD(val1, val2, val3)}");
                            }
                            break;
                        }
                    case "3":
                        {
                            Console.WriteLine("Write 4 param: ");
                            if (uint.TryParse(Console.ReadLine(), out uint val1)
                                && uint.TryParse(Console.ReadLine(), out uint val2)
                                && uint.TryParse(Console.ReadLine(), out uint val3)
                                && uint.TryParse(Console.ReadLine(), out uint val4))
                            {
                                Console.WriteLine($"{Euclide.EuclideanAlgorithmGCD(val1, val2, val3, val4)}");
                            }
                            break;
                        }
                    case "4":
                        {
                            Console.WriteLine("Write 5 param: ");
                            if (uint.TryParse(Console.ReadLine(), out uint val1)
                                && uint.TryParse(Console.ReadLine(), out uint val2)
                                && uint.TryParse(Console.ReadLine(), out uint val3)
                                && uint.TryParse(Console.ReadLine(), out uint val4)
                                && uint.TryParse(Console.ReadLine(), out uint val5))
                            { 
                                Console.WriteLine($"{Euclide.EuclideanAlgorithmGCD(val1, val2, val3, val4, val5)}");
                            }
                            break;
                        }
                    case "5":
                        {
                            Console.WriteLine("Write 2 param: ");
                            if (uint.TryParse(Console.ReadLine(), out uint val1)
                                && uint.TryParse(Console.ReadLine(), out uint val2))
                            {
                                //two boxing. How to fix(optimize)? 
                                Console.WriteLine($"{Euclide.BinaryEuclideanAlgorithmGCD(val1, val2, out long workingTime)} \n {workingTime} ");
                            }
                            break;
                        }
                    case "6":
                        loopStatus = false;
                        break;

                    default:
                        break;
                }
            }
        }
    }
}
