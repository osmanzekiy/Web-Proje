using System.ComponentModel.DataAnnotations;

namespace WebProje.Models
{
    public class AdminLogin
    {
        [Required(ErrorMessage ="Bu Alan Zorunludur!")]
        public string Email { get; set; }
        [Required(ErrorMessage ="Bu Alan Zorunludur!")]
        public string Password { get; set; }
    }
}
