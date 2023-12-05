using System.ComponentModel.DataAnnotations;

namespace WebProje.Models
{
    public class Admin
    {
        public int AdminId { get; set; }
        public string Isim { get; set; }
        public string Soyisim { get; set; }
        public string Mail { get; set; }
        public string Password { get; set; }   
        
        public int RolId { get; set; }
        public Roles Rol { get; set; }
    }
}
