using E_commerce.Application.Helper;
using E_commerce.Application.Services;
using E_commerce.Application.Services.OrderService;
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

namespace E_commerce.Presentation.CustomControls
{
    public partial class SidebarControl : UserControl
    {
        private readonly IUserServices _userServices; //1
        private readonly ICartItemService _cartItemService; //2
        private readonly IProductServices _productService; //3
        private readonly IOrderService _orderService; //4
        private readonly ICategoryServices _categoryService; //5
        private readonly ProfilePanelControl profilePanelControl;


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
   
        private void SidebarControl_Load(object sender, EventArgs e)
        {
            this.SuspendLayout();
            // Set the user name label text
            lbl_UserName.Text += SessionManager.CurrentUser != null ? SessionManager.CurrentUser.FirstName : "Guest";

        }


        #region Dashboard
        private void ClientDashboardbtn_Click(object sender, EventArgs e)
        {
            //// Remove existing CartControl if any
            var existingCart = this.Parent.Controls.OfType<CartControl>().FirstOrDefault();
            if (existingCart != null)
            {
                this.Parent.Controls.Remove(existingCart);
            }
            // Remove existing ProfilePanelControl if any
            var existingProfile = this.Parent.Controls.OfType<ProfilePanelControl>().FirstOrDefault();
            if (existingProfile != null)
            {
                this.Parent.Controls.Remove(existingProfile);
            }
            //add products here 
            
            ClientDashboardbtn.BackColor = Color.LightBlue;
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
            var existingAdminDashboard = this.Parent.Controls.OfType<AdminDashboardControl>().FirstOrDefault();
            if (existingAdminDashboard != null)
            {
                this.Parent.Controls.Remove(existingAdminDashboard);
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
            var existingAdminDashboard = this.Parent.Controls.OfType<AdminDashboardControl>().FirstOrDefault();
            if (existingAdminDashboard != null)
            {
                this.Parent.Controls.Remove(existingAdminDashboard);
            }
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

            #region Aya

            //profilePanelControl.Visible = true;
            //this.Controls.Add(profilePanelControl);
            //profilePanelControl.BringToFront();
            //profilePanelControl.ShowProfileSection();
            //Profilebtn.BackColor = Color.LightBlue;
            //ClientDashboardbtn.BackColor = Color.Transparent;
            //logoutbutton.BackColor = Color.Transparent;
            #endregion

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



    }
}
