using Guna.UI2.WinForms;

namespace E_commerce.Presentation.CustomControls
{
    partial class OrderControl
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

            dataGridViewCart = new Guna.UI2.WinForms.Guna2DataGridView();
            guna2HtmlLabelTotal = new Guna.UI2.WinForms.Guna2HtmlLabel();
            textBoxTotal = new Guna.UI2.WinForms.Guna2TextBox();
            btnOK = new Guna.UI2.WinForms.Guna2GradientButton();
            btnCancel = new Guna.UI2.WinForms.Guna2GradientButton();
            titleLabel = new Guna.UI2.WinForms.Guna2HtmlLabel();

            ((System.ComponentModel.ISupportInitialize)dataGridViewCart).BeginInit();
            SuspendLayout();

            // dataGridViewCart
            dataGridViewCart.AllowUserToAddRows = false;
            dataGridViewCart.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = Color.White;
            dataGridViewCart.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewCart.BackgroundColor = SystemColors.ControlDark;
            dataGridViewCart.BorderStyle = BorderStyle.FixedSingle;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(100, 88, 255);
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = Color.White;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dataGridViewCart.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dataGridViewCart.ColumnHeadersHeight = 30;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.White;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle3.ForeColor = Color.FromArgb(71, 69, 94);
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(231, 229, 255);
            dataGridViewCellStyle3.SelectionForeColor = Color.FromArgb(71, 69, 94);
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            dataGridViewCart.DefaultCellStyle = dataGridViewCellStyle3;
            dataGridViewCart.GridColor = Color.FromArgb(231, 229, 255);
            dataGridViewCart.Location = new Point(140, 80);
            dataGridViewCart.Name = "dataGridViewCart";
            dataGridViewCart.RowHeadersVisible = false;
            dataGridViewCart.RowTemplate.Height = 30;
            dataGridViewCart.Size = new Size(715, 435);
            dataGridViewCart.TabIndex = 0;
            dataGridViewCart.ThemeStyle.AlternatingRowsStyle.BackColor = Color.White;
            dataGridViewCart.ThemeStyle.AlternatingRowsStyle.Font = null;
            dataGridViewCellStyle3.SelectionForeColor = Color.FromArgb(71, 69, 94);
            dataGridViewCart.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = Color.Empty;
            dataGridViewCart.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = Color.Empty;
            dataGridViewCart.ThemeStyle.BackColor = SystemColors.ControlDark;
            dataGridViewCart.ThemeStyle.GridColor = Color.FromArgb(231, 229, 255);
            dataGridViewCart.ThemeStyle.HeaderStyle.BackColor = Color.FromArgb(100, 88, 255);
            dataGridViewCart.ThemeStyle.HeaderStyle.BorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCart.ThemeStyle.HeaderStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            dataGridViewCart.ThemeStyle.HeaderStyle.ForeColor = Color.White;
            dataGridViewCart.ThemeStyle.HeaderStyle.HeaightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCart.ThemeStyle.HeaderStyle.Height = 30;
            dataGridViewCart.ThemeStyle.ReadOnly = false;
            dataGridViewCart.ThemeStyle.RowsStyle.BackColor = Color.White;
            dataGridViewCart.ThemeStyle.RowsStyle.BorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridViewCart.ThemeStyle.RowsStyle.Font = new Font("Segoe UI", 9F);
            dataGridViewCart.ThemeStyle.RowsStyle.ForeColor = Color.FromArgb(71, 69, 94);
            dataGridViewCart.ThemeStyle.RowsStyle.Height = 30;
            dataGridViewCart.ThemeStyle.RowsStyle.SelectionBackColor = Color.FromArgb(231, 229, 255);
            dataGridViewCart.ThemeStyle.RowsStyle.SelectionForeColor = Color.FromArgb(71, 69, 94);

