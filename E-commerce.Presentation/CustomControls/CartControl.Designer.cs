namespace E_commerce.Presentation.CustomControls
{
    partial class CartControl
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            cartDataGridView = new Guna.UI2.WinForms.Guna2DataGridView();
            totalLabel = new Guna.UI2.WinForms.Guna2HtmlLabel();
            totalTextBox = new Guna.UI2.WinForms.Guna2TextBox();
            updateButton = new Guna.UI2.WinForms.Guna2GradientButton();
            checkoutButton = new Guna.UI2.WinForms.Guna2GradientButton();
            titleLabel = new Guna.UI2.WinForms.Guna2HtmlLabel();
            ((System.ComponentModel.ISupportInitialize)cartDataGridView).BeginInit();
            SuspendLayout();

            // cartDataGridView
            cartDataGridView.AllowUserToAddRows = false;
            cartDataGridView.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = Color.White;
            cartDataGridView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            cartDataGridView.BackgroundColor = SystemColors.ControlDark;
            cartDataGridView.BorderStyle = BorderStyle.FixedSingle;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(100, 88, 255);
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = Color.White;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            cartDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            cartDataGridView.ColumnHeadersHeight = 30;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.White;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle3.ForeColor = Color.FromArgb(71, 69, 94);
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(231, 229, 255);
            dataGridViewCellStyle3.SelectionForeColor = Color.FromArgb(71, 69, 94);
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            cartDataGridView.DefaultCellStyle = dataGridViewCellStyle3;
            cartDataGridView.GridColor = Color.FromArgb(231, 229, 255);
            cartDataGridView.Location = new Point(140, 80);
            cartDataGridView.Name = "cartDataGridView";
            cartDataGridView.RowHeadersVisible = false;
            cartDataGridView.RowTemplate.Height = 30;
            cartDataGridView.Size = new Size(715, 435);
            cartDataGridView.TabIndex = 0;
            cartDataGridView.ThemeStyle.AlternatingRowsStyle.BackColor = Color.White;
            cartDataGridView.ThemeStyle.AlternatingRowsStyle.Font = null;
            cartDataGridView.ThemeStyle.AlternatingRowsStyle.ForeColor = Color.Empty;
            cartDataGridView.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = Color.Empty;
            cartDataGridView.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = Color.Empty;
            cartDataGridView.ThemeStyle.BackColor = SystemColors.ControlDark;
            cartDataGridView.ThemeStyle.GridColor = Color.FromArgb(231, 229, 255);
            cartDataGridView.ThemeStyle.HeaderStyle.BackColor = Color.FromArgb(100, 88, 255);
            cartDataGridView.ThemeStyle.HeaderStyle.BorderStyle = DataGridViewHeaderBorderStyle.None;
            cartDataGridView.ThemeStyle.HeaderStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            cartDataGridView.ThemeStyle.HeaderStyle.ForeColor = Color.White;
            cartDataGridView.ThemeStyle.HeaderStyle.HeaightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            cartDataGridView.ThemeStyle.HeaderStyle.Height = 30;
            cartDataGridView.ThemeStyle.ReadOnly = false;
            cartDataGridView.ThemeStyle.RowsStyle.BackColor = Color.White;
            cartDataGridView.ThemeStyle.RowsStyle.BorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            cartDataGridView.ThemeStyle.RowsStyle.Font = new Font("Segoe UI", 9F);
            cartDataGridView.ThemeStyle.RowsStyle.ForeColor = Color.FromArgb(71, 69, 94);
            cartDataGridView.ThemeStyle.RowsStyle.Height = 30;
            cartDataGridView.ThemeStyle.RowsStyle.SelectionBackColor = Color.FromArgb(231, 229, 255);
            cartDataGridView.ThemeStyle.RowsStyle.SelectionForeColor = Color.FromArgb(71, 69, 94);

            // totalLabel
            totalLabel.BackColor = Color.Transparent;
            totalLabel.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            totalLabel.Location = new Point(407, 527);
            totalLabel.Name = "totalLabel";
            totalLabel.Size = new Size(49, 19);
            totalLabel.TabIndex = 1;
            totalLabel.Text = "TOTAL:";

            // totalTextBox
            totalTextBox.CustomizableEdges = customizableEdges1;
            totalTextBox.DefaultText = "0.00";
            totalTextBox.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            totalTextBox.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            totalTextBox.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            totalTextBox.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            totalTextBox.Enabled = false;
            totalTextBox.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            totalTextBox.Font = new Font("Segoe UI", 9F);
            totalTextBox.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            totalTextBox.Location = new Point(525, 521);
            totalTextBox.Name = "totalTextBox";
            totalTextBox.PlaceholderText = "";
            totalTextBox.SelectedText = "";
            totalTextBox.ShadowDecoration.CustomizableEdges = customizableEdges2;
            totalTextBox.Size = new Size(75, 36);
            totalTextBox.TabIndex = 2;

            // updateButton
            updateButton.CustomizableEdges = customizableEdges3;
            updateButton.DisabledState.BorderColor = Color.DarkGray;
            updateButton.DisabledState.CustomBorderColor = Color.DarkGray;
            updateButton.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            updateButton.DisabledState.FillColor2 = Color.FromArgb(169, 169, 169);
            updateButton.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            updateButton.FillColor2 = Color.Black;
            updateButton.Font = new Font("Segoe UI", 12.75F, FontStyle.Bold);
            updateButton.ForeColor = Color.White;
            updateButton.Location = new Point(365, 563);
            updateButton.Name = "updateButton";
            updateButton.ShadowDecoration.CustomizableEdges = customizableEdges4;
            updateButton.Size = new Size(120, 45);
            updateButton.TabIndex = 3;
            updateButton.Text = "Update";
            updateButton.Click += UpdateButton_Click;

            // checkoutButton
            checkoutButton.CustomizableEdges = customizableEdges5;
            checkoutButton.DisabledState.BorderColor = Color.DarkGray;
            checkoutButton.DisabledState.CustomBorderColor = Color.DarkGray;
            checkoutButton.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            checkoutButton.DisabledState.FillColor2 = Color.FromArgb(169, 169, 169);
            checkoutButton.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            checkoutButton.FillColor2 = Color.Black;
            checkoutButton.Font = new Font("Segoe UI", 12.75F, FontStyle.Bold);
            checkoutButton.ForeColor = Color.White;
            checkoutButton.Location = new Point(505, 563);
            checkoutButton.Name = "checkoutButton";
            checkoutButton.ShadowDecoration.CustomizableEdges = customizableEdges6;
            checkoutButton.Size = new Size(120, 45);
            checkoutButton.TabIndex = 4;
            checkoutButton.Text = "Checkout";
            checkoutButton.Click += CheckoutButton_Click;

            // titleLabel
            titleLabel.BackColor = Color.Transparent;
            titleLabel.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            titleLabel.Location = new Point(140, 40);
            titleLabel.Name = "titleLabel";
            titleLabel.Size = new Size(112, 34);
            titleLabel.TabIndex = 13;
            titleLabel.Text = "Your Cart";

            // CartControl
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(titleLabel);
            Controls.Add(checkoutButton);
            Controls.Add(updateButton);
            Controls.Add(totalTextBox);
            Controls.Add(totalLabel);
            Controls.Add(cartDataGridView);
            Name = "CartControl";
            Size = new Size(1386, 920);
            Load += CartControl_Load;
            ((System.ComponentModel.ISupportInitialize)cartDataGridView).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private Guna.UI2.WinForms.Guna2DataGridView cartDataGridView;
        private Guna.UI2.WinForms.Guna2HtmlLabel totalLabel;
        private Guna.UI2.WinForms.Guna2TextBox totalTextBox;
        private Guna.UI2.WinForms.Guna2GradientButton updateButton;
        private Guna.UI2.WinForms.Guna2GradientButton checkoutButton;
        private Guna.UI2.WinForms.Guna2HtmlLabel titleLabel;
    }
}