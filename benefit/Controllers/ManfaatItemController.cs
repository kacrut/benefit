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
    public class ManfaatItemController : Controller
    {
        private BENEFITContext db = new BENEFITContext();

        //
        // GET: /ManfaatItem/

        public ActionResult Index()
        {
            return View(db.ManfaatItems.ToList());
        }

        //
        // GET: /ManfaatItem/Details/5

        public ActionResult Details(int id = 0)
        {
            ManfaatItem manfaatitem = db.ManfaatItems.Find(id);
            if (manfaatitem == null)
            {
                return HttpNotFound();
            }
            return View(manfaatitem);
        }

        //
        // GET: /ManfaatItem/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /ManfaatItem/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ManfaatItem manfaatitem)
        {
            if (ModelState.IsValid)
            {
                db.ManfaatItems.Add(manfaatitem);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(manfaatitem);
        }

        //
        // GET: /ManfaatItem/Edit/5

        public ActionResult Edit(int id = 0)
        {
            ManfaatItem manfaatitem = db.ManfaatItems.Find(id);
            if (manfaatitem == null)
            {
                return HttpNotFound();
            }
            return View(manfaatitem);
        }

        //
        // POST: /ManfaatItem/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ManfaatItem manfaatitem)
        {
            if (ModelState.IsValid)
            {
                db.Entry(manfaatitem).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(manfaatitem);
        }

        //
        // GET: /ManfaatItem/Delete/5

        public ActionResult Delete(int id = 0)
        {
            ManfaatItem manfaatitem = db.ManfaatItems.Find(id);
            if (manfaatitem == null)
            {
                return HttpNotFound();
            }
            return View(manfaatitem);
        }

        //
        // POST: /ManfaatItem/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ManfaatItem manfaatitem = db.ManfaatItems.Find(id);
            db.ManfaatItems.Remove(manfaatitem);
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