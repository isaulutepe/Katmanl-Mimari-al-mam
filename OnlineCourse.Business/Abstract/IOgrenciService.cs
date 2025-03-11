using OnlineCourse.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineCourse.Business.Abstract
{
    public interface IOgrenciService
    {
        List<Ogrenci> GetAllStudents(); 
        Ogrenci GetOgrenciById(int id);
        Ogrenci CreateStudent(Ogrenci ogrenci);
        Ogrenci UpdateStudent(Ogrenci ogrenci);
        void DeleteStudent(int id);
    }
}
