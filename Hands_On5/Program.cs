using Hands_On5;

public class Program
{
    private static void Main(string[] args)
    {
        // Example 1: MinHeap with integers
        MinHeap<int> minHeap = new MinHeap<int>();
        minHeap.BuildMinHeap(new List<int> { 5, 13, 2, 25, 7, 17, 20, 8, 4 });
        Console.WriteLine("Initial Min Heap: " + minHeap);

        // Pop the root
        Console.WriteLine("Popped root (min): " + minHeap.PopRoot());
        Console.WriteLine("Min Heap after pop: " + minHeap);

        // Push a new element
        minHeap.Push(1);
        Console.WriteLine("Min Heap after push 1: " + minHeap);

        // Peek at the root
        Console.WriteLine("Peek root: " + minHeap.Peek());

        // Pop the root again
        Console.WriteLine("Popped root (min): " + minHeap.PopRoot());
        Console.WriteLine("Min Heap after second pop: " + minHeap);

        // Example 2: MinHeap with floating point numbers
        MinHeap<double> minHeap2 = new MinHeap<double>();
        minHeap2.BuildMinHeap(new List<double> { 3.14, 1.59, 2.65, 5.89, 7.32 });
        Console.WriteLine("Initial Min Heap with floats: " + minHeap2);
        minHeap2.Push(1.41);
        Console.WriteLine("Min Heap after push 1.41: " + minHeap2);
        Console.WriteLine("Popped root from float heap: " + minHeap2.PopRoot());
        Console.WriteLine("Min Heap after popping root: " + minHeap2);
    }
}