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
    public class SiparisController : Controller
    {
        private bContext db = new bContext();

        // GET: /Yonetim/Siparis/
        public ActionResult Index()
        {
            var siparisler = db.Siparisler.Include(s => s.Musteri);
            return View(siparisler.ToList());
        }

        // GET: /Yonetim/Siparis/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Siparis siparis = db.Siparisler.Find(id);
            if (siparis == null)
            {
                return HttpNotFound();
            }
            return View(siparis);
        }

        // GET: /Yonetim/Siparis/Create
        public ActionResult Create()
        {
            ViewBag.MusteriID = new SelectList(db.Musteriler, "ID", "MusteriKod");
            return View();
        }

        // POST: /Yonetim/Siparis/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="ID,SiparisTarihi,MusteriID,IsLive,IsDeleted")] Siparis siparis)
        {
            if (ModelState.IsValid)
            {
                db.Siparisler.Add(siparis);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MusteriID = new SelectList(db.Musteriler, "ID", "MusteriKod", siparis.MusteriID);
            return View(siparis);
        }

        // GET: /Yonetim/Siparis/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Siparis siparis = db.Siparisler.Find(id);
            if (siparis == null)
            {
                return HttpNotFound();
            }
            ViewBag.MusteriID = new SelectList(db.Musteriler, "ID", "MusteriKod", siparis.MusteriID);
            return View(siparis);
        }

        // POST: /Yonetim/Siparis/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="ID,SiparisTarihi,MusteriID,IsLive,IsDeleted")] Siparis siparis)
        {
            if (ModelState.IsValid)
            {
                db.Entry(siparis).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MusteriID = new SelectList(db.Musteriler, "ID", "MusteriKod", siparis.MusteriID);
            return View(siparis);
        }

        // GET: /Yonetim/Siparis/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Siparis siparis = db.Siparisler.Find(id);
            if (siparis == null)
            {
                return HttpNotFound();
            }
            return View(siparis);
        }

        // POST: /Yonetim/Siparis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Siparis siparis = db.Siparisler.Find(id);
            db.Siparisler.Remove(siparis);
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
