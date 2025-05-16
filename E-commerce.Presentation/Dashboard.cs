using E_commerce.Application.DTOs.User;
using E_commerce.Application.Helper;
using E_commerce.Application.Hepler;
using E_commerce.Application.Interfaces;
using E_commerce.Application.Services.ProductServices;
using E_commerce.Application.Services;
using E_commerce.Application.Services.UserServices;
using E_commerce.Core.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Ecommerce;

namespace E_commerce.Presentation
{
    public partial class Dashboard : Form
    {
        private readonly IUserServices _userServices;
        private readonly IProductServices _productServices;
        private readonly ICartItemService _cartItemService;

        public Dashboard(User user, IUserServices userServices)
        {
            InitializeComponent();
            roundedPanel1.Visible = false;
            _userServices = userServices;
            this.DoubleBuffered = true;
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            lbl_UserName.Text += SessionManager.CurrentUser?.FirstName;
            customTextBox21.Text += SessionManager.CurrentUser?.FirstName + ' ' + SessionManager.CurrentUser?.LastName;
            customTextBox22.Text += SessionManager.CurrentUser?.UserName;
            customTextBox23.Text += SessionManager.CurrentUser?.Email;
            customTextBox24.Text += SessionManager.CurrentUser?.Role.ToString();
            customTextBox25.Text += SessionManager.CurrentUser?.IsActive.ToString();
        }
        public Dashboard(IUserServices userServices, IProductServices productServices, ICartItemService cartItemService)
        {
            InitializeComponent();
            roundedPanel1.Visible = false;
            _userServices = userServices;
            _productServices = productServices;
            _cartItemService = cartItemService;


            this.DoubleBuffered = true;
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            lbl_UserName.Text += SessionManager.CurrentUser?.FirstName;
            customTextBox21.Text += SessionManager.CurrentUser?.FirstName + ' ' + SessionManager.CurrentUser?.LastName;
            customTextBox22.Text += SessionManager.CurrentUser?.UserName;
            customTextBox23.Text += SessionManager.CurrentUser?.Email;
            customTextBox24.Text += SessionManager.CurrentUser?.Role.ToString();
            customTextBox25.Text += SessionManager.CurrentUser?.IsActive.ToString();
        }


        public Dashboard()
        {
            InitializeComponent();
            roundedPanel1.Visible = false;
            this.DoubleBuffered = true;
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            lbl_UserName.Text += SessionManager.CurrentUser?.FirstName;
            customTextBox21.Text += SessionManager.CurrentUser?.FirstName + ' ' + SessionManager.CurrentUser?.LastName;
            customTextBox22.Text += SessionManager.CurrentUser?.UserName;
            customTextBox23.Text += SessionManager.CurrentUser?.Email;
            customTextBox24.Text += SessionManager.CurrentUser?.Role.ToString();
            customTextBox25.Text += SessionManager.CurrentUser?.IsActive.ToString();




        }

        public Dashboard(IUserServices userServices, User user)
        {
            InitializeComponent();
            roundedPanel1.Visible = false;
            this.DoubleBuffered = true;
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            lbl_UserName.Text += SessionManager.CurrentUser?.FirstName;
            customTextBox21.Text += SessionManager.CurrentUser?.FirstName + ' ' + SessionManager.CurrentUser?.LastName;
            customTextBox22.Text += SessionManager.CurrentUser?.UserName;
            customTextBox23.Text += SessionManager.CurrentUser?.Email;
            customTextBox24.Text += SessionManager.CurrentUser?.Role.ToString();
            customTextBox25.Text += SessionManager.CurrentUser?.IsActive.ToString(); _userServices = userServices;

        }

