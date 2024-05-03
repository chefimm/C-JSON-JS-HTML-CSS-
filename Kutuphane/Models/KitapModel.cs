using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Kutuphane.Models
{
    public class KitapModel : BaseEntity
    {
        [Required]
        [Column(TypeName = "varchar")]
        [MaxLength(60)]
        public string Ad {  get; set; }
        [Required]
        [Column(TypeName = "varchar")]
        [MaxLength(60)]
        public string Isbn { get; set; }
        [Required]
        public int Adet { get; set; }
        [Required]
        public DateTime EklenmeTarihi { get; set; }
        [Required]
        public int YazarId { get; set; }
        public virtual YazarModel Yazar { get; set; }
        public virtual List<KategoriModel> Kategoriler { get; set; }

    }
}
