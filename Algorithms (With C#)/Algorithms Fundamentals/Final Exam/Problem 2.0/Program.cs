namespace Problem_2._0
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.Intrinsics.Arm;

    internal class Program
    {
        private static Dictionary<string, HashSet<string>> graph;
        private static HashSet<string> visited;

        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());

            graph = new Dictionary<string, HashSet<string>>();
            visited = new HashSet<string>();

            for (int i = 0; i < n; i++)
            {
                var line = Console.ReadLine()
                    .Split()
                    .ToArray();

                var from = line[0];
                var to = line[1];

                if (!graph.ContainsKey(from))
                {
                    graph[from] = new HashSet<string>();
                }

                if (!graph.ContainsKey(to))
                {
                    graph[to] = new HashSet<string>();
                }

                graph[from].Add(to);
                graph[to].Add(from);
            }

            var componetsCount = 0;

            foreach (var node in graph.Keys)
            {
                if (!visited.Contains(node))
                {
                    componetsCount++;
                    DFS(node);
                }
            }

            Console.WriteLine(componetsCount);
        }

        private static void DFS(string node)
        {
            if (visited.Contains(node))
            {
                return;
            }

            visited.Add(node);

            foreach (var child in graph[node])
            {
                DFS(child);
            }
        }
    }
}