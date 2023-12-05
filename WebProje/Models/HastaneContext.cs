using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace WebProje.Models
{
    public class HastaneContext:DbContext
    {


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=(localdb)\\MSSQLLocalDB;database=HastaneDeneme;integrated security=true;");
        }


        public DbSet<Roles> Roller { get; set; }
        public DbSet<Bolum> Bolumler { get; set; }
        public DbSet<Hasta> Hastalar { get; set; }
        public DbSet<Doktor> Doktorlar { get; set; }
        public DbSet<Randevu> Randevular { get; set; }
        public DbSet<Admin> Adminler { get; set; }
        

      
    }
}
