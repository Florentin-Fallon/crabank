using Crabank.Database.Models;
using Microsoft.EntityFrameworkCore;

namespace Crabank.Database;

public class BankDbContext : DbContext
{
    public DbSet<BankAccount> Accounts { get; set; }
    public DbSet<BankTransaction> Transactions { get; set; }
    public DbSet<BankAdvisor> Advisors { get; set; }
    public DbSet<BankCard> Cards { get; set; }
    
    public BankDbContext()
    {
        
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=bank.db");
        base.OnConfiguring(optionsBuilder);
    }
}