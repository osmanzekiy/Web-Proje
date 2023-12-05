namespace WebProje.Models
{
    public class Randevu
    {
        public int RandevuId { get; set; }
        public DateTime Tarih { get; set; }

        public int? HastaId { get; set; }
        public Hasta Hasta { get; set; }

        public int DoktorId { get; set; }
        public Doktor Doktor { get; set; }
        public bool IsOpen { get; set; }


    }
}
