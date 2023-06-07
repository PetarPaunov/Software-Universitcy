namespace _2
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal class Program
    {
        private static Dictionary<string, List<string>> graph;
        private static Dictionary<string, int> dependacies;

        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());

            graph = new Dictionary<string, List<string>>();
            dependacies = new Dictionary<string, int>();

            GenerateGraph(n);
            GenerateDependacies();

            var sorted = new List<string>();

            while (dependacies.Count > 0)
            {
                var nodeToRemove = dependacies.FirstOrDefault(x => x.Value == 0).Key;

                if (nodeToRemove == null)
                {
                    break;
                }

                dependacies.Remove(nodeToRemove);
                sorted.Add(nodeToRemove);

                foreach (var child in graph[nodeToRemove])
                {
                    dependacies[child] -= 1;
                }
            }

            if (dependacies.Count > 0)
            {
                Console.WriteLine("Invalid topological sorting");
            }
            else
            {
                Console.WriteLine($"Topological sorting: {string.Join(", ", sorted)}");
            }
        }

        private static void GenerateDependacies()
        {
            foreach (var pairs in graph)
            {
                var node = pairs.Key;
                var childrens = pairs.Value;

                if (!dependacies.ContainsKey(node))
                {
                    dependacies[node] = 0;
                }

                foreach (var child in childrens)
                {
                    if (!dependacies.ContainsKey(child))
                    {
                        dependacies[child] = 1;
                    }
                    else
                    {
                        dependacies[child] += 1;
                    }
                }
            }
        }

        private static void GenerateGraph(int n)
        {
            for (int i = 0; i < n; i++)
            {
                var kav = Console.ReadLine().Split("->", StringSplitOptions.RemoveEmptyEntries)
                    .Select(x => x.Trim())
                    .ToArray();

                var key = kav[0];

                if (kav.Length < 2)
                {
                    graph[key] = new List<string>();
                    continue;
                }

                var childs = kav[1];

                graph[key] = new List<string>(childs.Split(", "));
            }
        }
    }
}