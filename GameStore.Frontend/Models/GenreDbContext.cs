using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
namespace GameStore.Frontend.Models
{
    public class GenreDbContext : DbContext
    {
        public GenreDbContext(DbContextOptions<GenreDbContext> options)
            : base(options)
        {
        }

        public DbSet<Genre> Genres { get; set; }
    }
}
