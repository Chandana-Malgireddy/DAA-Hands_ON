using System;
using System.Collections.Generic;

class TopologicalSort
{
    private int V; // Number of vertices
    private List<int>[] adj; // Adjacency list

    public TopologicalSort(int vertices)
    {
        V = vertices;
        adj = new List<int>[V];
        for (int i = 0; i < V; ++i)
            adj[i] = new List<int>();
    }

    // Function to add an edge into the graph
    public void AddEdge(int u, int v)
    {
        adj[u].Add(v); // u -> v
    }

    // Recursive helper function for topological sort
    private void TopoSortUtil(int v, bool[] visited, Stack<int> stack)
    {
        visited[v] = true;

        foreach (var neighbor in adj[v])
        {
            if (!visited[neighbor])
                TopoSortUtil(neighbor, visited, stack);
        }

        stack.Push(v); // Push current vertex to stack after visiting neighbors
    }

    public void TopologicalSortPrint()
    {
        var visited = new bool[V];
        var stack = new Stack<int>();

        for (int i = 0; i < V; i++)
        {
            if (!visited[i])
                TopoSortUtil(i, visited, stack);
        }

        Console.WriteLine("Topological Sort:");
        while (stack.Count > 0)
            Console.Write(stack.Pop() + " ");
        Console.WriteLine();
    }
}
