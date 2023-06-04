namespace _6
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal class Program
    {
        private static Dictionary<int, List<string>> wordsByIndex;
        private static Dictionary<string, int> wordsCount;
        private static LinkedList<string> usedWords;

        private static string target;

        static void Main(string[] args)
        {
            var words = Console.ReadLine().Split(", ").ToArray();
            target = Console.ReadLine();

            wordsByIndex = new Dictionary<int, List<string>>();
            wordsCount = new Dictionary<string, int>();
            usedWords = new LinkedList<string>();

            foreach (var word in words)
            {
                var index = target.IndexOf(word);

                if (index == -1)
                {
                    continue;
                }

                if (wordsCount.ContainsKey(word))
                {
                    wordsCount[word]++;
                    continue;
                }

                wordsCount[word] = 1;

                while (index != -1)
                {
                    if (!wordsByIndex.ContainsKey(index))
                    {
                        wordsByIndex[index] = new List<string>();
                    }

                    wordsByIndex[index].Add(word);

                    index = target.IndexOf(word, index + 1);
                }
            }

            GenerateResult(0);
        }

        private static void GenerateResult(int index)
        {
            if (index == target.Length)
            {
                Console.WriteLine(string.Join(' ', usedWords));
                return;
            }

            if (!wordsByIndex.ContainsKey(index))
            {
                return;
            }

            foreach (var word in wordsByIndex[index])
            {
                if (wordsCount[word] == 0)
                {
                    continue;
                }

                wordsCount[word] -= 1;
                usedWords.AddLast(word);

                GenerateResult(index + word.Length);

                wordsCount[word] += 1;
                usedWords.RemoveLast();
            }
        }   
    }
}