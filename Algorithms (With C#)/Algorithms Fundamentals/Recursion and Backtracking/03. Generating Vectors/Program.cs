namespace _03._Generating_Vectors
{
    using System;
    using System.Linq;

    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            var arr = new int[n];

            GeneratingVectors(arr, 0);
        }

        private static void GeneratingVectors(int[] arr, int index)
        {
            if (index >= arr.Length)
            {
                Console.WriteLine(string.Join(string.Empty, arr));
                return;
            }

            for (int i = 0; i < 2; i++)
            {
                arr[index] = i;
                GeneratingVectors(arr, index + 1);
            }
        }
    }
}