using BankManagementSystem.Model;
using Microsoft.EntityFrameworkCore;

namespace BankManagementSystem.Data
{
    public class DBContext : DbContext
    {
        public DbSet<Account> Account { get; set; }
        public DbSet<Branch> Branch { get; set; }
        public DbSet<Customer> Customer { get; set; }
        public DbSet<Employee> Employee { get; set; }
        public DbSet<Loan> Loan { get; set; }
        public DbSet<Transaction> Transaction { get; set; }

        public DBContext(DbContextOptions<DBContext> options) : base(options)
        {
            
        }
    }
}
