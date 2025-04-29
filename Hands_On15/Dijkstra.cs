using System;
using System.Collections.Generic;
namespace Hands_On15
{
    public class Dijkstra
    {
        static int INF = int.MaxValue;
        public static void DijkstraAlgorithm(Dictionary<string, List<(string, int)>> graph, string source)
        {
            var dist = new Dictionary<string, int>();
            var prev = new Dictionary<string, string>();
            var visited = new HashSet<string>();

            foreach (var node in graph.Keys)
                dist[node] = INF;
            dist[source] = 0;

            while (visited.Count < graph.Count)
            {
                string u = null;
                int minDist = INF;
                foreach (var node in graph.Keys)
                {
                    if (!visited.Contains(node) && dist[node] < minDist)
                    {
                        minDist = dist[node];
                        u = node;
                    }
                }

                if (u == null) break;
                visited.Add(u);

                foreach (var (v, weight) in graph[u])
                {
                    if (dist[u] + weight < dist[v])
                    {
                        dist[v] = dist[u] + weight;
                        prev[v] = u;
                    }
                }
            }

            Console.WriteLine("Dijkstra's Shortest Paths:");
            foreach (var kvp in dist)
            {
                Console.WriteLine($"{source} -> {kvp.Key}: {kvp.Value}");
            }
        }

    }
}
