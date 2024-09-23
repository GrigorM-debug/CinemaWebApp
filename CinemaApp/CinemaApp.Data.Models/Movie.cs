using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static CinemaApp.Common.MovieValidationConstants;

namespace CinemaApp.Data.Models
{
    public class Movie
    {
        public Movie()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }

        [MinLength(TitleMinLenght)]
        public string Title { get; set; } = null!;

        [MinLength(GenreMinLenght)]
        public string Genre { get; set; } = null!;

        public DateTime ReleaseDate { get; set; }

        [MinLength(DirectorMinLenght)]
        public string Director { get; set; } = null!;

        [Range(MinDuration, MaxDuration)]
        public int Duration { get; set; }

        [MinLength(DescriptionMinLenght)]
        public string Description { get; set; } = null!;
    }
}
