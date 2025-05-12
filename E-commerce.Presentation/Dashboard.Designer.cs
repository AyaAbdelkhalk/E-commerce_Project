using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace E_commerce.Presentation
{
    public partial class Dashboard : Form
    {
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Dashboard));
            this.pnl_sideBarClient = new Panel();
            MyCartbtn = new Button();
            pictureBox3 = new PictureBox();
            Profilebtn = new Button();
            pictureBox5 = new PictureBox();
            MyOrderbtn = new Button();
            pictureBox2 = new PictureBox();
            this.ClientDashboardbtn = new Button();
            pictureBox1 = new PictureBox();
            flowLayoutPanel8 = new FlowLayoutPanel();
            logoutbutton = new Button();
            logoutpicture = new PictureBox();
            usrpicture = new PictureBox();
            lbl_UserName = new Label();
            this.pnl_sideBarClient.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox5).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)logoutpicture).BeginInit();
            ((System.ComponentModel.ISupportInitialize)usrpicture).BeginInit();
            SuspendLayout();
            // 
            // pnl_sideBarClient
            // 
            this.pnl_sideBarClient.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            this.pnl_sideBarClient.BackColor = Color.FromArgb(80, 110, 160);
            this.pnl_sideBarClient.Controls.Add(MyCartbtn);
            this.pnl_sideBarClient.Controls.Add(pictureBox3);
            this.pnl_sideBarClient.Controls.Add(Profilebtn);
            this.pnl_sideBarClient.Controls.Add(pictureBox5);
            this.pnl_sideBarClient.Controls.Add(MyOrderbtn);
            this.pnl_sideBarClient.Controls.Add(pictureBox2);
            this.pnl_sideBarClient.Controls.Add(this.ClientDashboardbtn);
            this.pnl_sideBarClient.Controls.Add(pictureBox1);
            this.pnl_sideBarClient.Controls.Add(flowLayoutPanel8);
            this.pnl_sideBarClient.Controls.Add(logoutbutton);
            this.pnl_sideBarClient.Controls.Add(logoutpicture);
            this.pnl_sideBarClient.Controls.Add(usrpicture);
            this.pnl_sideBarClient.Controls.Add(lbl_UserName);
            this.pnl_sideBarClient.Location = new Point(14, 35);
            this.pnl_sideBarClient.Margin = new Padding(8);
            this.pnl_sideBarClient.Name = "pnl_sideBarClient";
            this.pnl_sideBarClient.Size = new Size(323, 650);
            this.pnl_sideBarClient.TabIndex = 0;
            // 
            // MyCartbtn
            // 
            MyCartbtn.BackColor = Color.Transparent;
            MyCartbtn.Cursor = Cursors.Hand;
            MyCartbtn.FlatAppearance.BorderSize = 0;
            MyCartbtn.FlatStyle = FlatStyle.Flat;
            MyCartbtn.Font = new Font("Arial Rounded MT Bold", 11F, FontStyle.Italic);
            MyCartbtn.ForeColor = Color.White;
            MyCartbtn.Location = new Point(54, 334);
            MyCartbtn.Name = "MyCartbtn";
            MyCartbtn.Size = new Size(223, 40);
            MyCartbtn.TabIndex = 20;
            MyCartbtn.Text = "My Cart  ";
            MyCartbtn.TextAlign = ContentAlignment.MiddleLeft;
            MyCartbtn.UseVisualStyleBackColor = false;
            // 
            // pictureBox3
            // 
            pictureBox3.BackColor = Color.Transparent;
            pictureBox3.Image = (Image)resources.GetObject("pictureBox3.Image");
            pictureBox3.Location = new Point(8, 334);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(40, 35);
            pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox3.TabIndex = 21;
            pictureBox3.TabStop = false;
            // 
            // Profilebtn
            // 
            Profilebtn.BackColor = Color.Transparent;
            Profilebtn.Cursor = Cursors.Hand;
            Profilebtn.FlatAppearance.BorderSize = 0;
            Profilebtn.FlatStyle = FlatStyle.Flat;
            Profilebtn.Font = new Font("Arial Rounded MT Bold", 11F, FontStyle.Italic);
            Profilebtn.ForeColor = Color.White;
            Profilebtn.Location = new Point(54, 400);
            Profilebtn.Name = "Profilebtn";
            Profilebtn.Size = new Size(223, 40);
            Profilebtn.TabIndex = 18;
            Profilebtn.Text = "Profile   ";
            Profilebtn.TextAlign = ContentAlignment.MiddleLeft;
            Profilebtn.UseVisualStyleBackColor = false;
            // 
            // pictureBox5
            // 
            pictureBox5.BackColor = Color.Transparent;
            pictureBox5.Image = (Image)resources.GetObject("pictureBox5.Image");
            pictureBox5.Location = new Point(8, 400);
            pictureBox5.Name = "pictureBox5";
            pictureBox5.Size = new Size(40, 35);
            pictureBox5.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox5.TabIndex = 19;
            pictureBox5.TabStop = false;
            // 
            // MyOrderbtn
            // 
            MyOrderbtn.BackColor = Color.Transparent;
            MyOrderbtn.Cursor = Cursors.Hand;
            MyOrderbtn.FlatAppearance.BorderSize = 0;
            MyOrderbtn.FlatStyle = FlatStyle.Flat;
            MyOrderbtn.Font = new Font("Arial Rounded MT Bold", 11F, FontStyle.Italic);
            MyOrderbtn.ForeColor = Color.White;
            MyOrderbtn.Location = new Point(54, 272);
            MyOrderbtn.Name = "MyOrderbtn";
            MyOrderbtn.Size = new Size(235, 40);
            MyOrderbtn.TabIndex = 12;
            MyOrderbtn.Text = "My Orders ";
            MyOrderbtn.TextAlign = ContentAlignment.MiddleLeft;
            MyOrderbtn.UseVisualStyleBackColor = false;
            // 
            // pictureBox2
            // 
            pictureBox2.BackColor = Color.Transparent;
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(8, 272);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(40, 35);
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.TabIndex = 13;
            pictureBox2.TabStop = false;
            // 
            // ClientDashboardbtn
            // 
            this.ClientDashboardbtn.BackColor = Color.Transparent;
            this.ClientDashboardbtn.Cursor = Cursors.Hand;
            this.ClientDashboardbtn.FlatAppearance.BorderSize = 0;
            this.ClientDashboardbtn.FlatStyle = FlatStyle.Flat;
            this.ClientDashboardbtn.Font = new Font("Arial Rounded MT Bold", 11F, FontStyle.Italic);
            this.ClientDashboardbtn.ForeColor = Color.White;
            this.ClientDashboardbtn.Location = new Point(54, 209);
            this.ClientDashboardbtn.Name = "ClientDashboardbtn";
            this.ClientDashboardbtn.Size = new Size(211, 40);
            this.ClientDashboardbtn.TabIndex = 10;
            this.ClientDashboardbtn.Text = "Dashboard ";
            this.ClientDashboardbtn.TextAlign = ContentAlignment.MiddleLeft;
            this.ClientDashboardbtn.UseVisualStyleBackColor = false;
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.Transparent;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(8, 209);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(40, 35);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 11;
            pictureBox1.TabStop = false;
            // 
            // flowLayoutPanel8
            // 
            flowLayoutPanel8.BackColor = Color.WhiteSmoke;
            flowLayoutPanel8.Location = new Point(0, 173);
            flowLayoutPanel8.Name = "flowLayoutPanel8";
            flowLayoutPanel8.Size = new Size(329, 10);
            flowLayoutPanel8.TabIndex = 7;
            // 
            // logoutbutton
            // 
            logoutbutton.BackColor = Color.Transparent;
            logoutbutton.Cursor = Cursors.Hand;
            logoutbutton.FlatAppearance.BorderSize = 0;
            logoutbutton.FlatStyle = FlatStyle.Flat;
            logoutbutton.Font = new Font("Arial Rounded MT Bold", 11F, FontStyle.Italic);
            logoutbutton.ForeColor = Color.White;
            logoutbutton.Location = new Point(54, 452);
            logoutbutton.Name = "logoutbutton";
            logoutbutton.Size = new Size(223, 40);
            logoutbutton.TabIndex = 0;
            logoutbutton.Text = "Log Out      ";
            logoutbutton.TextAlign = ContentAlignment.MiddleLeft;
            logoutbutton.UseVisualStyleBackColor = false;
            logoutbutton.Click += logoutbutton_Click;
            // 
            // logoutpicture
            // 
            logoutpicture.BackColor = Color.Transparent;
            logoutpicture.ErrorImage = (Image)resources.GetObject("logoutpicture.ErrorImage");
            logoutpicture.Image = (Image)resources.GetObject("logoutpicture.Image");
            logoutpicture.Location = new Point(8, 452);
            logoutpicture.Name = "logoutpicture";
            logoutpicture.Size = new Size(40, 35);
            logoutpicture.SizeMode = PictureBoxSizeMode.StretchImage;
            logoutpicture.TabIndex = 1;
            logoutpicture.TabStop = false;
            logoutpicture.Click += logoutpicture_Click;
            // 
            // usrpicture
            // 
            usrpicture.BackColor = Color.Transparent;
            usrpicture.Image = (Image)resources.GetObject("usrpicture.Image");
            usrpicture.Location = new Point(28, 49);
            usrpicture.Name = "usrpicture";
            usrpicture.Size = new Size(73, 72);
            usrpicture.SizeMode = PictureBoxSizeMode.StretchImage;
            usrpicture.TabIndex = 2;
            usrpicture.TabStop = false;
            usrpicture.Click += usrpicture_Click;
            // 
            // lbl_UserName
            // 
            lbl_UserName.AutoSize = true;
            lbl_UserName.BackColor = Color.Transparent;
            lbl_UserName.Font = new Font("Comic Sans MS", 18F, FontStyle.Bold | FontStyle.Italic);
            lbl_UserName.ForeColor = Color.White;
            lbl_UserName.Location = new Point(106, 49);
            lbl_UserName.Name = "lbl_UserName";
            lbl_UserName.Size = new Size(171, 84);
            lbl_UserName.TabIndex = 9;
            lbl_UserName.Text = "Welcome  \r\n  ";
            lbl_UserName.Click += lbl_employeeName_Click;
            // 
            // Dashboard
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1294, 713);
            Controls.Add(this.pnl_sideBarClient);
            Name = "Dashboard";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Dashboard";
            Load += Dashboard_Load;
            this.pnl_sideBarClient.ResumeLayout(false);
            this.pnl_sideBarClient.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox5).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)logoutpicture).EndInit();
            ((System.ComponentModel.ISupportInitialize)usrpicture).EndInit();
            ResumeLayout(false);
        }


        private void MakeRoundedPanel(Panel panel, int radius)
        {
            System.Drawing.Drawing2D.GraphicsPath path = new System.Drawing.Drawing2D.GraphicsPath();
            path.AddArc(0, 0, radius, radius, 180, 90);
            path.AddArc(panel.Width - radius, 0, radius, radius, 270, 90);
            path.AddArc(panel.Width - radius, panel.Height - radius, radius, radius, 0, 90);
            path.AddArc(0, panel.Height - radius, radius, radius, 90, 90);
            path.CloseAllFigures();
            panel.Region = new Region(path);
        }

        private void MakeRoundedButton(Button button, int radius)
        {
            System.Drawing.Drawing2D.GraphicsPath path = new System.Drawing.Drawing2D.GraphicsPath();

            path.StartFigure();
            path.AddArc(0, 0, radius, radius, 180, 90);
            path.AddArc(button.Width - radius, 0, radius, radius, 270, 90);
            path.AddArc(button.Width - radius, button.Height - radius, radius, radius, 0, 90);
            path.AddArc(0, button.Height - radius, radius, radius, 90, 90);
            path.CloseFigure();

            button.Region = new Region(path);
        }


        private void btn_productManagement_Click(object sender, EventArgs e) { }
        private void btn_orderManagement_Click(object sender, EventArgs e) { }
        private void btn_customersManagement_Click(object sender, EventArgs e) { }
        private void btn_categoryManagement_Click(object sender, EventArgs e) { }
        private Panel pnl_sideBarClient;
        private Button MyCartbtn;
        private PictureBox pictureBox3;
        private Button Profilebtn;
        private PictureBox pictureBox5;
        private Button categorybtn;
        private PictureBox pictureBox4;
        private Button MyOrderbtn;
        private PictureBox pictureBox2;
        private Button ClientDashboardbtn;
        private PictureBox pictureBox1;
        private FlowLayoutPanel flowLayoutPanel8;
        private Button logoutbutton;
        private PictureBox logoutpicture;
        private PictureBox usrpicture;
        private Label lbl_UserName;
    }
}
