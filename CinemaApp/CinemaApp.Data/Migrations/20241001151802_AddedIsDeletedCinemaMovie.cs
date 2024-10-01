using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CinemaApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddedIsDeletedCinemaMovie : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "CinemasMovies",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "CinemasMovies",
                keyColumns: new[] { "CinemaId", "MovieId" },
                keyValues: new object[] { new Guid("4445db85-b94d-4ace-8ccd-b5b8c0d66fc9"), new Guid("c2832c54-5e13-46e9-9c90-9a8ae7419cf2") },
                columns: new[] { "IsDeleted" },
                values: new object[] { false });

            migrationBuilder.UpdateData(
                table: "CinemasMovies",
                keyColumns: new[] { "CinemaId", "MovieId" },
                keyValues: new object[] { new Guid("6551ae12-4c18-4a8a-8d3e-69d46a900020"), new Guid("c2832c54-5e13-46e9-9c90-9a8ae7419cf2") },
                columns: new[] { "IsDeleted" },
                values: new object[] { false });

            migrationBuilder.UpdateData(
                table: "CinemasMovies",
                keyColumns: new[] { "CinemaId", "MovieId" },
                keyValues: new object[] { new Guid("4f389851-d6e9-4cd8-9045-4a1bc3c2ecb3"), new Guid("f376e02c-06a7-4f47-9d28-cf327a0b2d98") },
                columns: new[] { "IsDeleted" },
                values: new object[] { false });

            migrationBuilder.UpdateData(
                table: "CinemasMovies",
                keyColumns: new[] { "CinemaId", "MovieId" },
                keyValues: new object[] { new Guid("afed7bf2-aa76-4a21-a820-65fdbbec7001"), new Guid("f376e02c-06a7-4f47-9d28-cf327a0b2d98") },
                columns: new[] { "IsDeleted" },
                values: new object[] { false });

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "CinemasMovies");
        }
    }
}
