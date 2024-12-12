using Movie.Api.Data;
using Movie.Api.Endpoints;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("MovieStore");

builder.Services.AddSqlite<MovieStoreContext>(connectionString);

var app = builder.Build();

app.MapMoviesEndpoint();

await app.MigrateDatabaseAsync();

app.Run();
