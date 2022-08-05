namespace BookShop.DataProcessor
{
    using System;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Serialization;
    using BookShop.DataProcessor.ExportDto;
    using Data;
    using Newtonsoft.Json;
    using Formatting = Newtonsoft.Json.Formatting;

    public class Serializer
    {
        public static string ExportMostCraziestAuthors(BookShopContext context)
        {
            var authors = context
                .Authors
                .Select(x => new
                {
                    AuthorName = x.FirstName + " " + x.LastName,
                    Books = x.AuthorsBooks
                        .Select(ab => ab.Book)
                        .OrderByDescending(b => b.Price)
                        .Select(b => new
                        {
                            BookName = b.Name,
                            BookPrice = b.Price.ToString("F2")
                        })
                        .ToList()
                })
                .ToList()
                .OrderByDescending(x => x.Books.Count())
                .ThenBy(x => x.AuthorName)
                .ToList();

            return JsonConvert.SerializeObject(authors, Formatting.Indented);
        }

        public static string ExportOldestBooks(BookShopContext context, DateTime date)
        {
            var oldestBooks = context
                .Books
                .Where(x => x.PublishedOn < date && x.Genre.ToString() == "Science")
                .OrderByDescending(x => x.Pages)
                .ThenByDescending(x => x.PublishedOn)
                .Select(x => new ExportOldestBooksModel
                {
                    Pages = x.Pages.ToString(),
                    Name = x.Name,
                    Date = x.PublishedOn.ToString("d", CultureInfo.InvariantCulture)
                })
                .ToArray()
                .Take(10)
                .ToArray();

            var xmlSerializer = new XmlSerializer(typeof(ExportOldestBooksModel[]), new XmlRootAttribute("Books"));

            var textWriter = new StringWriter();

            var ns = new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty });

            xmlSerializer.Serialize(textWriter, oldestBooks, ns);

            return textWriter.ToString();
        }
    }
}