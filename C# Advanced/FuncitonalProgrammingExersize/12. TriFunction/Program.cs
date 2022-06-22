using System;
using System.Linq;

namespace _12._TriFunction
{
    class Program
    {
        static void Main(string[] args)
        {
            int magicNumber = int.Parse(Console.ReadLine());

            string[] names = Console.ReadLine().Split().ToArray();

            Func<string, int, bool> isEqualToMagigNum = (name, sum)
                => name.Sum(x => x) >= sum;

            Func<string[], int, Func<string, int, bool>, string> finalResult
                = (allNames, number, func)
                => allNames.FirstOrDefault(x => func(x, number));

            string magicName = finalResult(names, magicNumber, isEqualToMagigNum);

            Console.WriteLine(magicName);
        }
    }
}
