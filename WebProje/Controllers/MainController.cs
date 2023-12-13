using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using WebProje.Models;

namespace WebProje.Controllers
{
    [Authorize(Roles = "Doktor,Hasta,Admin")]
    public class MainController : Controller
    {
        private readonly HastaneContext _context;

        public MainController(HastaneContext context)
        {
            _context = context;
        }
        public IActionResult Anasayfa()
        {
            string? id = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            var randevular = _context.Randevular.Include(r => r.Doktor).Include(r => r.Hasta).Where(m => m.Hasta.TC == id && m.Tarih>DateTime.Now).ToList();
            ViewBag.BuSeneAlınanRandevu = _context.Randevular.Include(r => r.Hasta).Where(m => m.Hasta.TC == id && m.Tarih.Year==DateTime.Now.Year).Count();
            string bolum = "";
            var encok = _context.Randevular.Include(r => r.Doktor).Include(r => r.Hasta).Include(b => b.Doktor.Bolum).Where(m => m.Hasta.TC == id && m.Tarih.Year == DateTime.Now.Year).GroupBy(d => d.DoktorId).OrderByDescending(g => g.Count()).Select(g => new { DoktorId = g.Key, RandevuSayisi = g.Count() }).FirstOrDefault();
            if (encok != null)
            {
                bolum = _context.Doktorlar.Where(r => r.DoktorId == encok.DoktorId).Select(r => r.Bolum.BolumAdi).FirstOrDefault();
                ViewBag.EnCokBolum = "En Çok " + bolum + " Bölümünden " + encok.RandevuSayisi + " Adet Randevu Aldınız!";
            }
            ViewBag.EnCokBolum = "Henüz Sistemde Kayıtlı Randevunuz Yok!";

            return View(randevular);
        }

        public IActionResult Ayarlar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Ayarlar(AyarlarViewModel model)
        {
            string? id = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (model.Password != null || model.Telefon != null)
            {
                if (model.Password != null)
                {
                    var hasta = _context.Hastalar.Where(p => p.TC == id).FirstOrDefault();
                    hasta.Password = model.Password;
                    _context.SaveChanges();
                    TempData["Ayarlar"] = "Şifre Başarı İle Değiştirildi!";
                }
                if (model.Telefon != null)
                {
                    var hasta = _context.Hastalar.Where(p => p.TC == id).FirstOrDefault();
                    hasta.Telefon = model.Telefon;
                    _context.SaveChanges();
                    if (TempData["Ayarlar"] != null)
                    {
                        TempData["Ayarlar"] = "Şifre ve Telefon Başarı İle Değiştirildi!";
                    }
                    else
                        TempData["Ayarlar"] = "Telefon Başarı İle Değiştirildi";
                }
            }
            else TempData["Ayarlar"] = "Hiçbir Değişiklik Yapılmadı!";


            return RedirectToAction("Ayarlar");
        }
    }
}
