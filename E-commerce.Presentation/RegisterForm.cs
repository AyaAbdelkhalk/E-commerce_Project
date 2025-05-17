
﻿using E_commerce.Application.Services;
using E_commerce.Application.Services.AdminDashboardServices;
using E_commerce.Application.Services.OrderService;

﻿using E_commerce.Application.Services.ProductServices;


using E_commerce.Application.Services.UserServices;
using E_commerce.Presentation.CustomControls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace E_commerce.Presentation
{
    public partial class RegisterForm : Form
    {
        private readonly IUserServices _userServices;

        private readonly IOrderService _orderService;
        private readonly IProductServices _productService;
        private readonly ICategoryServices _categoryService;
        private readonly ICartItemService _cartItemService;

        public RegisterForm(IUserServices userServices,IProductServices productServices, IOrderService orderService, ICategoryServices categoryServices , ICartItemService cartItemService)

        public RegisterForm(IUserServices userServices)

        {
            InitializeComponent();

            this.WindowState = FormWindowState.Maximized;
            _userServices = userServices;
            _productService = productServices;
            _orderService = orderService;
            _categoryService = categoryServices;
            _cartItemService = cartItemService;




            SidebarControl sidebarControl = new SidebarControl(_userServices , _productService, _orderService, _categoryService, _cartItemService);
            sidebarControl.Visible = true;
            this.Controls.Add(sidebarControl);


            //only for testing but correctly it should be in AdminDashboard form
           // AdminDashboardControl adminDashboardControl = new AdminDashboardControl(_userServices, _productService, _orderService, _categoryService,_cartItemService);
           // adminDashboardControl.Visible = false;
            //this.Controls.Add(adminDashboardControl);

            ////Correct
            //ClientMainDashboardControl clientMainDashboardControl = new ClientMainDashboardControl(_userServices, _productService, _orderService, _categoryService ,_cartItemService);
            //clientMainDashboardControl.Visible = false;
            //this.Controls.Add(clientMainDashboardControl);


        }
        public RegisterForm(IUserServices userServices, IProductServices productServices, ICartItemService cartItemService)
        {
            InitializeComponent();

            this.WindowState = FormWindowState.Maximized;
            _userServices = userServices;
            _cartItemService = cartItemService;
            _productService = productServices;
            SidebarControl sidebarControl = new SidebarControl(_userServices, _productService, _cartItemService);
            sidebarControl.Visible = true;
            this.Controls.Add(sidebarControl);


        }
     

        private void RegisterForm_Load(object sender, EventArgs e)
        {

        }
    }
}
