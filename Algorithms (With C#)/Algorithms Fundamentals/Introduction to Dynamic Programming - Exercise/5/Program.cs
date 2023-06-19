namespace _5
{
    using System;

    internal class Program
    {
        private static int[,] dp;
        static void Main(string[] args)
        {
            var firstString = Console.ReadLine();
            var secondString = Console.ReadLine();

            dp = new int[firstString.Length + 1, secondString.Length + 1];

            for (int row = 1; row < dp.GetLength(0); row++)
            {
                dp[row, 0] = row;
            }

            for (int col = 1; col < dp.GetLength(1); col++)
            {
                dp[0, col] = col;
            }

            for (int row = 1; row < dp.GetLength(0); row++)
            {
                for (int col = 1; col < dp.GetLength(1); col++)
                {
                    if (firstString[row - 1] == secondString[col - 1])
                    {
                        dp[row, col] = dp[row - 1, col - 1];
                    }
                    else
                    {
                        var minimumOperations = Math.Min(dp[row - 1, col], dp[row, col - 1]) + 1;

                        dp[row, col] = minimumOperations;
                    }
                }
            }

            Console.WriteLine($"Deletions and Insertions: {dp[firstString.Length, secondString.Length]}");
        }
    }
}