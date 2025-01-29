using Hands_On_2;
using ScottPlot;
using System;
using System.ComponentModel.Design;
using System.Diagnostics;

using static System.Net.Mime.MediaTypeNames;

public class Program
{
    public static void Main(string[] args)
    {
    
        int[] inputSizes = { 100, 200, 500, 1000, 2000, 5000, 10000 };
        List<double> bubbleSortMemory = new List<double>();
        List<double> insertionSortMemory = new List<double>();
        List<double> selectionSortMemory = new List<double>();

        List<double> bubbleSortTimes = new List<double>();
        List<double> insertionSortTimes = new List<double>();
        List<double> selectionSortTimes = new List<double>();
        Console.WriteLine("Memory Usage (RAM): " + Process.GetCurrentProcess().PrivateMemorySize64 / (1024 * 1024) + " MB");
        
        Console.WriteLine("C# Runtime Version: " + Environment.Version.ToString());
        Stopwatch stopwatch = new Stopwatch();

        foreach (int n in inputSizes)
        {   
            int[] arr1 = GenerateShuffledArray(n);

            stopwatch.Restart();
            long beforeMemory = GC.GetTotalMemory(true);
            InsertionSort isort =new InsertionSort(arr1);
            stopwatch.Stop();
            long afterMemory = GC.GetTotalMemory(true);
            insertionSortTimes.Add(stopwatch.Elapsed.TotalMilliseconds);
            insertionSortMemory.Add((afterMemory - beforeMemory) / (1024 * 1024));

            arr1 = GenerateShuffledArray(n); 
            stopwatch.Restart();
            beforeMemory = GC.GetTotalMemory(true);
            SelectionSort ssort=new SelectionSort(arr1);
            stopwatch.Stop();
            afterMemory = GC.GetTotalMemory(true);
            selectionSortTimes.Add(stopwatch.Elapsed.TotalMilliseconds);
            selectionSortMemory.Add((afterMemory - beforeMemory) / (1024 * 1024));

            arr1 = GenerateShuffledArray(n); 
            stopwatch.Restart();
            beforeMemory = GC.GetTotalMemory(true);
            BubbleSort bsort=new BubbleSort(arr1);
            stopwatch.Stop();
            afterMemory = GC.GetTotalMemory(true);
            bubbleSortTimes.Add(stopwatch.Elapsed.TotalMilliseconds);
            bubbleSortMemory.Add((afterMemory - beforeMemory) / (1024 * 1024));
        }

        var plt = new Plot(600, 400); 
        plt.Title("Sorting Algorithm Runtime Comparison");
        plt.XLabel("Input Size");
        plt.YLabel("Execution Time (ms)");

        plt.AddScatter(inputSizes.Select(x => (double)x).ToArray(), bubbleSortTimes.ToArray(), label: "Bubble Sort");
        plt.AddScatter(inputSizes.Select(x => (double)x).ToArray(), insertionSortTimes.ToArray(), label: "Insertion Sort");
        plt.AddScatter(inputSizes.Select(x => (double)x).ToArray(), selectionSortTimes.ToArray(), label: "Selection Sort");
        
        plt.Legend();
        string filePath = @"C:\Images\sorting_algorithm_runtime_comparison1n.png";
        plt.SaveFig(filePath);

    }

    public static int[] GenerateShuffledArray(int size)
    {
        Random rand = new Random();
        int[] array = Enumerable.Range(0, size).ToArray();
        for (int i = 0; i < array.Length; i++)
        {
            int j = rand.Next(i, array.Length);
            int temp = array[i];
            array[i] = array[j];
            array[j] = temp;
        }
        return array;
    }

}