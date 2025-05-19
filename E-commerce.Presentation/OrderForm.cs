using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Guna.UI2.WinForms;
using Guna.UI2.WinForms.Suite;
using E_commerce.Application.DTOs.CartItem;
using E_commerce.Application.Services;
using E_commerce.Application.Services.OrderService;
using E_commerce.Application.Helper;
using E_commerce.Application.DTOs;
using E_commerce.Application.Services.ProductServices;
using E_commerce.Presentation.CustomControls;

namespace E_commerce.Presentation
{
    public partial class OrderForm : Form
    {
        private readonly List<CartItemDTO> _cartItems;
        private readonly CartItemForm _cartForm;
        private readonly IOrderService _orderService;
        private readonly ICartItemService _cartItemService;
        private readonly IProductServices _productService;
        private readonly CartControl _cartControl;
        private readonly int? _orderId; // Added to store order ID

        public OrderForm()
        {
            InitializeComponent();
            // Remove window controls since we're embedding
            guna2CircleButtonClose.Visible = false;
            guna2CircleButtonMinimize.Visible = false;
            guna2CircleButtonMaximize.Visible = false;

            // Adjust layout for embedding
            this.Padding = new Padding(20);
            dataGridViewCart.Location = new Point(20, 60);
            dataGridViewCart.Size = new Size(this.ClientSize.Width - 40, this.ClientSize.Height - 180);

            guna2HtmlLabelTotal.Location = new Point(this.ClientSize.Width - 200, this.ClientSize.Height - 100);
            textBoxTotal.Location = new Point(this.ClientSize.Width - 120, this.ClientSize.Height - 100);

            btnOK.Location = new Point(this.ClientSize.Width - 300, this.ClientSize.Height - 60);
            btnCancel.Location = new Point(this.ClientSize.Width - 160, this.ClientSize.Height - 60);

            titleLabel.Location = new Point(20, 20);
        }

        public OrderForm(List<CartItemDTO> cartItems, CartItemForm cartForm, IOrderService orderService, ICartItemService cartItemService, IProductServices productServices, int? orderId = null) : this()
        {
            _cartItems = cartItems ?? new List<CartItemDTO>();
            _cartForm = cartForm ?? throw new ArgumentNullException(nameof(cartForm));
            _orderService = orderService ?? throw new ArgumentNullException(nameof(orderService));
            _cartItemService = cartItemService ?? throw new ArgumentNullException(nameof(cartItemService));
            _productService = productServices ?? throw new ArgumentNullException(nameof(productServices));
            _orderId = orderId; // Initialize orderId
        }

        public OrderForm(List<CartItemDTO> cartItems, CartControl cartControl, IOrderService orderService, ICartItemService cartItemService, IProductServices productServices, int? orderId = null) : this()
        {
            _cartItems = cartItems ?? new List<CartItemDTO>();
            _cartControl = cartControl;
            _orderService = orderService ?? throw new ArgumentNullException(nameof(orderService));
            _cartItemService = cartItemService ?? throw new ArgumentNullException(nameof(cartItemService));
            _productService = productServices ?? throw new ArgumentNullException(nameof(productServices));
            _orderId = orderId; // Initialize orderId
        }

        private void OrderForm_Load(object sender, EventArgs e)
        {
            // Configure DataGridView columns
            dataGridViewCart.Columns.Clear();
            dataGridViewCart.AutoGenerateColumns = false;

            dataGridViewCart.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Name",
                HeaderText = "Product Name",
                Name = "Name",
                ReadOnly = true,
                Width = 200
            });

            dataGridViewCart.Columns.Add(new DataGridViewTextBoxColumn
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

            dataGridViewCart.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Quantity",
                HeaderText = "Quantity",
                Name = "Quantity",
                ReadOnly = true,
                Width = 60,
                DefaultCellStyle = new DataGridViewCellStyle
                {
                    Alignment = DataGridViewContentAlignment.MiddleCenter
                }
            });

            dataGridViewCart.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "DateAdded",
                HeaderText = "Date Added",
                Name = "DateAdded",
                ReadOnly = true
            });

            // Set data source
            dataGridViewCart.DataSource = _cartItems;

            // Calculate and display total
            decimal total = _cartItems.Sum(item => item.Price * item.Quantity);
            textBoxTotal.Text = total.ToString("C2");
        }

        private void dataGridViewCart_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // No action required for now
        }

        private async void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                if (_orderService == null)
                {
                    MessageBox.Show("Order service is not initialized.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var userId = SessionManager.CurrentUser?.UserID ?? 3; // Replace with actual user ID

                // Create the order using OrderService
                var response = await _orderService.CheckoutAsync(userId);
                if (!response.Succeeded)
                {
                    MessageBox.Show($"Failed to create order: {string.Join(", ", response.Errors)}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Delete all cart items for the user
                var cartResponse = await _cartItemService.ClearCartAsync(userId);
                if (!cartResponse.Succeeded)
                {
                    MessageBox.Show($"Failed to clear cart: {string.Join(", ", cartResponse.Errors)}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Navigate to MyOrdersForm
                //var myOrdersForm = new MyOrdersForm(_orderService,_productService);
                //myOrdersForm.Show();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to create order: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnCancel_Click(object sender, EventArgs e)
        {
            try
            {
                if (_orderId.HasValue)
                {
                    // Cancel the existing order
                    var response = await _orderService.CancelOrderAsync(_orderId.Value);
                    if (response.Succeeded)
                    {
                        MessageBox.Show(response.Data, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show($"Failed to cancel order: {string.Join(", ", response.Errors)}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                else if (_cartItems.Any())
                {
                    // Clear the cart if no order exists but cart items are present
                    var userId = SessionManager.CurrentUser?.UserID ?? 3; // Replace with actual user ID
                    var cartResponse = await _cartItemService.ClearCartAsync(userId);
                    if (cartResponse.Succeeded)
                    {
                        MessageBox.Show("Cart cleared successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show($"Failed to clear cart: {string.Join(", ", cartResponse.Errors)}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }

                // Navigate back to CartItemForm or refresh CartControl
                if (_cartForm != null)
                {
                    _cartForm.Show();
                }

                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void guna2CircleButtonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void guna2CircleButtonMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void guna2CircleButtonMaximize_Click(object sender, EventArgs e)
        {
            this.WindowState = this.WindowState == FormWindowState.Maximized ? FormWindowState.Normal : FormWindowState.Maximized;
        }
    }
}