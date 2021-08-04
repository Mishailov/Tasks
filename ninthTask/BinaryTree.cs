using System;
using System.Collections;
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

        public void Remove(T Value)
        {
            Root = RemoveRecursive(Root, Value);
        }

        private BinaryTreeNode RemoveRecursive(BinaryTreeNode rootIterator, T Value)
        {
            if (rootIterator is null)
                return rootIterator;

            int value = Value.CompareTo(rootIterator.Data);

            if (value < 0)
                rootIterator.Left = RemoveRecursive(rootIterator.Left, Value);

            if (value > 0)
                rootIterator.Right = RemoveRecursive(rootIterator.Right, Value);
            else
            {
                if (rootIterator.Left == null)
                    return rootIterator.Left;
                else if (rootIterator.Right == null)
                    return rootIterator.Right;

                rootIterator.Data = MinValue(rootIterator.Right, rootIterator.Data);

                rootIterator.Right = RemoveRecursive(rootIterator.Right, rootIterator.Data);
            }

            return rootIterator;
        }

        private T MinValue(BinaryTreeNode tree, T minValue)
        {
            if (tree.Left != null)
            {
                return MinValue(tree.Left, tree.Left.Data);
            }

            return minValue;
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

        //public IEnumerator<T> GetEnumerator()
        //{
        //    return new BinaryTreeEnumerator(this);
        //}

        ///// <summary>
        ///// The BinaryTreeEnumerator implements the IEnumerator allowing foreach enumeration of the tree
        ///// </summary>
        //class BinaryTreeEnumerator : IEnumerator<T>
        //{
        //    BinaryTreeNode current;
        //    BinaryTree<T> theTree;

        //    public BinaryTreeEnumerator(BinaryTree<T> tree)
        //    {
        //        theTree = tree;
        //        current = null;
        //    }

        //    /// <summary>
        //    /// The MoveNext function traverses the tree in sorted order.
        //    /// </summary>
        //    /// <returns>True if we found a valid entry, False if we have reached the end</returns>
        //    public bool MoveNext()
        //    {
        //        // For the first entry, find the lowest valued node in the tree
        //        if (current == null)
        //            current = theTree.FindMostLeft(theTree.Root);
        //        else
        //        {
        //            // Can we go right-left?
        //            if (current.Right != null)
        //                current = theTree.FindMostLeft(current.Right);
        //            else
        //            {
        //                // Note the value we have found
        //                T CurrentValue = current.Data;

        //                // Go up the tree until we find a value larger than the largest we have
        //                // already found (or if we reach the root of the tree)
        //                while (current != null)
        //                {
        //                    current = current.Parent;
        //                    if (current != null)
        //                    {
        //                        int Compare = current.Data.CompareTo(CurrentValue);
        //                        if (Compare < 0) continue;
        //                    }
        //                    break;
        //                }

        //            }
        //        }
        //        return (current != null);
        //    }

        //    public T Current
        //    {
        //        get
        //        {
        //            if (current == null)
        //                throw new InvalidOperationException();
        //            return current.Data;
        //        }
        //    }

        //    object IEnumerator.Current
        //    {
        //        get
        //        {
        //            if (current == null)
        //                throw new InvalidOperationException();
        //            return current.Data;
        //        }
        //    }

        //    public void Dispose() { }
        //    public void Reset() { current = null; }
        //}
    }
}

