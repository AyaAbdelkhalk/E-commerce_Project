using E_commerce.Application.DTOs.User;
using E_commerce.Application.Helper;
using E_commerce.Application.Hepler;
using E_commerce.Application.Interfaces;
using E_commerce.Application.Services;
using E_commerce.Application.Services.ProductServices;
using E_commerce.Application.Services.UserServices;
using E_commerce.Core.Models;
using E_commerce.Presentation.CustomControls;
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
        #region Ctor
        private readonly IProductServices _productServices;
        private readonly ICategoryServices _categoryServices;
        private readonly IUserServices _userServices;
        private readonly ICartItemService _cartItemService;
        private readonly ProfilePanelControl profilePanelControl1;

        public AdminDashboard(IUserServices userServices, User user)
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            roundedPanel1.Visible = false;
            this.DoubleBuffered = true;
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            lbl_employeeName.Text += SessionManager.CurrentUser?.FirstName;
            _userServices = userServices;
            // إضافة ProfilePanelControl
            profilePanelControl1 = new ProfilePanelControl(userServices);
            //profilePanelControl1.Location = new Point(20, 80);
            //profilePanelControl1.Size = new Size(1500, 800);
            this.Controls.Add(profilePanelControl1);
            profilePanelControl1.Visible = false;

        

        }
        public AdminDashboard(IProductServices productServices, ICategoryServices categoryServices, IUserServices userServices, ICartItemService cartItemService)
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            roundedPanel1.Visible = false;

            _productServices = productServices;
            _categoryServices = categoryServices;
            _cartItemService = cartItemService;
            _userServices = userServices;
            this.DoubleBuffered = true;
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            lbl_employeeName.Text += SessionManager.CurrentUser?.FirstName;
            // إضافة ProfilePanelControl
            profilePanelControl1 = new ProfilePanelControl(userServices);
            //profilePanelControl1.Location = new Point(200, 50);
            //profilePanelControl1.Size = new Size(1353, 728);
            this.Controls.Add(profilePanelControl1);
            profilePanelControl1.Visible = false;
        }
      
        #endregion


        private void AdminDashboard_Load(object sender, EventArgs e)
        {

            this.WindowState = FormWindowState.Maximized;
            roundedPanel1.Visible = false;
            this.DoubleBuffered = true;
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            lbl_employeeName.Text += SessionManager.CurrentUser?.FirstName;

            roundedPanel1.Visible = false;
            INFOroundedPanel2.Visible = false;
            DDDroundedPanel2.Visible = false;
            PPProundedPanel3.Visible = false;



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
            new products(_userServices, _productServices, _categoryServices, _cartItemService).Show();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            Form users = new users(_userServices, _productServices, _categoryServices);
            users.Show();
            this.Hide();
        }

        private void AdminDashboard_Load_1(object sender, EventArgs e)
        {
        }

        #region Sidebar
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
        //<<<<<<< updd

        private void productbtn_Click(object sender, EventArgs e)
        {

            Form productForm = new products(_userServices, _productServices, _categoryServices, _cartItemService);
            productForm.Show();
            this.Hide();
        }

        private void categorybtn_Click(object sender, EventArgs e)
        {
            Form CategoryForm = new Category(_userServices, _productServices, _categoryServices);
            CategoryForm.Show();
            this.Hide();
        }
        //=======
        #endregion

        //private void categorybtn_Click(object sender, EventArgs e)
        //{

        //}

        private void pnl_sideBar_Paint(object sender, PaintEventArgs e)
        {

        }

        //private void Profilebtn_Click(object sender, EventArgs e)
        //{
        //    roundedPanel1.Visible = true;
        //    // Change the button color
        //    Profilebtn.BackColor = Color.FromArgb(200, 230, 250); // لون ناعم عند المرور
        //    Profilebtn.ForeColor = Color.DarkBlue;
        //    // Reset the other buttons
        //    if (SessionManager.CurrentUser != null)
        //    {
        //        lbl_employeeName.Text = "Welcome \n " + SessionManager.CurrentUser.FirstName;
        //        customTextBox21.Text = SessionManager.CurrentUser.FirstName + " " + SessionManager.CurrentUser.LastName;
        //        customTextBox22.Text = SessionManager.CurrentUser.UserName;
        //        customTextBox23.Text = SessionManager.CurrentUser.Email;
        //        customTextBox24.Text = SessionManager.CurrentUser.Role.ToString();
        //        if (SessionManager.CurrentUser.IsActive == true)
        //            customTextBox25.Text = "Activated";
        //        else
        //            customTextBox25.Text = "Deactivated";

        //    }
        //    else
        //    {
        //        lbl_employeeName.Text = "Guest";
        //    }
        //    MakeReadOnly(customTextBox21);
        //    MakeReadOnly(customTextBox22);
        //    MakeReadOnly(customTextBox23);
        //    MakeReadOnly(customTextBox24);
        //    MakeReadOnly(customTextBox25);



        //}

        private void INFOroundedPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void logoutpicture_Click(object sender, EventArgs e)
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

        private async void button1_Click_1(object sender, EventArgs e)
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

        private void button3_Click(object sender, EventArgs e)
        {
            customTextBox27.Text = string.Empty;
            customTextBox26.Text = string.Empty;
            customTextBox28.Text = string.Empty;
            customTextBox212.Text = string.Empty;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            customTextBox210.Text = string.Empty;
            customTextBox211.Text = string.Empty;
            customTextBox29.Text = string.Empty;
        }

        //private void pictureBox6_Click(object sender, EventArgs e)
        //{
        //roundedPanel1.Visible = true;
        //// Change the button color
        //Profilebtn.BackColor = Color.FromArgb(200, 230, 250); // لون ناعم عند المرور
        //Profilebtn.ForeColor = Color.DarkBlue;
        //// Reset the other buttons
        //if (SessionManager.CurrentUser != null)
        //{
        //    lbl_employeeName.Text = "Welcome \n " + SessionManager.CurrentUser.FirstName;
        //    customTextBox21.Text = SessionManager.CurrentUser.FirstName + " " + SessionManager.CurrentUser.LastName;
        //    customTextBox22.Text = SessionManager.CurrentUser.UserName;
        //    customTextBox23.Text = SessionManager.CurrentUser.Email;
        //    customTextBox24.Text = SessionManager.CurrentUser.Role.ToString();
        //    if (SessionManager.CurrentUser.IsActive == true)
        //        customTextBox25.Text = "Activated";
        //    else
        //        customTextBox25.Text = "Deactivated";


        //}
        //else
        //{
        //    lbl_employeeName.Text = "Guest";
        //}
        //MakeReadOnly(customTextBox21);
        //MakeReadOnly(customTextBox22);
        //MakeReadOnly(customTextBox23);
        //MakeReadOnly(customTextBox24);
        //MakeReadOnly(customTextBox25);


        ////>>>>>>> master
        //}
        private async void Profilebtn_Click(object sender, EventArgs e)
        {
            profilePanelControl1.Visible = true;
            profilePanelControl1.BringToFront();
            profilePanelControl1.ShowProfileSection();
            Profilebtn.BackColor = Color.FromArgb(200, 230, 250);
            Profilebtn.ForeColor = Color.DarkBlue;

        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            Profilebtn_Click(sender, e);
        }
    }
}

















