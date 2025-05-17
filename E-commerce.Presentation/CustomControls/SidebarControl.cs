using E_commerce.Application.Helper;
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
using E_commerce.Application.Services.AdminDashboardServices;

namespace E_commerce.Presentation.CustomControls
{
    public partial class SidebarControl : UserControl
    {
        private readonly IUserServices _userServices; //1
        private readonly IProductServices _productServices;
        private readonly IOrderService _orderServices;
        private readonly ICategoryServices _categoryServices;
        private readonly ICartItemService _cartItemService;
        private readonly ProfilePanelControl profilePanelControl ;


        public SidebarControl(IUserServices _userServices)
        {
            InitializeComponent();
            this._userServices = _userServices;//2


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

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }
        #endregion


        #region Profile
        private void Profilebtn_Click(object sender, EventArgs e)
        {
            profilePanelControl.Visible = true;
            this.Controls.Add(profilePanelControl);
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
