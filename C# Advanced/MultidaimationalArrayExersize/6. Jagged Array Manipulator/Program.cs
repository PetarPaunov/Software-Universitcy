using System;
using System.Linq;

namespace _6._Jagged_Array_Manipulator
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            double[][] matrix = new double[n][];

            for (int row = 0; row < n; row++)
            {
                double[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(double.Parse).ToArray();

                matrix[row] = input;
            }

            for (int row = 0; row < matrix.Length - 1; row++)
            {
                if (matrix[row].Length == matrix[row + 1].Length)
                {
                    for (int col = 0; col < matrix[row].Length; col++)
                    {
                        matrix[row][col] *= 2;
                        matrix[row + 1][col] *= 2;
                    }
                }
                else
                {
                    for (int col = 0; col < matrix[row].Length; col++)
                    {
                        matrix[row][col] /= 2;
                    }
                    for (int col = 0; col < matrix[row + 1].Length; col++)
                    {
                        matrix[row + 1][col] /= 2;
                    }
                }
            }

            while (true)
            {
                string[] commandInput = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();

                string action = commandInput[0];

                if (action == "End")
                {
                    //TODU : Print Matrix, End The program;
                    foreach (var element in matrix)
                    {
                        Console.Write(string.Join(" ", element));
                        Console.WriteLine();
                        
                    }
                    break;
                }
                if (action == "Add")
                {
                    int rows = int.Parse(commandInput[1]);
                    int cols = int.Parse(commandInput[2]);
                    double value = int.Parse(commandInput[3]);

                    if (rows >= 0 && rows < matrix.Length && 
                        cols >= 0 && cols < matrix[rows].Length)
                    {
                        matrix[rows][cols] += value;
                    }

                }
                else if (action == "Subtract")
                {
                    int rows = int.Parse(commandInput[1]);
                    int cols = int.Parse(commandInput[2]);
                    double value = int.Parse(commandInput[3]);

                    if (rows >= 0 && rows < matrix.Length &&
                        cols >= 0 && cols < matrix[rows].Length)
                    {
                        matrix[rows][cols] -= value;
                    }
                }
            }
        }
    }
}
