namespace _4
{
    using System;
    using System.Collections.Generic;

    internal class Program
    {
        private static List<int>[] graph;
        private static Dictionary<int, int> visited;

        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());

            graph = new List<int>[n];
            visited = new Dictionary<int, int>();

            for (int node = 0; node < graph.Length; node++)
            {
                graph[node] = new List<int>();

                var children = Console.ReadLine();

                for (int child = 0; child < children.Length; child++)
                {
                    if (children[child] == 'Y')
                    {
                        graph[node].Add(child);
                    }
                }
            }

            var result = 0;

            for (int node = 0; node < graph.Length; node++)
            {
                result += DFS(node);
            }

            Console.WriteLine(result);
        }

        private static int DFS(int node)
        {
            if (visited.ContainsKey(node))
            {
                return visited[node]; 
            }

            var salary = 0;

            if (graph[node].Count == 0)
            {
                salary = 1;
            }
            else
            {
                foreach (var child in graph[node])
                {
                    salary += DFS(child);
                }
            }

            visited[node] = salary;

            return salary;
        }
    }
}