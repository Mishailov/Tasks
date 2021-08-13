using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ninthTask.Test
{
    [TestClass]
    public class BinaryTreeTest
    {
        BinaryTree<int> firstList = new BinaryTree<int>();

        private void InitItemsForFirstList()
        {
            firstList.Add(3);
            firstList.Add(4);
            firstList.Add(5);
        }

        [TestMethod]
        public void IsFindInFirstListCorrectValue_returnedTrue()
        {
            InitItemsForFirstList();

            Assert.IsTrue(firstList.Find(3));
        }

        [TestMethod]
        public void IsFindInFirstListUncorrectValue_returnedFalse()
        {
            InitItemsForFirstList();

            Assert.IsFalse(firstList.Find(99));
        }

        [TestMethod]
        public void IsDeletedValueInFirstList_returnedTrue()
        {
            InitItemsForFirstList();
            firstList.Remove(4);

            Assert.IsFalse(firstList.Find(4));
        }
    }
}
