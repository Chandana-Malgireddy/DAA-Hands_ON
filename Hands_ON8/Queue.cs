using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hands_ON8
{

    public class Queue
    {
        private int[] Q;
        private int head;
        private int tail;

        public Queue(int size)
        {
            Q = new int[size];
            head = -1;
            tail = -1;
        }
        public bool IsEmpty()
        {
            return head == -1;
        }
        public bool IsFull()
        {
            return tail == Q.Length - 1;
        }
        public void Enqueue(int item)
        {
            if (IsFull())
            {
                Console.WriteLine("Queue is full. Cannot enqueue element.");
                return;
            }
            if (head == -1)
                head = 0;
            Q[++tail] = item;
        }
        public int Dequeue()
        {
            if (IsEmpty())
            {
                Console.WriteLine("Queue is empty. Cannot dequeue element.");
                return -1;
            }
            int dequeuedElement = Q[head];
            if (head == tail)
                head = tail = -1; 
            else
                head++;
            return dequeuedElement;
        }

        public int Peek()
        {
            if (IsEmpty())
            {
                Console.WriteLine("Queue is empty.");
                return -1; 
            }
            return Q[head];
        }
    }

}
