using System.ComponentModel.DataAnnotations.Schema;

namespace _20241027TestWebAPI.Models
{
    [Table("Account")]
    public class LoginModel
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
