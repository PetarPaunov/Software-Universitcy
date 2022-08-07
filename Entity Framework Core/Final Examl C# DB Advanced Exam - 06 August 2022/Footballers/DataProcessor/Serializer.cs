namespace Footballers.DataProcessor
{
    using System;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Xml;
    using System.Xml.Serialization;
    using Data;
    using Footballers.DataProcessor.ExportDto;
    using Newtonsoft.Json;
    using Formatting = Newtonsoft.Json.Formatting;

    public class Serializer
    {
        public static string ExportCoachesWithTheirFootballers(FootballersContext context)
        {
            var coaches = context
                .Coaches
                .Where(x => x.Footballers.Count > 0)
                .ToArray()
                .Select(x => new ExportCoachesModel
                {
                    FootballersCount = x.Footballers.Count().ToString(),
                    CoachName = x.Name,
                    Footballers = x.Footballers.
                        Select(f => new ExportFootballers
                        {
                            Name = f.Name,
                            Position = f.PositionType.ToString()
                        })
                        .OrderBy(x => x.Name)
                        .ToArray()
                })
                .OrderByDescending(x => x.Footballers.Count())
                .ThenBy(x => x.CoachName)
                .ToArray();

            var xmlSerializer = new XmlSerializer(typeof(ExportCoachesModel[]), new XmlRootAttribute("Coaches"));

            var textWriter = new StringWriter();

            var ns = new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty });

            xmlSerializer.Serialize(textWriter, coaches, ns);

            return textWriter.ToString();
        }

        public static string ExportTeamsWithMostFootballers(FootballersContext context, DateTime date)
        {
            var teams = context
                .Teams
                .Where(x => x.TeamsFootballers.Any(f => f.Footballer.ContractStartDate >= date))
                .ToArray()
                .Select(x => new
                {
                    Name = x.Name,
                    Footballers = x.TeamsFootballers
                        .Where(f => f.Footballer.ContractStartDate >= date)
                        .ToArray()
                        .OrderByDescending(f => f.Footballer.ContractEndDate)
                        .ThenBy(f => f.Footballer.Name)
                        .Select(x => new
                        {
                            FootballerName = x.Footballer.Name,
                            ContractStartDate = x.Footballer.ContractStartDate.ToString("d", CultureInfo.InvariantCulture),
                            ContractEndDate = x.Footballer.ContractEndDate.ToString("d", CultureInfo.InvariantCulture),
                            BestSkillType = x.Footballer.BestSkillType.ToString(),
                            PositionType = x.Footballer.PositionType.ToString()
                        })
                        .ToArray()
                })
                .OrderByDescending(x => x.Footballers.Count())
                .ThenBy(x => x.Name)
                .Take(5)
                .ToArray();

            return JsonConvert.SerializeObject(teams, Formatting.Indented);
        }
    }
}
