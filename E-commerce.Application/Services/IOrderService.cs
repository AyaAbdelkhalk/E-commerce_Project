using E_commerce.Application.DTOs.Order;
using E_commerce.Application.Hepler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_commerce.Application.Services
{
    public interface IOrderService
    {
        Task<Response<OrderDisDto>> CheckoutAsync(int userId);
        Task ProcessOrderAsync(int orderId);
        Task<Response<string>> CancelOrderAsync(int orderId);
    }
}
