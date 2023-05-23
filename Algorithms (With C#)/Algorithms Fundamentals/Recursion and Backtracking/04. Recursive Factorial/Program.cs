namespace _04._Recursive_Factorial
{
    using System;

    internal class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());

            Console.WriteLine(GetFactorialRecursivly(n));
        }

        private static int GetFactorialRecursivly(int n)
        {
            if (n == 0)
            {
                return 1;
            }

            return n * GetFactorialRecursivly(n - 1);
        }
    }
}