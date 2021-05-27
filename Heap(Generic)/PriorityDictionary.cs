using System;
using System.Collections.Generic;
using System.Text;

namespace Heap_Generic_
{
    abstract class PriorityDictionary<T, U> where U : IComparable
    {
        protected T[] storage { get; set; }
        protected int count { get; set; }
        public int Count { get => count; }
        protected Dictionary<T, U> dictionary { get; set; }
        public Dictionary<T, U>.KeyCollection Keys { get => dictionary.Keys; }
        public Dictionary<T, U>.ValueCollection Values { get => dictionary.Values; }

        public PriorityDictionary()
        {
            count = 0;
            storage = new T[32];
            dictionary = new Dictionary<T, U>();
        }
        public PriorityDictionary(int size)
        {
            count = 0;
            storage = new T[size];
            dictionary = new Dictionary<T, U>();
        }

        public void Insert(T key, U value)
        {
            count++;
            if(count == storage.Length)
            {
                DoubleCapacity();
            }
            storage[count - 1] = key;
            dictionary.Add(key, value);
            RestoreUp(count - 1);
        }
        public T PeakKey()
        {
            return storage[0];
        }
        public U PeakValue()
        {
            return dictionary[storage[0]];
        }
        public KeyValuePair<T,U> Pop()
        {
            var output = new KeyValuePair<T, U>(storage[0], dictionary[storage[0]]);
            dictionary.Remove(storage[0]);
            storage[0] = storage[count - 1];
            count--;
            RestoreDown(0);
            return output;
        }
        public T PopKey()
        {
            T output = storage[0];
            dictionary.Remove(output);
            storage[0] = storage[count - 1];
            count--;
            RestoreDown(0);
            return output;
        }
        public U PopValue()
        {
            U output = dictionary[storage[0]];
            dictionary.Remove(storage[0]);
            storage[0] = storage[count - 1];
            count--;
            RestoreDown(0);
            return output;
        }
        protected void DoubleCapacity()
        {
            T[] tempStorage = new T[storage.Length * 2];
            storage.CopyTo(tempStorage, 0);
            storage = tempStorage;
        }
        protected void Swap(int index1, int index2)
        {
            T tempStorage = storage[index1];
            storage[index1] = storage[index2];
            storage[index2] = tempStorage;
        }
        protected abstract void RestoreUp(int index);
        protected abstract void RestoreDown(int index);
    }
}
