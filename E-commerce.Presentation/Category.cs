using E_commerce.Application.Services;
using E_commerce.Application.Services.ProductServices;
using Ecommerce;
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
    public partial class Category : Form
    {
        private readonly IProductServices _productServices;
        private readonly ICategoryServices _categoryServices;
        public Category(IProductServices productServices, ICategoryServices categoryServices)
        {
            InitializeComponent();
            _productServices = productServices;
            _categoryServices = categoryServices;
        }

        private async void dataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private async void ViewCategory_Click(object sender, EventArgs e)
        {
            try
            {
                dataGridView.Visible = true;
                AddCatPanel.Visible = false;
                var response = await _categoryServices.GetAllCategoriesWithProductsAsync();

                if (response != null && response.Data != null && response.Data.Count > 0)
                {
                    dataGridView.DataSource = response.Data;

                    dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    dataGridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
                    dataGridView.DefaultCellStyle.WrapMode = DataGridViewTriState.True;

                    // تحسين مظهر الرؤوس
                    dataGridView.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dataGridView.ColumnHeadersDefaultCellStyle.Font = new Font("Tahoma", 10, FontStyle.Bold);
                    dataGridView.EnableHeadersVisualStyles = false;
                    dataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
                    dataGridView.ColumnHeadersHeight = 40;


                    // إخفاء عمود CategoryID لأنه هو العمود الرئيسي وليس Id
                    if (dataGridView.Columns.Contains("CategoryID"))
                        dataGridView.Columns["CategoryID"].Visible = true;
                    dataGridView.Columns["CategoryID"].ReadOnly = true;

                    // تعديل أسماء الأعمدة حسب الكلاس
                    if (dataGridView.Columns.Contains("Name"))
                        dataGridView.Columns["Name"].HeaderText = "Category Name";

                    if (dataGridView.Columns.Contains("Description"))
                        dataGridView.Columns["Description"].HeaderText = "Description";


                }
                else
                {
                    MessageBox.Show("No categories found.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void AddCategory_Click(object sender, EventArgs e)
        {
            dataGridView.Visible = false;
            AddCatPanel.Visible = true;

        }

        private void Category_Load(object sender, EventArgs e)
        {
            dataGridView.Visible = false;
            AddCatPanel.Visible = false;
            this.WindowState = FormWindowState.Maximized;
        }

        private async void SaveButton_Click(object sender, EventArgs e)
        {
            try
            {
                // التحقق من صحة المدخلات
                if (string.IsNullOrWhiteSpace(NameText.Text))
                {
                    MessageBox.Show("Please enter category name", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    NameText.Focus();
                    return;
                }

                // إظهار حالة التحميل
                SaveButton.Enabled = false;
                Cursor = Cursors.WaitCursor;

                // إنشاء كائن الفئة الجديدة
                var categoryDto = new Application.DTOs.Category.CategoryDto
                {
                    Name = NameText.Text.Trim(),
                    Description = string.IsNullOrWhiteSpace(DescTextBox.Text) ? null : DescTextBox.Text.Trim()
                };

                // استدعاء الخدمة بشكل غير متزامن
                var result = await _categoryServices.AddCategoryAsync(categoryDto);

                if (result.Succeeded)
                {
                    MessageBox.Show("Category added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // إعادة تعيين النموذج
                    NameText.Clear();
                    DescTextBox.Clear();

                    // تحديث قائمة الفئات
                    await RefreshCategories();

                    // العودة لعرض القائمة
                    AddCatPanel.Visible = false;

                }
                else
                {
                    var errorMessage = result.Errors != null && result.Errors.Any()
                        ? string.Join("\n", result.Errors)
                        : "Failed to add category";

                    MessageBox.Show(errorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An unexpected error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                SaveButton.Enabled = true;
                Cursor = Cursors.Default;
            }
        }

        private async Task RefreshCategories()
        {
            try
            {
                var response = await _categoryServices.GetAllCategoriesWithProductsAsync();

                if (response.Succeeded && response.Data != null)
                {
                    dataGridView.DataSource = response.Data;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error refreshing categories: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void DeleteCategory_Click(object sender, EventArgs e)
        {
            SaveButton.Visible = true;
            UpdateButton.Visible = false;
            try
            {
                if (dataGridView.SelectedRows.Count > 0)
                {
                    var selectedRow = dataGridView.SelectedRows[0];
                    var categoryId = (int)selectedRow.Cells["CategoryID"].Value;
                    // استدعاء الخدمة لحذف الفئة
                    var result = await _categoryServices.DeleteCategoryAsync(categoryId);
                    if (result.Succeeded)
                    {
                        MessageBox.Show("Category deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        await RefreshCategories();
                    }
                    else
                    {
                        MessageBox.Show("Failed to delete category", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Please select a category to delete", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An unexpected error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void UpdateCategory_Click(object sender, EventArgs e)
        {
            try
            {
                dataGridView.EndEdit(); // <<< ده اللي بيعمل حفظ مؤقت للتعديل في الجدول

                var selectedRow = dataGridView.SelectedRows[0];
                var categoryId = (int)selectedRow.Cells["CategoryID"].Value;
                var categoryName = selectedRow.Cells["Name"].Value.ToString();
                var categoryDescription = selectedRow.Cells["Description"].Value.ToString();

                var CategoryDTO = new Application.DTOs.Category.UpdateCategoryDto
                {
                    CategoryID = categoryId,
                    Name = categoryName,
                    Description = categoryDescription
                };

                var category = await _categoryServices.UpdateCategoryAsync(CategoryDTO);
                if (category.Succeeded)
                {
                    MessageBox.Show("Category updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    await RefreshCategories();
                }
                else
                {
                    var errorMessage = category.Errors != null && category.Errors.Any()
                        ? string.Join("\n", category.Errors)
                        : "Failed to update category";
                    MessageBox.Show(errorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An unexpected error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                SaveButton.Visible = false;
                UpdateButton.Visible = true;
            }
        }


        private void guna2CircleButton1_Click(object sender, EventArgs e)
        {
            AddCatPanel.Visible = false;
        }

        private async void UpdateButton_Click(object sender, EventArgs e)
        {
            try
            {
                dataGridView.EndEdit(); // نحفظ التعديلات أولًا

                // تحقق إن فيه خلية متفعلة وفعلاً في صف حقيقي
                if (dataGridView.CurrentCell == null ||
                    dataGridView.CurrentCell.RowIndex < 0 ||
                    dataGridView.Rows[dataGridView.CurrentCell.RowIndex].IsNewRow)
                {
                    MessageBox.Show("Please select a valid row to update.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int rowIndex = dataGridView.CurrentCell.RowIndex;
                var row = dataGridView.Rows[rowIndex];

                // قراءة القيم من الصف
                int categoryId = Convert.ToInt32(row.Cells["CategoryID"].Value);
                string name = row.Cells["Name"].Value?.ToString();
                string description = row.Cells["Description"].Value?.ToString();

                var CategoryDTO = new Application.DTOs.Category.UpdateCategoryDto
                {
                    CategoryID = categoryId,
                    Name = name,
                    Description = description
                };

                var result = await _categoryServices.UpdateCategoryAsync(CategoryDTO);

                if (result.Succeeded)
                {
                    MessageBox.Show("Category updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    await RefreshCategories();
                }
                else
                {
                    var errorMessage = result.Errors != null && result.Errors.Any()
                        ? string.Join("\n", result.Errors)
                        : "Failed to update category";
                    MessageBox.Show(errorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An unexpected error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void guna2CircleButton4_Click(object sender, EventArgs e)
        {

        }

        private void guna2CircleButton2_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {
            var text = SearchCategory.Text.ToLower();
            if (string.IsNullOrEmpty(text))
            {
                RefreshCategories();
            }
            else
            {
                var result = _categoryServices.SearchCategoriesAsync(text);
                if (result != null && result.Result.Succeeded)
                {
                    dataGridView.DataSource = result.Result.Data;
                }
                else
                {
                    MessageBox.Show("No categories found.");
                }
            }

        }

        private void guna2CircleButton4_Click_1(object sender, EventArgs e)
        {

        }

        private void guna2CircleButton3_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}