using FinEx.Core.Entities;
using FinEx.Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FinEx.Infrastructure.Data;

public class UserRepository : IUserRepository
{
    private readonly FinanceContext _financeContext;
    public UserRepository(FinanceContext financeContext)
    {
        _financeContext = financeContext;
    }
    public async Task AddAsync(User user)
    {
        if (user != null) 
        {
            await _financeContext.Users.AddAsync(user);
            await _financeContext.SaveChangesAsync();
        }
    }

    public async Task DeleteAsync(int id)
    {
        var user=await GetByIdAsync(id);
        if (user != null)
        {
            _financeContext.Users.Remove(user);
            await _financeContext.SaveChangesAsync();
        }
    }

    public async Task<List<User>> GetAllAsync()
    {
        return await _financeContext.Users.ToListAsync();
    }

    public async Task<User> GetByIdAsync(int id)
    {
       return await _financeContext.Users.FindAsync(id);
    }

    public async Task UpdateAsync(User user)
    {
        if (user != null)
        {
            _financeContext.Users.Update(user);
            await _financeContext.SaveChangesAsync();
        }
    }
}
