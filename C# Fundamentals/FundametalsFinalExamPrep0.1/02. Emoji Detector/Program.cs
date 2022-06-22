using System;
using System.Text.RegularExpressions;

namespace _02._Emoji_Detector
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"([:*])\1([A-Z][a-z]{2,})\1{2}";
            string coolTrasholdPattern = @"[0-9]";
            string input = Console.ReadLine();
            long coolTrashold = 1;
            MatchCollection treshold = Regex.Matches(input, coolTrasholdPattern);

            foreach (Match digit in treshold)
            {
                coolTrashold *= int.Parse(digit.Value);
            }
            Console.WriteLine($"Cool threshold: {coolTrashold}");

            MatchCollection emogi = Regex.Matches(input, pattern);
            
            Console.WriteLine($"{emogi.Count} emojis found in the text. The cool ones are:");

            foreach (Match match in emogi)
            {
                long coolness = 0;
                string emoji = match.Groups[2].Value;

                for (int i = 0; i < emoji.Length; i++)
                {
                    coolness += emoji[i];
                }
                if (coolness >= coolTrashold)
                {
                    Console.WriteLine(match.Value);
                }

            }
        }
    }
}