        private void Dashboard_Load(object sender, EventArgs e)
        {

            this.WindowState = FormWindowState.Maximized;

            this.SuspendLayout();
            roundedPanel1.Visible = false;
            MakeRoundedPanel(pnl_sideBarClient, 30);
            //this.BackColor = Color.FromArgb(245, 245, 245) // Very Light Gray
            this.BackColor =
            //Color.FromArgb(250, 250, 240) // FloralWhite (أبيض على لمسة أصفر)
            Color.FromArgb(240, 248, 255); // AliceBlue – أزرق سماوي فاتح جداً

            MakeRoundedPanel(roundedPanel1, 30);
            MakeRoundedPanel(INFOroundedPanel2, 30);
            MakeRoundedPanel(PPProundedPanel3, 30);
            MakeRoundedPanel(DDDroundedPanel2, 30);
            lbl_UserName.Text += SessionManager.CurrentUser?.FirstName;
            customTextBox21.Text += SessionManager.CurrentUser?.FirstName + ' ' + SessionManager.CurrentUser?.LastName;
            customTextBox22.Text += SessionManager.CurrentUser?.UserName;
            customTextBox23.Text += SessionManager.CurrentUser?.Email;
            customTextBox24.Text += SessionManager.CurrentUser?.Role.ToString();
            customTextBox25.Text += SessionManager.CurrentUser?.IsActive.ToString();

            ClientDashboardbtn.MouseEnter += (s, e) =>
            {
                ClientDashboardbtn.BackColor = Color.FromArgb(200, 230, 250); // لون ناعم عند المرور
                ClientDashboardbtn.ForeColor = Color.DarkBlue;                // لون الخط أغمق
            };

            ClientDashboardbtn.MouseLeave += (s, e) =>
            {
                ClientDashboardbtn.BackColor = Color.Transparent;            // يرجع شفاف
                ClientDashboardbtn.ForeColor = Color.Black;           // يرجع لونه الأصلي
            };

            ClientDashboardbtn.MouseDown += (s, e) =>
            {
                ClientDashboardbtn.BackColor = Color.FromArgb(180, 210, 240); // لون أغمق عند الضغط
            };

            ClientDashboardbtn.MouseUp += (s, e) =>
            {
                ClientDashboardbtn.BackColor = Color.FromArgb(200, 230, 250); // يرجع للهوفر
            };
            MakeReadOnly(customTextBox21);
            MakeReadOnly(customTextBox22);
            MakeReadOnly(customTextBox23);
            MakeReadOnly(customTextBox24);
            MakeReadOnly(customTextBox25);


            if (SessionManager.CurrentUser != null)
            {
                lbl_UserName.Text = "Welcome \n " + SessionManager.CurrentUser.FirstName;
                customTextBox21.Text = SessionManager.CurrentUser.FirstName + " " + SessionManager.CurrentUser.LastName;
                customTextBox22.Text = SessionManager.CurrentUser.UserName;
                customTextBox23.Text = SessionManager.CurrentUser.Email;
                customTextBox24.Text = SessionManager.CurrentUser.Role.ToString();
                if (SessionManager.CurrentUser.IsActive == true)
                    customTextBox25.Text = "Activated";
                else
                    customTextBox25.Text = "Deactivated";


            }
            else
            {
                lbl_UserName.Text = "Guest";
            }

            LoadProducts();


        }

        private async void LoadProducts()
        {
            try
            {
                flowLayoutPanel1.Controls.Clear();
                flowLayoutPanel1.AutoScroll = true;

                var products = await _productServices.GetAllProductsAvailableAsync();
                if (products.Succeeded && products.Data != null)
                {
                    foreach (var product in products.Data)
                    {
                        UserControl1 userControl = new UserControl1(_cartItemService, product.ProductID, product.Name);
                        userControl.SetData(product.Name, product.Price.ToString(),
                                          product.ProductID.ToString(), product.ImagePath, product.Description);

                        userControl.Width = flowLayoutPanel1.Width - 25;
                        userControl.Height = 150;
                        userControl.Margin = new Padding(5);

                        flowLayoutPanel1.Controls.Add(userControl);
                    }
                }
                else
                {
                    ShowErrorMessage("No products available or failed to load.");
                }
            }
            catch (Exception ex)
            {
                ShowErrorMessage($"Error loading products: {ex.Message}");
            }
        }

        private void ShowErrorMessage(string message)
        {
            MessageBox.Show(this, message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void btn_dashboard_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void lbl_employeeName_Click(object sender, EventArgs e)
        {

        }

        private void logoutpicture_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Are you sure you want to log out?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                this.Hide();
                // Show the login form again
                SessionManager.Logout();
                var loginForm = new Login_Form(_userServices);
                loginForm.Show();
            }


        }
        private void Dashboard_Paint(object sender, PaintEventArgs e)
        {
            using (LinearGradientBrush brush = new LinearGradientBrush(this.ClientRectangle,
                Color.FromArgb(135, 206, 250),   // Sky Blue
                Color.FromArgb(255, 182, 193),   // Light Pink
                LinearGradientMode.Vertical))
            {
                e.Graphics.FillRectangle(brush, this.ClientRectangle);
            }
        }

        private void pnl_sideBar_Paint(object sender, PaintEventArgs e)
        {
            using (LinearGradientBrush brush = new LinearGradientBrush(pnl_sideBarClient.ClientRectangle,
                    Color.FromArgb(135, 206, 250),   // Sky Blue
                    Color.FromArgb(255, 223, 102), // Light Yellow (Sunlight)

                //Color.FromArgb(63, 43, 150) , Color.FromArgb(42, 27, 161)

                // Color.FromArgb(255, 175, 189), // مشمشي وردي
                //Color.FromArgb(255, 195, 160)  // مشمشي فاتح

                LinearGradientMode.Vertical))
            {
                e.Graphics.FillRectangle(brush, pnl_sideBarClient.ClientRectangle);
            }
        }

        private void PPProundedPanel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Pinfo_Click(object sender, EventArgs e)
        {

        }

        private void roundedPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void usrpicture_Click(object sender, EventArgs e)
        {

        }

