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
    public class MusteriTelefonController : Controller
    {
        private bContext db = new bContext();

        // GET: /Yonetim/MusteriTelefon/
        public ActionResult Index()
        {
            var musteritelefonlari = db.MusteriTelefonlari.Include(m => m.Musteri).Include(m => m.TelefonTip);
            return View(musteritelefonlari.ToList());
        }

        // GET: /Yonetim/MusteriTelefon/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MusteriTelefon musteritelefon = db.MusteriTelefonlari.Find(id);
            if (musteritelefon == null)
            {
                return HttpNotFound();
            }
            return View(musteritelefon);
        }

        // GET: /Yonetim/MusteriTelefon/Create
        public ActionResult Create()
        {
            ViewBag.MusteriID = new SelectList(db.Musteriler, "ID", "MusteriKod");
            ViewBag.TelefonTipID = new SelectList(db.TelefonTipleri, "ID", "TipTanim");
            return View();
        }

        // POST: /Yonetim/MusteriTelefon/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="ID,TelNo,TelOncelik,MusteriID,TelefonTipID,IsLive,IsDeleted")] MusteriTelefon musteritelefon)
        {
            if (ModelState.IsValid)
            {
                db.MusteriTelefonlari.Add(musteritelefon);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MusteriID = new SelectList(db.Musteriler, "ID", "MusteriKod", musteritelefon.MusteriID);
            ViewBag.TelefonTipID = new SelectList(db.TelefonTipleri, "ID", "TipTanim", musteritelefon.TelefonTipID);
            return View(musteritelefon);
        }

        // GET: /Yonetim/MusteriTelefon/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MusteriTelefon musteritelefon = db.MusteriTelefonlari.Find(id);
            if (musteritelefon == null)
            {
                return HttpNotFound();
            }
            ViewBag.MusteriID = new SelectList(db.Musteriler, "ID", "MusteriKod", musteritelefon.MusteriID);
            ViewBag.TelefonTipID = new SelectList(db.TelefonTipleri, "ID", "TipTanim", musteritelefon.TelefonTipID);
            return View(musteritelefon);
        }

        // POST: /Yonetim/MusteriTelefon/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="ID,TelNo,TelOncelik,MusteriID,TelefonTipID,IsLive,IsDeleted")] MusteriTelefon musteritelefon)
        {
            if (ModelState.IsValid)
            {
                db.Entry(musteritelefon).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MusteriID = new SelectList(db.Musteriler, "ID", "MusteriKod", musteritelefon.MusteriID);
            ViewBag.TelefonTipID = new SelectList(db.TelefonTipleri, "ID", "TipTanim", musteritelefon.TelefonTipID);
            return View(musteritelefon);
        }

        // GET: /Yonetim/MusteriTelefon/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MusteriTelefon musteritelefon = db.MusteriTelefonlari.Find(id);
            if (musteritelefon == null)
            {
                return HttpNotFound();
            }
            return View(musteritelefon);
        }

        // POST: /Yonetim/MusteriTelefon/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MusteriTelefon musteritelefon = db.MusteriTelefonlari.Find(id);
            db.MusteriTelefonlari.Remove(musteritelefon);
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
