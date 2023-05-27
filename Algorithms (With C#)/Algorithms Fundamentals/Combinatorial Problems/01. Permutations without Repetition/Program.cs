namespace _01._Permutations_without_Repetition
{
    using System;
    using System.Linq;

    internal class Program
    {
        private static string[] result;
        private static bool[] used;
        private static string[] input;

        static void Main(string[] args)
        {
            input = Console.ReadLine().Split().ToArray();

            result = new string[input.Length];
            used = new bool[input.Length];

            Permute(0);
        }

        private static void Permute(int index)
        {
            if (index >= result.Length)
            {
                Console.WriteLine(string.Join(" ", result));
                return;
            }

            for (int i = 0; i < result.Length; i++)
            {
                if (!used[i])
                {
                    result[index] = input[i];
                    used[i] = true;

                    Permute(index + 1);

                    used[i] = false;
                }
            }
        }
    }
}