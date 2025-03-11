using Hands_ON8;

class Program
{
    private static int Partition(int[] arr, int low, int high)
    {
        int pivot = arr[high]; 
        int i = low - 1; 
        for (int j = low; j < high; j++)
        {
            if (arr[j] <= pivot)
            {
                i++;
                int temp = arr[i];
                arr[i] = arr[j];
                arr[j] = temp;
            }
        }
        int temp1 = arr[i + 1];
        arr[i + 1] = arr[high];
        arr[high] = temp1;

        return i + 1; 
    }
    private static int QuickSelectRecursive(int[] arr, int low, int high, int i)
    {
        if (low == high)  
        {
            return arr[low];
        }
        Random rand = new Random();
        int pivotIndex = rand.Next(low, high + 1);
        int temp = arr[pivotIndex];
        arr[pivotIndex] = arr[high];
        arr[high] = temp;
        int partitionIndex = Partition(arr, low, high);
        if (i == partitionIndex)
            return arr[i];  
        else if (i < partitionIndex)
            return QuickSelectRecursive(arr, low, partitionIndex - 1, i);
        else
            return QuickSelectRecursive(arr, partitionIndex + 1, high, i);
    }
    public static int FindIthOrderStatistic(int[] arr, int i)
    {
        if (i < 1 || i > arr.Length)
            throw new ArgumentException("Invalid input: i must be between 1 and the length of the array");
        return QuickSelectRecursive(arr, 0, arr.Length - 1, i - 1);
    }
    public static void Main(string[] args)
    {
        int[] arr = { 7, 2, 5, 8, 4, 1, 5 };
        int i = 5;  

        try
        {
            int result = FindIthOrderStatistic(arr, i);
            Console.WriteLine($"The {i}th smallest element is: {result}");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        // Stack example
        Stack stack = new Stack(5);
        stack.Push(10);
        stack.Push(20);
        Console.WriteLine("Stack top: " + stack.Peek()); 
        Console.WriteLine("Popped: " + stack.Pop()); 
        Console.WriteLine("Stack top after pop: " + stack.Peek()); 

        // Queue example
        Queue queue = new Queue(5);
        queue.Enqueue(10);
        queue.Enqueue(20);
        Console.WriteLine("Queue front: " + queue.Peek()); 
        Console.WriteLine("Dequeued: " + queue.Dequeue()); 
        Console.WriteLine("Queue front after dequeue: " + queue.Peek()); 
        Console.WriteLine("Hello, World!");

        // Singly Linked List example
        SinglyLinkedList list = new SinglyLinkedList();
        list.InsertFirst(10);
        list.InsertFirst(20);
        list.InsertFirst(30);
        list.PrintList();
        Console.WriteLine("Search 20: " + list.Search(20)); 
        list.DeleteFirst();
        list.PrintList(); // Should print 20 10
    }
}