using E_commerce.Application.DTOs.Product;
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
    public interface IProductServices
    {
        public Task<Response<List<ProductListDto>>> GetAllProductsAvailableAsync();

        public Task<Response<List<ProductListDto>>> GetProductsByCategoryAsync(int categoryId);

        public Task<Response<List<ProductListDto>>> ProductsSearchByNameAsync(string name);

        public Task<Response<ProductDetailsDto?>> GetProducByIdAsync(int id);

        public Task<Response<string>> AddProductAsync(CreateProductDto dto, string? localImageFullPath = null);

        public Task<Response<string>> UpdateProductAsync(int id, UpdateProductDto dto, string? localImageFullPath = null);

        public Task<Response<string>> DeleteProductAsync(int id);
    }
}
