using Guna.UI2.WinForms.Suite;
using Guna.UI2.WinForms;

namespace E_commerce.Presentation
{
    partial class AdminOrderForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
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
            CustomizableEdges customizableEdges4 = new CustomizableEdges();
            CustomizableEdges customizableEdges5 = new CustomizableEdges();
            CustomizableEdges customizableEdges6 = new CustomizableEdges();
            CustomizableEdges customizableEdges7 = new CustomizableEdges();
            CustomizableEdges customizableEdges8 = new CustomizableEdges();
            CustomizableEdges customizableEdges9 = new CustomizableEdges();
            dataGridViewOrders = new Guna2DataGridView();
            guna2CircleButtonClose = new Guna2CircleButton();
            guna2CircleButtonMinimize = new Guna2CircleButton();
            guna2CircleButtonMaximize = new Guna2CircleButton();
            titleLabel = new Guna2HtmlLabel();
            statusComboBox = new Guna2ComboBox();
            searchButton = new Guna2GradientButton();
            updateStatusButton = new Guna2GradientButton();
            ((System.ComponentModel.ISupportInitialize)dataGridViewOrders).BeginInit();
            SuspendLayout();
            // 
            // dataGridViewOrders
            // 
            dataGridViewOrders.AllowUserToAddRows = false;
            dataGridViewOrders.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = Color.White;
            dataGridViewOrders.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewOrders.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
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
            dataGridViewOrders.Location = new Point(51, 271);
            dataGridViewOrders.Margin = new Padding(3, 4, 3, 4);
            dataGridViewOrders.Name = "dataGridViewOrders";
            dataGridViewOrders.RowHeadersVisible = false;
            dataGridViewOrders.RowHeadersWidth = 51;
            dataGridViewOrders.RowTemplate.Height = 30;
            dataGridViewOrders.Size = new Size(600, 57);
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
            dataGridViewOrders.CellContentClick += dataGridViewOrders_CellContentClick;
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
            guna2CircleButtonClose.Location = new Point(659, 12);
            guna2CircleButtonClose.Margin = new Padding(3, 4, 3, 4);
            guna2CircleButtonClose.Name = "guna2CircleButtonClose";
            guna2CircleButtonClose.ShadowDecoration.CustomizableEdges = customizableEdges1;
            guna2CircleButtonClose.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            guna2CircleButtonClose.Size = new Size(18, 23);
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
            guna2CircleButtonMinimize.Location = new Point(615, 12);
            guna2CircleButtonMinimize.Margin = new Padding(3, 4, 3, 4);
            guna2CircleButtonMinimize.Name = "guna2CircleButtonMinimize";
            guna2CircleButtonMinimize.ShadowDecoration.CustomizableEdges = customizableEdges2;
            guna2CircleButtonMinimize.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            guna2CircleButtonMinimize.Size = new Size(18, 23);
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
            guna2CircleButtonMaximize.Location = new Point(637, 12);
            guna2CircleButtonMaximize.Margin = new Padding(3, 4, 3, 4);
            guna2CircleButtonMaximize.Name = "guna2CircleButtonMaximize";
            guna2CircleButtonMaximize.ShadowDecoration.CustomizableEdges = customizableEdges3;
            guna2CircleButtonMaximize.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            guna2CircleButtonMaximize.Size = new Size(18, 23);
            guna2CircleButtonMaximize.TabIndex = 11;
            guna2CircleButtonMaximize.Text = "□";
            guna2CircleButtonMaximize.Click += guna2CircleButtonMaximize_Click;
            // 
            // titleLabel
            // 
            titleLabel.BackColor = Color.Transparent;
            titleLabel.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            titleLabel.Location = new Point(346, 1);
            titleLabel.Margin = new Padding(3, 4, 3, 4);
            titleLabel.Name = "titleLabel";
            titleLabel.Size = new Size(200, 43);
            titleLabel.TabIndex = 13;
            titleLabel.Text = "Admin Orders";
            // 
            // statusComboBox
            // 
            statusComboBox.BackColor = Color.Transparent;
            statusComboBox.BorderRadius = 5;
            statusComboBox.CustomizableEdges = customizableEdges4;
            statusComboBox.DrawMode = DrawMode.OwnerDrawFixed;
            statusComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            statusComboBox.FocusedColor = Color.FromArgb(94, 148, 255);
            statusComboBox.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            statusComboBox.Font = new Font("Segoe UI", 10F);
            statusComboBox.ForeColor = Color.FromArgb(68, 88, 112);
            statusComboBox.ItemHeight = 30;
            statusComboBox.Location = new Point(346, 58);
            statusComboBox.Margin = new Padding(3, 4, 3, 4);
            statusComboBox.Name = "statusComboBox";
            statusComboBox.ShadowDecoration.CustomizableEdges = customizableEdges5;
            statusComboBox.Size = new Size(228, 36);
            statusComboBox.TabIndex = 14;
            // 
            // searchButton
            // 
            searchButton.CustomizableEdges = customizableEdges6;
            searchButton.DisabledState.BorderColor = Color.DarkGray;
            searchButton.DisabledState.CustomBorderColor = Color.DarkGray;
            searchButton.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            searchButton.DisabledState.FillColor2 = Color.FromArgb(169, 169, 169);
            searchButton.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            searchButton.FillColor = Color.FromArgb(100, 88, 255);
            searchButton.FillColor2 = Color.FromArgb(72, 60, 227);
            searchButton.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            searchButton.ForeColor = Color.White;
            searchButton.Location = new Point(586, 58);
            searchButton.Margin = new Padding(3, 4, 3, 4);
            searchButton.Name = "searchButton";
            searchButton.ShadowDecoration.CustomizableEdges = customizableEdges7;
            searchButton.Size = new Size(114, 40);
            searchButton.TabIndex = 15;
            searchButton.Text = "Search";
            searchButton.Click += searchButton_Click;
            // 
            // updateStatusButton
            // 
            updateStatusButton.CustomizableEdges = customizableEdges8;
            updateStatusButton.DisabledState.BorderColor = Color.DarkGray;
            updateStatusButton.DisabledState.CustomBorderColor = Color.DarkGray;
            updateStatusButton.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            updateStatusButton.DisabledState.FillColor2 = Color.FromArgb(169, 169, 169);
            updateStatusButton.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            updateStatusButton.FillColor = Color.FromArgb(255, 140, 0);
            updateStatusButton.FillColor2 = Color.FromArgb(255, 165, 0);
            updateStatusButton.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            updateStatusButton.ForeColor = Color.White;
            updateStatusButton.Location = new Point(712, 58);
            updateStatusButton.Margin = new Padding(3, 4, 3, 4);
            updateStatusButton.Name = "updateStatusButton";
            updateStatusButton.ShadowDecoration.CustomizableEdges = customizableEdges9;
            updateStatusButton.Size = new Size(171, 40);
            updateStatusButton.TabIndex = 16;
            updateStatusButton.Text = "Update Status";
            updateStatusButton.Click += updateStatusButton_Click;
            // 
            // AdminOrderForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            BackColor = SystemColors.Control;
            ClientSize = new Size(900, 600);
            Controls.Add(updateStatusButton);
            Controls.Add(searchButton);
            Controls.Add(statusComboBox);
            Controls.Add(titleLabel);
            Controls.Add(guna2CircleButtonMaximize);
            Controls.Add(guna2CircleButtonMinimize);
            Controls.Add(guna2CircleButtonClose);
            Controls.Add(dataGridViewOrders);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(3, 4, 3, 4);
            Name = "AdminOrderForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Admin Orders";
            Load += AdminOrderForm_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridViewOrders).EndInit();
            ResumeLayout(false);
            PerformLayout();

        }

        private Guna2DataGridView dataGridViewOrders;
        private Guna2CircleButton guna2CircleButtonClose;
        private Guna2CircleButton guna2CircleButtonMinimize;
        private Guna2CircleButton guna2CircleButtonMaximize;
        private Guna2HtmlLabel titleLabel;
        private Guna2ComboBox statusComboBox;
        private Guna2GradientButton searchButton;
        private Guna2GradientButton updateStatusButton;
    }
}
