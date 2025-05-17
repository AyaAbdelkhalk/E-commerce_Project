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

      
        public async Task<Dictionary<string, int>> GetOrdersByCategoryAsync()
        {
            var result = await _dbSet
                .Include(o => o.OrderDetails)
                    .ThenInclude(od => od.Product)
                        .ThenInclude(p => p.Category)
                .SelectMany(order => order.OrderDetails)
                .GroupBy(od => od.Product.Category.Name)
                .Select(g => new
                {
                    CategoryName = g.Key,
                    OrderCount = g.Select(od => od.OrderID).Distinct().Count()
                })
                .ToDictionaryAsync(x => x.CategoryName, x => x.OrderCount);
            return result ?? new Dictionary<string, int>();
        }

        public Task<Dictionary<string, int>> GetMonthlyOrdersAsync(int months)
        {
            var orders = _dbSet
                .Where(o => o.OrderDate >= DateTime.Now.AddMonths(-months))
                .GroupBy(o => new { o.OrderDate.Year, o.OrderDate.Month })
                .Select(g => new
                {
                    MonthYear = $"{g.Key.Year}-{g.Key.Month}",
                    OrderCount = g.Count()
                });
            var monthlyOrders = orders.ToDictionaryAsync(x => x.MonthYear, x => x.OrderCount);
            return monthlyOrders;
        }

        public async Task<List<Order>> GetRecentOrdersAsync(int count)
        {
            var recentOrders = await _dbSet
                .Include(o => o.User)
                .Include(o => o.OrderDetails)
                .OrderByDescending(o => o.OrderDate)
                .Take(count)
                .ToListAsync();
            return recentOrders ?? new List<Order>();
        }
        public async Task<List<Order>> GetAllOrdersAsync()
        {
            return await _dbSet
                .Include(o => o.User)
                .Include(o => o.OrderDetails)
                .ToListAsync();
        }

        public async Task<Dictionary<string, decimal>> GetMonthlyOrderAmount()
        {
            var startDate = DateTime.Now.AddMonths(-11).Date; // بداية من الشهر اللي فات 12 شهر
            var endDate = DateTime.Now.Date;

            var monthlySales = await _dbSet
                .Where(o => o.OrderDate >= startDate && o.OrderDate <= endDate)
                .GroupBy(o => new { o.OrderDate.Year, o.OrderDate.Month })
                .Select(g => new
                {
                    MonthYear = $"{g.Key.Year}-{g.Key.Month:D2}",
                    TotalAmount = g.Sum(o => o.OrderDate == null ? 0m : o.TotalAmount)
                })
                .ToListAsync();

            var result = new Dictionary<string, decimal>();
            for (var date = startDate; date <= endDate; date = date.AddMonths(1))
            {
                string monthYear = date.ToString("yyyy-MM");
                result[monthYear] = monthlySales.FirstOrDefault(x => x.MonthYear == monthYear)?.TotalAmount ?? 0;
            }

            return result;
        }
    }
   
}
