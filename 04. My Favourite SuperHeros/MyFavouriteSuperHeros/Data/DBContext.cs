using Microsoft.EntityFrameworkCore;
using MyfavouriteSuperHeros.Data.Model;

namespace MyfavouriteSuperHeros.Data
{
    public class DBContext : DbContext
    {
        public DBContext(DbContextOptions<DBContext> options) : base(options) 
        {
            
        }
        public DbSet<SuperHero> SuperHero { get; set; }
    }
}
