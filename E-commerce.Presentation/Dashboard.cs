using E_commerce.Application.Helper;
using E_commerce.Application.Interfaces;
using E_commerce.Core.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace E_commerce.Presentation
{
    public partial class Dashboard : Form
    {
        private readonly IUserRepository _userRepository;
        public Dashboard(User user, IUserRepository userRepository)
        {
            InitializeComponent();
            _userRepository = userRepository;
            this.DoubleBuffered = true;
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            lbl_employeeName.Text += user.FirstName;
        }

        public Dashboard()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
        }
        public Dashboard(IUserRepository userRepository)
        {
            InitializeComponent();
            _userRepository = userRepository;
        }
        public Dashboard(User user)
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            lbl_employeeName.Text += user.FirstName;

        }

        private void Dashboard_Load(object sender, EventArgs e)
        {

            this.WindowState = FormWindowState.Maximized;

            this.SuspendLayout();

            MakeRoundedPanel(pnl_sideBar, 30);
            //this.Paint += new PaintEventHandler(Dashboard_Paint);
            //this.BackColor = Color.FromArgb(245, 245, 245) // Very Light Gray
            this.BackColor =
            //Color.FromArgb(250, 250, 240) // FloralWhite (أبيض على لمسة أصفر)
Color.FromArgb(240, 248, 255) // AliceBlue – أزرق سماوي فاتح جداً


;
            Dashboardbtn.MouseEnter += (s, e) =>
            {
                Dashboardbtn.BackColor = Color.FromArgb(200, 230, 250); // لون ناعم عند المرور
                Dashboardbtn.ForeColor = Color.DarkBlue;                // لون الخط أغمق
            };

            Dashboardbtn.MouseLeave += (s, e) =>
            {
                Dashboardbtn.BackColor = Color.Transparent;            // يرجع شفاف
                Dashboardbtn.ForeColor = Color.Black;           // يرجع لونه الأصلي
            };

            Dashboardbtn.MouseDown += (s, e) =>
            {
                Dashboardbtn.BackColor = Color.FromArgb(180, 210, 240); // لون أغمق عند الضغط
            };

            Dashboardbtn.MouseUp += (s, e) =>
            {
                Dashboardbtn.BackColor = Color.FromArgb(200, 230, 250); // يرجع للهوفر
            };


        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void btn_dashboard_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void lbl_employeeName_Click(object sender, EventArgs e)
        {

        }

        private void logoutpicture_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Are you sure you want to log out?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                this.Hide();
                // Show the login form again
                SessionManager.Logout();
                var loginForm = new Login_Form();
                loginForm.Show();
            }


        }
        private void Dashboard_Paint(object sender, PaintEventArgs e)
        {
            using (LinearGradientBrush brush = new LinearGradientBrush(this.ClientRectangle,
                Color.FromArgb(135, 206, 250),   // Sky Blue
                Color.FromArgb(255, 182, 193),   // Light Pink
                LinearGradientMode.Vertical))
            {
                e.Graphics.FillRectangle(brush, this.ClientRectangle);
            }
        }

        private void pnl_sideBar_Paint(object sender, PaintEventArgs e)
        {
            using (LinearGradientBrush brush = new LinearGradientBrush(pnl_sideBar.ClientRectangle,
                    Color.FromArgb(135, 206, 250),   // Sky Blue
                    Color.FromArgb(255, 223, 102)  // Light Yellow (Sunlight)

//Color.FromArgb(63, 43, 150) , Color.FromArgb(42, 27, 161)





// Color.FromArgb(255, 175, 189), // مشمشي وردي
//Color.FromArgb(255, 195, 160)  // مشمشي فاتح


,
                LinearGradientMode.Vertical))
            {
                e.Graphics.FillRectangle(brush, pnl_sideBar.ClientRectangle);
            }
        }

        private void usrpicture_Click(object sender, EventArgs e)
        {

        }

        private void logoutbutton_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Are you sure you want to log out?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                SessionManager.Logout();
                this.Hide();
                var loginForm = new Login_Form();
                loginForm.Show();
            }
        }
    }
}
