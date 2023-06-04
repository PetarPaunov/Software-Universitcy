namespace Bubble_Sort
{
    using System;
    using System.Linq;

    internal class Program
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();

            BubbleSort(numbers);

            Console.WriteLine(string.Join(' ', numbers));
        }

        private static void BubbleSort(int[] numbers)
        {
            var sortCount = 0;
            var isSorted = false;

            while (!isSorted)
            {
                isSorted = true;

                for (int i = 1; i < numbers.Length - sortCount; i++)
                {
                    var j = i - 1;

                    if (numbers[j] > numbers[i])
                    {
                        Swap(numbers, i, j);
                        isSorted = false;
                    }
                }

                sortCount++;
            }
        }

        private static void Swap(int[] numbers, int first, int second)
        {
            var temp = numbers[first];
            numbers[first] = numbers[second];
            numbers[second] = temp;
        }
    }
}