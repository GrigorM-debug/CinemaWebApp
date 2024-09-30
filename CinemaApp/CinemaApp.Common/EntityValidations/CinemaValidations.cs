using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaApp.Common.EntityValidations
{
    public static class CinemaValidations
    {
        public const string NameIsRequredMessage = "Name is required !";
        public const string NameLenghtMessage = "Name must be between 2 and 50 characters !";

        public const string LocationIsRequiredMessage = "Location is required !";
        public const string LocationLenghtMessage = "Location must be between 2 and 50 characters long !";
    }
}
