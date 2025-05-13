using E_commerce.Application.Helper;
using E_commerce.Application.Interfaces;
using E_commerce.Application.Services;
using E_commerce.Application.Services.ProductServices;
using E_commerce.Application.Services.UserServices;
using E_commerce.Core.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace E_commerce.Presentation
{
    public partial class AdminDashboard : Form
    {
        private readonly IProductServices _productServices;
        private readonly ICategoryServices _categoryServices;
        private readonly IUserServices _userServices;



        public AdminDashboard(User user)
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            lbl_employeeName.Text += user.FirstName;
        }
        public AdminDashboard(IUserServices userServices)
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            lbl_employeeName.Text += SessionManager.CurrentUser?.FirstName;
            _userServices = userServices;
        }
        public AdminDashboard(IUserServices userServices, User user)
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            lbl_employeeName.Text += SessionManager.CurrentUser?.FirstName;
            _userServices = userServices;

        }
        public AdminDashboard(IProductServices productServices, ICategoryServices categoryServices, IUserServices userServices)
        {
            InitializeComponent();
            _productServices = productServices;
            _categoryServices = categoryServices;
            _userServices = userServices;
            this.DoubleBuffered = true;
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            lbl_employeeName.Text += SessionManager.CurrentUser?.FirstName;
        }
        public AdminDashboard(IProductServices productServices, ICategoryServices categoryServices)
        {
            InitializeComponent();
            _productServices = productServices;
            _categoryServices = categoryServices;
            this.DoubleBuffered = true;
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            lbl_employeeName.Text += SessionManager.CurrentUser?.FirstName;
        }

        public AdminDashboard()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            lbl_employeeName.Text += SessionManager.CurrentUser?.FirstName;

        }
        private void AdminDashboard_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            this.DoubleBuffered = true;
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            lbl_employeeName.Text += SessionManager.CurrentUser?.FirstName;
        }
        private void btn_logout_Click(object sender, EventArgs e)
        {
            SessionManager.Logout();
            var result = MessageBox.Show("Are you sure you want to log out?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                this.Hide();
                new Login_Form(_userServices).Show();
            }
            this.Hide();

        }
        private void btn_products_Click(object sender, EventArgs e)
        {
            this.Hide();
            new products(_userServices,_productServices, _categoryServices).Show();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            Form users = new users(_userServices , _productServices , _categoryServices);
            users.Show();
            this.Hide();
        }

        private void AdminDashboard_Load_1(object sender, EventArgs e)
        {

        }

        private void logoutbutton_Click(object sender, EventArgs e)
        {
            this.Hide();
            var result = MessageBox.Show("Are you sure you want to log out?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                SessionManager.Logout();
                _userServices.Logout();
                var loginForm = new Login_Form(_userServices);
                loginForm.Show();
            }

        }

        private void productbtn_Click(object sender, EventArgs e)
        {

            Form productForm = new products(_userServices,_productServices, _categoryServices);
            productForm.Show();
            this.Hide();
        }

        private void categorybtn_Click(object sender, EventArgs e)
        {
            Form CategoryForm = new Category(_userServices, _productServices, _categoryServices);
            CategoryForm.Show();
            this.Hide();
        }
    }
}
