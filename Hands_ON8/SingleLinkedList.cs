using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hands_ON8
{

    public class SinglyLinkedList
    {
        public class Node
        {
            public int Data;
            public Node Next;

            public Node(int data)
            {
                Data = data;
                Next = null;
            }
        }

        private Node head;

        public SinglyLinkedList()
        {
            head = null;
        }

        // Check if the linked list is empty
        public bool IsEmpty()
        {
            return head == null;
        }

        // Insert an element at the beginning of the list
        public void InsertFirst(int data)
        {
            Node newNode = new Node(data);
            newNode.Next = head;
            head = newNode;
        }

        // Delete the first element of the list
        public void DeleteFirst()
        {
            if (IsEmpty())
            {
                Console.WriteLine("The list is empty. Nothing to delete.");
                return;
            }
            head = head.Next;
        }

        // Search for an element in the list
        public bool Search(int data)
        {
            Node current = head;
            while (current != null)
            {
                if (current.Data == data)
                    return true;
                current = current.Next;
            }
            return false;
        }

        // Print the list elements
        public void PrintList()
        {
            if (IsEmpty())
            {
                Console.WriteLine("The list is empty.");
                return;
            }
            Node current = head;
            while (current != null)
            {
                Console.Write(current.Data + " ");
                current = current.Next;
            }
            Console.WriteLine();
        }
    }

}
