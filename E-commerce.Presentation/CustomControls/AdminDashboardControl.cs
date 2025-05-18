using E_commerce.Application.Services.ProductServices;
using E_commerce.Application.Services;
using E_commerce.Application.Services.UserServices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using E_commerce.Application.Services.OrderService;
using E_commerce.Application.Services.AdminDashboardServices;
using System.Windows.Forms.DataVisualization.Charting;
using Guna.UI2.WinForms;
using E_commerce.Application.DTOs.Order;
using System.IO;

namespace E_commerce.Presentation.CustomControls
{
    public partial class AdminDashboardControl : UserControl
    {
        private readonly IUserServices _userServices;
        private readonly IProductServices _productServices;
        private readonly IOrderService _orderServices;
        private readonly ICategoryServices _categoryServices;
        private readonly ICartItemService _cartItemService;

        // UI Components
        private Guna2Panel metricsPanel;
        private Guna2Panel chartsPanel;
        private Guna2Panel gridPanel;
        private Guna2DataGridView ordersGrid;
        private Guna2Button refreshButton;
        private Chart pieChart;
        private Chart barChart;
        private Chart salesLineChart;

        public AdminDashboardControl(IUserServices userServices, IProductServices productServices, IOrderService orderServices, ICategoryServices categoryServices, ICartItemService cartItemService)
        {
            _userServices = userServices ?? throw new ArgumentNullException(nameof(userServices));
            _productServices = productServices ?? throw new ArgumentNullException(nameof(productServices));
            _orderServices = orderServices ?? throw new ArgumentNullException(nameof(orderServices));
            _categoryServices = categoryServices ?? throw new ArgumentNullException(nameof(categoryServices));
            _cartItemService = cartItemService ?? throw new ArgumentNullException(nameof(cartItemService));

            InitializeComponent();
            InitializeDashboardComponents();
        }

        private void InitializeDashboardComponents()
        {
            // Configure roundedPanel1
            roundedPanel1.Controls.Clear();
            roundedPanel1.BackColor = Color.Transparent;

            // Metrics Panel (Top)
            metricsPanel = new Guna2Panel
            {
                Location = new Point(20, 20),
                Size = new Size(1346, 150),
                BorderRadius = 15,
                FillColor = Color.FromArgb(100, 130, 180),
                ShadowDecoration = { Enabled = true }
            };
            roundedPanel1.Controls.Add(metricsPanel);
            SetupMetricsCards();

            // Charts Panel (Middle)
            chartsPanel = new Guna2Panel
            {
                Location = new Point(20, 190),
                Size = new Size(1346, 400),
                BorderRadius = 15,
                FillColor = Color.FromArgb(100, 130, 180),
                ShadowDecoration = { Enabled = true }
            };
            roundedPanel1.Controls.Add(chartsPanel);
            SetupCharts();

            // Grid Panel (Bottom)
            gridPanel = new Guna2Panel
            {
                Location = new Point(20, 610),
                Size = new Size(1346, 290),
                BorderRadius = 15,
                FillColor = Color.FromArgb(100, 130, 180),
                ShadowDecoration = { Enabled = true }
            };
            roundedPanel1.Controls.Add(gridPanel);
            SetupDataGrid();

            // Refresh Button
            refreshButton = new Guna2Button
            {
                Location = new Point(20, 10),
                Size = new Size(120, 35),
                Text = "Refresh",
                FillColor = Color.FromArgb(120, 150, 200),
                ForeColor = Color.White,
                BorderRadius = 10,
                ShadowDecoration = { Enabled = true }
            };
            refreshButton.Click += async (s, e) => await LoadDashboardDataAsync();
            gridPanel.Controls.Add(refreshButton);
        }

        private void SetupMetricsCards()
        {
            string[] titles = { "Total Users", "Total Orders", "Total Products", "Total Categories" };
            int cardWidth = 310;
            int cardHeight = 130;
            int spacing = 20;

            for (int i = 0; i < 4; i++)
            {
                var card = new Guna2Panel
                {
                    Location = new Point(spacing + i * (cardWidth + spacing), 10),
                    Size = new Size(cardWidth, cardHeight),
                    BorderRadius = 10,
                    FillColor = Color.FromArgb(120, 150, 200),
                    ShadowDecoration = { Enabled = true }
                };

                var icon = new Guna2PictureBox
                {
                    Location = new Point(10, 10),
                    Size = new Size(50, 50),
                    Image = GetIconForMetric(i),
                    SizeMode = PictureBoxSizeMode.StretchImage
                };

                var titleLabel = new Label
                {
                    Location = new Point(70, 20),
                    Size = new Size(200, 30),
                    Text = titles[i],
                    ForeColor = Color.White,
                    Font = new Font("Segoe UI", 12, FontStyle.Regular)
                };

                var valueLabel = new Label
                {
                    Location = new Point(70, 50),
                    Size = new Size(200, 40),
                    Text = "0",
                    ForeColor = Color.White,
                    Font = new Font("Segoe UI", 20, FontStyle.Bold),
                    Name = $"valueLabel{i}"
                };

                card.Controls.AddRange(new Control[] { icon, titleLabel, valueLabel });
                metricsPanel.Controls.Add(card);
            }
        }

