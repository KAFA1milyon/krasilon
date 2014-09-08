using balaban.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using balaban.Models;
using System.Net;
using PagedList;

namespace balaban.Controllers
{
    public class HomeController : Controller
    {
        private bContext db = new bContext();
        public ActionResult Index()
        {
            //ViewBag.Urunler = db.Urunler.ToList();

            var urun = (from s in db.Urunler.Include("UrunDetay").Include("UrunResimler").Include("UrunFiyatlar")
                        select s).ToList();

            return View(urun);
        }
        public ActionResult Products()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Products(int sayfa = 1)
        {
            var urun = (from s in db.Urunler.Include("UrunDetay").Include("UrunResimler").Include("UrunFiyatlar")
                        select s).ToList();
 
            return View(urun.OrderBy(x => x.UrunAdi).ToPagedList(sayfa, 2));
        } 

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            //Urun urun = db.Urunler.Find(id);

            var urun = (from s in db.Urunler.Include("UrunDetay").Include("UrunResimler").Include("UrunFiyatlar")
                        where s.ID == id
                        select s).FirstOrDefault<Urun>();

            //urun.UrunDetay = db.UrunDetay.Where(x => x.ID == id).FirstOrDefault();
            //urun.UrunFiyatlar = db.UrunFiyatlari.Where(x => x.ID == id).ToList();
            //urun.UrunFiyatDetaylar = db.UrunFiyatDetaylari.Where(x => x.ID == id).ToList();
            //urun.UrunResimler = db.UrunResimleri.Where(x => x.ID == id).ToList();

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