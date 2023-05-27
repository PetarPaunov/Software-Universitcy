namespace _05._Combinations_without_Repetition
{
    using System;
    using System.Linq;

    internal class Program
    {
        private static string[] input;
        private static int n;
        private static string[] combinations;

        static void Main(string[] args)
        {
            input = Console.ReadLine().Split().ToArray();
            n = int.Parse(Console.ReadLine());

            combinations = new string[n];

            GenerateCombinations(0, 0);
        }

        private static void GenerateCombinations(int index, int startIndex)
        {
            if (index >= combinations.Length)
            {
                Console.WriteLine(String.Join(" ", combinations));
                return;
            }

            for (int i = startIndex; i < input.Length; i++)
            {
                combinations[index] = input[i];
                GenerateCombinations(index + 1, i + 1);
            }
        }
    }
}