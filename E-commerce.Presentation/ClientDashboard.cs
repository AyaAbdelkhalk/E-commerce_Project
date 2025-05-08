using E_commerce.Application.Services;
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
    public partial class ClientDashboard : Form
    {
        private readonly IUserServices _userServices;
        public ClientDashboard(IUserServices userServices)
        {
            InitializeComponent();
        }
        public ClientDashboard()
        {
            InitializeComponent();
        }

        private void ClientDashboard_Load(object sender, EventArgs e)
        {

        }
    }
}
