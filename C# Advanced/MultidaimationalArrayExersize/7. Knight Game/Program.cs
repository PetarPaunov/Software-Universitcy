using System;

namespace _7._Knight_Game
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

            int removedKnights = 0;

            while (true)
            {
                int maxAttaks = 0;
                int knightRow = 0;
                int knithCol = 0;

                for (int row = 0; row < board.GetLength(0); row++)
                {
                    for (int col = 0; col < board.GetLength(1); col++)
                    {
                        int currentAttacks = 0;

                        if (board[row, col] != 'K')
                        {
                            continue;
                        }
                        if (IsIncide(board, row - 2, col + 1) && board[row - 2, col + 1] == 'K')
                        {
                            currentAttacks++;
                        }

                        if (IsIncide(board, row - 1, col + 2) && board[row - 1, col + 2] == 'K')
                        {
                            currentAttacks++;
                        }

                        if (IsIncide(board, row + 1, col + 2) && board[row + 1, col + 2] == 'K')
                        {
                            currentAttacks++;
                        }

                        if (IsIncide(board, row + 2, col + 1) && board[row + 2, col + 1] == 'K')
                        {
                            currentAttacks++;
                        }

                        if (IsIncide(board, row + 2, col - 1) && board[row + 2, col - 1] == 'K')
                        {
                            currentAttacks++;
                        }

                        if (IsIncide(board, row + 1, col - 2) && board[row + 1, col - 2] == 'K')
                        {
                            currentAttacks++;
                        }

                        if (IsIncide(board, row - 1, col - 2) && board[row - 1, col - 2] == 'K')
                        {
                            currentAttacks++;
                        }

                        if (IsIncide(board, row - 2, col - 1) && board[row - 2, col - 1] == 'K')
                        {
                            currentAttacks++;
                        }

                        if (currentAttacks > maxAttaks)
                        {
                            maxAttaks = currentAttacks;
                            knightRow = row;
                            knithCol = col;
                        }
                    }
                }
                if (maxAttaks == 0)
                {
                    Console.WriteLine(removedKnights);
                    break;
                }
                else
                {
                    board[knightRow, knithCol] = '0';
                    removedKnights++;
                }
            }
        }

        private static bool IsIncide(char[,] board, int row, int col)
        {
            return row >= 0 && row < board.GetLength(0) &&
                col >= 0 && col < board.GetLength(1);
        }
    }
}
