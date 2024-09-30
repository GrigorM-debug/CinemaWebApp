using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static CinemaApp.Common.CinemaValidationConstants;

namespace CinemaApp.Data.Models
{
    public class Cinema
    {
        public Cinema()
        {
            Id = Guid.NewGuid();
            CinemasMovies = new HashSet<CinemaMovie>();
        }

        public Guid Id { get; set; }

        [MinLength(NameMinLenght)]
        public string Name { get; set; } = null!;

        [MinLength(LocationMinLengh)]
        public string Location { get; set; } = null!;

        public virtual ICollection<CinemaMovie> CinemasMovies { get; set; }
    }
}
