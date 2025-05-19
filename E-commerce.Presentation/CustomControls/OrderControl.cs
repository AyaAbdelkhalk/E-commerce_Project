using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Guna.UI2.WinForms;
using E_commerce.Application.DTOs.CartItem;
using E_commerce.Application.Services;
using E_commerce.Application.Services.OrderService;
using E_commerce.Application.Helper;
using E_commerce.Application.Services.ProductServices;
using E_commerce.Application.DTOs;

namespace E_commerce.Presentation.CustomControls
{
    public partial class OrderControl : UserControl
    {
        private readonly List<CartItemDTO> _cartItems;
        private readonly IOrderService _orderService;
        private readonly ICartItemService _cartItemService;
        private readonly IProductServices _productService;

        public OrderControl()
        {
            InitializeComponent();
        }

        public OrderControl(List<CartItemDTO> cartItems, IOrderService orderService, ICartItemService cartItemService, IProductServices productServices)
        {
            InitializeComponent();
            _cartItems = cartItems ?? new List<CartItemDTO>();
            _orderService = orderService ?? throw new ArgumentNullException(nameof(orderService));
            _cartItemService = cartItemService ?? throw new ArgumentNullException(nameof(cartItemService));
            _productService = productServices ?? throw new ArgumentNullException(nameof(productServices));
            SetupControl();
        }

        private void SetupControl()
        {
            // Initialize and layout controls
            this.Size = new Size(800, 650);
            this.BackColor = Color.White;

            // Position controls with relative positioning
            int margin = 20;
            dataGridViewCart.Location = new Point(margin, 60);
            dataGridViewCart.Size = new Size(this.Width - (2 * margin), this.Height - 180);

            guna2HtmlLabelTotal.Location = new Point(this.Width - 200, this.Height - 100);
            textBoxTotal.Location = new Point(this.Width - 120, this.Height - 100);

            btnOK.Location = new Point(this.Width - 300, this.Height - 60);
            btnCancel.Location = new Point(this.Width - 160, this.Height - 60);

            titleLabel.Location = new Point(margin, 20);
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            LoadCartItems();
        }

        private void LoadCartItems()
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
                DefaultCellStyle = new DataGridViewCellStyle
                {
                    Alignment = DataGridViewContentAlignment.MiddleLeft
                },
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
                    Alignment = DataGridViewContentAlignment.MiddleLeft
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
                    Alignment = DataGridViewContentAlignment.MiddleLeft
                }
            });

            dataGridViewCart.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "DateAdded",
                HeaderText = "Date Added",
                Name = "DateAdded",
                DefaultCellStyle = new DataGridViewCellStyle
                {
                    Alignment = DataGridViewContentAlignment.MiddleLeft
                },
                ReadOnly = true
            });

            // Set data source
            dataGridViewCart.DataSource = _cartItems;

            // Calculate and display total
            decimal total = _cartItems.Sum(item => item.Price * item.Quantity);
            textBoxTotal.Text = total.ToString("C2");
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

                // Navigate to Dashboard content
                var parentForm = this.FindForm();
                if (parentForm != null)
                {
                    // Remove existing user controls (except SidebarControl)
                    var existingControls = parentForm.Controls.OfType<UserControl>().Where(c => c != this && c.GetType() != typeof(SidebarControl)).ToList();
                    foreach (var control in existingControls)
                    {
                        parentForm.Controls.Remove(control);
                    }

                    // Show Dashboard content (flowLayoutPanel1 and SearchTextBox)
                    var flowLayoutPanel = parentForm.Controls.OfType<FlowLayoutPanel>().FirstOrDefault();
                    if (flowLayoutPanel != null)
                    {
                        flowLayoutPanel.Visible = true;
                    }

                    var searchTextBox = parentForm.Controls.Find("SearchTextBox", true).FirstOrDefault();
                    if (searchTextBox != null)
                    {
                        searchTextBox.Visible = true;
                    }

                    

                    // Remove this OrderControl
                    parentForm.Controls.Remove(this);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to create order: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            // Navigate back to CartControl
            var parentForm = this.FindForm();
            if (parentForm != null)
            {
                // Remove existing controls
                var existingControls = parentForm.Controls.OfType<UserControl>().Where(c => c != this && c.GetType() != typeof(SidebarControl)).ToList();
                foreach (var control in existingControls)
                {
                    parentForm.Controls.Remove(control);
                }

                // Add CartControl
                var cartControl = new CartControl(_cartItemService, _productService, _orderService);
                cartControl.Visible = true;
                cartControl.Dock = DockStyle.Right;
                parentForm.Controls.Add(cartControl);
                cartControl.BringToFront();

                // Update SidebarControl button colors
                var sidebar = parentForm.Controls.OfType<SidebarControl>().FirstOrDefault();
                if (sidebar != null)
                {
                    sidebar.Controls["MyCartbtn"].BackColor = Color.LightBlue;
                    sidebar.Controls["ClientDashboardbtn"].BackColor = Color.Transparent;
                    sidebar.Controls["Profilebtn"].BackColor = Color.Transparent;
                    sidebar.Controls["logoutbutton"].BackColor = Color.Transparent;
                    sidebar.Controls["MyOrderbtn"].BackColor = Color.Transparent;
                }

                // Remove this OrderControl
                parentForm.Controls.Remove(this);
            }
        }
    }
}