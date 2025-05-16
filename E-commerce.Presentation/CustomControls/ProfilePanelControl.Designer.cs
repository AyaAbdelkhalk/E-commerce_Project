using AttendEase.Presentation.CustomControls;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Dynamic;

namespace E_commerce.Presentation.CustomControls
{
    partial class ProfilePanelControl
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
            roundedPanel1 = new RoundedPanel();
            DDDroundedPanel2 = new RoundedPanel();
            label12 = new Label();
            button3 = new Button();
            button1 = new Button();
            customTextBox26 = new CustomTextBox2();
            customTextBox28 = new CustomTextBox2();
            customTextBox27 = new CustomTextBox2();
            customTextBox212 = new CustomTextBox2();
            label8 = new Label();
            label7 = new Label();
            label6 = new Label();
            INFOroundedPanel2 = new RoundedPanel();
            Pinfo = new Label();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            customTextBox21 = new CustomTextBox2();
            customTextBox22 = new CustomTextBox2();
            customTextBox23 = new CustomTextBox2();
            customTextBox24 = new CustomTextBox2();
            customTextBox25 = new CustomTextBox2();
            PPProundedPanel3 = new RoundedPanel();
            label9 = new Label();
            label10 = new Label();
            label11 = new Label();
            customTextBox210 = new CustomTextBox2();
            customTextBox211 = new CustomTextBox2();
            customTextBox29 = new CustomTextBox2();
            ChangePassword = new Button();
            button2 = new Button();
            button5 = new Button();
            button6 = new Button();
            button7 = new Button();
            roundedPanel1.SuspendLayout();
            DDDroundedPanel2.SuspendLayout();
            INFOroundedPanel2.SuspendLayout();
            PPProundedPanel3.SuspendLayout();
            SuspendLayout();
            // 
            // roundedPanel1
            // 
            roundedPanel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            roundedPanel1.BackColor = Color.FromArgb(80, 110, 160);
            roundedPanel1.Controls.Add(DDDroundedPanel2);
            roundedPanel1.Controls.Add(INFOroundedPanel2);
            roundedPanel1.Controls.Add(PPProundedPanel3);
            roundedPanel1.CornerRadius = 30;
            roundedPanel1.Location = new Point(45, 3);
            roundedPanel1.Name = "roundedPanel1";
            roundedPanel1.Size = new Size(1386, 920);
            roundedPanel1.TabIndex = 0;
            roundedPanel1.Paint += roundedPanel1_Paint;
            // 
            // DDDroundedPanel2
            // 
            DDDroundedPanel2.BackColor = Color.FromArgb(224, 224, 224);
            DDDroundedPanel2.Controls.Add(label12);
            DDDroundedPanel2.Controls.Add(button3);
            DDDroundedPanel2.Controls.Add(button1);
            DDDroundedPanel2.Controls.Add(customTextBox26);
            DDDroundedPanel2.Controls.Add(customTextBox28);
            DDDroundedPanel2.Controls.Add(customTextBox27);
            DDDroundedPanel2.Controls.Add(customTextBox212);
            DDDroundedPanel2.Controls.Add(label8);
            DDDroundedPanel2.Controls.Add(label7);
            DDDroundedPanel2.Controls.Add(label6);
            DDDroundedPanel2.CornerRadius = 30;
            DDDroundedPanel2.Location = new Point(71, 412);
            DDDroundedPanel2.Name = "DDDroundedPanel2";
            DDDroundedPanel2.Size = new Size(551, 291);
            DDDroundedPanel2.TabIndex = 1;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Sylfaen", 12F, FontStyle.Italic);
            label12.Location = new Point(280, 29);
            label12.Name = "label12";
            label12.Size = new Size(109, 26);
            label12.TabIndex = 20;
            label12.Text = "Last Name ";
            label12.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // button3
            // 
            button3.Location = new Point(414, 213);
            button3.Name = "button3";
            button3.Size = new Size(96, 42);
            button3.TabIndex = 19;
            button3.Text = "Clear";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // button1
            // 
            button1.Location = new Point(154, 213);
            button1.Name = "button1";
            button1.Size = new Size(96, 42);
            button1.TabIndex = 18;
            button1.Text = "Save";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // customTextBox26
            // 
            customTextBox26.BackColor = Color.White;
            customTextBox26.BorderColor = Color.FromArgb(181, 191, 249);
            customTextBox26.BorderFocusColor = Color.FromArgb(181, 191, 249);
            customTextBox26.BorderSize = 1;
            customTextBox26.CornerRadius = 8;
            customTextBox26.ForeColor = Color.FromArgb(38, 32, 59);
            customTextBox26.Location = new Point(137, 127);
            customTextBox26.Margin = new Padding(3, 4, 3, 4);
            customTextBox26.Multiline = false;
            customTextBox26.Name = "customTextBox26";
            customTextBox26.Padding = new Padding(13);
            customTextBox26.PasswordChar = false;
            customTextBox26.Size = new Size(400, 40);
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
            customTextBox28.Location = new Point(137, 20);
            customTextBox28.Margin = new Padding(3, 4, 3, 4);
            customTextBox28.Multiline = false;
            customTextBox28.Name = "customTextBox28";
            customTextBox28.Padding = new Padding(13);
            customTextBox28.PasswordChar = false;
            customTextBox28.Size = new Size(137, 40);
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
            customTextBox27.Location = new Point(137, 76);
            customTextBox27.Margin = new Padding(3, 4, 3, 4);
            customTextBox27.Multiline = false;
            customTextBox27.Name = "customTextBox27";
            customTextBox27.Padding = new Padding(13);
            customTextBox27.PasswordChar = false;
            customTextBox27.Size = new Size(400, 40);
            customTextBox27.TabIndex = 16;
            customTextBox27.TextAlign = HorizontalAlignment.Left;
            customTextBox27.UnderlinedStyle = false;
            // 
            // customTextBox212
            // 
            customTextBox212.BackColor = Color.White;
            customTextBox212.BorderColor = Color.FromArgb(181, 191, 249);
            customTextBox212.BorderFocusColor = Color.FromArgb(181, 191, 249);
            customTextBox212.BorderSize = 1;
            customTextBox212.CornerRadius = 8;
            customTextBox212.ForeColor = Color.FromArgb(38, 32, 59);
            customTextBox212.Location = new Point(398, 20);
            customTextBox212.Margin = new Padding(3, 4, 3, 4);
            customTextBox212.Multiline = false;
            customTextBox212.Name = "customTextBox212";
            customTextBox212.Padding = new Padding(13);
            customTextBox212.PasswordChar = false;
            customTextBox212.Size = new Size(139, 40);
            customTextBox212.TabIndex = 21;
            customTextBox212.TextAlign = HorizontalAlignment.Left;
            customTextBox212.UnderlinedStyle = false;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Sylfaen", 12F, FontStyle.Italic);
            label8.Location = new Point(22, 29);
            label8.Name = "label8";
            label8.Size = new Size(113, 26);
            label8.TabIndex = 12;
            label8.Text = "First Name ";
            label8.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Sylfaen", 12F, FontStyle.Italic);
            label7.Location = new Point(22, 79);
            label7.Name = "label7";
            label7.Size = new Size(112, 26);
            label7.TabIndex = 13;
            label7.Text = "User Name ";
            label7.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Sylfaen", 12F, FontStyle.Italic);
            label6.Location = new Point(33, 130);
            label6.Name = "label6";
            label6.Size = new Size(77, 26);
            label6.TabIndex = 14;
            label6.Text = "E-Mail ";
            label6.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // INFOroundedPanel2
            // 
            INFOroundedPanel2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            INFOroundedPanel2.BackColor = Color.FromArgb(224, 224, 224);
            INFOroundedPanel2.Controls.Add(Pinfo);
            INFOroundedPanel2.Controls.Add(label1);
            INFOroundedPanel2.Controls.Add(label2);
            INFOroundedPanel2.Controls.Add(label3);
            INFOroundedPanel2.Controls.Add(label4);
            INFOroundedPanel2.Controls.Add(label5);
            INFOroundedPanel2.Controls.Add(customTextBox21);
            INFOroundedPanel2.Controls.Add(customTextBox22);
            INFOroundedPanel2.Controls.Add(customTextBox23);
            INFOroundedPanel2.Controls.Add(customTextBox24);
            INFOroundedPanel2.Controls.Add(customTextBox25);
            INFOroundedPanel2.CornerRadius = 30;
            INFOroundedPanel2.Location = new Point(71, 37);
            INFOroundedPanel2.Name = "INFOroundedPanel2";
            INFOroundedPanel2.Size = new Size(1247, 356);
            INFOroundedPanel2.TabIndex = 1;
            INFOroundedPanel2.Paint += INFOroundedPanel2_Paint;
            // 
            // Pinfo
            // 
            Pinfo.AutoSize = true;
            Pinfo.BackColor = SystemColors.GradientInactiveCaption;
            Pinfo.Font = new Font("Sylfaen", 16.2F, FontStyle.Bold | FontStyle.Italic);
            Pinfo.Location = new Point(20, 20);
            Pinfo.Name = "Pinfo";
            Pinfo.Size = new Size(185, 36);
            Pinfo.TabIndex = 0;
            Pinfo.Text = "Personal Info";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Sylfaen", 12F, FontStyle.Italic);
            label1.Location = new Point(20, 80);
            label1.Name = "label1";
            label1.Size = new Size(104, 26);
            label1.TabIndex = 1;
            label1.Text = "Full Name";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Sylfaen", 12F, FontStyle.Italic);
            label2.Location = new Point(20, 130);
            label2.Name = "label2";
            label2.Size = new Size(99, 26);
            label2.TabIndex = 2;
            label2.Text = "Username";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Sylfaen", 12F, FontStyle.Italic);
            label3.Location = new Point(20, 180);
            label3.Name = "label3";
            label3.Size = new Size(64, 26);
            label3.TabIndex = 3;
            label3.Text = "Email";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Sylfaen", 12F, FontStyle.Italic);
            label4.Location = new Point(20, 230);
            label4.Name = "label4";
            label4.Size = new Size(143, 26);
            label4.TabIndex = 4;
            label4.Text = "Account Status";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Sylfaen", 12F, FontStyle.Italic);
            label5.Location = new Point(20, 280);
            label5.Name = "label5";
            label5.Size = new Size(50, 26);
            label5.TabIndex = 5;
            label5.Text = "Role";
            // 
            // customTextBox21
            // 
            customTextBox21.BackColor = Color.White;
            customTextBox21.BorderColor = Color.FromArgb(181, 191, 249);
            customTextBox21.BorderFocusColor = Color.FromArgb(181, 191, 249);
            customTextBox21.BorderSize = 1;
            customTextBox21.CornerRadius = 8;
            customTextBox21.ForeColor = Color.FromArgb(38, 32, 59);
            customTextBox21.Location = new Point(182, 80);
            customTextBox21.Multiline = false;
            customTextBox21.Name = "customTextBox21";
            customTextBox21.Padding = new Padding(13);
            customTextBox21.PasswordChar = false;
            customTextBox21.Size = new Size(400, 40);
            customTextBox21.TabIndex = 6;
            customTextBox21.TextAlign = HorizontalAlignment.Left;
            customTextBox21.UnderlinedStyle = false;
            // 
            // customTextBox22
            // 
            customTextBox22.BackColor = Color.White;
            customTextBox22.BorderColor = Color.FromArgb(181, 191, 249);
            customTextBox22.BorderFocusColor = Color.FromArgb(181, 191, 249);
            customTextBox22.BorderSize = 1;
            customTextBox22.CornerRadius = 8;
            customTextBox22.ForeColor = Color.FromArgb(38, 32, 59);
            customTextBox22.Location = new Point(182, 130);
            customTextBox22.Multiline = false;
            customTextBox22.Name = "customTextBox22";
            customTextBox22.Padding = new Padding(13);
            customTextBox22.PasswordChar = false;
            customTextBox22.Size = new Size(400, 40);
            customTextBox22.TabIndex = 7;
            customTextBox22.TextAlign = HorizontalAlignment.Left;
            customTextBox22.UnderlinedStyle = false;
            // 
            // customTextBox23
            // 
            customTextBox23.BackColor = Color.White;
            customTextBox23.BorderColor = Color.FromArgb(181, 191, 249);
            customTextBox23.BorderFocusColor = Color.FromArgb(181, 191, 249);
            customTextBox23.BorderSize = 1;
            customTextBox23.CornerRadius = 8;
            customTextBox23.ForeColor = Color.FromArgb(38, 32, 59);
            customTextBox23.Location = new Point(182, 180);
            customTextBox23.Multiline = false;
            customTextBox23.Name = "customTextBox23";
            customTextBox23.Padding = new Padding(13);
            customTextBox23.PasswordChar = false;
            customTextBox23.Size = new Size(400, 40);
            customTextBox23.TabIndex = 8;
            customTextBox23.TextAlign = HorizontalAlignment.Left;
            customTextBox23.UnderlinedStyle = false;
            // 
            // customTextBox24
            // 
            customTextBox24.BackColor = Color.White;
            customTextBox24.BorderColor = Color.FromArgb(181, 191, 249);
            customTextBox24.BorderFocusColor = Color.FromArgb(181, 191, 249);
            customTextBox24.BorderSize = 1;
            customTextBox24.CornerRadius = 8;
            customTextBox24.ForeColor = Color.FromArgb(38, 32, 59);
            customTextBox24.Location = new Point(182, 230);
            customTextBox24.Multiline = false;
            customTextBox24.Name = "customTextBox24";
            customTextBox24.Padding = new Padding(13);
            customTextBox24.PasswordChar = false;
            customTextBox24.Size = new Size(400, 40);
            customTextBox24.TabIndex = 9;
            customTextBox24.TextAlign = HorizontalAlignment.Left;
            customTextBox24.UnderlinedStyle = false;
            // 
            // customTextBox25
            // 
            customTextBox25.BackColor = Color.White;
            customTextBox25.BorderColor = Color.FromArgb(181, 191, 249);
            customTextBox25.BorderFocusColor = Color.FromArgb(181, 191, 249);
            customTextBox25.BorderSize = 1;
            customTextBox25.CornerRadius = 8;
            customTextBox25.ForeColor = Color.FromArgb(38, 32, 59);
            customTextBox25.Location = new Point(182, 280);
            customTextBox25.Multiline = false;
            customTextBox25.Name = "customTextBox25";
            customTextBox25.Padding = new Padding(13);
            customTextBox25.PasswordChar = false;
            customTextBox25.Size = new Size(400, 40);
            customTextBox25.TabIndex = 10;
            customTextBox25.TextAlign = HorizontalAlignment.Left;
            customTextBox25.UnderlinedStyle = false;
            // 
            // PPProundedPanel3
            // 
            PPProundedPanel3.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            PPProundedPanel3.BackColor = Color.FromArgb(224, 224, 224);
            PPProundedPanel3.Controls.Add(label9);
            PPProundedPanel3.Controls.Add(label10);
            PPProundedPanel3.Controls.Add(label11);
            PPProundedPanel3.Controls.Add(customTextBox210);
            PPProundedPanel3.Controls.Add(customTextBox211);
            PPProundedPanel3.Controls.Add(customTextBox29);
            PPProundedPanel3.Controls.Add(ChangePassword);
            PPProundedPanel3.Controls.Add(button2);
            PPProundedPanel3.CornerRadius = 30;
            PPProundedPanel3.Location = new Point(717, 411);
            PPProundedPanel3.Name = "PPProundedPanel3";
            PPProundedPanel3.Size = new Size(601, 291);
            PPProundedPanel3.TabIndex = 2;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Sylfaen", 12F, FontStyle.Italic);
            label9.Location = new Point(20, 38);
            label9.Name = "label9";
            label9.Size = new Size(166, 26);
            label9.TabIndex = 0;
            label9.Text = "Current Password";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Sylfaen", 12F, FontStyle.Italic);
            label10.Location = new Point(20, 88);
            label10.Name = "label10";
            label10.Size = new Size(136, 26);
            label10.TabIndex = 1;
            label10.Text = "New Password";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Sylfaen", 12F, FontStyle.Italic);
            label11.Location = new Point(20, 138);
            label11.Name = "label11";
            label11.Size = new Size(170, 26);
            label11.TabIndex = 2;
            label11.Text = "Confirm Password";
            // 
            // customTextBox210
            // 
            customTextBox210.BackColor = Color.White;
            customTextBox210.BorderColor = Color.FromArgb(181, 191, 249);
            customTextBox210.BorderFocusColor = Color.FromArgb(0, 120, 215);
            customTextBox210.BorderSize = 2;
            customTextBox210.CornerRadius = 8;
            customTextBox210.ForeColor = Color.FromArgb(38, 32, 59);
            customTextBox210.Location = new Point(203, 29);
            customTextBox210.Multiline = false;
            customTextBox210.Name = "customTextBox210";
            customTextBox210.Padding = new Padding(5);
            customTextBox210.PasswordChar = true;
            customTextBox210.Size = new Size(362, 35);
            customTextBox210.TabIndex = 3;
            customTextBox210.TextAlign = HorizontalAlignment.Left;
            customTextBox210.UnderlinedStyle = false;
            // 
            // customTextBox211
            // 
            customTextBox211.BackColor = Color.White;
            customTextBox211.BorderColor = Color.FromArgb(181, 191, 249);
            customTextBox211.BorderFocusColor = Color.FromArgb(0, 120, 215);
            customTextBox211.BorderSize = 2;
            customTextBox211.CornerRadius = 8;
            customTextBox211.ForeColor = Color.FromArgb(38, 32, 59);
            customTextBox211.Location = new Point(203, 88);
            customTextBox211.Multiline = false;
            customTextBox211.Name = "customTextBox211";
            customTextBox211.Padding = new Padding(5);
            customTextBox211.PasswordChar = true;
            customTextBox211.Size = new Size(362, 35);
            customTextBox211.TabIndex = 4;
            customTextBox211.TextAlign = HorizontalAlignment.Left;
            customTextBox211.UnderlinedStyle = false;
            // 
            // customTextBox29
            // 
            customTextBox29.BackColor = Color.White;
            customTextBox29.BorderColor = Color.FromArgb(181, 191, 249);
            customTextBox29.BorderFocusColor = Color.FromArgb(0, 120, 215);
            customTextBox29.BorderSize = 2;
            customTextBox29.CornerRadius = 8;
            customTextBox29.ForeColor = Color.FromArgb(38, 32, 59);
            customTextBox29.Location = new Point(203, 138);
            customTextBox29.Multiline = false;
            customTextBox29.Name = "customTextBox29";
            customTextBox29.Padding = new Padding(5);
            customTextBox29.PasswordChar = true;
            customTextBox29.Size = new Size(362, 35);
            customTextBox29.TabIndex = 5;
            customTextBox29.TextAlign = HorizontalAlignment.Left;
            customTextBox29.UnderlinedStyle = false;
            // 
            // ChangePassword
            // 
            ChangePassword.ImageAlign = ContentAlignment.BottomCenter;
            ChangePassword.Location = new Point(233, 213);
            ChangePassword.Name = "ChangePassword";
            ChangePassword.Size = new Size(96, 42);
            ChangePassword.TabIndex = 6;
            ChangePassword.Text = "Save";
            ChangePassword.UseMnemonic = false;
            ChangePassword.UseVisualStyleBackColor = true;
            ChangePassword.Click += ChangePassword_Click;
            // 
            // button2
            // 
            button2.Location = new Point(444, 213);
            button2.Name = "button2";
            button2.Size = new Size(96, 42);
            button2.TabIndex = 7;
            button2.Text = "Cancel";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button5
            // 
            button5.Location = new Point(0, 0);
            button5.Name = "button5";
            button5.Size = new Size(75, 23);
            button5.TabIndex = 0;
            // 
            // button6
            // 
            button6.Location = new Point(0, 0);
            button6.Name = "button6";
            button6.Size = new Size(75, 23);
            button6.TabIndex = 0;
            // 
            // button7
            // 
            button7.Location = new Point(0, 0);
            button7.Name = "button7";
            button7.Size = new Size(75, 23);
            button7.TabIndex = 0;
            // 
            // ProfilePanelControl
            // 
            BackColor = Color.Transparent;
            Controls.Add(roundedPanel1);
            Location = new Point(383, 40);
            Name = "ProfilePanelControl";
            Size = new Size(1582, 938);
            Load += ProfilePanelControl_Load;
            roundedPanel1.ResumeLayout(false);
            DDDroundedPanel2.ResumeLayout(false);
            DDDroundedPanel2.PerformLayout();
            INFOroundedPanel2.ResumeLayout(false);
            INFOroundedPanel2.PerformLayout();
            PPProundedPanel3.ResumeLayout(false);
            PPProundedPanel3.PerformLayout();
            ResumeLayout(false);
        }

        public RoundedPanel roundedPanel1;
        public RoundedPanel INFOroundedPanel2;
        public RoundedPanel DDDroundedPanel2;
        public RoundedPanel PPProundedPanel3;
        public CustomTextBox2 customTextBox21;
        public CustomTextBox2 customTextBox22;
        public CustomTextBox2 customTextBox23;
        public CustomTextBox2 customTextBox24;
        public CustomTextBox2 customTextBox25;
        public CustomTextBox2 customTextBox26;
        public CustomTextBox2 customTextBox27;
        public CustomTextBox2 customTextBox28;
        public CustomTextBox2 customTextBox210;
        public CustomTextBox2 customTextBox211;
        public CustomTextBox2 customTextBox29;
        public Label Pinfo;
        public Label label1;
        public Label label2;
        public Label label3;
        public Label label4;
        public Label label5;
        public Label label6;
        public Label label7;
        public Label label8;
        public Label label9;
        public Label label10;
        public Label label11;
        public Button button2;
        public Button button3;
        public Button button5;
        public Button ChangePassword;
        public Button button4;
        public Button button1;
        public Label label12;
        public Button button6;
        public Button button7;
        public CustomControls.CustomTextBox2 customTextBox212;


        #endregion
    }
}