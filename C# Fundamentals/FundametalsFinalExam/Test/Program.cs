using System;

namespace Test
{
    class Program
    {
        public static object Print { get; private set; }

        static void Main(string[] args)
        {
            int a = 10;
            int b = 20;
            int c = a > b ? a : b;
            Console.WriteLine(c);
        }
    }
}