//using E_commerce.Application.DTOs.User;
//using E_commerce.Application.Helper;
//using E_commerce.Application.Hepler;
//using E_commerce.Application.Interfaces;
//using E_commerce.Application.Services;
//using E_commerce.Application.Services.ProductServices;
//using E_commerce.Application.Services.UserServices;
//using E_commerce.Core.Models;
//using System;
//using System.Collections.Generic;
//using System.ComponentModel;
//using System.Data;
//using System.Drawing;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Windows.Forms;

//namespace E_commerce.Presentation
//{
//    public partial class AdminDashboard : Form
//    {
//        #region Ctor
//        private readonly IProductServices _productServices;
//        private readonly ICategoryServices _categoryServices;
//        private readonly IUserServices _userServices;
//        private readonly ICartItemService _cartItemService;



//        //public AdminDashboard(User user)
//        //{
//        //    InitializeComponent();
//        //    this.WindowState = FormWindowState.Maximized;
//        //    roundedPanel1.Visible = false;
//        //    this.DoubleBuffered = true;
//        //    this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
//        //    lbl_employeeName.Text += user.FirstName;
//        //}
//        //public AdminDashboard(IUserServices userServices)
//        //{
//        //    InitializeComponent();
//        //    this.WindowState = FormWindowState.Maximized;
//        //    roundedPanel1.Visible = false;
//        //    this.DoubleBuffered = true;
//        //    this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
//        //    lbl_employeeName.Text += SessionManager.CurrentUser?.FirstName;
//        //    _userServices = userServices;
//        //}
//        public AdminDashboard(IUserServices userServices, User user)
//        {
//            InitializeComponent();
//            this.WindowState = FormWindowState.Maximized;
//            roundedPanel1.Visible = false;
//            this.DoubleBuffered = true;
//            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
//            lbl_employeeName.Text += SessionManager.CurrentUser?.FirstName;
//            _userServices = userServices;

