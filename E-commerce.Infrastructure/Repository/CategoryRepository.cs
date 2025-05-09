using E_commerce.Application.Interfaces;
using E_commerce.Core.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_commerce.Infrastructure.Repository
{
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(AppDbContext context) : base(context)
        {
        }


        public async Task<bool> CheckIfCategoryExistsAsync(string name)
        {
            return await _dbSet.AnyAsync(c => c.Name.ToLower() == name.ToLower());
        }


        public async Task<Category?> GetCategoryWithProductsByIdAsync(int id)
        {
            return await _dbSet
                .Include(c => c.Products)
                .FirstOrDefaultAsync(c => c.CategoryID == id);
        }

        public async Task<List<Category>> SearchCategoriesAsync(string keyword)
        {
            return await _dbSet
                .Where(c => c.Name.ToLower().Contains(keyword.ToLower()))
                .OrderBy(c => c.Name)
                .ToListAsync();
        }


        public async Task<List<Category>> GetCategoriesWithProductsAsync()
        {
            return await _dbSet
                .Include(c => c.Products)
                .OrderBy(c => c.Name)
                .ToListAsync();
        }


       

    }
}
