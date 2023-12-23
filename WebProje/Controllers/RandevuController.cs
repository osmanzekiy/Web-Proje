using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Security.Claims;
using System.Text;
using WebProje.Models;

namespace WebProje.Controllers
{
    [Authorize(Roles ="Hasta,Doktor,Admin")]
    public class RandevuController : Controller
    {
        private readonly HastaneContext _context;
        
        public RandevuController(HastaneContext context)
        {
            _context = context;
        }
        public IActionResult RandevuAl()
        {
          
            var calismaSaatleri = _context.CalismaSaatleri.Include(r => r.Doktor).Select(g => new
            {
                DoktorAd=g.Doktor.Isim+" "+g.Doktor.Soyisim,
                Gun=g.Gun,
                SaatBas=g.Baslangic,
                SaatBit=g.Bitis
            }).ToList();
            ViewBag.calismaSaat = calismaSaatleri;
            var datas=_context.Bolumler.ToList();
            ViewBag.Veriler = new SelectList(datas.Select(e => new SelectListItem
            {
                Value = e.BolumId.ToString(),
                Text = e.BolumAdi
            }), "Value", "Text");
            
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> RandevuAl(RandevuAl randevu)
        {
            if (ModelState.IsValid)
            {
                int id;
                string tcm = User.FindFirst(ClaimTypes.NameIdentifier).Value;
                if(User.IsInRole("Hasta")) id=_context.Hastalar.Where(r=>r.TC==tcm).Select(r=>r.HastaId).FirstOrDefault();
                else id = _context.Doktorlar.Where(r => r.TC == tcm).Select(r => r.DoktorId).FirstOrDefault();
                var data = _context.Randevular.Find(int.Parse(randevu.Date));
                data.HastaId = id;
                data.IsOpen = false;
                _context.SaveChanges();
                TempData["IslemBasarili"]="Randevunuz Başarıyla Oluşturuldu!!!";
                return RedirectToAction("Anasayfa","Main");
            }
            else
            {
          
                var datas = _context.Bolumler.ToList();
                ViewBag.Veriler = new SelectList(datas.Select(e => new SelectListItem
                {
                    Value = e.BolumId.ToString(),
                    Text = e.BolumAdi
                }), "Value", "Text");
                return View(randevu);
            }
        }

        [Authorize(Roles="Doktor")]
        public IActionResult DoktorRandevuIptal(int RandevuId)
        {
            //var data = _context.Randevular.Find(RandevuId);
            //_context.Randevular.Remove(data);
            //_context.SaveChanges();
            return RedirectToAction("Anasayfa", "Doktor");
        }
        public IActionResult RandevuIptal(int RandevuId)
        {
            //var data = _context.Randevular.Find(RandevuId);
            //_context.Randevular.Remove(data);
            //_context.SaveChanges();
            if (!User.IsInRole("Doktor"))
                return RedirectToAction("Anasayfa", "Main");
            else return RedirectToAction("Anasayfa", "Doktor");
        }


        public JsonResult DoktorGetir(string selectedEntity)
        {
            if (selectedEntity != null)
            {
                int bolumId = int.Parse(selectedEntity);
                var datas = _context.Doktorlar.Where(e => e.BolumId == bolumId).ToList();
                string tcm = User.FindFirst(ClaimTypes.NameIdentifier).Value;
                if (datas.Any(d => d.TC == User.FindFirst(ClaimTypes.NameIdentifier).Value))
                    datas.Remove(datas.Where(d => d.TC == User.FindFirst(ClaimTypes.NameIdentifier).Value).FirstOrDefault());

                return Json(datas);
            }
            else return Json(null);
        }
        public JsonResult RandevuGetir(string selectedEntity)
        {
            if (selectedEntity != null)
            {
                int doktorid = int.Parse(selectedEntity);
                var datas = _context.Randevular.Where(e => e.DoktorId == doktorid && e.IsOpen == true  && e.Tarih>DateTime.Now).Select(d => new
                {
                    randevuid = d.RandevuId,
                    tarih = d.Tarih.ToString("dd.MM.yyyy HH:mm:ss"),
                    isOpen = d.IsOpen
                }).ToList();
                return Json(datas);
            }
            else return Json(null);
        }
    }
}
