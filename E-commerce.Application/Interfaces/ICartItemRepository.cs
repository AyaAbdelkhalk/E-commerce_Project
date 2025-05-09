using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using E_commerce.Core.Models;

namespace E_commerce.Application.Interfaces
{
    public interface ICartItemRepository : IGenericRepository<CartItem>
    {
        public Task<IReadOnlyList<CartItem>> GetCartItemByUserIdAsync(int userId);
    }
}