//        }
//        public AdminDashboard(IProductServices productServices, ICategoryServices categoryServices, IUserServices userServices, ICartItemService cartItemService)
//        {
//            InitializeComponent();
//            this.WindowState = FormWindowState.Maximized;
//            roundedPanel1.Visible = false;

//            _productServices = productServices;
//            _categoryServices = categoryServices;
//            _cartItemService = cartItemService;
//            _userServices = userServices;
//            this.DoubleBuffered = true;
//            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
//            lbl_employeeName.Text += SessionManager.CurrentUser?.FirstName;
//        }
//        public AdminDashboard(IProductServices productServices, ICategoryServices categoryServices)
//        {
//            InitializeComponent();
//            this.WindowState = FormWindowState.Maximized;
//            roundedPanel1.Visible = false;
//            _productServices = productServices;
//            _categoryServices = categoryServices;
//            this.DoubleBuffered = true;
//            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
//            lbl_employeeName.Text += SessionManager.CurrentUser?.FirstName;
//        }


//        //public AdminDashboard()
//        //{
//        //    InitializeComponent();
//        //    this.WindowState = FormWindowState.Maximized;
//        //    roundedPanel1.Visible = false;
//        //    this.DoubleBuffered = true;
//        //    this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
//        //    lbl_employeeName.Text += SessionManager.CurrentUser?.FirstName;


//        //}
//        #endregion


//        private void AdminDashboard_Load(object sender, EventArgs e)
//        {

//            this.WindowState = FormWindowState.Maximized;
//            roundedPanel1.Visible = false;
//            this.DoubleBuffered = true;
//            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
//            lbl_employeeName.Text += SessionManager.CurrentUser?.FirstName;



//        }
//        private void btn_logout_Click(object sender, EventArgs e)
//        {
//            SessionManager.Logout();
//            var result = MessageBox.Show("Are you sure you want to log out?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
//            if (result == DialogResult.Yes)
//            {
//                this.Hide();
//                new Login_Form(_userServices).Show();
//            }
//            this.Hide();

//        }
//        private void btn_products_Click(object sender, EventArgs e)
//        {
//            this.Hide();
//            new products(_userServices, _productServices, _categoryServices, _cartItemService).Show();
//        }


//        private void button1_Click(object sender, EventArgs e)
//        {

//        }

//        private void AdminDashboard_Load_1(object sender, EventArgs e)
//        {

//        }

//        #region Sidebar
//        private void logoutbutton_Click(object sender, EventArgs e)
//        {
//            var result = MessageBox.Show("Are you sure you want to log out?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
//            if (result == DialogResult.Yes)
//            {
//                this.Hide();
//                SessionManager.Logout();
//                _userServices.Logout();
//                var loginForm = new Login_Form(_userServices);
//                loginForm.Show();
//            }

//        }
//        #endregion

//        private void categorybtn_Click(object sender, EventArgs e)
//        {

//        }

//        private void pnl_sideBar_Paint(object sender, PaintEventArgs e)
//        {

//        }

