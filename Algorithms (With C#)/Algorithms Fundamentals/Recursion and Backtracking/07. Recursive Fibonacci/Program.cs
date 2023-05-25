namespace _07._Recursive_Fibonacci
{
    using System;

    internal class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());

            var fib = RecursiveFibonacci(n);

            Console.WriteLine(fib);
        }

        private static long RecursiveFibonacci(int n)
        {
            if (n <= 1)
            {
                return 1;
            }

            return RecursiveFibonacci(n - 1) + RecursiveFibonacci(n - 2);
        }
    }
}