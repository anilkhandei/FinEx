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
    public class IncomeRepository : IIncomeRepository
    {
        private readonly FinanceContext _context;

        public IncomeRepository(FinanceContext context)
        {
            _context = context;
        }
        public async Task AddAsync(Income income)
        {
            if (income != null) 
            {
                _context.Incomes.Add(income);
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteAsync(int id)
        {
           var income=await GetByIdAsync(id);
            if (income != null)
            {
                _context.Incomes.Remove(income);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Income>> GetAllByUserIdAsync(int userId)
        {
            return await _context.Incomes.Where(x=>x.UserId == userId).ToListAsync();
        }

        public async Task<Income> GetByIdAsync(int id)
        {
           return await _context.Incomes.FindAsync(id);
        }

        public async Task UpdateAsync(Income income)
        {
            if (income != null)
            {
                _context.Incomes.Update(income);
                await _context.SaveChangesAsync();
            }
        }
    }
}
