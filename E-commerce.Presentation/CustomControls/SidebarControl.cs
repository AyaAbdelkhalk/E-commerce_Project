using E_commerce.Application.Helper;

using E_commerce.Application.Services.OrderService;

using E_commerce.Application.Services;
using E_commerce.Application.Services.ProductServices;

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
using E_commerce.Application.Services.AdminDashboardServices;

namespace E_commerce.Presentation.CustomControls
{
    public partial class SidebarControl : UserControl
    {
        private readonly IUserServices _userServices; //1

        private readonly IOrderService _orderServices;
        private readonly ICategoryServices _categoryServices;
        private readonly ProfilePanelControl profilePanelControl ;


        private readonly ICartItemService _cartItemService; //2
        private readonly IProductServices _productService; //3


        public SidebarControl(IUserServices _userServices)
        {
            InitializeComponent();
            this._userServices = _userServices;//2


        }
        public SidebarControl(IUserServices userServices,IProductServices productServices, ICartItemService cartItemService)
        {
            InitializeComponent();
            _userServices = userServices;//2
            _productService = productServices; //3
            _cartItemService = cartItemService; //4
        }

        public SidebarControl(IUserServices userServices, IProductServices productServices, IOrderService orderServices, ICategoryServices categoryServices, ICartItemService cartItemService)
        {
            _userServices = userServices;
            _productServices = productServices;
            _orderServices = orderServices;
            _categoryServices = categoryServices;
            InitializeComponent();
            profilePanelControl = new ProfilePanelControl(_userServices);
            _cartItemService = cartItemService;
        }

        private void SidebarControl_Load(object sender, EventArgs e)
        {
            this.SuspendLayout();
            // Set the user name label text
            lbl_UserName.Text += SessionManager.CurrentUser != null ? SessionManager.CurrentUser.FirstName : "Guest";


        }


        #region Dashboard
        private void ClientDashboardbtn_Click(object sender, EventArgs e)
        {
            profilePanelControl.Visible = false;
            AdminDashboardControl adminDashboardControl = new AdminDashboardControl(_userServices, _productServices, _orderServices, _categoryServices
                ,_cartItemService);
            adminDashboardControl.Visible = true;
            this.Controls.Add(adminDashboardControl);
            adminDashboardControl.BringToFront();
            adminDashboardControl.Show();
            ClientDashboardbtn.BackColor = Color.LightBlue;
            this.Visible = true;
            this.BringToFront();
            Profilebtn.BackColor = Color.Transparent;
            logoutbutton.BackColor = Color.Transparent;




        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            ClientDashboardbtn_Click(sender, e);

        }
        #endregion


        #region Products
        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }
        #endregion


        #region Orders
        private void MyOrderbtn_Click(object sender, EventArgs e)
        {

        }
        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }
        #endregion


        #region My Cart
        private void MyCartbtn_Click(object sender, EventArgs e)
        {

            // Remove existing CartControl if any
            var existingCart = this.Parent.Controls.OfType<CartControl>().FirstOrDefault();
            if (existingCart != null)
            {
                this.Parent.Controls.Remove(existingCart);
            }

            CartControl cart = new CartControl(_cartItemService, _productService);
            cart.Visible = true;
            cart.Dock = DockStyle.Right;
            this.Parent.Controls.Add(cart);
            cart.BringToFront();

            // Adjust ProfilePanelControl position if it exists
            var profile = this.Parent.Controls.OfType<ProfilePanelControl>().FirstOrDefault();
            if (profile != null)
            {
                profile.Location = new Point(0, cart.Height);
            }

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            MyCartbtn_Click(sender, e);
        }
        #endregion


        #region Profile
        private void Profilebtn_Click(object sender, EventArgs e)
        {


            // Remove existing ProfilePanelControl if any
            var existingProfile = this.Parent.Controls.OfType<ProfilePanelControl>().FirstOrDefault();
            if (existingProfile != null)
            {
                this.Parent.Controls.Remove(existingProfile);
            }

            ProfilePanelControl profilePanelControl = new ProfilePanelControl(_userServices);

            profilePanelControl.Visible = true;

            // Position below CartControl if it exists, otherwise at a default location
            var cart = this.Parent.Controls.OfType<CartControl>().FirstOrDefault();
            if (cart != null)
            {
                cart.Visible = false;
            }
 

            this.Parent.Controls.Add(profilePanelControl);
            profilePanelControl.BringToFront();
            profilePanelControl.ShowProfileSection();

            Profilebtn.BackColor = Color.LightBlue;
            ClientDashboardbtn.BackColor = Color.Transparent;
            logoutbutton.BackColor = Color.Transparent;



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


            var result = MessageBox.Show("Are you sure you want to log out?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                this.Hide();
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



        private void pnl_sideBarClient_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
