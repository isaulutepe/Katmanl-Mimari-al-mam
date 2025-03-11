using OnlineCourse.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineCourse.Business.Abstract
{
    public interface IKursService
    {
        List<Kurs> GetAllCourses(); 
        Kurs GetCourseById(int id); 
        Kurs CreateCourse(Kurs course);
        Kurs UpdateCourse(Kurs course);
        void DeleteCourse(int id);
    }
}
