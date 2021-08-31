using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ninthTask
{
    class Program
    {
        static void Main(string[] args)
        {
            BinaryTree<int> allMarks = new BinaryTree<int>();
            List<Student> allInfoAboutStudents = new List<Student>();

            allInfoAboutStudents.Add(new Student("Artem", "c#", DateTime.Now, 7, allMarks));
            allInfoAboutStudents.Add(new Student("Denis", "c#", DateTime.Now, 5, allMarks));
            allInfoAboutStudents.Add(new Student("Kirill", "c#", DateTime.Now, 6, allMarks));
            allInfoAboutStudents.Add(new Student("Vasya", "c#", DateTime.Now, 3, allMarks));
            allInfoAboutStudents.Add(new Student("Artem", "c#", DateTime.Now, 7, allMarks));
            allInfoAboutStudents.Add(new Student("Denis", "c#", DateTime.Now, 5, allMarks));
            allInfoAboutStudents.Add(new Student("Kirill", "c#", DateTime.Now, 6, allMarks));
            allInfoAboutStudents.Add(new Student("Vasya", "c#", DateTime.Now, 3, allMarks));
            allInfoAboutStudents.Add(new Student("Artem", "c#", DateTime.Now, 7, allMarks));
            allInfoAboutStudents.Add(new Student("Denis", "c#", DateTime.Now, 5, allMarks));
            allInfoAboutStudents.Add(new Student("Kirill", "c#", DateTime.Now, 6, allMarks));
            allInfoAboutStudents.Add(new Student("Vasya", "c#", DateTime.Now, 3, allMarks));
            allInfoAboutStudents.Add(new Student("Artem", "c#", DateTime.Now, 7, allMarks));
            allInfoAboutStudents.Add(new Student("Denis", "c#", DateTime.Now, 5, allMarks));
            allInfoAboutStudents.Add(new Student("Kirill", "c#", DateTime.Now, 6, allMarks));
            allInfoAboutStudents.Add(new Student("Vasya", "c#", DateTime.Now, 4, allMarks));

            foreach (var value in allInfoAboutStudents.OrderBy(x => x.Mark)) 
            {
                Console.WriteLine($"Name: {value.Name}, Test: {value.TestName}, End time: {value.EndTime}, Mark: {value.Mark}");
            }

            Console.WriteLine("Chose one sort conf");
            Console.WriteLine("1 - order by name \n" +
                "2 - order by test name \n" +
                "3 - order by Mark \n");
            string sortConf = Console.ReadLine();

            Console.WriteLine("Is descending? (Y/N)");
            string descending = Console.ReadLine();
            if(descending != "Y" && descending != "N")
            {
                Console.WriteLine("Uncorrect answer");
                return;
            }

            Console.WriteLine("num of line");
            if(!int.TryParse(Console.ReadLine(), out int countLine))
            {
                Console.WriteLine("Uncorrect value");
                return;
            }

            switch (sortConf)
            {
                case "1":
                    if (descending.Equals("Y"))
                    {
                        OrderByValue(allInfoAboutStudents.Take(countLine).OrderByDescending(x => x.Name));
                        break;
                    }

                    OrderByValue(allInfoAboutStudents.Take(countLine).OrderBy(x => x.Name));
                    break;

                case "2":
                    if (descending.Equals("Y"))
                    {
                        OrderByValue(allInfoAboutStudents.Take(countLine).OrderByDescending(x => x.TestName));
                        break;
                    }

                    OrderByValue(allInfoAboutStudents.Take(countLine).OrderBy(x => x.TestName));
                    break;

                case "3":
                    if (descending.Equals("Y"))
                    {
                        OrderByValue(allInfoAboutStudents.Take(countLine).OrderByDescending(x => x.Mark));
                        break;
                    }

                    OrderByValue(allInfoAboutStudents.Take(countLine).OrderBy(x => x.Mark));
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
