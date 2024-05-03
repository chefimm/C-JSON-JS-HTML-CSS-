using System.ComponentModel.DataAnnotations;

namespace Kutuphane.Models
{
    public class BaseEntity
    {
        [Key]
        public int Id { get; set; }
    }
}
