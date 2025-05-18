using E_commerce.Application.Services;
using E_commerce.Application.Services.OrderService;
using E_commerce.Application.Services.ProductServices;
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

namespace E_commerce.Presentation
{
    public partial class users : Form
    {
        private readonly IUserServices _userServices;
        private readonly IProductServices _productServices;
        private readonly ICategoryServices _categoryServices;
        private readonly ICartItemService _cartItemService;
        private readonly IOrderService _orderService;
        public users(IUserServices userServices, IProductServices productServices, ICategoryServices categoryServices)
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            _userServices = userServices;
            _categoryServices = categoryServices;
            _productServices = productServices;

        }

        public users(IUserServices userServices, IProductServices productServices, ICategoryServices categoryServices, ICartItemService cartItemService, IOrderService orderService)
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            _userServices = userServices;
            _productServices = productServices;
            _categoryServices = categoryServices;
            _cartItemService = cartItemService;
            _orderService = orderService;
        }

        private void Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void guna2CircleButton4_Click(object sender, EventArgs e)
        {
            if (this.MaximizeBox == true)
            {
                this.WindowState = FormWindowState.Maximized;
                this.MaximizeBox = false;
            }
            else
            {
                this.WindowState = FormWindowState.Normal;
                this.MaximizeBox = true;
            }
        }

        private void guna2CircleButton3_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private async void users_Load(object sender, EventArgs e)
        {
            //ViewUsersBtn.Visible = false;
            //ViewAdminsBtn.Visible = false;
            //dataGridView.Visible = false;
        }

        private async void ViewUsersBtn_Click(object sender, EventArgs e)
        {
            try
            {
                var users = await _userServices.GetAllUsers();
                if (users != null && users.Data != null && users.Data.Count > 0)
                {
                    var admins = users.Data.Where(u => u.Role == "Admin").ToList();
                    dataGridView.DataSource = admins;
                    dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    dataGridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
                    dataGridView.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                    dataGridView.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dataGridView.ColumnHeadersDefaultCellStyle.Font = new Font("Tahoma", 10, FontStyle.Bold);
                    dataGridView.EnableHeadersVisualStyles = false;
                    dataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
                    dataGridView.ColumnHeadersHeight = 40;
                }
                else
                {
                    MessageBox.Show("No Admins found.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private async void ViewAdminsBtn_Click(object sender, EventArgs e)
        {

            
        }

        private async void AdminMangementbtn_Click(object sender, EventArgs e)
        {
            try
            {
                ViewUsersBtn.Visible = true;
                ViewAdminsBtn.Visible = true;
                dataGridView.Visible = true;
                var users = await _userServices.GetAllUsers();

                if (users != null && users.Data != null && users.Data.Count > 0)
                {
                    dataGridView.DataSource = users.Data;

                    dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    dataGridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
                    dataGridView.DefaultCellStyle.WrapMode = DataGridViewTriState.True;

                    dataGridView.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dataGridView.ColumnHeadersDefaultCellStyle.Font = new Font("Tahoma", 10, FontStyle.Bold);
                    dataGridView.EnableHeadersVisualStyles = false;
                    dataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
                    dataGridView.ColumnHeadersHeight = 40;


                    if (dataGridView.Columns.Contains("Id"))
                        dataGridView.Columns["Id"].HeaderText = "User ID";

                    if (dataGridView.Columns.Contains("UserName"))
                        dataGridView.Columns["UserName"].HeaderText = "User Name";

                    if (dataGridView.Columns.Contains("Email"))
                        dataGridView.Columns["Email"].HeaderText = "Email";

                    if (dataGridView.Columns.Contains("FirstName"))
                        dataGridView.Columns["FirstName"].HeaderText = "First Name";

                    if (dataGridView.Columns.Contains("LastName"))
                        dataGridView.Columns["LastName"].HeaderText = "Last Name";

                    if (dataGridView.Columns.Contains("IsActive"))
                        dataGridView.Columns["IsActive"].HeaderText = "Is Active";

                    if (dataGridView.Columns.Contains("Role"))
                        dataGridView.Columns["Role"].HeaderText = "Role";

                }
                else
                {
                    MessageBox.Show("No Users found.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void productbtn_Click(object sender, EventArgs e)
        {
            Form productForm = new products(_productServices, _categoryServices, _userServices, _cartItemService, _orderService);
            productForm.Show();
            this.Hide();
        }

        private void categorybtn_Click(object sender, EventArgs e)
        {
            Form CategoryForm = new Category( _productServices, _categoryServices , _userServices, _cartItemService,_orderService);
            CategoryForm.Show();
            this.Hide();
        }
    }
}