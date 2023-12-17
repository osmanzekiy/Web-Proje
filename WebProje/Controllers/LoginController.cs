using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using WebProje.Models;
using NuGet.Protocol.Plugins;
using Microsoft.EntityFrameworkCore;

namespace WebProje.Controllers
{
    public class LoginController : Controller
    {
        private readonly HastaneContext _context;

        public LoginController(HastaneContext context)
        {
            _context = context;
        }



        [HttpGet]
        public IActionResult GirisYap()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> GirisYap(Login login)
        {
            bool isDoktor = false;
            if (ModelState.IsValid)
            {
            string tc = login.TC;
            string password = login.Sifre;
            List<Claim> claims;
          
            
            if(_context.Doktorlar.Any(d=>d.TC==tc && d.Password==password))
            {
             var d=_context.Doktorlar.Include(p=>p.Rol).Where(d=>d.TC==tc && d.Password==password).FirstOrDefault();
                     claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.NameIdentifier, tc),
                        new Claim(ClaimTypes.Role,d.Rol.RolAdi.ToString()),
                        new Claim("Isim",d.Isim),
                        new Claim("Soyisim",d.Soyisim)
                       
                    };
                    isDoktor=true;
                }
            else if(_context.Hastalar.Any(h=>h.TC==tc && h.Password==password))
            {
              var h=_context.Hastalar.Include(p=>p.Rol).Where(h=>h.TC==tc && h.Password==password).FirstOrDefault();
                     claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.NameIdentifier, tc),
                        new Claim(ClaimTypes.Role,h.Rol.RolAdi.ToString()),
                        new Claim("Isim",h.Isim),
                        new Claim("Soyisim",h.Soyisim)
               
                    };
                    isDoktor = false;
                }
            else
            
                
                
                {
                    ModelState.AddModelError("Sifre", "Kullanıcı Adı veya Şifre Hatalı !");
                    return View();
            }

                    var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                    var authProperties = new AuthenticationProperties
                    {
                       
                    };

                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                                                  new ClaimsPrincipal(claimsIdentity),
                                                  authProperties);
                if (isDoktor)
                {
                    return RedirectToAction("Anasayfa", "Doktor");
                }

                    return RedirectToAction("Anasayfa", "Main");
                
               
            }
            else
            {
                ModelState.AddModelError("Sifre", "Kullanıcı Adı veya Şifre Hatalı !");
            }


            return View();
        }

        public async Task<IActionResult> CikisYap()
        {
            await HttpContext.SignOutAsync();

            return RedirectToAction("GirisYap");
        }

        public IActionResult Hata()
        {
            return View();
        }


        public IActionResult KayitOl()
        {
            return View();
        }

        [HttpPost]
        public IActionResult KayitOl(KayitViewModel hasta)
        {
            
                        
            if (ModelState.IsValid)
            {
                Hasta _hasta = new Hasta()
                {
                    Isim = hasta.Isim,
                    Soyisim = hasta.Soyisim,
                    TC = hasta.TC,
                    Cinsiyet = hasta.Cinsiyet,
                    Password = hasta.Password,
                    Telefon = hasta.Telefon,
                    RolId = 3
                };
                _context.Hastalar.Add(_hasta);
                _context.SaveChanges();

            }
            return View(hasta);
        }


    }
}
