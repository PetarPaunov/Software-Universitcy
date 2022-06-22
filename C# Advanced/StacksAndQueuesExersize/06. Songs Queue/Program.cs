using System;
using System.Collections.Generic;
using System.Linq;

namespace _06._Songs_Queue
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] inputSongs = Console.ReadLine().Split(", ")
                .ToArray();
            Queue<string> songs = new Queue<string>();
            foreach (var song in inputSongs)
            {
                songs.Enqueue(song);
            }

            string command = Console.ReadLine();

            while (true)
            {
                if (songs.Count == 0)
                {
                    Console.WriteLine("No more songs!");
                    break;
                }
                if (command.StartsWith("Play"))
                {
                    songs.Dequeue();

                }
                else if (command.StartsWith("Add"))
                {
                    string songFullName = command.Substring(4);
                    
                    
                    if (!songs.Contains(songFullName))
                    {
                        songs.Enqueue(songFullName);
                    }
                    else
                    {
                        Console.WriteLine($"{songFullName} is already contained!");
                    }
                }
                else if (command.StartsWith("Show"))
                {
                    Console.WriteLine(String.Join(", ", songs));
                }


                command = Console.ReadLine();
            }
            



        }
    }
}
