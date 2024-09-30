using CinemaApp.Data.Configurations;
using CinemaApp.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using CinemaApp.Data.Seeding;

namespace CinemaApp.Data
{
    public class CinemaAppDbContext : DbContext
    {
        public CinemaAppDbContext()
        {
        }

        public CinemaAppDbContext(DbContextOptions options) : base(options)
        {
        }

        public virtual DbSet<Movie> Movies { get; set; } = null!;
        public virtual DbSet<Cinema> Cinemas { get; set; } = null!;
        public virtual DbSet<CinemaMovie> CinemasMovies { get; set; } = null!;

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