//        private void Profilebtn_Click(object sender, EventArgs e)
//        {
//            roundedPanel1.Visible = true;
//            // Change the button color
//            Profilebtn.BackColor = Color.FromArgb(200, 230, 250); // لون ناعم عند المرور
//            Profilebtn.ForeColor = Color.DarkBlue;
//            // Reset the other buttons
//            if (SessionManager.CurrentUser != null)
//            {
//                lbl_employeeName.Text = "Welcome \n " + SessionManager.CurrentUser.FirstName;
//                customTextBox21.Text = SessionManager.CurrentUser.FirstName + " " + SessionManager.CurrentUser.LastName;
//                customTextBox22.Text = SessionManager.CurrentUser.UserName;
//                customTextBox23.Text = SessionManager.CurrentUser.Email;
//                customTextBox24.Text = SessionManager.CurrentUser.Role.ToString();
//                if (SessionManager.CurrentUser.IsActive == true)
//                    customTextBox25.Text = "Activated";
//                else
//                    customTextBox25.Text = "Deactivated";


//            }
//            else
//            {
//                lbl_employeeName.Text = "Guest";
//            }
//            MakeReadOnly(customTextBox21);
//            MakeReadOnly(customTextBox22);
//            MakeReadOnly(customTextBox23);
//            MakeReadOnly(customTextBox24);
//            MakeReadOnly(customTextBox25);



//        }

//        //private void Profilebtn_Click(object sender, EventArgs e)
//        //{
//        //    roundedPanel1.Visible = true;

//        //    // Change the button color
//        //    Profilebtn.BackColor = Color.FromArgb(200, 230, 250); // لون ناعم عند المرور
//        //    Profilebtn.ForeColor = Color.DarkBlue;
//        //    // Reset the other buttons
//        //    if (SessionManager.CurrentUser != null)
//        //    {
//        //        lbl_employeeName.Text = "Welcome \n " + SessionManager.CurrentUser.FirstName;
//        //        customTextBox21.Text = SessionManager.CurrentUser.FirstName + " " + SessionManager.CurrentUser.LastName;
//        //        customTextBox22.Text = SessionManager.CurrentUser.UserName;
//        //        customTextBox23.Text = SessionManager.CurrentUser.Email;
//        //        customTextBox24.Text = SessionManager.CurrentUser.Role.ToString();
//        //        if (SessionManager.CurrentUser.IsActive == true)
//        //            customTextBox25.Text = "Activated";
//        //        else
//        //            customTextBox25.Text = "Deactivated";

//        //    }
//        //    else
//        //    {
//        //        lbl_employeeName.Text = "Guest";
//        //    }
//        //    MakeReadOnly(customTextBox21);
//        //    MakeReadOnly(customTextBox22);
//        //    MakeReadOnly(customTextBox23);
//        //    MakeReadOnly(customTextBox24);
//        //    MakeReadOnly(customTextBox25);



//        //}

//        private void INFOroundedPanel2_Paint(object sender, PaintEventArgs e)
//        {

//        }

//        private void logoutpicture_Click(object sender, EventArgs e)
//        {
//            var result = MessageBox.Show("Are you sure you want to log out?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
//            if (result == DialogResult.Yes)
//            {
//                this.Hide();
//                SessionManager.Logout();
//                _userServices.Logout();
//                var loginForm = new Login_Form(_userServices);
//                loginForm.Show();
//            }
//        }

//        private async void button1_Click_1(object sender, EventArgs e)
//        {
//            var user = SessionManager.CurrentUser;
//            if (user != null)
//            {
//                var updateDto = new AddUserDTO
//                {
//                    UserName = customTextBox27.Text,
//                    Password = user.Password, // خليها نفس الباسورد الأصلي
//                    PasswordConfirmed = user.Password,
//                    Email = customTextBox26.Text,
//                    FirstName = customTextBox28.Text,
//                    LastName = customTextBox212.Text
//                };

//                var result = await _userServices.UpdateUser(updateDto);

//                if (!result.Succeeded)
//                {
//                    MessageBox.Show(string.Join("\n", result.Errors), "Update Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
//                    return;
//                }

//                user.UserName = updateDto.UserName;
//                user.Email = updateDto.Email;
//                user.FirstName = updateDto.FirstName;
//                user.LastName = updateDto.LastName;

//                MessageBox.Show("User information updated successfully.");

//                customTextBox27.Text = string.Empty;
//                customTextBox26.Text = string.Empty;
//                customTextBox28.Text = string.Empty;
//                customTextBox212.Text = string.Empty;

