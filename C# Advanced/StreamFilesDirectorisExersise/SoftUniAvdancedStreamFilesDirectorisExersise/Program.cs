using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;

namespace SoftUniAvdancedStreamFilesDirectorisExersise
{
    class Program
    {
        static void Main(string[] args)
        {
            

        }

        private static void ZipAndExtract()
        {
            string sourceDirectory = @"C:\Users\petar\source\repos\SoftUniAvdancedStreamFilesDirectorisExersise\SoftUniAvdancedStreamFilesDirectorisExersise\zipExer";
            string targetDirectory = @"C:\Users\petar\source\repos\SoftUniAvdancedStreamFilesDirectorisExersise\SoftUniAvdancedStreamFilesDirectorisExersise\ZipExer2\result.zip";
            ZipFile.CreateFromDirectory(sourceDirectory, targetDirectory);

            string destinatinDirectory = @"C:\Users\petar\source\repos\SoftUniAvdancedStreamFilesDirectorisExersise\SoftUniAvdancedStreamFilesDirectorisExersise\ZipExer2\result";

            ZipFile.ExtractToDirectory(targetDirectory, destinatinDirectory);
        }

        private static void DirectoriTravelars()
        {
            string[] allFiles = Directory.GetFiles(@"..\..\..\", ".");

            Dictionary<string, Dictionary<string, double>> grupedFiles = new Dictionary<string, Dictionary<string, double>>();

            foreach (var file in allFiles)
            {
                FileInfo fileInfo = new FileInfo(file);

                if (!grupedFiles.ContainsKey(fileInfo.Extension))
                {
                    grupedFiles.Add(fileInfo.Extension, new Dictionary<string, double>());
                }
                double size = (double)fileInfo.Length / 1024;
                grupedFiles[fileInfo.Extension].Add(fileInfo.Name, size);

            }

            var sortedFiles = grupedFiles.OrderByDescending(x => x.Value.Count)
                .ThenBy(x => x.Key);

            List<string> fails = new List<string>();
            foreach (var file in sortedFiles)
            {
                fails.Add(file.Key);


                foreach (var item in file.Value)
                {
                    fails.Add($"--{item.Key} - {item.Value:F2}");
                }
            }

            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "/report.txt";

            File.WriteAllLines(path, fails);
        }

        private static void CopyBinariFile()
        {
            FileStream fileReader = new FileStream(@"..\..\..\copyMe.png", FileMode.Open);

            FileStream fileWriter = new FileStream(@"..\..\..\copyMeCopy.png", FileMode.Create);

            byte[] buffer = new byte[256];

            while (true)
            {
                int currentByts = fileReader.Read(buffer, 0, buffer.Length);

                if (currentByts == 0)
                {
                    fileWriter.Flush();
                    break;
                }

                fileWriter.Write(buffer, 0, buffer.Length);
            }
        }

        private static void WordCount()
        {
            Dictionary<string, int> wordsCount = new Dictionary<string, int>();

            string[] words = File.ReadAllLines(@"..\..\..\words.txt");

            string[] chekForWords = File.ReadAllLines(@"..\..\..\text.txt");

            foreach (var word in words)
            {
                if (!wordsCount.ContainsKey(word))
                {
                    wordsCount.Add(word, 0);

                }
            }


            foreach (var line in chekForWords)
            {

                foreach (var word in wordsCount)
                {

                    if (line.Contains(word.Key, StringComparison.OrdinalIgnoreCase))
                    {
                        wordsCount[word.Key]++;
                    }


                }
            }

            foreach (var word in wordsCount.OrderByDescending(x => x.Value))
            {
                string result = $"{word.Key} - {word.Value}{Environment.NewLine}";
                File.AppendAllText(@"..\..\..\actualResult.txt", result);
            }
        }

        private static void LineNumbers()
        {
            StreamReader streamReader = new StreamReader(@"..\..\..\text.txt");

            int count = 1;

            int letters = 0;

            int punctiation = 0;

            while (true)
            {
                string result = streamReader.ReadLine();

                if (result == null)
                {
                    break;
                }

                for (int i = 0; i < result.Length; i++)
                {
                    if (char.IsLetter(result[i]))
                    {
                        letters++;
                    }
                    if (char.IsPunctuation(result[i]))
                    {
                        punctiation++;
                    }
                }

                File.AppendAllText("../../../output.txt", $"Line {count}:{result} ({letters})({punctiation}){Environment.NewLine}");
                letters = 0;
                punctiation = 0;
                count++;

            }
        }

        private static void EvenLines()
        {
            StreamReader streamReader = new StreamReader(@"..\..\..\text.txt");

            string[] symbols = new string[] { "-", ",", ".", "!", "?" };

            bool isEven = true;

            while (true)
            {
                string output = streamReader.ReadLine();
                if (output == null)
                {
                    break;
                }

                if (!isEven)
                {
                    isEven = true;
                    continue;
                }

                foreach (var symbol in symbols)
                {
                    output = output.Replace(symbol, "@");
                }

                isEven = false;


                Console.WriteLine(string.Join(" ", output.Split(" ").Reverse()));
            }
        }
    }
}
