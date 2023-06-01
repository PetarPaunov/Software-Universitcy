namespace _2
{
    using System;

    internal class Program
    {
        private static int[] elements;
        
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());

            elements = new int[n];

            SimulateNestedLoop(0);
        }

        private static void SimulateNestedLoop(int index)
        {
            if (index >= elements.Length)
            {
                Console.WriteLine(String.Join(' ', elements));
                return;
            }

            for (int i = 0; i < elements.Length; i++)
            {
                elements[index] = i + 1;

                SimulateNestedLoop(index + 1);
            }
        }
    }
}