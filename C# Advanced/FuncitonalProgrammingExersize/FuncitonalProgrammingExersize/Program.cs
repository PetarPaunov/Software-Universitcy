using System;

namespace SoftUniAdancedFuncitonalProgrammingExersize
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(" ");

            Action<string> names = name => Console.WriteLine(name);


            foreach (var name in input)
            {
                names(name);
            }


        }
    }
}
