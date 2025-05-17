using E_commerce.Core.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_commerce.Application.Interfaces
{
    public interface IProductRepository : IGenericRepository<Product>
    {
        public Task<List<Product>> GetAllProductsAsync();

        public Task<List<Product>> GetAvailableProductsAsync();

        public Task<List<Product>> GetProductsByCategoryAsync(int categoryId);

        public Task<List<Product>> GetProductsByNameAsync(string name);
        public Task<IReadOnlyList<Product>> GetByIdsAsync(IEnumerable<int> productIds);
        public Task<Dictionary<string, int>> GetProductsByCategoryAsync();
    }
}
