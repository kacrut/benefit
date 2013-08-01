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
    public class PolisPegawaiController : Controller
    {
        private BENEFITContext db = new BENEFITContext();

        //
        // GET: /PolisPegawai/

        public ActionResult Index()
        {
            return View(db.PolisPegawais.ToList());
        }

        //
        // GET: /PolisPegawai/Details/5

        public ActionResult Details(int id = 0)
        {
            PolisPegawai polispegawai = db.PolisPegawais.Find(id);
            if (polispegawai == null)
            {
                return HttpNotFound();
            }
            return View(polispegawai);
        }

        //
        // GET: /PolisPegawai/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /PolisPegawai/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PolisPegawai polispegawai)
        {
            if (ModelState.IsValid)
            {
                db.PolisPegawais.Add(polispegawai);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(polispegawai);
        }

        //
        // GET: /PolisPegawai/Edit/5

        public ActionResult Edit(int id = 0)
        {
            PolisPegawai polispegawai = db.PolisPegawais.Find(id);
            if (polispegawai == null)
            {
                return HttpNotFound();
            }
            return View(polispegawai);
        }

        //
        // POST: /PolisPegawai/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(PolisPegawai polispegawai)
        {
            if (ModelState.IsValid)
            {
                db.Entry(polispegawai).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(polispegawai);
        }

        //
        // GET: /PolisPegawai/Delete/5

        public ActionResult Delete(int id = 0)
        {
            PolisPegawai polispegawai = db.PolisPegawais.Find(id);
            if (polispegawai == null)
            {
                return HttpNotFound();
            }
            return View(polispegawai);
        }

        //
        // POST: /PolisPegawai/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PolisPegawai polispegawai = db.PolisPegawais.Find(id);
            db.PolisPegawais.Remove(polispegawai);
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