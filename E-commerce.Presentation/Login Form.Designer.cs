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
            UserNametextBox = new TextBox();
            PasswordtextBox = new TextBox();
            UserName = new Label();
            label2 = new Label();
            Loginbutton = new Button();
            button1 = new Button();
            SuspendLayout();
            // 
            // UserNametextBox
            // 
            UserNametextBox.Location = new Point(292, 117);
            UserNametextBox.Name = "UserNametextBox";
            UserNametextBox.Size = new Size(382, 27);
            UserNametextBox.TabIndex = 0;
            // 
            // PasswordtextBox
            // 
            PasswordtextBox.Location = new Point(292, 205);
            PasswordtextBox.Name = "PasswordtextBox";
            PasswordtextBox.Size = new Size(382, 27);
            PasswordtextBox.TabIndex = 1;
            // 
            // UserName
            // 
            UserName.AutoSize = true;
            UserName.Location = new Point(152, 120);
            UserName.Name = "UserName";
            UserName.Size = new Size(78, 20);
            UserName.TabIndex = 2;
            UserName.Text = "UserName";
            UserName.Click += label1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(152, 208);
            label2.Name = "label2";
            label2.Size = new Size(70, 20);
            label2.TabIndex = 3;
            label2.Text = "Password";
            // 
            // Loginbutton
            // 
            Loginbutton.Font = new Font("Franklin Gothic Heavy", 16.2F, FontStyle.Italic, GraphicsUnit.Point, 0);
            Loginbutton.Location = new Point(376, 285);
            Loginbutton.Name = "Loginbutton";
            Loginbutton.Size = new Size(134, 45);
            Loginbutton.TabIndex = 4;
            Loginbutton.Text = "Login";
            Loginbutton.UseVisualStyleBackColor = true;
            Loginbutton.Click += Loginbutton_Click;
            // 
            // button1
            // 
            button1.Font = new Font("Franklin Gothic Heavy", 16.2F, FontStyle.Italic, GraphicsUnit.Point, 0);
            button1.Location = new Point(654, 12);
            button1.Name = "button1";
            button1.Size = new Size(134, 45);
            button1.TabIndex = 5;
            button1.Text = "Register";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // Login_Form
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(button1);
            Controls.Add(Loginbutton);
            Controls.Add(label2);
            Controls.Add(UserName);
            Controls.Add(PasswordtextBox);
            Controls.Add(UserNametextBox);
            FormBorderStyle = FormBorderStyle.SizableToolWindow;
            Name = "Login_Form";
            Text = "Login_Form";
            Load += Login_Form_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox UserNametextBox;
        private TextBox PasswordtextBox;
        private Label UserName;
        private Label label2;
        private Button Loginbutton;
        private Button button1;
    }
}