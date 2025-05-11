using Autofac;
using E_commerce.Application.Interfaces;
using E_commerce.Application.Services;
using E_commerce.Application.Services.CartItemService;
using E_commerce.Application.Services.ProductServices;
using E_commerce.Application.Services.UserServices;
using E_commerce.Infrastructure;
using E_commerce.Infrastructure.Repository;

namespace E_commerce.Presentation
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
            builder.RegisterType<CartItemService>().As<ICartItemService>();
            builder.RegisterType<CartItemRepository>().As<ICartItemRepository>();
            builder.RegisterType<ProductRepository>().As<IProductRepository>();

            builder.RegisterType<ProductRepository>().As<IProductRepository>();
            builder.RegisterType<ProductServices>().As<IProductServices>();

            builder.RegisterType<CategoryRepository>().As<ICategoryRepository>();
            builder.RegisterType<CategoryServices>().As<ICategoryServices>();



            var container = builder.Build();
            return container;
        }
    }
}