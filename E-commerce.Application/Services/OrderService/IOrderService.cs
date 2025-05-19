using E_commerce.Application.DTOs.Order;
using E_commerce.Application.Hepler;
using E_commerce.Core.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_commerce.Application.Services.OrderService
{
    public interface IOrderService
    {
        Task<List<OrderDisDto>> GetAllOrdersAsync2();
        Task<Response<OrderDisDto>> CheckoutAsync(int userId);
        Task ProcessOrderAsync(int orderId);
        Task<Response<string>> CancelOrderAsync(int orderId);

        //Admin      
        Task<Response<string>> ApproveOrderAsync(int orderId);
        //Admin  
        Task<Response<string>> DenyOrderAsync(int orderId);
        //Admin  
        Task<List<OrderDisDto>> GetOrdersByStatusAsync(Status? status = null);
        Task<List<OrderDisDto>> GetOrderHistoryByUserIdAsync(int userId);

        //for  admin dashboard
        Task<int> GetTotalOrders();

        Task<List<OrderDto>> GetRecentOrders(int count);

        Task<Dictionary<string, int>> GetOrdersByCategory();

        public Task<int> GetAllOrdersAsync();

        public Task<Dictionary<string, decimal>> GetMonthlyOrderAmountAsync();


    }
}
