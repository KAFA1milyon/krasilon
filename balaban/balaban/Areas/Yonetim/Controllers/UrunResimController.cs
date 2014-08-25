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
    public class UrunResimController : Controller
    {
        private bContext db = new bContext();

        // GET: /Yonetim/UrunResim/
        public ActionResult Index()
        {
            var urunresimleri = db.UrunResimleri.Include(u => u.Urun);
            return View(urunresimleri.ToList());
        }

        // GET: /Yonetim/UrunResim/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UrunResim urunresim = db.UrunResimleri.Find(id);
            if (urunresim == null)
            {
                return HttpNotFound();
            }
            return View(urunresim);
        }

        // GET: /Yonetim/UrunResim/Create
        public ActionResult Create()
        {
            ViewBag.UrunID = new SelectList(db.Urunler, "ID", "UrunAdi");
            return View();
        }

        // POST: /Yonetim/UrunResim/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="ID,ResimYol,AnaResim,UrunID,IsLive,IsDeleted")] UrunResim urunresim)
        {
            if (ModelState.IsValid)
            {
                db.UrunResimleri.Add(urunresim);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.UrunID = new SelectList(db.Urunler, "ID", "UrunAdi", urunresim.UrunID);
            return View(urunresim);
        }

        // GET: /Yonetim/UrunResim/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UrunResim urunresim = db.UrunResimleri.Find(id);
            if (urunresim == null)
            {
                return HttpNotFound();
            }
            ViewBag.UrunID = new SelectList(db.Urunler, "ID", "UrunAdi", urunresim.UrunID);
            return View(urunresim);
        }

        // POST: /Yonetim/UrunResim/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="ID,ResimYol,AnaResim,UrunID,IsLive,IsDeleted")] UrunResim urunresim)
        {
            if (ModelState.IsValid)
            {
                db.Entry(urunresim).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UrunID = new SelectList(db.Urunler, "ID", "UrunAdi", urunresim.UrunID);
            return View(urunresim);
        }

        // GET: /Yonetim/UrunResim/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UrunResim urunresim = db.UrunResimleri.Find(id);
            if (urunresim == null)
            {
                return HttpNotFound();
            }
            return View(urunresim);
        }

        // POST: /Yonetim/UrunResim/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            UrunResim urunresim = db.UrunResimleri.Find(id);
            db.UrunResimleri.Remove(urunresim);
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
