using E_commerce.Application.Interfaces;
using E_commerce.Core.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_commerce.Infrastructure.Repository
{
    public class CartItemRepository : GenericRepository<CartItem>, ICartItemRepository
    {
        private readonly AppDbContext _context;

        public CartItemRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<CartItem>> GetCartItemsByUserIdAsync(int userId)
        {
            // Eagerly load Product to avoid lazy loading multiple queries
            return await _dbSet
                .Include(ci => ci.Product)
                .Where(ci => ci.UserID == userId)
                .ToListAsync();
        }

        public async Task DeleteCartItemsByUserIdAsync(int userId)
        {
            var cartItems = await _dbSet
                .Where(ci => ci.UserID == userId)
                .ToListAsync();
            if (cartItems.Any())
            {
                _dbSet.RemoveRange(cartItems);
                await _context.SaveChangesAsync();
            }
        }
    }
}