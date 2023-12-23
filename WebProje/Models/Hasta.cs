using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WebProje.Models
{
    public class Hasta
    {
        public int HastaId { get; set; }
        [Required(ErrorMessage ="Bu Alan Boş Olamaz!")]
        [StringLength(11, MinimumLength = 11)]

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

        public virtual ICollection<Randevu>? Randevular { get; set; }

        public int? RolId { get; set; }
        public Roles? Rol { get; set; }


    }
}
