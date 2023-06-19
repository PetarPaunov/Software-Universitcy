namespace _7
{
    using System;

    internal class Program
    {
        private static int[,] dp;
        static void Main(string[] args)
        {
            var replace = int.Parse(Console.ReadLine());
            var insert = int.Parse(Console.ReadLine());
            var delete = int.Parse(Console.ReadLine());

            var firstString = Console.ReadLine();
            var secondString = Console.ReadLine();

            dp = new int[firstString.Length + 1, secondString.Length + 1];

            for (int row = 1; row < dp.GetLength(0); row++)
            {
                dp[row, 0] = dp[row - 1, 0] + delete;   
            }

            for (int col = 1; col < dp.GetLength(1); col++)
            {
                dp[0, col] = dp[0, col - 1] + insert;
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
                        var replaceCost = dp[row - 1, col - 1] + replace;
                        var deleteCost = dp[row - 1, col] + delete;
                        var insertCost = dp[row, col - 1] + insert;

                        dp[row, col] = Math.Min(Math.Min(replaceCost, deleteCost), insertCost);
                    }
                }
            }

            Console.WriteLine($"Minimum edit distance: {dp[firstString.Length, secondString.Length]}");
        }
    }
}