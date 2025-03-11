using OnlineCourse.Entities;


namespace OnlineCourse.DataAccess.Abstarct
{
    public interface IOgrenciRepository
    {
        //Öğrenci ile ilgili yapılacak işlemler burada tanımlanacak.
        List<Ogrenci> GetAllStudents(); //Bütün öğrencileri listele
        Ogrenci GetOgrenciById(int id);// İd ye sahip öğrenciyi getir.
        Ogrenci CreateStudent(Ogrenci ogrenci); //Yeni öğrenci ekle
        Ogrenci UpdateStudent(Ogrenci ogrenci); //Bilgileri girilen ögrenciyi güncelle ve geri döndür.
        void DeleteStudent(int id); //Öğrenciyi sil.
    }
}
