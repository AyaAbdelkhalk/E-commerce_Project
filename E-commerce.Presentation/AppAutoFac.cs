using Autofac;
using E_commerce.Application.Helper;
using E_commerce.Application.Interfaces;
using E_commerce.Application.Services;
using E_commerce.Application.Services.OrderService;
using E_commerce.Application.Services.ProductServices;
using E_commerce.Application.Services.UserServices;
using E_commerce.Core.Models;
using E_commerce.Infrastructure;
using E_commerce.Infrastructure.Repository;
using E_commerce.Shared;
using Microsoft.VisualBasic.ApplicationServices;

namespace E_commerce.Presentation
{
    public class AppAutoFac
    {
        public static IContainer Container { get; private set; }

        public static IContainer Inject()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<AppDbContext>().AsSelf();

            builder.RegisterType<UserRepository>().As<IUserRepository>();
            builder.RegisterType<UserServices>().As<IUserServices>();
            builder.RegisterType<Core.Models.User>().AsSelf();
            builder.RegisterType<CartItemService>().As<ICartItemService>();
            builder.RegisterType<CartItemRepository>().As<ICartItemRepository>();
            builder.RegisterType<ProductRepository>().As<IProductRepository>();
            builder.RegisterType<ProductServices>().As<IProductServices>();
            builder.RegisterType<CategoryRepository>().As<ICategoryRepository>();
            builder.RegisterType<CategoryServices>().As<ICategoryServices>();
            builder.RegisterType<OrderRepository>().As<IOrderRepository>();
            builder.RegisterType<OrderService>().As<IOrderService>();

            // Register IGenericRepository<Product>
            builder.RegisterType<GenericRepository<Product>>().As<IGenericRepository<Product>>();

            builder.RegisterType<SessionStorage>().As<ISessionStorage>().SingleInstance();

            Container = builder.Build();
            return Container;
        }
    }
}