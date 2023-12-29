using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ExpensesReimbursement;

public class ExpensesDBContext(DbContextOptions<ExpensesDBContext> options) : IdentityDbContext(options)
{
    public DbSet <Expense> Expenses => Set<Expense>();
}