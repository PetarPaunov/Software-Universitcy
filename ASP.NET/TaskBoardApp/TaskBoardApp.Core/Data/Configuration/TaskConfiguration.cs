using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskBoardApp.Core.Data.Models;

namespace TaskBoardApp.Core.Data.Configuration
{
    public class TaskConfiguration : IEntityTypeConfiguration<Models.Task>
    {
        public void Configure(EntityTypeBuilder<Models.Task> builder)
        {
            var tasks = SeedTasks();

            builder.HasData(tasks);
        }

        private List<Models.Task> SeedTasks()
        {
            return new List<Models.Task>()
            {
                new Models.Task()
                {
                    Id = 1,
                    Title = "Prepare for ASP.NET fundamentals Exam",
                    Description = "Lern using ASP.NET Core identity",
                    CreatedOn = DateTime.Now.AddMonths(-1),
                    OwnerId = "db69cbba-e2ba-4889-a362-eb04a8c40d34",
                    BoardId = 1
                },
                new Models.Task()
                {
                    Id = 2,
                    Title = "Improve EF Core skills",
                    Description = "Lern using EF Core and MSSQL",
                    CreatedOn = DateTime.Now.AddMonths(-1),
                    OwnerId = "db69cbba-e2ba-4889-a362-eb04a8c40d34",
                    BoardId = 3
                },
                new Models.Task()
                {
                    Id = 3,
                    Title = "Improve ASP.NET Core skills",
                    Description = "Lern using ASP.NET Core Identity",
                    CreatedOn = DateTime.Now.AddMonths(-1),
                    OwnerId = "db69cbba-e2ba-4889-a362-eb04a8c40d34",
                    BoardId = 2
                },
                new Models.Task()
                {
                    Id = 4,
                    Title = "Prepere for finel project",
                    Description = "Resurching",
                    CreatedOn = DateTime.Now.AddMonths(-1),
                    OwnerId = "db69cbba-e2ba-4889-a362-eb04a8c40d34",
                    BoardId = 3
                }
            };
        }
    }
}
