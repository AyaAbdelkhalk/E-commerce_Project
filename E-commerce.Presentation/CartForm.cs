using System;
using System.Windows.Forms;
using E_commerce.Application.DTOs;
using E_commerce.Application.Services.CartItemService;
using System.Threading.Tasks;
using System.Linq;
using E_commerce.Application.Helper;

namespace E_commerce.Presentation
{
    public partial class CartForm : Form
    {
        private readonly ICartItemService _cartItemService;
        private int _userId;

        public CartForm(ICartItemService cartItemService)
        {
            _cartItemService = cartItemService ?? throw new ArgumentNullException(nameof(cartItemService));
            _userId = GetCurrentUserId();
            InitializeComponent();
        }

        private void CartForm_Load(object sender, EventArgs e)
        {
            LoadCartItems();
        }

        private async void LoadCartItems()
        {
            try
            {
                var response = await _cartItemService.GetCartItemsByUserIdAsync(_userId);
                if (response.Succeeded && response.Data != null)
                {
                    dataGridViewCart.DataSource = null;
                    dataGridViewCart.DataSource = response.Data.ToList();
                    UpdateTotal();
                }
                else
                {
                    string errorMessage = response.Errors != null && response.Errors.Any()
                        ? string.Join(Environment.NewLine, response.Errors)
                        : "Failed to load cart items";
                    MessageBox.Show(errorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to load cart items: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateTotal()
        {
            if (dataGridViewCart.DataSource == null) return;

            decimal total = 0;
            foreach (DataGridViewRow row in dataGridViewCart.Rows)
            {
                if (row.DataBoundItem is CartItemDTO item)
                {
                    total += item.TotalPrice;
                }
            }
            textBoxTotal.Text = total.ToString("C");
        }

        private async void dataGridViewCart_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex < 0 || e.ColumnIndex < 0) return;

                if (dataGridViewCart.Columns[e.ColumnIndex].Name == "Remove" && e.RowIndex >= 0)
                {
                    if (dataGridViewCart.Rows[e.RowIndex].Cells["CartItemID"].Value != null &&
                        int.TryParse(dataGridViewCart.Rows[e.RowIndex].Cells["CartItemID"].Value.ToString(), out int cartItemId))
                    {
                        var response = await _cartItemService.RemoveFromCartAsync(cartItemId);
                        if (response.Succeeded)
                        {
                            LoadCartItems();
                            MessageBox.Show("Item removed successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            string errorMessage = response.Errors != null && response.Errors.Any()
                                ? string.Join(Environment.NewLine, response.Errors)
                                : "Failed to remove item";
                            MessageBox.Show(errorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Invalid cart item ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to remove item: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridViewCart.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Please select a cart item to update.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var selectedRow = dataGridViewCart.SelectedRows[0];
                if (selectedRow.Cells["CartItemID"].Value == null ||
                    !int.TryParse(selectedRow.Cells["CartItemID"].Value.ToString(), out int cartItemId))
                {
                    MessageBox.Show("Invalid cart item ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (selectedRow.Cells["Quantity"].Value == null ||
                    !int.TryParse(selectedRow.Cells["Quantity"].Value.ToString(), out int newQuantity) || newQuantity <= 0)
                {
                    MessageBox.Show("Please enter a valid positive quantity.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var response = await _cartItemService.UpdateCartItemQuantityAsync(cartItemId, newQuantity);
                if (response.Succeeded)
                {
                    LoadCartItems();
                    MessageBox.Show("Quantity updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    string errorMessage = response.Errors != null && response.Errors.Any()
                        ? string.Join(Environment.NewLine, response.Errors)
                        : "Failed to update quantity";
                    MessageBox.Show(errorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to update quantity: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnCheckout_Click(object sender, EventArgs e)
        {
            try
            {
                var cartItemsResponse = await _cartItemService.GetCartItemsByUserIdAsync(_userId);
                if (!cartItemsResponse.Succeeded || cartItemsResponse.Data == null || !cartItemsResponse.Data.Any())
                {
                    MessageBox.Show("Your cart is empty or could not be loaded.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var clearResponse = await _cartItemService.ClearCartAsync(_userId);
                if (clearResponse.Succeeded)
                {
                    LoadCartItems();
                    MessageBox.Show("Cart cleared. Order creation to be implemented.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    string errorMessage = clearResponse.Errors != null && clearResponse.Errors.Any()
                        ? string.Join(Environment.NewLine, clearResponse.Errors)
                        : "Failed to clear cart";
                    MessageBox.Show(errorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                // TODO: Implement order creation logic when IOrderService or equivalent is available
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to place order: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private int GetCurrentUserId()
        {
            return SessionManager.CurrentUser?.UserID ?? 1; // Replace with actual logic
        }
    }
}