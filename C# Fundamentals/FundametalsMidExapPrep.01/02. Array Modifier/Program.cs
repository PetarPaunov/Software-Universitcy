using System;
using System.Linq;

namespace _02._Array_Modifier
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray(); 

            string command = Console.ReadLine();

            while (command != "end")
            {
                string[] commandArgs = command.Split(" ");

                string action = commandArgs[0];

                if (action == "swap")
                {
                    int firstIndex = int.Parse(commandArgs[1]);

                    int secondIndex = int.Parse(commandArgs[2]);

                    int temp = input[firstIndex];

                    input[firstIndex] = input[secondIndex];

                    input[secondIndex] = temp;
                }
                else if (action == "multiply")
                {
                    int firstIndex = int.Parse(commandArgs[1]);

                    int secondIndex = int.Parse(commandArgs[2]);

                    int num1 = input[firstIndex];
                    int num2 = input[secondIndex];
                    int sum = num1 * num2;

                    input[firstIndex] = sum;
                }
                else if (action == "decrease")
                {
                    for (int i = 0; i < input.Length; i++)
                    {
                        input[i] -= 1;
                    }
                }      
                command = Console.ReadLine();
            }
            Console.WriteLine(string.Join(", ", input));
        }
    }
}
