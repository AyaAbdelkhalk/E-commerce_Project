using E_commerce.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace E_commerce.Application.Interfaces
{
    public interface ICartItemRepository : IGenericRepository<CartItem>
    {
        Task<IEnumerable<CartItem>> GetCartItemsByUserIdAsync(int userId);
        Task DeleteCartItemsByUserIdAsync(int userId);
    }
}