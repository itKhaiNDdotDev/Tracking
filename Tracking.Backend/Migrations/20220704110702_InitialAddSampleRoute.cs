using Microsoft.EntityFrameworkCore.Migrations;

namespace Tracking.Backend.Migrations
{
    public partial class InitialAddSampleRoute : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TransactionPoint_SampleRoutes_SampleRouteId",
                table: "TransactionPoint");

            migrationBuilder.DropIndex(
                name: "IX_TransactionPoint_SampleRouteId",
                table: "TransactionPoint");

            migrationBuilder.DropColumn(
                name: "SampleRouteId",
                table: "TransactionPoint");

            migrationBuilder.CreateTable(
                name: "TracePointForRoute",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StopPointId = table.Column<int>(nullable: true),
                    TravelTimeByMin = table.Column<int>(nullable: false),
                    SampleRouteId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TracePointForRoute", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TracePointForRoute_SampleRoutes_SampleRouteId",
                        column: x => x.SampleRouteId,
                        principalTable: "SampleRoutes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TracePointForRoute_TransactionPoint_StopPointId",
                        column: x => x.StopPointId,
                        principalTable: "TransactionPoint",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TracePointForRoute_SampleRouteId",
                table: "TracePointForRoute",
                column: "SampleRouteId");

            migrationBuilder.CreateIndex(
                name: "IX_TracePointForRoute_StopPointId",
                table: "TracePointForRoute",
                column: "StopPointId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TracePointForRoute");

            migrationBuilder.AddColumn<int>(
                name: "SampleRouteId",
                table: "TransactionPoint",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TransactionPoint_SampleRouteId",
                table: "TransactionPoint",
                column: "SampleRouteId");

            migrationBuilder.AddForeignKey(
                name: "FK_TransactionPoint_SampleRoutes_SampleRouteId",
                table: "TransactionPoint",
                column: "SampleRouteId",
                principalTable: "SampleRoutes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
