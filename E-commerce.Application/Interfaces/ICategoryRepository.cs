using E_commerce.Core.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_commerce.Application.Interfaces
{
    public interface ICategoryRepository : IGenericRepository<Category>
    {
        public Task<bool> CheckIfCategoryExistsAsync(string name);


        public Task<Category?> GetCategoryWithProductsByIdAsync(int id);

        public Task<List<Category>> SearchCategoriesAsync(string keyword);


        public Task<List<Category>> GetCategoriesWithProductsAsync();

    }
}
