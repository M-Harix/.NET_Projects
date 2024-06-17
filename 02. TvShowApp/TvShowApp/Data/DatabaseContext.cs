using Microsoft.EntityFrameworkCore;
using TvShowApp.Models;

namespace TvShowApp.Data
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
        }
        public DbSet<TvShow> TvShows { get; set; }
    }
}
