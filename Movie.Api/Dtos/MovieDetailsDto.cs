namespace Movie.Api.Dtos
{
    public record MovieDetailsDto(int Id, string Title, int DirectorId, DateOnly ReleaseDate);
}
