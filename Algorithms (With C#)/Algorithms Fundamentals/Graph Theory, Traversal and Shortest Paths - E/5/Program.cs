namespace _5
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal class Program
    {
        class Edge
        {
            public string First { get; set; }
            public string Second { get; set; }
        }

        private static Dictionary<string, List<string>> graph;
        private static List<Edge> edges;

        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());

            graph = new Dictionary<string, List<string>>();
            edges = new List<Edge>();

            for (int i = 0; i < n; i++)
            {
                var kvp = Console.ReadLine()
                    .Split(" -> ")
                    .ToArray();

                var node = kvp[0];

                if (kvp.Length == 1)
                {
                    graph[node] = new List<string>();

                    continue;
                }

                var childrens = kvp[1]
                    .Split()
                    .ToList();

                graph[node] = childrens;

                foreach (var child in childrens)
                {
                    edges.Add(new Edge(){ First = node, Second = child});
                }
            }

            edges = edges
                    .OrderBy(x => x.First)
                    .ThenBy(x => x.Second)
                    .ToList();

            var reversedEdges = new HashSet<string>();
            var resultEdges = new List<string>();

            foreach (var edge in edges)
            {
                if (reversedEdges.Contains($"{edge.First} - {edge.Second}"))
                {
                    continue;
                }

                graph[edge.First].Remove(edge.Second);
                graph[edge.Second].Remove(edge.First);

                if (BFS(edge.First, edge.Second))
                {
                    resultEdges.Add($"{edge.First} - {edge.Second}");
                    reversedEdges.Add($"{edge.Second} - {edge.First}");
                }
                else
                {
                    graph[edge.First].Add(edge.Second);
                    graph[edge.Second].Add(edge.First);
                }
            }

            Console.WriteLine($"Edges to remove: {resultEdges.Count}");

            foreach (var edge in resultEdges)
            {
                Console.WriteLine(edge);
            }
        }

        private static bool BFS(string start, string destination)
        {
            var queue = new Queue<string>();
            queue.Enqueue(start);

            var visited = new HashSet<string>() { start };

            while (queue.Count > 0)
            {
                var node = queue.Dequeue();

                if (node == destination)
                {
                    return true;
                }

                foreach (var child in graph[node])
                {
                    if (visited.Contains(child))
                    {
                        continue;
                    }

                    visited.Add(child);
                    queue.Enqueue(child);
                }
            }

            return false;
        }
    }
}