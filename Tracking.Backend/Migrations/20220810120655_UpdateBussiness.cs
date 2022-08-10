using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Tracking.Backend.Migrations
{
    public partial class UpdateBussiness : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "ActiveDate",
                table: "Device",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.CreateTable(
                name: "AssignRoute",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UnitId = table.Column<int>(nullable: false),
                    CarId = table.Column<int>(nullable: false),
                    DriverId = table.Column<int>(nullable: false),
                    RoutId = table.Column<int>(nullable: false),
                    TreasurerId = table.Column<int>(nullable: false),
                    AtmTechnicanId = table.Column<int>(nullable: true),
                    Guard = table.Column<string>(nullable: true),
                    BeginTime = table.Column<TimeSpan>(nullable: false),
                    EndTime = table.Column<TimeSpan>(nullable: false),
                    BeginDate = table.Column<DateTime>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: false),
                    Mon = table.Column<bool>(nullable: false),
                    Tue = table.Column<bool>(nullable: false),
                    Wed = table.Column<bool>(nullable: false),
                    Thu = table.Column<bool>(nullable: false),
                    Fri = table.Column<bool>(nullable: false),
                    Sat = table.Column<bool>(nullable: false),
                    Sun = table.Column<bool>(nullable: false),
                    IssueComand = table.Column<bool>(nullable: false),
                    senSMS = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssignRoute", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WarningLog",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AssignRouteId = table.Column<int>(nullable: false),
                    Type = table.Column<int>(nullable: false),
                    Message = table.Column<string>(nullable: true),
                    SendTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WarningLog", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WarrningStaff",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Image = table.Column<string>(nullable: true),
                    EmployeeCode = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Gender = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    RfidId = table.Column<int>(nullable: true),
                    UnitId = table.Column<int>(nullable: false),
                    OffJob = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WarrningStaff", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AssignRoute");

            migrationBuilder.DropTable(
                name: "WarningLog");

            migrationBuilder.DropTable(
                name: "WarrningStaff");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ActiveDate",
                table: "Device",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);
        }
    }
}
