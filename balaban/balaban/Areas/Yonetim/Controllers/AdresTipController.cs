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
    public class AdresTipController : Controller
    {
        private bContext db = new bContext();

        // GET: /Yonetim/AdresTip/
        public ActionResult Index()
        {
            return View(db.AresTipleri.ToList());
        }

        // GET: /Yonetim/AdresTip/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AdresTip adrestip = db.AresTipleri.Find(id);
            if (adrestip == null)
            {
                return HttpNotFound();
            }
            return View(adrestip);
        }

        // GET: /Yonetim/AdresTip/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Yonetim/AdresTip/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="ID,TipTanim")] AdresTip adrestip)
        {
            if (ModelState.IsValid)
            {
                db.AresTipleri.Add(adrestip);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(adrestip);
        }

        // GET: /Yonetim/AdresTip/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AdresTip adrestip = db.AresTipleri.Find(id);
            if (adrestip == null)
            {
                return HttpNotFound();
            }
            return View(adrestip);
        }

        // POST: /Yonetim/AdresTip/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="ID,TipTanim")] AdresTip adrestip)
        {
            if (ModelState.IsValid)
            {
                db.Entry(adrestip).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(adrestip);
        }

        // GET: /Yonetim/AdresTip/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AdresTip adrestip = db.AresTipleri.Find(id);
            if (adrestip == null)
            {
                return HttpNotFound();
            }
            return View(adrestip);
        }

        // POST: /Yonetim/AdresTip/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AdresTip adrestip = db.AresTipleri.Find(id);
            db.AresTipleri.Remove(adrestip);
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
