internal class Program
{
    private static void Main(string[] args)
    {
        // Topological Sort Test
        var topo = new TopologicalSort(6);
        topo.AddEdge(5, 2);
        topo.AddEdge(5, 0);
        topo.AddEdge(4, 0);
        topo.AddEdge(4, 1);
        topo.AddEdge(2, 3);
        topo.AddEdge(3, 1);
        topo.TopologicalSortPrint();

        // DFS Test
        var dfs = new DepthFirstSearch(4);
        dfs.AddEdge(0, 1);
        dfs.AddEdge(0, 2);
        dfs.AddEdge(1, 2);
        dfs.AddEdge(2, 0);
        dfs.AddEdge(2, 3);
        dfs.AddEdge(3, 3);
        Console.WriteLine("\nDFS from vertex 2:");
        dfs.DFS(2);

        // Kruskal's Algorithm Test
        Console.WriteLine();
        var kruskal = new KruskalAlgorithm(4);
        kruskal.AddEdge(0, 1, 10);
        kruskal.AddEdge(0, 2, 6);
        kruskal.AddEdge(0, 3, 5);
        kruskal.AddEdge(1, 3, 15);
        kruskal.AddEdge(2, 3, 4);
        kruskal.KruskalMST();
    }
}