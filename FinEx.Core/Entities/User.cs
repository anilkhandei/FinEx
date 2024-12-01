namespace FinEx.Core.Entities;

public class User
{
    public int Id { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
    public ICollection<Income> Incomes { get; set; }
    public ICollection<Expense> Expenses { get; set; }
    public ICollection<Budget> Budgets { get; set; }


}
