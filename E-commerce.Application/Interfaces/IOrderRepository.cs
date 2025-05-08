using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_commerce.Application.Interfaces
{
    public class IOrderRepository:IGenericRepository<Order>
    {
        Task<IQueryable<Order>> GetOrdersByUserIdAsync(int userId);

    }
}
