using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace CinemaApp.Data.Models
{
    public class CinemaAppUser : IdentityUser
    {
        [PersonalData]
        [MaxLength(255)]
        [Comment("The first name of the user")]
        public string? FirstName { get; set; }

        [PersonalData]
        [MaxLength(255)]
        [Comment("The last name of the user")]
        public string? LastName { get; set;}
    }
}
