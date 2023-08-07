namespace _03._Code
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal class Program
    {
        static void Main(string[] args)
        {
            var first = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            var second = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            var lsc = new int[first.Length + 1, second.Length + 1];

            for (int i = 1; i <= first.Length; i++)
            {
                for (int j = 1; j <= second.Length; j++)
                {
                    if (first[i - 1] == second[j - 1])
                    {
                        lsc[i, j] = lsc[i - 1, j - 1] + 1;
                    }
                    else
                    {
                        lsc[i, j] = Math.Max(lsc[i - 1, j], lsc[i, j - 1]);
                    }
                }
            }

            var x = first.Length;
            var y = second.Length;

            var result = new Stack<int>();

            while (x > 0 && y > 0)
            {
                if (first[x - 1] == second[y - 1])
                {
                    result.Push(first[x - 1]);

                    x--;
                    y--;
                }
                else
                {
                    if (lsc[x, y - 1] > lsc[x - 1, y])
                    {
                        y--;
                    }
                    else
                    {
                        x--;
                    }
                }
            }

            Console.WriteLine(string.Join(" ", result));
            Console.WriteLine(result.Count());
        }
    }
}