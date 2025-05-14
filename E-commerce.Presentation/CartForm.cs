using E_commerce.Application.Services;
using E_commerce.Application.DTOs.CartItem;
using E_commerce.Application.Helper;
using System;
using System.Linq;
using System.Windows.Forms;
using E_commerce.Application.DTOs;
using E_commerce.Application.Services.ProductServices;

namespace E_commerce.Presentation
{
    public partial class CartItemForm : Form
    {
        private readonly ICartItemService _cartItemService;
        private readonly IProductServices _productService;

        public CartItemForm(ICartItemService cartItemService, IProductServices productServices)
        {
            InitializeComponent();
            _cartItemService = cartItemService;
            _productService = productServices;

            this.WindowState = FormWindowState.Maximized;
            this.Size = Screen.PrimaryScreen.Bounds.Size;
            this.MaximizeBox = true;
            this.MinimizeBox = true;
        }

        private async void CartItemForm_Load(object sender, EventArgs e)
        {
            await LoadCartItems();
        }

        private async Task LoadCartItems()
        {

            var userId = SessionManager.CurrentUser?.UserID ?? 3;
            var response = await _cartItemService.GetCartItemsByUserIdAsync(userId);
            if (response.Succeeded)
            {
                // Clear existing columns to redefine them
                cartDataGridView.Columns.Clear();
                cartDataGridView.AutoGenerateColumns = false;

                // Define columns manually
             
               
                
                cartDataGridView.Columns.Add(new DataGridViewTextBoxColumn
                {
                    DataPropertyName = "Name",
                    HeaderText = "Product Name",
                    Name = "Name",
                    ReadOnly = true
                });
                cartDataGridView.Columns.Add(new DataGridViewTextBoxColumn
                {
                    DataPropertyName = "Price",
                    HeaderText = "Price",
                    Name = "Price",
                    ReadOnly = true
                });
                cartDataGridView.Columns.Add(new DataGridViewTextBoxColumn
                {
                    DataPropertyName = "Quantity",
                    HeaderText = "Quantity",
                    Name = "Quantity",
                    ReadOnly = false
                });
                cartDataGridView.Columns.Add(new DataGridViewTextBoxColumn
                {
                    DataPropertyName = "DateAdded",
                    HeaderText = "Date Added",
                    Name = "DateAdded",
                    Visible = true
                });
                cartDataGridView.Columns.Add(new DataGridViewTextBoxColumn
                {
                    DataPropertyName = "TotalPrice",
                    HeaderText = "Total Price",
                    Name = "TotalPrice",
                    Visible = false
                });

                // Add Remove button column
                if (!cartDataGridView.Columns.Contains("Remove"))
                {
                    var removeColumn = new DataGridViewButtonColumn
                    {
                        Name = "Remove",
                        HeaderText = "Action",
                        Text = "Remove",
                        UseColumnTextForButtonValue = true
                    };
                    cartDataGridView.Columns.Add(removeColumn);
                }

                // Enrich cart items with product details
                var enrichedItems = await Task.WhenAll(response.Data.Select(async item =>
                {

                    var productResponse = await _productService.GetProducByIdAsync(item.ProductID);
                    if (productResponse.Succeeded)
                    {
                        item.Name = productResponse.Data?.Name ?? "Unknown Product";
                        item.Price = productResponse.Data?.Price ?? 0m;
                    }
                    return item;
                }));

                // Debug: Inspect the raw data before binding
                Console.WriteLine($"Number of cart items retrieved: {enrichedItems.Count()}");
                foreach (var item in enrichedItems)
                {
                    Console.WriteLine($"CartItemID: {item.CartItemID}, ProductID: {item.ProductID}, Name: {item.Name ?? "NULL"}, Price: {item.Price}, Quantity: {item.Quantity}, TotalPrice: {item.TotalPrice}");
                }

                // Set the data source
                cartDataGridView.DataSource = enrichedItems.ToList();

                // Debug: Verify column headers
                foreach (DataGridViewColumn column in cartDataGridView.Columns)
                {
                    Console.WriteLine($"Column: {column.Name}, HeaderText: {column.HeaderText}, Visible: {column.Visible}");
                }

                // Calculate and display total
                decimal total = enrichedItems.Sum(item => item.TotalPrice);
                totalTextBox.Text = total.ToString("F2");
            }
            else
            {
                MessageBox.Show("Failed to load cart items: " + string.Join(", ", response.Errors), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void UpdateButton_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in cartDataGridView.Rows)
            {
                var cartItem = row.DataBoundItem as CartItemDTO;
                if (cartItem != null)
                {
                    if (int.TryParse(row.Cells["Quantity"].Value?.ToString(), out int newQuantity))
                    {
                        cartItem.Quantity = newQuantity;
                    }

                    var updateDto = new UpdateCartItemDTO
                    {
                        CartItemID = cartItem.CartItemID,
                        Quantity = cartItem.Quantity
                    };
                    var response = await _cartItemService.UpdateCartItemAsync(updateDto);
                    if (!response.Succeeded)
                    {
                        MessageBox.Show($"Failed to update item {cartItem.Name}: " + string.Join(", ", response.Errors), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            await LoadCartItems();
        }

        private async void cartDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex < 0 || e.RowIndex < 0) return;

            if (cartDataGridView.Columns[e.ColumnIndex].Name == "Remove")
            {
                var cartItem = cartDataGridView.Rows[e.RowIndex].DataBoundItem as CartItemDTO;
                if (cartItem != null)
                {
                    var response = await _cartItemService.RemoveCartItemAsync(cartItem.CartItemID);
                    if (response.Succeeded)
                    {
                        await LoadCartItems();
                    }
                    else
                    {
                        MessageBox.Show("Failed to remove item: " + string.Join(", ", response.Errors), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void CheckoutButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Checkout functionality to be implemented.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void ReturnButton_Click(object sender, EventArgs e)
        {
            // Assuming products form needs to be resolved differently without IContainer
            // You may need to adjust this based on your DI setup
            var productsForm = new products(); // Direct instantiation as a fallback
            productsForm.Show();
            this.Close();
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void MinimizeButton_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void MaximizeButton_Click(object sender, EventArgs e)
        {
            this.WindowState = this.WindowState == FormWindowState.Maximized ? FormWindowState.Normal : FormWindowState.Maximized;
        }
    }
}