using E_commerce.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_commerce.Application.Services.AdminDashboardServices
{
    public class AdminDashboardService : IAdminDashboardService
    {
        private readonly IUserRepository _userRepository;
        private readonly IProductRepository _productRepository;
        private readonly IOrderRepository _orderRepository;
        private readonly ICategoryRepository _categoryRepository;

        public AdminDashboardService(IUserRepository userRepository, IProductRepository productRepository, IOrderRepository orderRepository, ICategoryRepository categoryRepository)
        {
            _userRepository = userRepository;
            _productRepository = productRepository;
            _orderRepository = orderRepository;
            _categoryRepository = categoryRepository;
        }
        public async Task<int> GetTotalUsersAsync()
        {
            var users = await _userRepository.GetAllAsync();
            return users.Count();
        }
        public async Task<int> GetTotalProductsAsync()
        {
            var products = await _productRepository.GetAllAsync();
            return products.Count();
        }
        public async Task<int> GetTotalOrdersAsync()
        {
            var orders = await _orderRepository.GetAllAsync();
            return orders.Count();
        }
        public async Task<int> GetTotalCategoriesAsync()
        {
            var categories = await _categoryRepository.GetAllAsync();
            return categories.Count();
        }
        public async Task<decimal> GetTotalSalesAsync()
        {
            var orders = await _orderRepository.GetAllAsync();
            decimal totalSales = 0;
            foreach (var order in orders)
            {
                totalSales += order.TotalAmount;
            }
            return totalSales;
        }

    }
}
