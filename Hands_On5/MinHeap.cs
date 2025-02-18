using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hands_On5
{
    public class MinHeap<T> where T : IComparable<T>
    {
        private List<T> heap;
        public MinHeap()
        {
            heap = new List<T>();
        }
        private int Parent(int i)
        {
            return (i - 1) >> 1; 
        }
        private int Left(int i)
        {
            return (i << 1) + 1; 
        }
        private int Right(int i)
        {
            return (i << 1) + 2; 
        }
        public void BuildMinHeap(List<T> data)
        {
            heap = data;
            for (int i = heap.Count / 2 - 1; i >= 0; i--)
            {
                Heapify(i);
            }
        }
        private void Heapify(int i)
        {
            int left = Left(i);
            int right = Right(i);
            int smallest = i;           
            if (left < heap.Count && heap[left].CompareTo(heap[smallest]) < 0)
            {
                smallest = left;
            }
            if (right < heap.Count && heap[right].CompareTo(heap[smallest]) < 0)
            {
                smallest = right;
            }
            if (smallest != i)
            {
                Swap(i, smallest);
                Heapify(smallest);
            }
        }
        public T PopRoot()
        {
            if (heap.Count == 0)
                throw new InvalidOperationException("Heap is empty");

            T root = heap[0];
            T lastElement = heap[heap.Count - 1];
            heap.RemoveAt(heap.Count - 1);

            if (heap.Count > 0)
            {
                heap[0] = lastElement;
                Heapify(0);
            }

            return root;
        }
        public void Push(T value)
        {
            heap.Add(value);
            BubbleUp(heap.Count - 1);
        }
        private void BubbleUp(int i)
        {
            while (i > 0 && heap[Parent(i)].CompareTo(heap[i]) > 0)
            {
                Swap(i, Parent(i));
                i = Parent(i);
            }
        }
        private void Swap(int i, int j)
        {
            T temp = heap[i];
            heap[i] = heap[j];
            heap[j] = temp;
        }
        public T Peek()
        {
            if (heap.Count == 0)
                throw new InvalidOperationException("Heap is empty");

            return heap[0];
        }
        public int Size()
        {
            return heap.Count;
        }
        public override string ToString()
        {
            return string.Join(", ", heap);
        }
    }
}
