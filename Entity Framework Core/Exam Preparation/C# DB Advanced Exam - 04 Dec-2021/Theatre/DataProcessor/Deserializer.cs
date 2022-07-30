namespace Theatre.DataProcessor
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using Theatre.Data;
    using Theatre.Data.Models;
    using Theatre.Data.Models.Enums;
    using Theatre.DataProcessor.ImportDto;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfulImportPlay
            = "Successfully imported {0} with genre {1} and a rating of {2}!";

        private const string SuccessfulImportActor
            = "Successfully imported actor {0} as a {1} character!";

        private const string SuccessfulImportTheatre
            = "Successfully imported theatre {0} with #{1} tickets!";

        public static string ImportPlays(TheatreContext context, string xmlString)
        {
            var xmlSerializer = new XmlSerializer(typeof(ImportPlaysModel[]), new XmlRootAttribute("Plays"));

            var textReader = new StringReader(xmlString);

            var sb = new StringBuilder();

            var playsDto = xmlSerializer.Deserialize(textReader) as ImportPlaysModel[];

            var playList = new List<Play>();

            foreach (var play in playsDto)
            {
                var spanTime = TimeSpan.ParseExact(play.Duration, "c", CultureInfo.InvariantCulture);

                if (!IsValid(play) || spanTime.Hours < 1)
                {
                    sb.AppendLine("Invalid data!");
                    continue;
                }

                var currentPlay = new Play
                {
                    Title = play.Title,
                    Duration = spanTime,
                    Rating = play.Rating,
                    Genre = Enum.Parse<Genre>(play.Genre),
                    Description = play.Description,
                    Screenwriter = play.Screenwriter
                };

                playList.Add(currentPlay);

                sb.AppendLine($"Successfully imported {play.Title} with genre {play.Genre} and a rating of {play.Rating}!");
            }

            context.Plays.AddRange(playList);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportCasts(TheatreContext context, string xmlString)
        {
            var xmlSerializer = new XmlSerializer(typeof(CastsImportModel[]), new XmlRootAttribute("Casts"));

            var textReader = new StringReader(xmlString);

            var sb = new StringBuilder();

            var castDto = xmlSerializer.Deserialize(textReader) as CastsImportModel[];

            var castList = new List<Cast>();

            foreach (var cast in castDto)
            {
                if (!IsValid(cast))
                {
                    sb.AppendLine("Invalid data!");
                    continue;
                }

                var currentCast = new Cast
                {
                    FullName = cast.FullName,
                    IsMainCharacter = cast.IsMainCharacter == "false" ? false : true,
                    PhoneNumber = cast.PhoneNumber,
                    PlayId = cast.PlayId
                };

                castList.Add(currentCast);

                var mainOrLasser = currentCast.IsMainCharacter == false ? "lesser" : "main";

                sb.AppendLine($"Successfully imported actor {currentCast.FullName} as a {mainOrLasser} character!");
            }

            context.Casts.AddRange(castList);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportTtheatersTickets(TheatreContext context, string jsonString)
        {
            var theaterTickets = JsonConvert.DeserializeObject<ImportTheaterAndTicketsModel[]>(jsonString);

            var sb = new StringBuilder();

            var theaterList = new List<Theatre>();

            foreach (var theater in theaterTickets)
            {
                if (!IsValid(theater))
                {
                    sb.AppendLine("Invalid data!");
                    continue;
                }

                var currentTheater = new Theatre
                {
                    Name = theater.Name,
                    NumberOfHalls = theater.NumberOfHalls,
                    Director = theater.Director,
                };

                foreach (var ticket in theater.Tickets)
                {
                    if (!IsValid(ticket))
                    {
                        sb.AppendLine("Invalid data!");
                        continue;
                    }

                    var currentTicket = new Ticket
                    {
                        Price = ticket.Price,
                        RowNumber = ticket.RowNumber,
                        PlayId = ticket.PlayId
                    };

                    currentTheater.Tickets.Add(currentTicket);
                }

                context.Theatres.Add(currentTheater);
                context.SaveChanges();

                sb.AppendLine($"Successfully imported theatre {currentTheater.Name} with #{currentTheater.Tickets.Count()} tickets!");
            }

            return sb.ToString().TrimEnd();
        }


        private static bool IsValid(object obj)
        {
            var validator = new ValidationContext(obj);
            var validationRes = new List<ValidationResult>();

            var result = Validator.TryValidateObject(obj, validator, validationRes, true);
            return result;
        }
    }
}
