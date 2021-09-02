using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ninthTask.Test
{
    [TestClass]
    public class BinaryTreeTest
    {
        BinaryTreeComparer test = new BinaryTreeComparer();
        BinaryTree<Student> firstList = new BinaryTree<Student>();

        private void InitItemsForFirstList()
        {
            firstList.Add(new Student("Artem", "c#", DateTime.Now, 7));
            firstList.Add(new Student("Denis", "c#", DateTime.Now, 5));
            firstList.Add(new Student("Kirill", "c#", DateTime.Now, 6));
            firstList.Add(new Student("Vasya", "c#", DateTime.Now, 3));
        }

        [TestMethod]
        public void IsFindInFirstListCorrectValue_returnedTrue()
        {
            InitItemsForFirstList();

            var expected = new Student("Kirill", "c#", DateTime.Now, 6);

            Assert.IsTrue(firstList.Find(expected));
        }

        [TestMethod]
        public void IsFindInFirstListUncorrectValue_returnedFalse()
        {
            InitItemsForFirstList();

            var expected = new Student("Kirill", "c#", DateTime.Now, 2);

            Assert.IsFalse(firstList.Find(expected));
        }

        [TestMethod]
        public void IsDeletedValueInFirstList_returnedTrue()
        {
            InitItemsForFirstList();
            firstList.Remove(new Student("Vasya", "c#", DateTime.Now, 3));

            var expected = new Student("Vasya", "c#", DateTime.Now, 3);

            Assert.IsFalse(firstList.Find(expected));
        }

        [TestMethod]
        public void GetOrderedStudentList_returnedMarks7653()
        {
            InitItemsForFirstList();

            List<Student> actualList = new List<Student>();

            foreach (var item1 in firstList)
            {
                actualList.Add(item1);
            }

            List<Student> expectedList = new List<Student>
            {
                new Student("Vasya", "c#", DateTime.Now, 3),
                new Student("Denis", "c#", DateTime.Now, 5),
                new Student("Kirill", "c#", DateTime.Now, 6),
                new Student("Artem", "c#", DateTime.Now, 7)
            };

            for (int i = 0; i < actualList.Count; i++)
            {
                Assert.IsTrue(test.Equals(actualList[i],expectedList[i]));
            }
        }
    }
}
