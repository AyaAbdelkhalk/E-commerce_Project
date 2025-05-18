using E_commerce.Application.DTOs.Order;
using E_commerce.Application.Interfaces;
using E_commerce.Core.Enum;
using E_commerce.Core.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_commerce.Infrastructure.Repository
{
    public class OrderRepository : GenericRepository<Order>, IOrderRepository
    {
        public OrderRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<OrderDisDto> CreateOrderAsync(CreateOrderDto createOrderDto)
        {
            if (createOrderDto == null || createOrderDto.Items == null || !createOrderDto.Items.Any())
            {
                throw new InvalidOperationException("No items provided for the order.");
            }

            // Fetch product details to validate and get prices
            var productIds = createOrderDto.Items.Select(i => i.ProductID).ToList();
            var products = await _context.Products
                .Where(p => productIds.Contains(p.ProductID))
                .ToDictionaryAsync(p => p.ProductID, p => p);

            var orderDetails = new List<OrderDetail>();
            foreach (var item in createOrderDto.Items)
            {
                if (!products.TryGetValue(item.ProductID, out var product))
                {
                    throw new InvalidOperationException($"Product ID {item.ProductID} not found.");
                }
                orderDetails.Add(new OrderDetail
                {
                    ProductID = item.ProductID,
                    Quantity = item.Quantity,
                    Price = product.Price
                });
            }

            // Create order
            var order = new Order
            {
                UserID = createOrderDto.UserID,
                OrderDate = DateTime.UtcNow,
                Status = Status.Pending,
                DateProcessed = DateTime.UtcNow,
                TotalAmount = orderDetails.Sum(od => od.Price * od.Quantity),
                OrderDetails = orderDetails
            };

            await _dbSet.AddAsync(order);
            await _context.SaveChangesAsync();

            // Map to OrderDisDto
            return new OrderDisDto
            {
                OrderID = order.OrderID,
                UserID = order.UserID,
                OrderDate = order.OrderDate,
                TotalAmount = order.TotalAmount,
                Status = order.Status.ToString(),
                DateProcessed = order.DateProcessed,
                OrderDetails = order.OrderDetails.Select(od => new OrderDetailDto
                {
                    ProductID = od.ProductID,
                    ProductName = products[od.ProductID].Name,
                    Price = od.Price,
                    Quantity = od.Quantity
                }).ToList()
            };
        }

        public async Task<List<OrderDisDto>> GetOrderDtosByUserIdAsync(int userId)
        {
            var orders = await _dbSet
                .Where(o => o.UserID == userId)
                .Include(o => o.OrderDetails)
                    .ThenInclude(od => od.Product)
                .ToListAsync();

            return orders.Select(order => new OrderDisDto
            {
                OrderID = order.OrderID,
                UserID = order.UserID,
                OrderDate = order.OrderDate,
                TotalAmount = order.TotalAmount,
                Status = order.Status.ToString(),
                DateProcessed = order.DateProcessed,
                OrderDetails = order.OrderDetails.Select(od => new OrderDetailDto
                {
                    ProductID = od.ProductID,
                    ProductName = od.Product?.Name ?? "Unknown Product",
                    Price = od.Price,
                    Quantity = od.Quantity
                }).ToList()
            }).ToList();
        }

        public Task<IQueryable<Order>> GetOrdersByUserIdAsync(int userId)
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