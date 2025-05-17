using E_commerce.Application.Interfaces;
using E_commerce.Core.Enum;
using E_commerce.Core.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_commerce.Infrastructure.Repository
{
    public  class OrderRepository: GenericRepository<Order>, IOrderRepository
    {
        public OrderRepository(AppDbContext context) : base(context)
        {
        }


        public Task<IQueryable<Order>>GetOrdersByUserIdAsync(int userId)
        {
            var orders = _dbSet.Where(o => o.UserID == userId).AsQueryable();
            return Task.FromResult(orders);
        }
        public Task<IQueryable<Order>> GetOrdersByStatusAsync(Status? status = null)
        {
            var orders = _dbSet.AsQueryable();
            if (status.HasValue)
            {
                orders = orders.Where(o => o.Status == status.Value);
            }
            return Task.FromResult(orders);
        }
    }
   
}
