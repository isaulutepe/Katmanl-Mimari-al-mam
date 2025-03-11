using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineCourse.Entities
{
    public class Kurs
    {

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [StringLength(50)]
        public string CourseName { get; set; }
        [StringLength(50)]
        public string CourseDescription { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "Course price cannot be negative")]
        public decimal CoursePrice { get; set; }

        [CustomValidation(typeof(Kurs), "ValidateCourseDates")]
        public DateTime CourseBeginDate { get; set; }

        [CustomValidation(typeof(Kurs), "ValidateCourseDates")]
        public DateTime CourseFinishDate { get; set; }
        public static ValidationResult ValidateCourseDates(DateTime beginDate, ValidationContext context)
        {
            var kurs = context.ObjectInstance as Kurs;
            if (kurs.CourseBeginDate >= kurs.CourseFinishDate)
            {
                return new ValidationResult("Course begin date must be before finish date.");
            }
            return ValidationResult.Success;
        }
        [NotMapped]
        public bool IsCourseActive => DateTime.Now >= CourseBeginDate && DateTime.Now <= CourseFinishDate;
    }
}
