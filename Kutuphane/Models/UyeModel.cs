using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Kutuphane.Models
{
    public class UyeModel : BaseEntity
    {
        [Required]
        [Column(TypeName = "varchar")]
        [MaxLength(60)]
        public string Ad { get; set; }
        [Required]
        [Column(TypeName = "varchar")]
        [MaxLength(60)]
        public string Soyad { get; set; }
        [Required]
        [Column(TypeName = "char")]
        [MaxLength(11), MinLength(11)]
        public string Tc { get; set; }
        [Required]
        [Column(TypeName = "char")]
        [MaxLength(11), MinLength(11)]
        public string Tel {  get; set; }
        [Required]
        public DateTime KayitTarihi { get; set; }
        [Required]
        [Column(TypeName = "nvarchar")]
        [MaxLength(60)]
        public string Adres {  get; set; }
        public virtual List<OduncKitapModel> OduncKitaplar { get; set; }
    }
}
