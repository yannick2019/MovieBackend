namespace Movie.Api.Dtos
{
    public record UpdateMovieDto(string Title, int DirectorId, DateOnly ReleaseDate);
}
