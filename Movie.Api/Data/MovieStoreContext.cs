using Microsoft.EntityFrameworkCore;
using Movie.Api.Entities;

namespace Movie.Api.Data
{
    public class MovieStoreContext(DbContextOptions<MovieStoreContext> options) : DbContext(options)
    {
        public DbSet<Entities.Movie> Movies => Set<Entities.Movie>();
        public DbSet<Director> Directors => Set<Director>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Director>().HasData
                (
                    new { Id = 1, Name = "Christopher Nolan", DateOfBirth = new DateOnly(1970, 7, 30), Nationality = "British-American"},
                    new { Id = 2, Name = "Quentin Tarantino", DateOfBirth = new DateOnly(1963, 3, 27), Nationality = "American" },
                    new { Id = 3, Name = "Sophia Coppola", DateOfBirth = new DateOnly(1971, 5, 14), Nationality = "American" }
                );
        }
    }
}
