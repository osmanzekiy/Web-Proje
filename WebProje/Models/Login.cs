using System.ComponentModel.DataAnnotations;

namespace WebProje.Models
{
    public class Login
    {
        [Required(ErrorMessage ="TC No Alanı Boş Olamaz!")]
        [RegularExpression(@"\d{11}$", ErrorMessage = "11 Karakterlik Sayısal Alan Giriniz!")]

        public string TC { get; set; }
        [Required(ErrorMessage ="Şifre Alanı Boş Olamaz!")]
        public string Sifre { get; set; }
    }
}
