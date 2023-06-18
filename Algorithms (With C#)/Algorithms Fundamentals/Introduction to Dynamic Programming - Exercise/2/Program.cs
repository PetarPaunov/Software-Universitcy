namespace _2
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal class Program
    {
        static void Main(string[] args)
        {
            var presents = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            var allSums = GetAllSums(presents);

            var totlaSum = presents.Sum();
            var half = totlaSum / 2;

            while (true)
            {
                if (allSums.ContainsKey(half))
                {
                    var alanSum = half;
                    var bobSum = totlaSum - alanSum;

                    var alanPresents = GetPresents(allSums,alanSum);

                    Console.WriteLine($"Difference: {bobSum - alanSum}");
                    Console.WriteLine($"Alan:{alanSum} Bob:{bobSum}");
                    Console.WriteLine($"Alan takes: {string.Join(' ', alanPresents)}");
                    Console.WriteLine($"Bob takes the rest.");
                    break;
                }

                half--;
            }
        }

        private static List<int> GetPresents(Dictionary<int, int> allSums, int target)
        {
            var subSet = new List<int>();

            while (target > 0)
            {
                var current = allSums[target];
                target -= current;
                subSet.Add(current);
            }

            return subSet;
        }

        private static Dictionary<int, int> GetAllSums(int[] presents)
        {
            var sums = new Dictionary<int, int>() { { 0, 0} };

            foreach (var present in presents)
            {
                var currentSums = sums.Keys.ToArray();

                foreach (var sum in currentSums)
                {
                    var newSum = sum + present;

                    if (sums.ContainsKey(newSum))
                    {
                        continue;
                    }

                    sums[newSum] = present;
                }
            }

            return sums;
        }
    }
}