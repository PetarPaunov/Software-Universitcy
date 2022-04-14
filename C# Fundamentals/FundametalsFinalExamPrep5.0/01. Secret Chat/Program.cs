using System;
using System.Text;

namespace _01._Secret_Chat
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            string commands = Console.ReadLine();
            StringBuilder newInput = new StringBuilder(input);
            while (commands != "Reveal")
            {
                string[] splited = commands.Split(":|:");
                string command = splited[0];

                if (command == "InsertSpace")
                {
                    int index = int.Parse(splited[1]);

                    input = input.Insert(index, " ");
                    Console.WriteLine(input);
                }
                else if (command == "Reverse")
                {
                    string substring = splited[1];

                    if (input.Contains(substring))
                    {
                        int index = input.IndexOf(substring);
                        input = input.Remove(index, substring.Length);
                        string reversedSubstring = string.Empty;

                        for (int i = substring.Length - 1; i >= 0; i--)
                        {
                            reversedSubstring += substring[i];
                        }

                        input = input.Insert(input.Length, reversedSubstring);

                        Console.WriteLine(input);
                    }
                    else
                    {
                        Console.WriteLine("error");
                    }
                    
                }
                else if (command == "ChangeAll")
                {
                    string substring = splited[1];
                    string replacement = splited[2];

                    input = input.Replace(substring, replacement);
                    Console.WriteLine(input);
                }

                commands = Console.ReadLine();
            }
            Console.WriteLine($"You have a new text message: {input}");
        }
    }
}
