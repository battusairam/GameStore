using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using GameStore.Api.Data;
using GameStore.Api.Dtos;
using GameStore.Api.Entities;
using GameStore.Api.Mapping;

namespace GameStore.Api.EndPoints
{
    public static class GenresEndPoints
    {
        public static RouteGroupBuilder MapGenresEndpoints(this WebApplication app)
        {
            var group = app.MapGroup("genres");

            // GET endpoint
            group.MapGet("/", async (GameStoreContext dbContext) =>
                await dbContext.Genres
                    .Select(genre => genre.ToDto())
                    .AsNoTracking()
                    .ToListAsync());

            // POST endpoint
            group.MapPost("/", async (GameStoreContext dbContext, GenreDto genreDto) =>
            {
                var genre = new Genre
                {
                    Name = genreDto.Name,
                    // map other properties if any
                };

                dbContext.Genres.Add(genre);
                await dbContext.SaveChangesAsync();

                return Results.Created($"/genres/{genre.Id}", genre.ToDto());
            });

             // DELETE endpoint
            group.MapDelete("/{id}", async (int id, GameStoreContext dbContext) =>
            {
                var genre = await dbContext.Genres.FindAsync(id);

                if (genre == null)
                {
                    return Results.NotFound($"Genre with ID {id} not found.");
                }

                dbContext.Genres.Remove(genre);
                await dbContext.SaveChangesAsync();

                return Results.NoContent();
            });


            return group;
        }
    }
}
