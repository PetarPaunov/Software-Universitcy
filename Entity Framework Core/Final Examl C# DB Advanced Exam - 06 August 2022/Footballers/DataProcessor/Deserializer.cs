namespace Footballers.DataProcessor
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using Data;
    using Footballers.Data.Models;
    using Footballers.Data.Models.Enums;
    using Footballers.DataProcessor.ImportDto;
    using Newtonsoft.Json;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfullyImportedCoach
            = "Successfully imported coach - {0} with {1} footballers.";

        private const string SuccessfullyImportedTeam
            = "Successfully imported team - {0} with {1} footballers.";

        public static string ImportCoaches(FootballersContext context, string xmlString)
        {
            var xmlSerializer = new XmlSerializer(typeof(ImportChoachesModel[]), new XmlRootAttribute("Coaches"));

            var textReader = new StringReader(xmlString);

            var coachDto = xmlSerializer.Deserialize(textReader) as ImportChoachesModel[];

            var sb = new StringBuilder();

            foreach (var coach in coachDto)
            {
                if (!IsValid(coach))
                {
                    sb.AppendLine("Invalid data!");
                    continue;
                }

                var currentCoach = new Coach
                {
                    Name = coach.Name,
                    Nationality = coach.Nationality
                };
                context.Coaches.Add(currentCoach);
                context.SaveChanges();

                foreach (var footballer in coach.Footballers)
                {
                    var footbalerStartDate = DateTime.TryParseExact(footballer.ContractStartDate, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None , out var start);
                    var footbalerEndDate = DateTime.TryParseExact(footballer.ContractEndDate, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out var end);

                    if (!IsValid(footballer) || !footbalerStartDate || !footbalerEndDate || start > end)
                    {
                        sb.AppendLine("Invalid data!");
                        continue;
                    }

                    var bestSkillType = Enum.Parse<BestSkillType>(Enum.GetName(typeof(BestSkillType), footballer.BestSkillType));
                    var positionType = Enum.Parse<PositionType>(Enum.GetName(typeof(PositionType), footballer.PositionType));

                    var currentFootballer = new Footballer
                    {
                        Name = footballer.Name,
                        ContractStartDate = start,
                        ContractEndDate = end,
                        BestSkillType = bestSkillType,
                        PositionType = positionType,
                        CoachId = currentCoach.Id,
                    };

                    context.Footballers.Add(currentFootballer);
                    context.SaveChanges();

                }


                sb.AppendLine($"Successfully imported coach - {currentCoach.Name} with {currentCoach.Footballers.Count()} footballers.");
            }
            context.SaveChanges();


            return sb.ToString().TrimEnd();
        }
        public static string ImportTeams(FootballersContext context, string jsonString)
        {
            var teamsModels = JsonConvert.DeserializeObject<ImportTeamsModel[]>(jsonString);

            var sb = new StringBuilder();

            foreach (var team in teamsModels)
            {
                if (!IsValid(team) || team.Trophies <= 0)
                {
                    sb.AppendLine("Invalid data!");
                    continue;
                }

                var currentTeam = new Team
                {
                    Name = team.Name,
                    Nationality = team.Nationality,
                    Trophies = team.Trophies,

                };
                context.Teams.Add(currentTeam);
                context.SaveChanges();

                var districtFootIds = team.Footballers.Distinct();

                var count = 0;

                foreach (var footId in districtFootIds)
                {
                    var footballer = context.Footballers.FirstOrDefault(x => x.Id == footId);

                    if (footballer == null)
                    {
                        sb.AppendLine("Invalid data!");
                        continue;
                    }

                    var footTeam = new TeamFootballer
                    {
                        Footballer = footballer,
                        Team = currentTeam
                    };

                    context.TeamsFootballers.Add(footTeam);
                    context.SaveChanges();

                    count++;
                }



                sb.AppendLine($"Successfully imported team - {currentTeam.Name} with {currentTeam.TeamsFootballers.Count()} footballers.");
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
