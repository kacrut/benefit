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
    public class FreqPeriodeController : Controller
    {
        private BENEFITContext db = new BENEFITContext();

        //
        // GET: /FreqPeriode/

        public ActionResult Index()
        {
            return View(db.FreqPeriodes.ToList());
        }

        //
        // GET: /FreqPeriode/Details/5

        public ActionResult Details(int id = 0)
        {
            FreqPeriode freqperiode = db.FreqPeriodes.Find(id);
            if (freqperiode == null)
            {
                return HttpNotFound();
            }
            return View(freqperiode);
        }

        //
        // GET: /FreqPeriode/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /FreqPeriode/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(FreqPeriode freqperiode)
        {
            if (ModelState.IsValid)
            {
                db.FreqPeriodes.Add(freqperiode);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(freqperiode);
        }

        //
        // GET: /FreqPeriode/Edit/5

        public ActionResult Edit(int id = 0)
        {
            FreqPeriode freqperiode = db.FreqPeriodes.Find(id);
            if (freqperiode == null)
            {
                return HttpNotFound();
            }
            return View(freqperiode);
        }

        //
        // POST: /FreqPeriode/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(FreqPeriode freqperiode)
        {
            if (ModelState.IsValid)
            {
                db.Entry(freqperiode).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(freqperiode);
        }

        //
        // GET: /FreqPeriode/Delete/5

        public ActionResult Delete(int id = 0)
        {
            FreqPeriode freqperiode = db.FreqPeriodes.Find(id);
            if (freqperiode == null)
            {
                return HttpNotFound();
            }
            return View(freqperiode);
        }

        //
        // POST: /FreqPeriode/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            FreqPeriode freqperiode = db.FreqPeriodes.Find(id);
            db.FreqPeriodes.Remove(freqperiode);
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