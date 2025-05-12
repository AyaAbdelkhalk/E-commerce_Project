using Autofac;
using E_commerce.Application.Helper;
using E_commerce.Application.Interfaces;
using E_commerce.Application.Services;
using E_commerce.Application.Services.CartItemService;
using E_commerce.Application.Services.OrderService;
using E_commerce.Application.Services.ProductServices;
using E_commerce.Application.Services.UserServices;
using E_commerce.Core.Models;
using E_commerce.Shared;

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
            var userServices = container.Resolve<IUserServices>(); 

            var cartItemService = container.Resolve<ICartItemService>();

            var productServices = container.Resolve<IProductServices>();
            var categoryServices = container.Resolve<ICategoryServices>();
            var sessionStorage = container.Resolve<ISessionStorage>();
            var orderService = container.Resolve<IOrderService>();

            ApplicationConfiguration.Initialize();


            // To customize application configuration such as set high DPI settings or default font,  
            // see https://aka.ms/applicationconfiguration.  
            //System.Windows.Forms.Application.Run(new Form1());
            //System.Windows.Forms.Application.Run(new CartForm(cartItemService));
            //System.Windows.Forms.Application.Run(new Dashboard());
            //System.Windows.Forms.Application.Run(new Login_Form(userServices));


            //System.Windows.Forms.Application.Run(new products(productServices, categoryServices));
            //System.Windows.Forms.Application.Run(new Category(productServices, categoryServices));
            //System.Windows.Forms.Application.Run(new Order());

            //System.Windows.Forms.Application.Run(new products(productServices, categoryServices));
            //System.Windows.Forms.Application.Run(new Category(productServices, categoryServices));




            #region for final run
            SessionManager.Initialize(sessionStorage);
            SessionManager.LoadLastUser(userServices);

            if (SessionManager.IsLoggedIn)
            {
                System.Windows.Forms.Application.Run(new Dashboard(userServices, SessionManager.CurrentUser));
            }
            else
            {
                System.Windows.Forms.Application.Run(new Login_Form(userServices));
            }
            #endregion

        }
    }
}