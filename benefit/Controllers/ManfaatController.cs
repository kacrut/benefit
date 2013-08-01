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
    public class ManfaatController : Controller
    {
        private BENEFITContext db = new BENEFITContext();

        //
        // GET: /Manfaat/

        public ActionResult Index()
        {
            return View(db.Manfaats.ToList());
        }

        //
        // GET: /Manfaat/Details/5

        public ActionResult Details(int id = 0)
        {
            Manfaat manfaat = db.Manfaats.Find(id);
            if (manfaat == null)
            {
                return HttpNotFound();
            }
            return View(manfaat);
        }

        //
        // GET: /Manfaat/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Manfaat/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Manfaat manfaat)
        {
            if (ModelState.IsValid)
            {
                db.Manfaats.Add(manfaat);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(manfaat);
        }

        //
        // GET: /Manfaat/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Manfaat manfaat = db.Manfaats.Find(id);
            if (manfaat == null)
            {
                return HttpNotFound();
            }
            return View(manfaat);
        }

        //
        // POST: /Manfaat/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Manfaat manfaat)
        {
            if (ModelState.IsValid)
            {
                db.Entry(manfaat).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(manfaat);
        }

        //
        // GET: /Manfaat/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Manfaat manfaat = db.Manfaats.Find(id);
            if (manfaat == null)
            {
                return HttpNotFound();
            }
            return View(manfaat);
        }

        //
        // POST: /Manfaat/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Manfaat manfaat = db.Manfaats.Find(id);
            db.Manfaats.Remove(manfaat);
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