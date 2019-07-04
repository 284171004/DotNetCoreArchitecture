using DotNetCoreArchitecture.Domain;
using DotNetCoreArchitecture.Model;
using Microsoft.EntityFrameworkCore;

namespace DotNetCoreArchitecture.Database
{
    public static class ContextSeed
    {
        public static void Seed(this ModelBuilder builder)
        {
            builder.SeedUsers();
        }

        private static void SeedUsers(this ModelBuilder builder)
        {
            builder.Entity<UserEntity>(x =>
            {
                x.HasData(new
                {
                    UserId = 1L,
                    Roles = Roles.User | Roles.Admin,
                    Status = Status.Active
                });

                x.OwnsOne(y => y.FullName).HasData(new
                {
                    UserEntityUserId = 1L,
                    Name = "Administrator",
                    Surname = "Administrator"
                });

                x.OwnsOne(y => y.Email).HasData(new
                {
                    UserEntityUserId = 1L,
                    Address = "administrator@administrator.com"
                });
            });
        }
    }
}
