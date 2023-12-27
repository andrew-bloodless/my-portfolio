using Microsoft.EntityFrameworkCore;

namespace ExpensesReimbursement;

public class ExpensesDBContext(DbContextOptions<ExpensesDBContext> options) : DbContext(options)
{
    public DbSet <Expense> Expenses => Set<Expense>();
}