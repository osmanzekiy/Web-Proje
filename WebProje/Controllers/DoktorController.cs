using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Security.Claims;
using WebProje.Models;

namespace WebProje.Controllers
{
    [Authorize(Roles="Doktor")]
    public class DoktorController : Controller
    {
        private readonly HastaneContext _context;
        public DoktorController(HastaneContext context)
        {
            _context = context;
        }

        public IActionResult Anasayfa()
        {
            string? id = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            var myId =_context.Doktorlar.Where(t=>t.TC== User.FindFirst(ClaimTypes.NameIdentifier).Value).Select(a=>a.DoktorId).FirstOrDefault();
            ViewBag.aktifrandevu = _context.Randevular.Include(r => r.Doktor).Include(r => r.Hasta).Include(r=>r.Doktor.Bolum).Where(m => m.Hasta.TC == User.FindFirst(ClaimTypes.NameIdentifier).Value && m.Tarih > DateTime.Now).ToList();

            var randevular =_context.Randevular.Include(r=>r.Doktor).Include(r=>r.Hasta).Include(r=>r.Doktor.Bolum).Where(x=>x.DoktorId==myId && x.HastaId!=null && x.Tarih>DateTime.Now).ToList();
            ViewBag.BuSeneVerilenRandevu = _context.Randevular.Where(a => a.DoktorId == myId && a.IsOpen == false).Count();

            string bolum = "";
            var encok = _context.Randevular.Include(r => r.Doktor).Include(r => r.Hasta).Include(b => b.Doktor.Bolum).Where(m => m.Hasta.TC == id && m.Tarih.Year == DateTime.Now.Year).GroupBy(d => d.DoktorId).OrderByDescending(g => g.Count()).Select(g => new { DoktorId = g.Key, RandevuSayisi = g.Count() }).FirstOrDefault();
            if (encok != null)
            {
                bolum = _context.Doktorlar.Where(r => r.DoktorId == encok.DoktorId).Select(r => r.Bolum.BolumAdi).FirstOrDefault();
                ViewBag.EnCokBolum = "En Çok " + bolum + " Bölümünden " + encok.RandevuSayisi + " Adet Randevu Aldınız!";
            }
            else
                ViewBag.EnCokBolum = "Henüz Sistemde Kayıtlı Randevunuz Yok!";
            return View(randevular);
        }
    }
}
