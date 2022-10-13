using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TaskBoardApp.Core.Data.Configuration;
using TaskBoardApp.Core.Data.Models;

namespace TaskBoardApp.Core.Data
{
    public class TaskBoardAppDbContext : IdentityDbContext<ApplicationUser>
    {
        public TaskBoardAppDbContext(DbContextOptions<TaskBoardAppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Board> Boards { get; set; }
        public DbSet<Models.Task> Tasks { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Models.Task>()
                .HasOne(t => t.Board)
                .WithMany(b => b.Tasks)
                .HasForeignKey(t => t.BoardId)
                .OnDelete(DeleteBehavior.Restrict);

            //builder.ApplyConfiguration<ApplicationUser>(new UserConfiguration());
            //builder.ApplyConfiguration<Board>(new BoardConfiguration());
            //builder.ApplyConfiguration<Models.Task>(new TaskConfiguration());

            base.OnModelCreating(builder);
        }
    }
}