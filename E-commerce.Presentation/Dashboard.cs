using E_commerce.Application.DTOs.User;
using E_commerce.Application.Helper;
using E_commerce.Application.Interfaces;
using E_commerce.Application.Services.ProductServices;
using E_commerce.Application.Services.UserServices;
using E_commerce.Core.Models;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using E_commerce.Presentation.CustomControls;
using E_commerce.Application.Services.OrderService;
using E_commerce.Application.Hepler;
using E_commerce.Application.Services;
using Ecommerce;

namespace E_commerce.Presentation
{
    public partial class Dashboard : Form
    {
        private readonly IUserServices _userServices;
        private readonly IProductServices _productServices;
        private readonly ICartItemService _cartItemService;
        private readonly IOrderService _orderService;
        private readonly ICategoryServices _categoryServices;
        private readonly SidebarControl _sidebarControl;

        public Dashboard(User user, IUserServices userServices)
        {
            InitializeComponent();
            roundedPanel1.Visible = false;
            _userServices = userServices;
            _sidebarControl = new SidebarControl(userServices, null, null, null, null);
            this.Controls.Add(_sidebarControl);
            this.DoubleBuffered = true;
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
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
            _sidebarControl = new SidebarControl(userServices, cartItemService, productServices, null, null);
            this.Controls.Add(_sidebarControl);
            this.DoubleBuffered = true;
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
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
            customTextBox21.Text += SessionManager.CurrentUser?.FirstName + ' ' + SessionManager.CurrentUser?.LastName;
            customTextBox22.Text += SessionManager.CurrentUser?.UserName;
            customTextBox23.Text += SessionManager.CurrentUser?.Email;
            customTextBox24.Text += SessionManager.CurrentUser?.Role.ToString();
            customTextBox25.Text += SessionManager.CurrentUser?.IsActive.ToString();
            _sidebarControl = new SidebarControl(null, null, null, null, null);
            this.Controls.Add(_sidebarControl);
        }

        public Dashboard(IUserServices userServices, User user)
        {
            InitializeComponent();
            roundedPanel1.Visible = false;
            this.DoubleBuffered = true;
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            customTextBox21.Text += SessionManager.CurrentUser?.FirstName + ' ' + SessionManager.CurrentUser?.LastName;
            customTextBox22.Text += SessionManager.CurrentUser?.UserName;
            customTextBox23.Text += SessionManager.CurrentUser?.Email;
            customTextBox24.Text += SessionManager.CurrentUser?.Role.ToString();
            customTextBox25.Text += SessionManager.CurrentUser?.IsActive.ToString();
            _userServices = userServices;
            _sidebarControl = new SidebarControl(userServices, null, null, null, null);
            this.Controls.Add(_sidebarControl);
        }

        public Dashboard(IUserServices userServices, IProductServices productServices, ICartItemService cartItemService, IOrderService orderService, ICategoryServices categoryServices)
        {
            InitializeComponent();
            roundedPanel1.Visible = false;
            _userServices = userServices;
            _productServices = productServices;
            _cartItemService = cartItemService;
            _orderService = orderService;
            _categoryServices = categoryServices;
            _sidebarControl = new SidebarControl(userServices, cartItemService, productServices, orderService, categoryServices);
            this.Controls.Add(_sidebarControl);
            this.DoubleBuffered = true;
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            customTextBox21.Text += SessionManager.CurrentUser?.FirstName + ' ' + SessionManager.CurrentUser?.LastName;
            customTextBox22.Text += SessionManager.CurrentUser?.UserName;
            customTextBox23.Text += SessionManager.CurrentUser?.Email;
            customTextBox24.Text += SessionManager.CurrentUser?.Role.ToString();
            customTextBox25.Text += SessionManager.CurrentUser?.IsActive.ToString();
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            this.SuspendLayout();
            roundedPanel1.Visible = false;
            _sidebarControl.Location = new Point(12, 30);
            _sidebarControl.Size = new Size(283, 571);
            this.BackColor = Color.FromArgb(240, 248, 255); // AliceBlue
            MakeRoundedPanel(roundedPanel1, 30);
            MakeRoundedPanel(INFOroundedPanel2, 30);
            MakeRoundedPanel(PPProundedPanel3, 30);
            MakeRoundedPanel(DDDroundedPanel2, 30);
            MakeReadOnly(customTextBox21);
            MakeReadOnly(customTextBox22);
            MakeReadOnly(customTextBox23);
            MakeReadOnly(customTextBox24);
            MakeReadOnly(customTextBox25);

            if (SessionManager.CurrentUser != null)
            {
                customTextBox21.Text = SessionManager.CurrentUser.FirstName + " " + SessionManager.CurrentUser.LastName;
                customTextBox22.Text = SessionManager.CurrentUser.UserName;
                customTextBox23.Text = SessionManager.CurrentUser.Email;
                customTextBox24.Text = SessionManager.CurrentUser.Role.ToString();
                customTextBox25.Text = SessionManager.CurrentUser.IsActive ? "Activated" : "Deactivated";
            }


            LoadProducts();
            this.ResumeLayout();
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

        private async void button1_Click_1(object sender, EventArgs e) //update
        {
            var user = SessionManager.CurrentUser;
            if (user != null)
            {
                var updateDto = new AddUserDTO
                {
                    UserName = customTextBox27.Text,
                    Password = user.Password,
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

        private void roundedPanel1_Paint_1(object sender, PaintEventArgs e) { }
        private void PPProundedPanel3_Paint_1(object sender, PaintEventArgs e) { }
        private void DDDroundedPanel2_Paint(object sender, PaintEventArgs e) { }
        private void INFOroundedPanel2_Paint(object sender, PaintEventArgs e) { }
        private void customTextBox23__TextChanged(object sender, EventArgs e) { }
        private void customTextBox22__TextChanged(object sender, EventArgs e) { }

        private void MakeRoundedPanel(Panel panel, int radius)
        {
            GraphicsPath path = new GraphicsPath();
            path.AddArc(0, 0, radius, radius, 180, 90);
            path.AddArc(panel.Width - radius, 0, radius, radius, 270, 90);
            path.AddArc(panel.Width - radius, panel.Height - radius, radius, radius, 0, 90);
            path.AddArc(0, panel.Height - radius, radius, radius, 90, 90);
            path.CloseAllFigures();
            panel.Region = new Region(path);
        }

        public void MakeReadOnly(CustomTextBox2 customTextBox)
        {
            customTextBox.Enabled = false;
            customTextBox.BorderColor = Color.Transparent;
            customTextBox.BackColor = Color.LightGoldenrodYellow;
            customTextBox.ForeColor = Color.Black;
            customTextBox.Font = new Font(customTextBox.Font, FontStyle.Bold);
            customTextBox.TabStop = false;
            customTextBox.Padding = new Padding(10, 5, 5, 6);
        }
    }
}