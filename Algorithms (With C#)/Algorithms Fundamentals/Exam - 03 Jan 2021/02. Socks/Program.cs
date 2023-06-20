namespace _02._Socks
{
    using System;
    using System.Linq;

    internal class Program
    {
        private static int[,] dp;
        static void Main(string[] args)
        {
            var firstLine = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            var secondLine = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            dp = new int[firstLine.Length + 1, secondLine.Length + 1];

            for (int row = 1; row < dp.GetLength(0); row++)
            {
                for (int col = 1; col < dp.GetLength(1); col++)
                {
                    if (firstLine[row - 1] == secondLine[col - 1])
                    {
                        dp[row, col] = dp[row - 1, col - 1] + 1;
                    }
                    else
                    {
                        dp[row, col] = Math.Max(dp[row - 1, col], dp[row, col - 1]);
                    }
                }
            }

            Console.WriteLine(dp[firstLine.Length, secondLine.Length]);
        }
    }
}