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
    public class SiparisUrunDetayController : Controller
    {
        private bContext db = new bContext();

        // GET: /Yonetim/SiparisUrunDetay/
        public ActionResult Index()
        {
            var siprasiurundetaylari = db.SiprasiUrunDetaylari.Include(s => s.Siparis).Include(s => s.Urun);
            return View(siprasiurundetaylari.ToList());
        }

        // GET: /Yonetim/SiparisUrunDetay/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SiparisUrunDetay siparisurundetay = db.SiprasiUrunDetaylari.Find(id);
            if (siparisurundetay == null)
            {
                return HttpNotFound();
            }
            return View(siparisurundetay);
        }

        // GET: /Yonetim/SiparisUrunDetay/Create
        public ActionResult Create()
        {
            ViewBag.SiparisID = new SelectList(db.Siparisler, "ID", "ID");
            ViewBag.UrunID = new SelectList(db.Urunler, "ID", "UrunAdi");
            return View();
        }

        // POST: /Yonetim/SiparisUrunDetay/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="ID,Miktar,BirimFiyat,ToplamTutar,UrunID,SiparisID,IsLive,IsDeleted")] SiparisUrunDetay siparisurundetay)
        {
            if (ModelState.IsValid)
            {
                db.SiprasiUrunDetaylari.Add(siparisurundetay);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.SiparisID = new SelectList(db.Siparisler, "ID", "ID", siparisurundetay.SiparisID);
            ViewBag.UrunID = new SelectList(db.Urunler, "ID", "UrunAdi", siparisurundetay.UrunID);
            return View(siparisurundetay);
        }

        // GET: /Yonetim/SiparisUrunDetay/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SiparisUrunDetay siparisurundetay = db.SiprasiUrunDetaylari.Find(id);
            if (siparisurundetay == null)
            {
                return HttpNotFound();
            }
            ViewBag.SiparisID = new SelectList(db.Siparisler, "ID", "ID", siparisurundetay.SiparisID);
            ViewBag.UrunID = new SelectList(db.Urunler, "ID", "UrunAdi", siparisurundetay.UrunID);
            return View(siparisurundetay);
        }

        // POST: /Yonetim/SiparisUrunDetay/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="ID,Miktar,BirimFiyat,ToplamTutar,UrunID,SiparisID,IsLive,IsDeleted")] SiparisUrunDetay siparisurundetay)
        {
            if (ModelState.IsValid)
            {
                db.Entry(siparisurundetay).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.SiparisID = new SelectList(db.Siparisler, "ID", "ID", siparisurundetay.SiparisID);
            ViewBag.UrunID = new SelectList(db.Urunler, "ID", "UrunAdi", siparisurundetay.UrunID);
            return View(siparisurundetay);
        }

        // GET: /Yonetim/SiparisUrunDetay/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SiparisUrunDetay siparisurundetay = db.SiprasiUrunDetaylari.Find(id);
            if (siparisurundetay == null)
            {
                return HttpNotFound();
            }
            return View(siparisurundetay);
        }

        // POST: /Yonetim/SiparisUrunDetay/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SiparisUrunDetay siparisurundetay = db.SiprasiUrunDetaylari.Find(id);
            db.SiprasiUrunDetaylari.Remove(siparisurundetay);
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
