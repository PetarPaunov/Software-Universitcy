using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
namespace _03._The_Pianist
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Dictionary<string, string> pieceComposer = new Dictionary<string, string>();
            Dictionary<string, string> pieceKey = new Dictionary<string, string>();

            for (int i = 0; i < n; i++)
            {
                string[] firstInput = Console.ReadLine()
                    .Split("|");

                string piece = firstInput[0];
                string composer = firstInput[1];
                string key = firstInput[2];

                pieceComposer.Add(piece, composer);
                pieceKey.Add(piece, key);

            }

            string input = Console.ReadLine();

            while (input != "Stop")
            {
                string[] inputArgs = input.Split("|");
                string command = inputArgs[0];

                if (command == "Add")
                {
                    string piece = inputArgs[1];
                    string composer = inputArgs[2];
                    string key = inputArgs[3];

                    if (pieceComposer.ContainsKey(piece))
                    {
                        
                        Console.WriteLine($"{piece} is already in the collection!");
                    }
                    else
                    {
                        pieceComposer.Add(piece, composer);
                        pieceKey.Add(piece, key);
                        Console.WriteLine($"{piece} by {composer} in {key} added to the collection!");
                    }
                }
                else if (command == "Remove")
                {
                    string piece = inputArgs[1];

                    if (pieceComposer.ContainsKey(piece))
                    {
                        pieceComposer.Remove(piece);
                        pieceKey.Remove(piece);
                        Console.WriteLine($"Successfully removed {piece}!");
                    }
                    else
                    {
                        Console.WriteLine($"Invalid operation! {piece} does not exist in the collection.");
                    }
                }
                else if (command == "ChangeKey")
                {
                    string piece = inputArgs[1];
                    string key = inputArgs[2];

                    if (pieceKey.ContainsKey(piece))
                    {
                        pieceKey[piece] = key;
                        Console.WriteLine($"Changed the key of {piece} to {key}!");
                    }
                    else
                    {
                        Console.WriteLine($"Invalid operation! {piece} does not exist in the collection.");
                    }
                }

                input = Console.ReadLine();
            }

            foreach (var piece in pieceComposer.OrderBy(x => x.Key).ThenBy(x => x.Value))
            {
                Console.WriteLine($"{piece.Key} -> Composer: {piece.Value}, Key: {pieceKey[piece.Key]}");
            }


        }
    }
}
