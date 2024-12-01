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
    public class CategoryRepository : ICategoryRepository
    {
        private readonly FinanceContext _context;
        public CategoryRepository(FinanceContext context)
        {
            _context = context;
        }
        public async Task AddAsync(Category category)
        {
            if (category != null)
            {
                await _context.Categories.AddAsync(category);
                await _context.SaveChangesAsync();
            }
        }
        public async Task DeleteAsync(int id)
        {
            var category=await GetByIdAsync(id);
            if (category != null) 
            { 
                _context.Categories.Remove(category);
                await _context.SaveChangesAsync();
            }
        }
        public async Task<List<Category>> GetAllAsync()
        {
            return await _context.Categories.ToListAsync();
        }

        public async Task<Category> GetByIdAsync(int id)
        {
            return await _context.Categories.FindAsync(id);
        }
        public async Task UpdateAsync(Category category)
        {
            if (category != null)
            {
                _context.Categories.Update(category);
                await _context.SaveChangesAsync();
            }
        }
    }
}
