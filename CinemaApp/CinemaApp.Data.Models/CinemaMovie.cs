namespace CinemaApp.Data.Models
{
    /// <summary>
    /// Represents the mapping between a <see cref="Cinema"/> and a <see cref="Movie"/>.
    /// This class is used to establish a many-to-many relationship between cinemas and movies.
    /// </summary>
    public class CinemaMovie
    {
        /// <summary>
        /// Gets or sets the unique identifier for the cinema.
        /// </summary>
        /// <value>The unique identifier of the <see cref="Cinema"/> that shows the movie.</value>
        public Guid CinemaId { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="Cinema"/> associated with this mapping.
        /// </summary>
        /// <value>The <see cref="Cinema"/> where the movie is being shown.</value>
        public virtual Cinema Cinema { get; set; } = null!;

        /// <summary>
        /// Gets or sets the unique identifier for the movie.
        /// </summary>
        /// <value>The unique identifier of the <see cref="Movie"/> shown at the cinema.</value>
        public Guid MovieId { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="Movie"/> associated with this mapping.
        /// </summary>
        /// <value>The <see cref="Movie"/> that is shown at the cinema.</value>
        public virtual Movie Movie { get; set; } = null!;

        public bool IsDeleted { get; set; }
    }
}
