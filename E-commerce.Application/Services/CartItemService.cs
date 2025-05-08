using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using E_commerce.Application.DTOs;
using E_commerce.Application.Interfaces;
using E_commerce.Core.Models;

namespace E_commerce.Application.Services
{
    public class CartItemService : ICartItemService
    {
        private readonly ICartItemRepository _cartItemRepository;
        private readonly IProductRepository _productRepository;
        public CartItemService(ICartItemRepository cartItemRepository, IProductRepository productRepository)
        {
            _cartItemRepository = cartItemRepository;
            _productRepository = productRepository;
        }
        public async Task AddToCartAsync(int userId, int productId, int quantity)
        {
            if (quantity <= 0)
                throw new ArgumentException("Quantity must be greater than zero.");

            var product = await _productRepository.GetByIdAsync(productId);
            if (product == null)
                throw new ArgumentException("Product not found.");
            if (product.UnitsInStock < quantity)
                throw new ArgumentException("Insufficient stock.");

            var cartItem = new CartItem
            {
                UserID = userId,
                ProductID = productId,
                Quantity = quantity,
                DateAdded = DateTime.UtcNow
            };

            await _cartItemRepository.AddAsync(cartItem);
        }
        public async Task UpdateCartItemQuantityAsync(int cartItemId, int quantity)
        {
            if (quantity <= 0)
                throw new ArgumentException("Quantity must be greater than zero.");

            var cartItem = await _cartItemRepository.GetByIdAsync(cartItemId);
            if (cartItem == null)
                throw new ArgumentException("Cart item not found.");

            var product = await _productRepository.GetByIdAsync(cartItem.ProductID);
            if (product == null)
                throw new ArgumentException("Product not found.");
            if (product.UnitsInStock < quantity)
                throw new ArgumentException("Insufficient stock.");

            cartItem.Quantity = quantity;
            await _cartItemRepository.UpdateAsync(cartItem);
        }

        public async Task RemoveFromCartAsync(int cartItemId)
        {
            var cartItem = await _cartItemRepository.GetByIdAsync(cartItemId);
            if (cartItem == null)
                throw new ArgumentException("Cart item not found.");

            await _cartItemRepository.DeleteAsync(cartItemId);
        }

        public async Task<IEnumerable<CartItemDTO>> GetUserCartItemsAsync(int userId)
        {
            var cartItems = await _cartItemRepository.GetCartItemByUserIdAsync(userId);
            return cartItems.Select(ci => new CartItemDTO
            {
                CartItemID = ci.CartItemID,
                UserID = ci.UserID,
                ProductID = ci.ProductID,
                Name = ci.Product.Name,
                Price = ci.Product?.Price ?? 0,
                Quantity = ci.Quantity,
                DateAdded = ci.DateAdded
            }).ToList();
        }

        public async Task ClearCartAsync(int userId)
        {

            var cartItems = await _cartItemRepository.GetCartItemByUserIdAsync(userId);
            foreach (var cartItem in cartItems)
            {
                await _cartItemRepository.DeleteAsync(cartItem.CartItemID);
            }
        }
    }
}
