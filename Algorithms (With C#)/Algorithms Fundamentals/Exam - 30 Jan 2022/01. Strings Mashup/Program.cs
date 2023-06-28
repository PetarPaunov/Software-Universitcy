namespace _01._Strings_Mashup
{
    using System;

    internal class Program
    {
        private static char[] combinations;
        private static char[] str;

        static void Main(string[] args)
        {
            str = Console.ReadLine().ToCharArray();
            var n = int.Parse(Console.ReadLine());

            Array.Sort(str);

            combinations = new char[n];

            GenerateCombinations(0, 0);
        }

        private static void GenerateCombinations(int index, int startIndex)
        {
            if (index >= combinations.Length)
            {
                Console.WriteLine(String.Join("", combinations));
                return;
            }

            for (int i = startIndex; i < str.Length; i++)
            {
                combinations[index] = str[i];
                GenerateCombinations(index + 1, i);
            }
        }
    }
}