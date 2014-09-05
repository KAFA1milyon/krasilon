using balaban.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using balaban.Models;
using System.Net;

namespace balaban.Controllers
{
    public class HomeController : Controller
    {
        private bContext db = new bContext();
        public ActionResult Index()
        {
            ViewBag.Urunler = db.Urunler.ToList();

            return View();
        }
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Urun urun = db.Urunler.Find(id);
            urun.UrunDetaylar = db.UrunDetaylari.Where(x => x.ID==id).ToList();
            urun.UrunFiyatlar = db.UrunFiyatlari.Where(x => x.ID == id).ToList();
            urun.UrunFiyatDetaylar = db.UrunFiyatDetaylari.Where(x => x.ID == id).ToList();
            urun.UrunResimler = db.UrunResimleri.Where(x => x.ID == id).ToList();

            if (urun == null)
            {
                return HttpNotFound();
            }
            return View(urun);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}