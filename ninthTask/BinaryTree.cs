using System;
using System.Collections.Generic;
using System.Text;

namespace ninthTask
{
    class BinaryTree<T> where T : IComparable<T>
    {
        class BinaryTreeNode
        {
            public BinaryTreeNode Left;
            public BinaryTreeNode Right;
            public BinaryTreeNode Parent;
            public T Data;

            public BinaryTreeNode()
            {
                Left = null;
                Right = null;
                Parent = null;
            }
        }

        BinaryTreeNode Root;

        public void Add(T Value)
        {   
            BinaryTreeNode child = new BinaryTreeNode();

            child.Data = Value;

            if (Root == null)
            {
                Root = child;
            }
            else
            {
                BinaryTreeNode Interator = Root;
                AddRecursive(Value, Interator, child);
            }

        }

        private void AddRecursive(T Value, BinaryTreeNode rootIterator, BinaryTreeNode child)
        {
            int Compare = Value.CompareTo(rootIterator.Data);

            if (Compare <= 0)
                if (rootIterator.Left != null)
                {
                    rootIterator = rootIterator.Left;
                    AddRecursive(Value, rootIterator, child);
                }
                else
                {
                    rootIterator.Left = child;
                    child.Parent = rootIterator;
                }

            if (Compare > 0)
                if (rootIterator.Right != null)
                {
                    rootIterator = rootIterator.Right;
                    AddRecursive(Value, rootIterator, child);
                }
                else
                {
                    rootIterator.Right = child;
                    child.Parent = rootIterator;
                }
        }

        public bool Find(T Value)
        {
            BinaryTreeNode Iterator = Root;
            return FindRecursive(Value, Iterator);
        }

        private bool FindRecursive(T Value, BinaryTreeNode rootIterator)
        {
            if (rootIterator != null)
            {
                int Compare = Value.CompareTo(rootIterator.Data);

                if (Compare == 0) return true;
                if (Compare < 0)
                {
                    rootIterator = rootIterator.Left;
                    return FindRecursive(Value, rootIterator);
                }
                rootIterator = rootIterator.Right;
                return FindRecursive(Value, rootIterator);
            }
            return false;
        }

        BinaryTreeNode FindMostLeft(BinaryTreeNode start)
        {
            BinaryTreeNode node = start;
            if (node.Left != null)
            {
                node = node.Left;
                return FindMostLeft(node);
            }

            return node;
        }
    }
}
