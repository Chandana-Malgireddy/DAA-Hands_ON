using System;
using System.Collections.Generic;

class KruskalAlgorithm
{
    class Edge : IComparable<Edge>
    {
        public int Src, Dest, Weight;
        public int CompareTo(Edge compareEdge)
        {
            return this.Weight - compareEdge.Weight;
        }
    }

    class Subset
    {
        public int Parent, Rank;
    }

    private int V, E;
    private List<Edge> edges;

    public KruskalAlgorithm(int v)
    {
        V = v;
        edges = new List<Edge>();
    }

    public void AddEdge(int src, int dest, int weight)
    {
        edges.Add(new Edge { Src = src, Dest = dest, Weight = weight });
    }

    private int Find(Subset[] subsets, int i)
    {
        if (subsets[i].Parent != i)
            subsets[i].Parent = Find(subsets, subsets[i].Parent);
        return subsets[i].Parent;
    }

    private void Union(Subset[] subsets, int x, int y)
    {
        int xroot = Find(subsets, x);
        int yroot = Find(subsets, y);

        if (subsets[xroot].Rank < subsets[yroot].Rank)
            subsets[xroot].Parent = yroot;
        else if (subsets[xroot].Rank > subsets[yroot].Rank)
            subsets[yroot].Parent = xroot;
        else
        {
            subsets[yroot].Parent = xroot;
            subsets[xroot].Rank++;
        }
    }

    public void KruskalMST()
    {
        List<Edge> result = new List<Edge>();
        edges.Sort();

        Subset[] subsets = new Subset[V];
        for (int v = 0; v < V; ++v)
        {
            subsets[v] = new Subset { Parent = v, Rank = 0 };
        }

        foreach (Edge nextEdge in edges)
        {
            int x = Find(subsets, nextEdge.Src);
            int y = Find(subsets, nextEdge.Dest);

            if (x != y)
            {
                result.Add(nextEdge);
                Union(subsets, x, y);
            }

            if (result.Count == V - 1)
                break;
        }

        Console.WriteLine("Edges in MST (Kruskal):");
        foreach (Edge e in result)
            Console.WriteLine($"{e.Src} -- {e.Dest} == {e.Weight}");
    }
}
