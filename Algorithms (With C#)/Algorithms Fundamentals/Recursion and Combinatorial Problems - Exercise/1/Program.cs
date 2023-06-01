namespace _1
{
    using System;
    using System.Linq;

    internal class Program
    {
        private static int[] inputArr;
        static void Main(string[] args)
        {
            inputArr = Console.ReadLine().Split().Select(int.Parse).ToArray();
            ReversArray(0);
        }

        private static void ReversArray(int index)
        {
            if (index >= inputArr.Length - 1 - index)
            {
                Console.WriteLine(String.Join(" ", inputArr));
                return;
            }

            var temp = inputArr[index];
            inputArr[index] = inputArr[inputArr.Length - 1 - index];
            inputArr[inputArr.Length - 1 - index] = temp;

            ReversArray(index + 1);
        }
    }
}