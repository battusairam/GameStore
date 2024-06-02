using GameStore.Api.Data;
using GameStore.Api.Endpoints;
using GameStore.Api.EndPoints;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<GameStoreContext>(options =>
options.UseNpgsql(builder.Configuration.GetConnectionString("GameStore")));

// builder.Services.AddNpgsql<GameStoreContext>(connString);
var app = builder.Build();
app.MapGamesEndpoints();
app.MapGenresEndpoints();
await app.MigrateDbAsync();
app.Run();
    