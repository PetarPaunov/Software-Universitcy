using System;
using System.Text;

namespace _01._Activation_Keys
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            string command = Console.ReadLine();

            while (command != "Generate")
            {
                string[] splited = command.Split(">>>");

                if (splited[0] == "Contains")
                {
                    string substring = splited[1];

                    if (input.Contains(substring))  
                    {
                        Console.WriteLine($"{input} contains {substring}");
                    }
                    else
                    {
                        Console.WriteLine("Substring not found!");
                    }

                }
                if (splited[0] == "Flip")
                {
                    string upperOrLowor = splited[1];

                    if (upperOrLowor == "Upper")
                    {
                        int startIndex = int.Parse(splited[2]);
                        int endIndex = int.Parse(splited[3]);
                        int indexLenght = endIndex - startIndex;
                        string substring = input.Substring(startIndex, indexLenght);
                        substring = substring.ToUpper();

                        input = input.Remove(startIndex, indexLenght);
                        input = input.Insert(startIndex, substring);

                        Console.WriteLine(input);
                    }
                    else if (upperOrLowor == "Lower")
                    {
                        int startIndex = int.Parse(splited[2]);
                        int endIndex = int.Parse(splited[3]);
                        int indexLenght = endIndex - startIndex;
                        string substring = input.Substring(startIndex, indexLenght);
                        substring = substring.ToLower();

                        input = input.Remove(startIndex, indexLenght);
                        input = input.Insert(startIndex, substring);

                        Console.WriteLine(input);
                    }
                }
                if (splited[0] == "Slice")
                {
                    int staringIndex = int.Parse(splited[1]);
                    int endIndex = int.Parse(splited[2]);
                    int idenxLenght = endIndex - staringIndex;
                    input = input.Remove(staringIndex, idenxLenght);

                    Console.WriteLine(input);
                }

                command = Console.ReadLine();
            }

            Console.WriteLine($"Your activation key is: {input}");
        }
    }
}
