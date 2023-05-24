namespace _06._8_Queens_Puzzle
{
    using System;
    using System.Collections.Generic;

    internal class Program
    {
        static HashSet<int> attackedRows = new HashSet<int>();
        static HashSet<int> attackedColums = new HashSet<int>();
        static HashSet<int> attackedLeftDiagonal = new HashSet<int>();
        static HashSet<int> attackedRightDiagonal = new HashSet<int>();

        static void Main(string[] args)
        {
            const int ChessBoardSize = 8;

            var board = new bool[ChessBoardSize, ChessBoardSize];

            PlaceQueens(board, 0);
        }

        private static void PlaceQueens(bool[,] board, int row)
        {
            if (row >= board.GetLength(0))
            {
                PrintBoard(board);
                return;
            }

            for (int col = 0; col < board.GetLength(1); col++)
            {
                if (CanPlaceQueen(row, col))
                {
                    attackedRows.Add(row);
                    attackedColums.Add(col);
                    attackedLeftDiagonal.Add(row - col);
                    attackedRightDiagonal.Add(row + col);

                    board[row, col] = true;

                    PlaceQueens(board, row + 1);

                    attackedRows.Remove(row);
                    attackedColums.Remove(col);
                    attackedLeftDiagonal.Remove(row - col);
                    attackedRightDiagonal.Remove(row + col);

                    board[row, col] = false;
                }
            }
        }

        private static void PrintBoard(bool[,] board)
        {
            for (int row = 0; row < board.GetLength(0); row++)
            {
                for (int col = 0; col < board.GetLength(1); col++)
                {
                    Console.Write(board[row, col] == true ? "* " : "- ");
                }

                Console.WriteLine();
            }

            Console.WriteLine();
        }

        private static bool CanPlaceQueen(int row, int col)
         => !attackedRows.Contains(row) && !attackedColums.Contains(col) &&
            !attackedLeftDiagonal.Contains(row - col) && !attackedRightDiagonal.Contains(row + col);
    }
}