using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineCourse.Entities
{
    //Hangi öğrencinin hangi kursa kayıt olduğunu tutacak olan tablo.
    public class Kayit
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int OgrenciId { get; set; }
 

        public int KursId { get; set; }

        public DateTime KayitTarihi { get; set; }
    }
}
