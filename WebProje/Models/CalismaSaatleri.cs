using System.ComponentModel.DataAnnotations;

namespace WebProje.Models
{
    public class CalismaSaatleri
    {
        [Key]
        public int CalismaSaatleriId { get; set; }
        public string Gun { get; set; }
        public TimeSpan Baslangic { get; set; }
        public TimeSpan Bitis { get; set; }
        public int DoktorId { get; set; }
        public Doktor Doktor { get; set; }
    }
}
