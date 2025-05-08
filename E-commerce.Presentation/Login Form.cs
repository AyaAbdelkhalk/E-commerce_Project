using E_commerce.Application.DTOs.UserDTOs;
using E_commerce.Application.Helper;
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
    public partial class Login_Form : Form
    {
        private readonly IUserServices _userServices;

        public Login_Form(IUserServices userServices)
        {
            InitializeComponent();
            _userServices = userServices;
        }

        private void Login_Form_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private async void Loginbutton_Click(object sender, EventArgs e)
        {
            try
            {
                var result = await _userServices.Login(new LoginDTO
                {
                    UserName = UserNametextBox.Text,
                    Password = PasswordtextBox.Text
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

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            var registerForm = new RegisterForm(_userServices);
            registerForm.Show();

        }

    }
}

