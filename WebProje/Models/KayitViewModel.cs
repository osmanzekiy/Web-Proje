using System.ComponentModel.DataAnnotations;

namespace WebProje.Models
{
    public class KayitViewModel
    {
        [Required(ErrorMessage ="Bu Alan Zorunludur")]
        [StringLength(11, MinimumLength = 11,ErrorMessage ="TC Kimlik No 11 Karakter Olmalıdır!")]

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
