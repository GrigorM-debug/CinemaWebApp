namespace CinemaApp.Data.Models
{
    public class UserMovie
    {
        public string UserId { get; set; } = null!;

        public CinemaAppUser User { get; set; } = null!;

        public Guid MovieId { get; set; }

        public Movie Movie { get; set; } = null!;

        public bool IsDeleted { get; set; }
    }
}
