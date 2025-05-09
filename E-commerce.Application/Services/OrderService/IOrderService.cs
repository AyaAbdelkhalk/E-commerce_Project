using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_commerce.Application.Services.OrderService
{
    public interface IOrderService
    {
        Task<int> CheckoutAsync(int userId);
        Task ProcessOrderAsync(int orderId);
        Task CancelOrderAsync(int orderId);
    }
}
