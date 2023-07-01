namespace Problem_3._0
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal class Program
    {
        private static int[,] dp;

        static void Main(string[] args)
        {
            var firstLine = Console.ReadLine()
               .Split()
               .ToArray();

            var secondLine = Console.ReadLine()
                .Split()
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

            var i = firstLine.Length;
            var j = secondLine.Length;

            var result = new Stack<string>();

            while (i > 0 && j > 0)
            {
                if (firstLine[i - 1] == secondLine[j - 1])
                {
                    result.Push(firstLine[i - 1]);

                    i--;
                    j--;
                }
                else
                {
                    if (dp[i, j - 1] > dp[i - 1, j])
                    {
                        j--;
                    }
                    else
                    {
                        i--;
                    }
                }
            }

            Console.WriteLine($"[{string.Join(' ', result)}]");
        }
    }
}