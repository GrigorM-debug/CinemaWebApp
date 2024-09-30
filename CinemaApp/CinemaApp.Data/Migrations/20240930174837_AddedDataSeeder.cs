using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CinemaApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddedDataSeeder : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.InsertData(
                table: "Cinemas",
                columns: new[] { "Id", "Location", "Name" },
                values: new object[,]
                {
                    { new Guid("4445db85-b94d-4ace-8ccd-b5b8c0d66fc9"), "Sofia", "Kino Arena" },
                    { new Guid("4f389851-d6e9-4cd8-9045-4a1bc3c2ecb3"), "Sofia", "Cinema City" },
                    { new Guid("6551ae12-4c18-4a8a-8d3e-69d46a900020"), "Plovdiv", "Kino Arena" },
                    { new Guid("afed7bf2-aa76-4a21-a820-65fdbbec7001"), "Stara Zagora", "Mall Gallery" }
                });

            migrationBuilder.InsertData(
                table: "CinemasMovies",
                columns: new[] { "CinemaId", "MovieId" },
                values: new object[,]
                {
                    { new Guid("4445db85-b94d-4ace-8ccd-b5b8c0d66fc9"), new Guid("c2832c54-5e13-46e9-9c90-9a8ae7419cf2") },
                    { new Guid("6551ae12-4c18-4a8a-8d3e-69d46a900020"), new Guid("c2832c54-5e13-46e9-9c90-9a8ae7419cf2") },
                    { new Guid("4f389851-d6e9-4cd8-9045-4a1bc3c2ecb3"), new Guid("f376e02c-06a7-4f47-9d28-cf327a0b2d98") },
                    { new Guid("afed7bf2-aa76-4a21-a820-65fdbbec7001"), new Guid("f376e02c-06a7-4f47-9d28-cf327a0b2d98") }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "CinemasMovies",
                keyColumns: new[] { "CinemaId", "MovieId" },
                keyValues: new object[] { new Guid("4445db85-b94d-4ace-8ccd-b5b8c0d66fc9"), new Guid("c2832c54-5e13-46e9-9c90-9a8ae7419cf2") });

            migrationBuilder.DeleteData(
                table: "CinemasMovies",
                keyColumns: new[] { "CinemaId", "MovieId" },
                keyValues: new object[] { new Guid("6551ae12-4c18-4a8a-8d3e-69d46a900020"), new Guid("c2832c54-5e13-46e9-9c90-9a8ae7419cf2") });

            migrationBuilder.DeleteData(
                table: "CinemasMovies",
                keyColumns: new[] { "CinemaId", "MovieId" },
                keyValues: new object[] { new Guid("4f389851-d6e9-4cd8-9045-4a1bc3c2ecb3"), new Guid("f376e02c-06a7-4f47-9d28-cf327a0b2d98") });

            migrationBuilder.DeleteData(
                table: "CinemasMovies",
                keyColumns: new[] { "CinemaId", "MovieId" },
                keyValues: new object[] { new Guid("afed7bf2-aa76-4a21-a820-65fdbbec7001"), new Guid("f376e02c-06a7-4f47-9d28-cf327a0b2d98") });

            migrationBuilder.DeleteData(
                table: "Cinemas",
                keyColumn: "Id",
                keyValue: new Guid("4445db85-b94d-4ace-8ccd-b5b8c0d66fc9"));

            migrationBuilder.DeleteData(
                table: "Cinemas",
                keyColumn: "Id",
                keyValue: new Guid("4f389851-d6e9-4cd8-9045-4a1bc3c2ecb3"));

            migrationBuilder.DeleteData(
                table: "Cinemas",
                keyColumn: "Id",
                keyValue: new Guid("6551ae12-4c18-4a8a-8d3e-69d46a900020"));

            migrationBuilder.DeleteData(
                table: "Cinemas",
                keyColumn: "Id",
                keyValue: new Guid("afed7bf2-aa76-4a21-a820-65fdbbec7001"));

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
        }
    }
}
