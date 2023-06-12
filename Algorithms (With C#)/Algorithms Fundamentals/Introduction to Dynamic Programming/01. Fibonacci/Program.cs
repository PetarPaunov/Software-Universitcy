namespace _01._Fibonacci
{
    using System;
    using System.Collections.Generic;

    internal class Program
    {
        private static Dictionary<int, long> fibPairs = new Dictionary<int, long>();

        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());

            Console.WriteLine(Fibubacci(n));
        }

        private static long Fibubacci(int n)
        {
            if (fibPairs.ContainsKey(n))
            {
                return fibPairs[n];
            }

            if (n < 2)
            {
                return n;
            }

            var result = Fibubacci(n - 1) + Fibubacci(n - 2);
            fibPairs[n] = result;

            return result;
        }
    }
}