using E_commerce.Presentation.CustomControls;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Printing;
using System.Windows.Forms;

namespace E_commerce.Presentation
{
    public partial class Dashboard : Form
    {
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Dashboard));
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
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
            roundedPanel1 = new RoundedPanel();
            PPProundedPanel3 = new RoundedPanel();
            button2 = new Button();
            ChangePassword = new Button();
            customTextBox29 = new CustomTextBox2();
            customTextBox210 = new CustomTextBox2();
            label11 = new Label();
            customTextBox211 = new CustomTextBox2();
            label10 = new Label();
            label9 = new Label();
            DDDroundedPanel2 = new RoundedPanel();
            customTextBox212 = new CustomTextBox2();
            label12 = new Label();
            button3 = new Button();
            button1 = new Button();
            customTextBox26 = new CustomTextBox2();
            customTextBox28 = new CustomTextBox2();
            customTextBox27 = new CustomTextBox2();
            label8 = new Label();
            label7 = new Label();
            label6 = new Label();
            INFOroundedPanel2 = new RoundedPanel();
            customTextBox25 = new CustomTextBox2();
            customTextBox24 = new CustomTextBox2();
            customTextBox23 = new CustomTextBox2();
            customTextBox22 = new CustomTextBox2();
            customTextBox21 = new CustomTextBox2();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            Pinfo = new Label();
            flowLayoutPanel1 = new FlowLayoutPanel();
            SearchTextBox = new Guna.UI2.WinForms.Guna2TextBox();
            pnl_sideBarClient.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox5).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)logoutpicture).BeginInit();
            ((System.ComponentModel.ISupportInitialize)usrpicture).BeginInit();
            roundedPanel1.SuspendLayout();
            PPProundedPanel3.SuspendLayout();
            DDDroundedPanel2.SuspendLayout();
            INFOroundedPanel2.SuspendLayout();
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
            pnl_sideBarClient.Location = new Point(12, 30);
            pnl_sideBarClient.Margin = new Padding(7, 6, 7, 6);
            pnl_sideBarClient.Name = "pnl_sideBarClient";
            pnl_sideBarClient.Size = new Size(283, 571);
            pnl_sideBarClient.TabIndex = 0;
            // 
            // MyCartbtn
            // 
            MyCartbtn.BackColor = Color.Transparent;
            MyCartbtn.Cursor = Cursors.Hand;
            MyCartbtn.FlatAppearance.BorderSize = 0;
            MyCartbtn.FlatStyle = FlatStyle.Flat;
            MyCartbtn.Font = new Font("Arial Rounded MT Bold", 11F, FontStyle.Italic);
            MyCartbtn.ForeColor = Color.White;
            MyCartbtn.Location = new Point(47, 242);
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
            pictureBox3.Location = new Point(7, 242);
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
            Profilebtn.Font = new Font("Arial Rounded MT Bold", 11F, FontStyle.Italic);
            Profilebtn.ForeColor = Color.White;
            Profilebtn.Location = new Point(47, 287);
            Profilebtn.Margin = new Padding(3, 2, 3, 2);
            Profilebtn.Name = "Profilebtn";
            Profilebtn.Size = new Size(195, 30);
            Profilebtn.TabIndex = 18;
            Profilebtn.Text = "Profile   ";
            Profilebtn.TextAlign = ContentAlignment.MiddleLeft;
            Profilebtn.UseVisualStyleBackColor = false;
            Profilebtn.Click += Profilebtn_Click;
            // 
            // pictureBox5
            // 
            pictureBox5.BackColor = Color.Transparent;
            pictureBox5.Image = (Image)resources.GetObject("pictureBox5.Image");
            pictureBox5.Location = new Point(7, 287);
            pictureBox5.Margin = new Padding(3, 2, 3, 2);
            pictureBox5.Name = "pictureBox5";
            pictureBox5.Size = new Size(35, 26);
            pictureBox5.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox5.TabIndex = 19;
            pictureBox5.TabStop = false;
            pictureBox5.Click += pictureBox5_Click;
            // 
            // MyOrderbtn
            // 
            MyOrderbtn.BackColor = Color.Transparent;
            MyOrderbtn.Cursor = Cursors.Hand;
            MyOrderbtn.FlatAppearance.BorderSize = 0;
            MyOrderbtn.FlatStyle = FlatStyle.Flat;
            MyOrderbtn.Font = new Font("Arial Rounded MT Bold", 11F, FontStyle.Italic);
            MyOrderbtn.ForeColor = Color.White;
            MyOrderbtn.Location = new Point(47, 197);
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
            pictureBox2.Location = new Point(7, 197);
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
            ClientDashboardbtn.Font = new Font("Arial Rounded MT Bold", 11F, FontStyle.Italic);
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
            logoutbutton.Font = new Font("Arial Rounded MT Bold", 11F, FontStyle.Italic);
            logoutbutton.ForeColor = Color.White;
            logoutbutton.Location = new Point(47, 326);
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
            logoutpicture.Location = new Point(7, 326);
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
            // roundedPanel1
            // 
            roundedPanel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            roundedPanel1.BackColor = Color.FromArgb(80, 110, 160);
            roundedPanel1.Controls.Add(PPProundedPanel3);
            roundedPanel1.Controls.Add(DDDroundedPanel2);
            roundedPanel1.Controls.Add(INFOroundedPanel2);
            roundedPanel1.CornerRadius = 30;
            roundedPanel1.Location = new Point(332, 67);
            roundedPanel1.Margin = new Padding(3, 2, 3, 2);
            roundedPanel1.Name = "roundedPanel1";
            roundedPanel1.Size = new Size(1191, 571);
            roundedPanel1.TabIndex = 1;
            roundedPanel1.Paint += roundedPanel1_Paint_1;
            // 
            // PPProundedPanel3
            // 
            PPProundedPanel3.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            PPProundedPanel3.BackColor = Color.FromArgb(224, 224, 224);
            PPProundedPanel3.Controls.Add(button2);
            PPProundedPanel3.Controls.Add(ChangePassword);
            PPProundedPanel3.Controls.Add(customTextBox29);
            PPProundedPanel3.Controls.Add(customTextBox210);
            PPProundedPanel3.Controls.Add(label11);
            PPProundedPanel3.Controls.Add(customTextBox211);
            PPProundedPanel3.Controls.Add(label10);
            PPProundedPanel3.Controls.Add(label9);
            PPProundedPanel3.CornerRadius = 30;
            PPProundedPanel3.Location = new Point(552, 308);
            PPProundedPanel3.Margin = new Padding(3, 2, 3, 2);
            PPProundedPanel3.Name = "PPProundedPanel3";
            PPProundedPanel3.Size = new Size(584, 239);
            PPProundedPanel3.TabIndex = 2;
            PPProundedPanel3.Paint += PPProundedPanel3_Paint_1;
            // 
            // button2
            // 
            button2.Location = new Point(406, 160);
            button2.Margin = new Padding(3, 2, 3, 2);
            button2.Name = "button2";
            button2.Size = new Size(84, 32);
            button2.TabIndex = 21;
            button2.Text = "Clear";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click_1;
            // 
            // ChangePassword
            // 
            ChangePassword.Location = new Point(172, 160);
            ChangePassword.Margin = new Padding(3, 2, 3, 2);
            ChangePassword.Name = "ChangePassword";
            ChangePassword.Size = new Size(84, 32);
            ChangePassword.TabIndex = 20;
            ChangePassword.Text = "Save";
            ChangePassword.UseVisualStyleBackColor = true;
            ChangePassword.Click += ChangePassword_Click;
            // 
            // customTextBox29
            // 
            customTextBox29.BackColor = Color.White;
            customTextBox29.BorderColor = Color.FromArgb(181, 191, 249);
            customTextBox29.BorderFocusColor = Color.FromArgb(181, 191, 249);
            customTextBox29.BorderSize = 1;
            customTextBox29.CornerRadius = 8;
            customTextBox29.ForeColor = Color.FromArgb(38, 32, 59);
            customTextBox29.Location = new Point(154, 92);
            customTextBox29.Multiline = false;
            customTextBox29.Name = "customTextBox29";
            customTextBox29.Padding = new Padding(11, 10, 11, 10);
            customTextBox29.PasswordChar = false;
            customTextBox29.Size = new Size(350, 30);
            customTextBox29.TabIndex = 23;
            customTextBox29.TextAlign = HorizontalAlignment.Left;
            customTextBox29.UnderlinedStyle = false;
            // 
            // customTextBox210
            // 
            customTextBox210.BackColor = Color.White;
            customTextBox210.BorderColor = Color.FromArgb(181, 191, 249);
            customTextBox210.BorderFocusColor = Color.FromArgb(181, 191, 249);
            customTextBox210.BorderSize = 1;
            customTextBox210.CornerRadius = 8;
            customTextBox210.ForeColor = Color.FromArgb(38, 32, 59);
            customTextBox210.Location = new Point(154, 12);
            customTextBox210.Multiline = false;
            customTextBox210.Name = "customTextBox210";
            customTextBox210.Padding = new Padding(11, 10, 11, 10);
            customTextBox210.PasswordChar = false;
            customTextBox210.Size = new Size(350, 30);
            customTextBox210.TabIndex = 21;
            customTextBox210.TextAlign = HorizontalAlignment.Left;
            customTextBox210.UnderlinedStyle = false;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Sylfaen", 12F, FontStyle.Italic);
            label11.Location = new Point(13, 92);
            label11.Name = "label11";
            label11.Size = new Size(99, 44);
            label11.TabIndex = 20;
            label11.Text = "Confirm New\r\n      Password";
            label11.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // customTextBox211
            // 
            customTextBox211.BackColor = Color.White;
            customTextBox211.BorderColor = Color.FromArgb(181, 191, 249);
            customTextBox211.BorderFocusColor = Color.FromArgb(181, 191, 249);
            customTextBox211.BorderSize = 1;
            customTextBox211.CornerRadius = 8;
            customTextBox211.ForeColor = Color.FromArgb(38, 32, 59);
            customTextBox211.Location = new Point(154, 54);
            customTextBox211.Multiline = false;
            customTextBox211.Name = "customTextBox211";
            customTextBox211.Padding = new Padding(11, 10, 11, 10);
            customTextBox211.PasswordChar = false;
            customTextBox211.Size = new Size(350, 30);
            customTextBox211.TabIndex = 22;
            customTextBox211.TextAlign = HorizontalAlignment.Left;
            customTextBox211.UnderlinedStyle = false;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Sylfaen", 12F, FontStyle.Italic);
            label10.Location = new Point(13, 60);
            label10.Name = "label10";
            label10.Size = new Size(107, 22);
            label10.TabIndex = 19;
            label10.Text = "New Password";
            label10.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Sylfaen", 12F, FontStyle.Italic);
            label9.Location = new Point(13, 16);
            label9.Name = "label9";
            label9.Size = new Size(101, 22);
            label9.TabIndex = 18;
            label9.Text = "Old Password";
            label9.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // DDDroundedPanel2
            // 
            DDDroundedPanel2.BackColor = Color.FromArgb(224, 224, 224);
            DDDroundedPanel2.Controls.Add(customTextBox212);
            DDDroundedPanel2.Controls.Add(label12);
            DDDroundedPanel2.Controls.Add(button3);
            DDDroundedPanel2.Controls.Add(button1);
            DDDroundedPanel2.Controls.Add(customTextBox26);
            DDDroundedPanel2.Controls.Add(customTextBox28);
            DDDroundedPanel2.Controls.Add(customTextBox27);
            DDDroundedPanel2.Controls.Add(label8);
            DDDroundedPanel2.Controls.Add(label7);
            DDDroundedPanel2.Controls.Add(label6);
            DDDroundedPanel2.CornerRadius = 30;
            DDDroundedPanel2.Location = new Point(62, 309);
            DDDroundedPanel2.Margin = new Padding(3, 2, 3, 2);
            DDDroundedPanel2.Name = "DDDroundedPanel2";
            DDDroundedPanel2.Size = new Size(525, 238);
            DDDroundedPanel2.TabIndex = 1;
            DDDroundedPanel2.Paint += DDDroundedPanel2_Paint;
            // 
            // customTextBox212
            // 
            customTextBox212.BackColor = Color.White;
            customTextBox212.BorderColor = Color.FromArgb(181, 191, 249);
            customTextBox212.BorderFocusColor = Color.FromArgb(181, 191, 249);
            customTextBox212.BorderSize = 1;
            customTextBox212.CornerRadius = 8;
            customTextBox212.ForeColor = Color.FromArgb(38, 32, 59);
            customTextBox212.Location = new Point(348, 15);
            customTextBox212.Multiline = false;
            customTextBox212.Name = "customTextBox212";
            customTextBox212.Padding = new Padding(11, 10, 11, 10);
            customTextBox212.PasswordChar = false;
            customTextBox212.Size = new Size(122, 30);
            customTextBox212.TabIndex = 21;
            customTextBox212.TextAlign = HorizontalAlignment.Left;
            customTextBox212.UnderlinedStyle = false;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Sylfaen", 12F, FontStyle.Italic);
            label12.Location = new Point(245, 22);
            label12.Name = "label12";
            label12.Size = new Size(84, 22);
            label12.TabIndex = 20;
            label12.Text = "Last Name ";
            label12.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // button3
            // 
            button3.Location = new Point(362, 160);
            button3.Margin = new Padding(3, 2, 3, 2);
            button3.Name = "button3";
            button3.Size = new Size(84, 32);
            button3.TabIndex = 19;
            button3.Text = "Clear";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // button1
            // 
            button1.Location = new Point(128, 160);
            button1.Margin = new Padding(3, 2, 3, 2);
            button1.Name = "button1";
            button1.Size = new Size(84, 32);
            button1.TabIndex = 18;
            button1.Text = "Save";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click_1;
            // 
            // customTextBox26
            // 
            customTextBox26.BackColor = Color.White;
            customTextBox26.BorderColor = Color.FromArgb(181, 191, 249);
            customTextBox26.BorderFocusColor = Color.FromArgb(181, 191, 249);
            customTextBox26.BorderSize = 1;
            customTextBox26.CornerRadius = 8;
            customTextBox26.ForeColor = Color.FromArgb(38, 32, 59);
            customTextBox26.Location = new Point(120, 95);
            customTextBox26.Multiline = false;
            customTextBox26.Name = "customTextBox26";
            customTextBox26.Padding = new Padding(11, 10, 11, 10);
            customTextBox26.PasswordChar = false;
            customTextBox26.Size = new Size(350, 30);
            customTextBox26.TabIndex = 17;
            customTextBox26.TextAlign = HorizontalAlignment.Left;
            customTextBox26.UnderlinedStyle = false;
            // 
            // customTextBox28
            // 
            customTextBox28.BackColor = Color.White;
            customTextBox28.BorderColor = Color.FromArgb(181, 191, 249);
            customTextBox28.BorderFocusColor = Color.FromArgb(181, 191, 249);
            customTextBox28.BorderSize = 1;
            customTextBox28.CornerRadius = 8;
            customTextBox28.ForeColor = Color.FromArgb(38, 32, 59);
            customTextBox28.Location = new Point(120, 15);
            customTextBox28.Multiline = false;
            customTextBox28.Name = "customTextBox28";
            customTextBox28.Padding = new Padding(11, 10, 11, 10);
            customTextBox28.PasswordChar = false;
            customTextBox28.Size = new Size(120, 30);
            customTextBox28.TabIndex = 15;
            customTextBox28.TextAlign = HorizontalAlignment.Left;
            customTextBox28.UnderlinedStyle = false;
            // 
            // customTextBox27
            // 
            customTextBox27.BackColor = Color.White;
            customTextBox27.BorderColor = Color.FromArgb(181, 191, 249);
            customTextBox27.BorderFocusColor = Color.FromArgb(181, 191, 249);
            customTextBox27.BorderSize = 1;
            customTextBox27.CornerRadius = 8;
            customTextBox27.ForeColor = Color.FromArgb(38, 32, 59);
            customTextBox27.Location = new Point(120, 57);
            customTextBox27.Multiline = false;
            customTextBox27.Name = "customTextBox27";
            customTextBox27.Padding = new Padding(11, 10, 11, 10);
            customTextBox27.PasswordChar = false;
            customTextBox27.Size = new Size(350, 30);
            customTextBox27.TabIndex = 16;
            customTextBox27.TextAlign = HorizontalAlignment.Left;
            customTextBox27.UnderlinedStyle = false;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Sylfaen", 12F, FontStyle.Italic);
            label8.Location = new Point(19, 22);
            label8.Name = "label8";
            label8.Size = new Size(88, 22);
            label8.TabIndex = 12;
            label8.Text = "First Name ";
            label8.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Sylfaen", 12F, FontStyle.Italic);
            label7.Location = new Point(19, 59);
            label7.Name = "label7";
            label7.Size = new Size(88, 22);
            label7.TabIndex = 13;
            label7.Text = "User Name ";
            label7.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Sylfaen", 12F, FontStyle.Italic);
            label6.Location = new Point(29, 98);
            label6.Name = "label6";
            label6.Size = new Size(61, 22);
            label6.TabIndex = 14;
            label6.Text = "E-Mail ";
            label6.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // INFOroundedPanel2
            // 
            INFOroundedPanel2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            INFOroundedPanel2.BackColor = Color.FromArgb(224, 224, 224);
            INFOroundedPanel2.Controls.Add(customTextBox25);
            INFOroundedPanel2.Controls.Add(customTextBox24);
            INFOroundedPanel2.Controls.Add(customTextBox23);
            INFOroundedPanel2.Controls.Add(customTextBox22);
            INFOroundedPanel2.Controls.Add(customTextBox21);
            INFOroundedPanel2.Controls.Add(label5);
            INFOroundedPanel2.Controls.Add(label4);
            INFOroundedPanel2.Controls.Add(label3);
            INFOroundedPanel2.Controls.Add(label2);
            INFOroundedPanel2.Controls.Add(label1);
            INFOroundedPanel2.Controls.Add(Pinfo);
            INFOroundedPanel2.CornerRadius = 30;
            INFOroundedPanel2.Location = new Point(62, 33);
            INFOroundedPanel2.Margin = new Padding(3, 2, 3, 2);
            INFOroundedPanel2.Name = "INFOroundedPanel2";
            INFOroundedPanel2.Size = new Size(1074, 256);
            INFOroundedPanel2.TabIndex = 0;
            INFOroundedPanel2.Paint += INFOroundedPanel2_Paint;
            // 
            // customTextBox25
            // 
            customTextBox25.BackColor = Color.White;
            customTextBox25.BorderColor = Color.FromArgb(181, 191, 249);
            customTextBox25.BorderFocusColor = Color.FromArgb(181, 191, 249);
            customTextBox25.BorderSize = 1;
            customTextBox25.CornerRadius = 8;
            customTextBox25.ForeColor = Color.FromArgb(38, 32, 59);
            customTextBox25.Location = new Point(131, 161);
            customTextBox25.Multiline = false;
            customTextBox25.Name = "customTextBox25";
            customTextBox25.Padding = new Padding(11, 10, 11, 10);
            customTextBox25.PasswordChar = false;
            customTextBox25.Size = new Size(350, 30);
            customTextBox25.TabIndex = 11;
            customTextBox25.TextAlign = HorizontalAlignment.Left;
            customTextBox25.UnderlinedStyle = false;
            // 
            // customTextBox24
            // 
            customTextBox24.BackColor = Color.White;
            customTextBox24.BorderColor = Color.FromArgb(181, 191, 249);
            customTextBox24.BorderFocusColor = Color.FromArgb(181, 191, 249);
            customTextBox24.BorderSize = 1;
            customTextBox24.CornerRadius = 8;
            customTextBox24.ForeColor = Color.FromArgb(38, 32, 59);
            customTextBox24.Location = new Point(131, 199);
            customTextBox24.Multiline = false;
            customTextBox24.Name = "customTextBox24";
            customTextBox24.Padding = new Padding(11, 10, 11, 10);
            customTextBox24.PasswordChar = false;
            customTextBox24.Size = new Size(350, 30);
            customTextBox24.TabIndex = 10;
            customTextBox24.TextAlign = HorizontalAlignment.Left;
            customTextBox24.UnderlinedStyle = false;
            // 
            // customTextBox23
            // 
            customTextBox23.BackColor = Color.White;
            customTextBox23.BorderColor = Color.FromArgb(181, 191, 249);
            customTextBox23.BorderFocusColor = Color.FromArgb(181, 191, 249);
            customTextBox23.BorderSize = 1;
            customTextBox23.CornerRadius = 8;
            customTextBox23.ForeColor = Color.FromArgb(38, 32, 59);
            customTextBox23.Location = new Point(131, 124);
            customTextBox23.Multiline = false;
            customTextBox23.Name = "customTextBox23";
            customTextBox23.Padding = new Padding(11, 10, 11, 10);
            customTextBox23.PasswordChar = false;
            customTextBox23.Size = new Size(350, 30);
            customTextBox23.TabIndex = 8;
            customTextBox23.TextAlign = HorizontalAlignment.Left;
            customTextBox23.UnderlinedStyle = false;
            customTextBox23._TextChanged += customTextBox23__TextChanged;
            // 
            // customTextBox22
            // 
            customTextBox22.BackColor = Color.White;
            customTextBox22.BorderColor = Color.FromArgb(181, 191, 249);
            customTextBox22.BorderFocusColor = Color.FromArgb(181, 191, 249);
            customTextBox22.BorderSize = 1;
            customTextBox22.CornerRadius = 8;
            customTextBox22.ForeColor = Color.FromArgb(38, 32, 59);
            customTextBox22.Location = new Point(131, 88);
            customTextBox22.Multiline = false;
            customTextBox22.Name = "customTextBox22";
            customTextBox22.Padding = new Padding(11, 10, 11, 10);
            customTextBox22.PasswordChar = false;
            customTextBox22.Size = new Size(350, 30);
            customTextBox22.TabIndex = 7;
            customTextBox22.TextAlign = HorizontalAlignment.Left;
            customTextBox22.UnderlinedStyle = false;
            customTextBox22._TextChanged += customTextBox22__TextChanged;
            // 
            // customTextBox21
            // 
            customTextBox21.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            customTextBox21.BackColor = Color.White;
            customTextBox21.BorderColor = Color.FromArgb(181, 191, 249);
            customTextBox21.BorderFocusColor = Color.FromArgb(181, 191, 249);
            customTextBox21.BorderSize = 1;
            customTextBox21.CornerRadius = 8;
            customTextBox21.ForeColor = Color.FromArgb(38, 32, 59);
            customTextBox21.Location = new Point(131, 51);
            customTextBox21.Multiline = false;
            customTextBox21.Name = "customTextBox21";
            customTextBox21.Padding = new Padding(11, 10, 11, 10);
            customTextBox21.PasswordChar = false;
            customTextBox21.Size = new Size(350, 30);
            customTextBox21.TabIndex = 6;
            customTextBox21.TextAlign = HorizontalAlignment.Left;
            customTextBox21.UnderlinedStyle = false;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Sylfaen", 12F, FontStyle.Italic);
            label5.Location = new Point(35, 199);
            label5.Name = "label5";
            label5.Size = new Size(44, 22);
            label5.TabIndex = 5;
            label5.Text = "Role ";
            label5.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Sylfaen", 12F, FontStyle.Italic);
            label4.Location = new Point(3, 165);
            label4.Name = "label4";
            label4.Size = new Size(111, 22);
            label4.TabIndex = 4;
            label4.Text = "Account Status ";
            label4.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Sylfaen", 12F, FontStyle.Italic);
            label3.Location = new Point(29, 127);
            label3.Name = "label3";
            label3.Size = new Size(61, 22);
            label3.TabIndex = 3;
            label3.Text = "E-Mail ";
            label3.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Sylfaen", 12F, FontStyle.Italic);
            label2.Location = new Point(19, 88);
            label2.Name = "label2";
            label2.Size = new Size(88, 22);
            label2.TabIndex = 2;
            label2.Text = "User Name ";
            label2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Sylfaen", 12F, FontStyle.Italic);
            label1.Location = new Point(19, 51);
            label1.Name = "label1";
            label1.Size = new Size(84, 22);
            label1.TabIndex = 1;
            label1.Text = "Full Name ";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // Pinfo
            // 
            Pinfo.AutoSize = true;
            Pinfo.BackColor = SystemColors.GradientInactiveCaption;
            Pinfo.Font = new Font("Sylfaen", 16.2F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            Pinfo.Location = new Point(3, 4);
            Pinfo.Name = "Pinfo";
            Pinfo.Size = new Size(161, 28);
            Pinfo.TabIndex = 0;
            Pinfo.Text = "Personal Info  ";
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            flowLayoutPanel1.AutoScroll = true;
            flowLayoutPanel1.Location = new Point(329, 63);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(1191, 572);
            flowLayoutPanel1.TabIndex = 10;
            // 
            // SearchTextBox
            // 
            SearchTextBox.CustomizableEdges = customizableEdges1;
            SearchTextBox.DefaultText = "";
            SearchTextBox.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            SearchTextBox.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            SearchTextBox.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            SearchTextBox.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            SearchTextBox.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            SearchTextBox.Font = new Font("Segoe UI", 9F);
            SearchTextBox.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            SearchTextBox.Location = new Point(522, 12);
            SearchTextBox.Name = "SearchTextBox";
            SearchTextBox.PlaceholderText = "Search For Products";
            SearchTextBox.SelectedText = "";
            SearchTextBox.ShadowDecoration.CustomizableEdges = customizableEdges2;
            SearchTextBox.Size = new Size(337, 36);
            SearchTextBox.TabIndex = 11;
            SearchTextBox.TextChanged += SearchTextBox_TextChanged;
            // 
            // Dashboard
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1550, 622);
            Controls.Add(SearchTextBox);
            Controls.Add(flowLayoutPanel1);
            Controls.Add(pnl_sideBarClient);
            Controls.Add(roundedPanel1);
            Margin = new Padding(3, 2, 3, 2);
            Name = "Dashboard";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Dashboard";
            Load += Dashboard_Load;
            Click += Dashboard_Click;
            pnl_sideBarClient.ResumeLayout(false);
            pnl_sideBarClient.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox5).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)logoutpicture).EndInit();
            ((System.ComponentModel.ISupportInitialize)usrpicture).EndInit();
            roundedPanel1.ResumeLayout(false);
            PPProundedPanel3.ResumeLayout(false);
            PPProundedPanel3.PerformLayout();
            DDDroundedPanel2.ResumeLayout(false);
            DDDroundedPanel2.PerformLayout();
            INFOroundedPanel2.ResumeLayout(false);
            INFOroundedPanel2.PerformLayout();
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

        //private void Dashboard_Resize(object sender, EventArgs e)
        //{
        //    roundedPanel1.Location = new Point(pnl_sideBarClient.Width + 20, 35);
        //    roundedPanel1.Size = new Size(this.ClientSize.Width - pnl_sideBarClient.Width - 40, 650);
        //    INFOroundedPanel2.Size = new Size(roundedPanel1.Width - 40, roundedPanel1.Height / 2 - 20);
        //    INFOroundedPanel2.Location = new Point(20, 20);
        //    CProundedPanel4.Size = new Size((roundedPanel1.Width - 60) / 2, roundedPanel1.Height / 2 - 40);
        //    CProundedPanel4.Location = new Point(20, roundedPanel1.Height / 2 + 20);
        //    CDroundedPanel3.Size = new Size((roundedPanel1.Width - 60) / 2, roundedPanel1.Height / 2 - 40);
        //    CDroundedPanel3.Location = new Point((roundedPanel1.Width - 60) / 2 + 40, roundedPanel1.Height / 2 + 20);
        //}



        private void btn_productManagement_Click(object sender, EventArgs e) { }
        private void btn_orderManagement_Click(object sender, EventArgs e) { }
        private void btn_customersManagement_Click(object sender, EventArgs e) { }
        private void btn_categoryManagement_Click(object sender, EventArgs e) { }
        private Panel pnl_sideBarClient;
        private Button MyCartbtn;
        private PictureBox pictureBox3;
        private Button Profilebtn;
        private PictureBox pictureBox5;
        private Button MyOrderbtn;
        private PictureBox pictureBox2;
        private Button ClientDashboardbtn;
        private PictureBox pictureBox1;
        private FlowLayoutPanel flowLayoutPanel8;
        private Button logoutbutton;
        private PictureBox logoutpicture;
        private PictureBox usrpicture;
        private Label lbl_UserName;
        private RoundedPanel roundedPanel1;
        private RoundedPanel INFOroundedPanel2;
        private Label label1;
        private Label Pinfo;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label2;
        private RoundedPanel PPProundedPanel3;
        private RoundedPanel DDDroundedPanel2;
        private CustomControls.CustomTextBox2 customTextBox21;
        private CustomControls.CustomTextBox2 customTextBox23;
        private CustomControls.CustomTextBox2 customTextBox22;
        private CustomControls.CustomTextBox2 customTextBox26;
        private CustomControls.CustomTextBox2 customTextBox28;
        private CustomControls.CustomTextBox2 customTextBox27;
        private Label label8;
        private Label label7;
        private Label label6;
        private CustomControls.CustomTextBox2 customTextBox25;
        private CustomControls.CustomTextBox2 customTextBox24;
        private CustomControls.CustomTextBox2 customTextBox29;
        private CustomControls.CustomTextBox2 customTextBox210;
        private Label label11;
        private CustomControls.CustomTextBox2 customTextBox211;
        private Label label10;
        private Label label9;
        private Button button2;
        private Button ChangePassword;
        private Button button3;
        private Button button1;
        private CustomControls.CustomTextBox2 customTextBox212;
        private Label label12;

        public void MakeReadOnly(CustomControls.CustomTextBox2 customTextBox)
        {
            customTextBox.Enabled = false;
            customTextBox.BorderColor = Color.Transparent;
            customTextBox.BackColor = Color.LightGoldenrodYellow;
            customTextBox.ForeColor = Color.Black;
            customTextBox.Font = new Font(customTextBox.Font, FontStyle.Bold);
            customTextBox.TabStop = false;
            customTextBox.Padding = new Padding(10, 5, 5, 6);

        }
        private FlowLayoutPanel flowLayoutPanel1;
        private Guna.UI2.WinForms.Guna2TextBox SearchTextBox;
    }
}