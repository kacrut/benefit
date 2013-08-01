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
    public class ManfaatPISAController : Controller
    {
        private BENEFITContext db = new BENEFITContext();

        //
        // GET: /ManfaatPISA/

        public ActionResult Index()
        {
            return View(db.ManfaatPISAs.ToList());
        }

        //
        // GET: /ManfaatPISA/Details/5

        public ActionResult Details(int id = 0)
        {
            ManfaatPISA manfaatpisa = db.ManfaatPISAs.Find(id);
            if (manfaatpisa == null)
            {
                return HttpNotFound();
            }
            return View(manfaatpisa);
        }

        //
        // GET: /ManfaatPISA/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /ManfaatPISA/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ManfaatPISA manfaatpisa)
        {
            if (ModelState.IsValid)
            {
                db.ManfaatPISAs.Add(manfaatpisa);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(manfaatpisa);
        }

        //
        // GET: /ManfaatPISA/Edit/5

        public ActionResult Edit(int id = 0)
        {
            ManfaatPISA manfaatpisa = db.ManfaatPISAs.Find(id);
            if (manfaatpisa == null)
            {
                return HttpNotFound();
            }
            return View(manfaatpisa);
        }

        //
        // POST: /ManfaatPISA/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ManfaatPISA manfaatpisa)
        {
            if (ModelState.IsValid)
            {
                db.Entry(manfaatpisa).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(manfaatpisa);
        }

        //
        // GET: /ManfaatPISA/Delete/5

        public ActionResult Delete(int id = 0)
        {
            ManfaatPISA manfaatpisa = db.ManfaatPISAs.Find(id);
            if (manfaatpisa == null)
            {
                return HttpNotFound();
            }
            return View(manfaatpisa);
        }

        //
        // POST: /ManfaatPISA/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ManfaatPISA manfaatpisa = db.ManfaatPISAs.Find(id);
            db.ManfaatPISAs.Remove(manfaatpisa);
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