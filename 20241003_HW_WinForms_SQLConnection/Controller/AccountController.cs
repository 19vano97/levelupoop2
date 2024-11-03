

namespace _20241003_HW_WinForms_SQLConnection.Controller
{
    public class AccountController
    {
        public string pathToLogin = "/login";
        public string baseUrl;

        public AccountController(string baseUrl)
        {
            string url = string.Format("{0}{1}", baseUrl, pathToLogin);
        }

        public string LoginToService(string email, string password)
        {
            return PostLoginAsync(url, email, password);
        }

        private static async Task<string> PostLoginAsync(string url, string email, string password)
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
                var json = JsonSerializer.Serialize(data);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                // Send the POST request with JSON content
                var response = await client.PostAsync(url, content);

                // Ensure success status code
                response.EnsureSuccessStatusCode();

                // Read the response body as a string
                return await response.Content.ReadAsStringAsync();
            }
        }
    }
}
