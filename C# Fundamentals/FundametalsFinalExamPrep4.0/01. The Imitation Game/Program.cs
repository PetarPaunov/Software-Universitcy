using System;

namespace _01._The_Imitation_Game
{
    class Program
    {
        static void Main(string[] args)
        {
            string encriptedMessige = Console.ReadLine();

            string input = Console.ReadLine();

            while (input != "Decode")
            {
                string[] inputArgs = input.Split("|");
                string command = inputArgs[0];

                if (command == "Move")
                {
                    int num = int.Parse(inputArgs[1]);
                    string substring = encriptedMessige.Substring(0, num);

                    encriptedMessige = encriptedMessige.Remove(0, num);

                    encriptedMessige = encriptedMessige.Insert(encriptedMessige.Length, substring);
                }
                else if (command == "Insert")
                {
                    int index = int.Parse(inputArgs[1]);
                    string value = inputArgs[2];
                    

                    encriptedMessige = encriptedMessige.Insert(index, value);

                }
                else if (command == "ChangeAll")
                {
                    string substring = inputArgs[1];
                    string replace = inputArgs[2];

                    encriptedMessige = encriptedMessige.Replace(substring, replace);
                }


                input = Console.ReadLine();
            }
            Console.WriteLine($"The decrypted message is: {encriptedMessige}");
        }
    }
}
