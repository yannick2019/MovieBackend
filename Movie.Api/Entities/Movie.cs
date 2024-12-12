namespace Movie.Api.Entities
{
    public class Movie
    {
        public int Id { get; set; }
        public required string Title { get; set; }
        public int DirectorId { get; set; }
        public Director? Director { get; set; }
        public DateOnly ReleaseDate { get; set; }
    }
}
