namespace _2
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal class Program
    {
        static void Main(string[] args)
        {
            var rows = int.Parse(Console.ReadLine());
            var cols = int.Parse(Console.ReadLine());

            var matrix = new int[rows, cols];

            for (int i = 0; i < rows; i++)
            {
                var input = Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();

                for (int j = 0; j < cols; j++)
                {
                    matrix[i, j] = input[j];
                }
            }

            var secondMatrix = new int[rows, cols];
            secondMatrix[0, 0] = matrix[0, 0];

            for (int col = 1; col < cols; col++)
            {
                secondMatrix[0, col] = secondMatrix[0, col - 1] + matrix[0, col];
            }

            for (int row = 1; row < rows; row++)
            {
                secondMatrix[row, 0] = secondMatrix[row - 1, 0] + matrix[row, 0];
            }

            for (int row = 1; row < rows; row++)
            {
                for (int col = 1; col < cols; col++)
                {
                    var up = secondMatrix[row - 1, col];
                    var left = secondMatrix[row, col - 1];

                    var bigger = Math.Max(up, left);

                    secondMatrix[row, col] = bigger + matrix[row, col];
                }
            }

            var path = new Stack<string>();

            var row1 = rows - 1;
            var col1 = cols - 1;

            while (row1 > 0 && col1 > 0)
            {
                path.Push($"[{row1}, {col1}]");

                var upper = secondMatrix[row1 - 1, col1];
                var left = secondMatrix[row1, col1 - 1];

                if (upper > left)
                {
                    row1--;
                }
                else
                {
                    col1--;
                }
            }

            while (row1 > 0)
            {
                path.Push($"[{row1}, {col1}]");
                row1--;
            }

            while (col1 > 0)
            {
                path.Push($"[{row1}, {col1}]");
                col1--;
            }

            path.Push($"[{row1}, {col1}]");
            Console.WriteLine(string.Join(" ", path));
        }
    }
}