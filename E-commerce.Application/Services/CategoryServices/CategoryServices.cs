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
    public class CategoryServices : ICategoryServices
    {
        public readonly ICategoryRepository _categoryRepository;

        public CategoryServices(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<bool> CheckIfCategoryExistsAsync(string name)
        {
            return await _categoryRepository.CheckIfCategoryExistsAsync(name);
        }

        public async Task<Response<List<CategoryWithProductsDto>>> GetAllCategoriesWithProductsAsync()
        {
            var categories = await _categoryRepository.GetCategoriesWithProductsAsync();
            var data = categories.Adapt<List<CategoryWithProductsDto>>();
            return new Response<List<CategoryWithProductsDto>>(data);

        }
        public async Task<Response<CategoryWithProductsDto?>> GetCategoryWithProductsByIdAsync(int id)
        {
            var category = await _categoryRepository.GetCategoryWithProductsByIdAsync(id);
            var data = category?.Adapt<CategoryWithProductsDto>();
            return new Response<CategoryWithProductsDto?>(data);
        }

        public async Task<Response<List<CategoryWithProductsDto>>> SearchCategoriesAsync(string keyword)
        {
                var categories = await _categoryRepository.SearchCategoriesAsync(keyword);
                var data = categories.Adapt<List<CategoryWithProductsDto>>();
                return new Response<List<CategoryWithProductsDto>>(data);
        }
        public async Task<Response<string>> AddCategoryAsync(CategoryDto dto)
        {
            try
            {
                bool exists = await _categoryRepository.CheckIfCategoryExistsAsync(dto.Name);
                if (exists)
                {
                    return new Response<string>
                    {
                        Succeeded = false,
                        Errors = new List<string> { "Category with the same name already exists." },
                        Data = null
                    };
                }

                var category = dto.Adapt<Category>();

                await _categoryRepository.AddAsync(category);

                return new Response<string>("Category added successfully.", true);
            }
            catch (Exception ex)
            {
                return new Response<string>
                {
                    Succeeded = false,
                    Errors = new List<string> { ex.Message },
                    Data = null
                };
            }
        }

        public async Task<Response<string>> UpdateCategoryAsync(UpdateCategoryDto dto)
        {
            try
            {
                var category = await _categoryRepository.GetByIdAsync(dto.CategoryID);
                if (category == null)
                {
                    return new Response<string>
                    {
                        Succeeded = false,
                        Errors = new List<string> { "Category not found." },
                        Data = null
                    };
                }
                category.Name = dto.Name;
                category.Description = dto.Description;
                await _categoryRepository.UpdateAsync(category);
                return new Response<string>("Category updated successfully.", true);
            }
            catch (Exception ex)
            {
                return new Response<string>
                {
                    Succeeded = false,
                    Errors = new List<string> { ex.Message },
                    Data = null
                };
            }
        }

        public async Task<Response<string>> DeleteCategoryAsync(int id)
        {
            try
            {
                var category = await _categoryRepository.GetByIdAsync(id);
                if (category == null)
                {
                    return new Response<string>
                    {
                        Succeeded = false,
                        Errors = new List<string> { "Category not found." },
                        Data = null
                    };
                }
                await _categoryRepository.DeleteAsync(category.CategoryID);
                return new Response<string>("Category deleted successfully.", true);
            }
            catch (Exception ex)
            {
                return new Response<string>
                {
                    Succeeded = false,
                    Errors = new List<string> { ex.Message },
                    Data = null
                };
            }
        }




    }

}
