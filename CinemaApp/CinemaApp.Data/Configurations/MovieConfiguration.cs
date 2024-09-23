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
        }
    }
}
