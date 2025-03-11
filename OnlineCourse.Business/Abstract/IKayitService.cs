using OnlineCourse.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineCourse.Business.Abstract
{
    public interface IKayitService
    {
        Kayit KayitOl(int ogrenciId, int kursId);
        List<Kayit> TumKayitlariGetir();
        Kayit GetById(int id);
        void Delete(int id);
        Kayit Update(Kayit kayit);
    }
}
