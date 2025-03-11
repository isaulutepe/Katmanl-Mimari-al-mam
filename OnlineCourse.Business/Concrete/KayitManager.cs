using OnlineCourse.Business.Abstract;
using OnlineCourse.DataAccess.Abstarct;
using OnlineCourse.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineCourse.Business.Concrete
{
    public class KayitManager : IKayitService
    {
        private IKayitRepository _kayitRepository;
        private IKursRepository _kursRepository;
        private IOgrenciRepository _ogrenciRepository;
        public KayitManager(IKayitRepository kayitRepository, IKursRepository kursRepository, IOgrenciRepository ogrenciRepository)
        {
            _kayitRepository = kayitRepository;
            _kursRepository = kursRepository;
            _ogrenciRepository = ogrenciRepository;
        }

        public void Delete(int id)
        {
            _kayitRepository.Delete(id);
        }

        public Kayit GetById(int id)
        {
            return _kayitRepository.GetById(id);
        }

        public Kayit KayitOl(int ogrenciId, int kursId)
        {
            var ogrenci = _ogrenciRepository.GetOgrenciById(ogrenciId);
            var kurs = _kursRepository.GetCourseById(kursId);

            if (ogrenci == null || kurs == null)
                throw new Exception("Öğrenci veya kurs bulunamadı.");

            if (_kayitRepository.GetByStudentAndCourse(ogrenciId, kursId) != null)
                throw new Exception("Öğrenci zaten bu kursa kayıtlı!");

            if (ogrenci.Balance < kurs.CoursePrice)
                throw new Exception("Bakiyeniz yetersiz!");

            // 🎯 Kayıt işlemi
            ogrenci.Balance -= kurs.CoursePrice;
            _ogrenciRepository.UpdateStudent(ogrenci);

            var yeniKayit = new Kayit
            {
                OgrenciId = ogrenciId,
                KursId = kursId,
                KayitTarihi = DateTime.UtcNow

            };

            return _kayitRepository.Add(yeniKayit);
        }

        public List<Kayit> TumKayitlariGetir()
        {
            return _kayitRepository.GetAll();   
        }

        public Kayit Update(Kayit kayit)
        {
            return _kayitRepository.Update(kayit);
        }
    }
}
