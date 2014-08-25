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
    public class OdemeTipController : Controller
    {
        private bContext db = new bContext();

        // GET: /Yonetim/OdemeTip/
        public ActionResult Index()
        {
            return View(db.OdemeTipleri.ToList());
        }

        // GET: /Yonetim/OdemeTip/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OdemeTip odemetip = db.OdemeTipleri.Find(id);
            if (odemetip == null)
            {
                return HttpNotFound();
            }
            return View(odemetip);
        }

        // GET: /Yonetim/OdemeTip/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Yonetim/OdemeTip/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="ID,OdemeTipAdi,IsLive,IsDeleted")] OdemeTip odemetip)
        {
            if (ModelState.IsValid)
            {
                db.OdemeTipleri.Add(odemetip);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(odemetip);
        }

        // GET: /Yonetim/OdemeTip/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OdemeTip odemetip = db.OdemeTipleri.Find(id);
            if (odemetip == null)
            {
                return HttpNotFound();
            }
            return View(odemetip);
        }

        // POST: /Yonetim/OdemeTip/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="ID,OdemeTipAdi,IsLive,IsDeleted")] OdemeTip odemetip)
        {
            if (ModelState.IsValid)
            {
                db.Entry(odemetip).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(odemetip);
        }

        // GET: /Yonetim/OdemeTip/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OdemeTip odemetip = db.OdemeTipleri.Find(id);
            if (odemetip == null)
            {
                return HttpNotFound();
            }
            return View(odemetip);
        }

        // POST: /Yonetim/OdemeTip/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            OdemeTip odemetip = db.OdemeTipleri.Find(id);
            db.OdemeTipleri.Remove(odemetip);
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
