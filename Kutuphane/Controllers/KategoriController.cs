using Kutuphane.Models;
using Kutuphane.UnitOfWork;
using Microsoft.AspNetCore.Mvc;

namespace Kutuphane.Controllers
{
    public class KategoriController : Controller
    {
         private readonly IUnitOfWork unitOfWork;
        public KategoriController(IUnitOfWork unitOfWork) 
        {
            this.unitOfWork =  unitOfWork;
        }
        public IActionResult Index()
        {
            var kategoriler = unitOfWork.GetRepositories<KategoriModel>().GetAll();
            return View(kategoriler);
        }
        [HttpPost]
        public JsonResult EkleJson(string ktgAd) //Anlık eklenmiyor nasıl çözecem bulamadım.Sayfa yenilemem gerekiyor. ya ek bir sayfa ekliycem yada çözüm bulucam
        {
            KategoriModel ktgri = new KategoriModel();
            ktgri.Ad = ktgAd;
            var eklenenKtg = unitOfWork.GetRepositories<KategoriModel>().Add(ktgri);
            unitOfWork.SaveChanges();
            return Json(
                new 
                {
                    Result = new
                    {
                        Id = eklenenKtg.Id,
                        Ad = eklenenKtg.Ad,
                        //KitapAdeti = eklenenKtg.Kitaplar.Count()
                    },
                    /*JsonRequestBehavior.AllowGet core 6 da kullanılmıyormuş ihtiyaç yok.*/
                }
            );

        }
        [HttpPost]
        public JsonResult GuncelleJson(int ktgId, string ktgAd)
        {
            var kategori = unitOfWork.GetRepositories<KategoriModel>().GetById(ktgId);
            kategori.Ad = ktgAd;
            var durum = unitOfWork.SaveChanges();
            if (durum > 0) 
            {
                return Json("1"); 
            }
            return Json("0");            
        }
        public JsonResult SilJson(int ktgId) 
        {
            unitOfWork.GetRepositories<KategoriModel>().Delete(ktgId);
            var durum = unitOfWork.SaveChanges();
            if (durum > 0)
            {
                return Json("1");
            }
            return Json("0");
        }
    }
}
