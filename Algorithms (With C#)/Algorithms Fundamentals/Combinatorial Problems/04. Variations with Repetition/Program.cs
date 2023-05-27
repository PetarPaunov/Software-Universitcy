namespace _04._Variations_with_Repetition
{
    using System;
    using System.Linq;

    internal class Program
    {
        private static string[] input;
        private static int n;
        private static string[] variations;

        static void Main(string[] args)
        {
            input = Console.ReadLine().Split().ToArray();
            n = int.Parse(Console.ReadLine());

            variations = new string[n];

            Variations(0);
        }

        private static void Variations(int index)
        {
            if (index >= variations.Length)
            {
                Console.WriteLine(String.Join(" ", variations));
                return;
            }

            for (int i = 0; i < input.Length; i++)
            {
                variations[index] = input[i];
                Variations(index + 1);
            }
        }
    }
}