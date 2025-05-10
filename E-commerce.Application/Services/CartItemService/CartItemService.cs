using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using E_commerce.Application.DTOs;
using E_commerce.Application.DTOs.CartItem;
using E_commerce.Application.Helper;
using E_commerce.Application.Hepler;
using E_commerce.Application.Interfaces;
using E_commerce.Core.Models;
using Mapster;

namespace E_commerce.Application.Services.CartItemService
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

        public async Task<Response<string>> AddToCartAsync(int userId, int productId, int quantity)
        {
            try
            {
                if (quantity <= 0)
                {
                    return new Response<string>
                    {
                        Succeeded = false,
                        Errors = new List<string> { "Quantity must be greater than zero" }
                    };
                }

                var product = await _productRepository.GetByIdAsync(productId);
                if (product == null)
                {
                    return new Response<string>
                    {
                        Succeeded = false,
                        Errors = new List<string> { "Product not found" }
                    };
                }

                if (product.UnitsInStock < quantity)
                {
                    return new Response<string>
                    {
                        Succeeded = false,
                        Errors = new List<string> { "Insufficient stock" }
                    };
                }

                var createCartItemDTO = new CreateCartItemDTO
                {
                    UserID = SessionManager.CurrentUser.UserID,
                    ProductID = productId,
                    Quantity = quantity
                };
                var cartItem = createCartItemDTO.Adapt<CartItem>();
                await _cartItemRepository.AddAsync(cartItem);
                return new Response<string>("Item added to cart successfully");
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

        public async Task<Response<string>> ClearCartAsync(int userId)
        {
            try
            {
                var cartItems = await _cartItemRepository.GetCartItemByUserIdAsync(SessionManager.CurrentUser.UserID);
                foreach (var cartItem in cartItems)
                {
                    await _cartItemRepository.DeleteAsync(cartItem.CartItemID);
                }
                return new Response<string>("Cart cleared successfully");
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

        public async Task<Response<IReadOnlyList<CartItemDTO>>> GetCartItemsByUserIdAsync(int userId)
        {
            try
            {
                var cartItems = await _cartItemRepository.GetCartItemByUserIdAsync(SessionManager.CurrentUser.UserID);
                var productIds = cartItems.Select(ci => ci.ProductID).Distinct().ToList();
                var products = await _productRepository.GetByIdsAsync(productIds); // Fetch only relevant products
                var productDict = products.ToDictionary(p => p.ProductID, p => p);

                foreach (var cartItem in cartItems)
                {
                    if (productDict.TryGetValue(cartItem.ProductID, out var product))
                    {
                        cartItem.Product = product; // Set Product to avoid lazy loading during mapping
                    }
                }

                var data = cartItems.Adapt<IReadOnlyList<CartItemDTO>>();
                return new Response<IReadOnlyList<CartItemDTO>>(data);
            }
            catch (Exception ex)
            {
                return new Response<IReadOnlyList<CartItemDTO>>
                {
                    Succeeded = false,
                    Errors = new List<string> { ex.Message }
                };
            }
        }

        public async Task<Response<string>> RemoveFromCartAsync(int cartItemId)
        {
            try
            {
                var cartItem = await _cartItemRepository.GetByIdAsync(cartItemId);
                if (cartItem == null)
                {
                    return new Response<string>
                    {
                        Succeeded = false,
                        Errors = new List<string> { "Cart item not found" }
                    };
                }

                await _cartItemRepository.DeleteAsync(cartItemId);
                return new Response<string>("Item removed from cart successfully");
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

        public async Task<Response<string>> UpdateCartItemQuantityAsync(int cartItemId, int quantity)
        {
            try
            {
                if (quantity <= 0)
                {
                    return new Response<string>
                    {
                        Succeeded = false,
                        Errors = new List<string> { "Quantity must be greater than zero" }
                    };
                }

                var cartItem = await _cartItemRepository.GetByIdAsync(cartItemId);
                if (cartItem == null)
                {
                    return new Response<string>
                    {
                        Succeeded = false,
                        Errors = new List<string> { "Cart item not found" }
                    };
                }

                var product = await _productRepository.GetByIdAsync(cartItem.ProductID);
                if (product == null)
                {
                    return new Response<string>
                    {
                        Succeeded = false,
                        Errors = new List<string> { "Product not found" }
                    };
                }

                if (product.UnitsInStock < quantity)
                {
                    return new Response<string>
                    {
                        Succeeded = false,
                        Errors = new List<string> { "Insufficient stock" }
                    };
                }

                var updateCartItemDTO = new UpdateCartItemDTO
                {
                    CartItemID = cartItemId,
                    Quantity = quantity
                };
                updateCartItemDTO.Adapt(cartItem);
                await _cartItemRepository.UpdateAsync(cartItem);
                return new Response<string>("Quantity updated successfully");
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
