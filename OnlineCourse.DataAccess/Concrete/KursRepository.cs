using Microsoft.EntityFrameworkCore;
using OnlineCourse.DataAccess.Abstarct;
using OnlineCourse.Entities;

namespace OnlineCourse.DataAccess.Concrete
{
    public class KursRepository : IKursRepository
    {
        public Kurs CreateCourse(Kurs course)
        {
            using (var dbContext = new OnlineCourseDbContext())
            {
                try
                {
                    dbContext.Add(course);
                    dbContext.SaveChanges();
                    return course;
                }
                catch (Exception ex)
                {
                    throw new Exception("Kurs eklenirken hata oluştu.", ex);
                }
            }
        }

        public void DeleteCourse(int id)
        {
            using (var dbContext = new OnlineCourseDbContext())
            {
                var deleteCourse = dbContext.KursTablosu.Find(id);
                if (deleteCourse != null)
                {
                    dbContext.Remove(deleteCourse);
                    dbContext.SaveChanges();
                }
                else
                {
                    throw new Exception("Silinecek kurs bulunamadı.");
                }
            }
        }
        public List<Kurs> GetAllCourses()
        {
            using (var dbContext = new OnlineCourseDbContext())
            {
                return dbContext.KursTablosu.AsNoTracking().ToList();
            }
        }

        public Kurs GetCourseById(int id)
        {
            using (var dbContext = new OnlineCourseDbContext())
            {
                var course = dbContext.KursTablosu.Find(id);
                if (course == null)
                {
                    throw new Exception("Kurs bulunamadı.");
                }
                return course;
            }
        }

        public Kurs UpdateCourse(Kurs course)
        {
            using (var dbContext = new OnlineCourseDbContext())
            {
                var existingCourse = dbContext.KursTablosu.Find(course.Id);
                if (existingCourse != null)
                {
                    dbContext.Entry(existingCourse).CurrentValues.SetValues(course);
                    dbContext.SaveChanges();
                    return course;
                }
                else
                {
                    throw new Exception("Güncellenecek kurs bulunamadı.");
                }
            }
        }
    }
}
