using System;
using System.Collections.Generic;
using System.Linq;

namespace _07._Student_Academy
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Dictionary<string, List<double>> studentsGrades = new Dictionary<string, List<double>>();
            for (int i = 0; i < n; i++)
            {
                string studentName = Console.ReadLine();
                double studentGrade = double.Parse(Console.ReadLine());

                if (!studentsGrades.ContainsKey(studentName))
                {
                    studentsGrades.Add(studentName, new List<double>());
                    studentsGrades[studentName].Add(studentGrade);
                }
                else
                {
                    studentsGrades[studentName].Add(studentGrade);
                }
                

            }
            studentsGrades = studentsGrades.Where(x => x.Value.Average() >= 4.5).ToDictionary(x => x.Key, x => x.Value);
            foreach (var student in studentsGrades.OrderByDescending(x => x.Value.Average()))
            {
                Console.WriteLine($"{student.Key} -> {student.Value.Average():f2}");
            }
        }
    }
}
