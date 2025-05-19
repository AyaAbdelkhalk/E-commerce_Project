using E_commerce.Application.DTOs.User;
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

namespace E_commerce.Presentation.CustomControls
{
    public partial class userControl : UserControl
    {
        private readonly IUserServices _userServices;
        private DataGridViewRow selectedRow;

        public userControl(IUserServices userServices)
        {
            InitializeComponent();
            _userServices = userServices;

            // Ensure DataGridView allows row selection
            dataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView.MultiSelect = false; // Allow only one row to be selected
        }

        protected override async void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            SaveButton.Visible = false;
            panel1.Visible = false;
            await loadUsers();
        }

        private async void userControl_Load(object sender, EventArgs e)
        {
            panel1.Visible = true;
            await loadUsers();
        }

        public async Task loadUsers()
        {
            try
            {
                ViewUsersBtn.Visible = true;
                ViewAdminsBtn.Visible = true;
                dataGridView.Visible = true;
                var users = await _userServices.GetAllUsers();

                if (users != null && users.Data != null && users.Data.Count > 0)
                {
                    // مسح الأعمدة القديمة لتجنب التكرار
                    dataGridView.Columns.Clear();

                    // تعيين مصدر البيانات
                    dataGridView.DataSource = users.Data;

                    // إعداد أسلوب تحجيم الأعمدة والصفوف
                    dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    dataGridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
                    dataGridView.DefaultCellStyle.WrapMode = DataGridViewTriState.True;

                    // تهيئة رأس الجدول
                    dataGridView.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dataGridView.ColumnHeadersDefaultCellStyle.Font = new Font("Tahoma", 10, FontStyle.Bold);
                    dataGridView.EnableHeadersVisualStyles = false;
                    dataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
                    dataGridView.ColumnHeadersHeight = 40;

                    // تغيير عناوين الأعمدة
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

                    //get role and isactive from database and add it to the combobox




                    // إضافة عمود ComboBox جديد باسم "UserType"
                    DataGridViewComboBoxColumn userTypeColumn = new DataGridViewComboBoxColumn
                    {
                        Name = "UserType",
                        HeaderText = "Set Role",
                        DataPropertyName = "Role", // ربط العمود بالخاصية Role في الكائن
                        Items = { "Client", "Admin" } // قائمة الخيارات
                    };

                    dataGridView.Columns.Add(userTypeColumn);

                    DataGridViewComboBoxColumn isActiveColumn = new DataGridViewComboBoxColumn
                    {
                        Name = "isActive",
                        HeaderText = "Activation",
                        DataPropertyName = "isActive", // ربط العمود بالخاصية  في الكائن
                        Items = { "Active", "inActive" } // قائمة الخيارات
                    };
                    
                    dataGridView.Columns.Add(isActiveColumn);
                    dataGridView.CurrentCellDirtyStateChanged += DataGridView1_CurrentCellDirtyStateChanged;
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

        private void DataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView.Columns[e.ColumnIndex].Name == "isActive")
            {
                var newValue = dataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value?.ToString();
                Console.WriteLine($"Row {e.RowIndex}, Column isActive: Value changed to {newValue}");
                // Add your logic here, e.g., update the underlying data source or perform an action
            }
        }

        private void DataGridView1_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dataGridView.CurrentCell is DataGridViewComboBoxCell)
            {
                // Commit the edit to update the cell's value immediately
                dataGridView.CommitEdit(DataGridViewDataErrorContexts.Commit);

                // Get the selected value
                var selectedValue = dataGridView.CurrentCell.Value?.ToString();
                int rowIndex = dataGridView.CurrentCell.RowIndex;
                int columnIndex = dataGridView.CurrentCell.ColumnIndex;

                var userdto = new userdd
                {
                    Id = Convert.ToInt32(dataGridView.Rows[rowIndex].Cells["Id"].Value),
                    IsActive = selectedValue,
                    Role = dataGridView.Rows[rowIndex].Cells["UserType"].Value?.ToString()
                };
                _userServices.UpdateUserR(userdto);
                 loadUsers();
                // Handle the selection change
                MessageBox.Show($"Row {rowIndex}, Column {dataGridView.Columns[columnIndex].Name}: Selection changed to {selectedValue}");
                // Add your logic here, e.g., update the underlying data source or perform an action
            }
        }
        private async void ViewUsersBtn_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
            dataGridView.Visible = true;
            try
            {
                var users = await _userServices.GetAllUsers();
                if (users != null && users.Data != null && users.Data.Count > 0)
                {
                    var clients = users.Data.Where(u => u.Role == "Client").ToList();
                    dataGridView.DataSource = clients;
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
                    MessageBox.Show("No Clients found.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }

            await loadUsers();
        }

        private async void SearchCategory_TextChanged(object sender, EventArgs e)
        {
            var text = SearchCategory.Text.ToLower();

            if (string.IsNullOrEmpty(text))
            {
                return;
            }

            var result = await _userServices.SearchUser(text);
            if (result != null && result.Succeeded)
            {
                dataGridView.DataSource = result.Data;
            }
            else
            {
                dataGridView.DataSource = null; // Clear old results
                MessageBox.Show("No users found.");
            }
        }

        private async void ViewAdminsBtn_Click(object sender, EventArgs e)
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

        private async void button1_Click(object sender, EventArgs e)
        {




        }

        private async void SaveButton_Click(object sender, EventArgs e)
        {
            try
            {
                dataGridView.EndEdit(); // Save edits first

                // Check if there’s a valid selected row
                if (dataGridView.CurrentCell == null ||
                    dataGridView.CurrentCell.RowIndex < 0 ||
                    dataGridView.Rows[dataGridView.CurrentCell.RowIndex].IsNewRow)
                {
                    MessageBox.Show("Please select a valid row to update.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (selectedRow == null || dataGridView.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Please select a row first.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var row = selectedRow;

                // Read values from the row
                int userId = Convert.ToInt32(row.Cells["Id"].Value);
                string userName = row.Cells["UserName"].Value?.ToString();
                string email = row.Cells["Email"].Value?.ToString();
                string firstName = row.Cells["FirstName"].Value?.ToString();
                string lastName = row.Cells["LastName"].Value?.ToString();
                var UserDTO = new Application.DTOs.User.AddUserDTO
                {
                    UserName = userName,
                    Email = email,
                    FirstName = firstName,
                    LastName = lastName
                };

                var result = await _userServices.UpdateUser(UserDTO);

                if (result.Succeeded)
                {
                    MessageBox.Show("User updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    var errorMessage = result.Errors != null && result.Errors.Any()
                        ? string.Join("\n", result.Errors)
                        : "Failed to update user";
                    MessageBox.Show(errorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An unexpected error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dataGridView.Rows.Count && !dataGridView.Rows[e.RowIndex].IsNewRow)
            {
                dataGridView.Rows[e.RowIndex].Selected = true;
                selectedRow = dataGridView.Rows[e.RowIndex];
            }

            if (dataGridView.Columns[e.ColumnIndex].Name == "isActive")
            {
                var isActiveCell = dataGridView.Rows[e.RowIndex].Cells["isActive"];
                if (isActiveCell is DataGridViewComboBoxCell comboBoxCell)
                {
                    comboBoxCell.Items.Clear();
                    comboBoxCell.Items.Add("Active");
                    comboBoxCell.Items.Add("Inactive");
                    // Preserve existing value if available, else set default
                    comboBoxCell.Value = isActiveCell.Value?.ToString() ?? "Active";
                }

                var roleCell = dataGridView.Rows[e.RowIndex].Cells["UserType"];
                if (roleCell is DataGridViewComboBoxCell roleComboBoxCell)
                {
                    roleComboBoxCell.Items.Clear();
                    roleComboBoxCell.Items.Add("Admin");
                    roleComboBoxCell.Items.Add("Client");
                    // Preserve existing value if available, else set default
                    roleComboBoxCell.Value = roleCell.Value?.ToString() ?? "Client";
                }
            }
        }

        private void dataGridView_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count > 0 && !dataGridView.SelectedRows[0].IsNewRow)
            {
                selectedRow = dataGridView.SelectedRows[0];
            }
            else
            {
                selectedRow = null;
            }
        }

        private void guna2CircleButton1_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
            dataGridView.Visible = true; // Ensure DataGridView is visible when closing panel
        }

        private async void deleteUserBtn_Click(object sender, EventArgs e)
        {
            try
            {
                var selectedRow = dataGridView.SelectedRows[0];
                if (dataGridView.SelectedRows.Count == 0 || selectedRow == null)
                {
                    MessageBox.Show("Please select a user to delete.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var userId = Convert.ToInt32(selectedRow.Cells["Id"].Value); // Corrected from "userId" to "Id"

                // Confirm deletion with the user
                var confirmResult = MessageBox.Show(
                    $"Are you sure you want to delete the user with ID {userId}?",
                    "Confirm Delete",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (confirmResult != DialogResult.Yes)
                {
                    return;
                }

                // Call the service to delete the user
                var result = await _userServices.DeleteUser(userId);
                if (result.Succeeded)
                {
                    MessageBox.Show("User deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    selectedRow = null;
                    await loadUsers(); // Refresh the DataGridView after deletion
                }
                else
                {
                    var errorMessage = result.Errors != null && result.Errors.Any()
                        ? string.Join("\n", result.Errors)
                        : "Failed to delete user";
                    MessageBox.Show(errorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An unexpected error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void button1_Click_1(object sender, EventArgs e)
        {
            try
            {
                dataGridView.EndEdit(); // Ensure all edits are committed

                // Check if a valid row is selected
                if (dataGridView.SelectedRows.Count == 0 || dataGridView.SelectedRows[0].IsNewRow)
                {
                    MessageBox.Show("Please select a valid row to update.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var selectedRow = dataGridView.SelectedRows[0];

                // Read values from the selected row
                int userId = Convert.ToInt32(selectedRow.Cells["Id"].Value);
                string role = selectedRow.Cells["UserType"].Value?.ToString();
                string isActive = selectedRow.Cells["isActive"].Value?.ToString();

                // Validate the input
                if (string.IsNullOrEmpty(role) || string.IsNullOrEmpty(isActive))
                {
                    MessageBox.Show("Role or Active status is not selected.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Create DTO for updating role and isActive
                var userDto = new userdd
                {
                    Role = role,
                    IsActive = isActive
                };

                // Call the service to update the user
                var result = await _userServices.UpdateUserR(userDto);

                if (result.Succeeded)
                {
                    MessageBox.Show("User role and active status updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    await loadUsers(); // Refresh the DataGridView
                }
                else
                {
                    var errorMessage = result.Errors != null && result.Errors.Any()
                        ? string.Join("\n", result.Errors)
                        : "Failed to update user role and active status.";
                    MessageBox.Show(errorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An unexpected error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}