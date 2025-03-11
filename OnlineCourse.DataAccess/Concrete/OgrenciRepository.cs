using Microsoft.EntityFrameworkCore;
using OnlineCourse.DataAccess.Abstarct;
using OnlineCourse.Entities;


namespace OnlineCourse.DataAccess.Concrete
{
    public class OgrenciRepository : IOgrenciRepository
    {
        //Veritabanı işlemleri DataAccess içinde yapılır
        public Ogrenci CreateStudent(Ogrenci ogrenci)
        {
            using (var dbContext = new OnlineCourseDbContext())
            {
                try
                {
                    dbContext.Add(ogrenci);
                    dbContext.SaveChanges();
                    return ogrenci;
                }
                catch (Exception ex)
                {
                    throw new Exception("Öğrenci eklenirken hata oluştu.", ex);
                }
            }
        }

        public void DeleteStudent(int id)
        {
            using (var dbContext = new OnlineCourseDbContext())
            {
                var deletedValue = dbContext.OgrenciTablosu.Find(id);
                if (deletedValue != null)
                {
                    dbContext.Remove(deletedValue);
                    dbContext.SaveChanges();
                }
                else
                {
                    throw new Exception("Silinecek öğrenci bulunamadı.");
                }
            }

        }
        public List<Ogrenci> GetAllStudents()
        {
            using (var dbContext = new OnlineCourseDbContext())
            {
                return dbContext.OgrenciTablosu.AsNoTracking().ToList();
            }
        }

        public Ogrenci GetOgrenciById(int id)
        {
            using (var dbContext = new OnlineCourseDbContext())
            {
                var ogrenci = dbContext.OgrenciTablosu.Find(id);
                if (ogrenci == null)
                {
                    throw new Exception("Öğrenci bulunamadı.");
                }
                return ogrenci;
            }
        }

        public Ogrenci UpdateStudent(Ogrenci ogrenci)
        {
            using (var dbContext = new OnlineCourseDbContext())
            {
                var existingStudent = dbContext.OgrenciTablosu.Find(ogrenci.Id);
                if (existingStudent != null)
                {
                    dbContext.Entry(existingStudent).CurrentValues.SetValues(ogrenci);
                    dbContext.SaveChanges();
                    return ogrenci;
                }
                else
                {
                    throw new Exception("Güncellenecek öğrenci bulunamadı.");
                }
            }
        }
    }
}
