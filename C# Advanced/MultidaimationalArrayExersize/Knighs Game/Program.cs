using System;

namespace Knighs_Game
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            char[,] board = new char[n, n];

            for (int row = 0; row < board.GetLength(0); row++)
            {
                string boardInput = Console.ReadLine();
                for (int col = 0; col < board.GetLength(1); col++)
                {
                    board[col, row] = boardInput[col];
                }
            }
        }
    }
}
