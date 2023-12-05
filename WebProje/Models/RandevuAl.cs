using System.ComponentModel.DataAnnotations;

namespace WebProje.Models
{
    public class RandevuAl
    {
        [Required(ErrorMessage = "Lütfen bir İl seçiniz.")]
        public string Sehir { get; set; }
        [Required(ErrorMessage = "Lütfen bir İlçe seçiniz.")]
        public string Ilce { get; set; }
        [Required(ErrorMessage = "Lütfen bir Hastane seçiniz.")]
        public string Hastane { get; set; }
        [Required(ErrorMessage = "Lütfen bir Bölüm seçiniz.")]
        public string Bolum { get; set; }
        [Required(ErrorMessage = "Lütfen bir Doktor seçiniz.")]
        public string Doktor { get; set; }
        [Required(ErrorMessage = "Lütfen Tarih Seçiniz.")]
        public string Date { get; set; }
    }
}
