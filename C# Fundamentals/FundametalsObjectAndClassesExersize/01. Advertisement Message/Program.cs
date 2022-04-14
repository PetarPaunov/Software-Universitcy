using System;
using System.Collections.Generic;

namespace _01._Advertisement_Message
{
    class Program
    {
        static void Main(string[] args)
        {
            RandomGen phrases = new RandomGen(new List<String>() { "Excellent product.", "Such a great product.",
                "I always use that product.",
                "Best product of its category.", "Exceptional product.", "I can’t live without this product." });
            RandomGen events = new RandomGen(new List<string>() { "Now I feel good.", "I have succeeded with this product.", "Makes miracles. I am happy of the results!",
                "I cannot believe but now I feel awesome.", "Try it yourself, I am very satisfied.", "I feel great!" });
            RandomGen Authors = new RandomGen(new List<string>() { "Diana", "Petya", "Stella", "Elena", "Katya", "Iva", "Annie", "Eva" }
);
            RandomGen Cities = new RandomGen(new List<string>() { "Burgas", "Sofia", "Plovdiv", "Varna", "Ruse" }
);
            Console.WriteLine($"{phrases.GetRandomPhrases()} {events.GetRandomPhrases()} {Authors.GetRandomPhrases()} - {Cities.GetRandomPhrases()}");
        }
    }
    class RandomGen
    {
        public RandomGen(List<string> phrases)
        {
            Phrases = phrases;
        }
        public List<string> Phrases { get; set; }

        public string GetRandomPhrases()
        {
            Random random = new Random();
            return Phrases[random.Next(Phrases.Count)];


        }
    }
}
