using Microsoft.EntityFrameworkCore;
using LibraryManagementSystem.Model;
using LibraryManagementSystem.Dto;

namespace LibraryManagementSystem.Data
{
    public class DBContext : DbContext
    {
        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Book { get; set; }
        public DbSet<BookCopy> BookCopy { get; set; }
        public DbSet<Borrowing> Borrowing { get; set; }
        public DbSet<Fine> Fine { get; set; }
        public DbSet<Member> Member { get; set; }
        public DbSet<Publisher> Publisher { get; set; }
        public DbSet<User> User { get; set; }

        public DBContext(DbContextOptions<DBContext> options) : base(options)
        {
        }
    }
}
