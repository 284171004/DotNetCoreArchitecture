using DotNetCoreArchitecture.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DotNetCoreArchitecture.Database
{
    public sealed class UserEntityConfiguration : IEntityTypeConfiguration<UserEntity>
    {
        public void Configure(EntityTypeBuilder<UserEntity> builder)
        {
            builder.ToTable("Users", "User");

            builder.HasKey(x => x.UserId);

            builder.Property(x => x.UserId).IsRequired().ValueGeneratedOnAdd();
            builder.Property(x => x.Roles).IsRequired();
            builder.Property(x => x.Status).IsRequired();

            builder.OwnsOne(x => x.FullName, y =>
            {
                y.Property(x => x.Name).HasColumnName(nameof(UserEntity.FullName.Name)).IsRequired().HasMaxLength(100);
                y.Property(x => x.Surname).HasColumnName(nameof(UserEntity.FullName.Surname)).IsRequired().HasMaxLength(200);
            });

            builder.OwnsOne(x => x.Email, y =>
            {
                y.Property(x => x.Address).HasColumnName(nameof(UserEntity.Email)).IsRequired().HasMaxLength(300);
                y.HasIndex(x => x.Address).IsUnique();
            });

            builder.OwnsOne(x => x.SignIn, y =>
            {
                y.Property(x => x.Login).HasColumnName(nameof(UserEntity.SignIn.Login)).IsRequired().HasMaxLength(100);
                y.Property(x => x.Password).HasColumnName(nameof(UserEntity.SignIn.Password)).IsRequired().HasMaxLength(500);
                y.Property(x => x.Salt).HasColumnName(nameof(UserEntity.SignIn.Salt)).IsRequired().HasMaxLength(500);
                y.HasIndex(x => x.Login).IsUnique();
            });

            builder.HasMany(x => x.UsersLogs).WithOne(x => x.User).HasForeignKey(x => x.UserId);
        }
    }
}
