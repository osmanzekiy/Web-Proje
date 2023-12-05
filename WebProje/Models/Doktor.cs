using System.ComponentModel.DataAnnotations;

namespace WebProje.Models
{
    public class Doktor
    {
       
        public int DoktorId { get; set; }
        public string Isim { get; set; }
        public string Soyisim { get; set; }
        public string TC { get; set; }
        public string Password { get; set; }

        public int BolumId { get; set; }
        public Bolum Bolum { get; set; }

        public int RolId { get; set; }
        public Roles Rol { get; set; }
    }
}
