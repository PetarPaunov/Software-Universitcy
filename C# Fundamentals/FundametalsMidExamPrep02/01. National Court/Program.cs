using System;

namespace _01._National_Court
{
    class Program
    {
        static void Main(string[] args)
        {
            double studensCount = double.Parse(Console.ReadLine());
            double lectursCount = double.Parse(Console.ReadLine());
            double initialBonus = double.Parse(Console.ReadLine());

            double maxStudentBonus = 0;
            double bestStudentAtendens = 0;

            for (int i = 0; i < studensCount; i++)
            {
                double studentAtendens = int.Parse(Console.ReadLine());

                double totalBonus = studentAtendens / lectursCount * (5 + initialBonus);

                if (totalBonus > maxStudentBonus)
                {
                    maxStudentBonus = totalBonus;
                    bestStudentAtendens = studentAtendens;
                }
            }

            maxStudentBonus = Math.Ceiling(maxStudentBonus);

            Console.WriteLine($"Max Bonus: {maxStudentBonus}.");
            Console.WriteLine($"The student has attended {bestStudentAtendens} lectures.");
        }
    }
}
