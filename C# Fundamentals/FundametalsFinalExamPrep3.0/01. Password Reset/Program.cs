using System;

namespace _01._Password_Reset
{
    class Program
    {
        static void Main(string[] args)
        {
            string password = Console.ReadLine();

            string command = Console.ReadLine();

            while (command != "Done")
            {
                string[] commandArs = command.Split(" ");
                if (commandArs[0] == "TakeOdd")
                {
                    string newPassword = string.Empty;
                    for (int i = 1; i < password.Length; i += 2)
                    {
                        newPassword += password[i];
                    }
                    password = newPassword;
                    Console.WriteLine(password);
                }
                else if (commandArs[0] == "Cut")
                {
                    int index = int.Parse(commandArs[1]);
                    int lenght = int.Parse(commandArs[2]);

                    password = password.Remove(index, lenght);

                    Console.WriteLine(password);
                }
                else if (commandArs[0] == "Substitute")
                {
                    string substring = commandArs[1];
                    string substetute = commandArs[2];
                    if (password.Contains(substring))
                    {
                        password = password.Replace(substring, substetute);
                        Console.WriteLine(password);
                    }
                    else
                    {
                        Console.WriteLine("Nothing to replace!");
                    }

                }


                command = Console.ReadLine();
            }
            Console.WriteLine($"Your password is: {password}");
        }
    }
}
