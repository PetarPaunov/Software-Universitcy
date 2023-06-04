namespace Selection_Sort
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

            SelectionSort(numbers);

            Console.WriteLine(String.Join((' '), numbers));
        }

        private static void SelectionSort(int[] numbers)
        {
            for (int i = 0; i < numbers.Length; i++)
            {
                var min = i;
                
                for (int j = i + 1; j < numbers.Length; j++)
                {
                    if (numbers[min] > numbers[j])
                    {
                        min = j;
                    }
                }

                Swap(numbers, min, i);
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