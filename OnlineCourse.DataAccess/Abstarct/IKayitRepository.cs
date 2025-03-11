using OnlineCourse.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineCourse.DataAccess.Abstarct
{
    public interface IKayitRepository
    {
        Kayit Add(Kayit kayit);
        List<Kayit> GetAll();
        Kayit GetById(int id);
        Kayit GetByStudentAndCourse(int ogrenciId, int kursId); // 🎯 Aynı kursa tekrar kayıt kontrolü
        Kayit Update(Kayit kayit);
        void Delete(int id);
    }
}
