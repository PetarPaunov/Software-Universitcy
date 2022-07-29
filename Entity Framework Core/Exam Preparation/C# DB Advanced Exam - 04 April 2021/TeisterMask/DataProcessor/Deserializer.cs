namespace TeisterMask.DataProcessor
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
    using Newtonsoft.Json;
    using TeisterMask.Data.Models;
    using TeisterMask.Data.Models.Enums;
    using TeisterMask.DataProcessor.ImportDto;
    using ValidationContext = System.ComponentModel.DataAnnotations.ValidationContext;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfullyImportedProject
            = "Successfully imported project - {0} with {1} tasks.";

        private const string SuccessfullyImportedEmployee
            = "Successfully imported employee - {0} with {1} tasks.";

        public static string ImportProjects(TeisterMaskContext context, string xmlString)
        {
            var xmlSerializer = new XmlSerializer(typeof(ImportProjectsModel[]), new XmlRootAttribute("Projects"));

            var textReader = new StringReader(xmlString);

            var projectsDto = xmlSerializer.Deserialize(textReader) as ImportProjectsModel[];

            var sb = new StringBuilder();

            foreach (var project in projectsDto)
            {
                if (!IsValid(project))
                {
                    sb.AppendLine("Invalid data!");
                    continue;
                }

                var projectOpenDate = DateTime
                    .ParseExact(project.OpenDate, "dd/MM/yyyy", CultureInfo.InvariantCulture);

                var projectDueDate = DateTime
                    .TryParseExact(project.DueDate, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime dateNull);

                var currentProject = new Project();

                if (!projectDueDate)
                {
                    currentProject = new Project
                    {
                        Name = project.Name,
                        OpenDate = projectOpenDate,
                        DueDate = null,
                    };
                }
                else
                {
                    currentProject = new Project
                    {
                        Name = project.Name,
                        OpenDate = projectOpenDate,
                        DueDate = dateNull,
                    };
                }

                foreach (var task in project.Tasks)
                {
                    if (!IsValid(task))
                    {
                        sb.AppendLine("Invalid data!");
                        continue;
                    }

                    var taskOpenDate = DateTime
                        .TryParseExact
                        (task.OpenDate, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out var taskOpenDateNull);

                    var taskDueDate = DateTime
                        .TryParseExact
                        (task.DueDate, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out var taskDueDateNull);

                    var openDateCompare = DateTime.Compare(taskOpenDateNull, projectOpenDate);
                    var dueDateCompare = DateTime.Compare(taskDueDateNull, dateNull);

                    if (!taskOpenDate || !taskDueDate
                         || openDateCompare < 0 || (dueDateCompare > 0 && currentProject.DueDate != null))
                    {
                        sb.AppendLine("Invalid data!");
                        continue;
                    }

                    var currentTask = new Task
                    {
                        Name = task.Name,
                        OpenDate = taskOpenDateNull,
                        DueDate = taskDueDateNull,
                        ExecutionType = Enum.Parse<ExecutionType>(task.ExecutionType),
                        LabelType = Enum.Parse<LabelType>(task.LabelType)
                    };

                    currentProject.Tasks.Add(currentTask);
                }

                context.Projects.Add(currentProject);
                context.SaveChanges();

                sb.AppendLine($"Successfully imported project - {currentProject.Name} with {currentProject.Tasks.Count()} tasks.");
            }


            return sb.ToString().TrimEnd();
        }

        public static string ImportEmployees(TeisterMaskContext context, string jsonString)
        {
            var emploees = JsonConvert.DeserializeObject<ImportEmploeesModel[]>(jsonString);

            var sb = new StringBuilder();

            var tasksId = context.Tasks.Select(x => x.Id);

            foreach (var emploee in emploees)
            {
                if (!IsValid(emploee))
                {
                    sb.AppendLine("Invalid data!");
                    continue;
                }

                var currentEmploee = new Employee
                {
                    Username = emploee.Username,
                    Email = emploee.Email,
                    Phone = emploee.Phone,
                };

                var uniqueTasks = emploee.Tasks.Distinct();

                foreach (var task in uniqueTasks)
                {
                    if (!tasksId.Contains(task))
                    {
                        sb.AppendLine("Invalid data!");
                        continue;
                    }

                    var currentTask = context.Tasks.FirstOrDefault(x => x.Id == task);

                    currentEmploee.EmployeesTasks.Add(new EmployeeTask
                    {
                        Task = currentTask
                    });
                }

                context.Employees.Add(currentEmploee);
                context.SaveChanges();

                sb.AppendLine($"Successfully imported employee - {currentEmploee.Username} with {currentEmploee.EmployeesTasks.Count()} tasks.");
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