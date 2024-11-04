

using Newtonsoft.Json;
using System.Text;
using System.Text.Json;

namespace _20241003_HW_WinForms_SQLConnection.Controller
{
    public class AccountController
    {
        public string pathToLogin = "/api/account/login";
        public string pathToGetAllEmails = "/api/account/details/dev@yopmail.com";
        public string baseUrlAC;

        public AccountController(string baseUrl)
        {
            baseUrlAC = baseUrl;  string.Format("{0}{1}", baseUrl, pathToLogin);
        }

        public async Task<bool> LoginToService(string email, string password)
        {
            return await PostLoginAsync(string.Format("{0}{1}", baseUrlAC, pathToLogin), email, password) == true;
        }

        private async Task<bool> PostLoginAsync(string url, string email, string password)
        {
            using (var client = new HttpClient())
            {
                // Prepare the data object with email and password
                var data = new
                {
                    Email = email,
                    Password = password
                };

                // Serialize the object to JSON
                var json = JsonConvert.SerializeObject(data);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                try
                {
                    var response = client.PostAsync(url, content).Result;

                    return response.IsSuccessStatusCode;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}");

                    return false;
                }
            }
        }

        public async Task<string> GetAllEmails()
        {
            using (var client = new HttpClient())
            {
                var response = client.GetAsync(string.Format($"{baseUrlAC}{pathToGetAllEmails}")).Result;

                if (response.IsSuccessStatusCode)
                {
                    var data = response.Content.ReadAsStringAsync().Result;

                    return data.ToString();
                }

                return response.ToString();
            }
        }
    }
}
