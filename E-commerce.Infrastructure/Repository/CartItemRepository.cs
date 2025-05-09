using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using E_commerce.Application.Interfaces;
using E_commerce.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace E_commerce.Infrastructure.Repository
{
    public class CartItemRepository : GenericRepository<CartItem>, ICartItemRepository
    {

        public CartItemRepository(AppDbContext context) : base(context) { }

        public async Task<IReadOnlyList<CartItem>> GetCartItemByUserIdAsync(int userId)
        {
            return await _dbSet
                .Where(ci => ci.UserID == userId)
                .ToListAsync();
        }
        public async Task<CartItem?> GetCartItemByUserIdAndProductIdAsync(int userId, int productId)
        {
            if(_dbSet != null)
            {
                return await _dbSet
                    .Where(ci => ci.UserID == userId && ci.ProductID == productId)
                    .FirstOrDefaultAsync();
            }
            return null;

        }
    }
}
