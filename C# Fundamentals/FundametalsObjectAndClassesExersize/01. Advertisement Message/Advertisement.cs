using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01._Advertisement_Message
{
    //class RandomGen
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
