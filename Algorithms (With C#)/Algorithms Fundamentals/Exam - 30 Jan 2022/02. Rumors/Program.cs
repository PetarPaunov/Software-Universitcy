namespace _02._Rumors
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal class Program
    {
        private static List<int>[] graph;
        private static bool[] visited;
        private static int[] parent;

        static void Main(string[] args)
        {
            int peopleCount = int.Parse(Console.ReadLine());
            int conections = int.Parse(Console.ReadLine());

            graph = new List<int>[peopleCount + 1];
            visited = new bool[graph.Length];
            parent = new int[graph.Length];

            Array.Fill(parent, -1);

            for (int i = 0; i < graph.Length; i++)
            {
                graph[i] = new List<int>();
            }

            for (int i = 0; i < conections; i++)
            {
                var edge = Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();

                var firstNote = edge[0];
                var secondNote = edge[1];

                graph[firstNote].Add(secondNote);
                graph[secondNote].Add(firstNote);
            }

            var start = int.Parse(Console.ReadLine());

            BFS(start);
        }

        private static void BFS(int start)
        {
            var queue = new Queue<int>();
            queue.Enqueue(start);

            visited[start] = true;

            while (queue.Count > 0)
            {
                var node = queue.Dequeue();

                if (node != start)
                {
                    var path = GetPath(node);

                    Console.WriteLine($"{start} -> {node} ({path.Count - 1})");
                }

                foreach (var child in graph[node])
                {
                    if (!visited[child])
                    {
                        parent[child] = node;
                        visited[child] = true;
                        queue.Enqueue(child);
                    }
                }
            }
        }

        private static Stack<int> GetPath(int node)
        {
            var path = new Stack<int>();

            var index = node;

            while (index != -1)
            {
                path.Push(index);
                index = parent[index];
            }

            return path;
        }
    }
}