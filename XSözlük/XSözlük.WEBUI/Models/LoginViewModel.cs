using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace XSözlük.WEBUI.Models
{
    public class LoginViewModel
    {
        [Display(Name = "E-Posta")]
        public string Email { get; set; }
        [Display(Name = "Şifre")]
        public string Password { get; set; }
    }
}

