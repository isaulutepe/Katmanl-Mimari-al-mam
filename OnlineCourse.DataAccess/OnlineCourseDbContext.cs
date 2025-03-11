using Microsoft.EntityFrameworkCore;
using OnlineCourse.Entities;


namespace OnlineCourse.DataAccess
{
    public class OnlineCourseDbContext:DbContext
    {
        //Veritabanına bağlanma işlemi

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS; DataBase=OnlineCourseDb; uid=jesus1; pwd=30032001; TrustServerCertificate=True");
        }

        //Veritabanı tabloları
        public DbSet<Ogrenci> OgrenciTablosu { get; set; }
        public DbSet<Kurs> KursTablosu { get; set; }
        public DbSet<Kayit> KursKayitTablosu { get; set; }
    }
}