        private void logoutbutton_Click(object sender, EventArgs e)
        {
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


        private void roundedPanel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void INFOroundedPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void CDroundedPanel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void customTextBox23__TextChanged(object sender, EventArgs e)
        {

        }

        private void customTextBox22__TextChanged(object sender, EventArgs e)
        {

        }

        private void PPProundedPanel3_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void DDDroundedPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void roundedPanel1_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void Profilebtn_Click(object sender, EventArgs e)
        {
            roundedPanel1.Visible = true;
            // Change the button color
            Profilebtn.BackColor = Color.FromArgb(200, 230, 250); // لون ناعم عند المرور
            Profilebtn.ForeColor = Color.DarkBlue;                // لون الخط أغمق
            // Hide other panels

        }

        private async void button1_Click_1(object sender, EventArgs e) //update
        {
            var user = SessionManager.CurrentUser;
            if (user != null)
            {
                var updateDto = new AddUserDTO
                {
                    UserName = customTextBox27.Text,
                    Password = user.Password, // خليها نفس الباسورد الأصلي
                    PasswordConfirmed = user.Password,
                    Email = customTextBox26.Text,
                    FirstName = customTextBox28.Text,
                    LastName = customTextBox212.Text
                };

                var result = await _userServices.UpdateUser(updateDto);

                if (!result.Succeeded)
                {
                    MessageBox.Show(string.Join("\n", result.Errors), "Update Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                user.UserName = updateDto.UserName;
                user.Email = updateDto.Email;
                user.FirstName = updateDto.FirstName;
                user.LastName = updateDto.LastName;

                MessageBox.Show("User information updated successfully.");

                customTextBox27.Text = string.Empty;
                customTextBox26.Text = string.Empty;
                customTextBox28.Text = string.Empty;
                customTextBox212.Text = string.Empty;

                this.Hide();
                var dashboard = new Dashboard(_userServices, user);
                dashboard.Show();
            }
            else
            {
                MessageBox.Show("User not found.");
            }
        }

        private void button3_Click(object sender, EventArgs e) //clear
        {
            customTextBox27.Text = string.Empty;
            customTextBox26.Text = string.Empty;
            customTextBox28.Text = string.Empty;
            customTextBox212.Text = string.Empty;
        }

        private async void ChangePassword_Click(object sender, EventArgs e)
        {
            var user = SessionManager.CurrentUser;
            if (user != null)
            {
                var updatepass = new ChangePasswordDTO
                {
                    OldPassword = customTextBox210.Text,
                    NewPassword = customTextBox211.Text,
                    ConfirmPassword = customTextBox29.Text
                };

                var isOldPasswordCorrect = PasswordHelper.VerifyPassword(user.Password, updatepass.OldPassword);
                if (!isOldPasswordCorrect)
                {
                    MessageBox.Show("The old password is incorrect.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (updatepass.NewPassword != updatepass.ConfirmPassword)
                {
                    MessageBox.Show("New Password and Confirm Password do not match", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var isValidPassword = PasswordHelper.IsStrongPassword(updatepass.NewPassword);
                if (!isValidPassword)
                {
                    MessageBox.Show("The password is invalid. It must contain an upper letter, a lowercase letter, and a number.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var addu = new AddUserDTO
                {
                    UserName = user.UserName,
                    Password = updatepass.NewPassword,
                    PasswordConfirmed = updatepass.ConfirmPassword,
                    Email = user.Email,
                    FirstName = user.FirstName,
                    LastName = user.LastName
                };

                var result = await _userServices.UpdateUser(addu);
                if (result.Succeeded)
                {
                    SessionManager.CurrentUser.Password = PasswordHelper.HashPassword(updatepass.NewPassword);
                    MessageBox.Show("Password updated successfully.");
                    customTextBox210.Text = string.Empty;
                    customTextBox211.Text = string.Empty;
                    customTextBox29.Text = string.Empty;
                }
                else
                {
                    MessageBox.Show(string.Join("\n", result.Errors), "Update Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("User not found.");
            }
        }

        private void button2_Click_1(object sender, EventArgs e)// clear2
        {
            customTextBox210.Text = string.Empty;
            customTextBox211.Text = string.Empty;
            customTextBox29.Text = string.Empty;
        }

        private void pnl_sideBarClient_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            roundedPanel1.Visible = true;
            // Change the button color
            Profilebtn.BackColor = Color.FromArgb(200, 230, 250); // لون ناعم عند المرور
            Profilebtn.ForeColor = Color.DarkBlue;                // لون الخط أغمق
            // Hide other panels
        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void SearchTextBox_TextChanged(object sender, EventArgs e)
        {
            var text = SearchTextBox.Text.ToLower();

            foreach (UserControl1 control in flowLayoutPanel1.Controls)
            {
                if (control._name.ToLower().Contains(text))
                {
                    control.Visible = true;
                }
                else
                {
                    control.Visible = false;
                }
            }
        }

        private void Dashboard_Click(object sender, EventArgs e)
        {
            LoadProducts();
            flowLayoutPanel1.Visible = true;
        }
    }
}
