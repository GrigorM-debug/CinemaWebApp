using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaApp.Common
{
    public static class MovieValidationConstants
    {
        //Movie Lenght
        public const int TitleMaxLenght = 50;
        public const int TitleMinLenght = 2;

        //Genre lenght
        public const int GenreMaxLenght = 30;
        public const int GenreMinLenght = 3;

        //Director lenght
        public const int DirectorMaxLenght = 50;
        public const int DirectorMinLenght = 2;

        //Description lenght
        public const int DescriptionMaxLenght = 500;
        public const int DescriptionMinLenght = 10;
    }
}
