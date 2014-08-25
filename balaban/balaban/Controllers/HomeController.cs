using balaban.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace balaban.Controllers
{
    public class HomeController : Controller
    {
        private bContext db = new bContext();
        public ActionResult Index()
        {
            ViewBag.Title = db.Urunler.First().UrunAdi;

            return View();
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