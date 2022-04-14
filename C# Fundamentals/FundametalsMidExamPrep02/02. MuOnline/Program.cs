using System;

namespace _02._MuOnline
{
    class Program
    {
        static void Main(string[] args)
        {
            int initcialHelth = 100;
            int bitcoint = 0;
            bool isDeath = false;

            string[] room = Console.ReadLine()
                .Split("|");

            for (int i = 0; i < room.Length; i++)
            {
                string command = room[i];
                string[] splited = command.Split();
                if (splited[0] == "potion")
                {
                    int curentHelth = initcialHelth;
                    initcialHelth += int.Parse(splited[1]);

                    if (initcialHelth < 100)
                    {
                        
                        Console.WriteLine($"You healed for {splited[1]} hp.");
                        Console.WriteLine($"Current health: {initcialHelth} hp.");
                    }
                    else if (initcialHelth > 100)
                    {                   
                        int diff = 100 - curentHelth;
                        initcialHelth = 100;
                        Console.WriteLine($"You healed for {diff} hp.");
                        Console.WriteLine($"Current health: {initcialHelth} hp.");
                    }


                }
                else if (splited[0] == "chest")
                {
                    int numberOfBitcoin = int.Parse(splited[1]);
                    bitcoint += numberOfBitcoin;
                    Console.WriteLine($"You found {numberOfBitcoin} bitcoins.");
                }
                else
                {
                    initcialHelth -= int.Parse(splited[1]);

                    if (initcialHelth > 0)
                    {
                        Console.WriteLine($"You slayed {splited[0]}.");
                    }
                    else if (initcialHelth <= 0)
                    {
                        Console.WriteLine($"You died! Killed by {splited[0]}.");
                        Console.WriteLine($"Best room: {i + 1}");
                        isDeath = true;
                        break;
                    }

                }
            }
            if (!isDeath)
            {
                Console.WriteLine("You've made it!");
                Console.WriteLine($"Bitcoins: {bitcoint}");
                Console.WriteLine($"Health: {initcialHelth}");
            }


        }
    }
}
