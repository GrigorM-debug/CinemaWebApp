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
    public class CinemaConfiguration : IEntityTypeConfiguration<Cinema>
    {
        public void Configure(EntityTypeBuilder<Cinema> builder)
        {
            builder
                .HasKey(c => c.Id);

            builder
                .Property(c => c.Name)
                .IsRequired();

            builder
                .Property(c => c.Location)
                .IsRequired();

            //builder.HasData(CinemaDataSeed());
        }

        //private List<Cinema> CinemaDataSeed()
        //{
        //    List<Cinema> cinemas = new List<Cinema>()
        //    {
        //        new Cinema()
        //        {
        //            Name = "Kino Arena",
        //            Location = "Sofia"
        //        },
        //        new Cinema()
        //        {
        //            Name = "Cinema City",
        //            Location = "Sofia"
        //        },
        //        new Cinema() 
        //        {
        //            Name = "Mall Gallery",
        //            Location = "Stara Zagora"
        //        },
        //        new Cinema() 
        //        {
        //            Name = "Kino Arena",
        //            Location = "Plovdiv"
        //        },
        //    };

        //    return cinemas;
        //}
    }
}
