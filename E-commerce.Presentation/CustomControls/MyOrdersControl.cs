using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Guna.UI2.WinForms;
using E_commerce.Application.DTOs.Order;
using E_commerce.Application.Services.OrderService;
using E_commerce.Application.Helper;
using Microsoft.Extensions.Logging;
using E_commerce.Application.Services.ProductServices;

namespace E_commerce.Presentation.CustomControls
{
    public partial class MyOrdersControl : UserControl
    {
        private readonly IOrderService _orderService;
        private readonly ILogger<MyOrdersControl> _logger;
        private readonly IProductServices _productServices;

        public MyOrdersControl()
        {
            InitializeComponent();
            SetupControl();
        }

        public MyOrdersControl(IOrderService orderService, IProductServices productService, ILogger<MyOrdersControl> logger = null) : this()
        {
            _orderService = orderService ?? throw new ArgumentNullException(nameof(orderService));
            _productServices = productService ?? throw new ArgumentNullException(nameof(productService));
            _logger = logger;
            dataGridViewOrders.CellContentClick += dataGridViewOrders_CellContentClick;
        }

        private void SetupControl()
        {
            // Initialize and layout controls
            this.Size = new Size(800, 650); // Match CartControl size
            this.BackColor = Color.White;

            // Position controls with relative positioning
            int margin = 20;
            dataGridViewOrders.Location = new Point(margin, 60);
            dataGridViewOrders.Size = new Size(this.Width - (2 * margin), this.Height - 100);

            titleLabel.Location = new Point(margin, 20);
        }

        protected override async void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
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

                var userId = SessionManager.CurrentUser?.UserID ?? 3;
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

            dataGridView.Columns.Clear();

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

            if (order.OrderDetails != null && order.OrderDetails.Any())
            {
                try
                {
                    var enrichedItems = new List<OrderDetailDto>();

                    foreach (var item in order.OrderDetails)
                    {
                        var productResponse = await _productServices.GetProducByIdAsync(item.ProductID);
                        if (productResponse.Succeeded)
                        {
                            enrichedItems.Add(new OrderDetailDto
                            {
                                ProductName = productResponse.Data?.Name ?? "Unknown Product",
                                Price = productResponse.Data?.Price ?? 0m,
                                Quantity = item.Quantity
                            });
                        }
                        else
                        {
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
    }
}