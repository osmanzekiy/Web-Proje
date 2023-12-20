using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
            var myId=_context.Doktorlar.Where(t=>t.TC== User.FindFirst(ClaimTypes.NameIdentifier).Value).Select(a=>a.DoktorId).FirstOrDefault();
            var randevular=_context.Randevular.Include(r=>r.Doktor).Include(r=>r.Hasta).Where(x=>x.DoktorId==myId && x.HastaId!=null && x.Tarih>DateTime.Now).ToList();
            ViewBag.BuSeneVerilenRandevu = _context.Randevular.Where(a => a.DoktorId == myId && a.IsOpen == false).Count();
            return View(randevular);
        }
    }
}
