using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DockerBlazorWASMTest.Api.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "WeatherForecasts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    TemperatureC = table.Column<int>(type: "integer", nullable: false),
                    Summary = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WeatherForecasts", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "WeatherForecasts",
                columns: new[] { "Id", "Date", "Summary", "TemperatureC" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 4, 28, 0, 0, 0, 0, DateTimeKind.Utc), "Scorching", 33 },
                    { 2, new DateTime(2024, 4, 29, 0, 0, 0, 0, DateTimeKind.Utc), "Cool", 6 },
                    { 3, new DateTime(2024, 4, 30, 0, 0, 0, 0, DateTimeKind.Utc), "Balmy", -15 },
                    { 4, new DateTime(2024, 5, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Chilly", 8 },
                    { 5, new DateTime(2024, 5, 2, 0, 0, 0, 0, DateTimeKind.Utc), "Bracing", -10 },
                    { 6, new DateTime(2024, 5, 3, 0, 0, 0, 0, DateTimeKind.Utc), "Scorching", 53 },
                    { 7, new DateTime(2024, 5, 4, 0, 0, 0, 0, DateTimeKind.Utc), "Freezing", 25 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WeatherForecasts");
        }
    }
}
