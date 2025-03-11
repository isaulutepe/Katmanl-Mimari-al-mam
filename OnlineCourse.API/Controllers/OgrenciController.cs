using Microsoft.AspNetCore.Mvc;
using OnlineCourse.Business.Abstract;
using OnlineCourse.Entities;

namespace OnlineCourse.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OgrenciController : Controller
    {
        private IOgrenciService _ogrenciService;
        public OgrenciController(IOgrenciService ogrenciService)
        {
            _ogrenciService = ogrenciService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var students = _ogrenciService.GetAllStudents();
            return Ok(students); // 200 OK
        }

        // Belirli ID'ye sahip öğrenciyi getir
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var student = _ogrenciService.GetOgrenciById(id);
            if (student == null)
            {
                return NotFound($"ID {id} numaralı öğrenci bulunamadı."); // 404 Not Found
            }
            return Ok(student); // 200 OK
        }
        // Yeni öğrenci ekle
        [HttpPost]
        public IActionResult Post([FromBody] Ogrenci ogrenci)
        {
            if (ogrenci == null)
            {
                return BadRequest("Geçersiz öğrenci verisi."); // 400 Bad Request
            }

            var createdStudent = _ogrenciService.CreateStudent(ogrenci);
            return CreatedAtAction(nameof(Get), new { id = createdStudent.Id }, createdStudent); // 201 Created
        }
        // Öğrenci bilgilerini güncelle
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Ogrenci ogrenci)
        {
            if (ogrenci == null || ogrenci.Id != id)
            {
                return BadRequest("ID uyuşmazlığı veya geçersiz veri."); // 400 Bad Request
            }

            var existingStudent = _ogrenciService.GetOgrenciById(id);
            if (existingStudent == null)
            {
                return NotFound($"ID {id} numaralı öğrenci bulunamadı."); // 404 Not Found
            }

            var updatedStudent = _ogrenciService.UpdateStudent(ogrenci);
            return Ok(updatedStudent); // 200 OK
        }
        // Öğrenci sil
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var student = _ogrenciService.GetOgrenciById(id);
            if (student == null)
            {
                return NotFound($"ID {id} numaralı öğrenci bulunamadı."); // 404 Not Found
            }

            _ogrenciService.DeleteStudent(id);
            return NoContent(); // 204 No Content
        }

    }
}
