using ScottPlot;
using System.Diagnostics;
using System.Reflection.Metadata.Ecma335;

class Program
{
    private static void Main(string[] args)
    {
        //Console.WriteLine("Hello, World!");
         int[] inputSizes = { 100, 200, 500, 1000, 2000, 5000, 10000 };
        List<double> Times = new List<double>();
        Stopwatch stopwatch = new Stopwatch();
        
        int x = 1,y=1;
        foreach (int n in inputSizes)
        {
            stopwatch.Restart();
            for (int i =1;i<=n;i++)
            {
                for(int j =1;j<=n;j++)
                {
                    x = x + 1;
                    y = i + j;
                }
            }
            stopwatch.Stop();
            Times.Add(stopwatch.Elapsed.TotalMilliseconds);

        }
        var plt = new Plot(600, 400);
        plt.Title("Input(n) vs Time(n)");
        plt.XLabel("Input Size");
        plt.YLabel("Execution Time (ms)");
        plt.AddScatter(inputSizes.Select(x => (double)x).ToArray(), Times.ToArray(), label: "Func(n)");
        plt.Legend();
        string filePath = @"C:\Images\nvstimeafteraddingy.png";
        plt.SaveFig(filePath);

    }
}