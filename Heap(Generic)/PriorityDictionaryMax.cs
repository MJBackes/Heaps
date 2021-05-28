using System;
using System.Collections.Generic;
using System.Text;

namespace Heap_Generic_
{
    class PriorityDictionaryMax<T,U> : PriorityDictionary<T,U> where U : IComparable
    {
        public PriorityDictionaryMax() : base()
        {

        }
        public PriorityDictionaryMax(int size) : base(size)
        {

        }

        protected override void RestoreDown(int index)
        {
            int leftChildIndex = (index * 2) + 1;
            int rightChildIndex = (index * 2) + 2;
            if (leftChildIndex >= count)
                return;
            if(rightChildIndex >= count)
            {
                if(dictionary[storage[leftChildIndex]].CompareTo(dictionary[storage[index]]) > 0)
                {
                    Swap(index, leftChildIndex);
                }
                return;
            }
            if(dictionary[storage[leftChildIndex]].CompareTo(dictionary[storage[index]]) > 0 || dictionary[storage[rightChildIndex]].CompareTo(dictionary[storage[index]]) > 0)
            {
                int swapIndex = dictionary[storage[leftChildIndex]].CompareTo(dictionary[storage[rightChildIndex]]) >= 0 ? leftChildIndex : rightChildIndex;
                Swap(index, swapIndex);
                RestoreDown(swapIndex);
            }
        }
        protected override void RestoreUp(int index)
        {
            if (index == 0)
                return;
            int parentIndex = (index - 1) / 2;
            if(dictionary[storage[index]].CompareTo(dictionary[storage[parentIndex]]) > 0)
            {
                Swap(index, parentIndex);
                if(parentIndex > 0)
                    RestoreUp(parentIndex);
            }
        }
    }
}
