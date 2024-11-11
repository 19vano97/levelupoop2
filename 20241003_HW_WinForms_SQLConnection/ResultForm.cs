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
using System.Text.Json;

namespace _20241003_HW_WinForms_SQLConnection
{
    public partial class ResultForm : Form
    {
        public string clientName = "DesktopAppForWindows";
        private string _baseUrl;
        public string accountEmail;

        public ResultForm()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private async void ResultForm_Load(object sender, EventArgs e)
        {
            LoginForm login = new LoginForm();

            var configuration = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .Build();

            string baseUrl = configuration["ApiSettings:BaseUrl"];
            _baseUrl = baseUrl;

            if (login.ShowDialog() == DialogResult.OK)
            {
                AccountController loginToService = new AccountController(baseUrl);
                bool resLogin = loginToService.LoginToService(login.Email, login.Password).Result;
                accountEmail = login.Email;

                if (!resLogin)
                {
                    MessageBox.Show("Wrong email or password");
                    Close();
                }

                AccountController getEmails = new AccountController(baseUrl);

                string emails = getEmails.GetAllEmails().Result;

                OutputEmails(emails);
                grdEmailShow.CellContentClick += dataGridView1_CellContentClick;
            }
            else
            {
                Close();
            }
        }

        private void OutputEmails(string emails)
        {
            IEnumerable<string> emailsIE = ParseEmails(emails);

            foreach (var item in emailsIE)
            {
                grdEmailShow.ColumnCount = 1;
                grdEmailShow.Rows.Add(item);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            grdEmailDetails.Rows.Clear();
            grdEmailDetails.Columns.Clear();

            DataGridView emailGrid = sender as DataGridView;
            string email = (string)emailGrid.SelectedCells[0].Value;

            AccountController acc = new AccountController(_baseUrl);
            var emailDetails = ParseJson(acc.GetAccountDetails(email).Result);

            foreach (var item in emailDetails)
            {
                grdEmailDetails.ColumnCount = item.Count;
                grdEmailDetails.Rows.Add(item.Values.ToArray());
            }
        }

        private IEnumerable<string> ParseEmails(string emails)
        {
            return JsonSerializer.Deserialize<IEnumerable<string>>(emails);
        }

        private IEnumerable<Dictionary<string, object>> ParseJson(string jsonStr)
        {
            return JsonSerializer.Deserialize<List<Dictionary<string, object>>>(jsonStr);
        }

        private void grdEmailDetails_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
