namespace _01._TBC
{
    using System;

    internal class Program
    {
        private static int[,] matrix;
        private const char VisitedSymbol = 'v';
        private const char DirtSymbol = 'd';

        static void Main(string[] args)
        {
            var rows = int.Parse(Console.ReadLine());
            var cols = int.Parse(Console.ReadLine());

            matrix = new int[rows, cols];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                var line = Console.ReadLine();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = line[col];
                }
            }

            var tunnels = 0;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] == VisitedSymbol ||
                        matrix[row, col] == DirtSymbol)
                    {
                        continue;
                    }

                    ExploreTunnels(row, col);

                    tunnels++;
                }
            }

            Console.WriteLine(tunnels);
        }

        private static void ExploreTunnels(int row, int col)
        {
            if (IsOutSideOfTheMatrix(row, col) || 
                matrix[row, col] == VisitedSymbol || 
                matrix[row, col] == DirtSymbol)
            {
                return;
            }

            matrix[row, col] = VisitedSymbol;

            ExploreTunnels(row + 1, col);
            ExploreTunnels(row - 1, col);
            ExploreTunnels(row, col + 1);
            ExploreTunnels(row, col - 1);

            ExploreTunnels(row - 1, col - 1);
            ExploreTunnels(row + 1, col - 1);
            ExploreTunnels(row -1 , col + 1);
            ExploreTunnels(row + 1, col + 1);
        }

        private static bool IsOutSideOfTheMatrix(int row, int col)
            => row < 0 || row >= matrix.GetLength(0) ||
               col < 0 || col >= matrix.GetLength(1);
    }
}