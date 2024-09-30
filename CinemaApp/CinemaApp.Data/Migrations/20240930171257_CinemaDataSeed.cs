using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CinemaApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class CinemaDataSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: new Guid("121765d5-9cf3-4be6-9abd-28e68c23ea82"));

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: new Guid("4f877b32-8dee-4fc0-878b-7a39c302c7da"));

            migrationBuilder.InsertData(
                table: "Cinemas",
                columns: new[] { "Id", "Location", "Name" },
                values: new object[,]
                {
                    { new Guid("020105c3-8be5-4cb1-ada7-3c56b7eea587"), "Sofia", "Kino Arena" },
                    { new Guid("1187b14b-a184-4163-8c1a-c55c38f28f75"), "Sofia", "Cinema City" },
                    { new Guid("79340fc4-6a75-4957-8379-0dec012cf4f0"), "Plovdiv", "Kino Arena" },
                    { new Guid("c960b81e-1f9b-4036-963f-6f422a9705f2"), "Stara Zagora", "Mall Gallery" }
                });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "Description", "Director", "Duration", "Genre", "ReleaseDate", "Title" },
                values: new object[,]
                {
                    { new Guid("c2832c54-5e13-46e9-9c90-9a8ae7419cf2"), "After the Empire overpowers the Rebel Alliance, Luke Skywalker begins his Jedi training with Yoda. At the same time, Darth Vader and bounty hunter Boba Fett pursue his friends across the galaxy.", "Irvin Kershner", 124, "Action Epic", new DateTime(1980, 5, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Star Wars: Episode V - The Empire Strikes Back" },
                    { new Guid("f376e02c-06a7-4f47-9d28-cf327a0b2d98"), "The aging patriarch of an organized crime dynasty transfers control of his clandestine empire to his reluctant son.", "Francis Ford Coppola", 175, "Gangster", new DateTime(1972, 3, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Godfather" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Cinemas",
                keyColumn: "Id",
                keyValue: new Guid("020105c3-8be5-4cb1-ada7-3c56b7eea587"));

            migrationBuilder.DeleteData(
                table: "Cinemas",
                keyColumn: "Id",
                keyValue: new Guid("1187b14b-a184-4163-8c1a-c55c38f28f75"));

            migrationBuilder.DeleteData(
                table: "Cinemas",
                keyColumn: "Id",
                keyValue: new Guid("79340fc4-6a75-4957-8379-0dec012cf4f0"));

            migrationBuilder.DeleteData(
                table: "Cinemas",
                keyColumn: "Id",
                keyValue: new Guid("c960b81e-1f9b-4036-963f-6f422a9705f2"));

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: new Guid("c2832c54-5e13-46e9-9c90-9a8ae7419cf2"));

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: new Guid("f376e02c-06a7-4f47-9d28-cf327a0b2d98"));

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "Description", "Director", "Duration", "Genre", "ReleaseDate", "Title" },
                values: new object[,]
                {
                    { new Guid("121765d5-9cf3-4be6-9abd-28e68c23ea82"), "The aging patriarch of an organized crime dynasty transfers control of his clandestine empire to his reluctant son.", "Francis Ford Coppola", 175, "Gangster", new DateTime(1972, 3, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Godfather" },
                    { new Guid("4f877b32-8dee-4fc0-878b-7a39c302c7da"), "After the Empire overpowers the Rebel Alliance, Luke Skywalker begins his Jedi training with Yoda. At the same time, Darth Vader and bounty hunter Boba Fett pursue his friends across the galaxy.", "Irvin Kershner", 124, "Action Epic", new DateTime(1980, 5, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Star Wars: Episode V - The Empire Strikes Back" }
                });
        }
    }
}
