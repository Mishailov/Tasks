using System;

namespace ninthTask
{
    class Program
    {
        static void Main(string[] args)
        {
            BinaryTree<int> Test = new BinaryTree<int>(BinaryTree<int>.CompareFunction_Int);

            // Build the tree
            Test.Add(5);
            Test.Add(2);
            Test.Add(1);
            Test.Add(3);
            Test.Add(3); // Duplicates are OK
            Test.Add(4);
            Test.Add(6);
            Test.Add(10);
            Test.Add(7);
            Test.Add(8);
            Test.Add(9);

            foreach (int value in Test)
            {
                Console.WriteLine("Value: {0}", value);
            }
        }
    }
}
