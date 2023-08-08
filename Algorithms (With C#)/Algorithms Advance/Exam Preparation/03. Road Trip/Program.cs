namespace _03._Road_Trip
{
    using System;
    using System.Linq;

    internal class Program
    {
        static void Main(string[] args)
        {
            var itemValues = Console.ReadLine()
                .Split(", ")
                .Select(int.Parse)
                .ToArray();

            var itemSpace = Console.ReadLine()
                .Split(", ")
                .Select(int.Parse)
                .ToArray();

            var maxCapacity = int.Parse(Console.ReadLine());

            var dp = new int[itemValues.Length + 1, maxCapacity + 1];

            for (int row = 1; row < dp.GetLength(0); row++)
            {
                for (int capacity = 1; capacity < dp.GetLength(1); capacity++)
                {
                    var excluding = dp[row - 1, capacity];

                    if (itemSpace[row - 1] > capacity)
                    {
                        dp[row, capacity] = excluding;
                        continue;
                    }

                    var including = itemValues[row - 1] + dp[row - 1, capacity - itemSpace[row - 1]];

                    if (including > excluding)
                    {
                        dp[row, capacity] = including;
                    }
                    else
                    {
                        dp[row, capacity] = excluding;
                    }
                }
            }

            Console.WriteLine($"Maximum value: {dp[itemValues.Length, maxCapacity]}");
        }
    }
}