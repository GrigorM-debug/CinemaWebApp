using System.ComponentModel.DataAnnotations;
using static CinemaApp.Common.CinemaValidationConstants;

namespace CinemaApp.Data.Models
{
    /// <summary>
    /// Represents a cinema, including its name, location, and associated movies.
    /// </summary>
    public class Cinema
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Cinema"/> class.
        /// Generates a new unique identifier for the cinema and initializes the collection of movies shown at the cinema.
        /// </summary>
        public Cinema()
        {
            Id = Guid.NewGuid();
            CinemasMovies = new HashSet<CinemaMovie>();
        }

        /// <summary>
        /// Gets or sets the unique identifier for the cinema.
        /// </summary>
        /// <value>A unique <see cref="Guid"/> representing the cinema.</value>
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the name of the cinema.
        /// </summary>
        /// <value>The name of the cinema. Must be at least <see cref="NameMinLenght"/> characters long.</value>
        [MinLength(NameMinLenght)]
        public string Name { get; set; } = null!;

        /// <summary>
        /// Gets or sets the location of the cinema.
        /// </summary>
        /// <value>The location of the cinema. Must be at least <see cref="LocationMinLengh"/> characters long.</value>
        [MinLength(LocationMinLengh)]
        public string Location { get; set; } = null!;

        /// <summary>
        /// Gets or sets the collection of movies shown at the cinema.
        /// </summary>
        /// <value>A collection of <see cref="CinemaMovie"/> representing the movies that are shown at this cinema.</value>
        public virtual ICollection<CinemaMovie> CinemasMovies { get; set; }
    }
}
