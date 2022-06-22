using System;

namespace _01._Problem
{
    class Program
    {
        static void Main(string[] args)
        {
            double buget = double.Parse(Console.ReadLine());
            int signetStudents = int.Parse(Console.ReadLine());
            double priceOfFlowerForOne = double.Parse(Console.ReadLine());
            double priceOfEggsForOne = double.Parse(Console.ReadLine());
            double priceOfApronForOne = double.Parse(Console.ReadLine());

            double totalApronPrice = Math.Ceiling(signetStudents * 1.2) * priceOfApronForOne;
            double needetSumForFoods = signetStudents * (priceOfFlowerForOne + (10 * priceOfEggsForOne));
            double freeFwoler = (signetStudents / 5) * priceOfFlowerForOne;

            double finalSum = totalApronPrice + needetSumForFoods - freeFwoler;

            if (finalSum <= buget)
            {
                Console.WriteLine($"Items purchased for {finalSum:F2}$.");
            }
            else if (finalSum > buget)
            {
                finalSum -= buget;
                Console.WriteLine($"{finalSum:F2}$ more needed.");
            }

        }
    }
}
