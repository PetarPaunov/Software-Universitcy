using System;

namespace _02._Articles
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(", ");

            Articals articals = new Articals(input[0], input[1], input[2]);

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] command = Console.ReadLine().Split(": ");
                string commandName = command[0];
                string commandValu = command[1];


                if (commandName == "Edit")
                {
                    articals.Edint(commandValu);
                }
                if (commandName == "ChangeAuthor")
                {
                    articals.ChangeAuthor(commandValu);
                }
                if (commandName == "Rename")
                {
                    articals.Rename(commandValu);
                }

            }
            Console.WriteLine(articals);
        }
        class Articals
        {
            public Articals(string title, string content, string author)
            {
                Title = title;
                Content = content;
                Author = author;
            }
            public string Title { get; set; }
            public string Content { get; set; }
            public string Author { get; set; }

            public void Edint(string content)
            {
                Content = content;
            }
            public void ChangeAuthor(string author)
            {
                Author = author;
            }
            public void Rename(string title)
            {
                Title = title;
            }

            public override string ToString()
            {
                return $"{Title} - {Content}: {Author}";
            }

        }

    }
 
}     
