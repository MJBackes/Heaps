using System;
using System.Collections.Generic;
using System.Text;

namespace Heap_Generic_
{
    abstract class Heap<T>
    {
        protected T[] Storage { get; set; }
        protected int count { get; set; }
        public int Count { get => count; }

        public Heap()
        {
            Storage = new T[32];
            count = 0;
        }
        public Heap(int size)
        {
            Storage = new T[size];
            count = 0;
        }

        public void Insert(T input)
        {
            count++;
            if (count == Storage.Length)
            {
                DoubleCapacity();
            }
            Storage[count - 1] = input;
            RestoreUp(count - 1);
        }
        public T Peak()
        {
            return Storage[0];
        }
        public T Pop()
        {
            T output = Storage[0];
            Storage[0] = Storage[count - 1];
            count--;
            RestoreDown(0);
            return output;
        }
        private void DoubleCapacity()
        {
            T[] tempStorage = new T[Storage.Length * 2];
            Storage.CopyTo(tempStorage, 0);
            Storage = tempStorage;
        }
        protected void Swap(int index1, int index2)
        {
            T tempStorage = Storage[index1];
            Storage[index1] = Storage[index2];
            Storage[index2] = tempStorage;
        }
        protected abstract void RestoreUp(int index);
        protected abstract void RestoreDown(int index);
    }
}
