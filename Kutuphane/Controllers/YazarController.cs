using Kutuphane.Models;
using Kutuphane.UnitOfWork;
using Microsoft.AspNetCore.Mvc;

namespace Kutuphane.Controllers
{
    public class YazarController : Controller
    {
        private readonly IUnitOfWork unitOfWork;
        public YazarController(IUnitOfWork unitOfWork) 
        {
            this.unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            var yazarlar = unitOfWork.GetRepositories<YazarModel>().GetAll();
            return View(yazarlar);
        }
        [HttpPost]
        public JsonResult EkleJson(string yzrAd) //Anlık eklenmiyor nasıl çözecem bulamadım.Sayfa yenilemem gerekiyor. ya ek bir sayfa ekliycem yada çözüm bulucam
        {
            YazarModel yazar = new YazarModel();
            yazar.Ad = yzrAd;
            var eklenenYazar = unitOfWork.GetRepositories<YazarModel>().Add(yazar);
            unitOfWork.SaveChanges();
            return Json(
                new
                {
                    Result = new
                    {
                        Id = eklenenYazar.Id,
                        Ad = eklenenYazar.Ad,
                        //KitapAdeti = eklenenKtg.Kitaplar.Count()
                    },
                    /*JsonRequestBehavior.AllowGet core 6 da kullanılmıyormuş ihtiyaç yok.*/
                }
            );

        }
        [HttpPost]
        public JsonResult GuncelleJson(int yzrId, string yzrAd)
        {
            var yazar = unitOfWork.GetRepositories<YazarModel>().GetById(yzrId);
            yazar.Ad = yzrAd;
            var durum = unitOfWork.SaveChanges();
            if (durum > 0)
            {
                return Json("1");
            }
            return Json("0");
        }
        public JsonResult SilJson(int yazarId)
        {
            unitOfWork.GetRepositories<YazarModel>().Delete(yazarId);
            var durum = unitOfWork.SaveChanges();
            if (durum > 0)
            {
                return Json("1");
            }
            return Json("0");
        }
    }
}
