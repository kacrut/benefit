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
    public class FreqCaseController : Controller
    {
        private BENEFITContext db = new BENEFITContext();

        //
        // GET: /FreqCase/

        public ActionResult Index()
        {
            return View(db.FreqCases.ToList());
        }

        //
        // GET: /FreqCase/Details/5

        public ActionResult Details(int id = 0)
        {
            FreqCase freqcase = db.FreqCases.Find(id);
            if (freqcase == null)
            {
                return HttpNotFound();
            }
            return View(freqcase);
        }

        //
        // GET: /FreqCase/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /FreqCase/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(FreqCase freqcase)
        {
            if (ModelState.IsValid)
            {
                db.FreqCases.Add(freqcase);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(freqcase);
        }

        //
        // GET: /FreqCase/Edit/5

        public ActionResult Edit(int id = 0)
        {
            FreqCase freqcase = db.FreqCases.Find(id);
            if (freqcase == null)
            {
                return HttpNotFound();
            }
            return View(freqcase);
        }

        //
        // POST: /FreqCase/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(FreqCase freqcase)
        {
            if (ModelState.IsValid)
            {
                db.Entry(freqcase).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(freqcase);
        }

        //
        // GET: /FreqCase/Delete/5

        public ActionResult Delete(int id = 0)
        {
            FreqCase freqcase = db.FreqCases.Find(id);
            if (freqcase == null)
            {
                return HttpNotFound();
            }
            return View(freqcase);
        }

        //
        // POST: /FreqCase/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            FreqCase freqcase = db.FreqCases.Find(id);
            db.FreqCases.Remove(freqcase);
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