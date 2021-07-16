using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace ninthTask
{
    class Student<T> where T : IComparable<T>
    {
        public string Name { get; private set; }
        public string TestName { get; private set; }
        public DateTime EndTime { get; private set; }
        public T Mark { get; private set; }

        public Student(string name, string testName, DateTime endTime, T mark, BinaryTree<int> marks)
        {
            Name = name;
            TestName = testName;
            EndTime = endTime;
            Mark = mark;
            marks.Add(CompareTo(this));
        }

        public int CompareTo(Student<T> otherStudent)
        {
            if (otherStudent == null)
                return 0;

            return Mark.CompareTo(otherStudent.Mark);
        }
    }
}
