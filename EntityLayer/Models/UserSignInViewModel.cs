using System.ComponentModel.DataAnnotations;

namespace DemoProject.Models
{
    public class UserSignInViewModel
    {
        [Required(ErrorMessage ="Lütfen kullanıcı adını girin")]
        public string username { get; set; }
        [Required(ErrorMessage = "Lütfen şifre girin")]
        public string password { get; set; }
    }
}
