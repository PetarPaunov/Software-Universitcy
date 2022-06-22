using System;

namespace _02._Knights_of_Honor
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] names = Console.ReadLine().Split(" ");

            Action<string> honoredNames = name => Console.WriteLine($"Sir {name}");

            foreach (var name in names)
            {
                honoredNames(name);
            }
        }
    }
}
