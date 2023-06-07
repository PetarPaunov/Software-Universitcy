namespace _1
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal class Program
    {
        private static List<int>[] graph;
        private static bool[] visited;

        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());

            graph = new List<int>[n];
            visited = new bool[n];

            for (int i = 0; i < n; i++)
            {
                var line = Console.ReadLine();

                if (string.IsNullOrEmpty(line))
                {
                    graph[i] = new List<int>();
                }
                else
                {
                    var nodes = line
                    .Split(' ')
                    .Select(int.Parse)
                    .ToList();

                    graph[i] = nodes;
                }
            }

            for (int node = 0; node < graph.Length; node++)
            {
                var component = new List<int>();

                DepthFirstSearch(node, component);

                if (component.Count > 0)
                {
                    Console.WriteLine($"Connected component: {String.Join(' ', component)}");
                }
            }
        }

        private static void DepthFirstSearch(int node, List<int> component)
        {
            if (visited[node])
            {
                return;
            }

            visited[node] = true;

            foreach (var child in graph[node])
            {
                DepthFirstSearch(child, component);
            }

            component.Add(node);
        }
    }
}