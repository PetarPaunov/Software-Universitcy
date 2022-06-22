using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Heroes_of_Code_and_Logic_VII
{
    class Program
    {
        static void Main(string[] args)
        {
            int partyNumber = int.Parse(Console.ReadLine());

            Dictionary<string, int> heroHP = new Dictionary<string, int>();
            Dictionary<string, int> heroMP = new Dictionary<string, int>();

            for (int i = 0; i < partyNumber; i++)
            {
                string heroes = Console.ReadLine();
                string[] heroArgs = heroes.Split(" ");                  
                string heroName = heroArgs[0];
                int hitPoints = int.Parse(heroArgs[1]);
                int manaPoints = int.Parse(heroArgs[2]);

                heroHP.Add(heroName, hitPoints);
                heroMP.Add(heroName, manaPoints);

            }

            string input = Console.ReadLine();

            while (input != "End")
            {
                //CastSpell – {hero name} – {MP needed} – {spell name} 
                string[] inputArgs = input.Split(" - ").ToArray();
                string command = inputArgs[0];

                if (command == "CastSpell")
                {
                    string heroName = inputArgs[1];
                    int mpNeeded = int.Parse(inputArgs[2]);
                    string spellName = inputArgs[3];

                    if (heroMP[heroName] < mpNeeded)
                    {
                        Console.WriteLine($"{heroName} does not have enough MP to cast {spellName}!");  
                    }
                    else
                    {
                        heroMP[heroName] -= mpNeeded;

                        Console.WriteLine($"{heroName} has successfully cast {spellName} and now has {heroMP[heroName]} MP!");
                    }
                }
                else if (command == "TakeDamage")
                {
                    //TakeDamage – {hero name} – {damage} – {attacker}
                    string heroName = inputArgs[1];
                    int demage = int.Parse(inputArgs[2]);
                    string attacer = inputArgs[3];

                    if (heroHP[heroName] <= demage)
                    {
                        heroHP.Remove(heroName);
                        heroMP.Remove(heroName);
                        Console.WriteLine($"{heroName} has been killed by {attacer}!");
                        
                    }
                    else
                    {
                        heroHP[heroName] -= demage;
                        Console.WriteLine($"{heroName} was hit for {demage} HP by {attacer} and now has {heroHP[heroName]} HP left!");
                    }
                }
                else if (command == "Recharge")
                {
                    //Recharge – {hero name} – {amount}
                    string heroName = inputArgs[1];
                    int amount = int.Parse(inputArgs[2]); 
                    if (heroMP[heroName] + amount > 200)
                    {
                        Console.WriteLine($"{heroName} recharged for {200 - heroMP[heroName]} MP!");
                        heroMP[heroName] = 200;
                        
                    }
                    else
                    {
                        heroMP[heroName] += amount;
                        Console.WriteLine($"{heroName} recharged for {amount} MP!");
                    }
                }
                else if (command == "Heal")
                {
                    //Heal – {hero name} – {amount}
                    string heroName = inputArgs[1];
                    int amaunt = int.Parse(inputArgs[2]);
                    if (heroHP[heroName] + amaunt > 100)
                    {
                        Console.WriteLine($"{heroName} healed for {100 - heroHP[heroName]} HP!");
                        heroHP[heroName] = 100;
                       
                    }
                    else
                    {
                        heroHP[heroName] += amaunt;
                        Console.WriteLine($"{heroName} healed for {amaunt} HP!");
                    }

                    
                }

                input = Console.ReadLine();
            }

            foreach (var hero in heroHP.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
            {
                Console.WriteLine(hero.Key);
                Console.WriteLine($"HP: {hero.Value}");
                Console.WriteLine($"MP: {heroMP[hero.Key]}");
            }


            //heroHP = heroHP
            //    .Where(h => h.Value > 0)
            //    .OrderByDescending(h => h.Value)
            //    .ThenBy(h => h.Key)
            //    .ToDictionary(h => h.Key, h => h.Value);

            //foreach (var hero in heroHP)
            //{
            //    Console.WriteLine(hero.Key);
            //    Console.WriteLine($"HP: {hero.Value}");
            //    Console.WriteLine($"MP: {heroMP[hero.Key]}");
            //}
        }
    }
}
