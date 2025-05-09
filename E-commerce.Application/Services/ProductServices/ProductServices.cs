using E_commerce.Application.DTOs.Product;
using E_commerce.Application.Hepler; // عشان Response<T>
using E_commerce.Application.Interfaces;
using E_commerce.Core.Models;
using Mapster;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace E_commerce.Application.Services.ProductServices
{
    public class ProductServices : IProductServices
    {
        private readonly IProductRepository _productRepository;

        public ProductServices(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<Response<List<ProductListDto>>> GetAllProductsAvailableAsync()
        {
            var products = await _productRepository.GetAvailableProductsAsync();
            var data = products.Adapt<List<ProductListDto>>();
            return new Response<List<ProductListDto>>(data);
        }

        public async Task<Response<List<ProductListDto>>> GetProductsByCategoryAsync(int categoryId)
        {
            var products = await _productRepository.GetProductsByCategoryAsync(categoryId);
            var data = products.Adapt<List<ProductListDto>>();
            return new Response<List<ProductListDto>>(data);
        }

        public async Task<Response<List<ProductListDto>>> ProductsSearchByNameAsync(string name)
        {
            var products = await _productRepository.GetProductsByNameAsync(name);
            var data = products.Adapt<List<ProductListDto>>();
            return new Response<List<ProductListDto>>(data);
        }

        public async Task<Response<ProductDetailsDto?>> GetProducByIdAsync(int id)
        {
            var product = await _productRepository.GetByIdAsync(id);
            var data = product?.Adapt<ProductDetailsDto>();
            return new Response<ProductDetailsDto?>(data);
        }

        public async Task<Response<string>> AddProductAsync(CreateProductDto dto, string? localImageFullPath = null)
        {
            try
            { 
                var product = dto.Adapt<Product>();

                if (!string.IsNullOrEmpty(localImageFullPath)) // if images exists
                {
                    string fileName = Path.GetFileName(localImageFullPath);
                    string destPath = Path.Combine("Images", fileName);

                    Directory.CreateDirectory("Images");
                    File.Copy(localImageFullPath, destPath, true);

                    product.ImagePath = destPath;
                }
                else
                {
                    product.ImagePath = "Images/default.png";
                }

                await _productRepository.AddAsync(product);
                return new Response<string>("Product Added Successfully", true);
            }
            catch (Exception ex)
            {
                return new Response<string>
                {
                    Succeeded = false,
                    Errors = new List<string> { ex.Message }
                };
            }

        }

        public async Task<Response<string>> UpdateProductAsync(int id, UpdateProductDto dto, string? localImageFullPath = null)
        {
            try
            {
                var existingProduct = await _productRepository.GetByIdAsync(id);
                if (existingProduct == null)
                    return new Response<string>("Product Not Found", false);

                dto.Adapt(existingProduct);

                if (!string.IsNullOrEmpty(localImageFullPath))
                {
                    string fileName = Path.GetFileName(localImageFullPath);
                    string destPath = Path.Combine("Images", fileName);

                    Directory.CreateDirectory("Images");
                    File.Copy(localImageFullPath, destPath, true);

                    existingProduct.ImagePath = destPath;
                }
                //if the image path is not provided, keep the existing one
                existingProduct.ImagePath ??= "Images/default.png";

                await _productRepository.UpdateAsync(existingProduct);
                return new Response<string>("Updated Successfully", true);
            }
            catch (Exception ex)
            {
                return new Response<string>
                {
                    Succeeded = false,
                    Errors = new List<string> { ex.Message }
                };
            }
        }

        
        public async Task<Response<string>> DeleteProductAsync(int id)
        {
            try
            {
                var product = await _productRepository.GetByIdAsync(id);
                if (product == null)
                    return new Response<string>("Product Not Found", false);

                await _productRepository.DeleteAsync(product.ProductID);
                return new Response<string>("Product Deleted Successfully", true);
            }
            catch (Exception ex)
            {
                return new Response<string>
                {
                    Succeeded = false,
                    Errors = new List<string> { ex.Message }
                };
            }
        }
    }
}
