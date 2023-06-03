namespace _4
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    internal class Program
    {
        private static string[] peopleResult;
        private static List<string> people;

        static void Main(string[] args)
        {
            people = Console.ReadLine()
                .Split(", ")
                .ToList();

            peopleResult = new string[people.Count];

            while (true)
            {
                var line = Console.ReadLine();

                if (line == "generate")
                {
                    break;
                }

                var info = line.Split(" - ");

                var name = info[0];
                var position = int.Parse(info[1]);

                peopleResult[position - 1] = name;

                people.Remove(name);
            }

            Permute(0);
        }

        private static void Permute(int index)
        {
            if (index >= people.Count)
            {
                Print();
                return;
            }

            Permute(index + 1);

            for (int i = index + 1; i < people.Count; i++)
            {
                Swap(index, i);
                Permute(index + 1);
                Swap(index, i);
            }
        }

        private static void Print()
        {
            var sb = new StringBuilder();

            int count = 0;

            for (int i = 0; i < peopleResult.Length; i++)
            {
                if (peopleResult[i] != null)
                {
                    sb.Append($"{peopleResult[i]} ");
                }
                else
                {
                    sb.Append($"{people[count++]} ");
                }
            }
            sb.AppendLine();

            Console.WriteLine(sb.ToString().TrimEnd());
        }

        private static void Swap(int fisrt, int second)
        {
            var temp = people[fisrt];
            people[fisrt] = people[second];
            people[second] = temp;
        }
    }
}