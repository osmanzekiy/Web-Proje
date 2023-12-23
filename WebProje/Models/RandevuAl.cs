using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace WebProje.Models
{
    [BindProperties()]
    public class RandevuAl
    {
        [Display(Name = "Sehir")]
        [Required(ErrorMessage = "Lütfen bir İl seçiniz.")]
        public string Sehir { get; set; }

        [Display(Name="Ilce")]
        [Required(ErrorMessage = "Lütfen bir İlçe seçiniz.")]
        public string Ilce { get; set; }

        [Display(Name="Hastane")]
        [Required(ErrorMessage = "Lütfen bir Hastane seçiniz.")]
        public string Hastane { get; set; }

        [Display(Name = "Bolum")]
        [Required(ErrorMessage = "Lütfen bir Bölüm seçiniz.")]
        public string Bolum { get; set; }

        [Display(Name = "Doktor")]
        [Required(ErrorMessage = "Lütfen bir Doktor seçiniz.")]
        public string Doktor { get; set; }

        [Display(Name = "Tarih")]
        [Required(ErrorMessage = "Lütfen Tarih Seçiniz.")]
        public string Date { get; set; }

    }
}