        private void SetupCharts()
        {
            // Pie Chart (Products per Category)
            pieChart = new Chart
            {
                Location = new Point(10, 10),
                Size = new Size(550, 350),
                BackColor = Color.Transparent,
                Visible = false
            };
            var pieArea = new ChartArea { Name = "PieArea" };
            pieChart.ChartAreas.Add(pieArea);
            var pieSeries = new Series
            {
                Name = "Products",
                ChartType = SeriesChartType.Pie,
                IsValueShownAsLabel = true,
                LabelForeColor = Color.White,
                Font = new Font("Segoe UI", 12, FontStyle.Bold)
            };
            pieChart.Series.Add(pieSeries);
            pieChart.Legends.Add(new Legend("Legend"));
            pieChart.Titles.Add(new Title("Products per Category", Docking.Top, new Font("Segoe UI", 14, FontStyle.Bold), Color.White));
            chartsPanel.Controls.Add(pieChart);
            pieChart.Visible = true;

            // Kagi Chart (Monthly Sales)
            salesLineChart = new Chart
            {
                Location = new Point(570, 10),
                Size = new Size(750, 380),
                BackColor = Color.Transparent,
                BackSecondaryColor = Color.White,/////////
                BorderlineColor = Color.FromArgb(120, 150, 200),
                BorderlineWidth = 2
            };

            var salesArea = new ChartArea { Name = "SalesArea" };
            salesArea.BackColor = Color.White;////////////////////
            salesArea.AxisX.Title = "Month";
            salesArea.AxisX.Interval = 1;
            salesArea.AxisX.LabelStyle.Format = "MMM yyyy"; // Display as "Jan 2025"
            salesArea.AxisX.LabelStyle.Angle = 45; // Rotate labels for better fit
            salesArea.AxisX.TitleFont = new Font("Segoe UI", 12, FontStyle.Bold);
            salesArea.AxisY.Title = "Sales Amount (EGP)";
            salesArea.AxisY.TitleFont = new Font("Segoe UI", 12, FontStyle.Bold);
            salesArea.AxisY.LabelStyle.Format = "N0";

            // Disable grid lines
            salesArea.AxisX.MajorGrid.Enabled = false;
            salesArea.AxisX.MinorGrid.Enabled = false;
            salesArea.AxisY.MajorGrid.Enabled = false;
            salesArea.AxisY.MinorGrid.Enabled = false;

            salesLineChart.ChartAreas.Add(salesArea);

            var salesSeries = new Series
            {
                Name = "Sales",
                ChartType = SeriesChartType.Kagi,
                IsValueShownAsLabel = true,
                LabelForeColor = Color.White,
                LabelBackColor = Color.FromArgb(120, 150, 200),
                LabelBorderColor = Color.White,
                LabelBorderWidth = 1,
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                ToolTip = "Month: #VALX\nSales: $#VALY{C0}" // Tooltip with month and sales
            };
            salesSeries["PriceUpColor"] = "LimeGreen";
            salesSeries["PriceDownColor"] = "Crimson";
            salesSeries["KagiReversalAmount"] = "0";
            salesLineChart.Series.Add(salesSeries);


            chartsPanel.Controls.Add(salesLineChart);
        }

        private void SetupDataGrid()
        {
            ordersGrid = new Guna2DataGridView
            {
                Location = new Point(10, 50),
                Size = new Size(1326, 230),
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                BorderStyle = BorderStyle.None,
                CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal,
                ColumnHeadersHeight = 30,
                RowHeadersVisible = false,
                AllowUserToAddRows = false
            };
            ordersGrid.Columns.AddRange(
            //new DataGridViewTextBoxColumn { HeaderText = "Order ID", DataPropertyName = "Id" },
            //new DataGridViewTextBoxColumn { HeaderText = "User", DataPropertyName = "UserName" },
            //new DataGridViewTextBoxColumn { HeaderText = "Total Amount", DataPropertyName = "TotalAmount" },
            //new DataGridViewTextBoxColumn { HeaderText = "Date", DataPropertyName = "OrderDate" }
            );
            ordersGrid.RowsDefaultCellStyle.BackColor = Color.FromArgb(100, 130, 180);
            ordersGrid.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(80, 110, 160);
            gridPanel.Controls.Add(ordersGrid);

            // Search Box
            var searchBox = new Guna2TextBox
            {
                Location = new Point(150, 10),
                Size = new Size(200, 35),
                PlaceholderText = "Search Orders",
                BorderRadius = 10
            };
            searchBox.TextChanged += (s, e) =>
            {
                if (ordersGrid.DataSource is List<OrderDto> orders)
                    ordersGrid.DataSource = orders.Where(o => o.User.Contains(searchBox.Text, StringComparison.OrdinalIgnoreCase)).ToList();
            };
            gridPanel.Controls.Add(searchBox);
        }

