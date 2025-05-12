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
            pnl_sideBarClient = new Panel();
            MyCartbtn = new Button();
            pictureBox3 = new PictureBox();
            Profilebtn = new Button();
            pictureBox5 = new PictureBox();
            MyOrderbtn = new Button();
            pictureBox2 = new PictureBox();
            ClientDashboardbtn = new Button();
            pictureBox1 = new PictureBox();
            flowLayoutPanel8 = new FlowLayoutPanel();
            logoutbutton = new Button();
            logoutpicture = new PictureBox();
            usrpicture = new PictureBox();
            lbl_UserName = new Label();
            pnl_sideBarClient.SuspendLayout();
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
            pnl_sideBarClient.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            pnl_sideBarClient.BackColor = Color.FromArgb(80, 110, 160);
            pnl_sideBarClient.Controls.Add(MyCartbtn);
            pnl_sideBarClient.Controls.Add(pictureBox3);
            pnl_sideBarClient.Controls.Add(Profilebtn);
            pnl_sideBarClient.Controls.Add(pictureBox5);
            pnl_sideBarClient.Controls.Add(MyOrderbtn);
            pnl_sideBarClient.Controls.Add(pictureBox2);
            pnl_sideBarClient.Controls.Add(ClientDashboardbtn);
            pnl_sideBarClient.Controls.Add(pictureBox1);
            pnl_sideBarClient.Controls.Add(flowLayoutPanel8);
            pnl_sideBarClient.Controls.Add(logoutbutton);
            pnl_sideBarClient.Controls.Add(logoutpicture);
            pnl_sideBarClient.Controls.Add(usrpicture);
            pnl_sideBarClient.Controls.Add(lbl_UserName);
            pnl_sideBarClient.Location = new Point(12, 26);
            pnl_sideBarClient.Margin = new Padding(7, 6, 7, 6);
            pnl_sideBarClient.Name = "pnl_sideBarClient";
            pnl_sideBarClient.Size = new Size(283, 488);
            pnl_sideBarClient.TabIndex = 0;
            pnl_sideBarClient.Paint += pnl_sideBarClient_Paint;
            // 
            // MyCartbtn
            // 
            MyCartbtn.BackColor = Color.Transparent;
            MyCartbtn.Cursor = Cursors.Hand;
            MyCartbtn.FlatAppearance.BorderSize = 0;
            MyCartbtn.FlatStyle = FlatStyle.Flat;
            MyCartbtn.Font = new Font("Microsoft Sans Serif", 11F, FontStyle.Italic);
            MyCartbtn.ForeColor = Color.White;
            MyCartbtn.Location = new Point(47, 250);
            MyCartbtn.Margin = new Padding(3, 2, 3, 2);
            MyCartbtn.Name = "MyCartbtn";
            MyCartbtn.Size = new Size(195, 30);
            MyCartbtn.TabIndex = 20;
            MyCartbtn.Text = "My Cart  ";
            MyCartbtn.TextAlign = ContentAlignment.MiddleLeft;
            MyCartbtn.UseVisualStyleBackColor = false;
            // 
            // pictureBox3
            // 
            pictureBox3.BackColor = Color.Transparent;
            pictureBox3.Image = (Image)resources.GetObject("pictureBox3.Image");
            pictureBox3.Location = new Point(7, 250);
            pictureBox3.Margin = new Padding(3, 2, 3, 2);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(35, 26);
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
            Profilebtn.Font = new Font("Microsoft Sans Serif", 11F, FontStyle.Italic);
            Profilebtn.ForeColor = Color.White;
            Profilebtn.Location = new Point(47, 300);
            Profilebtn.Margin = new Padding(3, 2, 3, 2);
            Profilebtn.Name = "Profilebtn";
            Profilebtn.Size = new Size(195, 30);
            Profilebtn.TabIndex = 18;
            Profilebtn.Text = "Profile   ";
            Profilebtn.TextAlign = ContentAlignment.MiddleLeft;
            Profilebtn.UseVisualStyleBackColor = false;
            // 
            // pictureBox5
            // 
            pictureBox5.BackColor = Color.Transparent;
            pictureBox5.Image = (Image)resources.GetObject("pictureBox5.Image");
            pictureBox5.Location = new Point(7, 300);
            pictureBox5.Margin = new Padding(3, 2, 3, 2);
            pictureBox5.Name = "pictureBox5";
            pictureBox5.Size = new Size(35, 26);
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
            MyOrderbtn.Font = new Font("Microsoft Sans Serif", 11F, FontStyle.Italic);
            MyOrderbtn.ForeColor = Color.White;
            MyOrderbtn.Location = new Point(47, 204);
            MyOrderbtn.Margin = new Padding(3, 2, 3, 2);
            MyOrderbtn.Name = "MyOrderbtn";
            MyOrderbtn.Size = new Size(206, 30);
            MyOrderbtn.TabIndex = 12;
            MyOrderbtn.Text = "My Orders ";
            MyOrderbtn.TextAlign = ContentAlignment.MiddleLeft;
            MyOrderbtn.UseVisualStyleBackColor = false;
            // 
            // pictureBox2
            // 
            pictureBox2.BackColor = Color.Transparent;
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(7, 204);
            pictureBox2.Margin = new Padding(3, 2, 3, 2);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(35, 26);
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.TabIndex = 13;
            pictureBox2.TabStop = false;
            // 
            // ClientDashboardbtn
            // 
            ClientDashboardbtn.BackColor = Color.Transparent;
            ClientDashboardbtn.Cursor = Cursors.Hand;
            ClientDashboardbtn.FlatAppearance.BorderSize = 0;
            ClientDashboardbtn.FlatStyle = FlatStyle.Flat;
            ClientDashboardbtn.Font = new Font("Microsoft Sans Serif", 11F, FontStyle.Italic);
            ClientDashboardbtn.ForeColor = Color.White;
            ClientDashboardbtn.Location = new Point(47, 157);
            ClientDashboardbtn.Margin = new Padding(3, 2, 3, 2);
            ClientDashboardbtn.Name = "ClientDashboardbtn";
            ClientDashboardbtn.Size = new Size(185, 30);
            ClientDashboardbtn.TabIndex = 10;
            ClientDashboardbtn.Text = "Dashboard ";
            ClientDashboardbtn.TextAlign = ContentAlignment.MiddleLeft;
            ClientDashboardbtn.UseVisualStyleBackColor = false;
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.Transparent;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(7, 157);
            pictureBox1.Margin = new Padding(3, 2, 3, 2);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(35, 26);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 11;
            pictureBox1.TabStop = false;
            // 
            // flowLayoutPanel8
            // 
            flowLayoutPanel8.BackColor = Color.WhiteSmoke;
            flowLayoutPanel8.Location = new Point(0, 130);
            flowLayoutPanel8.Margin = new Padding(3, 2, 3, 2);
            flowLayoutPanel8.Name = "flowLayoutPanel8";
            flowLayoutPanel8.Size = new Size(288, 8);
            flowLayoutPanel8.TabIndex = 7;
            // 
            // logoutbutton
            // 
            logoutbutton.BackColor = Color.Transparent;
            logoutbutton.Cursor = Cursors.Hand;
            logoutbutton.FlatAppearance.BorderSize = 0;
            logoutbutton.FlatStyle = FlatStyle.Flat;
            logoutbutton.Font = new Font("Microsoft Sans Serif", 11F, FontStyle.Italic);
            logoutbutton.ForeColor = Color.White;
            logoutbutton.Location = new Point(47, 339);
            logoutbutton.Margin = new Padding(3, 2, 3, 2);
            logoutbutton.Name = "logoutbutton";
            logoutbutton.Size = new Size(195, 30);
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
            logoutpicture.Location = new Point(7, 339);
            logoutpicture.Margin = new Padding(3, 2, 3, 2);
            logoutpicture.Name = "logoutpicture";
            logoutpicture.Size = new Size(35, 26);
            logoutpicture.SizeMode = PictureBoxSizeMode.StretchImage;
            logoutpicture.TabIndex = 1;
            logoutpicture.TabStop = false;
            logoutpicture.Click += logoutpicture_Click;
            // 
            // usrpicture
            // 
            usrpicture.BackColor = Color.Transparent;
            usrpicture.Image = (Image)resources.GetObject("usrpicture.Image");
            usrpicture.Location = new Point(24, 37);
            usrpicture.Margin = new Padding(3, 2, 3, 2);
            usrpicture.Name = "usrpicture";
            usrpicture.Size = new Size(64, 54);
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
            lbl_UserName.Location = new Point(93, 37);
            lbl_UserName.Name = "lbl_UserName";
            lbl_UserName.Size = new Size(137, 68);
            lbl_UserName.TabIndex = 9;
            lbl_UserName.Text = "Welcome  \r\n  ";
            lbl_UserName.Click += lbl_employeeName_Click;
            // 
            // Dashboard
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1132, 535);
            Controls.Add(pnl_sideBarClient);
            Margin = new Padding(3, 2, 3, 2);
            Name = "Dashboard";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Dashboard";
            Load += Dashboard_Load;
            pnl_sideBarClient.ResumeLayout(false);
            pnl_sideBarClient.PerformLayout();
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
