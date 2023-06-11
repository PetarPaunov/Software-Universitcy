namespace _2
{
    using System;
    using System.Collections.Generic;

    internal class Program
    {
        private static char[,] graph;
        private static bool[,] visited;

        private static SortedDictionary<char, int> areas;

        static void Main(string[] args)
        {
            var rows = int.Parse(Console.ReadLine());
            var cols = int.Parse(Console.ReadLine());

            graph = new char[rows, cols];
            visited = new bool[rows, cols];
            areas = new SortedDictionary<char, int>();

            for (int i = 0; i < graph.GetLength(0); i++)
            {
                var elements = Console.ReadLine();

                for (int j = 0; j < graph.GetLength(1); j++)
                {
                    graph[i, j] = elements[j];
                }
            }

            var areasCount = 0;
            
            for (int i = 0; i < graph.GetLength(0); i++)
            {
                for (int j = 0; j < graph.GetLength(1); j++)
                {
                    if (visited[i, j])
                    {
                        continue;
                    }

                    DFS(i, j, graph[i, j]);
                    areasCount++;

                    if (areas.ContainsKey(graph[i, j]))
                    {
                        areas[graph[i, j]] += 1;
                    }
                    else
                    {
                        areas[graph[i, j]] = 1;
                    }
                }
            }

            Console.WriteLine($"Areas: {areasCount}");

            foreach (var area in areas)
            {
                Console.WriteLine($"Letter '{area.Key}' -> {area.Value}");
            }
        }

        private static void DFS(int row, int col, char symbol)
        {
            if (row < 0 || row >= graph.GetLength(0) ||
                col < 0 || col >= graph.GetLength(1))
            {
                return;
            }

            if (visited[row, col])
            {
                return;
            }

            if (graph[row, col] != symbol)
            {
                return;
            }

            visited[row, col] = true;

            DFS(row + 1, col, symbol);
            DFS(row - 1, col, symbol);
            DFS(row, col + 1, symbol);
            DFS(row, col - 1, symbol);

        }
    }
}