using CinemaApp.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaApp.Data.Configurations
{
    public class CinemaMovieConfiguration : IEntityTypeConfiguration<CinemaMovie>
    {
        public void Configure(EntityTypeBuilder<CinemaMovie> builder)
        {
            builder
                .HasKey(cm => new { cm.MovieId, cm.CinemaId});


            builder
                .HasOne(cm => cm.Movie)
                .WithMany(m => m.CinemasMovies)
                .HasForeignKey(cm => cm.MovieId);

            builder
                .HasOne(cm => cm.Cinema)
                .WithMany(c => c.CinemasMovies)
                .HasForeignKey(cm => cm.CinemaId);
        }
    }
}
