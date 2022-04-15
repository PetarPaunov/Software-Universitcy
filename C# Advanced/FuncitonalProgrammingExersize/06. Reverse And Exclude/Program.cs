using System;
using System.Collections.Generic;
using System.Linq;

namespace _06._Reverse_And_Exclude
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> inputNumbers = Console.ReadLine().Split(" ").Select(int.Parse).ToList();
            int devisibleNumber = int.Parse(Console.ReadLine());

            Predicate<int> devisibelNum = number => number % devisibleNumber == 0;

            Func<List<int>, List<int>> finalProduct = numbers =>
            {
                for (int i = 0; i < numbers.Count; i++)
                {
                    if (devisibelNum(numbers[i]))
                    {

                        numbers.Remove(numbers[i]);
                        i--;
                    }
                }

                return numbers;

            };

            finalProduct(inputNumbers);
            inputNumbers.Reverse();
            Console.WriteLine(string.Join(" ", inputNumbers));

        }
    }
}
