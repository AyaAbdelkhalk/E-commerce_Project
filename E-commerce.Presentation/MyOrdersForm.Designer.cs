using Guna.UI2.WinForms;
using Guna.UI2.WinForms.Suite;

namespace E_commerce.Presentation
{
    partial class MyOrdersForm
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
            CustomizableEdges customizableEdges1 = new CustomizableEdges();
            CustomizableEdges customizableEdges2 = new CustomizableEdges();
            CustomizableEdges customizableEdges3 = new CustomizableEdges();
            dataGridViewOrders = new Guna2DataGridView();
            guna2CircleButtonClose = new Guna2CircleButton();
            guna2CircleButtonMinimize = new Guna2CircleButton();
            guna2CircleButtonMaximize = new Guna2CircleButton();
            titleLabel = new Guna2HtmlLabel();
            ((System.ComponentModel.ISupportInitialize)dataGridViewOrders).BeginInit();
            SuspendLayout();
            // 
            // dataGridViewOrders
            // 
            dataGridViewOrders.AllowUserToAddRows = false;
            dataGridViewOrders.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = Color.White;
            dataGridViewOrders.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewOrders.BackgroundColor = SystemColors.ControlDark;
            dataGridViewOrders.BorderStyle = BorderStyle.FixedSingle;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(100, 88, 255);
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = Color.White;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dataGridViewOrders.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dataGridViewOrders.ColumnHeadersHeight = 30;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.White;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle3.ForeColor = Color.FromArgb(71, 69, 94);
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(231, 229, 255);
            dataGridViewCellStyle3.SelectionForeColor = Color.FromArgb(71, 69, 94);
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            dataGridViewOrders.DefaultCellStyle = dataGridViewCellStyle3;
            dataGridViewOrders.GridColor = Color.FromArgb(231, 229, 255);
            dataGridViewOrders.Location = new Point(140, 80);
            dataGridViewOrders.Name = "dataGridViewOrders";
            dataGridViewOrders.RowHeadersVisible = false;
            dataGridViewOrders.RowTemplate.Height = 30;
            dataGridViewOrders.Size = new Size(715, 435);
            dataGridViewOrders.TabIndex = 0;
            dataGridViewOrders.ThemeStyle.AlternatingRowsStyle.BackColor = Color.White;
            dataGridViewOrders.ThemeStyle.AlternatingRowsStyle.Font = null;
            dataGridViewOrders.ThemeStyle.AlternatingRowsStyle.ForeColor = Color.Empty;
            dataGridViewOrders.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = Color.Empty;
            dataGridViewOrders.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = Color.Empty;
            dataGridViewOrders.ThemeStyle.BackColor = SystemColors.ControlDark;
            dataGridViewOrders.ThemeStyle.GridColor = Color.FromArgb(231, 229, 255);
            dataGridViewOrders.ThemeStyle.HeaderStyle.BackColor = Color.FromArgb(100, 88, 255);
            dataGridViewOrders.ThemeStyle.HeaderStyle.BorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewOrders.ThemeStyle.HeaderStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            dataGridViewOrders.ThemeStyle.HeaderStyle.ForeColor = Color.White;
            dataGridViewOrders.ThemeStyle.HeaderStyle.HeaightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewOrders.ThemeStyle.HeaderStyle.Height = 30;
            dataGridViewOrders.ThemeStyle.ReadOnly = false;
            dataGridViewOrders.ThemeStyle.RowsStyle.BackColor = Color.White;
            dataGridViewOrders.ThemeStyle.RowsStyle.BorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridViewOrders.ThemeStyle.RowsStyle.Font = new Font("Segoe UI", 9F);
            dataGridViewOrders.ThemeStyle.RowsStyle.ForeColor = Color.FromArgb(71, 69, 94);
            dataGridViewOrders.ThemeStyle.RowsStyle.Height = 30;
            dataGridViewOrders.ThemeStyle.RowsStyle.SelectionBackColor = Color.FromArgb(231, 229, 255);
            dataGridViewOrders.ThemeStyle.RowsStyle.SelectionForeColor = Color.FromArgb(71, 69, 94);
            dataGridViewOrders.CellContentClick += dataGridViewOrders_CellContentClick_1;
            // 
            // guna2CircleButtonClose
            // 
            guna2CircleButtonClose.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            guna2CircleButtonClose.DisabledState.BorderColor = Color.DarkGray;
            guna2CircleButtonClose.DisabledState.CustomBorderColor = Color.DarkGray;
            guna2CircleButtonClose.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            guna2CircleButtonClose.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            guna2CircleButtonClose.FillColor = Color.IndianRed;
            guna2CircleButtonClose.Font = new Font("Segoe UI", 9F);
            guna2CircleButtonClose.ForeColor = Color.White;
            guna2CircleButtonClose.Location = new Point(839, 12);
            guna2CircleButtonClose.Name = "guna2CircleButtonClose";
            guna2CircleButtonClose.ShadowDecoration.CustomizableEdges = customizableEdges1;
            guna2CircleButtonClose.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            guna2CircleButtonClose.Size = new Size(16, 17);
            guna2CircleButtonClose.TabIndex = 9;
            guna2CircleButtonClose.Text = "X";
            guna2CircleButtonClose.Click += guna2CircleButtonClose_Click;
            // 
            // guna2CircleButtonMinimize
            // 
            guna2CircleButtonMinimize.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            guna2CircleButtonMinimize.DisabledState.BorderColor = Color.DarkGray;
            guna2CircleButtonMinimize.DisabledState.CustomBorderColor = Color.DarkGray;
            guna2CircleButtonMinimize.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            guna2CircleButtonMinimize.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            guna2CircleButtonMinimize.FillColor = Color.ForestGreen;
            guna2CircleButtonMinimize.Font = new Font("Segoe UI", 9F);
            guna2CircleButtonMinimize.ForeColor = Color.White;
            guna2CircleButtonMinimize.Location = new Point(801, 12);
            guna2CircleButtonMinimize.Name = "guna2CircleButtonMinimize";
            guna2CircleButtonMinimize.ShadowDecoration.CustomizableEdges = customizableEdges2;
            guna2CircleButtonMinimize.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            guna2CircleButtonMinimize.Size = new Size(16, 17);
            guna2CircleButtonMinimize.TabIndex = 10;
            guna2CircleButtonMinimize.Text = "-";
            guna2CircleButtonMinimize.Click += guna2CircleButtonMinimize_Click;
            // 
            // guna2CircleButtonMaximize
            // 
            guna2CircleButtonMaximize.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            guna2CircleButtonMaximize.DisabledState.BorderColor = Color.DarkGray;
            guna2CircleButtonMaximize.DisabledState.CustomBorderColor = Color.DarkGray;
            guna2CircleButtonMaximize.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            guna2CircleButtonMaximize.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            guna2CircleButtonMaximize.FillColor = Color.Orange;
            guna2CircleButtonMaximize.Font = new Font("Segoe UI", 9F);
            guna2CircleButtonMaximize.ForeColor = Color.White;
            guna2CircleButtonMaximize.Location = new Point(820, 12);
            guna2CircleButtonMaximize.Name = "guna2CircleButtonMaximize";
            guna2CircleButtonMaximize.ShadowDecoration.CustomizableEdges = customizableEdges3;
            guna2CircleButtonMaximize.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            guna2CircleButtonMaximize.Size = new Size(16, 17);
            guna2CircleButtonMaximize.TabIndex = 11;
            guna2CircleButtonMaximize.Text = "□";
            guna2CircleButtonMaximize.Click += guna2CircleButtonMaximize_Click;
            // 
            // titleLabel
            // 
            titleLabel.BackColor = Color.Transparent;
            titleLabel.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            titleLabel.Location = new Point(140, 40);
            titleLabel.Name = "titleLabel";
            titleLabel.Size = new Size(123, 34);
            titleLabel.TabIndex = 13;
            titleLabel.Text = "My Orders";
            // 
            // MyOrdersForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            ClientSize = new Size(1386, 788);
            Controls.Add(titleLabel);
            Controls.Add(guna2CircleButtonMaximize);
            Controls.Add(guna2CircleButtonMinimize);
            Controls.Add(guna2CircleButtonClose);
            Controls.Add(dataGridViewOrders);
            FormBorderStyle = FormBorderStyle.None;
            Name = "MyOrdersForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "My Orders";
            Load += MyOrdersForm_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridViewOrders).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private Guna2DataGridView dataGridViewOrders;
        private Guna2CircleButton guna2CircleButtonClose;
        private Guna2CircleButton guna2CircleButtonMinimize;
        private Guna2CircleButton guna2CircleButtonMaximize;
        private Guna2HtmlLabel titleLabel;
    }
}