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
            builder.RegisterType<AppDbContext>().AsSelf().InstancePerLifetimeScope();

            builder.RegisterType<UserRepository>().As<IUserRepository>().InstancePerLifetimeScope();
            builder.RegisterType<UserServices>().As<IUserServices>().InstancePerLifetimeScope();
            builder.RegisterType<Core.Models.User>().AsSelf().InstancePerLifetimeScope();
            builder.RegisterType<CartItemService>().As<ICartItemService>().InstancePerLifetimeScope();
            builder.RegisterType<CartItemRepository>().As<ICartItemRepository>().InstancePerLifetimeScope();
            builder.RegisterType<ProductRepository>().As<IProductRepository>().InstancePerLifetimeScope();
            builder.RegisterType<ProductServices>().As<IProductServices>().InstancePerLifetimeScope();
            builder.RegisterType<CategoryRepository>().As<ICategoryRepository>().InstancePerLifetimeScope();
            builder.RegisterType<CategoryServices>().As<ICategoryServices>().InstancePerLifetimeScope();
            builder.RegisterType<OrderRepository>().As<IOrderRepository>().InstancePerLifetimeScope();
            builder.RegisterType<OrderService>().As<IOrderService>().InstancePerLifetimeScope();


            // Register IGenericRepository<Product>
            builder.RegisterType<GenericRepository<Product>>().As<IGenericRepository<Product>>().InstancePerLifetimeScope();

            builder.RegisterType<SessionStorage>().As<ISessionStorage>().SingleInstance();
            builder.RegisterType<products>().AsSelf().InstancePerLifetimeScope();

            Container = builder.Build();
            return Container;
        }
    }
}