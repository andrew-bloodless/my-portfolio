using Microsoft.EntityFrameworkCore;

namespace ExpensesReimbursement;

public class ExpensesDBContext : DbContext
{
    public DbSet <Expense> Expenses { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseInMemoryDatabase("ExpensesDB");
    }
}
