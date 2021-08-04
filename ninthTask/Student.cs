using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace ninthTask
{
    class Student
    {
        public string Name { get; private set; }
        public string TestName { get; private set; }
        public DateTime EndTime { get; private set; }
        public int Mark { get; private set; }

        public Student(string name, string testName, DateTime endTime, int mark, BinaryTree<int> marks)
        {
            Name = name;
            TestName = testName;
            EndTime = endTime;
            Mark = mark;
            marks.Add(Mark);
        }
    }
}
