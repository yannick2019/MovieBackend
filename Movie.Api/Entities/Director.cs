namespace Movie.Api.Entities
{
    public class Director
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public DateOnly DateOfBirth { get; set; }
        public required string Nationality { get; set; }
    }
}
