using System;
using System.Collections.Generic;
using System.Linq;

namespace _11._The_Party_Reservation_Filter_Module
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> inventedPeople = Console.ReadLine().Split().ToList();

            var dictionary = new Dictionary<string, Predicate<string>>();
            string command = Console.ReadLine();

            while (command != "Print")
            {
                string[] commandInfo = command.Split(";");
                string action = commandInfo[0];
                string predicateAction = commandInfo[1];
                string value = commandInfo[2];
                string key = predicateAction + "_" + value;

                if (commandInfo[0] == "Add filter")
                {
                    
                    Predicate<string> predicate = GetPredicate(predicateAction, value);
                    dictionary.Add(key, predicate);
                }
                else if (commandInfo[0] == "Remove filter")
                {
                    dictionary.Remove(key);
                }


                command = Console.ReadLine();
            }

            foreach (var (key, predicate) in dictionary)
            {
                inventedPeople.RemoveAll(predicate);
            }

            Console.WriteLine(string.Join(" ", inventedPeople));
        }

        private static Predicate<string> GetPredicate(string predicateAction, string value)
        {
            if (predicateAction == "Starts with")
            {
                return x => x.StartsWith(value);
            }
            else if (predicateAction == "Ends with")
            {
                return x => x.EndsWith(value);
            }
            else if (predicateAction == "Lenght")
            {
                int lenght = int.Parse(value);
                return x => x.Length == lenght;
            }

            return x => x.Contains(value);
        }
    }
}
