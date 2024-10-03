using Microsoft.EntityFrameworkCore;

namespace Crabank.Database;

public class BankDbContext : DbContext
{
    public BankDbContext()
    {
        
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=bank.db");
        base.OnConfiguring(optionsBuilder);
    }
}