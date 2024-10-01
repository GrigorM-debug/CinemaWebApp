using CinemaApp.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CinemaApp.Data.Configurations
{
    /// <summary>
    /// Configures the <see cref="CinemaMovie"/> entity for the database model.
    /// This class defines the primary key and relationships for the <see cref="CinemaMovie"/> entity.
    /// </summary>
    public class CinemaMovieConfiguration : IEntityTypeConfiguration<CinemaMovie>
    {
        /// <summary>
        /// Configures the properties and relationships of the <see cref="CinemaMovie"/> entity.
        /// </summary>
        /// <param name="builder">
        /// The <see cref="EntityTypeBuilder{TEntity}"/> used to configure the <see cref="CinemaMovie"/> entity.
        /// </param>
        public void Configure(EntityTypeBuilder<CinemaMovie> builder)
        {
            // Set the primary key for the CinemaMovie entity, which is a composite key consisting of MovieId and CinemaId
            builder
                .HasKey(cm => new { cm.MovieId, cm.CinemaId });

            // Configure the relationship between CinemaMovie and Movie
            builder
                .HasOne(cm => cm.Movie)                    
                .WithMany(m => m.CinemasMovies)            
                .HasForeignKey(cm => cm.MovieId);           

            // Configure the relationship between CinemaMovie and Cinema
            builder
                .HasOne(cm => cm.Cinema)                    
                .WithMany(c => c.CinemasMovies)             
                .HasForeignKey(cm => cm.CinemaId);          
        }
    }
}
