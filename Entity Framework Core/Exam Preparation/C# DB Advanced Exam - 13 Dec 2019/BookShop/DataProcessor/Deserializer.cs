namespace BookShop.DataProcessor
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using BookShop.Data.Models;
    using BookShop.Data.Models.Enums;
    using BookShop.DataProcessor.ImportDto;
    using Data;
    using Newtonsoft.Json;
    using ValidationContext = System.ComponentModel.DataAnnotations.ValidationContext;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfullyImportedBook
            = "Successfully imported book {0} for {1:F2}.";

        private const string SuccessfullyImportedAuthor
            = "Successfully imported author - {0} with {1} books.";

        public static string ImportBooks(BookShopContext context, string xmlString)
        {
            var xmlSerializer = new XmlSerializer(typeof(ImportBooksModel[]), new XmlRootAttribute("Books"));

            var stringReader = new StringReader(xmlString);

            var bookDto = xmlSerializer.Deserialize(stringReader) as ImportBooksModel[];

            var sb = new StringBuilder();

            foreach (var book in bookDto)
            {
                if (!IsValid(book))
                {
                    sb.AppendLine("Invalid data!");
                    continue;
                }

                if (!Enum.IsDefined(typeof(Genre), book.Genre))
                {
                    sb.AppendLine("Invalid data!");
                    continue;
                }

                var bookDate = DateTime
                    .TryParseExact(
                        book.PublishedOn, 
                        "MM/dd/yyyy", 
                        CultureInfo.InvariantCulture, 
                        DateTimeStyles.None, 
                        out var currentDate
                    );

                if (!bookDate)
                {
                    sb.AppendLine("Invalid data!");
                    continue;
                }

                var currentGenre = Enum.Parse<Genre>(Enum.GetName(typeof(Genre), book.Genre));


                var currentBook = new Book
                {
                    Name = book.Name,
                    Genre = currentGenre,
                    Price = book.Price,
                    Pages = book.Pages,
                    PublishedOn = currentDate,

                };

                context.Books.Add(currentBook);
                context.SaveChanges();

                sb.AppendLine($"Successfully imported book {currentBook.Name} for {currentBook.Price:F2}.");
            }
            return sb.ToString().TrimEnd();
        }

        public static string ImportAuthors(BookShopContext context, string jsonString)
        {
            var authorsDto = JsonConvert.DeserializeObject<ImportAuthorsModel[]>(jsonString);

            var sb = new StringBuilder();

            foreach (var author in authorsDto)
            {
                if (!IsValid(author))
                {
                    sb.AppendLine("Invalid data!");
                    continue;
                }

                var emailExists = context.Authors.Any(x => x.Email == author.Email);

                if (emailExists)
                {
                    sb.AppendLine("Invalid data!");
                    continue;
                }

                var currentAuthor = new Author
                {
                    FirstName = author.FirstName,
                    LastName = author.LastName,
                    Phone = author.Phone,
                    Email = author.Email
                };

                foreach (var book in author.Books)
                {
                    var bookIsNull = context.Books.Find(book.Id);

                    if (bookIsNull == null)
                    {
                        continue;
                    }

                    var currentBook = new AuthorBook
                    {
                        Book = bookIsNull,
                        Author = currentAuthor
                    };

                    currentAuthor.AuthorsBooks.Add(currentBook);
                }

                if (currentAuthor.AuthorsBooks.Count() == 0)
                {
                    sb.AppendLine("Invalid data!");
                    continue;
                }

                context.Authors.Add(currentAuthor);
                context.SaveChanges();

                sb.AppendLine($"Successfully imported author - {currentAuthor.FirstName + ' ' + currentAuthor.LastName} with {currentAuthor.AuthorsBooks.Count()} books.");
            }

            return sb.ToString().TrimEnd();
        }

        private static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }
    }
}