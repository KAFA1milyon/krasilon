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
    public class UrunDetayController : Controller
    {
        private bContext db = new bContext();

        // GET: /Yonetim/UrunDetay/
        //public ActionResult Index()
        //{
        //    var UrunDetay = db.UrunDetay.Include(u => u.Urun);
        //    return View(UrunDetay.ToList());
        //}

        //// GET: /Yonetim/UrunDetay/Details/5
        //public ActionResult Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    UrunDetay urundetay = db.UrunDetay.Find(id);
        //    if (urundetay == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(urundetay);
        //}

        //// GET: /Yonetim/UrunDetay/Create
        //public ActionResult Create()
        //{
        //    ViewBag.UrunID = new SelectList(db.Urunler, "ID", "UrunAdi");
        //    return View();
        //}

        //// POST: /Yonetim/UrunDetay/Create
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include="ID,DetayText,UrunID,IsLive,IsDeleted")] UrunDetay urundetay)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.UrunDetay.Add(urundetay);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    ViewBag.UrunID = new SelectList(db.Urunler, "ID", "UrunAdi", urundetay.UrunID);
        //    return View(urundetay);
        //}

        //// GET: /Yonetim/UrunDetay/Edit/5
        //public ActionResult Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    UrunDetay urundetay = db.UrunDetay.Find(id);
        //    if (urundetay == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    ViewBag.UrunID = new SelectList(db.Urunler, "ID", "UrunAdi", urundetay.UrunID);
        //    return View(urundetay);
        //}

        //// POST: /Yonetim/UrunDetay/Edit/5
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include="ID,DetayText,UrunID,IsLive,IsDeleted")] UrunDetay urundetay)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(urundetay).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    ViewBag.UrunID = new SelectList(db.Urunler, "ID", "UrunAdi", urundetay.UrunID);
        //    return View(urundetay);
        //}

        //// GET: /Yonetim/UrunDetay/Delete/5
        //public ActionResult Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    UrunDetay urundetay = db.UrunDetay.Find(id);
        //    if (urundetay == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(urundetay);
        //}

        //// POST: /Yonetim/UrunDetay/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    UrunDetay urundetay = db.UrunDetay.Find(id);
        //    db.UrunDetay.Remove(urundetay);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}
    }
}
