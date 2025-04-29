using Hands_On15;
using static Hands_On15.BellmanFord;
class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Dijikstra's");
        var graph = new Dictionary<string, List<(string, int)>>()
        {
            { "s", new List<(string, int)>{ ("t",10), ("y",5) } },
            { "t", new List<(string, int)>{ ("x",1), ("y",2) } },
            { "x", new List<(string, int)>{ ("z",4) } },
            { "y", new List<(string, int)>{ ("t",3), ("x",9), ("z",2) } },
            { "z", new List<(string, int)>{ ("s",7), ("x",6) } },
        };

        Dijkstra.DijkstraAlgorithm(graph, "s");
        
        Console.WriteLine("Bellman-Ford");
        var vertices = new List<string> { "s", "t", "x", "y", "z" };
        var edges = new List<Edge>
        {
            new Edge("s", "t", 6),
            new Edge("s", "y", 7),
            new Edge("t", "x", 5),
            new Edge("t", "y", 8),
            new Edge("t", "z", -4),
            new Edge("x", "t", -2),
            new Edge("y", "x", -3),
            new Edge("y", "z", 9),
            new Edge("z", "s", 2),
            new Edge("z", "x", 7)
        };

        BellmanFordAlgorithm(edges, vertices, "s");
        Console.WriteLine("Floyd-Warshall");
        int INF = int.MaxValue;
        int[,] graph1 = {
            { 0, 3, 8, INF, -4 },
            { INF, 0, INF, 1, 7 },
            { INF, 4, 0, INF, INF },
            { 2, INF, -5, 0, INF },
            { INF, INF, INF, 6, 0 }
        };

        FloydWarshall.FloydWarshallAlgorithm(graph1);
    }
}