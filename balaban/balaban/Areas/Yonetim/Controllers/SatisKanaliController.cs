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
    public class SatisKanaliController : Controller
    {
        private bContext db = new bContext();

        // GET: /Yonetim/SatisKanali/
        public ActionResult Index()
        {
            return View(db.SatisKanallari.ToList());
        }

        // GET: /Yonetim/SatisKanali/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SatisKanali satiskanali = db.SatisKanallari.Find(id);
            if (satiskanali == null)
            {
                return HttpNotFound();
            }
            return View(satiskanali);
        }

        // GET: /Yonetim/SatisKanali/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Yonetim/SatisKanali/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="ID,KanalAdi,IsLive,IsDeleted")] SatisKanali satiskanali)
        {
            if (ModelState.IsValid)
            {
                db.SatisKanallari.Add(satiskanali);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(satiskanali);
        }

        // GET: /Yonetim/SatisKanali/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SatisKanali satiskanali = db.SatisKanallari.Find(id);
            if (satiskanali == null)
            {
                return HttpNotFound();
            }
            return View(satiskanali);
        }

        // POST: /Yonetim/SatisKanali/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="ID,KanalAdi,IsLive,IsDeleted")] SatisKanali satiskanali)
        {
            if (ModelState.IsValid)
            {
                db.Entry(satiskanali).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(satiskanali);
        }

        // GET: /Yonetim/SatisKanali/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SatisKanali satiskanali = db.SatisKanallari.Find(id);
            if (satiskanali == null)
            {
                return HttpNotFound();
            }
            return View(satiskanali);
        }

        // POST: /Yonetim/SatisKanali/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SatisKanali satiskanali = db.SatisKanallari.Find(id);
            db.SatisKanallari.Remove(satiskanali);
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
