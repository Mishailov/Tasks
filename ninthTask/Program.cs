using System;
using System.Collections.Generic;
using System.Linq;

namespace ninthTask
{
    class Program
    {
        static void Main(string[] args)
        {
            BinaryTree<int> allMarks = new BinaryTree<int>();
            List<Student<int>> allInfoAboutStudents = new List<Student<int>>();

            allInfoAboutStudents.Add(new Student<int>("Artem", "c#", DateTime.Now, 7, allMarks));
            allInfoAboutStudents.Add(new Student<int>("Denis", "c#", DateTime.Now, 5, allMarks));
            allInfoAboutStudents.Add(new Student<int>("Kirill", "c#", DateTime.Now, 6, allMarks));
            allInfoAboutStudents.Add(new Student<int>("Vasya", "c#", DateTime.Now, 4, allMarks));

            foreach (var value in allInfoAboutStudents.OrderBy(x => x.Mark)) 
            {
                Console.WriteLine($"Name: {value.Name}, Test: {value.TestName}, End time: {value.EndTime}, Mark: {value.Mark}");
            }
        }
    }
}
