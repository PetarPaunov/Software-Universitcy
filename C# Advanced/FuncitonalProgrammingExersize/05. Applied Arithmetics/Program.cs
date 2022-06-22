using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._Applied_Arithmetics
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] inputNumbers = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();

            Func<int[], int[]> add = numbers =>
            {
                for (int i = 0; i < numbers.Length; i++)
                {
                    numbers[i] += 1;
                }

                return numbers;

            };
            Func<int[], int[]> multiplay = multiplayNumber =>
            {
                for (int i = 0; i < multiplayNumber.Length; i++)
                {
                    multiplayNumber[i] *= 2;
                }

                return multiplayNumber;

            };
            Func<int[], int[]> subtract = subtractNumber =>
            {
                for (int i = 0; i < subtractNumber.Length; i++)
                {
                    subtractNumber[i] -= 1;
                }
                return subtractNumber;

            };
            Action<int[]> print = printNumbers => Console.WriteLine(string.Join(" ", printNumbers));

            string command = Console.ReadLine();

            while (command != "end")
            {
                if (command == "add")
                {
                    add(inputNumbers);
                }
                else if (command == "multiply")
                {
                    multiplay(inputNumbers);
                }
                else if (command == "subtract")
                {
                    subtract(inputNumbers);
                }
                else if (command == "print")
                {
                    print(inputNumbers);
                }
                

                command = Console.ReadLine();
            }
        }
    }
}
