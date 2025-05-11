using Autofac;
using E_commerce.Application.Helper;
using E_commerce.Application.Services.CartItemService;
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
            int lastUserId = Properties.Settings.Default.LastUserId;

            var container = AppAutoFac.Inject();
            var IUserServices = container.Resolve<IUserServices>();

            var cartItemService = container.Resolve<ICartItemService>();

            // To customize application configuration such as set high DPI settings or default font,  
            // see https://aka.ms/applicationconfiguration.  
            ApplicationConfiguration.Initialize();
            //System.Windows.Forms.Application.Run(new Form1());
            //System.Windows.Forms.Application.Run(new CartForm(cartItemService));
            System.Windows.Forms.Application.Run(new Dashboard());
            //System.Windows.Forms.Application.Run(new Login_Form(IUserServices));

            //check if the user is logged in
            //if (SessionManager.IsLoggedIn)
            //{
            //    System.Windows.Forms.Application.Run(new Dashboard(SessionManager.CurrentUser));
            //}
            //else
            //{
            //    // Show the login form
            //    System.Windows.Forms.Application.Run(new Login_Form(IUserServices));
            //}
        }
    }
}