namespace _05._Paths_in_Labyrinth
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal class Program
    {
        static void Main(string[] args)
        {
            var labirint = InitializeLabirint();
            FindAllPaths(labirint, 0, 0, new List<string>(), "");
        }

        private static void FindAllPaths
            (char[,] labirint, int row, int col, List<string> directions , string direction)
        {
            if (ValidateColAndRow(labirint, row, col))
            {
                return;
            }

            if (labirint[row, col] == 'v' ||
                labirint[row, col] == '*')
            {
                return;
            }

            directions.Add(direction);

            if (labirint[row, col] == 'e')
            {
                Console.WriteLine(string.Join("", directions));
                directions.RemoveAt(directions.Count() - 1);
                return;
            }

            labirint[row, col] = 'v';

            FindAllPaths(labirint, row - 1, col, directions, "U"); // UP
            FindAllPaths(labirint, row + 1, col, directions, "D"); // DOWN
            FindAllPaths(labirint, row, col - 1, directions, "L"); // LEFT
            FindAllPaths(labirint, row, col + 1, directions, "R"); // RIGHT

            labirint[row, col] = '-';
            directions.RemoveAt(directions.Count() - 1);
        }

        private static bool ValidateColAndRow(char[,] labirint, int row, int col)
            => row < 0 || row >= labirint.GetLength(0) ||
               col < 0 || col >= labirint.GetLength(1);

        private static char[,] InitializeLabirint()
        {
            var rows = int.Parse(Console.ReadLine());
            var cols = int.Parse(Console.ReadLine());

            var labirint = new char[rows, cols];

            for (int i = 0; i < labirint.GetLength(0); i++)
            {
                var input = Console.ReadLine();

                for (int j = 0; j < labirint.GetLength(1); j++)
                {
                    labirint[i, j] = input[j];
                }
            }

            return labirint;
        }
    }
}