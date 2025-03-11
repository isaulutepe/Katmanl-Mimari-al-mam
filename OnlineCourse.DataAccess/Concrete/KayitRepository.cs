using Microsoft.EntityFrameworkCore;
using OnlineCourse.DataAccess.Abstarct;
using OnlineCourse.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineCourse.DataAccess.Concrete
{
    public class KayitRepository : IKayitRepository
    {
        public Kayit Add(Kayit kayit)
        {
            using (var dbContext = new OnlineCourseDbContext())
            {
                dbContext.Add(kayit);
                dbContext.SaveChanges();
                return kayit;
            }
        }

        public void Delete(int id)
        {
            using (var dbContext = new OnlineCourseDbContext())
            {
                var deleted = GetById(id);
                dbContext.KursKayitTablosu.Remove(deleted);
                dbContext.SaveChanges();
            }
        }

        public List<Kayit> GetAll()
        {
            using (var dbContext = new OnlineCourseDbContext())
            {
                return dbContext.KursKayitTablosu.ToList();
            }
        }

        public Kayit GetById(int id)
        {
            using (var dbContext = new OnlineCourseDbContext())
            {
                var kayit = dbContext.KursKayitTablosu.Find(id);
                if (kayit == null)
                {
                    throw new Exception("Kayıt bulunamadı.");
                }
                return kayit;
            }
        }

        public Kayit GetByStudentAndCourse(int ogrenciId, int kursId)
        {
            using (var dbContext = new OnlineCourseDbContext())
            {
                return dbContext.KursKayitTablosu.FirstOrDefault(k => k.OgrenciId == ogrenciId && k.KursId == kursId);
            }

        }

        public Kayit Update(Kayit kayit)
        {
            using (var dbContext = new OnlineCourseDbContext())
            {
                dbContext.Update(kayit);
                dbContext.SaveChanges();
                return kayit;
            }
        }
    }
}
