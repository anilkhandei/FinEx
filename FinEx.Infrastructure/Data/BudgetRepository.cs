using FinEx.Core.Entities;
using FinEx.Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinEx.Infrastructure.Data
{
    public class BudgetRepository : IBudgetRepository
    {
        private readonly FinanceContext _context;
        public BudgetRepository(FinanceContext context)
        {
            _context = context;
        }
        public async Task AddAsync(Budget budget)
        {
            if (budget != null)
            {
                await _context.Budgets.AddAsync(budget);
                await _context.SaveChangesAsync();
            }

        }

        public async Task DeleteAsync(int id)
        {
            var budget= await GetByIdAsync(id);
            if (budget != null)
            {
                _context.Budgets.Remove(budget);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Budget>> GetAllByUserIdAsync(int userId)
        {
            return await _context.Budgets.Where(x => x.UserId == userId).ToListAsync();
        }

        public async Task<Budget> GetByIdAsync(int id)
        {
            return await _context.Budgets.FindAsync(id);   
        }

        public async Task UpdateAsync(Budget budget)
        {
            if(budget != null)
            {
                _context.Budgets.Remove(budget);
                await _context.SaveChangesAsync();
            }
        }
    }
}
