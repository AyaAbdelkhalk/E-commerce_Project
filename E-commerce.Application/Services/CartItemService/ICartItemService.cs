using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using E_commerce.Application.DTOs;
using E_commerce.Application.Hepler;

namespace E_commerce.Application.Services.CartItemService
{
    public interface ICartItemService
    {
        Task<Response<string>> AddToCartAsync(int userId, int productId, int quantity);
        Task<Response<string>> UpdateCartItemQuantityAsync(int cartItemId, int quantity);
        Task<Response<string>> RemoveFromCartAsync(int cartItemId);
        Task<Response<IReadOnlyList<CartItemDTO>>> GetCartItemsByUserIdAsync(int userId);
        Task<Response<string>> ClearCartAsync(int userId);
    }
}
