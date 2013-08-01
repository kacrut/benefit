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
    public class CaraBayarController : Controller
    {
        private BENEFITContext db = new BENEFITContext();

        //
        // GET: /CaraBayar/

        public ActionResult Index()
        {
            return View(db.CaraBayars.ToList());
        }

        //
        // GET: /CaraBayar/Details/5

        public ActionResult Details(int id = 0)
        {
            CaraBayar carabayar = db.CaraBayars.Find(id);
            if (carabayar == null)
            {
                return HttpNotFound();
            }
            return View(carabayar);
        }

        //
        // GET: /CaraBayar/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /CaraBayar/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CaraBayar carabayar)
        {
            if (ModelState.IsValid)
            {
                db.CaraBayars.Add(carabayar);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(carabayar);
        }

        //
        // GET: /CaraBayar/Edit/5

        public ActionResult Edit(int id = 0)
        {
            CaraBayar carabayar = db.CaraBayars.Find(id);
            if (carabayar == null)
            {
                return HttpNotFound();
            }
            return View(carabayar);
        }

        //
        // POST: /CaraBayar/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(CaraBayar carabayar)
        {
            if (ModelState.IsValid)
            {
                db.Entry(carabayar).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(carabayar);
        }

        //
        // GET: /CaraBayar/Delete/5

        public ActionResult Delete(int id = 0)
        {
            CaraBayar carabayar = db.CaraBayars.Find(id);
            if (carabayar == null)
            {
                return HttpNotFound();
            }
            return View(carabayar);
        }

        //
        // POST: /CaraBayar/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CaraBayar carabayar = db.CaraBayars.Find(id);
            db.CaraBayars.Remove(carabayar);
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