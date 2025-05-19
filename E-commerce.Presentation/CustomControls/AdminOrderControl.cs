using E_commerce.Application.Services.OrderService;
using E_commerce.Application.Services.ProductServices;
using E_commerce.Application.Services.UserServices;
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
using Microsoft.Extensions.Logging;
using E_commerce.Application.DTOs.Order;
using E_commerce.Application.Helper;
using Guna.UI2.WinForms;
using E_commerce.Application.Hepler;
using E_commerce.Core.Enum;

namespace E_commerce.Presentation.CustomControls
{
    public partial class AdminOrderControl : UserControl
    {
        private readonly IOrderService _orderService; 
        private readonly IProductServices _productServices;
        private readonly IUserServices _userServices;
        private readonly ICartItemService _cartItemService;
        private readonly ILogger _logger;
        public AdminOrderControl()
        {
            InitializeComponent();
            SetupControl();
        }

        public AdminOrderControl(IOrderService orderService, IProductServices productService, ILogger<AdminOrderControl> logger = null) : this()
        {
            _orderService = orderService ?? throw new ArgumentNullException(nameof(orderService));
            _productServices = productService ?? throw new ArgumentNullException(nameof(productService));
            _logger = logger;
            dataGridViewOrders.CellContentClick += dataGridViewOrders_CellContentClick;
        }

        public AdminOrderControl(IOrderService orderService, IProductServices productService, IUserServices userServices, ICartItemService cartItemService) : this()
        {
            _orderService = orderService ?? throw new ArgumentNullException(nameof(orderService));
            _productServices = productService ?? throw new ArgumentNullException(nameof(productService));
            _userServices = userServices ?? throw new ArgumentNullException(nameof(userServices));
            _cartItemService = cartItemService ?? throw new ArgumentNullException(nameof(cartItemService));
            dataGridViewOrders.CellContentClick += dataGridViewOrders_CellContentClick;
        }

        private void SetupControl()
        {
            this.BackColor = SystemColors.Control;
            this.Padding = new Padding(20);

            // Position controls with relative positioning
            int margin = 20;
            titleLabel.Location = new Point(margin, 20);
            statusComboBox.Location = new Point(margin, 60);
            searchButton.Location = new Point(statusComboBox.Right + 10, 60);
            updateStatusButton.Location = new Point(searchButton.Right + 10, 60);
            dataGridViewOrders.Location = new Point(margin, 100);
        }

        // Method to adjust the control size dynamically based on the parent control
        public void AdjustSizeToParent(Control parentControl)
        {
            if (parentControl == null) return;

            // Calculate available space: parent's client size minus margins
            int availableWidth = parentControl.ClientSize.Width - 40; // Account for left/right margins
            int availableHeight = parentControl.ClientSize.Height - 40; // Account for top/bottom margins

            // Set the control size
            this.Size = new Size(availableWidth, availableHeight);

            // Adjust control layouts dynamically
            int margin = 20;
            titleLabel.Location = new Point(margin, 20);
            statusComboBox.Location = new Point(margin, 60);
            searchButton.Location = new Point(statusComboBox.Right + 10, 60);
            updateStatusButton.Location = new Point(searchButton.Right + 10, 60);
            dataGridViewOrders.Location = new Point(margin, 100);
            dataGridViewOrders.Size = new Size(this.ClientSize.Width - (2 * margin), this.ClientSize.Height - 140);
        }

        protected override async void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            // Populate status combo box with enum values
            statusComboBox.Items.Add("All");
            statusComboBox.Items.AddRange(Enum.GetNames(typeof(Status)));
            statusComboBox.SelectedIndex = 0;
            await LoadOrders();
        }

