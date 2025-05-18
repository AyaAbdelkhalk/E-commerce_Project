using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Guna.UI2.WinForms;
using Guna.UI2.WinForms.Suite;
using E_commerce.Application.DTOs.Order;
using E_commerce.Application.Services.OrderService;
using E_commerce.Application.Helper;
using Microsoft.Extensions.Logging;
using E_commerce.Application.Services.ProductServices;

namespace E_commerce.Presentation
{
    public partial class MyOrdersForm : Form
    {
        private readonly IOrderService _orderService;
        private readonly ILogger<MyOrdersForm> _logger;
        private readonly IProductServices _productServices;

        public MyOrdersForm()
        {
            InitializeComponent();
            // Remove window controls since we're embedding
            guna2CircleButtonClose.Visible = false;
            guna2CircleButtonMinimize.Visible = false;
            guna2CircleButtonMaximize.Visible = false;

            // Adjust layout for embedding
            this.Padding = new Padding(20);
            dataGridViewOrders.Location = new Point(20, 60);
            dataGridViewOrders.Size = new Size(this.ClientSize.Width - 40, this.ClientSize.Height - 180);

            titleLabel.Location = new Point(20, 20);
        }

        public MyOrdersForm(IOrderService orderService, IProductServices productService, ILogger<MyOrdersForm> logger = null) : this()
        {
            _orderService = orderService ?? throw new ArgumentNullException(nameof(orderService));
            _productServices = productService ?? throw new ArgumentNullException(nameof(productService));
            _logger = logger;
        }

        private async void MyOrdersForm_Load(object sender, EventArgs e)
        {
            await LoadOrders();
        }

