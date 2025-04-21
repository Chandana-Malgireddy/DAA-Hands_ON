using System;
using System.Collections.Generic;

class DepthFirstSearch
{
    private int V;
    private List<int>[] adj;

    public DepthFirstSearch(int v)
    {
        V = v;
        adj = new List<int>[v];
        for (int i = 0; i < v; i++)
            adj[i] = new List<int>();
    }

    public void AddEdge(int v, int w)
    {
        adj[v].Add(w);
    }

    public void DFS(int v)
    {
        bool[] visited = new bool[V];
        DFSUtil(v, visited);
    }

    private void DFSUtil(int v, bool[] visited)
    {
        visited[v] = true;
        Console.Write(v + " ");

        foreach (int i in adj[v])
            if (!visited[i])
                DFSUtil(i, visited);
    }
}
