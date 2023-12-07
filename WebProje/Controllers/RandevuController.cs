using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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
                Randevu _randevu=new Randevu();
                //_randevu=_context.Randevular.Where(r => r.RandevuId == int.Parse(randevu.Date)).FirstOrDefault();
                //_randevu.IsOpen = false;
                string apiUrl = "https://localhost:7268/api/ApiRandevu/RandevuKaydet";
                var postData = randevu;

                using (HttpClient client = new HttpClient())
                {
                    // JSON verilerini dönüştürme
                    string jsonData =JsonConvert.SerializeObject(postData);

                    // İstek başlıklarını ayarlama (eğer gerekiyorsa)
                    // client.DefaultRequestHeaders.Add("Authorization", "Bearer your-access-token");

                    // POST isteği gönderme
                    HttpResponseMessage response = await client.PostAsync(apiUrl, new StringContent(jsonData, Encoding.UTF8, "application/json"));

                    // İstek sonucunu işleme
                    if (response.IsSuccessStatusCode)
                    {
                        // Başarılı işlemler burada yapılabilir
                        string responseContent = await response.Content.ReadAsStringAsync();
                        ViewBag.ResponseData = responseContent;
                    }
                    else
                    {
                        // Hata durumları burada işlenebilir
                        ViewBag.ErrorMessage = "Web API isteği başarısız oldu. Durum kodu: " + response.StatusCode;
                    }
                }
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

        public IActionResult RandevuIptal(int RandevuId)
        {
            //var data = _context.Randevular.Find(RandevuId);
            //_context.Randevular.Remove(data);
            //_context.SaveChanges();
            return RedirectToAction("Anasayfa","Main");
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
            int doktorid=int.Parse(selectedEntity);
            var datas = _context.Randevular.Where(e => e.DoktorId == doktorid && e.IsOpen==true).Select(d => new
            {
                randevuid=d.RandevuId,
                tarih=d.Tarih.ToString("dd.MM.yyyy HH:mm:ss"),
                isOpen=d.IsOpen
            }).ToList();
            return Json(datas);
        }
    }
}
