using FinEx.Core.Entities;

namespace FinEx.Core.Interfaces;
public interface ICategoryRepository
{
    Task<Category> GetByIdAsync(int id);
    Task AddAsync(Category category);
    Task UpdateAsync(Category category);
    Task DeleteAsync(int id);
    Task<List<Category>> GetAllAsync();
}
