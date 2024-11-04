using System.ComponentModel.DataAnnotations.Schema;

namespace _20241027TestWebAPI.Models
{
    public class Login
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
