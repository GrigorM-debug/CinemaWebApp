using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaApp.Common.EntityValidations
{
    public static class MovieValidations
    {
        //Title
        public const string TitleIsRequiredMessage = "Movie Title is required !";
        public const string TitleMinLenghtMessage = "Title must be at least 2 characters long !";
        public const string TitleMaxLenghtMessage = "Title must be maximum 50 characters long !";

        //Genre
        public const string GenreIsRequiredMessage = "Genre is required !";
        public const string GenreMinLenghtMessage = "Genre must be at least 3 characters long !";
        public const string GenreMaxLenghtMessage = "Genre must be maximum 30 characters long !";

        //Release Date
        public const string ReleaseDateIsRequireMessage = "Release Date is required !";

        //Duration 
        public const string DurationIsRequiredMessage = "Please specify the movie Duration !";
        public const string DurationRangeMessage = "Duration must be between 1 and 999 minutes !";

        //Director
        public const string DirectorNameIsRequiredMessage = "Director name is required !";
        public const string DirectorNameMinLenghtMessage = "Director name must at least 2 characters long !";
        public const string DirectorNameMaxLenghtMessage = "Director name must be maximum 50 charaters long !";

        //Description 
        public const string DescriptionIsRequiredMessage = "Description is required !";
        public const string DescriptionMinLenghtMessage = "Description must be at least 10 characters long !";
        public const string DescriptionMaxLenghtMessage = "Description must be maximum 500 characters long !";
    }
}
