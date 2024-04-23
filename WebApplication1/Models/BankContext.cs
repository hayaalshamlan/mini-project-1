using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Models
{
    public class BankContext : DbContext
    {
        public DbSet<BankBranch> BankBranches { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=bank.db");
        }
        public DbSet<Employee> Employees { get; set; }
    }

}
