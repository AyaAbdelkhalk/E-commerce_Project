using E_commerce.Application.DTOs.Category;
using E_commerce.Application.Hepler;
using E_commerce.Application.Interfaces;
using E_commerce.Core.Models;
using Mapster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_commerce.Application.Services
{
    public interface ICategoryServices
    {
        public Task<Response<List<CategoryWithProductsDto>>> GetAllCategoriesWithProductsAsync();

        public Task<bool> CheckIfCategoryExistsAsync(string name);

        public Task<Response<CategoryWithProductsDto?>> GetCategoryWithProductsByIdAsync(int id);

        public Task<Response<List<CategoryWithProductsDto>>> SearchCategoriesAsync(string keyword);
        public Task<Response<string>> AddCategoryAsync(CategoryDto dto);
        public Task<Response<string>> UpdateCategoryAsync(UpdateCategoryDto dto);

        public Task<Response<string>> DeleteCategoryAsync(int id);
    }
}
