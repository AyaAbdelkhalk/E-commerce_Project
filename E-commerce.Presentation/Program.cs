using Autofac;
using E_commerce.Application.Services;
using E_commerce.Application.Services.CartItemService;
using E_commerce.Application.Services.ProductServices;
using E_commerce.Application.Services.UserServices;
using E_commerce.Core.Models;

namespace E_commerce.Presentation
{
    internal static class Program
    {
        /// <summary>  
        ///  The main entry point for the application.  
        /// </summary>  
        [STAThread]
        static void Main()
        {
            var container = AppAutoFac.Inject();
            var userServices = container.Resolve<IUserServices>(); // Corrected variable name

            var cartItemService = container.Resolve<ICartItemService>();

            var productServices = container.Resolve<IProductServices>();
            var categoryServices = container.Resolve<ICategoryServices>();

            // To customize application configuration such as set high DPI settings or default font,  
            // see https://aka.ms/applicationconfiguration.  
            ApplicationConfiguration.Initialize();
            //System.Windows.Forms.Application.Run(new Form1());
            //System.Windows.Forms.Application.Run(new CartForm(cartItemService));
            //System.Windows.Forms.Application.Run(new Dashboard());
            //System.Windows.Forms.Application.Run(new Login_Form(userServices));

            //System.Windows.Forms.Application.Run(new products(productServices, categoryServices));
            System.Windows.Forms.Application.Run(new Category(productServices, categoryServices));

        }
    }
}