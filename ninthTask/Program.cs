using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ninthTask
{
    class Program
    {
        static void Main(string[] args)
        {
            BinaryTree<Student> studentsTree = new BinaryTree<Student>();

            studentsTree.Add(new Student("Artem", "c#", DateTime.Now, 7));
            studentsTree.Add(new Student("Denis", "c#", DateTime.Now, 5));
            studentsTree.Add(new Student("Kirill", "c#", DateTime.Now, 6));
            studentsTree.Add(new Student("Vasya", "c#", DateTime.Now, 3));
            studentsTree.Add(new Student("Artem", "c#", DateTime.Now, 7));

            Console.WriteLine("Chose one sort conf");
            Console.WriteLine("1 - order by name \n" +
                "2 - order by test name \n" +
                "3 - order by Mark \n");
            string sortConf = Console.ReadLine();

            Console.WriteLine("Is descending? (Y/N)");
            string descending = Console.ReadLine();
            if (descending != "Y" && descending != "N")
            {
                Console.WriteLine("Uncorrect answer");
                return;
            }

            Console.WriteLine("num of line");
            if (!int.TryParse(Console.ReadLine(), out int countLine))
            {
                Console.WriteLine("Uncorrect value");
                return;
            }

            switch (sortConf)
            {
                case "1":
                    if (descending.Equals("Y"))
                    {
                        OrderByValue(studentsTree.Take(countLine).OrderByDescending(x => x.Name));
                        break;
                    }

                    OrderByValue(studentsTree.Take(countLine).OrderBy(x => x.Name));
                    break;

                case "2":
                    if (descending.Equals("Y"))
                    {
                        OrderByValue(studentsTree.Take(countLine).OrderByDescending(x => x.TestName));
                        break;
                    }

                    OrderByValue(studentsTree.Take(countLine).OrderBy(x => x.TestName));
                    break;

                case "3":
                    if (descending.Equals("Y"))
                    {
                        OrderByValue(studentsTree.Take(countLine).OrderByDescending(x => x.Mark));
                        break;
                    }

                    OrderByValue(studentsTree.Take(countLine).OrderBy(x => x.Mark));
                    break;
            }
        }

        private static void OrderByValue(IEnumerable<Student> students)
        {
            foreach (var value in students)
            {
                Console.WriteLine($"Name: {value.Name}, " +
                    $"Test: {value.TestName}, " +
                    $"End time: {value.EndTime}, " +
                    $"Mark: {value.Mark}");
            }
        }
    }
}
