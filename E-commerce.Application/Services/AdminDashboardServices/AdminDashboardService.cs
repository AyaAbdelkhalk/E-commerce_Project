using E_commerce.Application.Interfaces;
using E_commerce.Application.Services.OrderService;
using E_commerce.Application.Services.ProductServices;
using E_commerce.Application.Services.UserServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_commerce.Application.Services.AdminDashboardServices
{
    public class AdminDashboardService : IAdminDashboardService
    {
        private readonly IUserServices _userServices;
        private readonly IProductServices _productServices;
        private readonly IOrderService _orderServices;
        private readonly ICategoryServices _categoryServices;

        public AdminDashboardService(IUserServices userServices, IProductServices productRepository, IOrderService orderRepository, ICategoryServices categoryRepository)
        {
            _userServices = userServices;
            _productServices = productRepository;
            _orderServices = orderRepository;
            _categoryServices = categoryRepository;
        }

        public async Task<int> GetTotalUsersAsync()
        {
            var users = await _userServices.GetAllUsers();
            return users.Data.Count();
        }
        public async Task<int> GetTotalProductsAsync()
        {
            var prds = await _productServices.GetAllProductsAvailableAsync();
            return prds.Data.Count();
        }
        public async Task<int> GetTotalCategoriesAsync()
        {
            var categories = await _categoryServices.GetAllCategoriesWithProductsAsync();
            return categories.Data.Count();
        }
        

    }
}
