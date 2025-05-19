using E_commerce.Application.DTOs.User;
using E_commerce.Application.Helper;
using E_commerce.Application.Hepler;
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

namespace E_commerce.Presentation.CustomControls
{

    public partial class ProfilePanelControl : UserControl
    {
        private readonly IUserServices _userServices;
        private readonly IProductServices _productServices;
        private readonly ICategoryServices _categoryServices;
        private readonly ICartItemService _cartItemService;
        private readonly IOrderService _orderService;
        public ProfilePanelControl(IUserServices userServices)
        {
            InitializeComponent();

            _userServices = userServices;
        }

        public ProfilePanelControl(IUserServices userServices, IProductServices productServices, ICategoryServices categoryServices, ICartItemService cartItemService, IOrderService orderService)
        {
            InitializeComponent();
            _userServices = userServices;
            _productServices = productServices;
            _categoryServices = categoryServices;
            _cartItemService = cartItemService;
            _orderService = orderService;
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string FullName
        {
            get => customTextBox21.Text;
            set => customTextBox21.Text = value;
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string UserName
        {
            get => customTextBox22.Text;
            set => customTextBox22.Text = value;
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string Email
        {
            get => customTextBox23.Text;
            set => customTextBox23.Text = value;
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string Role
        {
            get => customTextBox24.Text;
            set => customTextBox24.Text = value;
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string AccountStatus
        {
            get => customTextBox25.Text;
            set => customTextBox25.Text = value;
        }

        public void ShowInfoPanel()
        {
            roundedPanel1.Visible = true;
            //roundedPanel2.Visible = true;
            INFOroundedPanel2.Visible = true;
            DDDroundedPanel2.Visible = false;
            PPProundedPanel3.Visible = false;
            INFOroundedPanel2.BringToFront();
        }

        public void ShowDDPanel()
        {
            roundedPanel1.Visible = true;
            //roundedPanel2.Visible = true;
            DDDroundedPanel2.Visible = true;
            INFOroundedPanel2.Visible = false;
            PPProundedPanel3.Visible = false;
            DDDroundedPanel2.BringToFront();
        }

        public void ShowPPPanel()
        {
            roundedPanel1.Visible = true;
            //roundedPanel2.Visible = true;
            PPProundedPanel3.Visible = true;
            INFOroundedPanel2.Visible = false;
            DDDroundedPanel2.Visible = false;
            PPProundedPanel3.BringToFront();
        }

        public void HideAllPanels()
        {
            roundedPanel1.Visible = false;
            //roundedPanel2.Visible = false;
            INFOroundedPanel2.Visible = false;
            DDDroundedPanel2.Visible = false;
            PPProundedPanel3.Visible = false;
        }

        //show profile panel
        public void ShowProfileSection()
        {
            roundedPanel1.Visible = true;
            INFOroundedPanel2.Visible = true;
            INFOroundedPanel2.BringToFront();
            DDDroundedPanel2.Visible = true;
            PPProundedPanel3.Visible = true;

            if (SessionManager.CurrentUser != null)
            {
                customTextBox21.Text = $"{SessionManager.CurrentUser.FirstName} {SessionManager.CurrentUser.LastName}";
                customTextBox22.Text = SessionManager.CurrentUser.UserName;
                customTextBox23.Text = SessionManager.CurrentUser.Email;
                customTextBox24.Text = SessionManager.CurrentUser.IsActive ? "Activated" : "Deactivated";
                customTextBox25.Text = SessionManager.CurrentUser.Role.ToString();
            }
            else
            {
                customTextBox21.Text = "";
                customTextBox22.Text = "";
                customTextBox23.Text = "";
                customTextBox24.Text = "";
                customTextBox25.Text = "";
            }

            // جعل الحقول للقراءة فقط
            MakeReadOnly();
        }

        public void MakeReadOnly()
        {
            customTextBox21.Enabled = false;
            customTextBox21.BorderColor = Color.Transparent;
            customTextBox21.BackColor = Color.LightGoldenrodYellow;
            customTextBox21.ForeColor = Color.Black;
            customTextBox21.Font = new Font(customTextBox21.Font, FontStyle.Bold);
            customTextBox21.TabStop = false;
            customTextBox21.Padding = new Padding(10, 5, 5, 6);

            customTextBox22.Enabled = false;
            customTextBox22.BorderColor = Color.Transparent;
            customTextBox22.BackColor = Color.LightGoldenrodYellow;
            customTextBox22.ForeColor = Color.Black;
            customTextBox22.Font = new Font(customTextBox22.Font, FontStyle.Bold);
            customTextBox22.TabStop = false;
            customTextBox22.Padding = new Padding(10, 5, 5, 6);

            customTextBox23.Enabled = false;
            customTextBox23.BorderColor = Color.Transparent;
            customTextBox23.BackColor = Color.LightGoldenrodYellow;
            customTextBox23.ForeColor = Color.Black;
            customTextBox23.Font = new Font(customTextBox23.Font, FontStyle.Bold);
            customTextBox23.TabStop = false;
            customTextBox23.Padding = new Padding(10, 5, 5, 6);

            customTextBox24.Enabled = false;
            customTextBox24.BorderColor = Color.Transparent;
            customTextBox24.BackColor = Color.LightGoldenrodYellow;
            customTextBox24.ForeColor = Color.Black;
            customTextBox24.Font = new Font(customTextBox24.Font, FontStyle.Bold);
            customTextBox24.TabStop = false;
            customTextBox24.Padding = new Padding(10, 5, 5, 6);

            customTextBox25.Enabled = false;
            customTextBox25.BorderColor = Color.Transparent;
            customTextBox25.BackColor = Color.LightGoldenrodYellow;
            customTextBox25.ForeColor = Color.Black;
            customTextBox25.Font = new Font(customTextBox25.Font, FontStyle.Bold);
            customTextBox25.TabStop = false;
            customTextBox25.Padding = new Padding(10, 5, 5, 6);



        }



        private async void button1_Click(object sender, EventArgs e)
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
                var dashboard = new Dashboard(_userServices, user, _productServices, _cartItemService, _orderService, _categoryServices);
                dashboard.Show();
            }
            else
            {
                MessageBox.Show("User not found.");
            }
        }

        private void ProfilePanelControl_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            customTextBox211.Text = string.Empty;
            customTextBox29.Text = string.Empty;
            customTextBox210.Text = string.Empty;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            customTextBox27.Text = string.Empty;
            customTextBox26.Text = string.Empty;
            customTextBox28.Text = string.Empty;
            customTextBox212.Text = string.Empty;
        }

        public async void ChangePassword_Click(object sender, EventArgs e)
        {
            var user = SessionManager.CurrentUser;
            if (user != null)
            {
                var updatepass = new ChangePasswordDTO
                {
                    OldPassword = customTextBox211.Text,
                    NewPassword = customTextBox29.Text,
                    ConfirmPassword = customTextBox210.Text
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
                    if (SessionManager.CurrentUser != null)
                    {
                        SessionManager.CurrentUser.Password = PasswordHelper.HashPassword(updatepass.NewPassword);
                    }
                    MessageBox.Show("Password updated successfully.");
                    customTextBox211.Text = string.Empty;
                    customTextBox29.Text = string.Empty;
                    customTextBox210.Text = string.Empty;
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

        private void INFOroundedPanel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
