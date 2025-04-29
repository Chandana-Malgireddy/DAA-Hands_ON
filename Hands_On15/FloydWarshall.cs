using System;

public class FloydWarshall
{
    static int INF = int.MaxValue;
    public static void FloydWarshallAlgorithm(int[,] graph1)
    {
        int V = graph1.GetLength(0);
        int[,] dist = new int[V, V];

        for (int i = 0; i < V; i++)
            for (int j = 0; j < V; j++)
                dist[i, j] = graph1[i, j];

        for (int k = 0; k < V; k++)
            for (int i = 0; i < V; i++)
                for (int j = 0; j < V; j++)
                    if (dist[i, k] != INF && dist[k, j] != INF && dist[i, k] + dist[k, j] < dist[i, j])
                        dist[i, j] = dist[i, k] + dist[k, j];

        Console.WriteLine("Floyd-Warshall Shortest Distances:");
        for (int i = 0; i < V; i++)
        {
            for (int j = 0; j < V; j++)
            {
                if (dist[i, j] == INF)
                    Console.Write("INF".PadLeft(7));
                else
                    Console.Write(dist[i, j].ToString().PadLeft(7));
            }
            Console.WriteLine();
        }
    }

   
}
