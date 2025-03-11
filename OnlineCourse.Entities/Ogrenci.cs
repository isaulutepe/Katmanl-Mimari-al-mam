using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineCourse.Entities
{
    public class Ogrenci
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)] //Anahtar alan olacak
        public int Id { get; set; }
        [StringLength(50)]
        public string Name { get; set; }
        [StringLength(50)]
        public string SureName { get; set; }
        [StringLength(50)]
        [RegularExpression(@"^[^@\s]+@[^@\s]+\.[^@\s]+$", ErrorMessage = "Invalid email format")] //E mail doğrulaması için.
        public string Email { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "Balance cannot be negative")]
        public decimal Balance { get; set; }

    }
}