        private async Task LoadOrders(Status? status = null)
        {
            try
            {
                if (_orderService == null)
                {
                    _logger?.LogError("Order service is not initialized.");
                    MessageBox.Show("Order service is not initialized.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var userId = SessionManager.CurrentUser?.UserID ?? 2;
                _logger?.LogInformation($"Loading orders for user ID: {userId} with status: {status?.ToString() ?? "All"}");

                var orders = status.HasValue
                    ? await _orderService.GetOrdersByStatusAsync(status)
                    : await _orderService.GetAllOrdersAsync2();

                dataGridViewOrders.Columns.Clear();
                dataGridViewOrders.AutoGenerateColumns = false;

                dataGridViewOrders.Columns.Add(new DataGridViewTextBoxColumn
                {
                    DataPropertyName = "OrderID",
                    HeaderText = "Order ID",
                    Name = "OrderID",
                    ReadOnly = true,
                    DefaultCellStyle = new DataGridViewCellStyle
                    {
                        Alignment = DataGridViewContentAlignment.MiddleLeft
                    },
                    Width = 100
                });

                dataGridViewOrders.Columns.Add(new DataGridViewTextBoxColumn
                {
                    DataPropertyName = "OrderDate",
                    HeaderText = "Order Date",
                    Name = "OrderDate",
                    ReadOnly = true,
                    DefaultCellStyle = new DataGridViewCellStyle
                    {
                        Alignment = DataGridViewContentAlignment.MiddleLeft
                    },
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
                        Alignment = DataGridViewContentAlignment.MiddleLeft
                    }
                });

                dataGridViewOrders.Columns.Add(new DataGridViewTextBoxColumn
                {
                    DataPropertyName = "Status",
                    HeaderText = "Status",
                    Name = "Status",
                    ReadOnly = true,
                    DefaultCellStyle = new DataGridViewCellStyle
                    {
                        Alignment = DataGridViewContentAlignment.MiddleLeft
                    },
                    Width = 100
                });

                var detailsColumn = new DataGridViewButtonColumn
                {
                    Name = "Details",
                    HeaderText = "Details",
                    Text = "View Details",
                    UseColumnTextForButtonValue = true,
                    DefaultCellStyle = new DataGridViewCellStyle
                    {
                        Alignment = DataGridViewContentAlignment.MiddleLeft
                    },
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

        private async void searchButton_Click(object sender, EventArgs e)
        {
            if (statusComboBox.SelectedIndex == -1)
            {
                await LoadOrders();
            }
            else if (statusComboBox.SelectedItem.ToString() == "All")
            {
                await LoadOrders();
            }
            else
            {
                if (Enum.TryParse<Status>(statusComboBox.SelectedItem.ToString(), out var status))
                {
                    await LoadOrders(status);
                }
            }
        }

        private async void updateStatusButton_Click(object sender, EventArgs e)
        {
            if (dataGridViewOrders.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select an order to update.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var selectedOrder = dataGridViewOrders.SelectedRows[0].DataBoundItem as OrderDisDto;
            if (selectedOrder == null)
            {
                MessageBox.Show("Invalid order selected.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using (var statusForm = new Form
            {
                Text = "Update Order Status",
                Size = new Size(300, 150),
                StartPosition = FormStartPosition.CenterParent,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                MaximizeBox = false,
                MinimizeBox = false
            })
            {
                var comboBox = new Guna2ComboBox
                {
                    Location = new Point(20, 20),
                    Size = new Size(240, 30),
                    DropDownStyle = ComboBoxStyle.DropDownList,
                    Font = new Font("Segoe UI", 10F)
                };

                comboBox.Items.AddRange(Enum.GetNames<Status>());
                comboBox.SelectedItem = selectedOrder.Status;

                var confirmButton = new Guna2GradientButton
                {
                    Text = "Update",
                    Location = new Point(20, 60),
                    Size = new Size(100, 30),
                    Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                    ForeColor = Color.White,
                    FillColor = Color.FromArgb(100, 88, 255),
                    FillColor2 = Color.FromArgb(72, 60, 227)
                };

                var cancelButton = new Guna2GradientButton
                {
                    Text = "Cancel",
                    Location = new Point(130, 60),
                    Size = new Size(100, 30),
                    Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                    ForeColor = Color.White,
                    FillColor = Color.IndianRed,
                    FillColor2 = Color.DarkRed
                };

                confirmButton.Click += async (s, args) =>
                {
                    if (comboBox.SelectedIndex == -1)
                    {
                        MessageBox.Show("Please select a status.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    if (Enum.TryParse<Status>(comboBox.SelectedItem.ToString(), out var newStatus))
                    {
                        try
                        {
                            Response<string> response = null;
                            switch (newStatus)
                            {
                                case Status.Approved:
                                    response = await _orderService.ApproveOrderAsync(selectedOrder.OrderID);
                                    break;
                                case Status.Denied:
                                    response = await _orderService.DenyOrderAsync(selectedOrder.OrderID);
                                    break;
                                case Status.Shipped:
                                    await _orderService.ProcessOrderAsync(selectedOrder.OrderID);
                                    response = new Response<string> { Succeeded = true, Data = "Order status updated to Shipped." };
                                    break;
                                case Status.Pending:
                                    response = new Response<string> { Succeeded = true, Data = "Order status updated to Pending." };
                                    break;
                            }

                            if (response != null && response.Succeeded)
                            {
                                MessageBox.Show(response.Data, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                await LoadOrders();
                                statusForm.Close();
                            }
                            else
                            {
                                MessageBox.Show(string.Join("\n", response?.Errors ?? new List<string> { "Failed to update status." }), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        catch (Exception ex)
                        {
                            _logger?.LogError(ex, "Failed to update order status.");
                            MessageBox.Show($"Failed to update order status: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                };

                cancelButton.Click += (s, args) => statusForm.Close();

                statusForm.Controls.Add(comboBox);
                statusForm.Controls.Add(confirmButton);
                statusForm.Controls.Add(cancelButton);
                statusForm.ShowDialog(this);
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
            };

            dataGridView.Columns.Clear();

            dataGridView.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "ProductName",
                HeaderText = "Product Name",
                Name = "Name",
                ReadOnly = true,
                DefaultCellStyle = new DataGridViewCellStyle
                {
                    Alignment = DataGridViewContentAlignment.MiddleLeft
                },
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
                    Alignment = DataGridViewContentAlignment.MiddleLeft
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
                    Alignment = DataGridViewContentAlignment.MiddleLeft
                },
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
