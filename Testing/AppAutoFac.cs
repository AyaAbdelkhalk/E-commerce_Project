using Autofac;
using E_commerce.Application.Interfaces;
using E_commerce.Application.Services;
using E_commerce.Application.Services.AdminDashboardServices;
using E_commerce.Application.Services.OrderService;
using E_commerce.Application.Services.ProductServices;
using E_commerce.Application.Services.UserServices;
using E_commerce.Infrastructure;
using E_commerce.Infrastructure.Repository;
using System.ComponentModel;

namespace Testing
{
    public class AppAutoFac
    {
        public static Autofac.IContainer Inject()
        {
            var builder = new ContainerBuilder();
            // Register your services here
            // Example: builder.RegisterType<MyService>().As<IMyService>();
            builder.RegisterType<AppDbContext>().AsSelf();
            builder.RegisterType<UserRepository>().As<IUserRepository>();
            builder.RegisterType<UserServices>().As<IUserServices>();

            builder.RegisterType<ProductRepository>().As<IProductRepository>();
            builder.RegisterType<ProductServices>().As<IProductServices>();

            builder.RegisterType<CartItemService>().As<ICartItemService>();
            builder.RegisterType<CartItemRepository>().As<ICartItemRepository>();

            builder.RegisterType<OrderRepository>().As<IOrderRepository>();
            builder.RegisterType<OrderService>().As<IOrderService>();

            builder.RegisterType<CategoryRepository>().As<ICategoryRepository>();
            builder.RegisterType<CategoryServices>().As<ICategoryServices>();

            builder.RegisterType<AdminDashboardService>().As<IAdminDashboardService>();

            var container = builder.Build();
            return container;
        }
    }
}
