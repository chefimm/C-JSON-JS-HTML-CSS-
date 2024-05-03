using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kutuphane.Models
{
    public class YazarModel : BaseEntity
    {
        [Required]
        [Column(TypeName = "varchar")]
        [MaxLength(50)]
        public string Ad {  get; set; }
        public virtual List<KitapModel> Kitaplar { get; set; }
    }
}
