using E_commerce.Application.DTOs.User;
using E_commerce.Application.Helper;
using E_commerce.Application.Hepler;
using E_commerce.Application.Interfaces;
using E_commerce.Application.Services;
using E_commerce.Application.Services.ProductServices;
using E_commerce.Application.Services.UserServices;
using E_commerce.Core.Models;
using E_commerce.Presentation.CustomControls;
using Ecommerce;
using Guna.UI2.WinForms;
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

        private bool isUpdateMode = false;
        private int currentProductId = 0;


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
            flowLayoutPanel1.Visible = false;
            AddProductButton.Visible = false;
            UpdateProductButton.Visible = false;
            DeleteProductButton.Visible = false;
            gamedPanel.Visible = false;
            panel1.Visible = false;

            LoadProducts();
            LoadCategories();

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
            Form CategoryForm = new Category(_userServices, _productServices, _categoryServices , _cartItemService);
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

        private void productbtn_Click_1(object sender, EventArgs e)
        {
            flowLayoutPanel1.Visible = true;
            AddProductButton.Visible = true;
            gamedPanel.Visible = true;
            UpdateProductButton.Visible = true;
            DeleteProductButton.Visible = true;



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


        private async void LoadCategories()
        {
            try
            {
                var categories = await _categoryServices.GetAllCategoriesWithProductsAsync();
                if (categories.Succeeded)
                {
                    CategoryComboBox.DataSource = categories.Data;
                    CategoryComboBox.DisplayMember = "Name";
                    CategoryComboBox.ValueMember = "CategoryID";
                    //FilterCatCombo.DataSource = categories.Data;
                    //FilterCatCombo.DisplayMember = "Name";
                    //FilterCatCombo.ValueMember = "CategoryID";
                }
                else
                {
                    ShowErrorMessage("Failed to load categories.");
                }
            }
            catch (Exception ex)
            {
                ShowErrorMessage($"Error loading categories: {ex.Message}");
            }
        }

        private void ShowErrorMessage(string message)
        {
            MessageBox.Show(this, message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void SearchTextBox_TextChanged(object sender, EventArgs e)
        {
            var text = SearchTextBox.Text.ToLower();
            flowLayoutPanel1.Visible = true;
            AddProductButton.Visible = true;
            UpdateProductButton.Visible = true;
            DeleteProductButton.Visible = true;

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

        private void ResetForm()
        {
            NameText.Text = "";
            DescTextBox.Text = "";
            PriceTextBox.Text = "0";
            UnitsInStockTextBox.Text = "0";
            ImagePath.Image = null;
            ImagePath.Text = "";
            isUpdateMode = false;
            currentProductId = 0;
            SaveButton.Text = "Save";
        }

        private void AddProductButton_Click(object sender, EventArgs e)
        {
            panel1.Visible = true;
            flowLayoutPanel1.Visible = false;
            ResetForm();
            isUpdateMode = false;
            SaveButton.Text = "Save";
        }


        private bool ValidateInputs()
        {
            if (string.IsNullOrWhiteSpace(NameText.Text))
            {
                ShowErrorMessage("Please enter product name");
                return false;
            }

            if (string.IsNullOrWhiteSpace(DescTextBox.Text))
            {
                ShowErrorMessage("Please enter product description");
                return false;
            }

            if (!decimal.TryParse(PriceTextBox.Text, out decimal price) || price <= 0)
            {
                ShowErrorMessage("Please enter a valid price (greater than 0)");
                return false;
            }

            if (!int.TryParse(UnitsInStockTextBox.Text, out int units) || units < 0)
            {
                ShowErrorMessage("Please enter valid stock quantity (0 or greater)");
                return false;
            }

            if (CategoryComboBox.SelectedValue == null)
            {
                ShowErrorMessage("Please select a category");
                return false;
            }
            return true;
        }

        private void ShowSuccessMessage(string message)
        {
            Guna.UI2.WinForms.Guna2MessageDialog toast = new Guna.UI2.WinForms.Guna2MessageDialog();
            toast.Caption = "Success";
            toast.Text = message;
            toast.Icon = MessageDialogIcon.Information;
            toast.Style = MessageDialogStyle.Light;
            toast.Show();
        }

        private async void SaveButton_Click(object sender, EventArgs e)
        {
            if (!ValidateInputs())
                return;

            try
            {
                if (isUpdateMode)
                {
                    var updateDto = new Application.DTOs.Product.CreateProductDto
                    {
                        Name = NameText.Text.Trim(),
                        Description = DescTextBox.Text.Trim(),
                        Price = decimal.Parse(PriceTextBox.Text),
                        UnitsInStock = int.Parse(UnitsInStockTextBox.Text),
                        CategoryID = (int)CategoryComboBox.SelectedValue,
                        ImagePath = ImagePath.Text
                    };

                    var result = await _productServices.UpdateProductAsync(currentProductId, updateDto);

                    if (result.Succeeded)
                    {
                        ShowSuccessMessage("Product Updated Successfully!");
                        LoadProducts();
                        ResetForm();
                        panel1.Visible = false;

                        flowLayoutPanel1.Visible = true;
                    }
                    else
                    {
                        ShowErrorMessage($"Failed to update product. Error: {result.Errors}");
                    }
                }
                else
                {
                    var productDto = new Application.DTOs.Product.CreateProductDto
                    {
                        Name = NameText.Text.Trim(),
                        Description = DescTextBox.Text.Trim(),
                        Price = decimal.Parse(PriceTextBox.Text),
                        UnitsInStock = int.Parse(UnitsInStockTextBox.Text),
                        CategoryID = (int)CategoryComboBox.SelectedValue
                    };

                    var result = await _productServices.AddProductAsync(
                        productDto,
                        string.IsNullOrWhiteSpace(ImagePath.Text) ? null : ImagePath.Text);

                    if (result.Succeeded)
                    {
                        ShowSuccessMessage("Product Added Successfully!");
                        LoadProducts();
                        ResetForm();
                        panel1.Visible = false;
                        flowLayoutPanel1.Visible = true;
                    }
                    else
                    {
                        ShowErrorMessage($"Failed to add product. Error: {result.Errors}");
                    }
                }
            }
            catch (Exception ex)
            {
                ShowErrorMessage($"An error occurred: {ex.Message}");
            }
        }

        private async void UpdateProductButton_Click(object sender, EventArgs e)
        {
            if (UserControl1.existProductControl == null)
            {
                ShowErrorMessage("Please select a product first");
                return;
            }

            isUpdateMode = true;
            currentProductId = UserControl1.existProductControl._id;

            SaveButton.Text = "Update";
            panel1.Visible = true;
            flowLayoutPanel1.Visible = false;

            try
            {
                var product = await _productServices.GetProducByIdAsync(currentProductId);
                if (product.Succeeded && product.Data != null)
                {
                    var productData = product.Data;
                    NameText.Text = productData.Name;
                    DescTextBox.Text = productData.Description;
                    PriceTextBox.Text = productData.Price.ToString();
                    UnitsInStockTextBox.Text = productData.UnitsInStock.ToString();

                    CategoryComboBox.SelectedValue = productData.CategoryID;

                    if (!string.IsNullOrEmpty(productData.ImagePath) && File.Exists(productData.ImagePath))
                    {
                        ImagePath.Image = Image.FromFile(productData.ImagePath);
                        ImagePath.SizeMode = PictureBoxSizeMode.StretchImage;
                        ImagePath.Text = productData.ImagePath;
                    }
                    else
                    {
                        ImagePath.Image = null;
                        ImagePath.Text = "";
                    }
                }
                else
                {
                    ShowErrorMessage("Product data could not be loaded");
                }
            }
            catch (Exception ex)
            {
                ShowErrorMessage($"Error: {ex.Message}");
            }
        }

        private async void DeleteProductButton_Click(object sender, EventArgs e)
        {
            UserControl1 existUserControl = UserControl1.existProductControl;
            if (existUserControl != null)
            {
                int productId = existUserControl._id;
                var result = await _productServices.DeleteProductAsync(productId);
                if (result.Succeeded)
                {
                    ShowSuccessMessage("Product Deleted Successfully!");
                    LoadProducts();
                }
                else
                {
                    ShowErrorMessage("Failed to delete product.");
                }
            }
            else
            {
                ShowErrorMessage("No product selected.");
            }
        }

        private void guna2CircleButton1_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
        }

        private void ImagePath_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Title = "Choose Product Image";
                ofd.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";
                ofd.Multiselect = false;

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        ImagePath.Image = Image.FromFile(ofd.FileName);
                        ImagePath.SizeMode = PictureBoxSizeMode.StretchImage;
                        ImagePath.Text = ofd.FileName;
                    }
                    catch (Exception ex)
                    {
                        ShowErrorMessage($"Error loading image: {ex.Message}");
                    }
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Dashboard dashboard = new Dashboard(_userServices, _productServices, _cartItemService);
            dashboard.Show();
            this.Hide();
        }

        private void gamedPanel_Paint(object sender, PaintEventArgs e)
        {

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
