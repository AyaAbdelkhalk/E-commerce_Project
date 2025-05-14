using E_commerce.Application.DTOs;
using E_commerce.Application.DTOs.CartItem;
using E_commerce.Application.Hepler;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace E_commerce.Application.Services
{
    public interface ICartItemService
    {
        Task<Response<IEnumerable<CartItemDTO>>> GetCartItemsByUserIdAsync(int userId);
        Task<Response<CartItemDTO>> AddCartItemAsync(CreateCartItemDTO cartItemDto);
        Task<Response<CartItemDTO>> UpdateCartItemAsync(UpdateCartItemDTO cartItemDto);
        Task<Response<bool>> RemoveCartItemAsync(int cartItemId);
        Task<Response<bool>> ClearCartAsync(int userId);
    }
}