            // guna2HtmlLabelTotal
            guna2HtmlLabelTotal.BackColor = Color.Transparent;
            guna2HtmlLabelTotal.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            guna2HtmlLabelTotal.Location = new Point(407, 527);
            guna2HtmlLabelTotal.Name = "guna2HtmlLabelTotal";
            guna2HtmlLabelTotal.Size = new Size(49, 19);
            guna2HtmlLabelTotal.TabIndex = 1;
            guna2HtmlLabelTotal.Text = "TOTAL:";

            // textBoxTotal
            textBoxTotal.CustomizableEdges = customizableEdges1;
            textBoxTotal.DefaultText = "0.00";
            textBoxTotal.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            textBoxTotal.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            textBoxTotal.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            textBoxTotal.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            textBoxTotal.Enabled = false;
            textBoxTotal.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            textBoxTotal.Font = new Font("Segoe UI", 9F);
            textBoxTotal.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            textBoxTotal.Location = new Point(525, 521);
            textBoxTotal.Name = "textBoxTotal";
            textBoxTotal.PlaceholderText = "";
            textBoxTotal.SelectedText = "";
            textBoxTotal.ShadowDecoration.CustomizableEdges = customizableEdges2;
            textBoxTotal.Size = new Size(75, 36);
            textBoxTotal.TabIndex = 2;

            // btnOK
            btnOK.CustomizableEdges = customizableEdges3;
            btnOK.DisabledState.BorderColor = Color.DarkGray;
            btnOK.DisabledState.CustomBorderColor = Color.DarkGray;
            btnOK.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnOK.DisabledState.FillColor2 = Color.FromArgb(169, 169, 169);
            btnOK.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnOK.FillColor2 = Color.Black;
            btnOK.Font = new Font("Segoe UI", 12.75F, FontStyle.Bold);
            btnOK.ForeColor = Color.White;
            btnOK.Location = new Point(365, 563);
            btnOK.Name = "btnOK";
            btnOK.ShadowDecoration.CustomizableEdges = customizableEdges4;
            btnOK.Size = new Size(120, 45);
            btnOK.TabIndex = 3;
            btnOK.Text = "OK";
            btnOK.Click += btnOK_Click;

            // btnCancel
            btnCancel.CustomizableEdges = customizableEdges5;
            btnCancel.DisabledState.BorderColor = Color.DarkGray;
            btnCancel.DisabledState.CustomBorderColor = Color.DarkGray;
            btnCancel.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnCancel.DisabledState.FillColor2 = Color.FromArgb(169, 169, 169);
            btnCancel.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnCancel.FillColor2 = Color.Black;
            btnCancel.Font = new Font("Segoe UI", 12.75F, FontStyle.Bold);
            btnCancel.ForeColor = Color.White;
            btnCancel.Location = new Point(505, 563);
            btnCancel.Name = "btnCancel";
            btnCancel.ShadowDecoration.CustomizableEdges = customizableEdges6;
            btnCancel.Size = new Size(120, 45);
            btnCancel.TabIndex = 4;
            btnCancel.Text = "Cancel";
            btnCancel.Click += btnCancel_Click;

            // titleLabel
            titleLabel.BackColor = Color.Transparent;
            titleLabel.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            titleLabel.Location = new Point(140, 40);
            titleLabel.Name = "titleLabel";
            titleLabel.Size = new Size(150, 34);
            titleLabel.TabIndex = 13;
            titleLabel.Text = "Your Order";

            // OrderControl
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            Controls.Add(titleLabel);
            Controls.Add(btnCancel);
            Controls.Add(btnOK);
            Controls.Add(textBoxTotal);
            Controls.Add(guna2HtmlLabelTotal);
            Controls.Add(dataGridViewCart);
            Name = "OrderControl";
            Size = new Size(1386, 788);
            ((System.ComponentModel.ISupportInitialize)dataGridViewCart).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private Guna2DataGridView dataGridViewCart;
        private Guna2HtmlLabel guna2HtmlLabelTotal;
        private Guna2TextBox textBoxTotal;
        private Guna2GradientButton btnOK;
        private Guna2GradientButton btnCancel;
        private Guna2HtmlLabel titleLabel;
    }
}