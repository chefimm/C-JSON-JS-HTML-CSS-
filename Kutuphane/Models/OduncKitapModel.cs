using System.ComponentModel.DataAnnotations;

namespace Kutuphane.Models
{
    public class OduncKitapModel : BaseEntity
    {
        [Required]
        public int KitapId { get; set; }
        [Required]
        public int UyeId { get; set; }
        [Required]
        public DateTime AlisTarihi { get; set; }
        public DateTime ? GetirdigiTarihi { get; set; }

    }
}
