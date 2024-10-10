using System.ComponentModel.DataAnnotations;
using static CinemaApp.Common.MovieValidationConstants;
using static CinemaApp.Common.ApplicationConstants;

namespace CinemaApp.Data.Models
{
    /// <summary>
    /// Represents a movie with its details such as title, genre, release date, and more
    /// </summary>
    public class Movie
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Movie"/> class.
        /// Genereates a new unique identifier and initializes the collection of Cinemas that show this movie
        /// </summary>
        public Movie()
        {
            Id = Guid.NewGuid();
            CinemasMovies = new HashSet<CinemaMovie>();
        }

        /// <summary>
        /// Gets and sets the unique indentifier for the movie
        /// </summary>
        /// <value>A unique <see cref="Guid"/> representing the movie.</value>
        public Guid Id { get; set; }

        /// <summary>
        /// Gets and sets the title of the movie
        /// </summary>
        /// <value>The title of the movie must be at least <see cref="TitleMinLenght"/> characters long.</value>
        [MinLength(TitleMinLenght)]
        public string Title { get; set; } = null!;

        /// <summary>
        /// Gets and sets the genre of the movie
        /// </summary>
        /// <value>The title must be at least <see cref="TitleMinLenght"/> characters long.</value>
        [MinLength(GenreMinLenght)]
        public string Genre { get; set; } = null!;

        /// <summary>
        /// Gets and sets the release date of the movie.
        /// </summary>
        /// <value>The date when the movie was or will be released.</value>
        public DateTime ReleaseDate { get; set; }

        /// <summary>
        /// Gets and sets the director of the movie.
        /// </summary>
        /// <value>The name of movie's director must be at least <see cref="DirectorMinLenght"/> characters long.</value>
        [MinLength(DirectorMinLenght)]
        public string Director { get; set; } = null!;

        /// <summary>
        /// Gets and sets the duration of the movie in minutes.
        /// </summary>
        /// <value>
        /// The duration of the movie in minutes. Must be between <see cref="MinDuration"/> and <see cref="MaxDuration"/>.
        /// </value>
        [Range(MinDuration, MaxDuration)]
        public int Duration { get; set; }

        /// <summary>
        /// Gets and sets the description of the movie.
        /// </summary>
        /// <value>
        /// A description of the movie's plot. Must be at least <see cref="DescriptionMinLenght"/> charaters long.
        /// </value>
        [MinLength(DescriptionMinLenght)]
        public string Description { get; set; } = null!;

        [MinLength(ImageUrlMinLength)]
        public string ImageUrl { get; set; } = null!;
        /// <summary>
        /// Gets and sets the collection of cinemas that show this movie.
        /// </summary>
        /// <value>
        /// A collection of <see cref="CinemaMovie"/> representing the cinemas where this movie is being screened.
        /// </value>
        public virtual ICollection<CinemaMovie> CinemasMovies { get; set; }
    }
}
