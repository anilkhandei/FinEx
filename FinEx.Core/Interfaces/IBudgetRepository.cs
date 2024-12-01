using FinEx.Core.Entities;

namespace FinEx.Core.Interfaces;

public interface IBudgetRepository
{
    Task<Budget> GetByIdAsync(int id);
    Task AddAsync(Budget budget);
    Task UpdateAsync(Budget budget);
    Task DeleteAsync(int id);
    Task<IEnumerable<Budget>> GetAllByUserIdAsync(int userId);
}
