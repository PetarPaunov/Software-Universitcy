namespace _3
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal class Program
    {
        private static char[,] matrix;
        private static List<Area> areas;
        private static int sizeCount;

        class Area
        {
            public int Row { get; set; }
            public int Col { get; set; }
            public int Size { get; set; }
        }

        static void Main(string[] args)
        {
            var rows = int.Parse(Console.ReadLine());
            var cols = int.Parse(Console.ReadLine());

            areas = new List<Area>();

            matrix = new char[rows, cols];

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                var line = Console.ReadLine();

                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = line[j];
                }
            }

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (IsBorderOrVisited(i, j))
                    {
                        continue;
                    }

                    sizeCount = 0;
                    FindArea(i , j);

                    areas.Add(new Area()
                    {
                        Row = i,
                        Col = j,
                        Size = sizeCount
                    });
                }
            }

            PrintResult();
        }

        private static void PrintResult()
        {
            areas = areas
                .OrderByDescending(x => x.Size)
                .ThenBy(x => x.Row)
                .ThenBy(x => x.Col)
                .ToList();

            Console.WriteLine($"Total areas found: {areas.Count}");

            for (int i = 0; i < areas.Count; i++)
            {
                Console.WriteLine($"Area #{i + 1} at ({areas[i].Row}, {areas[i].Col}), size: {areas[i].Size}");
            }
        }

        private static void FindArea(int row, int col)
        {
            if (IsOutOfArrayBorders(row, col) || IsBorderOrVisited(row, col))
            {
                return;
            }

            matrix[row, col] = 'V';
            sizeCount++;

            FindArea(row + 1, col); // UP
            FindArea(row - 1, col); // DOWN
            FindArea(row, col - 1); // LEFT
            FindArea(row, col + 1); // RIGHT
        }

        private static bool IsOutOfArrayBorders(int row, int col)
            => row < 0 || row >= matrix.GetLength(0) ||
               col < 0 || col >= matrix.GetLength(1);

        private static bool IsBorderOrVisited(int row, int col)
            => matrix[row, col] == '*' || matrix[row, col] == 'V';
    }
}