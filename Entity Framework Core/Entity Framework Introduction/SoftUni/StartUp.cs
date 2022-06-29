using SoftUni.Data;
using SoftUni.Models;
using System;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.Globalization;

namespace SoftUni
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var db = new SoftUniContext();
            var result = RemoveTown(db);
            Console.WriteLine(result);
        }

        //15. Remove Town
        public static string RemoveTown(SoftUniContext context)
        {
            var town = context.Towns.FirstOrDefault(x => x.Name == "Seattle");

            var employees = context.Employees
                .Where(x => x.Address.Town.Name == "Seattle")
                .ToList();

            foreach (var emp in employees)
            {
                emp.AddressId = null;
            }

            var addresses = context.Addresses
                .Where(x => x.Town.Name == "Seattle")
                .ToList();

            foreach (var address in addresses)
            {
                context.Addresses.Remove(address);
            }

            context.Towns.Remove(town);

            context.SaveChanges();

            return $"{addresses.Count()} addresses in Seattle were deleted";
        }

        //14. Delete Project by Id
        public static string DeleteProjectById(SoftUniContext context)
        {
            var project = context.Projects
                .FirstOrDefault(x => x.ProjectId == 2);

            context.EmployeesProjects
                .Where(x => x.ProjectId == 2)
                .ToList()
                .ForEach(x => context.EmployeesProjects.Remove(x));

            context.Projects.Remove(project);

            context.SaveChanges();

            var projects = context.Projects
                .Select(x => x.Name)
                .ToList()
                .Take(10);

            StringBuilder sb = new StringBuilder();

            foreach (var proj in projects)
            {
                sb.AppendLine(proj);
            }

            return sb.ToString().TrimEnd();
        }

        //13. Find Employees by First Name Starting With Sa
        public static string GetEmployeesByFirstNameStartingWithSa(SoftUniContext context)
        {
            var employees = context.Employees
                .Where(x => x.FirstName.StartsWith("Sa"))
                .Select(x => new
                {
                    x.FirstName,
                    x.LastName,
                    x.JobTitle,
                    x.Salary
                })
                .OrderBy(x => x.FirstName)
                .ThenBy(x => x.LastName)
                .ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var employee in employees)
            {
                sb.AppendLine($"{employee.FirstName} {employee.LastName} - {employee.JobTitle} - (${employee.Salary:F2})");
            }

            return sb.ToString().TrimEnd();
        }

        //12. Increase Salaries
        public static string IncreaseSalaries(SoftUniContext context)
        {
            var employees = context.Employees
                .Where(x => x.Department.Name == "Engineering" || x.Department.Name == "Tool Design" || x.Department.Name == "Marketing" || x.Department.Name == "Information Services")
                .OrderBy(x => x.FirstName)
                .ThenBy(x => x.LastName)
                .ToList();

            foreach (var emplyoee in employees)
            {
                emplyoee.Salary *= 1.12m;
            }

            context.SaveChanges();

            StringBuilder sb = new StringBuilder();

            foreach (var employee in employees)
            {
                sb.AppendLine($"{employee.FirstName} {employee.LastName} (${employee.Salary:F2})");
            }

            return sb.ToString().TrimEnd();
        }

        //11. Find Latest 10 Projects
        public static string GetLatestProjects(SoftUniContext context)
        {
            var projects = context.Projects
                    .OrderByDescending(p => p.StartDate)
                    .Take(10)
                    .Select(p => new 
                    { 
                        p.Name,
                        p.Description,
                        p.StartDate 
                    })
                    .OrderBy(p => p.Name)
                    .ToList();

            StringBuilder sb = new StringBuilder();
            string dateFormat = "M/d/yyyy h:mm:ss tt";

            foreach (var project in projects)
            {
                sb.AppendLine(project.Name);
                sb.AppendLine(project.Description);
                sb.AppendLine(project.StartDate.ToString(dateFormat, CultureInfo.InvariantCulture));
            }

            return sb.ToString().TrimEnd();
        }

        //10. Departments with More Than 5 Employees
        public static string GetDepartmentsWithMoreThan5Employees(SoftUniContext context)
        {
            var deparments = context.Departments
                .Where(x => x.Employees.Count > 5)
                .OrderBy(x => x.Employees.Count)
                .ThenBy(x => x.Name)
                .Select(x => new
                {
                    x.Name,
                    x.Manager.FirstName,
                    x.Manager.LastName,
                    Employee = x.Employees.Select(x => new
                    {
                        x.FirstName,
                        x.LastName,
                        x.JobTitle
                    })
                    .OrderBy(x => x.FirstName)
                    .ThenBy(x => x.LastName)
                    .ToList()
                })
                .ToList();

            StringBuilder sb = new StringBuilder();


            foreach (var department in deparments)
            {
                sb.AppendLine($"{department.Name} - {department.FirstName} {department.LastName}");

                foreach (var emploee in department.Employee)
                {
                    sb.AppendLine($"{emploee.FirstName} {emploee.LastName} - {emploee.JobTitle}");
                }
            }

            return sb.ToString().TrimEnd();

        }

        //09. Employee 147
        public static string GetEmployee147(SoftUniContext context)
        {
            var emploee = context.Employees
                .Select(x => new Employee
                {
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    JobTitle = x.JobTitle,
                    EmployeeId = x.EmployeeId,
                    EmployeesProjects = x.EmployeesProjects.Select(x => new EmployeeProject
                    {
                        Project = x.Project
                    })
                    .OrderBy(x => x.Project.Name)
                    .ToList()
                })
                .FirstOrDefault(x => x.EmployeeId == 147);

            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"{emploee.FirstName} {emploee.LastName} - {emploee.JobTitle}");


            foreach (var project in emploee.EmployeesProjects)
            {
                sb.AppendLine(project.Project.Name);
            }

            return sb.ToString().TrimEnd();

        }

        //08. Addresses by Town
        public static string GetAddressesByTown(SoftUniContext context)
        {
            var addresses = context.Addresses
                .OrderByDescending(x => x.Employees.Count())
                .ThenBy(x => x.Town.Name)
                .ThenBy(x => x.AddressText)
                .Select(x => new
                {
                    x.AddressText,
                    x.Town.Name,
                    cout = x.Employees.Count()
                })
                .Take(10)
                .ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var address in addresses)
            {
                sb.AppendLine($"{address.AddressText}, {address.Name} - {address.cout} employees");
            }

            return sb.ToString().TrimEnd();

        }

        //07. Employees and Projects
        public static string GetEmployeesInPeriod(SoftUniContext context)
        {
            var employees = context.Employees
                .Include(x => x.EmployeesProjects)
                .ThenInclude(x => x.Project)
                .Where(x => x.EmployeesProjects.Any(p => p.Project.StartDate.Year >= 2001 &&
                                                         p.Project.StartDate.Year <= 2003))
                .Select(x => new
                {
                    x.FirstName,
                    x.LastName,
                    managerFirstName = x.Manager.FirstName,
                    managerLastName = x.Manager.LastName,
                    employeeProject = x.EmployeesProjects.Select(x => new
                    {
                        x.Project.Name,
                        x.Project.StartDate,
                        x.Project.EndDate
                    })

                })
                .Take(10)
                .ToList();

            StringBuilder sb = new StringBuilder();
            string dateFormat = "M/d/yyyy h:mm:ss tt";

            foreach (var employee in employees)
            {
                sb.AppendLine($"{employee.FirstName} {employee.LastName} - Manager: {employee.managerFirstName} {employee.managerLastName}");

                foreach (var projects in employee.employeeProject)
                {
                    var endDate = projects.EndDate.HasValue ? projects.EndDate.Value.ToString(dateFormat, CultureInfo.InvariantCulture) : "not finished";

                    sb.AppendLine($"--{projects.Name} - {projects.StartDate.ToString(dateFormat, CultureInfo.InvariantCulture)} - {endDate}");
                }
            }

            return sb.ToString().TrimEnd();
        }

        //06. Adding a New Address and Updating Employee
        public static string AddNewAddressToEmployee(SoftUniContext context)
        {
            var newAddress = new Address
            { 
                AddressText = "Vitoshka 15", 
                TownId = 4 
            };

            context.Addresses.Add(newAddress);
            context.SaveChanges();

            var employee = context.Employees
                .FirstOrDefault(x => x.LastName == "Nakov");

            employee.AddressId = newAddress.AddressId;

            context.SaveChanges();

            var addresses = context.Employees
                .Select(x => new
                {
                    x.Address.AddressText,
                    x.Address.AddressId
                })
                .OrderByDescending(x => x.AddressId)
                .Take(10)
                .ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var address in addresses)
            {
                sb.AppendLine(address.AddressText);
            }

            return sb.ToString().TrimEnd();

        }

        //05. Employees from Research and Development
        public static string GetEmployeesFromResearchAndDevelopment(SoftUniContext context)
        {
            var emploees = context.Employees
                .Select(x => new
                {
                    x.FirstName,
                    x.LastName,
                    x.Department,
                    x.Department.Name,
                    x.Salary
                })
                .Where(x => x.Department.Name == "Research and Development")
                .OrderBy(x => x.Salary)
                .ThenByDescending(x => x.FirstName)
                .ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var emploee in emploees)
            {
                sb.AppendLine($"{emploee.FirstName} {emploee.LastName} from {emploee.Department.Name} - ${emploee.Salary:F2}");
            }

            return sb.ToString().TrimEnd();
        }

        //04. Employees with Salary Over 50 000
        public static string GetEmployeesWithSalaryOver50000(SoftUniContext context)
        {
            var employees = context.Employees
                .Select(x => new
                {
                    x.FirstName,
                    x.Salary
                })
                .Where(x => x.Salary > 50_000)
                .OrderBy(x => x.FirstName)
                .ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var emploee in employees)
            {
                sb.AppendLine($"{emploee.FirstName} - {emploee.Salary:F2}");
            }

            return sb.ToString().TrimEnd();
                       
        }


        //03. Employees Full Information
        public static string GetEmployeesFullInformation(SoftUniContext context)
        {
            var emploees = context.Employees
                .Select(x => new
                {
                    x.EmployeeId,
                    x.FirstName,
                    x.LastName,
                    x.MiddleName,
                    x.JobTitle,
                    x.Salary
                })
                .OrderBy(x => x.EmployeeId).ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var emploee in emploees)
            {
                sb.AppendLine($"{emploee.FirstName} {emploee.LastName} {emploee.MiddleName} {emploee.JobTitle} {emploee.Salary:F2}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
