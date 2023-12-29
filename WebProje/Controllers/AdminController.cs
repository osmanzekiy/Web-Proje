using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using WebProje.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Data;
using Microsoft.AspNetCore.Authorization;

namespace WebProje.Controllers
{
    public class AdminController : Controller
    {
        private readonly HastaneContext _context;
        public AdminController(HastaneContext context)
        {
            _context = context;
        }
        [AllowAnonymous]
        public IActionResult Login()
        {
            return View();
        }
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Login(AdminLogin admin)
        {
            if(ModelState.IsValid)
            {
                if(_context.Adminler.Any(p=>p.Mail==admin.Email && p.Password == admin.Password))
                {
                    var _admin = _context.Adminler.Include(p=>p.Rol).Where(p => p.Mail == admin.Email && p.Password == admin.Password).FirstOrDefault();
                    List<Claim> claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.NameIdentifier, _admin.RolId.ToString()),
                        new Claim(ClaimTypes.Role,_admin.Rol.RolAdi.ToString()),
                        new Claim("Isim",_admin.Isim),
                        new Claim("Soyisim",_admin.Soyisim)

                    };
                    var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                    var authProperties = new AuthenticationProperties
                    {

                    };

                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                                                  new ClaimsPrincipal(claimsIdentity),
                                                  authProperties);
                    return RedirectToAction("AdminAnasayfa", "Admin");
                }
                else
                {
                    ModelState.AddModelError("Password","Kullanıcı Adı veya Şifre Hatalı!");
                }
                
            }
            return View(admin);
        }
        [Authorize(Roles ="Admin")]
        public IActionResult AdminSayfa()
        {
            ViewBag.Bölümler= new SelectList(_context.Bolumler.Select(e => new SelectListItem
            {
                Value = e.BolumId.ToString(),
                Text = e.BolumAdi
            }), "Value", "Text");
            return View();
        }

        [Authorize(Roles="Admin")]
        public IActionResult AdminAnasayfa()
        {
            var hastasay = _context.Hastalar.Count();
            var doktorsay = _context.Doktorlar.Count();
            ViewBag.hastavedoktor = "Sistemde Kayıtlı " + hastasay + " Adet Hasta " + doktorsay + " Adet Doktor Mevcut!";
            return View();
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult RandevuEkle(RandevuEkleViewModel model)
        {
            if (ModelState.IsValid && _context.Doktorlar.Any(r => r.DoktorId == int.Parse(model.Doktor)))
            {
                List<CalismaSaatleri> doktorsaatleri = _context.CalismaSaatleri.Include(r => r.Doktor).Where(r => r.DoktorId == int.Parse(model.Doktor)).ToList();
                var data = new[] { "Pazar", "Pazartesi", "Salı", "Çarşamba", "Perşembe", "Cuma", "Cumartesi" };
                var calismagunu = data[(int)(model.Tarih.DayOfWeek)];
                foreach(var item in doktorsaatleri)
                {
                    if (item.Gun == calismagunu && model.Tarih.TimeOfDay>item.Baslangic && model.Tarih.TimeOfDay<item.Bitis)
                    {
                        Randevu randevu = new Randevu();
                        randevu.DoktorId = int.Parse(model.Doktor);
                        randevu.Tarih = model.Tarih;
                        randevu.IsOpen = true;
                        _context.Randevular.Add(randevu);
                        _context.SaveChanges();
                        TempData["mesaj"] = "Başarıyla Eklendi!";
                        return RedirectToAction("AdminSayfa");
                    }
                }
                ViewBag.hata = "Lütfen Çalışma Saatlerini Dikkate Alınız !";
                
            }
             
                ViewBag.Bölümler = new SelectList(_context.Bolumler.Select(e => new SelectListItem
                {
                    Value = e.BolumId.ToString(),
                    Text = e.BolumAdi
                }), "Value", "Text");
                return View("AdminSayfa", model); 
        }
        [Authorize(Roles="Admin")]
        public IActionResult DoktorDuzen()
        {
            var data = _context.Doktorlar.Include(r=>r.Bolum).ToList();
            return View(data);
        }

        public IActionResult Delete(int id)
        {
            using (HttpClient client = new HttpClient())
            {
                string apiUrl = $"https://localhost:7268/api/ApiRandevu/DoktorSil/{id}";
                HttpResponseMessage response = client.DeleteAsync(apiUrl).Result;
                if (response.IsSuccessStatusCode)
                {
                    string apiResponse = response.Content.ReadAsStringAsync().Result;
                    TempData["mesaj"]= apiResponse;
                }
                else
                {
                    TempData["mesaj"] = "İşlem Gerçekleştirilemedi!";
                }
            }




            //    var doktor = _context.Doktorlar.Find(id);
            //_context.Doktorlar.Remove(doktor);
            //_context.SaveChanges();
            return RedirectToAction("DoktorDuzen");
        }

        public IActionResult DoktorEkle()
        {
            var datas = _context.Bolumler.ToList();
            ViewBag.Bolumler = new SelectList(datas.Select(e => new SelectListItem
            {
                Value = e.BolumId.ToString(),
                Text = e.BolumAdi
            }), "Value", "Text");

            return View();
        }

        [HttpPost]
        public IActionResult DoktorEkle(DoktorEkleViewModel model)
        {
            if(_context.Doktorlar.Any(x => x.TC == model.TC))
            {
                TempData["mesaj"] = "Girdiğiniz bilgiler sistemde mevcuttur!";
                return RedirectToAction("DoktorEkle");
            } 
            if (ModelState.IsValid)
            {
                Doktor d = new Doktor();
                d.Isim = model.Isim;
                d.Soyisim = model.Soyisim;
                d.TC = model.TC;
                d.Password = model.Password;
                d.RolId = 2;
                d.BolumId = model.BolumId;
                _context.Doktorlar.Add(d);
                _context.SaveChanges();
                TempData["mesajj"] = "İşlem Başarılı!";
                return RedirectToAction("DoktorEkle");
            }
            else
            {
                var datas = _context.Bolumler.ToList();
                ViewBag.Bolumler = new SelectList(datas.Select(e => new SelectListItem
                {
                    Value = e.BolumId.ToString(),
                    Text = e.BolumAdi
                }), "Value", "Text");
                return View();
            }
        }

    }
}
