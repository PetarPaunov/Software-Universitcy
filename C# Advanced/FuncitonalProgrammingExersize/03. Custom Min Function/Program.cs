using System;
using System.Linq;

namespace _03._Custom_Min_Function
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<int[], int> minNumber = numbers =>
            {
                int minValue = int.MaxValue;

                foreach (var number in numbers)
                {
                    if (minValue > number)
                    {
                        minValue = number;
                    }
                }
                return minValue;
            };

            int[] input = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();

            Console.WriteLine(minNumber(input));
        }
    }
}
