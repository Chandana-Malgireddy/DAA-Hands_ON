using ScottPlot;
using System;
using System.Diagnostics;
using System.Linq;

namespace Hands_ON6
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            NonRandomQuickSort ndq = new NonRandomQuickSort();
            int[] sizes = { 100, 500, 1000, 5000, 10000 };

            // Lists to hold the execution times for best, worst, and average cases
            var bestCaseTimes = new List<double>();
            var worstCaseTimes = new List<double>();
            var averageCaseTimes = new List <double>();

            Console.WriteLine("Benchmarking Non-Random Quicksort:");

            foreach (int n in sizes)
            {
                // Best Case (sorted array)
                int[] bestCase = new int[n];
                for (int i = 0; i < n; i++)
                    bestCase[i] = i;

                // Worst Case (reverse sorted array)
                int[] worstCase = new int[n];
                for (int i = 0; i < n; i++)
                    worstCase[i] = n*n*n;

                // Average Case (random array)
                int[] averageCase = new int[n];
                Random rand = new Random();
                for (int i = 0; i < n; i++)
                    averageCase[i] = rand.Next(1, 100000);

                // Benchmark Best Case
                Stopwatch stopwatch = Stopwatch.StartNew();
                ndq.NonRandomQuicksort(bestCase, 0, bestCase.Length - 1);
                stopwatch.Stop();
                Console.WriteLine($"Best Case ({n} elements): {stopwatch.ElapsedMilliseconds} ms");
                bestCaseTimes.Add(stopwatch.ElapsedMilliseconds);

                // Benchmark Worst Case
                stopwatch.Restart();
                ndq.NonRandomQuicksort(worstCase, 0, worstCase.Length - 1);
                stopwatch.Stop();
                Console.WriteLine($"Worst Case ({n} elements): {stopwatch.ElapsedMilliseconds} ms");
                worstCaseTimes.Add(stopwatch.ElapsedMilliseconds);

                // Benchmark Average Case
                stopwatch.Restart();
                ndq.NonRandomQuicksort(averageCase, 0, averageCase.Length - 1);
                stopwatch.Stop();
                Console.WriteLine($"Average Case ({n} elements): {stopwatch.ElapsedMilliseconds} ms");
                averageCaseTimes.Add(stopwatch.ElapsedMilliseconds);
            }

            // Plotting with ScottPlot
            var plt = new Plot(600, 400);
            plt.Title("Non-Random Quicksort Benchmarking");
            plt.XLabel("Input Size (n)");
            plt.YLabel("Execution Time (ms)");

            // Add scatter plots for best, worst, and average cases
            plt.AddScatter(sizes.Select(x => (double)x).ToArray(), bestCaseTimes.ToArray(), label: "Best Case", lineWidth: 2, color: System.Drawing.Color.Green);
            plt.AddScatter(sizes.Select(x => (double)x).ToArray(), worstCaseTimes.ToArray(), label: "Worst Case", lineWidth: 2, color: System.Drawing.Color.Red);
            plt.AddScatter(sizes.Select(x => (double)x).ToArray(), averageCaseTimes.ToArray(), label: "Average Case", lineWidth: 2, color: System.Drawing.Color.Blue);

            // Display the legend
            plt.Legend();

            // Save the plot to a file
            string filePath = @"C:\Images\quicksort_benchmark_comparison.png";
            plt.SaveFig(filePath);

  
        }
    }
}
