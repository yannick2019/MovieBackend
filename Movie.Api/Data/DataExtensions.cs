using Microsoft.EntityFrameworkCore;

namespace Movie.Api.Data
{
    public static class DataExtensions
    {
        public static async Task MigrateDatabaseAsync(this WebApplication app)
        {
            using var scope = app.Services.CreateScope();

            var dbContext = scope.ServiceProvider.GetRequiredService<MovieStoreContext>();

            await dbContext.Database.MigrateAsync();
        }
    }
}
