using System;
using System.Text.RegularExpressions;

namespace _02._Fancy_Barcodes
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"[@][#]+[A-Z][A-Za-z0-9]{4,}[A-Z][@][#]+";
            string digitPattern = @"[0-9]";
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string barcodes = Console.ReadLine();

                Match match = Regex.Match(barcodes, pattern);

                if (!match.Success)
                {
                    Console.WriteLine("Invalid barcode");
                }
                else
                {
                    MatchCollection matches = Regex.Matches(match.Value, digitPattern);   

                    Console.Write($"Product group: ");

                    if (matches.Count == 0)
                    {
                        Console.WriteLine("00");
                        continue;
                    }

                    foreach (Match m in matches)
                    {
                        Console.Write(m.Value);
                    }
                    Console.WriteLine();

                }
            }
            
        }
    }
}
