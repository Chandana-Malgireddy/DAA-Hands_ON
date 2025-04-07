using Hands_ON12;

internal class Program
{
    private static void Main(string[] args)
    {
        var arr = new DynamicArray();
        arr.Push(10);
        arr.Push(20);
        arr.Push(30);
        arr.Push(40);
        arr.Push(50);  

        Console.WriteLine("Size: " + arr.Size);        
        Console.WriteLine("Capacity: " + arr.Capacity); 

        arr[2] = 99;
        Console.WriteLine("Element at index 2: " + arr[2]);

        Console.WriteLine("Popped: " + arr.Pop());
    }
}