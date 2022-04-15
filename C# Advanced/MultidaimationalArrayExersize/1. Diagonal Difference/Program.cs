using System;
using System.Linq;

namespace _1._Diagonal_Difference
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int[,] matrix = new int[n, n];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                int[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse).ToArray();
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = input[col];
                }
            }

            int firstDiagonal = 0;
            int secondDiagonal = 0;

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                firstDiagonal += matrix[i, i];

            }

            int couter = matrix.GetLength(1) - 1;

            for (int i = 0; i < matrix.GetLength(1); i++)
            {
                secondDiagonal += matrix[couter, i];
                couter--;
            }


            int sum = Math.Abs(firstDiagonal - secondDiagonal);

            Console.WriteLine(sum);
        }
    }
}
