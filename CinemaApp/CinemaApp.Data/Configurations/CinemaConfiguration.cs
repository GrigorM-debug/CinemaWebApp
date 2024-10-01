using CinemaApp.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using static CinemaApp.Common.CinemaValidationConstants;

namespace CinemaApp.Data.Configurations
{
    /// <summary>
    /// Configures the <see cref="Cinema"/> entity for the Entity Framework Core model.
    /// </summary>
    public class CinemaConfiguration : IEntityTypeConfiguration<Cinema>
    {
        /// <summary>
        /// Configures the <see cref="Cinema"/> entity's properties and relationships.
        /// </summary>
        /// <param name="builder">The <see cref="EntityTypeBuilder{Cinema}"/> used to configure the entity.</param>
        public void Configure(EntityTypeBuilder<Cinema> builder)
        {
            // Configure the primary key
            builder
                .HasKey(c => c.Id)
                .HasName("PK_Cinema_Id");

            // Configure the Name property
            builder
                .Property(c => c.Name)
                .IsRequired()
                .HasMaxLength(NameMaxLenght)
                .HasComment("The name of the cinema. Must be at least the minimum length specified.");

            // Configure the Location property
            builder
                .Property(c => c.Location)
                .IsRequired()
                .HasMaxLength(LocationMaxLenght)
                .HasComment("The location of the cinema. Must be at least the minimum length specified.");

            // Configure the relationship with CinemaMovie
            builder
                .HasMany(c => c.CinemasMovies)
                .WithOne(cm => cm.Cinema)
                .HasForeignKey(cm => cm.CinemaId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_Cinema_CinemaMovie_CinemaId");
        }
    }
}
