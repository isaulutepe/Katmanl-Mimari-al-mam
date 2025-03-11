using Microsoft.AspNetCore.Mvc;
using OnlineCourse.Business.Abstract;
using OnlineCourse.Entities;

namespace OnlineCourse.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KursController : Controller
    {
        private IKursService _kursService;
        public KursController(IKursService kursService)
        {
            _kursService = kursService;
        }

        // Tüm kursları getir
        [HttpGet]
        public IActionResult Get()
        {
            var courses = _kursService.GetAllCourses();
            if (courses == null || courses.Count == 0)
            {
                return NotFound("Kurs bulunamadı."); // 404 Not Found
            }
            return Ok(courses); // 200 OK
        }
        // ID'ye göre kurs getir
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var course = _kursService.GetCourseById(id);
            if (course == null)
            {
                return NotFound($"ID {id} numaralı kurs bulunamadı."); // 404 Not Found
            }
            return Ok(course); // 200 OK
        }
        // Yeni kurs oluştur
        [HttpPost]
        public IActionResult Create([FromBody] Kurs course)
        {
            if (course == null)
            {
                return BadRequest("Geçersiz kurs verisi."); // 400 Bad Request
            }

            var createdCourse = _kursService.CreateCourse(course);
            return CreatedAtAction(nameof(GetById), new { id = createdCourse.Id }, createdCourse); // 201 Created
        }
        // Kurs bilgilerini güncelle
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Kurs course)
        {
            if (course == null || course.Id != id)
            {
                return BadRequest("ID uyuşmazlığı veya geçersiz veri."); // 400 Bad Request
            }

            var existingCourse = _kursService.GetCourseById(id);
            if (existingCourse == null)
            {
                return NotFound($"ID {id} numaralı kurs bulunamadı."); // 404 Not Found
            }

            var updatedCourse = _kursService.UpdateCourse(course);
            return Ok(updatedCourse); // 200 OK
        }
        // Kurs sil
        [HttpDelete("{id}")]
        public IActionResult DeleteById(int id)
        {
            var course = _kursService.GetCourseById(id);
            if (course == null)
            {
                return NotFound($"ID {id} numaralı kurs bulunamadı."); // 404 Not Found
            }

            _kursService.DeleteCourse(id);
            return NoContent(); // 204 No Content
        }
    }
}
