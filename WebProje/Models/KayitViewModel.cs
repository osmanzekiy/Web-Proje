using System.ComponentModel.DataAnnotations;

namespace WebProje.Models
{
    public class KayitViewModel
    {
        [Required]
        public string TC { get; set; }
        [Required(ErrorMessage = "Bu Alan Boş Olamaz!")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Bu Alan Boş Olamaz!")]
        public string Isim { get; set; }
        [Required(ErrorMessage = "Bu Alan Boş Olamaz!")]
        public string Soyisim { get; set; }
        [Required(ErrorMessage = "Bu Alan Boş Olamaz!")]
        public string Telefon { get; set; }
        [Required(ErrorMessage = "Bu Alan Boş Olamaz!")]
        public string Cinsiyet { get; set; }
    }
}
