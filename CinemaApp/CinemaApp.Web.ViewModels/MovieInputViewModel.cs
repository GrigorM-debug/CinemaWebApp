using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static CinemaApp.Common.MovieValidationConstants;

namespace CinemaApp.Web.ViewModels
{
    public class MovieInputViewModel
    {
        [Required]
        [MinLength(TitleMinLenght)]
        [MaxLength(TitleMaxLenght)]
        public string Title { get; set; } = null!;

        [Required]
        [MinLength(GenreMinLenght)]
        [MaxLength(GenreMaxLenght)]
        public string Genre { get; set; } = null!;

        [Required]
        public string ReleaseDate { get; set; } = null!;

        [Required]
        public int Duration { get; set; }

        [Required]
        [MinLength(DirectorMinLenght)]
        [MaxLength(DirectorMaxLenght)]
        public string Director { get; set; } = null!;

        [Required]
        [MinLength(DescriptionMinLenght)]
        [MaxLength(DescriptionMaxLenght)]
        public string Description { get; set; } = null!;
    }
}
