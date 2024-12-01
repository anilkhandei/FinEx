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
    public class ExpenseRepository : IExpenseRepository
    {
        private readonly FinanceContext _financeContext;
        public ExpenseRepository(FinanceContext financeContext)
        {
            _financeContext = financeContext;
        }

        public async Task AddAsync(Expense expense)
        {
            if (expense != null)
            {
                await _financeContext.Expenses.AddAsync(expense);
                await _financeContext.SaveChangesAsync();
            }
        }

        public async Task DeleteAsync(int id)
        {
            var expense=await GetByIdAsync(id);
            if (expense != null)
            {
                _financeContext.Expenses.Remove(expense);
                await _financeContext.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Expense>> GetAllByUserIdAsync(int UserId)
        {
            return await _financeContext.Expenses.Where(e => e.UserId == UserId).ToListAsync();
        }

        public async Task<Expense> GetByIdAsync(int id)
        {
            return await _financeContext.Expenses.FindAsync(id);
        }

        public async Task UpdateAsync(Expense expense)
        {
            if(expense != null)
            {
                _financeContext.Expenses.Update(expense);
                await _financeContext.SaveChangesAsync();
            }
        }
    }
}
