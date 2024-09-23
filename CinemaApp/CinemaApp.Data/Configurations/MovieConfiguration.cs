using Azure.Core;
using CinemaApp.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static CinemaApp.Common.MovieValidationConstants;

namespace CinemaApp.Data.Configurations
{
    public class MovieConfiguration : IEntityTypeConfiguration<Movie>
    {
        public void Configure(EntityTypeBuilder<Movie> builder)
        {
            //Fluent API
            builder
                .HasKey(m => m.Id);

            builder
                .Property(m => m.Title)
                .IsRequired()
                .HasMaxLength(TitleMaxLenght);

            builder.Property(m => m.Genre)
                .IsRequired()
                .HasMaxLength(GenreMaxLenght);

            builder
                .Property(m => m.ReleaseDate)
                .IsRequired();

            builder
                .Property(m => m.Director)
                .IsRequired()
                .HasMaxLength(DirectorMaxLenght);

            builder
                .Property(m => m.Duration)
                .IsRequired();

            builder
                .Property(m => m.Description)
                .IsRequired()
                .HasMaxLength(DescriptionMaxLenght);

            builder.HasData(MovieDataSeed());
        }

        private List<Movie> MovieDataSeed()
        {
            List<Movie> movies = new List<Movie>()
            {
                new Movie()
                {
                    Title = "Star Wars: Episode V - The Empire Strikes Back",
                    Genre = "Action Epic",
                    ReleaseDate = new DateTime(1980, 05, 06),
                    Director = "Irvin Kershner",
                    Duration = 124,
                    Description = "After the Empire overpowers the Rebel Alliance, Luke Skywalker begins his Jedi training with Yoda. At the same time, Darth Vader and bounty hunter Boba Fett pursue his friends across the galaxy."
                },

                new Movie()
                {
                    Title = "The Godfather",
                    Genre = "Gangster",
                    ReleaseDate = new DateTime(1972, 03, 14),
                    Director = "Francis Ford Coppola",
                    Duration = 175,
                    Description = "The aging patriarch of an organized crime dynasty transfers control of his clandestine empire to his reluctant son."
                }
            };

            return movies;
        }
    }
}
