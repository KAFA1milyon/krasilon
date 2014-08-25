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
    public class MusteriAdresController : Controller
    {
        private bContext db = new bContext();

        // GET: /Yonetim/MusteriAdres/
        public ActionResult Index()
        {
            var musteriadresleri = db.MusteriAdresleri.Include(m => m.AdresTip).Include(m => m.Musteri);
            return View(musteriadresleri.ToList());
        }

        // GET: /Yonetim/MusteriAdres/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MusteriAdres musteriadres = db.MusteriAdresleri.Find(id);
            if (musteriadres == null)
            {
                return HttpNotFound();
            }
            return View(musteriadres);
        }

        // GET: /Yonetim/MusteriAdres/Create
        public ActionResult Create()
        {
            ViewBag.AdresTipID = new SelectList(db.AresTipleri, "ID", "TipTanim");
            ViewBag.MusteriID = new SelectList(db.Musteriler, "ID", "MusteriKod");
            return View();
        }

        // POST: /Yonetim/MusteriAdres/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="ID,Sehir,Adres1,Adres2,AdresOncelik,MusteriID,AdresTipID,IsLive,IsDeleted")] MusteriAdres musteriadres)
        {
            if (ModelState.IsValid)
            {
                db.MusteriAdresleri.Add(musteriadres);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AdresTipID = new SelectList(db.AresTipleri, "ID", "TipTanim", musteriadres.AdresTipID);
            ViewBag.MusteriID = new SelectList(db.Musteriler, "ID", "MusteriKod", musteriadres.MusteriID);
            return View(musteriadres);
        }

        // GET: /Yonetim/MusteriAdres/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MusteriAdres musteriadres = db.MusteriAdresleri.Find(id);
            if (musteriadres == null)
            {
                return HttpNotFound();
            }
            ViewBag.AdresTipID = new SelectList(db.AresTipleri, "ID", "TipTanim", musteriadres.AdresTipID);
            ViewBag.MusteriID = new SelectList(db.Musteriler, "ID", "MusteriKod", musteriadres.MusteriID);
            return View(musteriadres);
        }

        // POST: /Yonetim/MusteriAdres/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="ID,Sehir,Adres1,Adres2,AdresOncelik,MusteriID,AdresTipID,IsLive,IsDeleted")] MusteriAdres musteriadres)
        {
            if (ModelState.IsValid)
            {
                db.Entry(musteriadres).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AdresTipID = new SelectList(db.AresTipleri, "ID", "TipTanim", musteriadres.AdresTipID);
            ViewBag.MusteriID = new SelectList(db.Musteriler, "ID", "MusteriKod", musteriadres.MusteriID);
            return View(musteriadres);
        }

        // GET: /Yonetim/MusteriAdres/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MusteriAdres musteriadres = db.MusteriAdresleri.Find(id);
            if (musteriadres == null)
            {
                return HttpNotFound();
            }
            return View(musteriadres);
        }

        // POST: /Yonetim/MusteriAdres/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MusteriAdres musteriadres = db.MusteriAdresleri.Find(id);
            db.MusteriAdresleri.Remove(musteriadres);
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
