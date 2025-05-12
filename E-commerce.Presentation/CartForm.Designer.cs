namespace E_commerce.Presentation
{
    partial class CartForm
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
        private void guna2CircleButtonClose_Click(object sender, EventArgs e)
        {
            // Add your logic here for when the close button is clicked
            this.Close(); // Example: Closes the form
        }

        private void InitializeComponent()
        {
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges9 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges10 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges7 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges8 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            dataGridViewCart = new DataGridView();
            dataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn2 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn3 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn4 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn5 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn6 = new DataGridViewTextBoxColumn();
            dataGridViewButtonColumn1 = new DataGridViewButtonColumn();
            guna2HtmlLabelTotal = new Guna.UI2.WinForms.Guna2HtmlLabel();
            textBoxTotal = new Guna.UI2.WinForms.Guna2TextBox();
            btnUpdate = new Guna.UI2.WinForms.Guna2GradientButton();
            btnCheckout = new Guna.UI2.WinForms.Guna2GradientButton();
            guna2CustomGradientPanel = new Guna.UI2.WinForms.Guna2CustomGradientPanel();
            guna2CircleButtonClose = new Guna.UI2.WinForms.Guna2CircleButton();
            guna2CircleButtonMinimize = new Guna.UI2.WinForms.Guna2CircleButton();
            guna2CircleButtonMaximize = new Guna.UI2.WinForms.Guna2CircleButton();
            ((System.ComponentModel.ISupportInitialize)dataGridViewCart).BeginInit();
            guna2CustomGradientPanel.SuspendLayout();
            SuspendLayout();
            // 
            // dataGridViewCart
            // 
            dataGridViewCart.AllowUserToAddRows = false;
            dataGridViewCart.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCart.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCart.Columns.AddRange(new DataGridViewColumn[] { dataGridViewTextBoxColumn1, dataGridViewTextBoxColumn2, dataGridViewTextBoxColumn3, dataGridViewTextBoxColumn4, dataGridViewTextBoxColumn5, dataGridViewTextBoxColumn6, dataGridViewButtonColumn1 });
            dataGridViewCart.Location = new Point(20, 20);
            dataGridViewCart.Name = "dataGridViewCart";
            dataGridViewCart.RowHeadersWidth = 51;
            dataGridViewCart.Size = new Size(951, 300);
            dataGridViewCart.TabIndex = 4;
            dataGridViewCart.CellContentClick += dataGridViewCart_CellContentClick;
            // 
            // dataGridViewTextBoxColumn1
            // 
            dataGridViewTextBoxColumn1.MinimumWidth = 6;
            dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            // 
            // dataGridViewTextBoxColumn2
            // 
            dataGridViewTextBoxColumn2.MinimumWidth = 6;
            dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            // 
            // dataGridViewTextBoxColumn3
            // 
            dataGridViewTextBoxColumn3.MinimumWidth = 6;
            dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            // 
            // dataGridViewTextBoxColumn4
            // 
            dataGridViewTextBoxColumn4.MinimumWidth = 6;
            dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            // 
            // dataGridViewTextBoxColumn5
            // 
            dataGridViewTextBoxColumn5.MinimumWidth = 6;
            dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            // 
            // dataGridViewTextBoxColumn6
            // 
            dataGridViewTextBoxColumn6.MinimumWidth = 6;
            dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            // 
            // dataGridViewButtonColumn1
            // 
            dataGridViewButtonColumn1.MinimumWidth = 6;
            dataGridViewButtonColumn1.Name = "dataGridViewButtonColumn1";
            // 
            // guna2HtmlLabelTotal
            // 
            guna2HtmlLabelTotal.BackColor = Color.Transparent;
            guna2HtmlLabelTotal.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            guna2HtmlLabelTotal.Location = new Point(367, 340);
            guna2HtmlLabelTotal.Name = "guna2HtmlLabelTotal";
            guna2HtmlLabelTotal.Size = new Size(39, 19);
            guna2HtmlLabelTotal.TabIndex = 3;
            guna2HtmlLabelTotal.Text = "Total:";
            // 
            // textBoxTotal
            // 
            textBoxTotal.CustomizableEdges = customizableEdges1;
            textBoxTotal.DefaultText = "";
            textBoxTotal.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            textBoxTotal.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            textBoxTotal.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            textBoxTotal.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            textBoxTotal.Enabled = false;
            textBoxTotal.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            textBoxTotal.Font = new Font("Segoe UI", 9F);
            textBoxTotal.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            textBoxTotal.Location = new Point(467, 340);
            textBoxTotal.Name = "textBoxTotal";
            textBoxTotal.PlaceholderText = "";
            textBoxTotal.SelectedText = "";
            textBoxTotal.ShadowDecoration.CustomizableEdges = customizableEdges2;
            textBoxTotal.Size = new Size(150, 36);
            textBoxTotal.TabIndex = 2;
            // 
            // btnUpdate
            // 
            btnUpdate.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnUpdate.CustomizableEdges = customizableEdges3;
            btnUpdate.DisabledState.BorderColor = Color.DarkGray;
            btnUpdate.DisabledState.CustomBorderColor = Color.DarkGray;
            btnUpdate.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnUpdate.DisabledState.FillColor2 = Color.FromArgb(169, 169, 169);
            btnUpdate.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnUpdate.FillColor2 = Color.Black;
            btnUpdate.Font = new Font("Segoe UI", 12.75F, FontStyle.Bold);
            btnUpdate.ForeColor = Color.White;
            btnUpdate.Location = new Point(293, 393);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.RightToLeft = RightToLeft.No;
            btnUpdate.ShadowDecoration.CustomizableEdges = customizableEdges4;
            btnUpdate.Size = new Size(159, 43);
            btnUpdate.TabIndex = 1;
            btnUpdate.Text = "Update";
            btnUpdate.Click += btnUpdate_Click;
            // 
            // btnCheckout
            // 
            btnCheckout.CustomizableEdges = customizableEdges5;
            btnCheckout.DisabledState.BorderColor = Color.DarkGray;
            btnCheckout.DisabledState.CustomBorderColor = Color.DarkGray;
            btnCheckout.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnCheckout.DisabledState.FillColor2 = Color.FromArgb(169, 169, 169);
            btnCheckout.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnCheckout.FillColor2 = Color.Black;
            btnCheckout.Font = new Font("Segoe UI", 12.75F, FontStyle.Bold);
            btnCheckout.ForeColor = Color.White;
            btnCheckout.Location = new Point(458, 393);
            btnCheckout.Name = "btnCheckout";
            btnCheckout.ShadowDecoration.CustomizableEdges = customizableEdges6;
            btnCheckout.Size = new Size(159, 43);
            btnCheckout.TabIndex = 0;
            btnCheckout.Text = "Checkout";
            btnCheckout.Click += btnCheckout_Click;
            // 
            // guna2CustomGradientPanel
            // 
            guna2CustomGradientPanel.Controls.Add(guna2CircleButtonClose);
            guna2CustomGradientPanel.Controls.Add(guna2CircleButtonMinimize);
            guna2CustomGradientPanel.Controls.Add(dataGridViewCart);
            guna2CustomGradientPanel.Controls.Add(guna2CircleButtonMaximize);
            guna2CustomGradientPanel.Controls.Add(guna2HtmlLabelTotal);
            guna2CustomGradientPanel.Controls.Add(textBoxTotal);
            guna2CustomGradientPanel.Controls.Add(btnUpdate);
            guna2CustomGradientPanel.Controls.Add(btnCheckout);
            guna2CustomGradientPanel.CustomizableEdges = customizableEdges9;
            guna2CustomGradientPanel.FillColor = SystemColors.InactiveCaption;
            guna2CustomGradientPanel.FillColor2 = SystemColors.MenuText;
            guna2CustomGradientPanel.FillColor3 = Color.DarkSlateGray;
            guna2CustomGradientPanel.Location = new Point(0, 0);
            guna2CustomGradientPanel.Name = "guna2CustomGradientPanel";
            guna2CustomGradientPanel.ShadowDecoration.CustomizableEdges = customizableEdges10;
            guna2CustomGradientPanel.Size = new Size(1132, 535);
            guna2CustomGradientPanel.TabIndex = 5;
            guna2CustomGradientPanel.Paint += guna2CircleButtonClose_Click;
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
            guna2CircleButtonClose.Location = new Point(955, 3);
            guna2CircleButtonClose.Name = "guna2CircleButtonClose";
            guna2CircleButtonClose.ShadowDecoration.CustomizableEdges = customizableEdges7;
            guna2CircleButtonClose.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            guna2CircleButtonClose.Size = new Size(16, 17);
            guna2CircleButtonClose.TabIndex = 6;
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
            guna2CircleButtonMinimize.FillColor = Color.Orange;
            guna2CircleButtonMinimize.Font = new Font("Segoe UI", 9F);
            guna2CircleButtonMinimize.ForeColor = Color.White;
            guna2CircleButtonMinimize.Location = new Point(917, 3);
            guna2CircleButtonMinimize.Name = "guna2CircleButtonMinimize";
            guna2CircleButtonMinimize.ShadowDecoration.CustomizableEdges = customizableEdges8;
            guna2CircleButtonMinimize.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            guna2CircleButtonMinimize.Size = new Size(16, 17);
            guna2CircleButtonMinimize.TabIndex = 7;
            guna2CircleButtonMinimize.Text = "-";
            // 
            // guna2CircleButtonMaximize
            // 
            guna2CircleButtonMaximize.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            guna2CircleButtonMaximize.DisabledState.BorderColor = Color.DarkGray;
            guna2CircleButtonMaximize.DisabledState.CustomBorderColor = Color.DarkGray;
            guna2CircleButtonMaximize.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            guna2CircleButtonMaximize.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            guna2CircleButtonMaximize.FillColor = Color.ForestGreen;
            guna2CircleButtonMaximize.Font = new Font("Segoe UI", 9F);
            guna2CircleButtonMaximize.ForeColor = Color.White;
            guna2CircleButtonMaximize.Location = new Point(936, 3);
            guna2CircleButtonMaximize.Name = "guna2CircleButtonMaximize";
            guna2CircleButtonMaximize.ShadowDecoration.CustomizableEdges = customizableEdges8;
            guna2CircleButtonMaximize.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            guna2CircleButtonMaximize.Size = new Size(16, 17);
            guna2CircleButtonMaximize.TabIndex = 8;
            guna2CircleButtonMaximize.Text = "□";
            // 
            // CartForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(993, 527);
            Controls.Add(guna2CustomGradientPanel);
            FormBorderStyle = FormBorderStyle.None;
            Name = "CartForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Shopping Cart";
            Load += CartForm_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridViewCart).EndInit();
            guna2CustomGradientPanel.ResumeLayout(false);
            guna2CustomGradientPanel.PerformLayout();
            ResumeLayout(false);
        }

        private System.Windows.Forms.DataGridView dataGridViewCart;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabelTotal;
        private Guna.UI2.WinForms.Guna2TextBox textBoxTotal;
        private Guna.UI2.WinForms.Guna2GradientButton btnUpdate;
        private Guna.UI2.WinForms.Guna2GradientButton btnCheckout;
        private Guna.UI2.WinForms.Guna2CustomGradientPanel guna2CustomGradientPanel;
        private Guna.UI2.WinForms.Guna2CircleButton guna2CircleButtonClose;
        private Guna.UI2.WinForms.Guna2CircleButton guna2CircleButtonMinimize;
        private Guna.UI2.WinForms.Guna2CircleButton guna2CircleButtonMaximize;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private DataGridViewButtonColumn dataGridViewButtonColumn1;
    }
}