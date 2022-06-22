using System;
using System.Linq;

namespace _4._Matrix_Shuffling
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] matrixInfo = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();
            int rows = matrixInfo[0];
            int cols = matrixInfo[1];

            string[,] matrix = new string[rows, cols];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                string[] input = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = input[col];
                }
            }

            while (true)
            {
                string[] command = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string action = command[0];

                if (action == "END")
                {
                    break;
                } 
                if (action == "swap")
                {
                    if (command.Length == 5)
                    {
                        int row1 = int.Parse(command[1]);
                        int col1 = int.Parse(command[2]);
                        int row2 = int.Parse(command[3]);
                        int col2 = int.Parse(command[4]);
                        if (row1 < 0 || row1 >= matrix.GetLength(0)
                        || row2 < 0 || row2 >= matrix.GetLength(0)
                        || col1 < 0 || col1 >= matrix.GetLength(1)
                        || col1 < 0 || col1 >= matrix.GetLength(1))
                        {
                            Console.WriteLine("Invalid input!");
                            continue;
                        }
                        else
                        {
                            string undu = matrix[row1, col1];
                            matrix[row1, col1] = matrix[row2, col2];
                            matrix[row2, col2] = undu;
                            for (int row = 0; row < matrix.GetLength(0); row++)
                            {
                                for (int col = 0; col < matrix.GetLength(1); col++)
                                {
                                    Console.Write(matrix[row, col] + " ");
                                }
                                Console.WriteLine();
                            }

                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid input!");
                        continue;
                    }
                }

                

            }



        }
    }
}
