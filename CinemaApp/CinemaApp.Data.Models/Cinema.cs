using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public string Name { get; set; } = null!;

        public string Location { get; set; } = null!;

        public virtual ICollection<CinemaMovie> CinemasMovies { get; set; }
    }
}
