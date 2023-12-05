using System.ComponentModel.DataAnnotations;

namespace WebProje.Models
{
    public class Roles
    {
        [Key]
        public int RolId { get; set; }
        public string RolAdi { get; set; }
    }
}
