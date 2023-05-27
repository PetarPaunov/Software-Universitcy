namespace _03._Variations_without_Repetition
{
    using System;
    using System.Linq;

    internal class Program
    {
        private static string[] input;
        private static string[] variations;
        private static bool[] used;
        private static int n;

        static void Main(string[] args)
        {
            input = Console.ReadLine().Split().ToArray();
            n = int.Parse(Console.ReadLine());

            used = new bool[input.Length];
            variations = new string[n];

            Variations(0);
        }

        private static void Variations(int index)
        {
            if (index >= variations.Length)
            {
                Console.WriteLine(string.Join(" ", variations));
                return;
            }

            for (int i = 0; i < input.Length; i++)
            {
                if (!used[i])
                {
                    used[i] = true;
                    variations[index] = input[i];
                    Variations(index + 1);

                    used[i] = false;
                }
            }
        }
    }
}