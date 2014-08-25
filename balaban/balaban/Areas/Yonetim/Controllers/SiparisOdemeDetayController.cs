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
    public class SiparisOdemeDetayController : Controller
    {
        private bContext db = new bContext();

        // GET: /Yonetim/SiparisOdemeDetay/
        public ActionResult Index()
        {
            var siparisodemedetaylari = db.SiparisOdemeDetaylari.Include(s => s.OdemeTip).Include(s => s.SatisKanali);
            return View(siparisodemedetaylari.ToList());
        }

        // GET: /Yonetim/SiparisOdemeDetay/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SiparisOdemeDetay siparisodemedetay = db.SiparisOdemeDetaylari.Find(id);
            if (siparisodemedetay == null)
            {
                return HttpNotFound();
            }
            return View(siparisodemedetay);
        }

        // GET: /Yonetim/SiparisOdemeDetay/Create
        public ActionResult Create()
        {
            ViewBag.OdemeTipID = new SelectList(db.OdemeTipleri, "ID", "OdemeTipAdi");
            ViewBag.SatisKanalID = new SelectList(db.SatisKanallari, "ID", "KanalAdi");
            return View();
        }

        // POST: /Yonetim/SiparisOdemeDetay/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="ID,OdemeTutari,OdemeTipID,SatisKanalID,IsLive,IsDeleted")] SiparisOdemeDetay siparisodemedetay)
        {
            if (ModelState.IsValid)
            {
                db.SiparisOdemeDetaylari.Add(siparisodemedetay);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.OdemeTipID = new SelectList(db.OdemeTipleri, "ID", "OdemeTipAdi", siparisodemedetay.OdemeTipID);
            ViewBag.SatisKanalID = new SelectList(db.SatisKanallari, "ID", "KanalAdi", siparisodemedetay.SatisKanalID);
            return View(siparisodemedetay);
        }

        // GET: /Yonetim/SiparisOdemeDetay/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SiparisOdemeDetay siparisodemedetay = db.SiparisOdemeDetaylari.Find(id);
            if (siparisodemedetay == null)
            {
                return HttpNotFound();
            }
            ViewBag.OdemeTipID = new SelectList(db.OdemeTipleri, "ID", "OdemeTipAdi", siparisodemedetay.OdemeTipID);
            ViewBag.SatisKanalID = new SelectList(db.SatisKanallari, "ID", "KanalAdi", siparisodemedetay.SatisKanalID);
            return View(siparisodemedetay);
        }

        // POST: /Yonetim/SiparisOdemeDetay/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="ID,OdemeTutari,OdemeTipID,SatisKanalID,IsLive,IsDeleted")] SiparisOdemeDetay siparisodemedetay)
        {
            if (ModelState.IsValid)
            {
                db.Entry(siparisodemedetay).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.OdemeTipID = new SelectList(db.OdemeTipleri, "ID", "OdemeTipAdi", siparisodemedetay.OdemeTipID);
            ViewBag.SatisKanalID = new SelectList(db.SatisKanallari, "ID", "KanalAdi", siparisodemedetay.SatisKanalID);
            return View(siparisodemedetay);
        }

        // GET: /Yonetim/SiparisOdemeDetay/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SiparisOdemeDetay siparisodemedetay = db.SiparisOdemeDetaylari.Find(id);
            if (siparisodemedetay == null)
            {
                return HttpNotFound();
            }
            return View(siparisodemedetay);
        }

        // POST: /Yonetim/SiparisOdemeDetay/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SiparisOdemeDetay siparisodemedetay = db.SiparisOdemeDetaylari.Find(id);
            db.SiparisOdemeDetaylari.Remove(siparisodemedetay);
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
