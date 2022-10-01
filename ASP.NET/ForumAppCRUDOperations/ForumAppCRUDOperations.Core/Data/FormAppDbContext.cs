using ForumAppCRUDOperations.Core.Configure;
using ForumAppCRUDOperations.Core.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace ForumAppCRUDOperations.Core.Data
{
    public class FormAppDbContext : DbContext
    {
        public FormAppDbContext(DbContextOptions options)
            : base(options)
        {

        }

        public DbSet<Post> Posts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Post>()
                .Property(e => e.IsDeleted)
                .HasDefaultValue(false);

            modelBuilder.ApplyConfiguration<Post>(new PostConfiguration());

            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
    }
}
