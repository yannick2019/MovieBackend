using Movie.Api.Dtos;

namespace Movie.Api.Mapping
{
    public static class MovieMapping
    {
        public static Entities.Movie ToEntity(this CreateMovieDto newMovie)
        {
            return new Entities.Movie()
            {
                Title = newMovie.Title,
                DirectorId = newMovie.DirectorId,
                ReleaseDate = newMovie.ReleaseDate
            };
        }

        public static MovieDetailsDto ToMovieDetailsDto(this Entities.Movie movie)
        {
            return new
            (
                Id: movie.Id,
                Title: movie.Title,
                DirectorId: movie.DirectorId,
                ReleaseDate: movie.ReleaseDate
            );
        }

        public static MovieSummaryDto ToMovieSummaryDto(this Entities.Movie movie)
        {
            return new
            (
                Id: movie.Id,
                Title: movie.Title,
                Director: movie.Director!.Name,
                ReleaseDate: movie.ReleaseDate
            );
        }

        public static Entities.Movie ToEntity(this UpdateMovieDto updateMovie, int id)
        {
            return new Entities.Movie()
            {
                Id = id,
                Title = updateMovie.Title,
                DirectorId = updateMovie.DirectorId,
                ReleaseDate = updateMovie.ReleaseDate
            };
        }
    }
}
