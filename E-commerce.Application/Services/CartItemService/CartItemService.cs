using E_commerce.Application.DTOs;
using E_commerce.Application.DTOs.CartItem;
using E_commerce.Application.Hepler;
using E_commerce.Application.Interfaces;
using E_commerce.Core.Models;
using Mapster;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_commerce.Application.Services
{
    public class CartItemService : ICartItemService
    {
        private readonly ICartItemRepository _cartItemRepository;
        private readonly IGenericRepository<Product> _productRepository;

        public CartItemService(ICartItemRepository cartItemRepository, IGenericRepository<Product> productRepository)
        {

            _cartItemRepository = cartItemRepository;
            _productRepository = productRepository;
        }

        public async Task<Response<IEnumerable<CartItemDTO>>> GetCartItemsByUserIdAsync(int userId)
        {
            var cartItems = await _cartItemRepository.GetCartItemsByUserIdAsync(userId);
            var cartItemDtos = cartItems.Adapt<IEnumerable<CartItemDTO>>();
            return new Response<IEnumerable<CartItemDTO>>(cartItemDtos);
        }

        public async Task<Response<CartItemDTO>> AddCartItemAsync(CreateCartItemDTO cartItemDto)
        {
            var response = new Response<CartItemDTO>();

            // Validate input
            if (cartItemDto.Quantity <= 0)
            {
                response.Succeeded = false;
                response.Errors.Add("Quantity must be greater than zero.");
                return response;
            }

            // Validate product exists
            var product = await _productRepository.GetByIdAsync(cartItemDto.ProductID);
            if (product == null)
            {
                response.Succeeded = false;
                response.Errors.Add("Product not found.");
                return response;
            }

            // Validate stock availability
            if (product.UnitsInStock < cartItemDto.Quantity)
            {
                response.Succeeded = false;
                response.Errors.Add("Insufficient stock for the requested quantity.");
                return response;
            }

            // Check if item already exists in cart
            var existingCartItems = await _cartItemRepository.GetCartItemsByUserIdAsync(cartItemDto.UserID);
            var existingCartItem = existingCartItems.FirstOrDefault(ci => ci.ProductID == cartItemDto.ProductID);
            if (existingCartItem != null)
            {
                // Update quantity if item exists
                existingCartItem.Quantity += cartItemDto.Quantity;
                if (product.UnitsInStock < existingCartItem.Quantity)
                {
                    response.Succeeded = false;
                    response.Errors.Add("Insufficient stock for the updated quantity.");
                    return response;
                }
                await _cartItemRepository.UpdateAsync(existingCartItem);
                var updatedDto = existingCartItem.Adapt<CartItemDTO>();
                return new Response<CartItemDTO>(updatedDto);
            }

            // Add new cart item
            var cartItem = cartItemDto.Adapt<CartItem>();
            cartItem.DateAdded= DateTime.Now;
            var addedCartItem = await _cartItemRepository.AddAsync(cartItem);
            var addedCartItemDto = addedCartItem.Adapt<CartItemDTO>();
            return new Response<CartItemDTO>(addedCartItemDto);
        }

        public async Task<Response<CartItemDTO>> UpdateCartItemAsync(UpdateCartItemDTO cartItemDto)
        {
            var response = new Response<CartItemDTO>();

            // Validate input
            if (cartItemDto.Quantity <= 0)
            {
                response.Succeeded = false;
                response.Errors.Add("Quantity must be greater than zero.");
                return response;
            }

            var cartItem = await _cartItemRepository.GetByIdAsync(cartItemDto.CartItemID);
            if (cartItem == null)
            {
                response.Succeeded = false;
                response.Errors.Add("Cart item not found.");
                return response;
            }

            // Validate product stock
            var product = await _productRepository.GetByIdAsync(cartItem.ProductID);
            if (product == null)
            {
                response.Succeeded = false;
                response.Errors.Add("Product not found.");
                return response;
            }

            if (product.UnitsInStock < cartItemDto.Quantity)
            {
                response.Succeeded = false;
                response.Errors.Add("Insufficient stock for the requested quantity.");
                return response;
            }

            cartItem.Quantity = cartItemDto.Quantity;
            cartItem.DateAdded = DateTime.UtcNow;
            var updatedCartItem = await _cartItemRepository.UpdateAsync(cartItem);
            var updatedCartItemDto = updatedCartItem.Adapt<CartItemDTO>();
            return new Response<CartItemDTO>(updatedCartItemDto);
        }

        public async Task<Response<bool>> RemoveCartItemAsync(int cartItemId)
        {
            var response = new Response<bool>();

            var cartItem = await _cartItemRepository.GetByIdAsync(cartItemId);
            if (cartItem == null)
            {
                response.Succeeded = false;
                response.Errors.Add("Cart item not found.");
                return response;
            }

            await _cartItemRepository.DeleteAsync(cartItemId);
            return new Response<bool>(true);
        }

        public async Task<Response<bool>> ClearCartAsync(int userId)
        {
            await _cartItemRepository.DeleteCartItemsByUserIdAsync(userId);
            return new Response<bool>(true);
        }
    }
}