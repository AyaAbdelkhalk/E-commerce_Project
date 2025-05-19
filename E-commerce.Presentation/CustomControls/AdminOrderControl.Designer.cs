using Guna.UI2.WinForms.Suite;
using Guna.UI2.WinForms;

namespace E_commerce.Presentation.CustomControls
{
    partial class AdminOrderControl
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
            dataGridViewOrders = new Guna2DataGridView();
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
            dataGridViewOrders.Location = new Point(20, 100);
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
            dataGridViewOrders.CellContentClick += dataGridViewOrders_CellContentClick;
            // 
            // titleLabel
            // 
            titleLabel.BackColor = Color.Transparent;
            titleLabel.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            titleLabel.Location = new Point(20, 20);
            titleLabel.Name = "titleLabel";
            titleLabel.Size = new Size(200, 43);
            titleLabel.TabIndex = 13;
            titleLabel.Text = "Admin Orders";
            // 
            // statusComboBox
            // 
            statusComboBox.BackColor = Color.Transparent;
            statusComboBox.BorderRadius = 5;
            statusComboBox.DrawMode = DrawMode.OwnerDrawFixed;
            statusComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            statusComboBox.FocusedColor = Color.FromArgb(94, 148, 255);
            statusComboBox.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            statusComboBox.Font = new Font("Segoe UI", 10F);
            statusComboBox.ForeColor = Color.FromArgb(68, 88, 112);
            statusComboBox.ItemHeight = 30;
            statusComboBox.Location = new Point(20, 60);
            statusComboBox.Name = "statusComboBox";
            statusComboBox.Size = new Size(228, 36);
            statusComboBox.TabIndex = 14;
            // 
            // searchButton
            // 
            searchButton.DisabledState.BorderColor = Color.DarkGray;
            searchButton.DisabledState.CustomBorderColor = Color.DarkGray;
            searchButton.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            searchButton.DisabledState.FillColor2 = Color.FromArgb(169, 169, 169);
            searchButton.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            searchButton.FillColor = Color.FromArgb(100, 88, 255);
            searchButton.FillColor2 = Color.FromArgb(72, 60, 227);
            searchButton.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            searchButton.ForeColor = Color.White;
            searchButton.Location = new Point(258, 60);
            searchButton.Name = "searchButton";
            searchButton.Size = new Size(114, 40);
            searchButton.TabIndex = 15;
            searchButton.Text = "Search";
            searchButton.Click += searchButton_Click;
            // 
            // updateStatusButton
            // 
            updateStatusButton.DisabledState.BorderColor = Color.DarkGray;
            updateStatusButton.DisabledState.CustomBorderColor = Color.DarkGray;
            updateStatusButton.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            updateStatusButton.DisabledState.FillColor2 = Color.FromArgb(169, 169, 169);
            updateStatusButton.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            updateStatusButton.FillColor = Color.FromArgb(255, 140, 0);
            updateStatusButton.FillColor2 = Color.FromArgb(255, 165, 0);
            updateStatusButton.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            updateStatusButton.ForeColor = Color.White;
            updateStatusButton.Location = new Point(378, 60);
            updateStatusButton.Name = "updateStatusButton";
            updateStatusButton.Size = new Size(171, 40);
            updateStatusButton.TabIndex = 16;
            updateStatusButton.Text = "Update Status";
            updateStatusButton.Click += updateStatusButton_Click;
            // 
            // AdminOrderControl
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            Controls.Add(updateStatusButton);
            Controls.Add(searchButton);
            Controls.Add(statusComboBox);
            Controls.Add(titleLabel);
            Controls.Add(dataGridViewOrders);
            Name = "AdminOrderControl";
            Size = new Size(900, 600);
            ((System.ComponentModel.ISupportInitialize)dataGridViewOrders).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private Guna2DataGridView dataGridViewOrders;
        private Guna2HtmlLabel titleLabel;
        private Guna2ComboBox statusComboBox;
        private Guna2GradientButton searchButton;
        private Guna2GradientButton updateStatusButton;
    }
}

