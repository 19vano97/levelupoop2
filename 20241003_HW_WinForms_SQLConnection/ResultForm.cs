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

namespace _20241003_HW_WinForms_SQLConnection
{
    public partial class ResultForm : Form
    {
        public ResultForm()
        {
            InitializeComponent();
            
            var configuration = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .Build();
        
            string baseUrl = configuration["ApiSettings:BaseUrl"];
            _apiService = new ApiService(baseUrl);
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void ResultForm_Load(object sender, EventArgs e)
        {
            LoginForm login = new LoginForm();

            if (login.ShowDialog() == DialogResult.OK)
            {
                AccountController loginToService = new AccountController(baseUrl);
                string res = loginToService.LoginToService(login.Email, login.Password);

                
            }
            else
            {
                Close();
            }
        }
    }
}
