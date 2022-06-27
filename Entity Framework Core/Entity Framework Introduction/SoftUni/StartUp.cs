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
            var result = GetEmployeesInPeriod(db);
            Console.WriteLine(result);
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
