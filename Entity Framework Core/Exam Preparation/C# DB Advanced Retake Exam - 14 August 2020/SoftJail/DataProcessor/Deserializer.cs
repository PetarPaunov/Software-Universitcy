namespace SoftJail.DataProcessor
{

    using Data;
    using Newtonsoft.Json;
    using SoftJail.Data.Models;
    using SoftJail.Data.Models.Enums;
    using SoftJail.DataProcessor.ImportDto;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;

    public class Deserializer
    {
        public static string ImportDepartmentsCells(SoftJailDbContext context, string jsonString)
        {
            var deparmentCells = JsonConvert.DeserializeObject<DepartmentCellsModel[]>(jsonString);

            var sb = new StringBuilder();
            var departmentsList = new List<Department>();

            foreach (var departmentCell in deparmentCells)
            {
                if (!IsValid(departmentCell) || !departmentCell.Cells.All(IsValid) || !departmentCell.Cells.Any())
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }

                var department = new Department
                {
                    Name = departmentCell.Name,
                    Cells = departmentCell.Cells.Select(x => new Cell
                    {
                        CellNumber = x.CellNumber,
                        HasWindow = x.HasWindow,
                    })
                    .ToArray()
                };

                sb.AppendLine($"Imported {department.Name} with {department.Cells.Count} cells");
                departmentsList.Add(department);
            }

            context.Departments.AddRange(departmentsList);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportPrisonersMails(SoftJailDbContext context, string jsonString)
        {
            var prisonorsMails = JsonConvert.DeserializeObject<PrisonerMailInmportModel[]>(jsonString);


            var sb = new StringBuilder();
            var prisonersList = new List<Prisoner>();

            foreach (var prisonor in prisonorsMails)
            {
                if (!IsValid(prisonor)|| !prisonor.Mails.All(IsValid))
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }

                var incarcerationDate = DateTime
                    .ParseExact(prisonor.IncarcerationDate, "dd/MM/yyyy", CultureInfo.InvariantCulture);

                var isValidreliseDate = DateTime
                    .TryParseExact(prisonor.ReleaseDate, "dd/MM/yyyy", CultureInfo.InvariantCulture,
                    DateTimeStyles.None, out DateTime reliseDate);

                var curentPrisoner = new Prisoner
                {
                    FullName = prisonor.FullName,
                    Nickname = prisonor.Nickname,
                    Age = prisonor.Age,
                    IncarcerationDate = incarcerationDate,
                    ReleaseDate = isValidreliseDate ? (DateTime?)reliseDate : null,
                    Bail = prisonor.Bail,
                    CellId = prisonor.CellId,
                    Mails = prisonor.Mails.Select(x => new Mail
                    {
                        Description = x.Description,
                        Sender = x.Sender,
                        Address = x.Address,
                    })
                    .ToArray()
                };

                prisonersList.Add(curentPrisoner);
                sb.AppendLine($"Imported {curentPrisoner.FullName} {curentPrisoner.Age} years old");
            }

            context.Prisoners.AddRange(prisonersList);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportOfficersPrisoners(SoftJailDbContext context, string xmlString)
        {
            var xmlSerializer = new XmlSerializer(typeof(OficersPrisonersImportModel[]), new XmlRootAttribute("Officers"));

            var stringReader = new StringReader(xmlString);

            var officersDto = xmlSerializer.Deserialize(stringReader) as OficersPrisonersImportModel[];

            var sb = new StringBuilder();
            var officersList = new List<Officer>();

            foreach (var officer in officersDto)
            {
                if (!IsValid(officer))
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }

                var currentOfficer = new Officer
                {
                    FullName = officer.Name,
                    Salary = officer.Money,
                    Position = Enum.Parse<Position>(officer.Position),
                    Weapon = Enum.Parse<Weapon>(officer.Weapon),
                    DepartmentId = officer.DepartmentId,
                    OfficerPrisoners = officer.Prisoners.Select(x => new OfficerPrisoner
                    {
                        PrisonerId = x.Id,
                    })
                    .ToArray()
                };

                officersList.Add(currentOfficer);
                sb.AppendLine($"Imported {officer.Name} ({officer.Prisoners.Count()} prisoners)");
            }

            context.Officers.AddRange(officersList);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        private static bool IsValid(object obj)
        {
            var validationContext = new System.ComponentModel.DataAnnotations.ValidationContext(obj);
            var validationResult = new List<ValidationResult>();

            bool isValid = Validator.TryValidateObject(obj, validationContext, validationResult, true);
            return isValid;
        }
    }
}