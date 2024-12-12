namespace Movie.Api.Dtos
{
    public record MovieSummaryDto(int Id, string Title, string Director, DateOnly ReleaseDate);
}
