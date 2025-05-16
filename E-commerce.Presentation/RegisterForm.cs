using E_commerce.Application.Services.UserServices;
using E_commerce.Presentation.CustomControls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace E_commerce.Presentation
{
    public partial class RegisterForm : Form
    {
        private readonly IUserServices _userServices;
        public RegisterForm(IUserServices userServices)
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            _userServices = userServices;
            SidebarControl sidebarControl = new SidebarControl(_userServices);
            sidebarControl.Visible = true;
            this.Controls.Add(sidebarControl);

        }
        public RegisterForm()
        {
            InitializeComponent();
        }

        private void RegisterForm_Load(object sender, EventArgs e)
        {

        }
    }
}
