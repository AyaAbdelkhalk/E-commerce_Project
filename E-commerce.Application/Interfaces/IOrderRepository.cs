using E_commerce.Application.DTOs.Order;
using E_commerce.Core.Enum;
using E_commerce.Core.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_commerce.Application.Interfaces
{
    public interface IOrderRepository : IGenericRepository<Order>
    {
        Task<IQueryable<Order>> GetOrdersByUserIdAsync(int userId);
        Task<IQueryable<Order>> GetOrdersByStatusAsync(Status? status = null);
        Task<OrderDisDto> CreateOrderAsync(CreateOrderDto createOrderDto);
        Task<List<OrderDisDto>> GetOrderDtosByUserIdAsync(int userId);
    }
}