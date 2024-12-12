using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Movie.Api.Migrations
{
    /// <inheritdoc />
    public partial class DirectorData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Directors",
                columns: new[] { "Id", "DateOfBirth", "Name", "Nationality" },
                values: new object[,]
                {
                    { 1, new DateOnly(1970, 7, 30), "Christopher Nolan", "British-American" },
                    { 2, new DateOnly(1963, 3, 27), "Quentin Tarantino", "American" },
                    { 3, new DateOnly(1971, 5, 14), "Sophia Coppola", "American" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Directors",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Directors",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Directors",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
