namespace Theatre.DataProcessor
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Xml;
    using System.Xml.Serialization;
    using Theatre.Data;
    using Theatre.DataProcessor.ExportDto;

    public class Serializer
    {
        public static string ExportTheatres(TheatreContext context, int numbersOfHalls)
        {
            var teathers = context
                .Theatres
                .ToList()
                .Where(x => x.NumberOfHalls >= numbersOfHalls && x.Tickets.Count() >= 20)
                .Select(x => new
                {
                    Name = x.Name,
                    Halls = x.NumberOfHalls,
                    TotalIncome = x.Tickets.Where(t => t.RowNumber >= 1 && t.RowNumber <= 5).Sum(t => t.Price),
                    Tickets = x.Tickets.Where(t => t.RowNumber >= 1 && t.RowNumber <= 5)
                        .Select(t => new
                        {
                            Price = t.Price,
                            RowNumber = t.RowNumber
                        })
                        .OrderByDescending(t => t.Price)
                        .ToList()
                })
                .OrderByDescending(x => x.Halls)
                .ThenBy(x => x.Name)
                .ToList();

            var result = JsonConvert.SerializeObject(teathers, Newtonsoft.Json.Formatting.Indented);

            return result; 
        }

        public static string ExportPlays(TheatreContext context, double rating)
        {
            var plays = context
                .Plays
                .ToList()
                .Where(x => x.Rating <= rating)
                .Select(x => new PlaysExportModel
                {
                    Title = x.Title,
                    Duration = x.Duration.ToString("c"),
                    Rating = x.Rating == 0 ? "Premier" : x.Rating.ToString(),
                    Genre = x.Genre.ToString(),
                    Actors = x.Casts
                        .Where(a => a.IsMainCharacter == true)
                        .Select(a => new ActorsModel
                        {
                            FullName = a.FullName,
                            MainCharacter = $"Plays main character in '{a.Play.Title}'."
                        })
                        .OrderByDescending(a => a.FullName)
                        .ToArray()
                })
                .OrderBy(x => x.Title)
                .ThenByDescending(x => x.Genre)
                .ToList();

            var xmlSerializer = new XmlSerializer(typeof(List<PlaysExportModel>), new XmlRootAttribute("Plays"));

            var textWriter = new StringWriter();

            var ns = new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty });

            xmlSerializer.Serialize(textWriter, plays, ns);

            return textWriter.ToString();
        }
    }
}
