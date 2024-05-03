using Microsoft.EntityFrameworkCore;

namespace Kutuphane.Models
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {

        }
        DbSet<KategoriModel> Kategoriler { get; set; }
        DbSet<KitapModel> Kitaplar { get; set; }
        DbSet<OduncKitapModel> OduncKitaplar { get;set; }
        DbSet<UyeModel> Uyeler { get; set; }
        DbSet<YazarModel> Yazarlar { get; set; }
    }
}
