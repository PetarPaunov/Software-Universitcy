namespace _3
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
            var n = int.Parse(Console.ReadLine());
            var e = int.Parse(Console.ReadLine());

            graph = new List<int>[n + 1];
            visited = new bool[graph.Length];
            parent = new int[graph.Length];

            Array.Fill(parent, -1);

            for (int i = 0; i < graph.Length; i++)
            {
                graph[i] = new List<int>();
            }

            for (int i = 0; i < e; i++)
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
            var end = int.Parse(Console.ReadLine());

            BFS(start, end);
        }

        private static void BFS(int start, int end)
        {
            var queue = new Queue<int>();
            queue.Enqueue(start);

            visited[start] = true;

            while (queue.Count > 0)
            {
                var node = queue.Dequeue();

                if (node == end)
                {
                    var path = GetPath(end);

                    Console.WriteLine($"Shortest path length is: {path.Count - 1}");
                    Console.WriteLine(String.Join(' ', path));

                    break;
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

        private static Stack<int> GetPath(int end)
        {
            var path = new Stack<int>();

            var index = end;

            while (index != -1)
            {
                path.Push(index);
                index = parent[index];
            }

            return path;
        }
    }
}
