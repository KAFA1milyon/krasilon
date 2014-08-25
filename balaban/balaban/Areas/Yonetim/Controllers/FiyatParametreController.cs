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
    public class FiyatParametreController : Controller
    {
        private bContext db = new bContext();

        // GET: /Yonetim/FiyatParametre/
        public ActionResult Index()
        {
            return View(db.FiyatParametreleri.ToList());
        }

        // GET: /Yonetim/FiyatParametre/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FiyatParametre fiyatparametre = db.FiyatParametreleri.Find(id);
            if (fiyatparametre == null)
            {
                return HttpNotFound();
            }
            return View(fiyatparametre);
        }

        // GET: /Yonetim/FiyatParametre/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Yonetim/FiyatParametre/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="ID,ParametreBaslangic,ParametreBitis,IsLive,IsDeleted")] FiyatParametre fiyatparametre)
        {
            if (ModelState.IsValid)
            {
                db.FiyatParametreleri.Add(fiyatparametre);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(fiyatparametre);
        }

        // GET: /Yonetim/FiyatParametre/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FiyatParametre fiyatparametre = db.FiyatParametreleri.Find(id);
            if (fiyatparametre == null)
            {
                return HttpNotFound();
            }
            return View(fiyatparametre);
        }

        // POST: /Yonetim/FiyatParametre/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="ID,ParametreBaslangic,ParametreBitis,IsLive,IsDeleted")] FiyatParametre fiyatparametre)
        {
            if (ModelState.IsValid)
            {
                db.Entry(fiyatparametre).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(fiyatparametre);
        }

        // GET: /Yonetim/FiyatParametre/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FiyatParametre fiyatparametre = db.FiyatParametreleri.Find(id);
            if (fiyatparametre == null)
            {
                return HttpNotFound();
            }
            return View(fiyatparametre);
        }

        // POST: /Yonetim/FiyatParametre/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            FiyatParametre fiyatparametre = db.FiyatParametreleri.Find(id);
            db.FiyatParametreleri.Remove(fiyatparametre);
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
