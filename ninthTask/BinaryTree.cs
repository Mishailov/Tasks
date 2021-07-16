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
                while (true)
                {
                    int Compare = Value.CompareTo(Iterator.Data);

                    if (Compare <= 0)
                        if (Iterator.Left != null)
                        {
                            Iterator = Iterator.Left;
                            continue;
                        }
                        else
                        {
                            Iterator.Left = child;
                            child.Parent = Iterator;
                            break;
                        }
                    if (Compare > 0)
                        if (Iterator.Right != null)
                        {
                            Iterator = Iterator.Right;
                            continue;
                        }
                        else
                        {
                            Iterator.Right = child;
                            child.Parent = Iterator;
                            break;
                        }
                }

            }

        }

        public bool Find(T Value)
        {
            BinaryTreeNode Iterator = Root;
            while (Iterator != null)
            {
                int Compare = Value.CompareTo(Iterator.Data);

                if (Compare == 0) return true;
                if (Compare < 0)
                {
                    Iterator = Iterator.Left;
                    continue;
                }
                Iterator = Iterator.Right;
            }
            return false;
        }

        BinaryTreeNode FindMostLeft(BinaryTreeNode start)
        {
            BinaryTreeNode node = start;
            while (true)
            {
                if (node.Left != null)
                {
                    node = node.Left;
                    continue;
                }
                break;
            }
            return node;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return new BinaryTreeEnumerator(this);
        }

        class BinaryTreeEnumerator : IEnumerator<T>
        {
            BinaryTreeNode current;
            BinaryTree<T> theTree;

            public BinaryTreeEnumerator(BinaryTree<T> tree)
            {
                theTree = tree;
                current = null;
            }

            public bool MoveNext()
            {
                if (current == null)
                    current = theTree.FindMostLeft(theTree.Root);
                else
                {
                    if (current.Right != null)
                        current = theTree.FindMostLeft(current.Right);
                    else
                    {
                        T CurrentValue = current.Data;

                        while (current != null)
                        {
                            current = current.Parent;
                            if (current != null)
                            {
                                int Compare = current.Data.CompareTo(CurrentValue);
                                if (Compare < 0) continue;
                            }
                            break;
                        }

                    }
                }
                return (current != null);
            }

            public T Current
            {
                get
                {
                    if (current == null)
                        throw new InvalidOperationException();
                    return current.Data;
                }
            }

            object System.Collections.IEnumerator.Current => throw new NotImplementedException();

            public void Dispose() { }
            public void Reset() { current = null; }
        }
    }
}
