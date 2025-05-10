using AttendEase.Presentation.CustomControls;
using FontAwesome.Sharp;
using System.Drawing.Drawing2D;

namespace E_commerce.Presentation
{
    partial class Login_Form
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login_Form));
            Loginbutton = new Button();
            UserNametextBox = new CustomTextBox();
            Emailtxt = new CustomTextBox();
            UserName = new Label();
            label2 = new Label();
            button1 = new Button();
            panel2 = new Panel();
            label7 = new Label();
            Exitbtn = new Button();
            pictureBox1 = new PictureBox();
            label3 = new Label();
            loginUnderline = new Panel();
            registerUnderline = new Panel();
            Loginpanel = new Panel();
            loginbtn = new Button();
            togglePasswordButton = new IconButton();
            PsswordTextBox = new CustomTextBox();
            REGpanel = new Panel();
            LastNamelbl = new Label();
            LastNametxt = new CustomTextBox();
            FirstNamelbl = new Label();
            FirstNametxt = new CustomTextBox();
            label6 = new Label();
            usernametxt = new CustomTextBox();
            label5 = new Label();
            label4 = new Label();
            label1 = new Label();
            button2 = new Button();
            toggleRegPasswordButton = new IconButton();
            toggleRegConfirmPasswordButton = new IconButton();
            conpasswordtxt = new CustomTextBox();
            passwordtxt = new CustomTextBox();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            Loginpanel.SuspendLayout();
            REGpanel.SuspendLayout();
            SuspendLayout();
            // 
            // Loginbutton
            // 
            Loginbutton.Anchor = AnchorStyles.None;
            Loginbutton.BackColor = Color.Transparent;
            Loginbutton.Cursor = Cursors.Hand;
            Loginbutton.FlatAppearance.BorderSize = 0;
            Loginbutton.FlatAppearance.MouseDownBackColor = Color.Transparent;
            Loginbutton.FlatAppearance.MouseOverBackColor = Color.Transparent;
            Loginbutton.FlatStyle = FlatStyle.Flat;
            Loginbutton.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            Loginbutton.ForeColor = Color.MidnightBlue;
            Loginbutton.Location = new Point(602, 32);
            Loginbutton.Name = "Loginbutton";
            Loginbutton.Size = new Size(142, 45);
            Loginbutton.TabIndex = 4;
            Loginbutton.Text = "Sign in";
            Loginbutton.UseVisualStyleBackColor = false;
            Loginbutton.Click += Loginbutton_Click;
            // 
            // UserNametextBox
            // 
            UserNametextBox.Anchor = AnchorStyles.None;
            UserNametextBox.BackColor = Color.White;
            UserNametextBox.BorderColor = Color.FromArgb(181, 191, 249);
            UserNametextBox.BorderFocusColor = Color.FromArgb(181, 191, 249);
            UserNametextBox.BorderSize = 1;
            UserNametextBox.ForeColor = Color.FromArgb(38, 32, 59);
            UserNametextBox.Location = new Point(24, 131);
            UserNametextBox.Multiline = false;
            UserNametextBox.Name = "UserNametextBox";
            UserNametextBox.Padding = new Padding(13);
            UserNametextBox.PasswordChar = false;
            UserNametextBox.Size = new Size(367, 47);
            UserNametextBox.TabIndex = 0;
            UserNametextBox.UnderlinedStyle = false;
            // 
            // Emailtxt
            // 
            Emailtxt.Anchor = AnchorStyles.None;
            Emailtxt.BackColor = Color.White;
            Emailtxt.BorderColor = Color.FromArgb(181, 191, 249);
            Emailtxt.BorderFocusColor = Color.FromArgb(181, 191, 249);
            Emailtxt.BorderSize = 0;
            Emailtxt.ForeColor = Color.FromArgb(38, 32, 59);
            Emailtxt.Location = new Point(25, 40);
            Emailtxt.Multiline = false;
            Emailtxt.Name = "Emailtxt";
            Emailtxt.Padding = new Padding(13);
            Emailtxt.PasswordChar = false;
            Emailtxt.Size = new Size(367, 47);
            Emailtxt.TabIndex = 1;
            Emailtxt.UnderlinedStyle = false;
            // 
            // UserName
            // 
            UserName.Anchor = AnchorStyles.None;
            UserName.AutoSize = true;
            UserName.Font = new Font("Urdu Typesetting", 12F, FontStyle.Bold | FontStyle.Italic);
            UserName.ForeColor = Color.MidnightBlue;
            UserName.Location = new Point(24, 91);
            UserName.Name = "UserName";
            UserName.Size = new Size(109, 37);
            UserName.TabIndex = 2;
            UserName.Text = "User Name";
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.None;
            label2.AutoSize = true;
            label2.Font = new Font("Urdu Typesetting", 12F, FontStyle.Bold | FontStyle.Italic);
            label2.ForeColor = Color.MidnightBlue;
            label2.Location = new Point(24, 181);
            label2.Name = "label2";
            label2.Size = new Size(100, 37);
            label2.TabIndex = 3;
            label2.Text = "Password";
            label2.Click += label2_Click;
            // 
            // button1
            // 
            button1.Anchor = AnchorStyles.None;
            button1.BackColor = Color.Transparent;
            button1.Cursor = Cursors.Hand;
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatAppearance.MouseDownBackColor = Color.Transparent;
            button1.FlatAppearance.MouseOverBackColor = Color.Transparent;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            button1.ForeColor = Color.MidnightBlue;
            button1.Location = new Point(440, 32);
            button1.Name = "button1";
            button1.Size = new Size(142, 45);
            button1.TabIndex = 5;
            button1.Text = "Register";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // panel2
            // 
            panel2.Anchor = AnchorStyles.None;
            panel2.Controls.Add(label7);
            panel2.Controls.Add(Exitbtn);
            panel2.Controls.Add(pictureBox1);
            panel2.Controls.Add(label3);
            panel2.Controls.Add(button1);
            panel2.Controls.Add(Loginbutton);
            panel2.Controls.Add(loginUnderline);
            panel2.Controls.Add(registerUnderline);
            panel2.Controls.Add(REGpanel);
            panel2.Controls.Add(Loginpanel);
            panel2.Location = new Point(162, 12);
            panel2.Name = "panel2";
            panel2.Size = new Size(810, 718);
            panel2.TabIndex = 7;
            panel2.Paint += panel2_Paint;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Simplified Arabic Fixed", 19.8000011F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label7.ForeColor = Color.MidnightBlue;
            label7.Location = new Point(37, 544);
            label7.Margin = new Padding(0);
            label7.Name = "label7";
            label7.RightToLeft = RightToLeft.Yes;
            label7.Size = new Size(290, 40);
            label7.TabIndex = 12;
            label7.Text = "Join us Today";
            label7.TextAlign = ContentAlignment.TopCenter;
            // 
            // Exitbtn
            // 
            Exitbtn.Anchor = AnchorStyles.None;
            Exitbtn.BackColor = Color.Transparent;
            Exitbtn.Cursor = Cursors.Hand;
            Exitbtn.FlatAppearance.BorderSize = 0;
            Exitbtn.FlatAppearance.MouseDownBackColor = Color.FromArgb(120, 0, 0, 0);
            Exitbtn.FlatAppearance.MouseOverBackColor = Color.FromArgb(100, 181, 191, 249);
            Exitbtn.FlatStyle = FlatStyle.Flat;
            Exitbtn.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            Exitbtn.ForeColor = Color.White;
            Exitbtn.Location = new Point(55, 627);
            Exitbtn.Name = "Exitbtn";
            Exitbtn.Size = new Size(123, 50);
            Exitbtn.TabIndex = 10;
            Exitbtn.Text = "Exit";
            Exitbtn.UseVisualStyleBackColor = false;
            Exitbtn.Click += button3_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.BorderStyle = BorderStyle.Fixed3D;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(55, 176);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(306, 226);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 8;
            pictureBox1.TabStop = false;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Simplified Arabic Fixed", 19.8000011F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.MidnightBlue;
            label3.Location = new Point(3, 61);
            label3.Name = "label3";
            label3.Size = new Size(353, 80);
            label3.TabIndex = 6;
            label3.Text = "Welcome To \r\n      Our System";
            label3.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // loginUnderline
            // 
            loginUnderline.BackColor = Color.MidnightBlue;
            loginUnderline.Location = new Point(602, 78);
            loginUnderline.Name = "loginUnderline";
            loginUnderline.Size = new Size(142, 2);
            loginUnderline.TabIndex = 0;
            // 
            // registerUnderline
            // 
            registerUnderline.BackColor = Color.MidnightBlue;
            registerUnderline.Location = new Point(440, 78);
            registerUnderline.Name = "registerUnderline";
            registerUnderline.Size = new Size(142, 2);
            registerUnderline.TabIndex = 1;
            // 
            // Loginpanel
            // 
            Loginpanel.Controls.Add(UserName);
            Loginpanel.Controls.Add(UserNametextBox);
            Loginpanel.Controls.Add(label2);
            Loginpanel.Controls.Add(loginbtn);
            Loginpanel.Controls.Add(togglePasswordButton);
            Loginpanel.Controls.Add(PsswordTextBox);
            Loginpanel.Location = new Point(391, 121);
            Loginpanel.Name = "Loginpanel";
            Loginpanel.Size = new Size(407, 597);
            Loginpanel.TabIndex = 10;
            // 
            // loginbtn
            // 
            loginbtn.Anchor = AnchorStyles.None;
            loginbtn.BackColor = Color.MidnightBlue;
            loginbtn.Cursor = Cursors.Hand;
            loginbtn.FlatAppearance.BorderSize = 0;
            loginbtn.FlatAppearance.MouseDownBackColor = Color.Transparent;
            loginbtn.FlatAppearance.MouseOverBackColor = Color.FromArgb(181, 191, 249);
            loginbtn.FlatStyle = FlatStyle.Flat;
            loginbtn.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            loginbtn.ForeColor = Color.White;
            loginbtn.Location = new Point(131, 300);
            loginbtn.Name = "loginbtn";
            loginbtn.Size = new Size(123, 50);
            loginbtn.TabIndex = 9;
            loginbtn.Text = "Log In";
            loginbtn.UseVisualStyleBackColor = false;
            loginbtn.Click += loginbtn_Click;
            // 
            // togglePasswordButton
            // 
            togglePasswordButton.BackColor = Color.White;
            togglePasswordButton.FlatAppearance.BorderSize = 0;
            togglePasswordButton.FlatStyle = FlatStyle.Flat;
            togglePasswordButton.IconChar = IconChar.Eye;
            togglePasswordButton.IconColor = Color.Gray;
            togglePasswordButton.IconFont = IconFont.Auto;
            togglePasswordButton.IconSize = 24;
            togglePasswordButton.Location = new Point(351, 237);
            togglePasswordButton.Name = "togglePasswordButton";
            togglePasswordButton.Size = new Size(30, 30);
            togglePasswordButton.TabIndex = 10;
            togglePasswordButton.UseVisualStyleBackColor = false;
            togglePasswordButton.Click += TogglePasswordButton_Click;
            // 
            // PsswordTextBox
            // 
            PsswordTextBox.Anchor = AnchorStyles.None;
            PsswordTextBox.BackColor = Color.White;
            PsswordTextBox.BorderColor = Color.FromArgb(181, 191, 249);
            PsswordTextBox.BorderFocusColor = Color.FromArgb(181, 191, 249);
            PsswordTextBox.BorderSize = 1;
            PsswordTextBox.ForeColor = Color.FromArgb(38, 32, 59);
            PsswordTextBox.Location = new Point(24, 232);
            PsswordTextBox.Multiline = false;
            PsswordTextBox.Name = "PsswordTextBox";
            PsswordTextBox.Padding = new Padding(13);
            PsswordTextBox.PasswordChar = true;
            PsswordTextBox.Size = new Size(367, 47);
            PsswordTextBox.TabIndex = 1;
            PsswordTextBox.UnderlinedStyle = false;
            // 
            // REGpanel
            // 
            REGpanel.Controls.Add(LastNamelbl);
            REGpanel.Controls.Add(LastNametxt);
            REGpanel.Controls.Add(FirstNamelbl);
            REGpanel.Controls.Add(FirstNametxt);
            REGpanel.Controls.Add(label6);
            REGpanel.Controls.Add(usernametxt);
            REGpanel.Controls.Add(label5);
            REGpanel.Controls.Add(label4);
            REGpanel.Controls.Add(label1);
            REGpanel.Controls.Add(button2);
            REGpanel.Controls.Add(Emailtxt);
            REGpanel.Controls.Add(toggleRegPasswordButton);
            REGpanel.Controls.Add(toggleRegConfirmPasswordButton);
            REGpanel.Controls.Add(conpasswordtxt);
            REGpanel.Controls.Add(passwordtxt);
            REGpanel.Location = new Point(391, 121);
            REGpanel.Name = "REGpanel";
            REGpanel.Size = new Size(408, 594);
            REGpanel.TabIndex = 11;
            // 
            // LastNamelbl
            // 
            LastNamelbl.Anchor = AnchorStyles.None;
            LastNamelbl.AutoSize = true;
            LastNamelbl.Font = new Font("Urdu Typesetting", 12F, FontStyle.Bold | FontStyle.Italic);
            LastNamelbl.ForeColor = Color.MidnightBlue;
            LastNamelbl.Location = new Point(25, 445);
            LastNamelbl.Name = "LastNamelbl";
            LastNamelbl.Size = new Size(105, 37);
            LastNamelbl.TabIndex = 22;
            LastNamelbl.Text = "Last Name";
            // 
            // LastNametxt
            // 
            LastNametxt.Anchor = AnchorStyles.None;
            LastNametxt.BackColor = Color.White;
            LastNametxt.BorderColor = Color.FromArgb(181, 191, 249);
            LastNametxt.BorderFocusColor = Color.FromArgb(181, 191, 249);
            LastNametxt.BorderSize = 0;
            LastNametxt.ForeColor = Color.FromArgb(38, 32, 59);
            LastNametxt.Location = new Point(25, 484);
            LastNametxt.Multiline = false;
            LastNametxt.Name = "LastNametxt";
            LastNametxt.Padding = new Padding(13);
            LastNametxt.PasswordChar = false;
            LastNametxt.Size = new Size(367, 47);
            LastNametxt.TabIndex = 21;
            LastNametxt.UnderlinedStyle = false;
            // 
            // FirstNamelbl
            // 
            FirstNamelbl.Anchor = AnchorStyles.None;
            FirstNamelbl.AutoSize = true;
            FirstNamelbl.Font = new Font("Urdu Typesetting", 12F, FontStyle.Bold | FontStyle.Italic);
            FirstNamelbl.ForeColor = Color.MidnightBlue;
            FirstNamelbl.Location = new Point(25, 358);
            FirstNamelbl.Name = "FirstNamelbl";
            FirstNamelbl.Size = new Size(109, 37);
            FirstNamelbl.TabIndex = 20;
            FirstNamelbl.Text = "First Name";
            // 
            // FirstNametxt
            // 
            FirstNametxt.Anchor = AnchorStyles.None;
            FirstNametxt.BackColor = Color.White;
            FirstNametxt.BorderColor = Color.FromArgb(181, 191, 249);
            FirstNametxt.BorderFocusColor = Color.FromArgb(181, 191, 249);
            FirstNametxt.BorderSize = 0;
            FirstNametxt.ForeColor = Color.FromArgb(38, 32, 59);
            FirstNametxt.Location = new Point(25, 395);
            FirstNametxt.Multiline = false;
            FirstNametxt.Name = "FirstNametxt";
            FirstNametxt.Padding = new Padding(13);
            FirstNametxt.PasswordChar = false;
            FirstNametxt.Size = new Size(367, 47);
            FirstNametxt.TabIndex = 18;
            FirstNametxt.UnderlinedStyle = false;
            // 
            // label6
            // 
            label6.Anchor = AnchorStyles.None;
            label6.AutoSize = true;
            label6.Font = new Font("Urdu Typesetting", 12F, FontStyle.Bold | FontStyle.Italic);
            label6.ForeColor = Color.MidnightBlue;
            label6.Location = new Point(25, 90);
            label6.Name = "label6";
            label6.Size = new Size(109, 37);
            label6.TabIndex = 15;
            label6.Text = "User Name";
            // 
            // usernametxt
            // 
            usernametxt.Anchor = AnchorStyles.None;
            usernametxt.BackColor = Color.White;
            usernametxt.BorderColor = Color.FromArgb(181, 191, 249);
            usernametxt.BorderFocusColor = Color.FromArgb(181, 191, 249);
            usernametxt.BorderSize = 0;
            usernametxt.ForeColor = Color.FromArgb(38, 32, 59);
            usernametxt.Location = new Point(25, 130);
            usernametxt.Multiline = false;
            usernametxt.Name = "usernametxt";
            usernametxt.Padding = new Padding(13);
            usernametxt.PasswordChar = false;
            usernametxt.Size = new Size(367, 47);
            usernametxt.TabIndex = 14;
            usernametxt.UnderlinedStyle = false;
            // 
            // label5
            // 
            label5.Anchor = AnchorStyles.None;
            label5.AutoSize = true;
            label5.Font = new Font("Urdu Typesetting", 12F, FontStyle.Bold | FontStyle.Italic);
            label5.ForeColor = Color.MidnightBlue;
            label5.Location = new Point(24, 268);
            label5.Name = "label5";
            label5.Size = new Size(174, 37);
            label5.TabIndex = 13;
            label5.Text = "Confirm Password";
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.None;
            label4.AutoSize = true;
            label4.Font = new Font("Urdu Typesetting", 12F, FontStyle.Bold | FontStyle.Italic);
            label4.ForeColor = Color.MidnightBlue;
            label4.Location = new Point(25, 180);
            label4.Name = "label4";
            label4.Size = new Size(100, 37);
            label4.TabIndex = 12;
            label4.Text = "Password";
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.None;
            label1.AutoSize = true;
            label1.Font = new Font("Urdu Typesetting", 12F, FontStyle.Bold | FontStyle.Italic);
            label1.ForeColor = Color.MidnightBlue;
            label1.Location = new Point(25, 3);
            label1.Name = "label1";
            label1.Size = new Size(73, 37);
            label1.TabIndex = 12;
            label1.Text = "E-Mail";
            // 
            // button2
            // 
            button2.Anchor = AnchorStyles.None;
            button2.BackColor = Color.MidnightBlue;
            button2.Cursor = Cursors.Hand;
            button2.FlatAppearance.BorderSize = 0;
            button2.FlatAppearance.MouseDownBackColor = Color.Transparent;
            button2.FlatAppearance.MouseOverBackColor = Color.FromArgb(181, 191, 249);
            button2.FlatStyle = FlatStyle.Flat;
            button2.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            button2.ForeColor = Color.White;
            button2.Location = new Point(132, 544);
            button2.Name = "button2";
            button2.Size = new Size(123, 50);
            button2.TabIndex = 11;
            button2.Text = "Sign Up";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // toggleRegPasswordButton
            // 
            toggleRegPasswordButton.BackColor = Color.White;
            toggleRegPasswordButton.FlatAppearance.BorderSize = 0;
            toggleRegPasswordButton.FlatStyle = FlatStyle.Flat;
            toggleRegPasswordButton.IconChar = IconChar.Eye;
            toggleRegPasswordButton.IconColor = Color.Gray;
            toggleRegPasswordButton.IconFont = IconFont.Auto;
            toggleRegPasswordButton.IconSize = 24;
            toggleRegPasswordButton.Location = new Point(361, 232);
            toggleRegPasswordButton.Name = "toggleRegPasswordButton";
            toggleRegPasswordButton.Size = new Size(20, 21);
            toggleRegPasswordButton.TabIndex = 16;
            toggleRegPasswordButton.UseVisualStyleBackColor = false;
            toggleRegPasswordButton.Click += ToggleRegPasswordButton_Click;
            // 
            // toggleRegConfirmPasswordButton
            // 
            toggleRegConfirmPasswordButton.BackColor = Color.White;
            toggleRegConfirmPasswordButton.FlatAppearance.BorderSize = 0;
            toggleRegConfirmPasswordButton.FlatStyle = FlatStyle.Flat;
            toggleRegConfirmPasswordButton.IconChar = IconChar.Eye;
            toggleRegConfirmPasswordButton.IconColor = Color.Gray;
            toggleRegConfirmPasswordButton.IconFont = IconFont.Auto;
            toggleRegConfirmPasswordButton.IconSize = 24;
            toggleRegConfirmPasswordButton.Location = new Point(351, 319);
            toggleRegConfirmPasswordButton.Name = "toggleRegConfirmPasswordButton";
            toggleRegConfirmPasswordButton.Size = new Size(40, 25);
            toggleRegConfirmPasswordButton.TabIndex = 17;
            toggleRegConfirmPasswordButton.UseVisualStyleBackColor = false;
            toggleRegConfirmPasswordButton.Click += ToggleRegConfirmPasswordButton_Click;
            // 
            // conpasswordtxt
            // 
            conpasswordtxt.Anchor = AnchorStyles.None;
            conpasswordtxt.BackColor = Color.White;
            conpasswordtxt.BorderColor = Color.FromArgb(181, 191, 249);
            conpasswordtxt.BorderFocusColor = Color.FromArgb(181, 191, 249);
            conpasswordtxt.BorderSize = 0;
            conpasswordtxt.ForeColor = Color.FromArgb(38, 32, 59);
            conpasswordtxt.Location = new Point(25, 307);
            conpasswordtxt.Multiline = false;
            conpasswordtxt.Name = "conpasswordtxt";
            conpasswordtxt.Padding = new Padding(13);
            conpasswordtxt.PasswordChar = false;
            conpasswordtxt.Size = new Size(367, 47);
            conpasswordtxt.TabIndex = 3;
            conpasswordtxt.UnderlinedStyle = false;
            // 
            // passwordtxt
            // 
            passwordtxt.Anchor = AnchorStyles.None;
            passwordtxt.BackColor = Color.White;
            passwordtxt.BorderColor = Color.FromArgb(181, 191, 249);
            passwordtxt.BorderFocusColor = Color.FromArgb(181, 191, 249);
            passwordtxt.BorderSize = 0;
            passwordtxt.ForeColor = Color.FromArgb(38, 32, 59);
            passwordtxt.Location = new Point(25, 220);
            passwordtxt.Multiline = false;
            passwordtxt.Name = "passwordtxt";
            passwordtxt.Padding = new Padding(13);
            passwordtxt.PasswordChar = true;
            passwordtxt.Size = new Size(367, 47);
            passwordtxt.TabIndex = 2;
            passwordtxt.UnderlinedStyle = false;
            // 
            // Login_Form
            // 
            AutoScaleMode = AutoScaleMode.Inherit;
            AutoSize = true;
            AutoValidate = AutoValidate.EnablePreventFocusChange;
            ClientSize = new Size(1154, 742);
            Controls.Add(panel2);
            Name = "Login_Form";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Login_Form";
            WindowState = FormWindowState.Maximized;
            Load += Login_Form_Load;
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            Loginpanel.ResumeLayout(false);
            Loginpanel.PerformLayout();
            REGpanel.ResumeLayout(false);
            REGpanel.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private AttendEase.Presentation.CustomControls.CustomTextBox UserNametextBox;
        private AttendEase.Presentation.CustomControls.CustomTextBox Emailtxt;
        private Label UserName;
        private Label label2;
        private Button Loginbutton;
        private Button button1;
        private Panel panel2;//3
        private Label label3;
        private PictureBox pictureBox1;
        private Panel loginUnderline;
        private Panel registerUnderline;
        private Button loginbtn;
        private Button Exitbtn;
        private Panel REGpanel;//2
        private CustomTextBox PsswordTextBox;
        private CustomTextBox conpasswordtxt;
        private CustomTextBox passwordtxt;
        private Label label5;
        private Label label4;
        private Label label1;
        private Button button2;
        private Label label6;
        private CustomTextBox usernametxt;
        private Panel Loginpanel;//1
        private Label label7;
        private IconButton togglePasswordButton;
        private FontAwesome.Sharp.IconButton toggleRegPasswordButton;
        private FontAwesome.Sharp.IconButton toggleRegConfirmPasswordButton;

        private void TogglePasswordButton_Click(object sender, EventArgs e)
        {
            PsswordTextBox.PasswordChar = !PsswordTextBox.PasswordChar;

            togglePasswordButton.IconChar = PsswordTextBox.PasswordChar ?
                IconChar.Eye : IconChar.EyeSlash;
        }
        private void ToggleRegPasswordButton_Click(object sender, EventArgs e)
        {
            passwordtxt.PasswordChar = !passwordtxt.PasswordChar;
            toggleRegPasswordButton.IconChar = passwordtxt.PasswordChar ? IconChar.Eye : IconChar.EyeSlash;
        }

        private void ToggleRegConfirmPasswordButton_Click(object sender, EventArgs e)
        {
            conpasswordtxt.PasswordChar = !conpasswordtxt.PasswordChar;
            toggleRegConfirmPasswordButton.IconChar = conpasswordtxt.PasswordChar ? IconChar.Eye : IconChar.EyeSlash;
        }
        private Label LastNamelbl;
        private CustomTextBox LastNametxt;
        private Label FirstNamelbl;
        private CustomTextBox FirstNametxt;
    }
}
