using System.ComponentModel.DataAnnotations;

namespace WebProje.Models
{
    public class DoktorEkleViewModel
    {
        [Required(ErrorMessage ="Bu Alan Zorunludur!")]
        public string Isim { get; set; }
        [Required(ErrorMessage = "Bu Alan Zorunludur!")]
        public string Soyisim { get; set; }
        [Required(ErrorMessage = "Bu Alan Zorunludur!")]
        [StringLength(11, MinimumLength = 11,ErrorMessage ="TC 11 karakter olmalıdır!")]
        public string TC { get; set; }
        [Required(ErrorMessage = "Bu Alan Zorunludur!")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Bu Alan Zorunludur!")]

        public int BolumId { get; set; }

    }
}
