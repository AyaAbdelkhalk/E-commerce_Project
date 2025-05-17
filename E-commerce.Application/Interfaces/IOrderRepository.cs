using E_commerce.Core.Enum;
using E_commerce.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_commerce.Application.Interfaces
{
    public interface IOrderRepository: IGenericRepository<Order>
    {
        public Task<IQueryable<Order>> GetOrdersByUserIdAsync(int userId);
        public Task<IQueryable<Order>> GetOrdersByStatusAsync(Status? status = null);

    }
}
