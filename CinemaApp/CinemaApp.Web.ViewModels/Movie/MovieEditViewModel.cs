using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static CinemaApp.Common.EntityValidations.MovieValidations;
using static CinemaApp.Common.MovieValidationConstants;
using static CinemaApp.Common.ApplicationConstants;

namespace CinemaApp.Web.ViewModels.Movie
{
    public class MovieEditViewModel
    {

        [Required(ErrorMessage = TitleIsRequiredMessage)]
        [MinLength(TitleMinLenght, ErrorMessage = TitleMinLenghtMessage)]
        [MaxLength(TitleMaxLenght, ErrorMessage = TitleMaxLenghtMessage)]
        public string Title { get; set; } = null!;

        [Required(ErrorMessage = GenreIsRequiredMessage)]
        [MinLength(GenreMinLenght, ErrorMessage = GenreMinLenghtMessage)]
        [MaxLength(GenreMaxLenght, ErrorMessage = GenreMaxLenghtMessage)]
        public string Genre { get; set; } = null!;

        [Required(ErrorMessage = ReleaseDateIsRequireMessage)]
        public string ReleaseDate { get; set; } = null!;

        [Required(ErrorMessage = DurationIsRequiredMessage)]
        [Range(MinDuration, MaxDuration, ErrorMessage = DurationRangeMessage)]
        public int Duration { get; set; }

        [Required(ErrorMessage = DirectorNameIsRequiredMessage)]
        [MinLength(DirectorMinLenght, ErrorMessage = DirectorNameMinLenghtMessage)]
        [MaxLength(DirectorMaxLenght, ErrorMessage = DirectorNameMaxLenghtMessage)]
        public string Director { get; set; } = null!;

        [Required(ErrorMessage = DescriptionIsRequiredMessage)]
        [MinLength(DescriptionMinLenght, ErrorMessage = DescriptionMinLenghtMessage)]
        [MaxLength(DescriptionMaxLenght, ErrorMessage = DescriptionMaxLenghtMessage)]
        public string Description { get; set; } = null!;
    }
}
