using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using benefit.Models;

namespace benefit.Controllers
{
    public class ManfaatInManfaatItemController : Controller
    {
        private BENEFITContext db = new BENEFITContext();

        //
        // GET: /ManfaatInManfaatItem/

        public ActionResult Index()
        {
            var manfaatinmanfaatitems = db.ManfaatInManfaatItems.Include(m => m.Manfaat).Include(m => m.ManfaatItem);
            return View(manfaatinmanfaatitems.OrderBy(a=>a.ManfaatID).ThenBy(a=>a.ManfaatItemID).ToList());
        }

        //
        // GET: /ManfaatInManfaatItem/Details/5

        public ActionResult Details(int id = 0)
        {
            ManfaatInManfaatItem manfaatinmanfaatitem = db.ManfaatInManfaatItems.Find(id);
            if (manfaatinmanfaatitem == null)
            {
                return HttpNotFound();
            }
            return View(manfaatinmanfaatitem);
        }

        //
        // GET: /ManfaatInManfaatItem/Create

        public ActionResult Create()
        {
            ViewBag.ManfaatID = new SelectList(db.Manfaats, "ManfaatID", "NamaManfaat");
            ViewBag.ManfaatItemID = new SelectList(db.ManfaatItems, "ManfaatItemID", "ManfaatItemName");
            return View();
        }

        //
        // POST: /ManfaatInManfaatItem/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ManfaatInManfaatItem manfaatinmanfaatitem)
        {
            if (ModelState.IsValid)
            {
                db.ManfaatInManfaatItems.Add(manfaatinmanfaatitem);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ManfaatID = new SelectList(db.Manfaats, "ManfaatID", "NamaManfaat", manfaatinmanfaatitem.ManfaatID);
            ViewBag.ManfaatItemID = new SelectList(db.ManfaatItems, "ManfaatItemID", "ManfaatItemName", manfaatinmanfaatitem.ManfaatItemID);
            return View(manfaatinmanfaatitem);
        }

        //
        // GET: /ManfaatInManfaatItem/Edit/5

        public ActionResult Edit(int id = 0)
        {
            ManfaatInManfaatItem manfaatinmanfaatitem = db.ManfaatInManfaatItems.Find(id);
            if (manfaatinmanfaatitem == null)
            {
                return HttpNotFound();
            }
            ViewBag.ManfaatID = new SelectList(db.Manfaats, "ManfaatID", "NamaManfaat", manfaatinmanfaatitem.ManfaatID);
            ViewBag.ManfaatItemID = new SelectList(db.ManfaatItems, "ManfaatItemID", "ManfaatItemName", manfaatinmanfaatitem.ManfaatItemID);
            return View(manfaatinmanfaatitem);
        }

        //
        // POST: /ManfaatInManfaatItem/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ManfaatInManfaatItem manfaatinmanfaatitem)
        {
            if (ModelState.IsValid)
            {
                db.Entry(manfaatinmanfaatitem).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ManfaatID = new SelectList(db.Manfaats, "ManfaatID", "NamaManfaat", manfaatinmanfaatitem.ManfaatID);
            ViewBag.ManfaatItemID = new SelectList(db.ManfaatItems, "ManfaatItemID", "ManfaatItemName", manfaatinmanfaatitem.ManfaatItemID);
            return View(manfaatinmanfaatitem);
        }

        //
        // GET: /ManfaatInManfaatItem/Delete/5

        public ActionResult Delete(int id = 0)
        {
            ManfaatInManfaatItem manfaatinmanfaatitem = db.ManfaatInManfaatItems.Find(id);
            if (manfaatinmanfaatitem == null)
            {
                return HttpNotFound();
            }
            return View(manfaatinmanfaatitem);
        }

        //
        // POST: /ManfaatInManfaatItem/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ManfaatInManfaatItem manfaatinmanfaatitem = db.ManfaatInManfaatItems.Find(id);
            db.ManfaatInManfaatItems.Remove(manfaatinmanfaatitem);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}