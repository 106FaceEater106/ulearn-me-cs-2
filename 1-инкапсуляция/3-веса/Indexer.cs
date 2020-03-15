using System;

namespace Incapsulation.Weights
{
    class Indexer
    {
        private readonly double[] arr;
        private readonly int start;

        public int Length { get; }

        public Indexer(double[] array, int start, int length)
        {
            if ((start > array.Length - 1 && length != 0)
                || start < 0
                || length < 0
                || start + length > array.Length)
                throw new ArgumentException();
            arr = array;
            this.start = start;
            Length = length;
        }

        private void CheckIndex(int index)
        {
            if (index < 0 || index > arr.Length - start - 2)
                throw new IndexOutOfRangeException();
        }

        public double this[int i]
        {
            get {
                CheckIndex(i);
                return arr[start + i];
            }
            set {
                CheckIndex(i);
                arr[start + i] = value;
            }
        }
    }
}
