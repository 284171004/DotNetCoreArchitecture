using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace DotNetCoreArchitecture.Database.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable("UsersLogs", "User");
            migrationBuilder.DropTable("Users", "User");
        }

        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema("User");

            migrationBuilder.CreateTable
            (
                "Users",
                table => new
                {
                    UserId = table.Column<long>().Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 100),
                    Surname = table.Column<string>(maxLength: 200),
                    Email = table.Column<string>(maxLength: 300),
                    Login = table.Column<string>(maxLength: 100),
                    Password = table.Column<string>(maxLength: 500),
                    Salt = table.Column<string>(maxLength: 500),
                    Roles = table.Column<int>(),
                    Status = table.Column<int>()
                },
                "User",
                table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                }
            );

            migrationBuilder.CreateTable
            (
                "UsersLogs",
                table => new
                {
                    UserLogId = table.Column<long>().Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<long>(),
                    LogType = table.Column<int>(),
                    DateTime = table.Column<DateTime>()
                },
                "User",
                table =>
                {
                    table.PrimaryKey("PK_UsersLogs", x => x.UserLogId);
                    table.ForeignKey("FK_UsersLogs_Users_UserId", x => x.UserId, "Users", "UserId", "User", onDelete: ReferentialAction.Cascade);
                }
            );

            migrationBuilder.InsertData
            (
                "Users",
                new[] { "UserId", "Roles", "Status", "Email", "Name", "Surname", "Login", "Password", "Salt" },
                new object[]
                {
                    1L,
                    3,
                    1,
                    "administrator@administrator.com",
                    "Administrator",
                    "Administrator",
                    "admin",
                    "O34uMN1Vho2IYcSM7nlXEqn57RZ8VEUsJwH++sFr0i3MSHJVx8J3PQGjhLR3s5i4l0XWUnCnymQ/EbRmzvLy8uMWREZu7vZI+BqebjAl5upYKMMQvlEcBeyLcRRTTBpYpv80m/YCZQmpig4XFVfIViLLZY/Kr5gBN5dkQf25rK8=",
                    "79005744-e69a-4b09-996b-08fe0b70cbb9"
                },
                "User"
            );

            migrationBuilder.CreateIndex("IX_Users_Email", "Users", "Email", "User", true);
            migrationBuilder.CreateIndex("IX_Users_Login", "Users", "Login", "User", true);
            migrationBuilder.CreateIndex("IX_UsersLogs_UserId", "UsersLogs", "UserId", "User");
        }
    }
}
