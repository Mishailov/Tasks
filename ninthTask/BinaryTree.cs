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
                BinaryTreeNode Iterator = Root;
                int Compare = Value.CompareTo(Iterator.Data);

                if (Compare <= 0)
                    if (Iterator.Left != null)
                    {
                        Iterator = Iterator.Left;
                    }
                    else
                    {
                        Iterator.Left = child;
                        child.Parent = Iterator;
                        Add(child.Parent.Data);
                    }

                if (Compare > 0)
                    if (Iterator.Right != null)
                    {
                        Iterator = Iterator.Right;
                    }
                    else
                    {
                        Iterator.Right = child;
                        child.Parent = Iterator;
                        Add(child.Parent.Data);
                    }
            }

        }

        public bool Find(T Value)
        {
            BinaryTreeNode Iterator = Root;
            if (Iterator != null)
            {
                int Compare = Value.CompareTo(Iterator.Data);

                if (Compare == 0) return true;
                if (Compare < 0)
                {
                    Iterator = Iterator.Left;
                }
                Iterator = Iterator.Right;
                return Find(Iterator.Data);
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
