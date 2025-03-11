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
    public class KursManager : IKursService
    {
        private IKursRepository _kursRepository;

        public KursManager(IKursRepository kursRepository)
        {
            _kursRepository = kursRepository;
        }
        public Kurs CreateCourse(Kurs course)
        {
            return _kursRepository.CreateCourse(course);
        }

        public void DeleteCourse(int id)
        {
            _kursRepository.DeleteCourse(id);
        }

        public List<Kurs> GetAllCourses()
        {
            return _kursRepository.GetAllCourses();
        }

        public Kurs GetCourseById(int id)
        {
            return _kursRepository.GetCourseById(id);
        }

        public Kurs UpdateCourse(Kurs course)
        {
            return _kursRepository.UpdateCourse(course);
        }
    }
}
