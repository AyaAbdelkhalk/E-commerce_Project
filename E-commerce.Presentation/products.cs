using E_commerce.Application.Services.ProductServices;
using E_commerce.Application.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Ecommerce;
using Guna.UI2.WinForms;
using E_commerce.Core.Models;

namespace E_commerce.Presentation
{
    public partial class products : Form
    {
        private readonly IProductServices _productServices;
        private readonly ICategoryServices _categoryServices;
        private bool isUpdateMode = false;
        private int currentProductId = 0;

        public products(IProductServices productServices, ICategoryServices categoryServices)
        {
            InitializeComponent();
            _productServices = productServices;
            _categoryServices = categoryServices;


            LoadCategories();
            SetupForm();

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

        private void SetupForm()
        {
            this.StartPosition = FormStartPosition.CenterScreen;
            PriceTextBox.Text = "0";
            UnitsInStockTextBox.Text = "0";
            flowLayoutPanel1.AutoScroll = true;
            SaveButton.Text = "Save";
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
                        UserControl1 userControl = new UserControl1(product.ProductID, product.Name);
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
            MessageBox.Show(this, message, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void AddProductButton_Click(object sender, EventArgs e)
        {
            panel1.Visible = true;
            flowLayoutPanel1.Visible = false;
            ResetForm();
            isUpdateMode = false;
            SaveButton.Text = "Save";
        }

        private void guna2GradientCircleButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void guna2CircleButton1_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
        }

        private void products_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            panel1.Visible = false;
            flowLayoutPanel1.Visible = false;
            LoadProducts();
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

        private void ImagePath_Click_1(object sender, EventArgs e)
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

        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {
            flowLayoutPanel1.Visible = !flowLayoutPanel1.Visible;
            if (flowLayoutPanel1.Visible)
            {
                LoadProducts();
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
                    ShowSuccessMessage("Product Deleted SuccessFully!");
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

        private void guna2CircleButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void guna2CircleButton4_Click(object sender, EventArgs e)
        {

            //this.WindowState = FormWindowState.Maximized;
        }

        private void guna2CircleButton3_Click(object sender, EventArgs e)
        {
            //this.WindowState = FormWindowState.Minimized;
        }

        private void guna2CustomGradientPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void flowLayoutPanel1_MouseClick(object sender, MouseEventArgs e)
        {
            if (UserControl1.existProductControl != null)
            {
                UserControl1.existProductControl.Deselect();
                UserControl1.existProductControl = null;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Category category = new Category(_productServices, _categoryServices);
            category.Show();
            this.Hide();
        }
    }
}