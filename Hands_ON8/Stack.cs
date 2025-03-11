using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hands_ON8
{
    public class Stack
    {
        private int[] S;
        private int top;
        public Stack(int size)
        {
            S = new int[size];
            top = -1;
        }
        public bool IsEmpty()
        {
            return top == -1;
        }
        public bool IsFull()
        {
            return top == S.Length - 1;
        }
        public void Push(int item)
        {
            if (IsFull())
            {
                Console.WriteLine("Stack is full. Cannot push element.");
                return;
            }
            S[++top] = item;
        }

        public int Pop()
        {
            if (IsEmpty())
            {
                Console.WriteLine("Stack is empty. Cannot pop element.");
                return -1; 
            }
            return S[top--];
        }
        public int Peek()
        {
            if (IsEmpty())
            {
                Console.WriteLine("Stack is empty.");
                return -1; 
            }
            return S[top];
        }
    }

}
