namespace E_commerce.Presentation.CustomControls
{
    partial class SidebarControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SidebarControl));
            pnl_sideBarClient = new RoundedPanel();
            button5 = new Button();
            pictureBox4 = new PictureBox();
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
            ((System.ComponentModel.ISupportInitialize)pictureBox4).BeginInit();
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
            pnl_sideBarClient.AutoSize = true;
            pnl_sideBarClient.BackColor = Color.FromArgb(80, 110, 160);
            pnl_sideBarClient.Controls.Add(button5);
            pnl_sideBarClient.Controls.Add(pictureBox4);
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
            pnl_sideBarClient.CornerRadius = 30;
            pnl_sideBarClient.Location = new Point(14, 44);
            pnl_sideBarClient.Margin = new Padding(8);
            pnl_sideBarClient.Name = "pnl_sideBarClient";
            pnl_sideBarClient.Size = new Size(332, 839);
            pnl_sideBarClient.TabIndex = 1;
            pnl_sideBarClient.Paint += pnl_sideBarClient_Paint;
            // 
            // button5
            // 
            button5.BackColor = Color.Transparent;
            button5.Cursor = Cursors.Hand;
            button5.FlatAppearance.BorderSize = 0;
            button5.FlatStyle = FlatStyle.Flat;
            button5.Font = new Font("Arial Rounded MT Bold", 11F, FontStyle.Italic);
            button5.ForeColor = Color.White;
            button5.Location = new Point(54, 263);
            button5.Name = "button5";
            button5.Size = new Size(211, 40);
            button5.TabIndex = 22;
            button5.Text = "Products ";
            button5.TextAlign = ContentAlignment.MiddleLeft;
            button5.UseVisualStyleBackColor = false;
            button5.Click += button5_Click;
            // 
            // pictureBox4
            // 
            pictureBox4.BackColor = Color.Transparent;
            pictureBox4.Image = (Image)resources.GetObject("pictureBox4.Image");
            pictureBox4.Location = new Point(8, 264);
            pictureBox4.Name = "pictureBox4";
            pictureBox4.Size = new Size(40, 35);
            pictureBox4.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox4.TabIndex = 23;
            pictureBox4.TabStop = false;
            pictureBox4.Click += pictureBox4_Click;
            // 
            // MyCartbtn
            // 
            MyCartbtn.BackColor = Color.Transparent;
            MyCartbtn.Cursor = Cursors.Hand;
            MyCartbtn.FlatAppearance.BorderSize = 0;
            MyCartbtn.FlatStyle = FlatStyle.Flat;
            MyCartbtn.Font = new Font("Arial Rounded MT Bold", 11F, FontStyle.Italic);
            MyCartbtn.ForeColor = Color.White;
            MyCartbtn.Location = new Point(54, 382);
            MyCartbtn.Name = "MyCartbtn";
            MyCartbtn.Size = new Size(223, 40);
            MyCartbtn.TabIndex = 20;
            MyCartbtn.Text = "My Cart  ";
            MyCartbtn.TextAlign = ContentAlignment.MiddleLeft;
            MyCartbtn.UseVisualStyleBackColor = false;
            MyCartbtn.Click += MyCartbtn_Click;
            // 
            // pictureBox3
            // 
            pictureBox3.BackColor = Color.Transparent;
            pictureBox3.Image = (Image)resources.GetObject("pictureBox3.Image");
            pictureBox3.Location = new Point(8, 382);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(40, 35);
            pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox3.TabIndex = 21;
            pictureBox3.TabStop = false;
            pictureBox3.Click += pictureBox3_Click;
            // 
            // Profilebtn
            // 
            Profilebtn.BackColor = Color.Transparent;
            Profilebtn.Cursor = Cursors.Hand;
            Profilebtn.FlatAppearance.BorderSize = 0;
            Profilebtn.FlatStyle = FlatStyle.Flat;
            Profilebtn.Font = new Font("Arial Rounded MT Bold", 11F, FontStyle.Italic);
            Profilebtn.ForeColor = Color.White;
            Profilebtn.Location = new Point(54, 441);
            Profilebtn.Name = "Profilebtn";
            Profilebtn.Size = new Size(223, 40);
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
            pictureBox5.Location = new Point(8, 441);
            pictureBox5.Name = "pictureBox5";
            pictureBox5.Size = new Size(40, 35);
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
            MyOrderbtn.Location = new Point(54, 321);
            MyOrderbtn.Name = "MyOrderbtn";
            MyOrderbtn.Size = new Size(235, 40);
            MyOrderbtn.TabIndex = 12;
            MyOrderbtn.Text = "My Orders ";
            MyOrderbtn.TextAlign = ContentAlignment.MiddleLeft;
            MyOrderbtn.UseVisualStyleBackColor = false;
            MyOrderbtn.Click += MyOrderbtn_Click;
            // 
            // pictureBox2
            // 
            pictureBox2.BackColor = Color.Transparent;
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(8, 321);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(40, 35);
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.TabIndex = 13;
            pictureBox2.TabStop = false;
            pictureBox2.Click += pictureBox2_Click;
            // 
            // ClientDashboardbtn
            // 
            ClientDashboardbtn.BackColor = Color.Transparent;
            ClientDashboardbtn.Cursor = Cursors.Hand;
            ClientDashboardbtn.FlatAppearance.BorderSize = 0;
            ClientDashboardbtn.FlatStyle = FlatStyle.Flat;
            ClientDashboardbtn.Font = new Font("Arial Rounded MT Bold", 11F, FontStyle.Italic);
            ClientDashboardbtn.ForeColor = Color.White;
            ClientDashboardbtn.Location = new Point(54, 209);
            ClientDashboardbtn.Name = "ClientDashboardbtn";
            ClientDashboardbtn.Size = new Size(211, 40);
            ClientDashboardbtn.TabIndex = 10;
            ClientDashboardbtn.Text = "Dashboard ";
            ClientDashboardbtn.TextAlign = ContentAlignment.MiddleLeft;
            ClientDashboardbtn.UseVisualStyleBackColor = false;
            ClientDashboardbtn.Click += ClientDashboardbtn_Click;
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
            pictureBox1.Click += pictureBox1_Click;
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
            logoutbutton.Location = new Point(54, 493);
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
            logoutpicture.Location = new Point(8, 493);
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
            // 
            // SidebarControl
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(pnl_sideBarClient);
            Location = new Point(14, 40);
            Name = "SidebarControl";
            Size = new Size(1893, 891);
            pnl_sideBarClient.ResumeLayout(false);
            pnl_sideBarClient.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox5).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)logoutpicture).EndInit();
            ((System.ComponentModel.ISupportInitialize)usrpicture).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private RoundedPanel pnl_sideBarClient;
        private Button button5;
        private PictureBox pictureBox4;
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


    }
}
