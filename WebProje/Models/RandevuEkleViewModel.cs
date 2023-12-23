using System.ComponentModel.DataAnnotations;

namespace WebProje.Models
{
    public class RandevuEkleViewModel
    {
        [Required(ErrorMessage = "Lütfen bir Bölüm seçiniz.")]
        public string Bolum { get; set; }

        [Required(ErrorMessage = "Lütfen bir Doktor seçiniz.")]
        public string Doktor { get; set; }

        [Required(ErrorMessage ="Lütfen bir Tarih seçiniz.")]
        public DateTime Tarih { get; set; }


    }
}
