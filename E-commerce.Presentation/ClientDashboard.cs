using E_commerce.Application.Services.OrderService;
using E_commerce.Application.Services.ProductServices;
using E_commerce.Application.Services;
using E_commerce.Application.Services.UserServices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using E_commerce.Presentation.CustomControls;

namespace E_commerce.Presentation
{
    public partial class ClientDashboard : Form
    {
        private readonly IUserServices _userServices;
        private readonly IOrderService _orderService;
        private readonly IProductServices _productService;
        private readonly ICategoryServices _categoryService;
        private readonly ICartItemService _cartItemService;

        public ClientDashboard(IUserServices userServices, IProductServices productServices, IOrderService orderService, ICategoryServices categoryServices, ICartItemService cartItemService)
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            _userServices = userServices;
            _productService = productServices;
            _orderService = orderService;
            _categoryService = categoryServices;
            _cartItemService = cartItemService;




            SidebarControl sidebarControl = new SidebarControl(_userServices, _cartItemService,_productService, _orderService, _categoryService);
            sidebarControl.Visible = true;
            this.Controls.Add(sidebarControl);

            //only for testing but correctly it should be in AdminDashboard form
            AdminDashboardControl adminDashboardControl = new AdminDashboardControl(_userServices, _productService, _orderService, _categoryService, _cartItemService);
            adminDashboardControl.Visible = false;
            this.Controls.Add(adminDashboardControl);

            CartControl cartControl = new CartControl( _cartItemService, _productService,_orderService);
            cartControl.Visible = false;
            this.Controls.Add(cartControl);
            ProfilePanelControl profilePanelControl = new ProfilePanelControl(_userServices);
            profilePanelControl.Visible = false;
            this.Controls.Add(profilePanelControl);



        }

        private void ClientDashboard_Load(object sender, EventArgs e)
        {
            

        }
    }
}