        private async void AdminDashboardControl_Load(object sender, EventArgs e)
        {
            await LoadDashboardDataAsync();
        }

        private async Task LoadDashboardDataAsync()
        {
            try
            {
                refreshButton.Enabled = false;

                // Load Metrics
                var totalUsersTask = _userServices.GetTotalUsersAsync();
                var totalOrdersTask = _orderServices.GetAllOrdersAsync();
                var totalProductsTask = _productServices.GetTotalProductsAsync();
                var totalCategoriesTask = _categoryServices.GetTotalCategoriesAsync();

                await Task.WhenAll(totalUsersTask, totalOrdersTask, totalProductsTask, totalCategoriesTask);

                UpdateMetricLabel(0, totalUsersTask.Result.ToString());
                UpdateMetricLabel(1, totalOrdersTask.Result.ToString());
                UpdateMetricLabel(2, totalProductsTask.Result.ToString());
                UpdateMetricLabel(3, totalCategoriesTask.Result.ToString());

                var monthlySales = await _orderServices.GetMonthlyOrderAmountAsync();
                UpdateBarChart(monthlySales);

                var productsByCategory = await _productServices.GetProductsByCategory();
                UpdatePieChart(productsByCategory);

                var recentOrders = await _orderServices.GetRecentOrders(20);
                ordersGrid.DataSource = recentOrders;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading dashboard data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                refreshButton.Enabled = true;
            }
        }

        private void UpdateMetricLabel(int index, string value)
        {
            var panel = metricsPanel.Controls.OfType<Guna2Panel>().ElementAtOrDefault(index);
            if (panel == null)
            {
                MessageBox.Show($"Metric panel at index {index} is null.", "UI Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var label = panel.Controls.OfType<Label>().FirstOrDefault(l => l.Name == $"valueLabel{index}");
            if (label != null)
                label.Text = value ?? "0";
            else
                MessageBox.Show($"Value label at index {index} is null.", "UI Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void UpdatePieChart(Dictionary<string, int> productsByCategory)
        {
            if (pieChart?.Series["Products"] == null)
            {
                MessageBox.Show("Pie chart or series is null.", "Chart Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            pieChart.Series["Products"].Points.Clear();
            foreach (var kvp in productsByCategory ?? new Dictionary<string, int>())
                pieChart.Series["Products"].Points.AddXY(kvp.Key, kvp.Value);
        }

        private void UpdateBarChart(Dictionary<string, decimal> monthlySales)
        {
            if (salesLineChart?.Series["Sales"] == null)
            {
                MessageBox.Show("Sales chart or series is null.", "Chart Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                salesLineChart.Series["Sales"].Points.Clear();

                // Define the 12 months from June 2024 to May 2025
                var months = Enumerable.Range(0, 12)
                    .Select(i => DateTime.Now.AddMonths(-11 + i))
                    .ToList();

                // Calculate dynamic reversal amount (5% of max sales or 500 if no data)
                decimal maxSales = monthlySales?.Any() == true ? monthlySales.Values.Max() : 0;
                decimal reversalAmount = maxSales > 0 ? maxSales * 0.05m : 500;
                salesLineChart.Series["Sales"]["KagiReversalAmount"] = reversalAmount.ToString();

                // Add points for Kagi Chart
                foreach (var month in months)
                {
                    string monthKey = month.ToString("yyyy-MM");
                    decimal sales = monthlySales?.ContainsKey(monthKey) == true ? monthlySales[monthKey] : 0;
                    salesLineChart.Series["Sales"].Points.AddXY(month, sales);
                }

                Console.WriteLine($"Monthly Sales Data (May 18, 2025): {string.Join(", ", monthlySales?.Select(x => $"{x.Key}: {x.Value:C0}") ?? new string[] { "No data" })}");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating Kagi chart: {ex.Message}", "Chart Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private Image GetIconForMetric(int index)
        {
            string iconName = index switch
            {
                0 => "category.png",
                1 => "feature.png",
                2 => "checkout.png",
                3 => "category.png",
                _ => throw new ArgumentOutOfRangeException(nameof(index), "Invalid metric index")
            };
            return LoadIcon(iconName);
        }

        private Image LoadIcon(string iconName)
        {
            try
            {
                string iconPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Images", iconName);
                if (File.Exists(iconPath))
                {
                    return Image.FromFile(iconPath);
                }
                else
                {
                    MessageBox.Show($"Icon file '{iconName}' not found in Resources folder.", "Icon Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return new Bitmap(50, 50);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading icon '{iconName}': {ex.Message}", "Icon Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new Bitmap(50, 50); // Return a placeholder blank image
            }
        }

        private void roundedPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}