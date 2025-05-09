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
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        public ProductRepository(AppDbContext context) : base(context)
        {

        }
        public async Task<List<Product>> GetAvailableProductsAsync()
        {
            return await _dbSet
                .Where(p => p.UnitsInStock > 0)
                .Include(p => p.Category)
                .OrderBy(p => p.Name)
                .ToListAsync();
        }

        // filter products by category
        public async Task<List<Product>> GetProductsByCategoryAsync(int categoryId)
        {
            return await _dbSet
                .Where(p => p.CategoryID == categoryId)
                .Include(p => p.Category)
                .OrderBy(p => p.Name)
                .ToListAsync();
        }

        // filter products by name
        public async Task<List<Product>> GetProductsByNameAsync(string name)
        {
            return await _dbSet
                .Where(p => p.Name.Contains(name))
                .Include(p => p.Category)
                .OrderBy(p => p.Name)
                .ToListAsync();
        }
        public async Task<IReadOnlyList<Product>> GetByIdsAsync(IEnumerable<int> productIds)
        {
            return await _dbSet
                .Where(p => productIds.Contains(p.ProductID))
                .ToListAsync();
        }



    }
}
