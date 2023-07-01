namespace Problem_1._0
{
    using System;
    using System.Collections.Generic;

    internal class Program
    {
        private static Dictionary<string, ulong> cache;
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var k = int.Parse(Console.ReadLine());

            cache = new Dictionary<string, ulong>();

            Console.WriteLine(GetBinom(n, k));
        }

        private static ulong GetBinom(int row, int col)
        {
            if (col == 0 || col == row)
            {
                return 1;
            }

            var key = $"{row}-{col}";

            if (cache.ContainsKey(key))
            {
                return cache[key];
            }

            var result = GetBinom(row - 1, col - 1) + GetBinom(row - 1, col);

            cache[key] = result;

            return result;

        }
    }
}