using E_commerce.Application.Services.OrderService;
using E_commerce.Application.Services.ProductServices;
using E_commerce.Application.Services.UserServices;
using E_commerce.Application.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace E_commerce.Presentation.CustomControls
{
    public partial class ClientMainDashboardControl : UserControl
    {
        private readonly IUserServices _userServices;
        private readonly IProductServices _productServices;
        private readonly IOrderService _orderServices;
        private readonly ICategoryServices _categoryServices;
        private readonly ICartItemService _cartItemService;
        public ClientMainDashboardControl()
        {
            InitializeComponent();
        }

        public ClientMainDashboardControl(IUserServices userServices, IProductServices productServices, IOrderService orderServices, ICategoryServices categoryServices, ICartItemService cartItemService)
        {
            _userServices = userServices;
            _productServices = productServices;
            _orderServices = orderServices;
            _categoryServices = categoryServices;
            _cartItemService = cartItemService;
        }

        private void ClientMainDashboardControl_Load(object sender, EventArgs e)
        {

        }

        private void roundedPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
