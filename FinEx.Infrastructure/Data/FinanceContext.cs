using FinEx.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace FinEx.Infrastructure.Data;

public class FinanceContext : DbContext
{
    public FinanceContext(DbContextOptions<FinanceContext> options) : base(options)
    {
    }

    public DbSet<User> Users { get; set; }
    public DbSet<Expense> Expenses { get; set; }
    public DbSet<Budget> Budgets { get; set; }
    public DbSet<Income> Incomes { get; set; }
    public DbSet<Category> Categories { get; set; }

}
