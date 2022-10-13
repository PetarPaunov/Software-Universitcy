using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskBoardApp.Core.Data.Models;

namespace TaskBoardApp.Core.Data.Configuration
{
    public class UserConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            var user = SeedUser();

            builder.HasData(user);
        }

        private ApplicationUser SeedUser()
        {
            var passwordHesher = new PasswordHasher<ApplicationUser>();

            var user = new ApplicationUser()
            {
                UserName = "User",
                NormalizedUserName = "USER",
                Email = "test@abv.bg",
                NormalizedEmail = "TEST@ABV.BG",
                FirstName = "Guest",
                LastName = "User"
            };

            user.PasswordHash = passwordHesher.HashPassword(user, "123");

            return user;
        }
    }
}
