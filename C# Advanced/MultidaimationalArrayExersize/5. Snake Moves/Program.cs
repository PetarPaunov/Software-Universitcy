using System;
using System.Linq;

namespace _5._Snake_Moves
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();
            int rows = input[0];
            int cols = input[1];

            char[,] zigZagSnake = new char[rows, cols];

            string snake = Console.ReadLine();

            bool isLeftToRigh = true;

            int couter = 0;
            for (int row = 0; row < zigZagSnake.GetLength(0); row++)
            {
                if (isLeftToRigh)
                {
                    for (int col = 0; col < zigZagSnake.GetLength(1); col++)
                    {
                        zigZagSnake[row, col] = snake[couter++];

                        if (couter == snake.Length)
                        {
                            couter = 0;
                        }
                    }
                    isLeftToRigh = false;
                }
                else
                {
                    for (int col = zigZagSnake.GetLength(1) - 1; col >= 0; col--)
                    {
                        zigZagSnake[row, col] = snake[couter++];

                        if (couter == snake.Length)
                        {
                            couter = 0;
                        }
                    }
                    isLeftToRigh = true;
                }
                
            }

            for (int row = 0; row < zigZagSnake.GetLength(0); row++)
            {
                for (int col = 0; col < zigZagSnake.GetLength(1); col++)
                {
                    Console.Write(zigZagSnake[row, col]);
                }
                Console.WriteLine();
            }
        }
    }
}
