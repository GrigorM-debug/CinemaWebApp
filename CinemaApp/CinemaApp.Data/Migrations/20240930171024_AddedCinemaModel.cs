using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CinemaApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddedCinemaModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: new Guid("2e4cab9b-56a4-4d52-8058-6cc9f503c32d"));

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: new Guid("3f659b18-6721-415e-878b-ddd3279167d5"));

            migrationBuilder.CreateTable(
                name: "Cinemas",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cinemas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CinemasMovies",
                columns: table => new
                {
                    CinemaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MovieId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CinemasMovies", x => new { x.MovieId, x.CinemaId });
                    table.ForeignKey(
                        name: "FK_CinemasMovies_Cinemas_CinemaId",
                        column: x => x.CinemaId,
                        principalTable: "Cinemas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CinemasMovies_Movies_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "Description", "Director", "Duration", "Genre", "ReleaseDate", "Title" },
                values: new object[,]
                {
                    { new Guid("121765d5-9cf3-4be6-9abd-28e68c23ea82"), "The aging patriarch of an organized crime dynasty transfers control of his clandestine empire to his reluctant son.", "Francis Ford Coppola", 175, "Gangster", new DateTime(1972, 3, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Godfather" },
                    { new Guid("4f877b32-8dee-4fc0-878b-7a39c302c7da"), "After the Empire overpowers the Rebel Alliance, Luke Skywalker begins his Jedi training with Yoda. At the same time, Darth Vader and bounty hunter Boba Fett pursue his friends across the galaxy.", "Irvin Kershner", 124, "Action Epic", new DateTime(1980, 5, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Star Wars: Episode V - The Empire Strikes Back" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CinemasMovies_CinemaId",
                table: "CinemasMovies",
                column: "CinemaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CinemasMovies");

            migrationBuilder.DropTable(
                name: "Cinemas");

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: new Guid("121765d5-9cf3-4be6-9abd-28e68c23ea82"));

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: new Guid("4f877b32-8dee-4fc0-878b-7a39c302c7da"));

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "Description", "Director", "Duration", "Genre", "ReleaseDate", "Title" },
                values: new object[,]
                {
                    { new Guid("2e4cab9b-56a4-4d52-8058-6cc9f503c32d"), "After the Empire overpowers the Rebel Alliance, Luke Skywalker begins his Jedi training with Yoda. At the same time, Darth Vader and bounty hunter Boba Fett pursue his friends across the galaxy.", "Irvin Kershner", 124, "Action Epic", new DateTime(1980, 5, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Star Wars: Episode V - The Empire Strikes Back" },
                    { new Guid("3f659b18-6721-415e-878b-ddd3279167d5"), "The aging patriarch of an organized crime dynasty transfers control of his clandestine empire to his reluctant son.", "Francis Ford Coppola", 175, "Gangster", new DateTime(1972, 3, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Godfather" }
                });
        }
    }
}
