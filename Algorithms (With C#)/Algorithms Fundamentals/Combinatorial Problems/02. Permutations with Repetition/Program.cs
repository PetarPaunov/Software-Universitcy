namespace _02._Permutations_with_Repetition
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal class Program
    {
        private static string[] input;

        static void Main(string[] args)
        {
            input = Console.ReadLine().Split().ToArray();

            Permute(0);
        }

        private static void Permute(int index)
        {
            if (index >= input.Length)
            {
                Console.WriteLine(string.Join(" ", input));
                return;
            }

            Permute(index + 1);
            var used = new HashSet<string> { input[index] };

            for (int i = index + 1; i < input.Length; i++)
            {
                if (!used.Contains(input[i]))
                {
                    Swap(index, i);
                    Permute(index + 1);
                    Swap(index, i);

                    used.Add(input[i]);
                }

            }
        }

        private static void Swap(int first, int second)
        {
            var temp = input[first];
            input[first] = input[second];
            input[second] = temp;
        }
    }
}