//                this.Hide();
//                var dashboard = new Dashboard(_userServices, user);
//                dashboard.Show();
//            }
//            else
//            {
//                MessageBox.Show("User not found.");
//            }
//        }

//        private async void ChangePassword_Click(object sender, EventArgs e)
//        {
//            var user = SessionManager.CurrentUser;
//            if (user != null)
//            {
//                var updatepass = new ChangePasswordDTO
//                {
//                    OldPassword = customTextBox210.Text,
//                    NewPassword = customTextBox211.Text,
//                    ConfirmPassword = customTextBox29.Text
//                };

//                var isOldPasswordCorrect = PasswordHelper.VerifyPassword(user.Password, updatepass.OldPassword);
//                if (!isOldPasswordCorrect)
//                {
//                    MessageBox.Show("The old password is incorrect.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
//                    return;
//                }

//                if (updatepass.NewPassword != updatepass.ConfirmPassword)
//                {
//                    MessageBox.Show("New Password and Confirm Password do not match", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
//                    return;
//                }

//                var isValidPassword = PasswordHelper.IsStrongPassword(updatepass.NewPassword);
//                if (!isValidPassword)
//                {
//                    MessageBox.Show("The password is invalid. It must contain an upper letter, a lowercase letter, and a number.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
//                    return;
//                }

//                var addu = new AddUserDTO
//                {
//                    UserName = user.UserName,
//                    Password = updatepass.NewPassword,
//                    PasswordConfirmed = updatepass.ConfirmPassword,
//                    Email = user.Email,
//                    FirstName = user.FirstName,
//                    LastName = user.LastName
//                };

//                var result = await _userServices.UpdateUser(addu);
//                if (result.Succeeded)
//                {
//                    SessionManager.CurrentUser.Password = PasswordHelper.HashPassword(updatepass.NewPassword);
//                    MessageBox.Show("Password updated successfully.");
//                    customTextBox210.Text = string.Empty;
//                    customTextBox211.Text = string.Empty;
//                    customTextBox29.Text = string.Empty;
//                }
//                else
//                {
//                    MessageBox.Show(string.Join("\n", result.Errors), "Update Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
//                }
//            }
//            else
//            {
//                MessageBox.Show("User not found.");
//            }
//        }

//        private void button3_Click(object sender, EventArgs e)
//        {
//            customTextBox27.Text = string.Empty;
//            customTextBox26.Text = string.Empty;
//            customTextBox28.Text = string.Empty;
//            customTextBox212.Text = string.Empty;
//        }

//        private void button2_Click(object sender, EventArgs e)
//        {
//            customTextBox210.Text = string.Empty;
//            customTextBox211.Text = string.Empty;
//            customTextBox29.Text = string.Empty;
//        }

//        private void pictureBox6_Click(object sender, EventArgs e)
//        {
//            roundedPanel1.Visible = true;
//            // Change the button color
//            Profilebtn.BackColor = Color.FromArgb(200, 230, 250); // لون ناعم عند المرور
//            Profilebtn.ForeColor = Color.DarkBlue;
//            // Reset the other buttons
//            if (SessionManager.CurrentUser != null)
//            {
//                lbl_employeeName.Text = "Welcome \n " + SessionManager.CurrentUser.FirstName;
//                customTextBox21.Text = SessionManager.CurrentUser.FirstName + " " + SessionManager.CurrentUser.LastName;
//                customTextBox22.Text = SessionManager.CurrentUser.UserName;
//                customTextBox23.Text = SessionManager.CurrentUser.Email;
//                customTextBox24.Text = SessionManager.CurrentUser.Role.ToString();
//                if (SessionManager.CurrentUser.IsActive == true)
//                    customTextBox25.Text = "Activated";
//                else
//                    customTextBox25.Text = "Deactivated";


//            }
//            else
//            {
//                lbl_employeeName.Text = "Guest";
//            }
//            MakeReadOnly(customTextBox21);
//            MakeReadOnly(customTextBox22);
//            MakeReadOnly(customTextBox23);
//            MakeReadOnly(customTextBox24);
//            MakeReadOnly(customTextBox25);


//        }
//    }
//}
