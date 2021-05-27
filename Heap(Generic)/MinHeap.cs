using System;
using System.Collections.Generic;
using System.Text;

namespace Heap_Generic_
{
    class MinHeap<T> : Heap<T> where T : IComparable
    {

        public MinHeap() : base()
        {
        }
        public MinHeap(int size) : base(size)
        {
        }
        protected override void RestoreUp(int index)
        {
            if (index == 0)
                return;
            int parentIndex = (index - 1) / 2;
            if (Storage[index].CompareTo(Storage[parentIndex]) < 0)
            {
                Swap(index, parentIndex);
                if (parentIndex != 0)
                    RestoreUp(parentIndex);
            }
        }
        protected override void RestoreDown(int index)
        {
            int leftChildIndex = 2 * index + 1;
            int rightChildIndex = 2 * index + 2;
            if (leftChildIndex >= count)
                return;
            if (rightChildIndex >= count)
            {
                if (Storage[leftChildIndex].CompareTo(Storage[index]) < 0)
                    Swap(leftChildIndex, index);
                return;
            }
            if (Storage[leftChildIndex].CompareTo(Storage[index]) < 0 || Storage[rightChildIndex].CompareTo(Storage[index]) < 0)
            {
                int swapIndex = Storage[leftChildIndex].CompareTo(Storage[rightChildIndex]) < 0 ? leftChildIndex : rightChildIndex;
                Swap(index, swapIndex);
                RestoreDown(swapIndex);
            }
        }

    }
}
