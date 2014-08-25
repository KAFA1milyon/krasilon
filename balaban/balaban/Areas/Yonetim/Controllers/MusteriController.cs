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
    public class MusteriController : Controller
    {
        private bContext db = new bContext();

        // GET: /Yonetim/Musteri/
        public ActionResult Index()
        {
            var musteriler = db.Musteriler.Include(m => m.MusteriTip);
            return View(musteriler.ToList());
        }

        // GET: /Yonetim/Musteri/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Musteri musteri = db.Musteriler.Find(id);
            if (musteri == null)
            {
                return HttpNotFound();
            }
            return View(musteri);
        }

        // GET: /Yonetim/Musteri/Create
        public ActionResult Create()
        {
            ViewBag.MusteriTipID = new SelectList(db.MusteriTipleri, "ID", "TipTanim");
            return View();
        }

        // POST: /Yonetim/Musteri/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="ID,MusteriKod,MusteriTipID,KullaniciAdi,Sifre,VergiNo,TCKimlikNo,VergiDairesi,IrtibatIsim,IrtibatNo,IsLive,IsDeleted")] Musteri musteri)
        {
            if (ModelState.IsValid)
            {
                db.Musteriler.Add(musteri);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MusteriTipID = new SelectList(db.MusteriTipleri, "ID", "TipTanim", musteri.MusteriTipID);
            return View(musteri);
        }

        // GET: /Yonetim/Musteri/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Musteri musteri = db.Musteriler.Find(id);
            if (musteri == null)
            {
                return HttpNotFound();
            }
            ViewBag.MusteriTipID = new SelectList(db.MusteriTipleri, "ID", "TipTanim", musteri.MusteriTipID);
            return View(musteri);
        }

        // POST: /Yonetim/Musteri/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="ID,MusteriKod,MusteriTipID,KullaniciAdi,Sifre,VergiNo,TCKimlikNo,VergiDairesi,IrtibatIsim,IrtibatNo,IsLive,IsDeleted")] Musteri musteri)
        {
            if (ModelState.IsValid)
            {
                db.Entry(musteri).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MusteriTipID = new SelectList(db.MusteriTipleri, "ID", "TipTanim", musteri.MusteriTipID);
            return View(musteri);
        }

        // GET: /Yonetim/Musteri/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Musteri musteri = db.Musteriler.Find(id);
            if (musteri == null)
            {
                return HttpNotFound();
            }
            return View(musteri);
        }

        // POST: /Yonetim/Musteri/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Musteri musteri = db.Musteriler.Find(id);
            db.Musteriler.Remove(musteri);
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
