using Kutuphane.Models;
using Kutuphane.UnitOfWork;
using Microsoft.AspNetCore.Mvc;

namespace Kutuphane.Controllers
{
    public class KitapController : Controller
    {
        private readonly IUnitOfWork unitOfWork;
        public KitapController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            var kitaplar = unitOfWork.GetRepositories<KitapModel>().GetAll();
            return View(kitaplar);
        }
        public IActionResult Ekle() 
        {
            ViewBag.Kategoriler = unitOfWork.GetRepositories<KategoriModel>().GetAll();
            ViewBag.Yazarlar = unitOfWork.GetRepositories<YazarModel>().GetAll();
            return View();
        }

        [HttpPost]
        public JsonResult EkleJson(string[] kategoriler, string yazar, string kitapAd, string kitapAdet, string Isbn)
        {
            if (kategoriler != null && !string.IsNullOrEmpty(yazar) && !string.IsNullOrEmpty(kitapAd) && !string.IsNullOrEmpty(kitapAdet) && !string.IsNullOrEmpty(Isbn))
            {
                List<KategoriModel> k = new List<KategoriModel>();
                foreach (var kategoriId in kategoriler)
                {
                    var kategoriID = Convert.ToInt32(kategoriId);
                    var kategori = unitOfWork.GetRepositories<KategoriModel>().GetById(kategoriID);
                    k.Add(kategori);
                }

                KitapModel kitap = new KitapModel();
                kitap.Ad = kitapAd;
                kitap.Adet = Convert.ToInt32(kitapAdet);
                kitap.YazarId = Convert.ToInt32(yazar);
                kitap.Isbn = Isbn;
                kitap.Kategoriler = k;
                kitap.EklenmeTarihi = DateTime.Now;
                unitOfWork.GetRepositories<KitapModel>().Add(kitap);
                var durum = unitOfWork.SaveChanges();

                if (durum > 0)
                {
                    return Json("1");
                }
                else
                {
                    return Json("0");
                }
            }
            else
            {
                return Json("bosOlamaz");
            }
        }

        /*[HttpPost]
        public JsonResult EkleJson(string[] kategoriler, string yazar, string kitapAd, string kitapAdet, string kitapIsbn)
        {
            if (kategoriler != null && !string.IsNullOrEmpty(yazar) && !string.IsNullOrEmpty(kitapAd) && !string.IsNullOrEmpty(kitapAdet) && !string.IsNullOrEmpty(kitapIsbn))
            {
                List<KategoriModel> k = new List<KategoriModel>();
                foreach (var kategoriId in kategoriler)
                {
                    var kategoriID = Convert.ToInt32(kategoriId);
                    var kategori = unitOfWork.GetRepositories<KategoriModel>().GetById(kategoriID);
                    k.Add(kategori);
                }

                KitapModel kitap = new KitapModel();
                kitap.Ad = kitapAd; 
                kitap.Adet = Convert.ToInt32(kitapAdet);
                kitap.YazarId = Convert.ToInt32(yazar);
                kitap.Isbn = kitapIsbn;
                kitap.Kategoriler = k;
                kitap.EklenmeTarihi = DateTime.Now;

                unitOfWork.GetRepositories<KitapModel>().Add(kitap);

                var durum = unitOfWork.SaveChanges();
                if (durum > 0)
                {
                    return Json("1");
                }
                else
                {
                    return Json("0");
                }
            }
            else
            {
                return Json("bosOlamaz");
            }
        }
        */

    }
}
