using E_commerce.Application.Services.UserServices;
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
            _userServices = userServices;
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