        private async Task LoadOrders()
        {
            try
            {
                if (_orderService == null)
                {
                    _logger?.LogError("Order service is not initialized.");
                    MessageBox.Show("Order service is not initialized.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var userId = SessionManager.CurrentUser?.UserID ?? 3; // Replace with SessionManager.CurrentUser?.UserID
                _logger?.LogInformation($"Loading orders for user ID: {userId}");

                var orders = await _orderService.GetOrderHistoryByUserIdAsync(userId);


                dataGridViewOrders.Columns.Clear();
                dataGridViewOrders.AutoGenerateColumns = false;



                dataGridViewOrders.Columns.Add(new DataGridViewTextBoxColumn
                {
                    DataPropertyName = "OrderID",
                    HeaderText = "Order ID",
                    Name = "OrderID",
                    ReadOnly = true,
                    Width = 100
                });

                dataGridViewOrders.Columns.Add(new DataGridViewTextBoxColumn
                {
                    DataPropertyName = "OrderDate",
                    HeaderText = "Order Date",
                    Name = "OrderDate",
                    ReadOnly = true,
                    Width = 150
                });

                dataGridViewOrders.Columns.Add(new DataGridViewTextBoxColumn
                {
                    DataPropertyName = "TotalAmount",
                    HeaderText = "Total",
                    Name = "TotalAmount",
                    ReadOnly = true,
                    DefaultCellStyle = new DataGridViewCellStyle
                    {
                        Format = "C2",
                        Alignment = DataGridViewContentAlignment.MiddleRight
                    }
                });

                dataGridViewOrders.Columns.Add(new DataGridViewTextBoxColumn
                {
                    DataPropertyName = "Status",
                    HeaderText = "Status",
                    Name = "Status",
                    ReadOnly = true,
                    Width = 100
                });

                var detailsColumn = new DataGridViewButtonColumn
                {
                    Name = "Details",
                    HeaderText = "Details",
                    Text = "View Details",
                    UseColumnTextForButtonValue = true,
                    Width = 100
                };
                dataGridViewOrders.Columns.Add(detailsColumn);

                dataGridViewOrders.DataSource = orders.ToList();
                _logger?.LogInformation($"Loaded {orders.Count} orders for user ID: {userId}");
            }
            catch (Exception ex)
            {
                _logger?.LogError(ex, "Failed to load orders.");
                MessageBox.Show($"Failed to load orders: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridViewOrders_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex < 0 || e.RowIndex < 0) return;

            if (dataGridViewOrders.Columns[e.ColumnIndex].Name == "Details")
            {
                var order = dataGridViewOrders.Rows[e.RowIndex].DataBoundItem as OrderDisDto;
                if (order != null)
                {
                    ShowOrderDetails(order);
                }
            }
        }

        private async void ShowOrderDetails(OrderDisDto order)
        {
            var detailsForm = new Form
            {
                Text = $"Order {order.OrderID} Details",
                Size = new Size(600, 400),
                StartPosition = FormStartPosition.CenterParent,
                FormBorderStyle = FormBorderStyle.FixedSingle,
                MaximizeBox = false
            };

            var dataGridView = new Guna2DataGridView
            {
                Location = new Point(10, 10),
                Size = new Size(560, 300),
                AutoGenerateColumns = false,
                AllowUserToAddRows = false,
                AllowUserToDeleteRows = false,
                RowHeadersVisible = false
            };

            // Clear any existing columns first
            dataGridView.Columns.Clear();

            // Add columns
            dataGridView.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "ProductName",
                HeaderText = "Product Name",
                Name = "Name",
                ReadOnly = true,
                Width = 200
            });

            dataGridView.Columns.Add(new DataGridViewTextBoxColumn
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

            dataGridView.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Quantity",
                HeaderText = "Qty",
                Name = "Quantity",
                ReadOnly = true,
                Width = 60,
                DefaultCellStyle = new DataGridViewCellStyle
                {
                    Alignment = DataGridViewContentAlignment.MiddleCenter
                }
            });

            // Verify and set the data source
            if (order.OrderDetails != null && order.OrderDetails.Any())
            {
                try
                {
                    // Enrich order details with product information
                    var enrichedItems = new List<OrderDetailDto>();

                    foreach (var item in order.OrderDetails)
                    {
                        // Fetch product details for each order item
                        var productResponse = await _productServices.GetProducByIdAsync(item.ProductID);
                        if (productResponse.Succeeded)
                        {
                            // Create a new object with the enriched data
                            enrichedItems.Add(new OrderDetailDto
                            {
                               
                                ProductName = productResponse.Data?.Name ?? "Unknown Product",
                                Price = productResponse.Data?.Price ?? 0m,
                                Quantity = item.Quantity
                                // Add other properties if needed
                            });
                        }
                        else
                        {
                            // Fallback if product fetch fails
                            enrichedItems.Add(new OrderDetailDto
                            {
                                
                                ProductName = "Product not found",
                                Price = 0m,
                                Quantity = item.Quantity
                            });
                        }
                    }

                    dataGridView.DataSource = enrichedItems;
                }
                catch (Exception ex)
                {
                    _logger?.LogError(ex, "Error enriching order details");
                    MessageBox.Show("Error loading product details", "Error",
                                  MessageBoxButtons.OK, MessageBoxIcon.Error);
                    dataGridView.DataSource = order.OrderDetails.ToList();
                }
            }
            else
            {
                dataGridView.DataSource = new List<OrderDetailDto>();
            }

            var closeButton = new Guna2GradientButton
            {
                Text = "Close",
                Size = new Size(100, 40),
                Location = new Point(460, 320),
                Font = new Font("Segoe UI", 12F, FontStyle.Bold),
                ForeColor = Color.White,
                FillColor2 = Color.Black
            };
            closeButton.Click += (s, e) => detailsForm.Close();

            detailsForm.Controls.Add(dataGridView);
            detailsForm.Controls.Add(closeButton);
            detailsForm.ShowDialog(this);
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

        private void dataGridViewOrders_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex < 0 || e.RowIndex < 0) return;

            if (dataGridViewOrders.Columns[e.ColumnIndex].Name == "Details")
            {
                var order = dataGridViewOrders.Rows[e.RowIndex].DataBoundItem as OrderDisDto;
                if (order != null)
                {
                    ShowOrderDetails(order);
                }
            }
        }
    }
}