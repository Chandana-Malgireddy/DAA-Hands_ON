using System;
using System.Collections.Generic;
namespace Hands_On15
{ 
    public class BellmanFord
    {
        static int INF = int.MaxValue;
        public class Edge
        {
            public string From, To;
            public int Weight;
            public Edge(string from, string to, int weight)
            {
                From = from; To = to; Weight = weight;
            }
        }

        public static bool BellmanFordAlgorithm(List<Edge> edges, List<string> vertices, string source)
        {
            var dist = new Dictionary<string, int>();
            foreach (var v in vertices)
                dist[v] = INF;
            dist[source] = 0;

            for (int i = 1; i < vertices.Count; i++)
            {
                foreach (var edge in edges)
                {
                    if (dist[edge.From] != INF && dist[edge.From] + edge.Weight < dist[edge.To])
                    dist[edge.To] = dist[edge.From] + edge.Weight;
                }
            }

            foreach (var edge in edges)
            {
                if (dist[edge.From] != INF && dist[edge.From] + edge.Weight < dist[edge.To])
                {
                    Console.WriteLine("Graph contains negative weight cycle");
                    return false;
                }
            }

            Console.WriteLine("Bellman-Ford Shortest Paths:");
            foreach (var kvp in dist)
            {
                Console.WriteLine($"{source} -> {kvp.Key}: {kvp.Value}");
            }
            return true;
        }

   
    }
}

