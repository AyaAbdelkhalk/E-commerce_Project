using Autofac;
using E_commerce.Application.Helper;
using E_commerce.Application.Interfaces;
using E_commerce.Application.Services;
using E_commerce.Application.Services.OrderService;
using E_commerce.Application.Services.ProductServices;
using E_commerce.Application.Services.UserServices;
using E_commerce.Core.Models;
using E_commerce.Shared;
using System.Threading.Tasks;

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

            System.Windows.Forms.Application.EnableVisualStyles();
            System.Windows.Forms.Application.SetCompatibleTextRenderingDefault(false);
            var container = AppAutoFac.Inject();
            var userServices = container.Resolve<IUserServices>();
            var cartItemService = container.Resolve<ICartItemService>();
            var productServices = container.Resolve<IProductServices>();
            var categoryServices = container.Resolve<ICategoryServices>();
            var sessionStorage = container.Resolve<ISessionStorage>();
            var orderService = container.Resolve<IOrderService>();
            ApplicationConfiguration.Initialize();
            SessionManager.Initialize(sessionStorage);
            var loadUserTask = SessionManager.LoadLastUser(userServices);
            loadUserTask.Wait();




            #region Form Region
            // To customize application configuration such as set high DPI settings or default font,  
            // see https://aka.ms/applicationconfiguration.  
            //System.Windows.Forms.Application.Run(new Form1());
            System.Windows.Forms.Application.Run(new RegisterForm(userServices,productServices, cartItemService));
            //System.Windows.Forms.Application.Run(new Dashboard());
            //System.Windows.Forms.Application.Run(new Login_Form(userServices));


            //System.Windows.Forms.Application.Run(new products(productServices, categoryServices));
            //<<<<<<< updd
            //System.Windows.Forms.Application.Run(new Category(productServices, categoryServices));
            //System.Windows.Forms.Application.Run(new Order());

            //System.Windows.Forms.Application.Run(new products(userServices, productServices, categoryServices, cartItemService));
            //=======
            //>>>>>>> master
            //System.Windows.Forms.Application.Run(new Category(productServices, categoryServices));
            //System.Windows.Forms.Application.Run(new Order());

            //<<<<<<< updd
            //          System.Windows.Forms.Application.Run(new users(userServices , productServices , categoryServices));


            //System.Windows.Forms.Application.Run(new AdminDashboard(productServices, categoryServices, userServices));

            //SessionManager.Initialize(sessionStorage);
            ////await SessionManager.LoadLastUser(userServices);
            //if (SessionManager.IsLoggedIn)
            //{
            //    if (SessionManager.IsAdmin())
            //    {
            //        System.Windows.Forms.Application.Run(new AdminDashboard(productServices, categoryServices, userServices, cartItemService));
            //    }
            //    else
            //    {

            //        System.Windows.Forms.Application.Run(new Dashboard(userServices));
            //    }
            //}
            //else
            //{
            //    System.Windows.Forms.Application.Run(new Login_Form(userServices));
            //} 
            #endregion

            //System.Windows.Forms.Application.Run(new products(userServices, productServices, categoryServices, cartItemService));
            //System.Windows.Forms.Application.Run(new AdminDashboard(productServices, categoryServices, userServices, cartItemService));




            //if (SessionManager.IsLoggedIn)
            //{
            //    if (SessionManager.IsAdmin())
            //    {
            //        System.Windows.Forms.Application.Run(new AdminDashboard(productServices, categoryServices, userServices, cartItemService));
            //    }
            //    else
            //    {
            //        System.Windows.Forms.Application.Run(new Dashboard(userServices, productServices, cartItemService));
            //    }
            //}
            //else
            //{
            //    System.Windows.Forms.Application.Run(new Login_Form(userServices));
            //}

            ////System.Windows.Forms.Application.Run(new RegisterForm(userServices));


        }
    }
    
}