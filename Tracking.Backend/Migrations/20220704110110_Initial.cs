using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Tracking.Backend.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AtmTechnican",
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
                    table.PrimaryKey("PK_AtmTechnican", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Car",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LicensePlate = table.Column<string>(nullable: true),
                    Type = table.Column<string>(nullable: true),
                    DeviceId = table.Column<int>(nullable: false),
                    UnitId = table.Column<int>(nullable: false),
                    DriverId = table.Column<int>(nullable: false),
                    NumberCamera = table.Column<int>(nullable: false),
                    FirstCam = table.Column<string>(nullable: true),
                    FirstCamRotation = table.Column<int>(nullable: false),
                    SecondCamRotation = table.Column<int>(nullable: false),
                    FuelType = table.Column<string>(nullable: true),
                    Fuel = table.Column<float>(nullable: true),
                    Uom = table.Column<string>(nullable: true),
                    LimitedSpeed = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Car", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Device",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DeviceCode = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    MobileCarrier = table.Column<string>(nullable: true),
                    ActiveDate = table.Column<DateTime>(nullable: false),
                    UnitId = table.Column<int>(nullable: false),
                    Imei = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    AllowUpdate = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Device", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Driver",
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
                    table.PrimaryKey("PK_Driver", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ManageUnit",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ManageUnit", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Rfid",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CardNumber = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Type = table.Column<string>(nullable: true),
                    ActiveDate = table.Column<DateTime>(nullable: true),
                    UnitId = table.Column<int>(nullable: false),
                    Status = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rfid", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SampleRoutes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RouteCode = table.Column<string>(nullable: true),
                    UnitId = table.Column<int>(nullable: false),
                    RouteType = table.Column<int>(nullable: false),
                    BeginTime = table.Column<TimeSpan>(nullable: false),
                    OverTimeAllowed = table.Column<int>(nullable: false),
                    ToleranceAllowed = table.Column<int>(nullable: false),
                    Distance = table.Column<int>(nullable: false),
                    ArrivalTime = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SampleRoutes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Treasurer",
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
                    Unit = table.Column<string>(nullable: true),
                    OffJob = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Treasurer", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TransactionPoint",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PointCode = table.Column<string>(nullable: true),
                    PointName = table.Column<string>(nullable: true),
                    PointType = table.Column<int>(nullable: false),
                    UnitId = table.Column<int>(nullable: false),
                    Address = table.Column<string>(nullable: true),
                    Longtitude = table.Column<float>(nullable: false),
                    Latitude = table.Column<float>(nullable: false),
                    Contact = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    Fax = table.Column<string>(nullable: true),
                    Branch = table.Column<string>(nullable: true),
                    SampleRouteId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransactionPoint", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TransactionPoint_SampleRoutes_SampleRouteId",
                        column: x => x.SampleRouteId,
                        principalTable: "SampleRoutes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TransactionPoint_SampleRouteId",
                table: "TransactionPoint",
                column: "SampleRouteId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AtmTechnican");

            migrationBuilder.DropTable(
                name: "Car");

            migrationBuilder.DropTable(
                name: "Device");

            migrationBuilder.DropTable(
                name: "Driver");

            migrationBuilder.DropTable(
                name: "ManageUnit");

            migrationBuilder.DropTable(
                name: "Rfid");

            migrationBuilder.DropTable(
                name: "TransactionPoint");

            migrationBuilder.DropTable(
                name: "Treasurer");

            migrationBuilder.DropTable(
                name: "SampleRoutes");
        }
    }
}
