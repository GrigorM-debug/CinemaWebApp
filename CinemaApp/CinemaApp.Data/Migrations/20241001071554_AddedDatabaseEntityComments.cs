using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CinemaApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddedDatabaseEntityComments : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CinemasMovies_Cinemas_CinemaId",
                table: "CinemasMovies");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Cinemas",
                table: "Cinemas");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Movies",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                comment: "The title of the movie. Must be at least the minimum length specified.",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<DateTime>(
                name: "ReleaseDate",
                table: "Movies",
                type: "datetime2",
                nullable: false,
                comment: "The release date of the movie.",
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<string>(
                name: "Genre",
                table: "Movies",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                comment: "The genre of the movie. Must be at least the minimum length specified.",
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldMaxLength: 30);

            migrationBuilder.AlterColumn<int>(
                name: "Duration",
                table: "Movies",
                type: "int",
                nullable: false,
                comment: "The duration of the movie in minutes.",
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Director",
                table: "Movies",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                comment: "The director of the movie. Must be at least the minimum length specified.",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Movies",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                comment: "A brief description of the movie. Must be at least the minimum length specified.",
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Cinemas",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                comment: "The name of the cinema. Must be at least the minimum length specified.",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Location",
                table: "Cinemas",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                comment: "The location of the cinema. Must be at least the minimum length specified.",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Cinema_Id",
                table: "Cinemas",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Cinema_CinemaMovie_CinemaId",
                table: "CinemasMovies",
                column: "CinemaId",
                principalTable: "Cinemas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cinema_CinemaMovie_CinemaId",
                table: "CinemasMovies");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Cinema_Id",
                table: "Cinemas");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Movies",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldComment: "The title of the movie. Must be at least the minimum length specified.");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ReleaseDate",
                table: "Movies",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldComment: "The release date of the movie.");

            migrationBuilder.AlterColumn<string>(
                name: "Genre",
                table: "Movies",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldMaxLength: 30,
                oldComment: "The genre of the movie. Must be at least the minimum length specified.");

            migrationBuilder.AlterColumn<int>(
                name: "Duration",
                table: "Movies",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldComment: "The duration of the movie in minutes.");

            migrationBuilder.AlterColumn<string>(
                name: "Director",
                table: "Movies",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldComment: "The director of the movie. Must be at least the minimum length specified.");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Movies",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500,
                oldComment: "A brief description of the movie. Must be at least the minimum length specified.");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Cinemas",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldComment: "The name of the cinema. Must be at least the minimum length specified.");

            migrationBuilder.AlterColumn<string>(
                name: "Location",
                table: "Cinemas",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldComment: "The location of the cinema. Must be at least the minimum length specified.");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Cinemas",
                table: "Cinemas",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CinemasMovies_Cinemas_CinemaId",
                table: "CinemasMovies",
                column: "CinemaId",
                principalTable: "Cinemas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
