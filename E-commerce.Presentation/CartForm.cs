using E_commerce.Application.Services;
using E_commerce.Application.DTOs.CartItem;
using E_commerce.Application.Helper;
using System;
using System.Linq;
using System.Windows.Forms;
using E_commerce.Application.DTOs;
using E_commerce.Application.Services.ProductServices;
using E_commerce.Presentation.CustomControls;
using E_commerce.Application.Services.UserServices;
using E_commerce.Application.Services.OrderService;

namespace E_commerce.Presentation
{
    public partial class CartItemForm : Form
    {
        private readonly ICartItemService _cartItemService;
        private readonly IProductServices _productService;
        private readonly IUserServices _userServices;
        private readonly IOrderService _orderService;

        public CartItemForm()
        {
            InitializeComponent();
            // Remove the window controls since we're embedding
            closeButton.Visible = false;
            minimizeButton.Visible = false;
            maximizeButton.Visible = false;

            // Adjust layout for embedding
            this.Padding = new Padding(20);
            cartDataGridView.Location = new Point(20, 60);
            cartDataGridView.Size = new Size(this.ClientSize.Width - 40, this.ClientSize.Height - 180);

            totalLabel.Location = new Point(this.ClientSize.Width - 200, this.ClientSize.Height - 100);
            totalTextBox.Location = new Point(this.ClientSize.Width - 120, this.ClientSize.Height - 100);

            updateButton.Location = new Point(this.ClientSize.Width - 300, this.ClientSize.Height - 60);
            checkoutButton.Location = new Point(this.ClientSize.Width - 160, this.ClientSize.Height - 60);

            titleLabel.Location = new Point(20, 20);
        }

        public CartItemForm(ICartItemService cartItemService, IProductServices productServices, IUserServices userServices,IOrderService orderService)
        : this() // Call the default constructor first
        {
            _cartItemService = cartItemService;
            _productService = productServices;
            _userServices = userServices;
            _orderService = orderService;
            cartDataGridView.CellContentClick += cartDataGridView_CellContentClick;

            SidebarControl sidebarControl = new SidebarControl(_userServices);
            sidebarControl.Visible = true;
            this.Controls.Add(sidebarControl);
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
                // Clear existing columns
                cartDataGridView.Columns.Clear();
                cartDataGridView.AutoGenerateColumns = false;

                // Create columns with proper formatting
                cartDataGridView.Columns.Add(new DataGridViewTextBoxColumn
                {
                    DataPropertyName = "Name",
                    HeaderText = "Product Name",
                    Name = "Name",
                    ReadOnly = true,
                    Width = 200
                });

                cartDataGridView.Columns.Add(new DataGridViewTextBoxColumn
                {
                    DataPropertyName = "Price",
                    HeaderText = "Price",
                    Name = "Price",
                    ReadOnly = true,
                    DefaultCellStyle = new DataGridViewCellStyle
                    {
                        Format = "C2",
                        Alignment = DataGridViewContentAlignment.MiddleRight
                    }
                });

                cartDataGridView.Columns.Add(new DataGridViewTextBoxColumn
                {
                    DataPropertyName = "Quantity",
                    HeaderText = "Quantity",
                    Name = "Quantity",
                    Width = 60,
                    DefaultCellStyle = new DataGridViewCellStyle
                    {
                        Alignment = DataGridViewContentAlignment.MiddleCenter
                    }
                });
                cartDataGridView.Columns.Add(new DataGridViewTextBoxColumn
                {
                    DataPropertyName = "DateAdded",
                    HeaderText = "Date Added",
                    Name = "DateAdded",
                    Visible = true
                });

                // Add Remove button column
                var removeColumn = new DataGridViewButtonColumn
                {
                    Name = "Remove",
                    HeaderText = "Action",
                    Text = "Remove",
                    UseColumnTextForButtonValue = true,
                    Width = 80
                };
                cartDataGridView.Columns.Add(removeColumn);

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

                // Set data source
                cartDataGridView.DataSource = enrichedItems.ToList();

                // Calculate and display total
                decimal total = enrichedItems.Sum(item => item.Price * item.Quantity);
                totalTextBox.Text = total.ToString("C2");
            }
            else
            {
                MessageBox.Show("Failed to load cart items: " + string.Join(", ", response.Errors),
                               "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            var cartItems = (cartDataGridView.DataSource as List<CartItemDTO>)?.ToList() ?? new List<CartItemDTO>();
            if (cartItems.Count == 0)
            {
                MessageBox.Show("Your cart is empty.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            var orderForm = new OrderForm(cartItems, this, _orderService, _cartItemService);
            orderForm.Show();
            this.Hide();
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
