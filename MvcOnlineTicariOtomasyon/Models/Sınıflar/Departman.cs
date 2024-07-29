using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MvcOnlineTicariOtomasyon.Models.Sınıflar
{
    public class Departman
    {
        [Key]
        public int Departmanid { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string DepartmanAd { get; set; }
        public bool Durum { get; set; }
        public ICollection<Personel> Personels { get; set; }
    }
}