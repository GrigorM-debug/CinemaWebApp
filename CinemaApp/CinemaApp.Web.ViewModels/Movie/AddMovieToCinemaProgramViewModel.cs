using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static CinemaApp.Common.MovieValidationConstants;
namespace CinemaApp.Web.ViewModels
{
    public class AddMovieToCinemaProgramViewModel
    {
        [Required]
        public string MovieId { get; set; } = null!;

        [Required]
        [MinLength(TitleMinLenght)]
        [MaxLength(TitleMaxLenght)]
        public string MovieTitle { get; set; } = null!;

        public List<CinemaCheckBoxViewModel> Cinemas { get; set; } = new List<CinemaCheckBoxViewModel>();
    }
}
