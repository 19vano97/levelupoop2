using System.ComponentModel.DataAnnotations.Schema;

namespace _20241027TestWebAPI.Models
{
    [Table("Account")]
    public class LoginModel
    {
        public string email { get; set; }
        public string password { get; set; }
    }
}
