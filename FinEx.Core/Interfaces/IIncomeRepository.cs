using FinEx.Core.Entities;

namespace FinEx.Core.Interfaces;

public interface IIncomeRepository
{
    Task<Income> GetByIdAsync(int id);
    Task AddAsync(Income income);
    Task UpdateAsync(Income income);
    Task DeleteAsync(int id);
    Task<IEnumerable<Income>> GetAllByUserIdAsync(int userId);
}
