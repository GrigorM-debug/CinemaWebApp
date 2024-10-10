using CinemaApp.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using static CinemaApp.Common.ApplicationConstants;
using static CinemaApp.Common.MovieValidationConstants;

namespace CinemaApp.Data.Configurations
{
    /// <summary>
    /// Configures the <see cref="Movie"/> entity for the database model.
    /// This class defines the primary key, required properties, and maximum length for the <see cref="Movie"/> entity.
    /// </summary>
    public class MovieConfiguration : IEntityTypeConfiguration<Movie>
    {
        /// <summary>
        /// Configures the properties and relationships of the <see cref="Movie"/> entity.
        /// </summary>
        /// <param name="builder">
        /// The <see cref="EntityTypeBuilder{TEntity}"/> used to configure the <see cref="Movie"/> entity.
        /// </param>
        public void Configure(EntityTypeBuilder<Movie> builder)
        {
            // Set the primary key for the Movie entity
            builder
                .HasKey(m => m.Id);

            // Configure the Title property
            builder
                .Property(m => m.Title)                    
                .IsRequired()                               
                .HasMaxLength(TitleMaxLenght)             
                .HasComment("The title of the movie. Must be at least the minimum length specified."); 

            // Configure the Genre property
            builder
                .Property(m => m.Genre)
                .IsRequired()                               
                .HasMaxLength(GenreMaxLenght)              
                .HasComment("The genre of the movie. Must be at least the minimum length specified."); 

            // Configure the ReleaseDate property
            builder
                .Property(m => m.ReleaseDate)
                .IsRequired()                               
                .HasComment("The release date of the movie."); 

            // Configure the Director property
            builder
                .Property(m => m.Director)                 
                .IsRequired()                              
                .HasMaxLength(DirectorMaxLenght)           
                .HasComment("The director of the movie. Must be at least the minimum length specified."); 

            // Configure the Duration property
            builder
                .Property(m => m.Duration)
                .IsRequired()                               
                .HasComment("The duration of the movie in minutes."); 

            // Configure the Description property
            builder
                .Property(m => m.Description)              
                .IsRequired()                               
                .HasMaxLength(DescriptionMaxLenght)      
                .HasComment("A brief description of the movie. Must be at least the minimum length specified.");

            builder
                .Property(m => m.ImageUrl)
                .IsRequired()
                .HasMaxLength(ImageUrlMaxLength);
        }
    }
}
