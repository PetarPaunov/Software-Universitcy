namespace BookShop
{
    using BookShop.Models.Enums;
    using Data;
    using Initializer;
    using System;
    using System.Globalization;
    using System.Linq;
    using System.Text;

    public class StartUp
    {
        public static void Main()
        {
            using var db = new BookShopContext();
            //DbInitializer.ResetDatabase(db);

            var result = CountCopiesByAuthor(db);

            Console.WriteLine(result);
        }


        //12. Total Book Copies
        public static string CountCopiesByAuthor(BookShopContext context)
        {
            var authors = context.Authors
                .Select(x => new
                {
                    x.FirstName,
                    x.LastName,
                    Copies = x.Books.Sum(x => x.Copies)
                })
                .OrderByDescending(x => x.Copies)
                .ToList();

            return String.Join(Environment.NewLine, authors
                .Select(x => $"{x.FirstName} {x.LastName} - {x.Copies}"));

        }

        //11. Count Books
        public static int CountBooks(BookShopContext context, int lengthCheck)
        {
            var books = context.Books
                .Where(x => x.Title.Length > lengthCheck)
                .Select(x => x.Title.Count())
                .ToList();

            return books.Count;
        }

        //10. Book Search by Author
        public static string GetBooksByAuthor(BookShopContext context, string input)
        {
            input = input.ToLower();

            var books = context.Books
                .Where(x => x.Author.LastName.ToLower().StartsWith(input))
                .Select(x => new
                {
                    x.Title,
                    x.BookId,
                    Author = x.Author.FirstName + " " + x.Author.LastName,
                })
                .OrderBy(x => x.BookId)
                .ToList();



            return String.Join(Environment.NewLine, books
                .Select(x => $"{x.Title} ({x.Author})"));
        }

        //9. Book Search
        public static string GetBookTitlesContaining(BookShopContext context, string input)
        {
            input = input.ToLower();

            var books = context.Books
                .Where(x => x.Title.ToLower().Contains(input))
                .Select(x => x.Title)
                .OrderBy(title => title)
                .ToList();

            return String.Join(Environment.NewLine, books.Select(Title => Title));
        }

        //8. Author Search
        public static string GetAuthorNamesEndingIn(BookShopContext context, string input)
        {
            var authors = context.Authors
                .Where(x => x.FirstName.EndsWith(input))
                .Select(x => new
                {
                    x.FirstName,
                    x.LastName
                })
                .OrderBy(x => x.FirstName)
                .ThenBy(x => x.LastName)
                .ToList();

            return String.Join(Environment.NewLine, authors.Select(x => $"{x.FirstName} {x.LastName}"));
        }
        //7. Released Before Date
        public static string GetBooksReleasedBefore(BookShopContext context, string date)
        {
            var targetDate = DateTime.ParseExact(date, "dd-MM-yyyy", CultureInfo.InvariantCulture);

            var books = context.Books
                .Where(x => x.ReleaseDate.Value < targetDate)
                .Select(x => new
                {
                    Title = x.Title,
                    Edition = x.EditionType,
                    Price = x.Price,
                    ReleaseDate = x.ReleaseDate.Value
                })
                .OrderByDescending(x => x.ReleaseDate)
                .ToList();

            return String.Join(Environment.NewLine, books
                .Select(x => $"{x.Title} - {x.Edition} - ${x.Price:F2}"));
        }

        //6. Book Titles by Category
        public static string GetBooksByCategory(BookShopContext context, string input)
        {
            var categories = input.Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(x => x.ToLower())
                .ToArray();

            var books = context.Books
                .Where(x => x.BookCategories
                    .Any(x => categories.Contains
                        (x.Category.Name.ToLower())))
                .Select(x => x.Title)
                .OrderBy(title => title)
                .ToList();

            return String.Join(Environment.NewLine, books);    
        }

        //5. Not Released In
        public static string GetBooksNotReleasedIn(BookShopContext context, int year)
        {
            var books = context.Books
                .Where(x => x.ReleaseDate.Value.Year != year)
                .Select(x => new
                {
                    Id = x.BookId,
                    Title = x.Title
                })
                .OrderBy(x => x.Id).ToList();

            return String.Join(Environment.NewLine, books.Select(x => x.Title));
        }

        //4. Books by Price
        public static string GetBooksByPrice(BookShopContext context)
        {
            var books = context.Books
                .Where(x => x.Price > 40)
                .Select(x => new
                {
                    Price = x.Price,
                    Title = x.Title
                })
                .OrderByDescending(x => x.Price)
                .ToList();

            StringBuilder sb = new StringBuilder(); ;

            foreach (var book in books)
            {
                sb.AppendLine($"{book.Title} - ${book.Price:F2}");
            }

            return sb.ToString().TrimEnd();
        }

        //3. Golden Books
        public static string GetGoldenBooks(BookShopContext context)
        {
            var editionTipe = Enum.Parse<EditionType>("Gold");

            var books = context.Books
                .Where(x => x.EditionType == editionTipe && x.Copies < 5000)
                .Select(x => new
                {
                    Id = x.BookId,
                    Title = x.Title
                })
                .OrderBy(x => x.Id)
                .ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var book in books)
            {
                sb.AppendLine(book.Title);
            }

            return sb.ToString().TrimEnd();
        }

        //2. Age Restriction
        public static string GetBooksByAgeRestriction(BookShopContext context, string command)
        {
            var restriction = Enum.Parse<AgeRestriction>(command, true);

            var books = context.Books
                .Where(x => x.AgeRestriction == restriction)
                .Select(x => x.Title)
                .OrderBy(x => x)
                .ToList();

            return String.Join(Environment.NewLine, books);
        }
    }
}
