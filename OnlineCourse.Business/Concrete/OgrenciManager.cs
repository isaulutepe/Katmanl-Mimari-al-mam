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
    public class OgrenciManager : IOgrenciService
    {
        private IOgrenciRepository _ogrencirepository;
        public OgrenciManager(IOgrenciRepository ogrenciRepository)
        {
            _ogrencirepository = ogrenciRepository;
        }
        public Ogrenci CreateStudent(Ogrenci ogrenci)
        {
            return _ogrencirepository.CreateStudent(ogrenci);
        }

        public void DeleteStudent(int id)
        {
            _ogrencirepository.DeleteStudent(id);
        }

        public List<Ogrenci> GetAllStudents()
        {
            return _ogrencirepository.GetAllStudents();
        }

        public Ogrenci GetOgrenciById(int id)
        {
            return _ogrencirepository.GetOgrenciById(id);
        }

        public Ogrenci UpdateStudent(Ogrenci ogrenci)
        {
            return _ogrencirepository.UpdateStudent(ogrenci);
        }
    }
}
