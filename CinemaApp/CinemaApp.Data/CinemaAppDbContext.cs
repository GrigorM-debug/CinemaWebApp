using CinemaApp.Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using CinemaApp.Data.Seeding;

namespace CinemaApp.Data
{
    /// <summary>
    /// Represents the database context for the CinemaApp.
    /// Manages the <see cref="Movie"/>, <see cref="Cinema"/>, and <see cref="CinemaMovie"/> entities.
    /// </summary>
    public class CinemaAppDbContext : DbContext
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CinemaAppDbContext"/> class.
        /// </summary>
        public CinemaAppDbContext()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CinemaAppDbContext"/> class with the specified options.
        /// </summary>
        /// <param name="options">The options to configure the context.</param>
        public CinemaAppDbContext(DbContextOptions options) : base(options)
        {
        }

        /// <summary>
        /// Gets or sets the <see cref="DbSet{TEntity}"/> for <see cref="Movie"/> entities.
        /// </summary>
        public virtual DbSet<Movie> Movies { get; set; } = null!;

        /// <summary>
        /// Gets or sets the <see cref="DbSet{TEntity}"/> for <see cref="Cinema"/> entities.
        /// </summary>
        public virtual DbSet<Cinema> Cinemas { get; set; } = null!;

        /// <summary>
        /// Gets or sets the <see cref="DbSet{TEntity}"/> for the <see cref="CinemaMovie"/> mapping table.
        /// </summary>
        public virtual DbSet<CinemaMovie> CinemasMovies { get; set; } = null!;

        /// <summary>
        /// Configures the model and applies any custom configurations or seed data during model creation.
        /// </summary>
        /// <param name="modelBuilder">The <see cref="ModelBuilder"/> used to configure the model for the context.</param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            // Seed data
            CinemaAppDataSeeder.SeedCinemas(modelBuilder);
            CinemaAppDataSeeder.SeedMovies(modelBuilder);
            CinemaAppDataSeeder.SeedCinemaMovies(modelBuilder);
        }
    }
}
