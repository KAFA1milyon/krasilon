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
    public class UrunFiyatController : Controller
    {
        private bContext db = new bContext();

        // GET: /Yonetim/UrunFiyat/
        public ActionResult Index()
        {
            var urunfiyatlari = db.UrunFiyatlari.Include(u => u.OdemeTip).Include(u => u.SatisKanal).Include(u => u.Urun);
            return View(urunfiyatlari.ToList());
        }

        // GET: /Yonetim/UrunFiyat/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UrunFiyat urunfiyat = db.UrunFiyatlari.Find(id);
            if (urunfiyat == null)
            {
                return HttpNotFound();
            }
            return View(urunfiyat);
        }

        // GET: /Yonetim/UrunFiyat/Create
        public ActionResult Create()
        {
            ViewBag.OdemeTipID = new SelectList(db.OdemeTipleri, "ID", "OdemeTipAdi");
            ViewBag.SatisKanalID = new SelectList(db.SatisKanallari, "ID", "KanalAdi");
            ViewBag.UrunID = new SelectList(db.Urunler, "ID", "UrunAdi");
            return View();
        }

        // POST: /Yonetim/UrunFiyat/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="ID,Fiyat,UrunID,SatisKanalID,OdemeTipID,IsLive,IsDeleted")] UrunFiyat urunfiyat)
        {
            if (ModelState.IsValid)
            {
                db.UrunFiyatlari.Add(urunfiyat);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.OdemeTipID = new SelectList(db.OdemeTipleri, "ID", "OdemeTipAdi", urunfiyat.OdemeTipID);
            ViewBag.SatisKanalID = new SelectList(db.SatisKanallari, "ID", "KanalAdi", urunfiyat.SatisKanalID);
            ViewBag.UrunID = new SelectList(db.Urunler, "ID", "UrunAdi", urunfiyat.UrunID);
            return View(urunfiyat);
        }

        // GET: /Yonetim/UrunFiyat/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UrunFiyat urunfiyat = db.UrunFiyatlari.Find(id);
            if (urunfiyat == null)
            {
                return HttpNotFound();
            }
            ViewBag.OdemeTipID = new SelectList(db.OdemeTipleri, "ID", "OdemeTipAdi", urunfiyat.OdemeTipID);
            ViewBag.SatisKanalID = new SelectList(db.SatisKanallari, "ID", "KanalAdi", urunfiyat.SatisKanalID);
            ViewBag.UrunID = new SelectList(db.Urunler, "ID", "UrunAdi", urunfiyat.UrunID);
            return View(urunfiyat);
        }

        // POST: /Yonetim/UrunFiyat/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="ID,Fiyat,UrunID,SatisKanalID,OdemeTipID,IsLive,IsDeleted")] UrunFiyat urunfiyat)
        {
            if (ModelState.IsValid)
            {
                db.Entry(urunfiyat).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.OdemeTipID = new SelectList(db.OdemeTipleri, "ID", "OdemeTipAdi", urunfiyat.OdemeTipID);
            ViewBag.SatisKanalID = new SelectList(db.SatisKanallari, "ID", "KanalAdi", urunfiyat.SatisKanalID);
            ViewBag.UrunID = new SelectList(db.Urunler, "ID", "UrunAdi", urunfiyat.UrunID);
            return View(urunfiyat);
        }

        // GET: /Yonetim/UrunFiyat/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UrunFiyat urunfiyat = db.UrunFiyatlari.Find(id);
            if (urunfiyat == null)
            {
                return HttpNotFound();
            }
            return View(urunfiyat);
        }

        // POST: /Yonetim/UrunFiyat/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            UrunFiyat urunfiyat = db.UrunFiyatlari.Find(id);
            db.UrunFiyatlari.Remove(urunfiyat);
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
