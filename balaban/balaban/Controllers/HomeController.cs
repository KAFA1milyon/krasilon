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
                List<Urun> u = db.Urunler.Include("UrunDetay").Include("UrunResimler").Include("UrunFiyatlar").Where(x =>
                    x.UrunResimler.Count > 0 &
                    x.UrunFiyatlar.Count > 0).Randomize().ToList();
                return View(u);
            }
        }
        public ActionResult Products()
        {
            return View();
        }
        //[HttpGet]
        //public ActionResult Products(int page = 1)
        //{
        //    var urun = (from s in db.Urunler.Include("UrunDetay").Include("UrunResimler").Include("UrunFiyatlar")
        //                select s).ToList();

        //    return View(urun.OrderBy(x => x.ID).ToPagedList(page, 4));
        //}
         
        [HttpGet]
        public ViewResult Products(string sortOrder, string currentFilter, string searchString, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
 
            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;

            IEnumerable<Urun>  uruns = (from s in db.Urunler.Include("UrunDetay").Include("UrunResimler").Include("UrunFiyatlar")select s).ToList();
            if (!String.IsNullOrEmpty(searchString))
            {
                uruns = uruns.Where(s => s.UrunAdi.ToUpper().Contains(searchString.ToUpper()));
            }
            switch (sortOrder)
            {
                case "Name":
                    uruns = uruns.OrderBy(s => s.UrunAdi);
                    break;
                case "Name_desc":
                    uruns = uruns.OrderByDescending(s => s.UrunAdi);
                    break;
                case "Price":
                    uruns = uruns.OrderBy(s => s.UrunFiyatlar.First().Fiyat);  
                    //uruns = (from m in db.Urunler
                    //         join ms in db.UrunFiyatlari on m.ID equals ms.ID
                    //         orderby ms.Fiyat ascending
                    //         select m);

                    break;
                case "Price_desc":
                    uruns = uruns.OrderByDescending(s => s.UrunFiyatlar.First().Fiyat); 

                    //uruns = (from m in db.Urunler
                    //         join ms in db.UrunFiyatlari on m.ID equals ms.ID
                    //         orderby ms.Fiyat descending
                    //         select m);
                    break;
                case "Date":
                    uruns = uruns.OrderBy(s => s.KayitTarihi);
                    break;
                case "Date_desc":
                    uruns = uruns.OrderByDescending(s => s.KayitTarihi);
                    break;
                default:  // Name ascending 
                    uruns = uruns.OrderBy(s => s.UrunAdi);
                    break;
            }

            int pageSize = 3;
            int pageNumber = (page ?? 1);
            return View(uruns.ToPagedList(pageNumber, pageSize));
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