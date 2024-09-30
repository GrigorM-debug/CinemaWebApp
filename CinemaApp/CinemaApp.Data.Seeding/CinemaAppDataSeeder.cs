﻿using CinemaApp.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace CinemaApp.Data.Seeding
{
    public static class CinemaAppDataSeeder
    {
        public static void SeedCinemas(ModelBuilder modelBuilder)
        {
            var cinemas = new List<Cinema>
            {
                new Cinema { Id = Guid.Parse("4445db85-b94d-4ace-8ccd-b5b8c0d66fc9"), Name = "Kino Arena", Location = "Sofia" },
                new Cinema { Id = Guid.Parse("4f389851-d6e9-4cd8-9045-4a1bc3c2ecb3"), Name = "Cinema City", Location = "Sofia" },
                new Cinema { Id = Guid.Parse("6551ae12-4c18-4a8a-8d3e-69d46a900020"), Name = "Kino Arena", Location = "Plovdiv" },
                new Cinema { Id = Guid.Parse("afed7bf2-aa76-4a21-a820-65fdbbec7001"), Name = "Mall Gallery", Location = "Stara Zagora" }
            };

            modelBuilder.Entity<Cinema>().HasData(cinemas);
        }

        public static void SeedMovies(ModelBuilder modelBuilder)
        {
            var movies = new List<Movie>
            {
                new Movie { Id = Guid.Parse("C2832C54-5E13-46E9-9C90-9A8AE7419CF2"), Title = "Star Wars: Episode V - The Empire Strikes Back", Genre = "Action Epic", ReleaseDate = new DateTime(1980, 5, 6), Director = "Irvin Kershner", Duration = 124, Description = "After the Empire overpowers the Rebel Alliance, Luke Skywalker begins his Jedi training with Yoda. At the same time, Darth Vader and bounty hunter Boba Fett pursue his friends across the galaxy." },
                new Movie { Id = Guid.Parse("F376E02C-06A7-4F47-9D28-CF327A0B2D98"), Title = "The Godfather", Genre = "Gangster", ReleaseDate = new DateTime(1972, 3, 14), Director = "Francis Ford Coppola", Duration = 175, Description = "The aging patriarch of an organized crime dynasty transfers control of his clandestine empire to his reluctant son." }
            };

            modelBuilder.Entity<Movie>().HasData(movies);
        }

        public static void SeedCinemaMovies(ModelBuilder modelBuilder)
        {
            var cinemaMovies = new List<CinemaMovie>
            {
                new CinemaMovie { CinemaId = Guid.Parse("4445db85-b94d-4ace-8ccd-b5b8c0d66fc9"), MovieId = Guid.Parse("C2832C54-5E13-46E9-9C90-9A8AE7419CF2") },  // Kino Arena, Sofia - Star Wars
                new CinemaMovie { CinemaId = Guid.Parse("4f389851-d6e9-4cd8-9045-4a1bc3c2ecb3"), MovieId = Guid.Parse("F376E02C-06A7-4F47-9D28-CF327A0B2D98") },  // Cinema City, Sofia - The Godfather
                new CinemaMovie { CinemaId = Guid.Parse("6551ae12-4c18-4a8a-8d3e-69d46a900020"), MovieId = Guid.Parse("C2832C54-5E13-46E9-9C90-9A8AE7419CF2") },  // Kino Arena, Plovdiv - Star Wars
                new CinemaMovie { CinemaId = Guid.Parse("afed7bf2-aa76-4a21-a820-65fdbbec7001"), MovieId = Guid.Parse("F376E02C-06A7-4F47-9D28-CF327A0B2D98") }   // Mall Gallery, Stara Zagora - The Godfather
            };

            modelBuilder.Entity<CinemaMovie>().HasData(cinemaMovies);
        }
    }
}
