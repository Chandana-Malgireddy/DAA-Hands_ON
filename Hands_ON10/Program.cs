using System;
class Node
{
    public int Key, Value;
    public Node Next, Prev;
    public Node(int key, int value)
    {
        Key = key;
        Value = value;
        Next = Prev = null;
    }
}
class DoublyLinkedList
{
    public Node head;
    public DoublyLinkedList()
    {
        head = null;
    }
    public void Insert(int key, int value)
    {
        Node newNode = new Node(key, value);
        if (head != null)
        {
            newNode.Next = head;
            head.Prev = newNode;
        }
        head = newNode;
    }
    public bool Remove(int key)
    {
        Node current = head;
        while (current != null)
        {
            if (current.Key == key)
            {
                if (current.Prev != null) current.Prev.Next = current.Next;
                if (current.Next != null) current.Next.Prev = current.Prev;
                if (current == head) head = current.Next;
                return true;
            }
            current = current.Next;
        }
        return false;
    }
    public int Search(int key)
    {
        Node current = head;
        while (current != null)
        {
            if (current.Key == key) return current.Value;
            current = current.Next;
        }
        return -1; 
    }

    public void Clear()
    {
        head = null; 
    }
}
class HashTable
{
    private DoublyLinkedList[] table;
    private int capacity;
    private int size;
    private const double LOAD_FACTOR_UPPER = 1.0;
    private const double LOAD_FACTOR_LOWER = 0.25;
    private const double A = 0.6180339887; 
    public HashTable(int initialCapacity = 8)
    {
        capacity = initialCapacity;
        size = 0;
        table = new DoublyLinkedList[capacity];
        for (int i = 0; i < capacity; i++) table[i] = new DoublyLinkedList();
    }
    private int HashFunction(int key)
    {
        double frac = key * A - Math.Floor(key * A);
        return (int)(capacity * frac);
    }
    private void Resize(int newCapacity)
    {
        DoublyLinkedList[] newTable = new DoublyLinkedList[newCapacity];
        for (int i = 0; i < newCapacity; i++) newTable[i] = new DoublyLinkedList();

        foreach (var list in table)
        {
            Node current = list.head;
            while (current != null)
            {
                int newIndex = current.Key % newCapacity;
                newTable[newIndex].Insert(current.Key, current.Value);
                current = current.Next;
            }
        }

        table = newTable;
        capacity = newCapacity;
    }
    public void Insert(int key, int value)
    {
        int index = HashFunction(key);
        table[index].Insert(key, value);
        size++;

        if (size >= capacity * LOAD_FACTOR_UPPER) Resize(capacity * 2);
    }
    public void Remove(int key)
    {
        int index = HashFunction(key);
        if (table[index].Remove(key))
        {
            size--;
            if (size > 0 && size <= capacity * LOAD_FACTOR_LOWER) Resize(capacity / 2);
        }
    }
    public int Search(int key)
    {
        int index = HashFunction(key);
        return table[index].Search(key);
    }
}
class Program
{
    static void Main()
    {
        HashTable ht = new HashTable();
        ht.Insert(10, 100);
        ht.Insert(20, 200);
        ht.Insert(30, 300);
        Console.WriteLine(ht.Search(20)); 
        ht.Remove(20);
        Console.WriteLine(ht.Search(20)); 
    }
}
