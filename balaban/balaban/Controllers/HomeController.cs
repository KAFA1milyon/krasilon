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
            using (var db = new bContext())
            {
                List<Urun> u = db.Urunler.Include("UrunDetay").Include("UrunResimler").Include("UrunFiyatlar").Randomize().ToList();
                return View(u);
            }
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

            return View(urun.OrderBy(x => x.ID).ToPagedList(sayfa, 4));
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var urun = (from s in db.Urunler.Include("UrunDetay").Include("UrunResimler").Include("UrunFiyatlar")
                        where s.ID == id
                        select s).FirstOrDefault<Urun>();

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