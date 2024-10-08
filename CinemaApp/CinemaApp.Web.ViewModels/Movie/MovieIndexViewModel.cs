﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static CinemaApp.Common.MovieValidationConstants;
using static CinemaApp.Common.EntityValidations.MovieValidations;
using static CinemaApp.Common.ApplicationConstants;

namespace CinemaApp.Web.ViewModels.Movie
{
    public class MovieIndexViewModel
    {
        public string Id { get; set; } = null!;

        [Required(ErrorMessage = TitleIsRequiredMessage)]
        [MinLength(TitleMinLenght)]
        [MaxLength(TitleMaxLenght)]
        public string Title { get; set; } = null!;

        [Required(ErrorMessage = GenreIsRequiredMessage)]
        [MinLength(GenreMinLenght)]
        [MaxLength(GenreMaxLenght)]
        public string Genre { get; set; } = null!;

        public DateTime ReleaseDate { get; set; }

        [Required(ErrorMessage = DirectorNameIsRequiredMessage)]
        [MinLength(DirectorMinLenght)]
        [MaxLength(DirectorMaxLenght)]
        public string Director { get; set; } = null!;

        [Range(MinDuration, MaxDuration)]
        public int Duration { get; set; }

        [MinLength(DescriptionMinLenght)]
        public string Description { get; set; } = null!;

        [MinLength(ImageUrlMinLength)]
        [MaxLength(ImageUrlMaxLength)]
        public string ImageUrl { get; set; } = null!;
    }
}
