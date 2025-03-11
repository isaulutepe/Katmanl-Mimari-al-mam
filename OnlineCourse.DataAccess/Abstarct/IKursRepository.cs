using OnlineCourse.Entities;


namespace OnlineCourse.DataAccess.Abstarct
{
    public interface IKursRepository
    {
        List<Kurs> GetAllCourses(); // (GetAllCourse → GetAllCourses)
        Kurs GetCourseById(int id); // (GetCoursById → GetCourseById)
        Kurs CreateCourse(Kurs course);
        Kurs UpdateCourse(Kurs course);
        void DeleteCourse(int id);
    }
}
