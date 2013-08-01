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
    public class vwInfoBenefitController : Controller
    {
        private BENEFITContext db = new BENEFITContext();

        //
        // GET: /vwInfoBenefit/

        public ActionResult Index()
        {
            return View(db.vwInfoBenefits.ToList());
        }

        //
        // GET: /vwInfoBenefit/Details/5

        public ActionResult Details(int id = 0)
        {
            vwInfoBenefit vwinfobenefit = db.vwInfoBenefits.Find(id);
            if (vwinfobenefit == null)
            {
                return HttpNotFound();
            }
            return View(vwinfobenefit);
        }

        //
        // GET: /vwInfoBenefit/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /vwInfoBenefit/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(vwInfoBenefit vwinfobenefit)
        {
            if (ModelState.IsValid)
            {
                db.vwInfoBenefits.Add(vwinfobenefit);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(vwinfobenefit);
        }

        //
        // GET: /vwInfoBenefit/Edit/5

        public ActionResult Edit(int id = 0)
        {
            vwInfoBenefit vwinfobenefit = db.vwInfoBenefits.Find(id);
            if (vwinfobenefit == null)
            {
                return HttpNotFound();
            }
            return View(vwinfobenefit);
        }

        //
        // POST: /vwInfoBenefit/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(vwInfoBenefit vwinfobenefit)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vwinfobenefit).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(vwinfobenefit);
        }

        //
        // GET: /vwInfoBenefit/Delete/5

        public ActionResult Delete(int id = 0)
        {
            vwInfoBenefit vwinfobenefit = db.vwInfoBenefits.Find(id);
            if (vwinfobenefit == null)
            {
                return HttpNotFound();
            }
            return View(vwinfobenefit);
        }

        //
        // POST: /vwInfoBenefit/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            vwInfoBenefit vwinfobenefit = db.vwInfoBenefits.Find(id);
            db.vwInfoBenefits.Remove(vwinfobenefit);
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