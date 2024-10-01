using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static CinemaApp.Common.CinemaValidationConstants;
using static CinemaApp.Common.EntityValidations.CinemaValidations;

namespace CinemaApp.Web.ViewModels.Cinema
{
    public class CinemaEditViewModel
    {
        [Required(ErrorMessage = NameIsRequredMessage)]
        [MinLength(NameMinLenght, ErrorMessage = NameLenghtMessage)]
        [MaxLength(NameMaxLenght, ErrorMessage = NameLenghtMessage)]
        public string Name { get; set; } = null!;

        [Required(ErrorMessage = NameIsRequredMessage)]
        [MinLength(LocationMinLengh, ErrorMessage = LocationLenghtMessage)]
        [MaxLength(LocationMaxLenght, ErrorMessage = LocationLenghtMessage)]
        public string Location { get; set; } = null!;
    }
}
