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
    public class MusteriTipController : Controller
    {
        private bContext db = new bContext();

        // GET: /Yonetim/MusteriTip/
        public ActionResult Index()
        {
            return View(db.MusteriTipleri.ToList());
        }

        // GET: /Yonetim/MusteriTip/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MusteriTip musteritip = db.MusteriTipleri.Find(id);
            if (musteritip == null)
            {
                return HttpNotFound();
            }
            return View(musteritip);
        }

        // GET: /Yonetim/MusteriTip/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Yonetim/MusteriTip/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="ID,TipTanim,IsLive,IsDeleted")] MusteriTip musteritip)
        {
            if (ModelState.IsValid)
            {
                db.MusteriTipleri.Add(musteritip);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(musteritip);
        }

        // GET: /Yonetim/MusteriTip/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MusteriTip musteritip = db.MusteriTipleri.Find(id);
            if (musteritip == null)
            {
                return HttpNotFound();
            }
            return View(musteritip);
        }

        // POST: /Yonetim/MusteriTip/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="ID,TipTanim,IsLive,IsDeleted")] MusteriTip musteritip)
        {
            if (ModelState.IsValid)
            {
                db.Entry(musteritip).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(musteritip);
        }

        // GET: /Yonetim/MusteriTip/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MusteriTip musteritip = db.MusteriTipleri.Find(id);
            if (musteritip == null)
            {
                return HttpNotFound();
            }
            return View(musteritip);
        }

        // POST: /Yonetim/MusteriTip/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MusteriTip musteritip = db.MusteriTipleri.Find(id);
            db.MusteriTipleri.Remove(musteritip);
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
