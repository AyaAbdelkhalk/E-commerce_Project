using E_commerce.Application.DTOs.User;
using E_commerce.Application.Helper;
using E_commerce.Application.Services.UserServices;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace E_commerce.Presentation
{
    public partial class Login_Form : Form
    {
        private readonly IUserServices _userServices;


        public Login_Form(IUserServices userServices)
        {
            InitializeComponent();
            _userServices = userServices;
            this.DoubleBuffered = true;

            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);


        }

        private async void Login_Form_Load(object sender, EventArgs e)
        {
            loginUnderline.Visible = false;

            try
            {
                string imagePath = "C:\\Users\\Elnour Tech\\source\\repos\\E-commerce\\E-commerce.Presentation\\Images\\Untitled design.png";
                if (System.IO.File.Exists(imagePath))
                {
                    this.BackgroundImage = Image.FromFile(imagePath);
                    this.BackgroundImageLayout = ImageLayout.Stretch;
                }
                else
                {
                    MessageBox.Show("لم يتم العثور على ملف الصورة في المسار المحدد.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("حدث خطأ أثناء تحميل الخلفية: " + ex.Message);
            }
        }

        private async void loginbtn_Click(object sender, EventArgs e)//login button
        {
            try
            {

                var result = await _userServices.Login(new LoginDTO
                {
                    UserName = UserNametextBox.Text,
                    Password = PsswordTextBox.Text
                });

                if (result.Succeeded)
                {
                    this.Hide();
                    if (SessionManager.IsAdmin())
                        new AdminDashboard().Show();
                    else
                        new ClientDashboard().Show();
                }
                else
                {
                    MessageBox.Show(string.Join("\n", result.Errors));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("حدث خطأ: " + ex.Message);
            }
        }


        private void Loginbutton_Click(object sender, EventArgs e) //sign in form
        {
            Loginpanel.BringToFront();
            registerUnderline.Visible = false;
            loginUnderline.Visible = true;
        }

        private void button1_Click(object sender, EventArgs e) //register form
        {
            REGpanel.BringToFront();
            loginUnderline.Visible = false;
            registerUnderline.Visible = true;
        }

        private void button3_Click(object sender, EventArgs e) //exit button  
        {
            System.Windows.Forms.Application.Exit();
        }


        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            panel2.BackColor = Color.Transparent;
            Rectangle shadowRect = panel2.ClientRectangle;
            shadowRect.Inflate(-1, -1);
            DrawShadow(e.Graphics, shadowRect);

            using (LinearGradientBrush brush = new LinearGradientBrush(panel2.ClientRectangle,
                Color.FromArgb(150, Color.White),
                Color.FromArgb(150, Color.Silver),
                45F))
            {
                e.Graphics.FillRectangle(brush, panel2.ClientRectangle);
            }

            panel2.BorderStyle = BorderStyle.None;
            panel2.Region = new Region(panel2.ClientRectangle);
        }
        private void label2_Click(object sender, EventArgs e) { }





        private void DrawShadow(Graphics g, Rectangle rect, int shadowSize = 6)
        {
            using (GraphicsPath path = new GraphicsPath())
            {
                path.AddRectangle(rect);
                using (PathGradientBrush brush = new PathGradientBrush(path))
                {
                    brush.CenterColor = Color.FromArgb(80, 0, 0, 0); // Dark transparent center
                    brush.SurroundColors = new Color[] { Color.Transparent };
                    g.FillRectangle(brush, new Rectangle(rect.X - shadowSize, rect.Y - shadowSize,
                                                         rect.Width + shadowSize * 2, rect.Height + shadowSize * 2));
                }
            }
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            try
            {
                var result = await _userServices.AddNewUser(new AddUserDTO
                {
                    UserName = usernametxt.Text,
                    Password = passwordtxt.Text,
                    PasswordConfirmed = conpasswordtxt.Text,
                    Email = Emailtxt.Text,
                    FirstName = FirstNametxt.Text,
                    LastName = LastNametxt.Text
                });
                if (result.Succeeded)
                {
                    MessageBox.Show(result.Errors.ToString());
                    this.Hide();
                    new ClientDashboard().Show();
                }
                else
                {
                    MessageBox.Show(string.Join("\n", result.Errors));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("حدث خطأ: " + ex.Message);
            }

        }
    }
}
