namespace _5
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal class Program
    {
        private static List<string[]> girlsList;
        private static List<string[]> boysList;
        static void Main(string[] args)
        {
            var girls = Console.ReadLine().Split(", ");
            var girstCombs = new string[3];
            girlsList = new List<string[]>();

            var boys = Console.ReadLine().Split(", ");
            var boysCombs = new string[2];
            boysList = new List<string[]>();

            GenerateCombinations(0, 0, girls, girstCombs, girlsList);
            GenerateCombinations(0, 0, boys, boysCombs, boysList);

            foreach (var girl in girlsList)
            {
                foreach (var boy in boysList)
                {
                    Console.WriteLine($"{string.Join(", ", girl)}, {string.Join(", ", boy)}");
                }
            }
        }

        private static void GenerateCombinations(int index, int start, string[] elements, string[] combs, List<string[]> com)
        {
            if (index >= combs.Length)
            {
                com.Add(combs.ToArray());
                return;
            }

            for (int i = start; i < elements.Length; i++)
            {
                combs[index] = elements[i];
                GenerateCombinations(index + 1, i + 1, elements, combs, com);
            }
        }
    }
}