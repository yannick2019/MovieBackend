using Microsoft.EntityFrameworkCore;
using Movie.Api.Data;
using Movie.Api.Dtos;
using Movie.Api.Mapping;

namespace Movie.Api.Endpoints
{
    public static class MoviesEndpoints
    {
        public static RouteGroupBuilder MapMoviesEndpoint(this WebApplication app)
        {
            var group = app.MapGroup("/movies").WithParameterValidation();

            group.MapGet("/", async (MovieStoreContext dbContext) => 
            {
                return await dbContext.Movies
                    .Include(movie => movie.Director)
                    .Select(movie => movie.ToMovieSummaryDto())
                    .AsNoTracking()
                    .ToListAsync();
            });

            group.MapGet("/{id}", async (int id, MovieStoreContext dbContext) =>
            {
                Entities.Movie? movie = await dbContext.Movies.FindAsync(id);

                return (movie is null) ? Results.NotFound() : Results.Ok(movie.ToMovieDetailsDto());
            }).WithName("GetMovie");

            group.MapPost("/", async (CreateMovieDto newMovie, MovieStoreContext dbContext) =>
            {
                Entities.Movie movie = newMovie.ToEntity();

                await dbContext.Movies.AddAsync(movie);
                await dbContext.SaveChangesAsync();

                return Results.CreatedAtRoute("GetMovie", new { id = movie.Id }, movie.ToMovieDetailsDto());
            });

            group.MapPut("/{id}", async (int id, UpdateMovieDto updateMovie, MovieStoreContext dbContext) =>
            {
                var existingMovie = await dbContext.Movies.FindAsync(id);

                if (existingMovie is null) return Results.NotFound();

                dbContext.Entry(existingMovie).CurrentValues.SetValues(updateMovie.ToEntity(id));

                await dbContext.SaveChangesAsync();

                return Results.NoContent();
            });

            group.MapDelete("/{id}", async (int id, MovieStoreContext dbContext) =>
            {
                await dbContext.Movies.Where(movie => movie.Id == id).ExecuteDeleteAsync();

                return Results.NoContent();
            });

            return group;
        }
    }
}
