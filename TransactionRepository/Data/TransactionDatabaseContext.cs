using Microsoft.EntityFrameworkCore;
using TransactionRepository.Model;

namespace TransactionRepository.Data
{
    public class TransactionDatabaseContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase(databaseName: "TransactionDatabase");
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Transaction> Tranasctions { get; set; }
    }
}
