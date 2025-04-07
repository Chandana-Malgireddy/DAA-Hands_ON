using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hands_ON12
{
    public class DynamicArray
    {
        private int[] data;
        private int size;
        private int capacity;

        public DynamicArray()
        {
            capacity = 4;           
            data = new int[capacity];
            size = 0;
        }

        public int Size => size;
        public int Capacity => capacity;

        public void Push(int item)
        {
            if (size == capacity)
            {
                Resize(capacity * 2);
            }
            data[size++] = item;
        }

        public int Pop()
        {
            if (size == 0)
            {
                throw new InvalidOperationException("Array is empty.");
            }
            int item = data[--size];
            return item;
        }

        public int Get(int index)
        {
            if (index < 0 || index >= size)
            {
                throw new IndexOutOfRangeException();
            }
            return data[index];
        }

        public void Set(int index, int value)
        {
            if (index < 0 || index >= size)
            {
                throw new IndexOutOfRangeException();
            }
            data[index] = value;
        }

        public int this[int index]
        {
            get => Get(index);
            set => Set(index, value);
        }

        private void Resize(int newCapacity)
        {
            int[] newData = new int[newCapacity];
            for (int i = 0; i < size; i++)
            {
                newData[i] = data[i];
            }
            data = newData;
            capacity = newCapacity;
        }
    }

}
