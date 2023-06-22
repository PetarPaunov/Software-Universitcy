namespace _03._Path_Finder
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

            for (int i = 0; i < graph.Length; i++)
            {
                var line = Console.ReadLine();

                if (string.IsNullOrEmpty(line))
                {
                    graph[i] = new List<int>();
                    continue;
                }

                var nodes = line
                    .Split(' ')
                    .Select(int.Parse)
                    .ToList();

                graph[i] = nodes;
            }

            var possiblePaths = int.Parse(Console.ReadLine());
            
            for (int i = 0; i < possiblePaths; i++)
            {
                visited = new bool[n];

                var path = Console.ReadLine()
                    .Split(' ')
                    .Select(int.Parse)
                    .ToArray();

                var startPathIndex = 0;
                var startNode = path[startPathIndex];

                DFS(startNode, startPathIndex, path);

                if (PathExists(path))
                {
                    Console.WriteLine("yes");
                }
                else
                {
                    Console.WriteLine("no");
                }
            }
        }

        private static bool PathExists(int[] path)
        {
            foreach (var node in path)
            {
                if (visited[node] == false)
                {
                    return false;
                }
            }

            return true;
        }

        private static void DFS(int index, int pathIndex, int[] path)
        {
            if (visited[index] || 
                pathIndex >= path.Length ||
                index != path[pathIndex])
            {
                return;
            }

            visited[index] = true;

            foreach (var child in graph[index])
            {
                DFS(child, pathIndex + 1, path);
            }
        }
    }
}