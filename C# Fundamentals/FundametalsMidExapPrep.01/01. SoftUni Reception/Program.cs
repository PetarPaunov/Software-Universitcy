using System;

namespace _01._SoftUni_Reception
{
    class Program
    {
        static void Main(string[] args)
        {
            int firstEmployeeEficiansi = int.Parse(Console.ReadLine());

            int secondEmployeeEficiansi = int.Parse(Console.ReadLine());

            int thirdEmployeeEficiansi = int.Parse(Console.ReadLine());

            int studentsCount = int.Parse(Console.ReadLine());

            int timeCount = 0;

            int employeeTotal = firstEmployeeEficiansi + secondEmployeeEficiansi + thirdEmployeeEficiansi;


            while (studentsCount > 0)
            {
                timeCount++;

                studentsCount -= employeeTotal;

                if (timeCount % 4 == 0)
                {
                    timeCount++;

                }

            }
            Console.WriteLine($"Time needed: {timeCount}h.");
        }
    }
}
