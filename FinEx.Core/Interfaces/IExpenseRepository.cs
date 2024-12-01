using FinEx.Core.Entities;

namespace FinEx.Core.Interfaces;

public interface IExpenseRepository
{
    Task<Expense> GetByIdAsync(int id);
    Task AddAsync(Expense expense);
    Task UpdateAsync(Expense expense);
    Task DeleteAsync(int id);
    Task<IEnumerable<Expense>> GetAllByUserIdAsync(int UserId);
}
