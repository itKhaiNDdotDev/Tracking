using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Tracking.Backend.Migrations
{
    public partial class AddUserContext : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RoutId",
                table: "AssignRoute");

            migrationBuilder.DropColumn(
                name: "senSMS",
                table: "AssignRoute");

            migrationBuilder.AddColumn<int>(
                name: "RouteId",
                table: "AssignRoute",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "sendSMS",
                table: "AssignRoute",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(nullable: true),
                    NormalizedUserName = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    NormalizedEmail = table.Column<string>(nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    fullname = table.Column<string>(nullable: true),
                    is_active = table.Column<bool>(nullable: false),
                    is_admin = table.Column<bool>(nullable: false),
                    create_date = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropColumn(
                name: "RouteId",
                table: "AssignRoute");

            migrationBuilder.DropColumn(
                name: "sendSMS",
                table: "AssignRoute");

            migrationBuilder.AddColumn<int>(
                name: "RoutId",
                table: "AssignRoute",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "senSMS",
                table: "AssignRoute",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
