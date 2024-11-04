using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using _20241003_HW_WinForms_SQLConnection.Controller;
using Microsoft.Extensions.Configuration;

namespace _20241003_HW_WinForms_SQLConnection
{
    public partial class ResultForm : Form
    {
        public ResultForm()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private async void ResultForm_Load(object sender, EventArgs e)
        {
            LoginForm login = new LoginForm();

            var configuration = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .Build();

            string baseUrl = configuration["ApiSettings:BaseUrl"];

            if (login.ShowDialog() == DialogResult.OK)
            {
                AccountController loginToService = new AccountController(baseUrl);
                bool resLogin = loginToService.LoginToService(login.Email, login.Password).Result;

                if (!resLogin)
                {
                    MessageBox.Show("Wrong email or password");
                    Close();
                }
            }
            else
            {
                Close();
            }
        }
    }
}
