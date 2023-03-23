using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TrainingProject.Core.Migrations
{
    public partial class AddWeatherForecast : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Temperatures",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TemperatureC = table.Column<string>(nullable: true),
                    TemperatureF = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Temperatures", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WeatherForecasts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(nullable: false),
                    TemperatureId = table.Column<int>(nullable: true),
                    Summary = table.Column<string>(nullable: true),
                    Type = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WeatherForecasts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WeatherForecasts_Temperatures_TemperatureId",
                        column: x => x.TemperatureId,
                        principalTable: "Temperatures",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Temperatures",
                columns: new[] { "Id", "TemperatureC", "TemperatureF" },
                values: new object[,]
                {
                    { 1, "33", null },
                    { 2, "34", null },
                    { 3, "35", null },
                    { 4, "36", null },
                    { 5, "37", null }
                });

            migrationBuilder.InsertData(
                table: "WeatherForecasts",
                columns: new[] { "Id", "Date", "Summary", "TemperatureId", "Type" },
                values: new object[] { 2, new DateTime(2020, 2, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mild", null, "0" });

            migrationBuilder.InsertData(
                table: "WeatherForecasts",
                columns: new[] { "Id", "Date", "Summary", "TemperatureId", "Type" },
                values: new object[,]
                {
                    { 1, new DateTime(2020, 2, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cold", 1, "1" },
                    { 3, new DateTime(2020, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Warm", 3, "1" },
                    { 4, new DateTime(2020, 2, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Balmy", 4, "0" },
                    { 5, new DateTime(2020, 2, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "Hot", 5, "1" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_WeatherForecasts_TemperatureId",
                table: "WeatherForecasts",
                column: "TemperatureId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WeatherForecasts");

            migrationBuilder.DropTable(
                name: "Temperatures");
        }
    }
}
