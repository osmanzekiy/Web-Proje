using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using WebProje.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebProje.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize(Roles = "Hasta,Doktor,Admin")]
    public class ApiRandevuController : ControllerBase
    {
        // GET: api/<ApiRandevuController>
        [HttpGet]
        public IEnumerable<string> VeriGetir()
        {
            return new string[] { "value1", "value2" };
        }


        [HttpGet("{selectedEntity}")]
        public IActionResult DoktorGetir(string? selectedEntity)
        {
            HastaneContext _context=new HastaneContext();
            if (selectedEntity != null)
            {
                int bolumId = int.Parse(selectedEntity);
                var datas = _context.Doktorlar.Where(e => e.BolumId == bolumId).Select(x => new {x.Isim,x.Soyisim,x.TC,x.DoktorId}).ToList();
                string tcm = User.FindFirst(ClaimTypes.NameIdentifier).Value;
                if (datas.Any(d => d.TC == User.FindFirst(ClaimTypes.NameIdentifier).Value))
                    datas.Remove(datas.Where(d => d.TC == User.FindFirst(ClaimTypes.NameIdentifier).Value).FirstOrDefault());

                return Ok(datas);
            }
            else return null;
        }

        [HttpDelete("{id}")]
        [AllowAnonymous]
        public IActionResult DoktorSil(string? id)
        {
            HastaneContext _context = new HastaneContext();
            var doktor = _context.Doktorlar.Find(id);
            _context.Doktorlar.Remove(doktor);
            _context.SaveChanges();

            return Ok("İşlem Başarılı");
        }
    }
}
