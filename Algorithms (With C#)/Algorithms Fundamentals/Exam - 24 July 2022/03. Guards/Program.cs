namespace _03._Guards
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal class Program
    {
        private static bool[] visited;
        private static List<int>[] graph;
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var m = int.Parse(Console.ReadLine());

            graph = new List<int>[n + 1];
            visited = new bool[n + 1];

            for (int node = 0; node < graph.Length; node++)
            {
                graph[node] = new List<int>();
            }

            for (int i = 0; i < m; i++)
            {
                var edge = Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();

                var from = edge[0];
                var to = edge[1];

                graph[from].Add(to);
            }

            var startNode = int.Parse(Console.ReadLine());

            DFS(startNode);

            for (int i = 1; i < visited.Length; i++)
            {
                if (!visited[i])
                {
                    Console.Write(i + " ");
                }
            }
        }

        private static void DFS(int startNode)
        {
            if (visited[startNode])
            {
                return;
            }

            visited[startNode] = true;

            foreach (var node in graph[startNode])
            {
                DFS(node);
            }
        }
    }
}