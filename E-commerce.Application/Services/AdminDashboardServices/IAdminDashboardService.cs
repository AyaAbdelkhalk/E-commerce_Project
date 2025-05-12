using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_commerce.Application.Services.AdminDashboardServices
{
    public interface IAdminDashboardService 
    {
        Task<int> GetTotalUsersAsync();
        Task<int> GetTotalProductsAsync();
        Task<int> GetTotalOrdersAsync();
        Task<int> GetTotalCategoriesAsync();
        Task<decimal> GetTotalSalesAsync();
        //Task<decimal> GetTotalRevenueAsync();
        //Task<List<string>> GetTopSellingProductsAsync(int count);
        //Task<List<string>> GetTopCategoriesAsync(int count);
    }
}
