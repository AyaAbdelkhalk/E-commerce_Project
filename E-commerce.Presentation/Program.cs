using Autofac;
using E_commerce.Application.Services;
using E_commerce.Application.Services.ProductServices;
using E_commerce.Application.Services.UserServices;

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
            var IUserServices = container.Resolve<IUserServices>();

            var IProductServices = container.Resolve<IProductServices>();
            var ICategoryServices = container.Resolve<ICategoryServices>();

            // To customize application configuration such as set high DPI settings or default font,  
            // see https://aka.ms/applicationconfiguration.  
            ApplicationConfiguration.Initialize();
            //System.Windows.Forms.Application.Run(new Form1());
            System.Windows.Forms.Application.Run(new products(IProductServices , ICategoryServices));

        }
    }
}