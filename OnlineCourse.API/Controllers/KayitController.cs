using Microsoft.AspNetCore.Mvc;
using OnlineCourse.Business.Abstract;
using OnlineCourse.Entities;

namespace OnlineCourse.API.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class KayitController : Controller
    {
        private IKayitService _kayitService;
        public KayitController(IKayitService kayitService)
        {
            _kayitService = kayitService;
        }

        [HttpPost]
        public IActionResult KayitOl(int ogrenciId, int kursId)
        {
            try
            {
                var kayit = _kayitService.KayitOl(ogrenciId, kursId);
                return Ok(kayit);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet]
        public IActionResult TumKayitlariGetir()
        {
            var kayitlar = _kayitService.TumKayitlariGetir();
            return Ok(kayitlar);
        }
        [HttpGet("{id}")]
        public IActionResult GetByid(int id)
        {
            var kayit = _kayitService.GetById(id);
            return Ok(kayit);
        }
        [HttpDelete("{id}")]
        public void KayitSil(int id)
        {
            if (id !=0 && id !=null)
            {
                _kayitService.Delete(id);
            }
        }
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody]Kayit kayit)
        {
            if (kayit == null || kayit.Id != id)
            {
                return BadRequest("ID uyuşmazlığı veya geçersiz veri."); // 400 Bad Request
            }

            var existing = _kayitService.GetById(id);
            if (existing== null)
            {
                return NotFound($"ID {id} numaralı kayit bulunamadı."); // 404 Not Found
            }

            var updated = _kayitService.Update(kayit);
            return Ok(updated); // 200 OK
        }
    }
}
