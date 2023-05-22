namespace _02._Recursive_Drawing
{
    using System;

    internal class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());

            RecursiveDrawing(n);
        }

        private static void RecursiveDrawing(int n)
        {
            if (n <= 0)
            {
                return;
            }

            Console.WriteLine(new string('*', n));

            RecursiveDrawing(n - 1);

            Console.WriteLine(new string('#', n));
        }
    }
}