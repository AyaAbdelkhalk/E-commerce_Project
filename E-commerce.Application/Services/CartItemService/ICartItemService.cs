using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using E_commerce.Application.DTOs;

namespace E_commerce.Application.Services.CartItemService
{
    public interface ICartItemService
    {
        Task AddToCartAsync(int userId, int productId, int quantity);
        Task UpdateCartItemQuantityAsync(int cartItemId, int quantity);
        Task RemoveFromCartAsync(int cartItemId);
        Task<IEnumerable<CartItemDTO>> GetUserCartItemsAsync(int userId);
        Task ClearCartAsync(int userId);
    }
}
