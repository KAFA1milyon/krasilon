using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using balaban.Models;
using balaban.DAL;

namespace balaban.Areas.Yonetim.Controllers
{
    public class UrunFiyatDetayController : Controller
    {
        private bContext db = new bContext();

        // GET: /Yonetim/UrunFiyatDetay/
        public ActionResult Index()
        {
            var urunfiyatdetaylari = db.UrunFiyatDetaylari.Include(u => u.FiyatParametre).Include(u => u.Musteri).Include(u => u.Urun);
            return View(urunfiyatdetaylari.ToList());
        }

        // GET: /Yonetim/UrunFiyatDetay/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UrunFiyatDetay urunfiyatdetay = db.UrunFiyatDetaylari.Find(id);
            if (urunfiyatdetay == null)
            {
                return HttpNotFound();
            }
            return View(urunfiyatdetay);
        }

        // GET: /Yonetim/UrunFiyatDetay/Create
        public ActionResult Create()
        {
            ViewBag.FiyatParametreID = new SelectList(db.FiyatParametreleri, "ID", "ParametreBaslangic");
            ViewBag.MusteriID = new SelectList(db.Musteriler, "ID", "MusteriKod");
            ViewBag.UrunID = new SelectList(db.Urunler, "ID", "UrunAdi");
            return View();
        }

        // POST: /Yonetim/UrunFiyatDetay/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="ID,Fiyat,UrunID,MusteriID,FiyatParametreID,IsLive,IsDeleted")] UrunFiyatDetay urunfiyatdetay)
        {
            if (ModelState.IsValid)
            {
                db.UrunFiyatDetaylari.Add(urunfiyatdetay);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.FiyatParametreID = new SelectList(db.FiyatParametreleri, "ID", "ParametreBaslangic", urunfiyatdetay.FiyatParametreID);
            ViewBag.MusteriID = new SelectList(db.Musteriler, "ID", "MusteriKod", urunfiyatdetay.MusteriID);
            ViewBag.UrunID = new SelectList(db.Urunler, "ID", "UrunAdi", urunfiyatdetay.UrunID);
            return View(urunfiyatdetay);
        }

        // GET: /Yonetim/UrunFiyatDetay/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UrunFiyatDetay urunfiyatdetay = db.UrunFiyatDetaylari.Find(id);
            if (urunfiyatdetay == null)
            {
                return HttpNotFound();
            }
            ViewBag.FiyatParametreID = new SelectList(db.FiyatParametreleri, "ID", "ParametreBaslangic", urunfiyatdetay.FiyatParametreID);
            ViewBag.MusteriID = new SelectList(db.Musteriler, "ID", "MusteriKod", urunfiyatdetay.MusteriID);
            ViewBag.UrunID = new SelectList(db.Urunler, "ID", "UrunAdi", urunfiyatdetay.UrunID);
            return View(urunfiyatdetay);
        }

        // POST: /Yonetim/UrunFiyatDetay/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="ID,Fiyat,UrunID,MusteriID,FiyatParametreID,IsLive,IsDeleted")] UrunFiyatDetay urunfiyatdetay)
        {
            if (ModelState.IsValid)
            {
                db.Entry(urunfiyatdetay).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.FiyatParametreID = new SelectList(db.FiyatParametreleri, "ID", "ParametreBaslangic", urunfiyatdetay.FiyatParametreID);
            ViewBag.MusteriID = new SelectList(db.Musteriler, "ID", "MusteriKod", urunfiyatdetay.MusteriID);
            ViewBag.UrunID = new SelectList(db.Urunler, "ID", "UrunAdi", urunfiyatdetay.UrunID);
            return View(urunfiyatdetay);
        }

        // GET: /Yonetim/UrunFiyatDetay/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UrunFiyatDetay urunfiyatdetay = db.UrunFiyatDetaylari.Find(id);
            if (urunfiyatdetay == null)
            {
                return HttpNotFound();
            }
            return View(urunfiyatdetay);
        }

        // POST: /Yonetim/UrunFiyatDetay/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            UrunFiyatDetay urunfiyatdetay = db.UrunFiyatDetaylari.Find(id);
            db.UrunFiyatDetaylari.Remove(urunfiyatdetay);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
