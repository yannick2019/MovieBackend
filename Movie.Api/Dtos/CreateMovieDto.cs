using System.ComponentModel.DataAnnotations;

namespace Movie.Api.Dtos
{
    public record CreateMovieDto([Required] string Title, int DirectorId, DateOnly ReleaseDate);
}
