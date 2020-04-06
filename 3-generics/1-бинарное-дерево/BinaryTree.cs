using System;
using System.Collections;
using System.Collections.Generic;

namespace Generics.BinaryTrees
{
    public class BinaryTree<T> : IEnumerable<T> where T : IComparable<T>
    {
        private bool initialized = false;

        public BinaryTree<T> Left { get; private set; }
        public BinaryTree<T> Right { get; private set; }
        public T Value { get; private set; }

        public void Add(T newValue)
        {
            if (!initialized)
            {
                Value = newValue;
                initialized = true;
            }
            else if (newValue.CompareTo(Value) < 1)
            {
                if (Left == null) Left = new BinaryTree<T>();
                Left.Add(newValue);
            }
            else
            {
                if (Right == null) Right = new BinaryTree<T>();
                Right.Add(newValue);
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            if (Left != null)
                foreach (var n in Left)
                    yield return n;
            if (initialized)
                yield return Value;
            if (Right != null)
                foreach (var n in Right)
                    yield return n;
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    public static class BinaryTree
    {
        public static BinaryTree<T> Create<T>(params T[] items) where T : IComparable<T>
        {
            BinaryTree<T> tree = new BinaryTree<T>();
            foreach (var item in items)
                tree.Add(item);
            return tree;
        }
    }
}