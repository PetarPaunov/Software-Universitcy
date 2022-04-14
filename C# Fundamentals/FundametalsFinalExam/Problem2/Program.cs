using System;
using System.Text.RegularExpressions;
namespace Problem2
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"^([$%])(?<tag>[A-Z][a-z]{2,})\1:\s{1}\[(?<firstGroop>[0-9]{1,})\]\|\[(?<secondGroop>[0-9]{1,})\]\|\[(?<thirdGroop>[0-9]{1,})\]\|$";

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string messige = Console.ReadLine();
                Match match = Regex.Match(messige, pattern);

                if (!match.Success)
                {
                    Console.WriteLine("Valid message not found!");
                }
                else
                {
                    int fisrtGroop = int.Parse(match.Groups["firstGroop"].Value);
                    int secondGroop = int.Parse(match.Groups["secondGroop"].Value);
                    int thirdGroop = int.Parse(match.Groups["thirdGroop"].Value);
                    Console.WriteLine($"{match.Groups["tag"].Value}: {(char)fisrtGroop}{(char)secondGroop}{(char)thirdGroop}");
                }
            }

        }
    }
}
