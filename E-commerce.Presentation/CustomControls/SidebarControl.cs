using Castle.Core.Logging;
using E_commerce.Application.Helper;
using E_commerce.Application.Services;
using E_commerce.Application.Services.OrderService;
using E_commerce.Application.Services.ProductServices;
using E_commerce.Application.Services.UserServices;
using Microsoft.Extensions.Logging;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace E_commerce.Presentation.CustomControls
{
    public partial class SidebarControl : UserControl
    {
        private readonly IUserServices _userServices;
        private readonly ICartItemService _cartItemService;
        private readonly IProductServices _productService;
        private readonly IOrderService _orderService;
        private readonly ICategoryServices _categoryService;
        private readonly ProfilePanelControl profilePanelControl;
        private readonly CartControl cartControl;
        private readonly MyOrdersControl myOrdersControl;
        private readonly ILogger<MyOrdersControl> _logger;

        public SidebarControl(IUserServices userServices, ICartItemService cartItemService, IProductServices productService, IOrderService orderService, ICategoryServices categoryService)
        {
            InitializeComponent();
            _userServices = userServices;
            _cartItemService = cartItemService;
            _productService = productService;
            _orderService = orderService;
            _categoryService = categoryService;
            profilePanelControl = new ProfilePanelControl(_userServices);
        }
        public SidebarControl(IUserServices userServices, ICartItemService cartItemService, IProductServices productService, IOrderService orderService)
        {
            InitializeComponent();
            _userServices = userServices;
            _cartItemService = cartItemService;
            _productService = productService;
            _orderService = orderService;
            cartControl = new CartControl(_cartItemService, _productService, _orderService);
        }
        public SidebarControl(IProductServices productService, IOrderService orderService, ICategoryServices categoryService, ILogger<MyOrdersControl> logger = null)
        {
            InitializeComponent();
            _productService = productService;
            _orderService = orderService;
            _categoryService = categoryService;
            _logger = logger;
            myOrdersControl = new MyOrdersControl(_orderService, _productService, _logger);
        }
        private void SidebarControl_Load(object sender, EventArgs e)
        {
            this.SuspendLayout();
            lbl_UserName.Text += SessionManager.CurrentUser != null ? SessionManager.CurrentUser.FirstName : "Guest";
            this.ResumeLayout();
        }

        private void HideDashboardContent()
        {
            var dashboard = this.Parent as Dashboard;
            if (dashboard != null)
            {
                // Hide the flowLayoutPanel1 to clear product display
                var flowLayoutPanel = dashboard.Controls.OfType<FlowLayoutPanel>().FirstOrDefault();
                if (flowLayoutPanel != null)
                {
                    flowLayoutPanel.Visible = false;
                }

                // Hide the search bar (SearchTextBox)
                var searchTextBox = dashboard.Controls.Find("SearchTextBox", true).FirstOrDefault();
                if (searchTextBox != null)
                {
                    searchTextBox.Visible = false;
                }
            }
        }

        private void ShowDashboardContent()
        {
            var dashboard = this.Parent as Dashboard;
            if (dashboard != null)
            {
                // Show the flowLayoutPanel1 to display product content
                var flowLayoutPanel = dashboard.Controls.OfType<FlowLayoutPanel>().FirstOrDefault();
                if (flowLayoutPanel != null)
                {
                    flowLayoutPanel.Visible = true;
                }

                // Show the search bar (SearchTextBox)
                var searchTextBox = dashboard.Controls.Find("SearchTextBox", true).FirstOrDefault();
                if (searchTextBox != null)
                {
                    searchTextBox.Visible = true;
                }
            }
        }

        #region Dashboard
        private void ClientDashboardbtn_Click(object sender, EventArgs e)
        {
            // Remove existing controls
            var existingCart = this.Parent.Controls.OfType<CartControl>().FirstOrDefault();
            if (existingCart != null)
            {
                this.Parent.Controls.Remove(existingCart);
            }
            var existingProfile = this.Parent.Controls.OfType<ProfilePanelControl>().FirstOrDefault();
            if (existingProfile != null)
            {
                this.Parent.Controls.Remove(existingProfile);
            }
            var existingOrders = this.Parent.Controls.OfType<MyOrdersControl>().FirstOrDefault();
            if (existingOrders != null)
            {
                this.Parent.Controls.Remove(existingOrders);
            }

            // Show Dashboard content
            ShowDashboardContent();

            ClientDashboardbtn.BackColor = Color.LightBlue;
            Profilebtn.BackColor = Color.Transparent;
            logoutbutton.BackColor = Color.Transparent;
            MyOrderbtn.BackColor = Color.Transparent;
            MyCartbtn.BackColor = Color.Transparent;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            ClientDashboardbtn_Click(sender, e);
        }
        #endregion

        #region Products
        private void button5_Click(object sender, EventArgs e)
        {
            // Implement product functionality if needed
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            button5_Click(sender, e);
        }
        #endregion

        #region Orders
        private void MyOrderbtn_Click(object sender, EventArgs e)
        {
            // Remove existing controls
            var existingCart = this.Parent.Controls.OfType<CartControl>().FirstOrDefault();
            if (existingCart != null)
            {
                this.Parent.Controls.Remove(existingCart);
            }
            var existingProfile = this.Parent.Controls.OfType<ProfilePanelControl>().FirstOrDefault();
            if (existingProfile != null)
            {
                this.Parent.Controls.Remove(existingProfile);
            }
            var existingOrders = this.Parent.Controls.OfType<MyOrdersControl>().FirstOrDefault();
            if (existingOrders != null)
            {
                this.Parent.Controls.Remove(existingOrders);
            }
            var existingAdminDashboard = this.Parent.Controls.OfType<AdminDashboardControl>().FirstOrDefault();
            if (existingAdminDashboard != null)
            {
                this.Parent.Controls.Remove(existingAdminDashboard);
            }

            // Hide Dashboard content
            HideDashboardContent();

            // Add MyOrdersControl
            MyOrdersControl orders = new MyOrdersControl(_orderService, _productService, _logger);
            orders.Visible = true;
            orders.Dock = DockStyle.Right;
            this.Parent.Controls.Add(orders);
            orders.BringToFront();

            MyOrderbtn.BackColor = Color.LightBlue;
            ClientDashboardbtn.BackColor = Color.Transparent;
            Profilebtn.BackColor = Color.Transparent;
            logoutbutton.BackColor = Color.Transparent;
            MyCartbtn.BackColor = Color.Transparent;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            MyOrderbtn_Click(sender, e);
        }
        #endregion

        #region My Cart
        private void MyCartbtn_Click(object sender, EventArgs e)
        {
            // Remove existing controls
            var existingCart = this.Parent.Controls.OfType<CartControl>().FirstOrDefault();
            if (existingCart != null)
            {
                this.Parent.Controls.Remove(existingCart);
            }
            var existingProfile = this.Parent.Controls.OfType<ProfilePanelControl>().FirstOrDefault();
            if (existingProfile != null)
            {
                this.Parent.Controls.Remove(existingProfile);
            }
            var existingOrders = this.Parent.Controls.OfType<MyOrdersControl>().FirstOrDefault();
            if (existingOrders != null)
            {
                this.Parent.Controls.Remove(existingOrders);
            }
            var existingAdminDashboard = this.Parent.Controls.OfType<AdminDashboardControl>().FirstOrDefault();
            if (existingAdminDashboard != null)
            {
                this.Parent.Controls.Remove(existingAdminDashboard);
            }

            // Hide Dashboard content
            HideDashboardContent();

            CartControl cart = new CartControl(_cartItemService, _productService, _orderService);
            cart.Visible = true;
            cart.Dock = DockStyle.Right;
            this.Parent.Controls.Add(cart);
            cart.BringToFront();

            MyCartbtn.BackColor = Color.LightBlue;
            ClientDashboardbtn.BackColor = Color.Transparent;
            Profilebtn.BackColor = Color.Transparent;
            logoutbutton.BackColor = Color.Transparent;
            MyOrderbtn.BackColor = Color.Transparent;
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            MyCartbtn_Click(sender, e);
        }
        #endregion

        #region Profile
        private void Profilebtn_Click(object sender, EventArgs e)
        {
            // Remove existing controls
            var existingCart = this.Parent.Controls.OfType<CartControl>().FirstOrDefault();
            if (existingCart != null)
            {
                this.Parent.Controls.Remove(existingCart);
            }
            var existingProfile = this.Parent.Controls.OfType<ProfilePanelControl>().FirstOrDefault();
            if (existingProfile != null)
            {
                this.Parent.Controls.Remove(existingProfile);
            }
            var existingOrders = this.Parent.Controls.OfType<MyOrdersControl>().FirstOrDefault();
            if (existingOrders != null)
            {
                this.Parent.Controls.Remove(existingOrders);
            }
            var existingAdminDashboard = this.Parent.Controls.OfType<AdminDashboardControl>().FirstOrDefault();
            if (existingAdminDashboard != null)
            {
                this.Parent.Controls.Remove(existingAdminDashboard);
            }

            // Hide Dashboard content
            HideDashboardContent();

            ProfilePanelControl profilePanelControl = new ProfilePanelControl(_userServices);
            profilePanelControl.Visible = true;
            profilePanelControl.Dock = DockStyle.Right;
            this.Parent.Controls.Add(profilePanelControl);
            profilePanelControl.BringToFront();
            profilePanelControl.ShowProfileSection();

            Profilebtn.BackColor = Color.LightBlue;
            ClientDashboardbtn.BackColor = Color.Transparent;
            logoutbutton.BackColor = Color.Transparent;
            MyOrderbtn.BackColor = Color.Transparent;
            MyCartbtn.BackColor = Color.Transparent;
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            Profilebtn_Click(sender, e);
        }
        #endregion

        #region Logout
        private void logoutbutton_Click(object sender, EventArgs e)
        {
            logoutbutton.BackColor = Color.LightBlue;
            ClientDashboardbtn.BackColor = Color.Transparent;
            Profilebtn.BackColor = Color.Transparent;
            MyOrderbtn.BackColor = Color.Transparent;
            MyCartbtn.BackColor = Color.Transparent;

            var result = MessageBox.Show("Are you sure you want to log out?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                this.Parent.Hide();
                SessionManager.Logout();
                _userServices.Logout();
                var loginForm = new Login_Form(_userServices);
                loginForm.Show();
            }
        }

        private void logoutpicture_Click(object sender, EventArgs e)
        {
            logoutbutton_Click(sender, e);
        }
        #endregion
    }
}